# Documentación de Integración Frontend - WSAgro

Esta documentación describe los endpoints disponibles en el API Gateway (`https://wsgw-ltfp.onrender.com/api/agro`) para consumir las operaciones de Trazabilidad Agrícola. Todas las peticiones deben incluir el header `Authorization: Bearer <Token JWT>`. El aislamiento de datos (`TenantId`) se obtiene automáticamente desde el token.

---

## 🔐 Autenticación (Obtener Token JWT)
Antes de consumir cualquier endpoint de la sección agrícola, el Frontend debe autenticar al usuario para obtener el Token JWT.

- **Endpoint:** `POST https://wsgw-ltfp.onrender.com/api/auth/login`
- **Payload:**
```json
{
  "usuario": "email@ejemplo.com",
  "password": "MiPasswordSeguro123"
}
```

### Credenciales de Prueba para el Frontend
Utiliza los siguientes usuarios para probar los diferentes roles y verificar qué vistas/acciones están permitidas para cada uno. (Todos comparten la misma contraseña: `pass123!`).

| Rol en el Negocio | Correo de Acceso (Usuario) | Contraseña |
| :--- | :--- | :--- |
| **Gerente** | `gerentePrueba@agrotest.com` | `pass123!` |
| **Agrónomo** | `agronomoPrueba@agrotest.com` | `pass123!` |
| **Operario** | `operarioPrueba@agrotest.com` | `pass123!` |

> **Nota para Frontend:** El token retornado en la respuesta de este login debe inyectarse en los headers de las peticiones subsiguientes como `Authorization: Bearer {token}`.

---

## 1. Predio (Finca)
**Descripción:** Registra las fincas o haciendas de la empresa.
- **Actor (Rol recomendado):** `GERENTE`
- **Endpoint:** `POST /api/agro/Predio`
- **Payload (PredioDTO):**
```json
{
  "id": "UUID (opcional, generado automáticamente si se omite)",
  "nombre": "Nombre de la finca (String)",
  "codigoIca": "Código de registro del ICA (String, Único)",
  "ubicacionLat": "Latitud geográfica (Decimal)",
  "ubicacionLon": "Longitud geográfica (Decimal)",
  "createdAt": "Fecha de creación (ISO 8601, ej. 2026-04-30T14:00:00Z)"
}
```

---

