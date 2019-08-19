$fileList = Get-ChildItem "." -recurse *.exe | %{$_.FullName}
Foreach($file in $fileList){ & $file; write-host $file; sleep 2; }
pause