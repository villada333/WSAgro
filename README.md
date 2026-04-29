# WSAgro - Microservicio Backend (.NET 8)

**WSAgro** es el componente de lógica de negocio y API (Backend) de la plataforma SaaS de Trazabilidad Agrícola. Funciona como un microservicio independiente y opera bajo el ecosistema protegido por el Gateway (`WSGW`).

## 🎯 Objetivo del Microservicio

Este proyecto NO es un simple CRUD. Su función principal es actuar como el **Motor Normativo Fitosanitario**, garantizando que toda operación agrícola cumpla con las normas del ICA (Resolución 824) y las Buenas Prácticas Agrícolas (BPA).

### Responsabilidades Clave:
- **Motor de Reglas de Negocio:**
  - *SST (Seguridad y Salud):* Validar que los operarios tengan capacitaciones vigentes antes de permitirles registrar aplicaciones químicas.
  - *Periodo de Carencia:* Calcular y bloquear cosechas si la planta aún tiene residuos tóxicos.
  - *Manejo Integrado de Plagas (MIP):* Calcular porcentajes de incidencia y disparar umbrales de alerta.
  - *Inventario:* Bloquear el uso de químicos vencidos.
- **Aislamiento Multi-Tenant:** Interceptar todas las peticiones para aislar los datos (vía `tenant_id`) garantizando que una finca no vea los datos de otra.
- **Conexión Directa a Datos:** Es el único servicio autorizado para interactuar directamente con la Base de Datos PostgreSQL en Supabase.

---

## 🏗️ Arquitectura en Capas

El proyecto está diseñado bajo una arquitectura limpia y estructurada en 4 capas estrictas de dependencia (`WSAgro -> SERVICE -> DAO -> DTO`):

1. **`WSAgro` (Capa API):**
   - Contiene los **Controladores REST**. 
   - Define los *Endpoints* asegurados con el atributo `[Authorize]`.
   - Incluye la configuración de inyección de dependencias y middlewares (Swagger, Hangfire, RateLimiting, JWT) en `Extensiones/`.
2. **`WSAgro.SERVICE` (Capa de Lógica de Negocio):**
   - Contiene Interfaces e Implementaciones.
   - Aquí es donde reside el "Motor Normativo" y se resuelven las reglas de negocio antes de tocar la base de datos.
3. **`WSAgro.DAO` (Capa de Acceso a Datos):**
   - Responsable de la comunicación con PostgreSQL (Supabase).
   - Implementa `Entity Framework Core` con la configuración de DbContext y mapeo de tablas (Fluent API).
4. **`WSAgro.DTO` (Capa de Transferencia):**
   - Define los objetos que viajan entre capas y hacia el frontend.
   - Utiliza la respuesta universal `SalidaDTO<T>` para estandarizar el éxito/error de todas las peticiones.

---

## 🔒 Seguridad e Integración (JWT)

Este microservicio **delega la autenticación** al sistema central `WS_Auth`. 

- No emite tokens ni almacena contraseñas.
- Recibe un **JWT asimétrico (RS256)** del cliente (pasado a través del Gateway).
- Verifica la autenticidad del JWT leyendo la clave pública RSA configurada en sus variables de entorno (`JwtPublicKeyPem`).
- Extrae la identidad del usuario (`user_id`), su rol (`role`) y el tenant (`Company_ID`) del JWT para aplicar las reglas de aislamiento de datos y permisos.

---

## 🩺 Monitoreo de Salud (Health Checks)

El microservicio cuenta con un endpoint público para validar rápidamente si la aplicación está en línea y procesando solicitudes. Esto es ideal para configurar pruebas de disponibilidad en servicios de infraestructura en la nube (ej. Render, Docker).

- **Endpoint:** `GET /estado`
- **Respuesta (JSON):**
  ```json
  {
    "estado": "En línea",
    "servicio": "WSAgro",
    "timestamp": "2026-04-29T00:00:00.000Z"
  }
  ```

---

## ⚙️ Configuración (Environment Variables)

Para ejecutar este servicio localmente o en producción (Render/Docker), asegúrese de configurar las siguientes variables de entorno o actualizar el archivo `appsettings.json`:

```json
{
  "Connection": "Cadena de conexión a PostgreSQL (Supabase)",
  "JwtPublicKeyPem": "-----BEGIN PUBLIC KEY-----\n...\n-----END PUBLIC KEY-----",
  "JwtSettingsIssuer": "WS_BET",
  "JwtSettingsAudience": "APP_ORION"
}
```

*Desarrollado en .NET 8 como componente del ecosistema SaaS Agro.*
