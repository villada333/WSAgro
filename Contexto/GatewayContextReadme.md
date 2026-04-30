# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**WSGW** (WebService Gateway) is an ASP.NET Core 8 API Gateway that acts as a reverse proxy with JWT validation, IP rate limiting, and YARP-based request routing to downstream microservices. Deployed on Render.com — the Gateway is the primary public entry point; WSAuth is also deployed as a public Web Service (`wsauth.onrender.com`), while WSAgro runs on Render's private network.

## Build & Run Commands

```bash
# Build solution
dotnet build WSGW.sln
dotnet build -c Release

# Run (dev) — reads $PORT with fallback to 8080
dotnet run --project WSGW/WSGW.csproj

# Run without launchSettings (simulates production environment)
# JwtPublicKeyPem must be the full PEM string (newlines as \n or use a file)
JwtPublicKeyPem="$(cat /path/to/public.pem)" ASPNETCORE_ENVIRONMENT=Production PORT=8080 \
  dotnet run --project WSGW/WSGW.csproj --no-launch-profile

# Docker
docker build -t wsgw-test .
docker run -e PORT=8080 \
           -e "JwtPublicKeyPem=$(cat /path/to/public.pem)" \
           -e ASPNETCORE_ENVIRONMENT=Production \
           -p 8080:8080 wsgw-test
```

There are no test projects. Use `WSGW/WSGW.http` for manual endpoint testing, or import `WSGW-Integration.postman_collection.json` into Postman for full integration tests against the deployed environment (`wsgw-ltfp.onrender.com` + `wsauth.onrender.com`).

> **NuGet**: Requires access to a private feed at `http://hera.sipo.com.co/api/v4/groups/18/-/packages/nuget/index.json` (configured in `NuGet.Config`). The `NU1900` warnings about this feed are non-blocking when the feed is unreachable.

## Architecture

Three-project layered solution — dependency direction is strict and must not be reversed:

```
WSGW (Web API) → WSGW.SERVICE (Class Library) → WSGW.DTO (Class Library)
```

| Project        | Role                                                                |
| -------------- | ------------------------------------------------------------------- |
| `WSGW`         | Entry point, middleware pipeline, YARP proxy, controllers           |
| `WSGW.SERVICE` | JWT validation business logic (`AuthService`), DI wiring (`IoC.cs`) |
| `WSGW.DTO`     | Shared DTOs (`JwtClaimsDTO`)                                        |

## Key Files

- `WSGW/Program.cs` — Binds to `$PORT` (fallback `8080`) via `ConfigureKestrel` + `ListenAnyIP`, then delegates to two `InitConfigAPI` extension methods
- `WSGW/Extensiones/ConfigureServiceExtend.cs` — Registers all services: Swagger, JWT auth, rate limiting, YARP transforms, CORS (reads `CORS_ALLOWED_ORIGINS`), gateway services
- `WSGW/Extensiones/AppBuilderExtend.cs` — Configures the middleware pipeline; Swagger only active in `IsDevelopment()`
- `WSGW/Infrastructure/Proxy/JwtValidationMiddleware.cs` — Core middleware: validates JWT, injects claims into `HttpContext.Items["JwtClaims"]`, or returns 401
- `WSGW/Infrastructure/KeepAlive/KeepAliveService.cs` — `BackgroundService` that pings downstream health endpoints to prevent Render cold-starts. Interval read from `KeepAlive:IntervalSeconds` (default 300s in code; currently 10s in `appsettings.json`). Targets configured in `appsettings.json → KeepAlive.Targets`
- `WSGW/Controladores/GatewayController.cs` — `GET /api/gateway/health` (public) and `GET /api/gateway/routes` (requires `Admin` role)
- `WSGW.SERVICE/Implementaciones/AuthService.cs` — Validates JWT; extracts `UserId` (`sub`/`NameIdentifier`), `CompanyId` (`Company_ID`), `Role`; logs `Warning` on failure
- `WSGW.SERVICE/Extensiones/IoC.cs` — Registers `IAuthService → AuthService` as singleton via DI
- `WSGW.SERVICE/Extensiones/ServiceCollectionExtend.cs` — `AddGatewayServices()` extension method; entry point called by `ConfigureServiceExtend.cs` to wire all SERVICE-layer dependencies
- `WSGW/appsettings.json` — YARP routes/clusters, rate limiting, logging config, KeepAlive targets. No secrets.

## Middleware Pipeline (Execution Order)

```
Routing → IP Rate Limiting → CORS → Authentication → Authorization
→ JwtValidationMiddleware → Controllers → YARP Reverse Proxy
```

Swagger (`UseSwagger` / `UseSwaggerUI`) is injected only when `IsDevelopment()` — returns 404 in Production.

## YARP Routing

Two downstream clusters defined in `appsettings.json` (override via env vars in Render). `nuevasritas.json` at repo root is WSAgro's full OpenAPI spec.

