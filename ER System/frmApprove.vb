Public Class frmApprove
    Public userIDApprove As String
    Dim UserID As String
    Dim sqlUpdatefileStatus As New SqlClient.SqlCommand
    Private Sub frmApprove_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.TopMost = False
    End Sub

    Private Sub frmApprove_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Me.KeyPreview = True
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmApprove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvUser.Columns("UserID").Visible = False
        dgvUser.Columns("Position").Visible = False
        dgvUser.Columns("Username").Visible = False
        dgvUser.Columns("User Level").Visible = False
        dgvUser.Columns("Email Address").Visible = False
        dgvUser.Columns("Email To").Visible = False
        dgvUser.Columns("EmailBCC").Visible = False
        dgvUser.Columns("Signature").Visible = False
        dgvUser.Columns("DeptID").Visible = False
        dgvUser.Columns("Password").Visible = False
        dgvUser.Columns("EmailPass").Visible = False
        dgvUser.Columns("Department").Visible = False
        dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.TopMost = True
        frmMain.TopMost = False
    End Sub
    Private Sub dgvUser_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                MsgBox("Please Double click on the row you are interested in")
                Exit Sub
            Else
                userIDApprove = dgvUser.Rows(e.RowIndex).Cells("UserID").Value
            End If
        Catch ex As Exception

        End Try
        If modLoadingData.ChangeLoad = "1" Then
            LoadingUserReportDetailsFILED(userIDApprove, frmMain.ChangeLoading, modLoadingData.LoginuserID)
        Else
            LoadingUserReportDetailsDONE(userIDApprove, frmMain.ChangeLoading, modLoadingData.LoginuserID)
        End If
        dgvUserReportDetails.Columns("ID").Visible = False
        dgvUserReportDetails.Columns("Report Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvUserReportDetails.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
        If dgvUserReportDetails.Rows.Count <> 0 Then
            btnApprove.Enabled = True
            btnReportViewer.Enabled = True
            btnCancel.Enabled = True
            btnReject.Enabled = True
        Else
            MsgBox("Empty Report")
        End If
    End Sub
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        frmCancelNote.Show()
    End Sub
    Private Sub clear()
        btnApprove.Enabled = False
        btnReject.Enabled = False
        btnReportViewer.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        LoadSignatorySigned(modLoadingData.LoginuserID, userIDApprove, ReportID)
        If SignedID = modLoadingData.LoginuserID Then
            MsgBox("You Already Confirm the Report")
        Else
            With sqlUpdatefileStatus
                .Connection = SQLConnection
                .CommandText = "sp2_UpdateReportNumberStatus  '" & userIDApprove & "','" & ReportID & "','" & modLoadingData.LoginuserID & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            If modLoadingData.ChangeLoad = 1 Then
                LoadingUserReportDetailsFILED(userIDApprove, frmMain.ChangeLoading, LoginuserID)
            Else
                LoadingUserReportDetailsDONE(userIDApprove, frmMain.ChangeLoading, LoginuserID)
            End If
            dgvUserReportDetails.Columns("ID").Visible = False
            dgvUserReportDetails.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
            AddSign(userIDApprove, modLoadingData.LoginuserID, ReportID)
            ' frmMain.LoadingER()
            MsgBox("Approve Successfully")
            btnApprove.Enabled = False
            btnReject.Enabled = False
            btnReportViewer.Enabled = False
            If frmMain.ChangeLoading = "1" Then
                LoadingUserAccountFiled(modLoadingData.LoginDeptID)
                Me.Show()
                frmMain.ChangeLoading = "1"
                Me.TopMost = True
                Me.btnApprove.Visible = True
                '  Me.btnReject.Visible = True
            Else
                LoadingUserAccountPending(modLoadingData.LoginDeptID)
                Me.Show()
                frmMain.ChangeLoading = "0"
                Me.TopMost = True
                Me.btnApprove.Visible = False
                '  Me.btnReject.Visible = False
                Me.btnCancel.Location = New Point(331, 480)
                Me.btnReportViewer.Location = New Point(442, 480)
                frmRpt.cryptRptER.ShowPrintButton = False
                Me.dgvUser.Columns("Number of File").Visible = False
                Me.dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
        End If
    End Sub

    Private Sub dgvUserReportDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserReportDetails.CellClick
        If e.RowIndex < 0 Then
            MsgBox("Please Double click on the row you are interested in")
            Exit Sub
        Else
            modLoadingData.ReportID = dgvUserReportDetails.Rows(e.RowIndex).Cells("ID").Value
            ' MsgBox(reportID)
        End If
        If reportID = Nothing Or reportID = "" Then
            MsgBox("No Selected Report")
            btnApprove.Enabled = False
            btnReportViewer.Enabled = False
            btnCancel.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnReportViewer.Click
        If reportID = Nothing Then
            MsgBox("No Selected Report")
        Else
            frmRpt.reportID = modLoadingData.ReportID
            frmRpt.MyUserID = Me.userIDApprove
            frmRpt.Show()
            Me.SendToBack()
            frmRpt.BringToFront()
            frmRpt.cryptRptER.Dock = DockStyle.Fill
            frmRpt.Button1.Visible = False
            frmRpt.cryptRptER.DisplayToolbar = True
            Me.TopMost = False
            frmRpt.TopMost = True
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnApprove.Enabled = False
        btnReportViewer.Enabled = False
        btnCancel.Enabled = False
        Me.Close()
    End Sub

    Private Sub dgvUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellContentClick

    End Sub
End Class