# ========================================================================
#	This script looks up the directory tree searching for the NETFx root
#	which is signaled by the netfx.txt file.
#	Once the root is located, the Common.ps1 from there is imported 
#	in the context and the Push-Packages function in it is invoked.
# ========================================================================

$current = $pwd.Path
$paths = new-object System.Collections.Stack
$dir = new-object System.IO.DirectoryInfo $pwd.Path
$isRoot = gci netfx.txt -ea silentlycontinue

# Search for the root
while ($isRoot -eq $null)
{
	$paths.Push($dir.Name)
	$dir = $dir.Parent
	
	pushd ..\
	$isRoot = gci netfx.txt -ea silentlycontinue
}

. ./Common.ps1
Build-Packages $current

mkdir Drop -ea silentlycontinue
$dropDir = gci -Filter Drop

Get-ChildItem -Path $current -Recurse -Filter *.nupkg | `
Where-Object { $_.DirectoryName.EndsWith("bin\Release") }  | %{ `
	$target = [System.IO.Path]::Combine($dropDir.FullName, $_.Name); `
	Remove-Item -Path $target -ea silentlycontinue; `
	$_.MoveTo($target); }

# Pop folders just in case this is invoked from a powershell prompt
$current = $pwd.Path
popd
while ($current -ne $pwd.Path)
{
	$current = $pwd.Path
	popd
}

write-host Done!