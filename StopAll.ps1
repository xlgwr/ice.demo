$fileList = Get-ChildItem "." -recurse *.exe | %{$_.BaseName}
Foreach($file in $fileList){ write-host $file; Get-Process -Name $file | foreach-object{$_.Kill()} }
pause