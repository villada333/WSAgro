try {
    $body = @{
        id = "11111111-1111-1111-1111-111111111112"
        loteId = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"
        tipoLabor = "Fumigacion"
        fechaAplicacion = "2026-04-30T14:00:00Z"
        insumoId = "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeee1"
        dosisAplicada = 2.5
        operarioId = "33333333-3333-3333-3333-333333333333"
        agronomoId = "22222222-2222-2222-2222-222222222222"
        tarjetaProfAgronomo = "TP-12345"
        pCarencia = 15
        pReingreso = 24
        createdAt = "2026-04-30T14:00:00Z"
    } | ConvertTo-Json

    Invoke-RestMethod -Uri "http://localhost:8080/LaborTransaccional" -Method Post -Body $body -Headers @{"X-Company-ID"="Agro30042026"} -ContentType "application/json"
} catch {
    $stream = $_.Exception.Response.GetResponseStream()
    $reader = New-Object System.IO.StreamReader($stream)
    $reader.ReadToEnd()
}
