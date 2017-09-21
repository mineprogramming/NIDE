strLink = "http://api.mineprogramming.org/nide/update.zip"
zipFile = "update.zip"

Set fileSystem = CreateObject("Scripting.FileSystemObject")

fullPath = fileSystem.GetAbsolutePathName(zipFile)
extractPath = fileSystem.GetParentFolderName(fullPath)


Set objHTTP = CreateObject("WinHttp.WinHttpRequest.5.1")
objHTTP.Open "GET", strLink, False
objHTTP.Send

         
If fileSystem.FileExists(fullPath) Then
    fileSystem.DeleteFile(fullPath)
End If

If objHTTP.Status = 200 Then
    Dim objStream
    Set objStream = CreateObject("ADODB.Stream")
    With objStream
           .Type = 1
           .Open
           .Write objHTTP.ResponseBody
           .SaveToFile fullPath
           .Close
    End With
    set objStream = Nothing
End If

set objHTTP = Nothing

If fileSystem.FileExists(strSaveTo) Then
    WScript.Echo "Download `" & zipFile & "` completed successfuly."
End If



set objShell = CreateObject("Shell.Application")
set FilesInZip = objShell.NameSpace(fullPath).items
objShell.NameSpace(extractPath).CopyHere(FilesInZip)

Set objShell = Nothing

Dim objShell
Set objShell = WScript.CreateObject( "WScript.Shell" )
objShell.Run(fileSystem.GetAbsolutePathName("NIDE.exe"))

fileSystem.DeleteFile(fullPath)

set fileSystem = Nothing 

