Imports System.Security.Cryptography
Imports Microsoft.Win32
Public Class frmChangePassword
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If txtNew.Text = txtCon.Text And modLoadingData.LoginPassword = txtCurrent.Text Then
            ChangePassword(modLoadingData.LoginuserID, TripleDes.EncryptData(txtNew.Text))
            MsgBox("Change Successfully")
            Me.Close()
        Else
            MsgBox("Your Password is not match")
        End If
    End Sub
    Private Sub frmChangePassword_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.TopMost = False
        frmMain.TopMost = True
    End Sub

    Private Sub frmChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.KeyPreview = True
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub
    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        LoadingUserAccountEmail(modLoadingData.LoginuserID, modLoadingData.LoginDeptID)

        txtEmailAdd.Text = TripleDes.DecryptData(modLoadingData.EmailAdd)
        txtEmailPass.Text = TripleDes.DecryptData(modLoadingData.EmailPass)
        txtEmailTo.Text = modLoadingData.EmailTo
        txtBcc.Text = modLoadingData.EmailBCC
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            UpdateEmailSetup(modLoadingData.LoginuserID, TripleDes.EncryptData(txtEmailAdd.Text), TripleDes.EncryptData(txtEmailPass.Text), txtEmailTo.Text, txtBcc.Text)
            MsgBox("Successfully Update" + vbNewLine + "Application Need to close ....")
            Application.Exit()
        Catch ex As Exception
        End Try
    End Sub
End Class