| Route                          | Cluster   | Default address         | JWT Required | Path transform           |
| ------------------------------ | --------- | ----------------------- | ------------ | ------------------------ |
| `/api/auth/**`                 | `ws-auth` | `http://localhost:5001` | No           | Pass-through             |
| `/Tenants/**`                  | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/AuthUsersCentral/**`         | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/UserTenants/**`              | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/AuthLoginAttempts/**`        | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/AuthMfaRecoveryCodes/**`     | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/AuthRefreshTokens/**`        | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/Encryption/**`               | `ws-auth` | `http://localhost:5001` | Yes          | Pass-through             |
| `/api/agro/**`                 | `ws-agro` | `http://localhost:5004` | Yes          | Strip `/api/agro` prefix |

**JWT bypass paths**: `/api/auth/**`, `/api/gateway/**`, `/swagger/**`, `/hangfire/**`

The `ws-agro` route strips the `/api/agro` prefix before forwarding — downstream WSAgro serves resources at root level (e.g. gateway `/api/agro/Lote` → downstream `/Lote`).

Both clusters have `ActivityTimeout: 30s` — tolerates Render cold-start spin-up time.

To override cluster addresses without changing `appsettings.json`, use ASP.NET Core's `__` env var convention:

```
ReverseProxy__Clusters__ws-auth__Destinations__primary__Address=https://wsauth.onrender.com/
ReverseProxy__Clusters__ws-agro__Destinations__primary__Address=https://wsagro.onrender.com/
```

## Request Flow (Protected Routes)

```
Client → Rate Limiter → CORS → JwtValidationMiddleware
  ├─ Valid: stores JwtClaimsDTO in HttpContext.Items["JwtClaims"]
  │         → YARP transform injects X-Company-ID, X-User-ID → Downstream
  └─ Invalid/Missing: 401 { "codigo": 0, "mensaje": "..." }
```

YARP header injection (`X-Company-ID`, `X-User-ID`) applies **only** to `ws-agro` — not to `ws-auth`. Incoming `X-Company-ID`/`X-User-ID` headers are stripped before injection (prevents spoofing).

## Configuration

### Required environment variables (never in appsettings.json)

| Variable          | Description                                           | Render type |
| ----------------- | ----------------------------------------------------- | ----------- |
| `JwtPublicKeyPem` | RSA public key in PEM format (contents of `public.pem`) | **Secret**  |

### Optional environment variables (have defaults)

| Variable                 | Default                                       | Description                      |
| ------------------------ | --------------------------------------------- | -------------------------------- |
| `PORT`                   | `8080`                                        | Injected automatically by Render |
| `CORS_ALLOWED_ORIGINS`   | `http://localhost:3000,http://localhost:5173` | Comma-separated allowed origins. If set to empty string `""`, falls back to defaults. |
| `ASPNETCORE_ENVIRONMENT` | `Development`                                 | Set to `Production` on Render    |
| `JwtSettingsIssuer`      | `WS_BET` (in appsettings.json)                | Expected JWT issuer              |
| `JwtSettingsAudience`    | `APP_ORION` (in appsettings.json)             | Expected JWT audience            |

### JWT details

- Algorithm: **RS256** (asymmetric) — Gateway holds only the **public key**; WSAuth holds the private key
- Issuer: `WS_BET`, Audience: `APP_ORION`, ClockSkew: 1 minute
- Claims extracted: `UserId` (from `sub`/`NameIdentifier`), `CompanyId` (from `Company_ID`), `Role`
- **WSAuth signs tokens with the RSA private key** — the Gateway only validates with the public key
- `ValidAlgorithms` is explicitly restricted to `RsaSha256` (prevents algorithm confusion attacks)

### Rate limiting

- 60 requests/minute per IP via `AspNetCoreRateLimit` (returns HTTP 429)
- In-memory store — not shared across multiple instances; use Redis if scaling horizontally

## Deployment (Render.com)

- Gateway → **Web Service** (public) — `https://wsgw-ltfp.onrender.com`
- WSAuth → **Web Service** (public) — `https://wsauth.onrender.com`
- WSAgro → **Private Service** (accessible only within Render's private network) — `https://wsagro.onrender.com`
- Internal service URLs follow the pattern: `http://<service-name>.internal:<port>/`
- Render provides TLS termination at the edge; HTTP is used for internal service-to-service traffic
- Health check path: `/api/gateway/health` — returns plain text `Healthy` (HTTP 200)
- **Required env vars on Gateway** to route traffic to Render:
  ```
  ReverseProxy__Clusters__ws-auth__Destinations__primary__Address=https://wsauth.onrender.com/
  ReverseProxy__Clusters__ws-agro__Destinations__primary__Address=https://wsagro.onrender.com/
  ```

## Integration Guide

`consideraciones.md` — How to integrate with the Gateway:
- Frontend: login flow, protected request format, CORS, error codes
- JWT structure: required claims (`sub`, `Company_ID`, `role`, `iss`, `aud`), RS256 key generation, signing example in .NET
- Backend: how to add a new business service (YARP config + transform wiring), headers received downstream (`X-User-ID`, `X-Company-ID`), tenant isolation pattern, adding public routes
- WSAgro resources: full OpenAPI spec in `nuevasritas.json` (AnalisisRecurso, Lote, Predio, RegistroCosecha, MonitoreoMip, and 15+ other agricultural domain resources)

## Spec & Planning Docs

Active planning documents are in `.speckit/`:

- `.speckit/spec.md` — Security requirements (MUST/SHOULD/MAY)
- `.speckit/plan.md` — Technical design for each remediation item
- `.speckit/tasks.md` — Checklist tracking Phases 1 and 2 progress
