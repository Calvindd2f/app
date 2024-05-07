param(
  [Parameter(Position=0,Mandatory=0)]
  [string]$logsDir = 'C:\pss\logs\',
  [Parameter(Position=3,Mandatory=0)]
  [switch]$docs = $false,
  [Parameter(Position=4,Mandatory=0)]
  [System.Collections.Hashtable]$parameters = @{},
  [Parameter(Position=5, Mandatory=0)]
  [System.Collections.Hashtable]$properties = @{},
  [Parameter(Position = 7, Mandatory = $false)]
  [switch]$nologo,
  [Parameter(Position = 6, Mandatory = $false)]
  [alias("init")]
  [scriptblock]$initialization = {},
  [Parameter(Position = 8, Mandatory = $false)]
  [switch]$detailedDocs
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path $logsDir -PathType Container)) {
    New-Item -Path $logsDir -ItemType Container
}

$logFileName = "$logsDir_$(Get-Date -Format 'yyyy-MM-dd_HH-mm-ss').log"

& 'C:\dotnet-tools\crank-agent.exe' 2>&1 >> $logFileName


