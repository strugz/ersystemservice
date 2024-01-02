Public Class frmMain
    Public ChangeLoading As String
    Public UserID As String = Nothing
    Public DeptID As String = Nothing
    Public PrintStatus As String
    Public FileStatus As String
    Dim sqlcmdPrintStatus As New SqlClient.SqlCommand
    Dim loginStatus As String
    Dim dt As New DataTable
    Dim ReportStatus As String
    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Public Sub LoadingER()
        If DgvReportDetails.Rows.Count - 1 <> 0 Then
            LoadingDataReport(modLoadingData.LoginuserID, "01/01/1990", "12/01/2200")
            AutoSizegrid()
            DgvReportDetails.Columns("Report ID").Visible = False
            DgvReportDetails.Columns("CashCheck").Visible = False
            DgvReportDetails.Columns("CashAmount").Visible = False
            DgvReportDetails.Columns("CashDate").Visible = False
            DgvReportDetails.Columns("CashRefDoc").Visible = False
            DgvReportDetails.Columns("CashRefNo").Visible = False
            DgvReportDetails.Columns("RevolvingFund").Visible = False
            DgvReportDetails.Columns("ReportPrintStatus").Visible = False
            DgvReportDetails.Columns("ReportFileStatus").Visible = False
            DgvReportDetails.Columns("ReportSentStatus").Visible = False
            Dim i As Integer
            Dim f = New Font("Calibri", 10, FontStyle.Bold)
            For i = 0 To DgvReportDetails.Rows.Count - 1
                If DgvReportDetails.Rows(i).Cells("Status").Value = "Approved" Then
                    Me.DgvReportDetails.Rows(i).Cells("Status").Style.Font = f
                    Me.DgvReportDetails.Rows(i).Cells("Date From").Style.Font = f
                    Me.DgvReportDetails.Rows(i).Cells("Date To").Style.Font = f
                    Me.DgvReportDetails.Rows(i).Cells("Description").Style.Font = f
                    Me.DgvReportDetails.Rows(i).Cells("Status").Style.ForeColor = Color.Black
                    Me.DgvReportDetails.Rows(i).Cells("Date From").Style.ForeColor = Color.Black
                    Me.DgvReportDetails.Rows(i).Cells("Date To").Style.ForeColor = Color.Black
                    Me.DgvReportDetails.Rows(i).Cells("Description").Style.ForeColor = Color.Black
                End If
            Next
        Else
            LoadingDataReport(modLoadingData.LoginuserID, "01/01/1990", "12/01/2200")
            AutoSizegrid()
            DgvReportDetails.Columns("Report ID").Visible = False
            DgvReportDetails.Columns("CashCheck").Visible = False
            DgvReportDetails.Columns("CashAmount").Visible = False
            DgvReportDetails.Columns("CashDate").Visible = False
            DgvReportDetails.Columns("CashRefDoc").Visible = False
            DgvReportDetails.Columns("CashRefNo").Visible = False
            DgvReportDetails.Columns("RevolvingFund").Visible = False
            DgvReportDetails.Columns("ReportPrintStatus").Visible = False
            DgvReportDetails.Columns("ReportFileStatus").Visible = False
            DgvReportDetails.Columns("ReportSentStatus").Visible = False
        End If
    End Sub
    Public Sub AutoSizegrid()
        DgvReportDetails.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DgvReportDetails.Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Private Sub DgvReportDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvReportDetails.CellClick
        Try
            If e.RowIndex < 0 Then
                MsgBox("Please Double click on the row you are interested in")
                Exit Sub
            Else
                modLoadingData.sDate = DgvReportDetails.Rows(e.RowIndex).Cells("Date From").Value
                modLoadingData.eDate = DgvReportDetails.Rows(e.RowIndex).Cells("Date To").Value
                frmEReport.Description = DgvReportDetails.Rows(e.RowIndex).Cells("Description").Value
                modLoadingData.ReportIDExport = DgvReportDetails.Rows(e.RowIndex).Cells("Report ID").Value
                frmEReport.CashCheck = DgvReportDetails.Rows(e.RowIndex).Cells("CashCheck").Value
                frmEReport.txtAmount.Text = DgvReportDetails.Rows(e.RowIndex).Cells("CashAmount").Value
                frmEReport.DtpReportDate.Text = DgvReportDetails.Rows(e.RowIndex).Cells("CashDate").Value
                frmEReport.txtRefDoc.Text = DgvReportDetails.Rows(e.RowIndex).Cells("CashRefDoc").Value
                frmEReport.txtRefNum.Text = DgvReportDetails.Rows(e.RowIndex).Cells("CashRefNo").Value
                frmEReport.txtRevFund.Text = DgvReportDetails.Rows(e.RowIndex).Cells("RevolvingFund").Value
                PrintStatus = DgvReportDetails.Rows(e.RowIndex).Cells("ReportPrintStatus").Value
                FileStatus = DgvReportDetails.Rows(e.RowIndex).Cells("ReportFileStatus").Value
                ReportStatus = DgvReportDetails.Rows(e.RowIndex).Cells("Status").Value
                ReportPrintStatus = IIf(IsDBNull(DgvReportDetails.Rows(e.RowIndex).Cells("ReportSentStatus").Value) = True, "", DgvReportDetails.Rows(e.RowIndex).Cells("ReportSentStatus").Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If modLoadingData.LoginUserLevel = "Admin" Then
            frmEReport.Show()
            frmEReport.BringToFront()
            frmEReport.Focus()
            DgvReportDetails.Enabled = False
            MenuStrip1.Enabled = False
            frmRpt.cryptRptER.ShowPrintButton = True
        Else
            If PrintStatus = "0" Then
                ' MsgBox("Your Forms is already Printed" & vbNewLine & "Please Contact Your Administrator")
                ' frmEReport.TopMost = True
                '  frmEReport.Show()
                '  frmEReport.TabControl1.TabPages.Remove(frmEReport.TabPage2)
                Me.TopMost = False
                Me.btnPrintPreview.Enabled = True
                btnReportData.Enabled = False
                frmEReport.btnUpdate.Visible = True
                frmEReport.BtnSave.Visible = False
                btnFileReport.Enabled = True
                If frmEReport.CashCheck = "1" Then
                    frmEReport.CbCashAdvanceReceive.Checked = True
                Else
                    frmEReport.CbCashAdvanceReceive.Checked = False
                End If

            ElseIf ReportStatus = "New" Or ReportStatus = "Returned" Then
                btnReportData.Enabled = False
                frmEReport.btnUpdate.Visible = True
                frmEReport.BtnSave.Visible = False
                Me.btnPrintPreview.Enabled = True
                Me.btnFileReport.Enabled = True
                frmEReport.BringToFront()
                Me.TopMost = False
                If frmEReport.CashCheck = "1" Then
                    frmEReport.CbCashAdvanceReceive.Checked = True
                Else
                    frmEReport.CbCashAdvanceReceive.Checked = False
                End If
                frmEReport.Show()
                DgvReportDetails.Enabled = False
                MenuStrip1.Enabled = False
                frmEReport.Location = New Point(200, 157)
                frmEReport.Width = 1055
                Me.btnPrintPreview.Enabled = True
                frmRpt.btnSendPrint.Enabled = False
                frmRpt.cryptRptER.ShowNextPage()
                frmRpt.cryptRptER.DisplayToolbar = True
                frmRpt.cryptRptER.ShowPrintButton = False
                frmRpt.cryptRptER.ShowCopyButton = False
                frmRpt.cryptRptER.ShowExportButton = False
            ElseIf ReportStatus = "For Approval" Then
                btnReportData.Enabled = False
                frmEReport.btnUpdate.Visible = True
                frmEReport.BtnSave.Visible = False
                Me.btnPrintPreview.Enabled = True
                Me.btnFileReport.Enabled = True
                frmEReport.BringToFront()
                Me.TopMost = False
                If frmEReport.CashCheck = "1" Then
                    frmEReport.CbCashAdvanceReceive.Checked = True
                Else
                    frmEReport.CbCashAdvanceReceive.Checked = False
                End If
                frmRpt.cryptRptER.ShowNextPage()
                frmRpt.cryptRptER.DisplayToolbar = True
                frmRpt.cryptRptER.ShowPrintButton = False
                frmRpt.cryptRptER.ShowCopyButton = False
                frmRpt.cryptRptER.ShowExportButton = False
                frmRpt.btnSendPrint.Enabled = True
            Else
                btnReportData.Enabled = False
                frmEReport.btnUpdate.Visible = True
                frmEReport.BtnSave.Visible = False
                Me.btnPrintPreview.Enabled = True
                Me.btnFileReport.Enabled = True
                frmEReport.BringToFront()
                Me.TopMost = False
                If frmEReport.CashCheck = "1" Then
                    frmEReport.CbCashAdvanceReceive.Checked = True
                Else
                    frmEReport.CbCashAdvanceReceive.Checked = False
                End If
            End If
        End If
        If modLoadingData.LoginUserLevel = "Admin" Then
            frmEReport.btnUpdate.Enabled = False
            Me.TopMost = False
            frmEReport.BringToFront()
            frmEReport.txtPofExpense.Text = frmEReport.Description
            frmEReport.DtpReportFrom.Value = modLoadingData.sDate
            frmEReport.DtpReportTo.Value = modLoadingData.eDate
            frmEReport.txtStatus.SelectedIndex = 0
            Me.btnFileReport.Enabled = True
            modLoadingData.ExpenseCount = Nothing
            Me.btnFileReport.Text = "Update Report"
            Me.ToolTip1.SetToolTip(Me.btnFileReport, "Update Report")
            Me.ToolStripButton1.Enabled = False
            Me.ToolStripButton2.Enabled = False
            Me.btnPrintPreview.Enabled = True
            frmEReport.BtnSave.Visible = False
            frmEReport.btnUpdate.Visible = True
            frmEReport.btnUpdate.Enabled = True
            frmEReport.Location = New Point(200, 157)
            frmEReport.TabControl1.SelectedTab = frmEReport.TabPage2
            frmRpt.cryptRptER.DisplayToolbar = True
            frmRpt.cryptRptER.ShowPrintButton = True
            frmRpt.cryptRptER.ShowNextPage()
            frmRpt.cryptRptER.DisplayToolbar = True
            frmRpt.cryptRptER.ShowPrintButton = False
            frmRpt.cryptRptER.ShowCopyButton = False
            frmRpt.cryptRptER.ShowExportButton = False
            frmRpt.btnSendPrint.Enabled = True
        Else
            If Me.PrintStatus = 0 And Me.FileStatus = "0" Then
                frmEReport.btnUpdate.Enabled = False
                frmEReport.txtPofExpense.Text = frmEReport.Description
                frmEReport.DtpReportFrom.Value = modLoadingData.sDate
                frmEReport.DtpReportTo.Value = modLoadingData.eDate
                frmEReport.txtStatus.SelectedIndex = 0
                Me.btnFileReport.Enabled = True
                modLoadingData.ExpenseCount = Nothing
                Me.btnFileReport.Text = "Update Report"
                Me.ToolTip1.SetToolTip(Me.btnFileReport, "Update Report")
                Me.ToolStripButton1.Enabled = False
                Me.ToolStripButton2.Enabled = False
            ElseIf Me.FileStatus = "1" And Me.PrintStatus = 1 Then
                frmEReport.DtpReportFrom.Value = modLoadingData.sDate
                frmEReport.DtpReportTo.Value = modLoadingData.eDate
                Me.btnFileReport.Enabled = False
                frmEReport.txtPofExpense.Text = frmEReport.Description
                frmEReport.txtStatus.SelectedIndex = 0
                modLoadingData.ExpenseCount = Nothing
                Me.btnFileReport.Text = "Already Filed"
                Me.ToolTip1.SetToolTip(Me.btnFileReport, "Already Filed")
                frmEReport.btnUpdate.Enabled = False
                Me.ToolStripButton1.Enabled = False
                Me.ToolStripButton2.Enabled = False
            Else
                frmEReport.DtpReportFrom.Value = modLoadingData.sDate
                frmEReport.DtpReportTo.Value = modLoadingData.eDate
                frmEReport.txtPofExpense.Text = frmEReport.Description
                'DtpReportFrom.Text = SDateReport
                'DtpReportTo.Text = EdateReport
                frmEReport.txtStatus.SelectedIndex = 0
                Me.btnFileReport.Enabled = True
                modLoadingData.ExpenseCount = Nothing
                Me.btnFileReport.Text = "File Report"
                Me.ToolTip1.SetToolTip(Me.btnFileReport, "File Report")
                Me.ToolStripButton1.Enabled = False
                Me.ToolStripButton2.Enabled = False
                frmRpt.btnSendPrint.Enabled = False
                'frmRpt.cryptRptER.DisplayToolbar = True
                'frmRpt.cryptRptER.Dock = DockStyle.Fill
                frmRpt.cryptRptER.ShowPrintButton = False
            End If
        End If
    End Sub
    Private Sub UpdatePrintStatus()
        With sqlcmdPrintStatus
            .Connection = SQLConnection
            .CommandText = "UPDATE tbReportDetails SET ReportPrintStatus ='1',ReportNumberStatus = '0' where ID='" & modLoadingData.ReportIDExport & "'"
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
    End Sub
    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmUserRegistration.ShowDialog()
    End Sub
    Private Sub ERToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        frmApprove.Show()
        ChangeLoading = "1"
        frmApprove.TopMost = True
        frmApprove.btnApprove.Visible = True
    End Sub
    Private Sub ERCashAdvanceToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmApprove.Show()
        ChangeLoading = "0"
        frmApprove.TopMost = True
        frmApprove.btnApprove.Visible = False
        frmApprove.btnCancel.Location = New Point(331, 480)
        frmApprove.btnReportViewer.Location = New Point(442, 480)
        frmRpt.cryptRptER.ShowPrintButton = False
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs)
        If txtSearch.Text = "" Then
            LoadingER()
        Else
            SearchDataReport(Me.UserID, txtSearch.Text)
            AutoSizegrid()
            DgvReportDetails.Columns("Report ID").Visible = False
            DgvReportDetails.Columns("CashCheck").Visible = False
            DgvReportDetails.Columns("CashAmount").Visible = False
            DgvReportDetails.Columns("CashDate").Visible = False
            DgvReportDetails.Columns("CashRefDoc").Visible = False
            DgvReportDetails.Columns("CashRefNo").Visible = False
            DgvReportDetails.Columns("RevolvingFund").Visible = False
        End If
    End Sub
    Private Sub ActiveFormsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActiveFormsToolStripMenuItem.Click
        LoadingUserAccountFiled(modLoadingData.LoginDeptID)
        frmApprove.Show()
        Me.ChangeLoading = "1"
        ChangeLoad = ChangeLoading
        frmApprove.btnApprove.Visible = True
        frmApprove.btnReject.Visible = True
    End Sub
    Private Sub PreviousFormsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviousFormsToolStripMenuItem.Click
        LoadingUserAccountPending(modLoadingData.LoginDeptID)
        frmApprove.Show()
        ChangeLoading = "0"
        ChangeLoad = ChangeLoading
        frmApprove.BringToFront()
        frmApprove.btnApprove.Visible = False
        frmApprove.btnReject.Visible = False
        frmApprove.btnCancel.Location = New Point(405, 480)
        frmApprove.btnReportViewer.Location = New Point(516, 480)
        frmApprove.dgvUser.Columns("Number of File").Visible = False
        frmApprove.dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("IMS")
    End Sub
    Private Sub Logout()
        Me.Hide()
        frmLogin.Show()
        Me.Enabled = False
        frmLogin.txtUsername.Focus()
        ttuser.Text = Nothing
        tsslUserDept.Text = Nothing
        Me.UserID = Nothing
        Me.DeptID = Nothing
        '  LogoutdupAcc()
    End Sub
    Private Sub LogoutdupAcc()
        Dim dt As New DataTable
        Dim sqlcmdDupAcc As New SqlClient.SqlCommand
        With sqlcmdDupAcc
            .Connection = SQLConnection
            .CommandText = "update tbUserRegistration set [Status] = '0' where UserID = '" & modLoadingData.LoginuserID & "'"
            .ExecuteNonQuery()
            Timer2.Enabled = False
            Timer2.Stop()
        End With
    End Sub
    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.Control AndAlso e.KeyValue = Keys.L) = True Then
            frmLogin.txtUsername.Clear()
            frmLogin.txtPassword.Clear()
            Logout()
            LogoutdupAcc()
            Me.btnReportData.Enabled = False
            Me.btnPrintPreview.Enabled = False
            Me.btnReportData.Enabled = True
            Me.ToolStripButton1.Enabled = True
            Me.ToolStripButton2.Enabled = True
            modLoadingData.ReportIDExport = Nothing
            Me.btnFileReport.Enabled = False
            Me.btnFileReport.Text = "File Report"
            Me.DgvReportDetails.DataSource = Nothing
            frmAdditionalInput.Close()
            frmApprove.Close()
            frmCancelNote.Close()
            frmChangePassword.Close()
            frmDeptSignature.Close()
            frmEmailSetup.Close()
            frmEReport.Close()
            frmERType.Close()
            frmExpenseDetails.Close()
            frmHelp.Close()
            frmLoading.Close()
            frmPreviousER.Close()
            frmPreviousERExpense.Close()
            frmReturnedER.Close()
            frmRpt.Close()
            frmSelectDept.Close()
            frmSignature.Close()
            frmUserRegistration.Close()
        ElseIf (e.KeyValue = Keys.Escape) = True Then
            btnPrintPreview.Enabled = False
            btnFileReport.Enabled = False
            ToolStripButton1.Enabled = True
            btnReportData.Enabled = True
            Me.ToolStripButton1.Enabled = True
            Me.ToolStripButton2.Enabled = True
            modLoadingData.ReportIDExport = Nothing
            frmEReport.Description = Nothing
            Me.btnFileReport.Enabled = False
            Me.btnFileReport.Text = "File Report"
            Me.PrintStatus = Nothing
            Me.FileStatus = Nothing
            frmEReport.btnUpdate.Visible = False
            frmEReport.BtnSave.Visible = True
        ElseIf (e.Control AndAlso e.KeyValue = Keys.F5) Then
            frmConnection.Show()
            Me.Hide()
        End If
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Enabled = False
    End Sub
    Private Sub btnPrintPreview_Click_1(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        LoadingOfficersToSign(modLoadingData.LoginuserID)
        If modLoadingData.OfficersToSign = Nothing Then
            frmEReport.TopMost = False
            MsgBox("Please Insert Your Signatory " & vbNewLine & " Go to Account Settings > Signatory", TopMost = True)
        Else
            LoadingExpenseCount(modLoadingData.ReportIDExport)
            If modLoadingData.ReportIDExport = Nothing Then
                MsgBox("No Report Selected")
                ' LoadingExpenseCount(Me.ReportID)
            ElseIf modLoadingData.ExpenseCount = Nothing Or modLoadingData.ExpenseCount = "" Then
                frmEReport.TopMost = False
                MsgBox("No Expense Data to Load", TopMost = True)
            Else
                If ReportStatus = "For Approval" Then
                    frmRpt.btnSendPrint.Enabled = True
                End If
                frmRpt.MyUserID = modLoadingData.LoginuserID
                frmRpt.reportID = modLoadingData.ReportIDExport
                frmRpt.Show()
            End If
        End If
    End Sub
    Private Sub btnFileReport_Click_1(sender As Object, e As EventArgs) Handles btnFileReport.Click
        LoadingOfficersToSign(modLoadingData.LoginuserID)
        LoadingExpenseCount(modLoadingData.ReportIDExport)
        If modLoadingData.OfficersToSign = Nothing Then
            frmEReport.TopMost = False
            MsgBox("Please Insert Your Signatory " & vbNewLine & " Go to Account Settings > Signatory", TopMost = True)
        ElseIf modLoadingData.ExpenseCount = Nothing Or modLoadingData.ExpenseCount = "" Then
            frmEReport.TopMost = False
            MsgBox("No Expense Data to File", TopMost = True)
        ElseIf Me.PrintStatus = 0 Then
            Dim y As MsgBoxResult
            y = MessageBox.Show("Are you sure you want to Update your Expense Report?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If y = MsgBoxResult.Yes Then
                UpdatePrintStatus()
                DeleteImage(modLoadingData.LoginuserID, modLoadingData.ReportIDExport)
                frmRpt.cryptRptER.ShowPrintButton = False
                frmRpt.cryptRptER.ShowExportButton = False
                LoadingER()
                frmEReport.Close()
                btnPrintPreview.Enabled = False
                btnFileReport.Enabled = False
                ToolStripButton1.Enabled = True
                btnReportData.Enabled = True
            Else
                Exit Sub
            End If
        Else
            If modLoadingData.ReportIDExport = Nothing Then
                MsgBox("No Report Selected")
            Else
                Dim y As MsgBoxResult
                y = MessageBox.Show("Are you sure you want to File your Expense Report?" + vbNewLine + "You can not update the expense once you file", "File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If y = MsgBoxResult.Yes Then
                    RefileER(modLoadingData.ReportIDExport, "1")
                    frmEReport.Close()
                    frmEReport.TopMost = False
                    LoadingER()
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub btnReportData_Click_1(sender As Object, e As EventArgs) Handles btnReportData.Click
        'DgvReportDetails.SendToBack()
        frmEReport.Show()
        frmEReport.TopMost = True
        frmEReport.TabPage2.Dispose()
        'frmEReport.TopMost = True
        Me.btnFileReport.Enabled = False
        Me.btnPrintPreview.Enabled = False
        DgvReportDetails.Enabled = False
        MenuStrip1.Enabled = False
        frmEReport.StartPosition = FormStartPosition.Manual
        frmEReport.Location = New Point(300, 157)
        frmEReport.Width = 350
    End Sub
    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DgvReportDetails.Visible = True
        DgvReportDetails.BringToFront()
        LoadingER()
        detect.Text = 1
        ToolStripButton1.Enabled = False
        ToolStripButton2.Enabled = False
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmLogin.txtUsername.Clear()
        frmLogin.txtPassword.Clear()
        Logout()
        LogoutdupAcc()
        Me.btnReportData.Enabled = False
        Me.btnPrintPreview.Enabled = False
        Me.btnReportData.Enabled = True
        Me.ToolStripButton1.Enabled = True
        Me.ToolStripButton2.Enabled = True
        modLoadingData.ReportIDExport = Nothing
        Me.btnFileReport.Enabled = False
        Me.btnFileReport.Text = "File Report"

    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim x As String
        x = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If x = DialogResult.Yes Then
            Me.Close()
        Else
        End If
    End Sub
    Private Sub ToolStripButton1_DoubleClick(sender As Object, e As EventArgs) Handles ToolStripButton1.DoubleClick
        DgvReportDetails.Visible = False
    End Sub
    Private Sub ChangePasswordToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem1.Click
        frmChangePassword.Show()
    End Sub
    Private Sub SignatoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignatoryToolStripMenuItem.Click
        frmDeptSignature.Show()
        Me.TopMost = False
        frmDeptSignature.TopMost = True
    End Sub
    Private Sub UserAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserAccountToolStripMenuItem.Click
        Try
            LoadingUserAccountFiled(modLoadingData.LoginDeptID)
            frmUserRegistration.Show()
            frmUserRegistration.TopMost = True
            frmUserRegistration.dgvUserAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            frmUserRegistration.dgvUserAccount.Columns("Signature").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("EmailBCC").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("DeptID").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("Email Address").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("EmailPass").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("Password").Visible = False
            frmUserRegistration.dgvUserAccount.Columns("Number of file").Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles tsmiPrev.Click
        frmPreviousER.ShowDialog()
        frmPreviousER.TopMost = True
        Me.TopMost = False
    End Sub
    Private Sub AboutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("On-Going")
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim dt As New DataTable
        Dim sqlcmdLoadLogin As New SqlClient.SqlCommand
        With sqlcmdLoadLogin
            .Connection = SQLConnection
            .CommandText = "select a.[Status],a.UserID from tbUserRegistration as a where UserID ='" & modLoadingData.LoginuserID & "'"
            .CommandType = CommandType.Text
            dt.Load(.ExecuteReader)
            If dt.Rows.Count <> 0 Then
                loginStatus = dt.Rows(0).Item("Status")
            End If
            If loginStatus = "0" Then
                frmLogin.txtUsername.Clear()
                frmLogin.txtPassword.Clear()
                Logout()
                LogoutdupAcc()
            End If
        End With
    End Sub
    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        frmHelp.Show()
        frmHelp.TopMost = True
        Me.TopMost = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        frmReturnedER.Show()
    End Sub
    Private Sub DgvReportDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvReportDetails.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.btnReportData.Enabled = False
            Me.btnPrintPreview.Enabled = False
            Me.btnReportData.Enabled = True
            Me.ToolStripButton1.Enabled = True
            Me.ToolStripButton2.Enabled = True
            modLoadingData.ReportIDExport = Nothing
            Me.btnFileReport.Enabled = False
            Me.btnFileReport.Text = "File Report"
        End If
    End Sub
    Private Sub FToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuExpenseDetails.Click
        frmExpenseDetails.ShowDialog()
        frmExpenseDetails.TopMost = True
        Me.TopMost = False
    End Sub
    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles fmsExpenseSummary.Click
        frmExpenseSummary.ShowDialog()
    End Sub

    Private Sub DgvReportDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvReportDetails.CellContentClick

    End Sub

    Private Sub DgvReportDetails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvReportDetails.CellDoubleClick

    End Sub
End Class
