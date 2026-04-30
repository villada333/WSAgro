$Gateway = "https://wsgw-ltfp.onrender.com"
$TenantId = "Agro30042026"
$GerenteId = "11111111-1111-1111-1111-111111111111"

# 1. Login
$loginBody = @{
    usuario = "gerentePrueba@agrotest.com"
    password = "pass123!"
} | ConvertTo-Json

Write-Host "=== Login Gerente ==="
try {
    $loginResponse = Invoke-RestMethod -Uri "$Gateway/api/auth/login" -Method Post -Body $loginBody -ContentType "application/json"
    $GerenteToken = $loginResponse.data.token
    Write-Host "Login exitoso. Token obtenido."
} catch {
    Write-Host "Error en Login: $($_.Exception.Message)"
    exit
}

# Configuración de Headers
$headers = @{
    Authorization = "Bearer $GerenteToken"
    "X-Company-ID" = $TenantId
}

# 2. Registrar Predio
$PredioId = [guid]::NewGuid().ToString()
$codigoIca = "ICA-" + [DateTimeOffset]::Now.ToUnixTimeMilliseconds()
$predioBody = @{
    id = $PredioId
    nombre = "Finca El Paraiso"
    codigoIca = $codigoIca
    ubicacionLat = 5.0
    ubicacionLon = -75.0
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
} | ConvertTo-Json

Write-Host "`n=== Creando Predio ==="
try {
    $predioResponse = Invoke-RestMethod -Uri "$Gateway/api/agro/Predio" -Method Post -Body $predioBody -Headers $headers -ContentType "application/json"
    $predioResponse | ConvertTo-Json -Depth 5 | Write-Host
} catch {
    Write-Host "Error Predio: $($_.Exception.Message)"
    if ($_.ErrorDetails) { $_.ErrorDetails.Message | Write-Host }
}

# 3. Crear Lote
$LoteId = [guid]::NewGuid().ToString()
$loteBody = @{
    id = $LoteId
    predioId = $PredioId
    nombreNumero = "Lote " + (Get-Random -Minimum 10 -Maximum 99)
    areaHa = 5.5
    cultivo = "Aguacate Hass"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
} | ConvertTo-Json

Write-Host "`n=== Creando Lote ==="
try {
    $loteResponse = Invoke-RestMethod -Uri "$Gateway/api/agro/Lote" -Method Post -Body $loteBody -Headers $headers -ContentType "application/json"
    $loteResponse | ConvertTo-Json -Depth 5 | Write-Host
} catch {
    Write-Host "Error Lote: $($_.Exception.Message)"
    if ($_.ErrorDetails) { $_.ErrorDetails.Message | Write-Host }
}

# 4. Catalogo Insumos
$InsumoId = [guid]::NewGuid().ToString()
$insumoBody = @{
    id = $InsumoId
    registroIca = "ICA-" + [DateTimeOffset]::Now.ToUnixTimeMilliseconds()
    nombreComercial = "Controlador Bio"
    ingredienteActivo = "Bacillus thuringiensis"
    categoriaTox = "III"
    tipoInsumo = "Biologico"
    createdAt = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
} | ConvertTo-Json

Write-Host "`n=== Creando Insumo (Catálogo) ==="
try {
    $insumoResponse = Invoke-RestMethod -Uri "$Gateway/api/agro/CatalogoInsumoIca" -Method Post -Body $insumoBody -Headers $headers -ContentType "application/json"
    $insumoResponse | ConvertTo-Json -Depth 5 | Write-Host
} catch {
    Write-Host "Error Insumo: $($_.Exception.Message)"
    if ($_.ErrorDetails) { $_.ErrorDetails.Message | Write-Host }
}
