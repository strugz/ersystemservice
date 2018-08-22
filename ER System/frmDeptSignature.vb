Public Class frmDeptSignature
    Dim dtDeptSIgn As New DataTable
    Public picSignature As New PictureBox
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddDeptSign(cbbDept.SelectedValue.ToString, txtReview.Text, txtEndorse.Text, txtApprove.Text, modLoadingData.LoginuserID)
        MsgBox("Successfully Added")
        Me.Close()
    End Sub

    Private Sub frmDeptSignature_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.KeyPreview = True
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub
    Private Sub frmDeptSignature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadingUserAccDept(modLoadingData.LoginuserID)
            dtDeptSIgn.Reset()
            LoadingDepartment()
            txtEndorse.Text = LoadEndorse
            txtReview.Text = LoadReview
            txtApprove.Text = LoadApprove
            cbbDept.SelectedValue = modLoadingData.LoginDeptID
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateDeptSign(modLoadingData.LoginuserID, modLoadingData.DeptID, txtReview.Text, txtEndorse.Text, txtApprove.Text)
        MsgBox("Successfully Update")
        LoadingUserAccDept(modLoadingData.LoginuserID)
        Me.Close()
    End Sub

End Class