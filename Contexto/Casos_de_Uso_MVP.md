# Casos de Uso: Plataforma de Trazabilidad Agrícola (MVP)

Este documento detalla los flujos de interacción principales que los usuarios tendrán con el sistema, divididos por las fases operativas de la finca y los roles involucrados (`GERENTE`, `AGRONOMO`, `OPERARIO`).

---

## 1. Configuración Inicial e Infraestructura Productiva
*Actores: `GERENTE`, `AGRONOMO`*

### CU-1.01: Registrar un nuevo Predio (Finca)
- **Actor:** GERENTE
- **Descripción:** El usuario registra la información legal y geográfica de la finca, incluyendo el Código ICA, estableciendo la raíz para toda la trazabilidad.

### CU-1.02: Crear y subdividir Lotes
- **Actor:** GERENTE / AGRONOMO
- **Descripción:** El usuario crea lotes dentro del predio, definiendo un nombre/número, el tipo de cultivo y el área en hectáreas. Esta es la unidad mínima donde ocurrirán los eventos.

### CU-1.03: Registrar Semilla o Material de Propagación
- **Actor:** AGRONOMO
- **Descripción:** El usuario asocia un lote recién creado con el material vegetal sembrado, ingresando la variedad, el vivero proveedor y el Registro ICA del vivero para auditorías.

---

## 2. Gestión de Insumos y Bodega
*Actores: `AGRONOMO`, `OPERARIO`*

### CU-2.01: Ingreso de Insumos a Bodega
- **Actor:** AGRONOMO / OPERARIO (Encargado de bodega)
- **Descripción:** El usuario selecciona un producto del **Catálogo Global del ICA** e ingresa la cantidad recibida, el Lote de Fabricación y la Fecha de Vencimiento.
- **Validaciones:** El sistema no permitirá ingresar productos que no estén en el catálogo oficial.

### CU-2.02: Consulta de Alertas de Vencimiento
- **Actor:** AGRONOMO
- **Descripción:** El usuario revisa en el Dashboard los insumos que están próximos a vencer o ya vencidos para retirarlos y evitar multas.

---

## 3. Seguridad y Salud en el Trabajo (SST)
*Actores: `GERENTE`, `AGRONOMO`*

### CU-3.01: Registrar Capacitación
- **Actor:** AGRONOMO / GERENTE
- **Descripción:** Se documenta la ejecución de una charla de SST (ej. Uso de Plaguicidas), subiendo fotos como evidencia.

### CU-3.02: Registrar Asistencia del Personal
- **Actor:** AGRONOMO
- **Descripción:** Desde la PWA móvil, el agrónomo selecciona a los operarios asistentes a la capacitación y estos firman en la pantalla del dispositivo.
- **Impacto:** Habilita a estos operarios para realizar labores fitosanitarias.

### CU-3.03: Entrega de Elementos de Protección Personal (EPP)
- **Actor:** GERENTE / AGRONOMO
- **Descripción:** Se registra qué elementos (mascarillas, guantes, trajes) se entregaron a un operario específico, cumpliendo con la norma de prevención.

---

## 4. Recursos y Mantenimiento de Equipos
*Actores: `GERENTE`, `AGRONOMO`*

### CU-4.01: Subir Análisis de Agua o Suelo
- **Actor:** GERENTE / AGRONOMO
- **Descripción:** El usuario carga un PDF con los resultados de laboratorio del predio y define una fecha de vigencia/vencimiento para el análisis.

### CU-4.02: Registrar Equipo o Herramienta
- **Actor:** AGRONOMO
- **Descripción:** Se da de alta en el sistema maquinaria crítica, como una bomba de fumigación, registrando su marca y serie.

### CU-4.03: Registrar Calibración/Mantenimiento
- **Actor:** OPERARIO / AGRONOMO
- **Descripción:** Se asienta en la bitácora que un equipo fue calibrado o mantenido, programando automáticamente la fecha de la próxima revisión recomendada.

