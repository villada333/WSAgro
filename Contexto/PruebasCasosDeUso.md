# Plan de Pruebas E2E: Casos de Uso MVP

Este documento planifica la ejecución de pruebas automatizadas End-to-End (E2E) para la plataforma WSAgro, comunicándose directamente a través del API Gateway (`https://wsgw-ltfp.onrender.com`). 

El objetivo es simular un flujo operativo real completo, desde el registro de la finca hasta la cosecha, asegurando que el aislamiento Multi-Tenant y los roles funcionen correctamente.

## 1. Estrategia de Pruebas

Para garantizar que cualquier desarrollador pueda ejecutar estas pruebas con un solo clic desde su editor de código (VS Code o Visual Studio), implementaremos las pruebas utilizando un archivo **`.http` (REST Client)**. 

Este archivo permitirá:
1. Declarar variables de entorno (URLs, Tokens).
2. Ejecutar peticiones secuenciales.
3. Almacenar automáticamente los JWT retornados por el Gateway para inyectarlos en las siguientes peticiones.

## 2. Fase de Setup: Identidad y Autenticación (WS_Auth)

Antes de tocar el módulo agrícola, el Gateway debe gestionar los usuarios. Crearemos un Tenant (Empresa) ficticio y tres perfiles bajo ese mismo ecosistema.

**Empresa de Prueba:** `Agro_Test_Corp`

| Usuario (Email) | Contraseña | Rol | Tarea Principal |
| :--- | :--- | :--- | :--- |
| `gerente@agrotest.com` | `Test1234!` | `GERENTE` | Crear Finca y Lotes. |
| `agronomo@agrotest.com` | `Test1234!` | `AGRONOMO` | Definir Umbrales MIP y Recetar Químicos. |
| `operario@agrotest.com` | `Test1234!` | `OPERARIO` | Registrar Monitoreos, Aplicaciones y Cosecha. |

*Flujo Automático:*
1. Hacer un `POST /api/auth/register` (o equivalente) para crear cada usuario.
2. Hacer un `POST /api/auth/login` con cada uno.
3. Guardar el JWT de cada respuesta en variables (`@GerenteToken`, `@AgronomoToken`, `@OperarioToken`).

## 3. Fase Operativa: Mapeo de Casos de Uso (WSAgro)

Una vez obtenidos los tokens, se ejecutarán las pruebas sobre el microservicio `WSAgro` respetando el flujo agrícola real:

### ⚙️ Módulo 1: Configuración de la Finca
*   **Prueba 1 (CU-1.01):** Crear Predio. -> `POST /Predio` (Token: Gerente)
*   **Prueba 2 (CU-1.02):** Crear Lote para ese predio. -> `POST /Lote` (Token: Gerente)

### 🛡️ Módulo 2: SST y Personal
*   **Prueba 3 (CU-3.01):** Crear una capacitación SST. -> `POST /CapacitacionSst` (Token: Agrónomo)
*   **Prueba 4 (CU-3.02):** Registrar al operario en la capacitación. -> `POST /AsistenciaCapacitacion` (Token: Agrónomo) - *Esto es vital para que el Motor Normativo no bloquee al operario después.*

### 🐛 Módulo 3: Manejo Integrado de Plagas (MIP)
*   **Prueba 5 (CU-5.01):** Definir Umbral de Acción (ej: 5% de broca). -> `POST /UmbralAccionFinca` (Token: Agrónomo)
*   **Prueba 6 (CU-5.02):** Registrar un Monitoreo en campo. -> `POST /MonitoreoMip` y `POST /DetalleMonitoreoMip` (Token: Operario).

### 🧪 Módulo 4: Cuaderno de Campo y Fitosanidad
*   **Prueba 7 (CU-6.02):** Registrar una fumigación/aplicación. -> `POST /LaborTransaccional` (Token: Operario). *Aquí el motor normativo fijará el Periodo de Carencia.*

### 🚜 Módulo 5: Cosecha
*   **Prueba 8 (CU-7.01):** Registrar Cosecha. -> `POST /RegistroCosecha` (Token: Operario). *Se espera que el Motor Normativo valide si la cosecha choca con el periodo de carencia de la prueba 7.*

---

## 4. Ejecución
Todas estas pruebas quedarán programadas en el script `Pruebas_E2E_Agro.http`. Al ejecutarlas, el flujo completo documentará el estado actual de madurez del microservicio, sirviendo como guía de "Test-Driven Development" (TDD) para el desarrollo de las reglas de negocio.
