
param(
    [string]$deployPath,
    [string]$conf
)

if ($deployPath) {
    $destination = $deployPath
}
else {
        $destination = '.\bin\' 
}

if (-not (Test-Path $destination)) {
    New-Item $destination -ItemType Directory
}

if (-not $conf) {
    $conf = "Debug"
}

Write-Host Copying to $destination from $conf

Write-Host Copying gxcli
Copy-Item -Path .\src\bin\$conf\*.* $destination