---

## 5. Manejo Integrado de Plagas (MIP)
*Actores: `AGRONOMO`, `OPERARIO`*

### CU-5.01: Definir Umbrales de Acción
- **Actor:** AGRONOMO
- **Descripción:** El agrónomo define qué porcentaje de afectación de una plaga (ej. 5%) es aceptable en la finca antes de que el sistema emita una alerta de intervención.

### CU-5.02: Registrar Monitoreo (Censo en Campo)
- **Actor:** OPERARIO
- **Descripción:** Usando la PWA (Online/Offline), el operario camina el lote, registra el estado fenológico de la planta e ingresa cuántas plantas de la muestra tienen presencia de plagas.
- **Impacto:** El sistema calcula la incidencia y, si supera el Umbral de Acción, envía una alerta al Agrónomo.

---

## 6. Labores y Fitosanidad (El "Cuaderno de Campo")
*Actores: `AGRONOMO`, `OPERARIO`*

### CU-6.01: Registrar Labor Cultural (Poda, Plateo, etc.)
- **Actor:** OPERARIO
- **Descripción:** El operario asienta en la app que realizó un mantenimiento físico al lote, especificando la fecha.

### CU-6.02: Registrar Aplicación Fitosanitaria / Fertilización
- **Actor:** OPERARIO / AGRONOMO
- **Descripción:** El usuario registra la fumigación de un lote. Debe indicar el insumo usado, dosis, y el agrónomo responsable. 
- **Reglas del Motor Normativo (Validaciones Estrictas):**
    1. **Validación SST:** El sistema bloquea si el operario no tiene asistencia a capacitaciones.
    2. **Validación Insumo:** El sistema bloquea si el insumo elegido está vencido.
    3. **Actualización de Carencia:** El sistema guarda los días de *Periodo de Carencia* (tiempo de espera antes de cosechar) y las horas de *Periodo de Reingreso* exigidos por el químico.

---

## 7. Cosecha y Trazabilidad (Salida Segura)
*Actores: `OPERARIO`, `GERENTE`*

### CU-7.01: Registrar Cosecha de Lote
- **Actor:** OPERARIO
- **Descripción:** El operario indica que ha recolectado X kilos/unidades de un lote específico en el día actual.
- **Reglas del Motor Normativo:**
    - El backend evalúa la fecha actual contra la última aplicación de químicos en ese lote.
    - **Bloqueo ICA:** Si no ha pasado el *Periodo de Carencia*, la cosecha queda "Contaminada/No Liberada" y se lanza una alerta crítica.
    - Si aprueba, la cosecha queda "Liberada" y se genera un lote interno de trazabilidad (ej. un QR para imprimir).

### CU-7.02: Generar Remisión de Despacho
- **Actor:** GERENTE / OPERARIO LOGÍSTICO
- **Descripción:** Se prepara un camión para exportación. El usuario selecciona qué canastillas (cosechas) va a cargar.
- **Validación:** El sistema impide agregar a una remisión oficial cosechas que estén marcadas como "No Liberadas" por violar el periodo de carencia.

---

## 8. Sincronización y Movilidad
*Actores: `OPERARIO`, `SISTEMA`*

### CU-8.01: Registro de Operaciones Offline
- **Actor:** OPERARIO
- **Descripción:** El operario llega a una zona sin señal en la finca, abre la PWA, registra 5 monitoreos y 2 aplicaciones. Los datos quedan guardados de forma segura en el dispositivo (IndexedDB).

### CU-8.02: Sincronización con el Backend
- **Actor:** SISTEMA / OPERARIO
- **Descripción:** Al recuperar conexión (o al pulsar un botón "Sincronizar"), la PWA empuja la cola de transacciones hacia la API `.NET`. El backend valida las reglas normativas masivamente y retorna el éxito de la operación.
