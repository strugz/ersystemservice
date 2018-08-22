Public Class frmCancelNote

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOkay.Click
        Dim sqlcmdUpdateFilePrintStatus As New SqlClient.SqlCommand

        Try
            If modLoadingData.ReportID = Nothing Or modLoadingData.ReportID = "" Then
                MsgBox("No Report Selected")
            Else
                With sqlcmdUpdateFilePrintStatus
                    .Connection = SQLConnection
                    .CommandText = "sp2_LoadUserReportDetailsCancel"
                    .Parameters.Add("@reportID", SqlDbType.BigInt).Value = modLoadingData.ReportID
                    .Parameters.AddWithValue("@reportCancelNote", rtbNote.Text).SqlDbType = SqlDbType.VarChar
                    .CommandType = CommandType.StoredProcedure
                    .ExecuteNonQuery()
                    MsgBox("Report Rejected")
                End With
                If modLoadingData.ChangeLoad = 1 Then
                    LoadingUserReportDetailsFILED(frmApprove.userIDApprove, frmMain.ChangeLoading, modLoadingData.LoginuserID)
                Else
                    LoadingUserReportDetailsDONE(frmApprove.userIDApprove, frmMain.ChangeLoading, modLoadingData.LoginuserID)
                End If

                frmApprove.dgvUserReportDetails.Columns("ID").Visible = False
                frmApprove.dgvUserReportDetails.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
                frmMain.LoadingER()
                If frmMain.ChangeLoading = "1" Then
                    LoadingUserAccountFiled(modLoadingData.LoginDeptID)
                    Me.Show()
                    frmMain.ChangeLoading = "1"
                    Me.TopMost = True
                    frmApprove.btnApprove.Visible = True
                Else
                    LoadingUserAccountPending(modLoadingData.LoginDeptID)
                    frmApprove.Show()
                    frmMain.ChangeLoading = "0"
                    frmApprove.TopMost = True
                    frmApprove.btnApprove.Visible = False
                    frmApprove.btnCancel.Location = New Point(331, 480)
                    frmApprove.btnReportViewer.Location = New Point(442, 480)
                    frmRpt.cryptRptER.ShowPrintButton = False
                    frmApprove.dgvUser.Columns("Number of File").Visible = False
                    frmApprove.dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                End If
            End If
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub

    Private Sub frmCancelNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class