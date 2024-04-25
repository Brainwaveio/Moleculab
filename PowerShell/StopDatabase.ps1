param(
    [string]$databaseProcessName = "QuantumQuery"
)

Get-Process | Where-Object { $_.ProcessName -eq $databaseProcessName } | Stop-Process -Force

Write-Host "Database processes and resources have been cleaned up."