## 2. Lote
**Descripción:** Subdivisión física de un Predio donde se realiza una siembra o cultivo específico.
- **Actor (Rol recomendado):** `GERENTE` o `AGRONOMO`
- **Endpoint:** `POST /api/agro/Lote`
- **Payload (LoteDTO):**
```json
{
  "id": "UUID",
  "predioId": "UUID del Predio padre",
  "nombreNumero": "Nombre o identificador del lote (String)",
  "areaHa": "Área en hectáreas (Decimal)",
  "cultivo": "Tipo de cultivo principal (String)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 3. Catálogo Insumos ICA
**Descripción:** Catálogo maestro de productos químicos, pesticidas y fertilizantes avalados para su uso en la operación.
- **Actor (Rol recomendado):** `GERENTE` o `AGRONOMO`
- **Endpoint:** `POST /api/agro/CatalogoInsumoIca`
- **Payload (CatalogoInsumoIcaDTO):**
```json
{
  "id": "UUID",
  "registroIca": "Número de registro oficial del ICA (String, Único)",
  "nombreComercial": "Nombre del producto en el mercado (String)",
  "ingredienteActivo": "Principio activo del químico (String)",
  "categoriaTox": "Nivel de toxicidad, ej. I, II, III, IV (String)",
  "tipoInsumo": "Clasificación, ej. Biologico, Quimico (String)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 4. Catálogo Plagas y Enfermedades
**Descripción:** Diccionario de referencia de las plagas locales a monitorear.
- **Actor (Rol recomendado):** `AGRONOMO`
- **Endpoint:** `POST /api/agro/CatalogoPlagaEnfermedad`
- **Payload (CatalogoPlagaEnfermedadDTO):**
```json
{
  "id": "UUID",
  "nombreComun": "Nombre popular de la plaga (String)",
  "nombreCientifico": "Nombre científico taxonómico (String)",
  "tipoAgente": "Clasificación, ej. Insecto, Hongo, Bacteria (String)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 5. Capacitación SST (Seguridad y Salud)
**Descripción:** Registro del evento de capacitación realizado para instruir al personal.
- **Actor (Rol recomendado):** `AGRONOMO` (Capacitador)
- **Endpoint:** `POST /api/agro/CapacitacionSst`
- **Payload (CapacitacionSstDTO):**
```json
{
  "id": "UUID",
  "tema": "Título o temática tratada en la capacitación (String)",
  "fecha": "Fecha en que se dictó la charla (ISO 8601)",
  "evidenciaUrl": "Enlace (URL) a la firma o planilla escaneada (String)",
  "createdAt": "Fecha de registro en sistema (ISO 8601)"
}
```

---

## 6. Asistencia Capacitación SST
**Descripción:** Vinculación de los trabajadores a las capacitaciones (Requisito normativo para operar químicos).
- **Actor (Rol recomendado):** `AGRONOMO`
- **Endpoint:** `POST /api/agro/AsistenciaCapacitacion`
- **Payload (AsistenciaCapacitacionDTO):**
```json
{
  "id": "UUID",
  "capacitacionId": "UUID de la capacitación registrada previamente",
  "usuarioId": "UUID del Operario en el sistema de Auth",
  "firmaBase64": "Firma digital capturada en pantalla (String Base64)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 7. Umbral Acción Finca
**Descripción:** Límites y parámetros máximos de tolerancia de plagas establecidos por el Agrónomo para disparar controles (MIP).
- **Actor (Rol recomendado):** `AGRONOMO`
- **Endpoint:** `POST /api/agro/UmbralAccionFinca`
- **Payload (UmbralAccionFincaDTO):**
```json
{
  "id": "UUID",
  "plagaId": "UUID de la plaga en el catálogo",
  "incidenciaMaxima": "Porcentaje límite de tolerancia (Decimal)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 8. Monitoreo MIP (Manejo Integrado de Plagas)
**Descripción:** Evaluaciones periódicas en campo para medir la presencia de afectaciones en los Lotes.
- **Actor (Rol recomendado):** `OPERARIO`
- **Endpoint:** `POST /api/agro/MonitoreoMip`
- **Payload (MonitoreoMipDTO):**
```json
{
  "id": "UUID",
  "loteId": "UUID del lote monitoreado",
  "operarioId": "UUID del operario que realiza el monitoreo",
  "fechaMonitoreo": "Fecha de la inspección física (ISO 8601)",
  "estFenologico": "Estado de desarrollo de la planta, ej. Floración (String)",
  "plantasEvaluadas": "Cantidad de árboles o unidades revisadas (Entero)",
  "createdAt": "Fecha de registro en sistema (ISO 8601)"
}
```

---

## 9. Labor Transaccional (Fumigaciones, Aplicaciones)
**Descripción:** Registro del uso de insumos químicos o biológicos sobre los Lotes. Impacta inventarios y tiempos de carencia.
- **Actor (Rol recomendado):** `OPERARIO`
- **Endpoint:** `POST /api/agro/LaborTransaccional`
- **Payload (LaborTransaccionalDTO):**
```json
{
  "id": "UUID",
  "loteId": "UUID del lote donde se aplicó el químico",
  "tipoLabor": "Categoría de la labor, ej. Fumigación, Fertilizacion (String)",
  "insumoId": "UUID del producto utilizado (del Catálogo)",
  "dosisAplicada": "Cantidad de insumo disuelta (Decimal)",
  "operarioId": "UUID del operario ejecutante",
  "agronomoId": "UUID del agrónomo que recetó/aprobó la labor (Opcional)",
  "tarjetaProfAgronomo": "Número de matrícula profesional del agrónomo (String)",
  "fechaAplicacion": "Fecha real del trabajo de campo (ISO 8601)",
  "pCarencia": "Periodo de Carencia en días sugeridos para no cosechar (Entero)",
  "pReingreso": "Horas que el personal debe esperar antes de volver a entrar al lote (Entero)",
  "createdAt": "Fecha (ISO 8601)"
}
```

---

## 10. Registro Cosecha
**Descripción:** Salida y cuantificación de la producción agrícola final. Validará que se cumplan las carencias químicas.
- **Actor (Rol recomendado):** `OPERARIO`
- **Endpoint:** `POST /api/agro/RegistroCosecha`
- **Payload (RegistroCosechaDTO):**
```json
{
  "id": "UUID",
  "loteId": "UUID del lote cosechado",
  "operarioId": "UUID del operario encargado",
  "fechaCosecha": "Fecha de extracción (ISO 8601)",
  "cantidad": "Kilos o toneladas obtenidas (Decimal)",
  "loteTrazInterno": "Código de seguimiento interno del lote para empacadora (String)",
  "liberado": "Booleano que indica si la cosecha está libre de retenciones por químicos (Boolean)",
  "createdAt": "Fecha (ISO 8601)"
}
```
