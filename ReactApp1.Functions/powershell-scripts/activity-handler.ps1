#activity-handler.ps1
param($Request, $TriggerMetadata)
# Example function logic
$data = $Request.Body
# Perform operations or call other services
$response = Process-Data -InputData $data
Push-OutputBinding -Name Response -Value ($response | ConvertTo-Json)
