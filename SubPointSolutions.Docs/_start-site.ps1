cls

cd  $PSScriptRoot

$wyam_folder_path = [System.IO.Path]::GetFullPath("..\packages\Wyam.0.11.3-beta\tools");
$wyam_config = "_site.wyam"  

Write-Host "Running Wyam from [$wyam_folder_path]" -ForegroundColor Green

. "$wyam_folder_path\Wyam.exe"  --input "$PSScriptRoot\Views" `
								  --output "$PSScriptRoot\Views-Output" `
								  --preview --watch `
								  --config $wyam_config