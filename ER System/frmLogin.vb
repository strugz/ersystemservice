Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.Threading
Public Class frmLogin
    Dim username As String
    Dim oClip As New Clipping()
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Public mtx As Mutex
    Dim bool As Boolean
    Dim loginSearchStatus As String
    Dim CurrentVersion As String
    Dim NewVersion As String
    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Application.Exit()
    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)
        Try
            DBConnection()
            If Not IsConnected Then
                Me.Visible = False
                frmConnection.ShowDialog()
                DBConnection()
                If Not IsConnected Then
                    End
                End If
            End If
            LoadUserAccountAdmin()
        Catch ex As Exception
        End Try
        CurrentVersion = GetFileVersionInfo(Application.StartupPath + "\ER.exe").ToString()
        NewVersion = GetFileVersionInfo(Application.StartupPath + "\Executable\ER.exe").ToString()
        If CurrentVersion = NewVersion Then
        Else
            If (Not IO.File.Exists(Application.StartupPath + "\Executable")) Then
                Thread.Sleep(300)
                IO.File.Delete(Application.StartupPath + "\ER.exe")
                IO.File.Copy(Application.StartupPath + "\Executable\ER.exe", Application.StartupPath + "\ER.exe")

                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ER System\Connection", "ERUpdater", "1")
                If (Not IO.Directory.Exists(Application.StartupPath + "\ERPDF")) Then
                    IO.Directory.CreateDirectory(Application.StartupPath + "\ERPDF")
                End If
                MsgBox("Application Updated. The Application will be close . . . .")
                Application.Exit()
            End If
        End If
    End Sub
    Private Function GetFileVersionInfo(ByVal filename As String) As String
        GetFileVersionInfo = FileVersionInfo.GetVersionInfo(filename).FileVersion
        Return GetFileVersionInfo
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        LoginUserAccount(UCase(txtUsername.Text), TripleDes.EncryptData(txtPassword.Text))
        SearchDup()
        If txtUsername.Text = Nothing Or txtPassword.Text = Nothing Then
            MsgBox("Please Fill Your Username/Password")
            txtUsername.Focus()
        Else
            If loginSearchStatus = "1" Then
                DUpAcct("0")
                Threading.Thread.Sleep(300)
                DUpAcct("1")
                LoadUserAccount()
            ElseIf loginSearchStatus = "0" Then
                DUpAcct("1")
                LoadUserAccount()
            ElseIf modLoadingData.LoginUsername = Nothing Or modLoadingData.LoginPassword = Nothing Then
                MsgBox("No Username/Password Detected")
                txtPassword.Clear()
                txtPassword.Focus()
            End If
            frmMain.Timer2.Enabled = True
            frmMain.Timer2.Interval = 100
            frmMain.Timer2.Start()
        End If
    End Sub
    Private Sub LoadUserAccount()
        If modLoadingData.LoginDepartment <> "IMS" And modLoadingData.LoginUsername = UCase(txtUsername.Text) And modLoadingData.LoginPassword = txtPassword.Text And modLoadingData.LoginUserLevel = "Admin" Then
            frmMain.Show()
            Me.Hide()
            frmMain.MenuForms.Visible = True
            frmMain.MenuFile.Visible = True
            frmMain.btnPrintPreview.Enabled = False
            frmMain.btnFileReport.Enabled = False
            frmMain.Enabled = True
            frmMain.colored.BringToFront()
            frmMain.ttuser.Text = modLoadingData.LoginFullname
            frmMain.tsslUserDept.Text = modLoadingData.LoginDepartment
            frmMain.tsmiPrev.Visible = False
            frmMain.UserAccountToolStripMenuItem.Visible = False
            frmMain.fmsExpenseSummary.Visible = False
        ElseIf modLoadingData.LoginDepartment = "IMS" And modLoadingData.LoginUsername = UCase(txtUsername.Text) And modLoadingData.LoginPassword = txtPassword.Text And modLoadingData.LoginUserLevel = "Admin" Then
            frmMain.Show()
            Me.Hide()
            frmMain.tsmiPrev.Visible = True
            frmMain.UserAccountToolStripMenuItem.Visible = True
            frmMain.MenuForms.Visible = True
            frmMain.MenuFile.Visible = True
            frmMain.btnPrintPreview.Enabled = False
            frmMain.btnFileReport.Enabled = False
            frmMain.Enabled = True
            frmMain.colored.BringToFront()
            frmMain.ttuser.Text = modLoadingData.LoginFullname
            frmMain.tsslUserDept.Text = modLoadingData.LoginDepartment
            'frmMain.MenuExpenseDetails.Visible = True
            frmMain.fmsExpenseSummary.Visible = True
        ElseIf modLoadingData.LoginDepartment = "IMS" And modLoadingData.LoginUsername = UCase(txtUsername.Text) And modLoadingData.LoginPassword = txtPassword.Text And modLoadingData.LoginUserLevel = "User" Then
            frmMain.Show()
            Me.Hide()
            frmMain.tsmiPrev.Visible = True
            frmMain.UserAccountToolStripMenuItem.Visible = False
            frmMain.MenuForms.Visible = False
            frmMain.MenuFile.Visible = True
            frmMain.btnPrintPreview.Enabled = False
            frmMain.btnFileReport.Enabled = False
            frmMain.Enabled = True
            frmMain.colored.BringToFront()
            frmMain.ttuser.Text = modLoadingData.LoginFullname
            frmMain.tsslUserDept.Text = modLoadingData.LoginDepartment
            'frmMain.MenuExpenseDetails.Visible = False
            frmMain.fmsExpenseSummary.Visible = False
        ElseIf modLoadingData.LoginDepartment <> "IMS" And modLoadingData.LoginUsername = UCase(txtUsername.Text) And modLoadingData.LoginPassword = txtPassword.Text And modLoadingData.LoginUserLevel = "User" Then
            frmMain.Show()
            Me.Hide()
            frmMain.tsmiPrev.Visible = False
            frmMain.ttuser.Text = modLoadingData.LoginFullname
            frmMain.tsslUserDept.Text = modLoadingData.LoginDepartment
            frmMain.UserAccountToolStripMenuItem.Visible = False
            frmMain.MenuForms.Visible = False
            frmMain.MenuFile.Visible = True
            frmMain.btnPrintPreview.Enabled = False
            frmMain.btnFileReport.Enabled = False
            frmMain.Enabled = True
            frmMain.colored.BringToFront()
            'frmMain.MenuExpenseDetails.Visible = False
            frmMain.fmsExpenseSummary.Visible = False
        Else
            MsgBox("Invalid Username/Password")
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub
    Private Sub SearchDup()
        Dim dt As New DataTable
        Dim sqlcmdSearchDup As New SqlClient.SqlCommand
        With sqlcmdSearchDup
            .Connection = SQLConnection
            .CommandText = "Select a.[Status] from tbUserRegistration as a where UserID='" & modLoadingData.LoginuserID & "'"
            .CommandType = CommandType.Text
            dt.Load(.ExecuteReader)
            If dt.Rows.Count <> 0 Then
                loginSearchStatus = dt.Rows(0).Item("Status")
            End If
        End With
    End Sub
    Private Sub DUpAcct(ByVal loginStatus As String)
        Dim sqlcmdDup As New SqlClient.SqlCommand
        With sqlcmdDup
            .Connection = SQLConnection
            .CommandText = "Update tbUserRegistration set [Status] = '" & loginStatus & "' where UserID = '" & modLoadingData.LoginuserID & "'"
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
End Class