﻿Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.Win32
Public Class frmUserRegistration
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Public dtdepartment As New DataTable
    Dim dtdepartmentManager As New DataTable
    Public DeptID As String
    Public picName As String
    Dim MyEmail As String
    Dim MyEMailPass As String
    Dim username As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        LoadDuplicateUserID(txtUserID.Text)
        If txtUser.Text = username And txtUserID.Text = modLoadingData.DuplicateUserID Then
            LoadDupUser()
            MsgBox("Username/UserID is Already Use/Exist")
        ElseIf txtUser.Text = username Or txtUserID.Text = modLoadingData.DuplicateUserID Then
            LoadDupUser()
            MsgBox("Username/UserID is Already Use/Exist")
        ElseIf txtUser.Text = username Then
            LoadDupUser()
            MsgBox("Username/UserID is Already Use/Exist")
        ElseIf txtUserID.Text = modLoadingData.DuplicateUserID Then
            LoadDupUser()
            MsgBox("Username/UserID is Already Use/Exist")
        ElseIf Trim(picName) = "" And cbDepartment.SelectedValue.ToString = "7" Then
            AdduserAccount(txtUserID.Text, txtFullname.Text, txtPosition.Text, cbDepartment.SelectedValue.ToString, UCase(txtUser.Text), TripleDes.EncryptData(txtPassword.Text), TripleDes.EncryptData("ereports.mdmpi@marsmandrysdale.com").ToString, TripleDes.EncryptData("JayAb@0ag").ToString, txtEmailTo.Text, txtEmailBcc.Text, txtUserlevel.Text)
            MsgBox("Successfully Save")
            LoadingUserAccount(modLoadingData.LoginDeptID)
            Clear()
        ElseIf Trim(picName) = "" Then
            MsgBox("Please Insert Signature")
        Else
            AdduserAccount(txtUserID.Text, txtFullname.Text, txtPosition.Text, cbDepartment.SelectedValue.ToString, UCase(txtUser.Text), TripleDes.EncryptData(txtPassword.Text), TripleDes.EncryptData("ereports.mdmpi@marsmandrysdale.com").ToString, TripleDes.EncryptData("JayAb@0ag").ToString, txtEmailTo.Text, txtEmailBcc.Text, txtUserlevel.Text)
            MsgBox("Successfully Save")
            LoadingUserAccount(modLoadingData.LoginDeptID)
            Clear()
        End If
        LoadMaxUserID()
        txtUserID.Text = modLoadingData.MaxUserID + 1
    End Sub
    Public Sub LoadDupUser()
        modLoadingData.LoadDuplicateUser(UCase(txtUser.Text))
        If modLoadingData.dtLoadDupUser.Rows.Count <> 0 Then
            username = modLoadingData.dtLoadDupUser.Rows(0).Item("username").ToString
        End If
    End Sub
    Private Sub Clear()
        txtEmailBcc.Clear()
        txtEmailTo.Clear()
        txtFullname.Clear()
        txtPassword.Clear()
        txtPosition.Clear()
        txtUser.Clear()
        txtUserID.Clear()
        txtUserlevel.SelectedIndex = 1
        picSignature.Image = Nothing
        btnSave.Visible = True
        btnUpdate.Visible = False
    End Sub

    Private Sub frmUserRegistration_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.TopMost = False
        frmMain.TopMost = True
    End Sub

    Private Sub frmUserRegistration_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.KeyPreview = True
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmUserRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadingUserAccount(modLoadingData.LoginDeptID)
            cbDeptManager()

            txtUserlevel.SelectedIndex = 2

        Catch ex As Exception
        End Try
        LoadMaxUserID()
        txtUserID.Text = modLoadingData.MaxUserID + 1
    End Sub
    Private Sub cbDeptManager()


        LoadingDepartment()


    End Sub
    Private Sub cbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDepartment.SelectedIndexChanged
        'LoadingDepartmentManager(cbDepartment.Text)
        DeptID = cbDepartment.SelectedValue.ToString
    End Sub
    Private Sub picEmployee_Click(sender As Object, e As EventArgs) Handles picSignature.Click
        fd.Title = "Select your Image."
        fd.InitialDirectory = "C:\"
        fd.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg|PNGs|*.png"
        fd.RestoreDirectory = False
        If fd.ShowDialog() = DialogResult.OK Then
            picName = fd.FileName
            picSignature.Image = Image.FromFile(fd.FileName)
        End If
    End Sub

    Private Sub dgvUserAccount_CellContextMenuStripNeeded(sender As Object, e As DataGridViewCellContextMenuStripNeededEventArgs) Handles dgvUserAccount.CellContextMenuStripNeeded

    End Sub
    Private Sub dgvUserAccount_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserAccount.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                MsgBox("Please double click on the row you are interested in")
                Exit Sub
            Else
                If IsDBNull(dgvUserAccount.Rows(e.RowIndex).Cells("Signature").Value) = True Then
                    picSignature.Image = Nothing
                    MsgBox("No Signature")
                Else
                    Try

                        Dim ms As New IO.MemoryStream(CType(dgvUserAccount.Rows(e.RowIndex).Cells("Signature").Value, Byte()))
                        Dim img As Image = Image.FromStream(ms)
                        picName = img.ToString
                        picSignature.Image = img

                    Catch ex As Exception

                    End Try
                End If
                With dgvUserAccount
                    txtUserID.Text = .Rows(e.RowIndex).Cells("UserID").Value
                    txtFullname.Text = .Rows(e.RowIndex).Cells("Fullname").Value
                    txtUser.Text = .Rows(e.RowIndex).Cells("username").Value
                    If IsDBNull(txtPosition.Text = .Rows(e.RowIndex).Cells("Position").Value) = True Then
                        txtPosition.Text = ""
                    Else
                        txtPosition.Text = .Rows(e.RowIndex).Cells("Position").Value
                    End If
                    txtUserlevel.Text = .Rows(e.RowIndex).Cells("User Level").Value
                    If IsDBNull(txtEmailTo.Text = .Rows(e.RowIndex).Cells("Email To").Value) = True Then
                        txtEmailTo.Text = ""
                    Else
                        txtEmailTo.Text = .Rows(e.RowIndex).Cells("Email To").Value
                    End If
                    If IsDBNull(txtEmailBcc.Text = .Rows(e.RowIndex).Cells("EmailBCC").Value) = True Then
                        txtEmailBcc.Text = ""
                    Else
                        txtEmailBcc.Text = .Rows(e.RowIndex).Cells("EmailBCC").Value
                    End If
                    cbDepartment.SelectedValue = .Rows(e.RowIndex).Cells("DeptID").Value.ToString
                    If IsDBNull(txtPassword.Text = .Rows(e.RowIndex).Cells("Password").Value) Then
                        txtPassword.Text = ""
                    Else
                        txtPassword.Text = TripleDes.DecryptData(.Rows(e.RowIndex).Cells("Password").Value)
                    End If
                End With
                txtUserID.Enabled = False
                btnUpdate.Visible = True
                btnSave.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
        picName = Nothing
        txtUserID.Enabled = True
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateUserAccount(txtUserID.Text, txtFullname.Text, txtPosition.Text, cbDepartment.SelectedValue.ToString, UCase(txtUser.Text), TripleDes.EncryptData(txtPassword.Text), txtEmailTo.Text, txtEmailBcc.Text, txtUserlevel.Text)
        LoadingUserAccount(modLoadingData.LoginDeptID)
        MsgBox("Save Successfully")
        btnSave.Visible = True
        btnUpdate.Visible = False
        Clear()
        picName = Nothing
        txtUserID.Enabled = True

    End Sub

    Private Sub dgvUserAccount_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserAccount.CellContentClick

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class