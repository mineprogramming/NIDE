strLink = "http://api.mineprogramming.org/nide/update.zip"
zipFile = "update.zip"

Set fileSystem = CreateObject("Scripting.FileSystemObject")

fullPath = fileSystem.GetAbsolutePathName(zipFile)
extractPath = fileSystem.GetParentFolderName(fullPath)

WScript.Echo "Downloading package """ & zipFile & """..."

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

If fileSystem.FileExists(fullPath) Then
    WScript.Echo "Package """ & zipFile & """ downloaded successfuly."
Else
    WScript.Echo "Cannot download update package!"
End If

WScript.Echo "Unpacking package """ & zipFile & """..."
set objShell = CreateObject("Shell.Application")
set FilesInZip = objShell.NameSpace(fullPath).items
for i = 0 to FilesInZip.count - 1
    file = fileSystem.GetAbsolutePathName(fileSystem.GetFileName(FilesInZip.item(i).path))
    If fileSystem.FileExists(file) Then
        fileSystem.DeleteFile(file)
    End If
next
objShell.NameSpace(extractPath).CopyHere(FilesInZip)
WScript.Echo "Unpacking package completed successfully"

Set objShell = Nothing

fileSystem.DeleteFile(fullPath)
MsgBox("Successfully updated NIDE")

Dim objShell
Set objShell = WScript.CreateObject( "WScript.Shell" )
objShell.Run(fileSystem.GetAbsolutePathName("NIDE.exe"))

set fileSystem = Nothing 
