Imports System.IO
Module modReuse
    Public Function SetTextFile(ByVal workwith As String, ByVal hospital As String,
                              ByVal instrument As String, ByVal serialnumber As String,
                                   ByVal servicenumber As String) As String
        Dim str() As String = {workwith, hospital, instrument, serialnumber, servicenumber}
        Dim objWriter As New StreamWriter(Application.StartupPath + "/ER.txt")
        If File.Exists(Application.StartupPath + "/ER.txt") = False Then
            Directory.CreateDirectory(Application.StartupPath + "/ER.txt")
            For i = 0 To str.Count - 1
                If i = str.Count - 1 Then
                    objWriter.Write(str(i))
                Else
                    objWriter.Write(str(i) + "/")
                End If
            Next
        Else
            For i = 0 To str.Count - 1
                If i = str.Count - 1 Then
                    objWriter.Write(str(i))
                Else
                    objWriter.Write(str(i) + "/")
                End If
            Next
            objWriter.Close()
        End If
        Return SetTextFile
    End Function
    Public Function GetTextFile() As String
        GetTextFile = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "/ER.txt")
    End Function
End Module
