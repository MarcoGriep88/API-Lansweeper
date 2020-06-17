# ==========================================
# AUTHOR: GRIEP MARCO
# THIS SCRIPT IS AN CONNECTOR BETWEEN MY TO APIs
# * API-LANSWEEPER
# * API-CHOCO-INFO 
#
# THIS ENABLED YOU THE FUNCTIONALLITY TO CHECK WHAT SOFTWARE
# IS INSTALLED BY LANSWEEPER AND COULD BE UPGRADED BY A NEWER CHOCOLATEY PACKAGE
# ==========================================


$json_lansweeper = ""
$json_chocolateyAppInfo = ""

$WeightMultiplierMajor = 100
$WeightMultiplierMinor = 10
$WeightMultiplierBuild = 1

class UpgradableInfo {
    [string]$Hostname
    [string]$Software
    [string]$LocalVersion
    [string]$UpgradeVersion
    [int]$Weight
}

try {
    $response = Invoke-WebRequest -Uri "https://localhost:44311/api/Values"
    $json_lansweeper = ConvertFrom-Json $([String]::new($response.Content))
}
catch {
    [Environment]::Exit(1)
}

try {
    $response = Invoke-WebRequest -Uri "http://localhost:8090/"
    $json_chocolateyAppInfo = ConvertFrom-Json $([String]::new($response.Content)) 
    Invoke-RestMethod -Method Post -Uri "http://localhost:8090/refreshupgrade"
}
catch {
    [Environment]::Exit(2)
}

foreach($lso in $json_lansweeper) {
    foreach($choco in $json_chocolateyAppInfo) {
        if ($lso.SoftwareName.Trim().ToLower() -like $choco.Name.ToLower() -or $lso.SoftwareName.Replace(" ", "-").ToLower() -like $choco.Name.ToLower()) {
            $localVersion = $lso.SoftwareVersion
            $remoteVersion = $choco.Version
            
            if ([version]$remoteVersion -gt [version]$localVersion) {

                $remoteMajor = ([version]$remoteVersion).Major
                $remoteMinor = ([version]$remoteVersion).Minor
                $remoteBuild = ([version]$remoteVersion).Build

                $localMajor = ([version]$localVersion).Major
                $localMinor = ([version]$localVersion).Minor
                $localBuild = ([version]$localVersion).Build

                $dMajor = [Math]::Abs(($remoteMajor - $localMajor)) * $WeightMultiplierMajor
                $dMinor = [Math]::Abs(($remoteMinor - $localMinor)) * $WeightMultiplierMinor
                $dBuild = [Math]::Abs(($remoteBuild - $localBuild)) * $WeightMultiplierBuild

                if ($dBuild -gt 9) { # Vermeiden das es zahlen gibt die nur wegen der Build Nummer die Gewichtung auf 26000 hochziehen. Alles ab 10, gibt maximal 9 Punkte
                    $dBuild = 9
                }

                $delta = $dMajor + $dMinor + $dBuild

                $delta = [Math]::Abs($delta)

                Write-Host "Found Upgradable: $($lso.AssetName) - $($choco.Name.ToLower()) - Local Version: $($lso.SoftwareVersion) - Chocolatey Version: $($choco.Version) - Weight: $($delta)"

                $obj = @([UpgradableInfo]@{Hostname=$lso.AssetName;Software=$choco.Name;LocalVersion=$lso.SoftwareVersion;UpgradeVersion=$choco.Version;Weight=$delta})
                $json = $obj | ConvertTo-Json
                Invoke-RestMethod -Method Post -Uri "http://localhost:8090/upgrade" -Body $json -ContentType "application/json"
            }
            break;
        }
    }
}