Imports System.Security.Cryptography
Imports Microsoft.Win32
Module mConn
    Public LocalSQLConnection As SqlClient.SqlConnection
    Public MyConnection As Object
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Public SQLConnection As SqlClient.SqlConnection
    Public cnString As String
    Public connectString As String
    Public ActiveDBType As String
    Public IsConnected As Boolean
    Public ExtDBConnection As Object
    Public objIntegration As Object
    Public currentDate As String
    Private strLogs As String
    Public objRatesSettings As Object
    Public isConnectedPrevious As Boolean
    Public conn As New SqlClient.SqlConnection
    Public Sub DBConnection()
        Select Case My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "DBType", "Microsoft Access")
            Case "Microsoft Access"
            Case "Miscrosoft SQL Server"
                SQLConnection = New SqlClient.SqlConnection
                ActiveDBType = "MSSQL"
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "Authentication", _
                                            "Windows Authentication") = "Windows Authentication" Then
                    cnString = "Data Source=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "ServerName", "")) & _
                                                    ";Integrated Security=TRUE" & ";Database=" & _
                                                    TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "Database", ""))
                Else
                    cnString = "Data Source=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "ServerName", "")) & _
                                                    ";Integrated Security=FALSE" & ";UID=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "UserName", "")) & _
                                                    ";PWD=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "Password", "")) & _
                                                    ";Database=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "Database", ""))
                End If
                SQLConnection.ConnectionString = cnString
                Try
                    SQLConnection.Open()
                    IsConnected = True
                Catch ex As Exception
                    IsConnected = False
                End Try
            Case "MYSQL"
            Case "Odbc"
        End Select
    End Sub
    Public Sub ConnectionPreviousER()
        connectString = "Data Source=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "ServerName", "")) & _
                                                            ";Integrated Security=FALSE" & ";UID=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "UserName", "")) & _
                                                            ";PWD=" & TripleDes.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "Password", "")) & _
                                                            ";Database=ExpenseReportDB"
        conn.ConnectionString = connectString
        conn.Open()

    End Sub
End Module
