$Gateway = "https://wsgw-ltfp.onrender.com"
$TenantId = "Agro30042026"
$GerenteId = "11111111-1111-1111-1111-111111111111"
$AgronomoId = "22222222-2222-2222-2222-222222222222"
$OperarioId = "33333333-3333-3333-3333-333333333333"

# IDs Globales a reutilizar
$PredioId = [guid]::NewGuid().ToString()
$LoteId = [guid]::NewGuid().ToString()
$InsumoId = [guid]::NewGuid().ToString()
$PlagaId = [guid]::NewGuid().ToString()
$CapacitacionId = [guid]::NewGuid().ToString()

function Get-Token($usuario, $password) {
    $loginBody = @{ usuario = $usuario; password = $password } | ConvertTo-Json
    $res = Invoke-RestMethod -Uri "$Gateway/api/auth/login" -Method Post -Body $loginBody -ContentType "application/json"
    return $res.data.token
}

Write-Host "=== Obteniendo Tokens ==="
$TokenGerente = Get-Token "gerentePrueba@agrotest.com" "pass123!"
$TokenAgronomo = Get-Token "agronomoPrueba@agrotest.com" "pass123!"
$TokenOperario = Get-Token "operarioPrueba@agrotest.com" "pass123!"

function Invoke-Api($Name, $Endpoint, $Token, $Body, $OverrideGateway = $null) {
    Write-Host "`n>>> $Name"
    $headers = @{
        Authorization = "Bearer $Token"
        "X-Company-ID" = $TenantId
    }
    try {
        $uri = if ($OverrideGateway) { "$OverrideGateway/$Endpoint" } else { "$Gateway/api/agro/$Endpoint" }
        $res = Invoke-RestMethod -Uri $uri -Method Post -Body ($Body | ConvertTo-Json) -Headers $headers -ContentType "application/json"
        Write-Host "Exito! Codigo: $($res.codigo)"
        if ($res.codigo -ne 1) { Write-Host "Respuesta: $($res | ConvertTo-Json -Depth 3)" }
    } catch {
        Write-Host "ERROR en $Name : $($_.Exception.Message)"
        if ($_.ErrorDetails) { $_.ErrorDetails.Message | Write-Host }
    }
}

# --- GERENTE ---
Invoke-Api "1. Crear Predio" "Predio" $TokenGerente @{
    id = $PredioId
    nombre = "Finca E2E"
    codigoIca = "ICA-$([DateTimeOffset]::Now.ToUnixTimeMilliseconds())"
    ubicacionLat = 5.0
    ubicacionLon = -75.0
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "2. Crear Lote" "Lote" $TokenGerente @{
    id = $LoteId
    predioId = $PredioId
    nombreNumero = "Lote $(Get-Random -Minimum 10 -Maximum 99)"
    areaHa = 5.5
    cultivo = "Aguacate Hass"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "3. Catalogo Insumo" "CatalogoInsumoIca" $TokenGerente @{
    id = $InsumoId
    registroIca = "ICA-$([DateTimeOffset]::Now.ToUnixTimeMilliseconds())"
    nombreComercial = "Test Insumo"
    ingredienteActivo = "Test"
    categoriaTox = "III"
    tipoInsumo = "Biologico"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

# --- AGRONOMO ---
Invoke-Api "4. Catalogo Plaga" "CatalogoPlagaEnfermedad" $TokenAgronomo @{
    id = $PlagaId
    nombreComun = "Plaga Test"
    nombreCientifico = "Testus plagus"
    tipoAgente = "Insecto"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "5. Crear Capacitacion SST" "CapacitacionSst" $TokenAgronomo @{
    id = $CapacitacionId
    tema = "Capacitacion Automatizada"
    fecha = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
    evidenciaUrl = "http://test.com/firma"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "6. Asistencia SST (Operario)" "AsistenciaCapacitacion" $TokenAgronomo @{
    capacitacionId = $CapacitacionId
    usuarioId = $OperarioId
    firmaBase64 = "FirmaBase64"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "7. Umbral Accion Finca" "UmbralAccionFinca" $TokenAgronomo @{
    plagaId = $PlagaId
    incidenciaMaxima = 5.0
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

# --- OPERARIO ---
Invoke-Api "8. Monitoreo MIP" "MonitoreoMip" $TokenOperario @{
    loteId = $LoteId
    fechaMonitoreo = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
    estFenologico = "Floracion"
    plantasEvaluadas = 20
    operarioId = $OperarioId
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}

Invoke-Api "9. Labor Transaccional" "LaborTransaccional" $TokenOperario @{
    loteId = $LoteId
    tipoLabor = "Fumigacion"
    fechaAplicacion = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
    insumoId = $InsumoId
    dosisAplicada = 2.5
    operarioId = $OperarioId
    agronomoId = $AgronomoId
    tarjetaProfAgronomo = "TP-12345"
    pCarencia = 15
    pReingreso = 24
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
} "http://localhost:8080"

Invoke-Api "10. Registro Cosecha" "RegistroCosecha" $TokenOperario @{
    loteId = $LoteId
    fechaCosecha = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
    cantidad = 1500.5
    loteTrazInterno = "TRZ-$([DateTimeOffset]::Now.ToUnixTimeMilliseconds())"
    liberado = $true
    operarioId = $OperarioId
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
}
