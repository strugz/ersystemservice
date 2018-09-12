Public Class frmEReport
    Dim dtLoadReport As New DataTable
    Dim transactionID As String
    Public SDateReport As String
    Public EdateReport As String
    Public Description As String
    Public perdiem As String
    Public CashCheck As String
    Dim dtSort As New DataTable
    Dim Check As String
    Dim SortNumber As Integer
#Region "Sorting"
    Enum mode
        top = 0
        up = 1
        down = 2
        bottom = 3
    End Enum

    Private Sub swapRows(ByVal range As mode)
        Dim iSelectedRow As Integer = -1
        For iTmp As Integer = 0 To dgvExpense.Rows.Count - 1
            If dgvExpense.Rows(iTmp).Selected Then
                iSelectedRow = iTmp
                Exit For
            End If
        Next
        If iSelectedRow <> -1 Then
            Dim sTmp(18) As String
            For iTmp As Integer = 0 To dgvExpense.Columns.Count - 1
                sTmp(iTmp) = dgvExpense.Rows(iSelectedRow).Cells(iTmp).Value.ToString
            Next
            Dim iNewRow As Integer
            If range = mode.down Then
                iNewRow = iSelectedRow + 1
            ElseIf range = mode.up Then
                iNewRow = iSelectedRow - 1
            End If
            If range = mode.up Or range = mode.down Then
                For iTmp As Integer = 0 To dgvExpense.Columns.Count - 1
                    dgvExpense.Rows(iSelectedRow).Cells(iTmp).Value = dgvExpense.Rows(iNewRow).Cells(iTmp).Value
                    dgvExpense.Rows(iNewRow).Cells(iTmp).Value = sTmp(iTmp)
                Next
                toSelect(iNewRow)
            ElseIf range = mode.top Or range = mode.bottom Then
                reshuffleRows(sTmp, iSelectedRow, range)
            End If
        End If
    End Sub
    Private Sub toSelect(ByVal iNewRow As Integer)
        dgvExpense.Rows(iNewRow).Selected = True
    End Sub
    Private Sub reshuffleRows(ByVal sTmp() As String, ByVal iSelectedRow As Integer, ByVal Range As mode)
        If Range = mode.top Then
            Dim iFirstRow As Integer = 0
            If iSelectedRow > iFirstRow Then
                For iTmp As Integer = iSelectedRow To 1 Step -1
                    For iCol As Integer = 0 To dgvExpense.Columns.Count - 1
                        dgvExpense.Rows(iTmp).Cells(iCol).Value = dgvExpense.Rows(iTmp - 1).Cells(iCol).Value
                    Next
                Next
                For iCol As Integer = 0 To dgvExpense.Columns.Count - 1
                    dgvExpense.Rows(iFirstRow).Cells(iCol).Value = sTmp(iCol).ToString
                Next
                toSelect(iFirstRow)
            End If
        Else
            Dim iLastRow As Integer = dgvExpense.Rows.Count - 1
            If iSelectedRow < iLastRow Then
                For iTmp As Integer = iSelectedRow To iLastRow - 1
                    For iCol As Integer = 0 To dgvExpense.Columns.Count - 1
                        dgvExpense.Rows(iTmp).Cells(iCol).Value = dgvExpense.Rows(iTmp + 1).Cells(iCol).Value
                    Next
                Next
                For iCol As Integer = 0 To dgvExpense.Columns.Count - 1
                    dgvExpense.Rows(iLastRow).Cells(iCol).Value = sTmp(iCol).ToString
                Next
                toSelect(iLastRow)
            End If
        End If
    End Sub
#End Region
    Public Sub AutoSizegrid()
        dgvExpense.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvExpense.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clearData()
        CbCashAdvanceReceive.Checked = False
        btnUpdate.Visible = False
        BtnSave.Visible = True
        Me.Close()
    End Sub
    Private Sub clearData()
        txtAmount.Clear()
        txtPofExpense.Clear()
        txtRefDoc.Clear()
        txtRefNum.Clear()
        txtRevFund.Clear()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Trim(LTrim(RTrim(txtPofExpense.Text)) = "") Then
            MsgBox("Please Fill All Fields")
        Else
            If CbCashAdvanceReceive.Checked = False Or txtAmount.Text = Nothing Then
                AddReport(DtpReportFrom.Text, DtpReportTo.Text, txtPofExpense.Text, "0", "", txtRefDoc.Text, txtRefNum.Text,
                          "Employee", txtRevFund.Text, IIf(CbCashAdvanceReceive.Checked, "1", "0"), modLoadingData.LoginuserID, "", "NOT APPROVED", Date.Now.ToString("yyyy-MM-dd"), "")
                MsgBox("Add Successfully")
                frmMain.LoadingER()
                frmMain.DgvReportDetails.Visible = True
                frmMain.DgvReportDetails.BringToFront()
                Me.Close()
            ElseIf modLoadingData.LoginUserLevel = "Admin" Then
                AddReport(DtpReportFrom.Text, DtpReportTo.Text, txtPofExpense.Text, txtAmount.Text, DtpReportDate.Value.ToString("MM-dd-yyyy"), txtRefDoc.Text, txtRefNum.Text, "Employee", txtRevFund.Text, IIf(CbCashAdvanceReceive.Checked, "1", "0"), modLoadingData.LoginuserID, "", "APPROVED", Date.Now.ToString("yyyy-MM-dd"), "0")
                MsgBox("Add Successfully")
                frmMain.LoadingER()
                frmMain.DgvReportDetails.Visible = True
                frmMain.DgvReportDetails.BringToFront()
                Me.Close()
            ElseIf modLoadingData.LoginUserLevel = "Admin" And (CbCashAdvanceReceive.Checked = False Or txtAmount.Text = Nothing) Then
                AddReport(DtpReportFrom.Text, DtpReportTo.Text, txtPofExpense.Text, txtAmount.Text, "", txtRefDoc.Text, txtRefNum.Text, "Employee", txtRevFund.Text, IIf(CbCashAdvanceReceive.Checked, "1", "0"), modLoadingData.LoginuserID, "", "APPROVED", Date.Now.ToString("yyyy-MM-dd"), "0")
                MsgBox("Add Successfully")
                frmMain.LoadingER()
                frmMain.DgvReportDetails.Visible = True
                frmMain.DgvReportDetails.BringToFront()
                Me.Close()
            Else
                AddReport(DtpReportFrom.Text, DtpReportTo.Text, txtPofExpense.Text, txtAmount.Text, DtpReportDate.Value.ToString("MM-dd-yyyy"), txtRefDoc.Text, txtRefNum.Text, "Employee", txtRevFund.Text, IIf(CbCashAdvanceReceive.Checked, "1", "0"), modLoadingData.LoginuserID, "", "NOT APPROVED", Date.Now.ToString("yyyy-MM-dd"), "")
                MsgBox("Add Successfully")
                frmMain.LoadingER()
                frmMain.DgvReportDetails.Visible = True
                frmMain.DgvReportDetails.BringToFront()
                Me.Close()
            End If
            'LoadingDataReport(UserID, "01/01/1990", "12/01/2200")
            ' AutoSizegrid()
        End If
    End Sub
    Private Sub frmEReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMain.btnReportData.Enabled = False
        frmMain.btnPrintPreview.Enabled = False
        frmMain.btnReportData.Enabled = True
        frmMain.ToolStripButton1.Enabled = True
        frmMain.ToolStripButton2.Enabled = True
        modLoadingData.ReportIDExport = Nothing
        frmMain.btnFileReport.Enabled = False
        frmMain.btnFileReport.Text = "File Report"
        'frmMain.TopMost = True
        'Me.TopMost = False
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "1")
        frmMain.DgvReportDetails.Enabled = True
        frmMain.MenuStrip1.Enabled = True
    End Sub

    Private Sub frmEReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            clearExpenseData()
            btnExpenseUpdate.Visible = False
            btnExpenseSave.Visible = True
        End If
    End Sub
    Private Sub frmEReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClient()
        If modLoadingData.LoginUserLevel = "Admin" Then
            btnUpdate.Enabled = False
            'Me.TopMost = False
            txtPofExpense.Text = Description
            DtpReportFrom.Value = modLoadingData.sDate
            DtpReportTo.Value = modLoadingData.eDate
            txtStatus.SelectedIndex = 0
            frmMain.btnFileReport.Enabled = True
            modLoadingData.ExpenseCount = Nothing
            frmMain.btnFileReport.Text = "Update Report"
            frmMain.ToolTip1.SetToolTip(frmMain.btnFileReport, "Update Report")
            frmMain.ToolStripButton1.Enabled = False
            frmMain.ToolStripButton2.Enabled = False
            frmMain.btnPrintPreview.Enabled = True
        Else
            If frmMain.PrintStatus = 0 And frmMain.FileStatus = "0" Then
                '  TabControl1.TabPages.Remove(TabPage2)
                btnUpdate.Enabled = False
                txtPofExpense.Text = Description
                DtpReportFrom.Value = modLoadingData.sDate
                DtpReportTo.Value = modLoadingData.eDate
                'DtpReportFrom.Text = SDateReport
                'DtpReportTo.Text = EdateReport
                txtStatus.SelectedIndex = 0
                frmMain.btnFileReport.Enabled = True
                modLoadingData.ExpenseCount = Nothing
                frmMain.btnFileReport.Text = "Update Report"
                frmMain.ToolTip1.SetToolTip(frmMain.btnFileReport, "Update Report")
                frmMain.ToolStripButton1.Enabled = False
                frmMain.ToolStripButton2.Enabled = False
            ElseIf frmMain.FileStatus = "1" And frmMain.PrintStatus = 1 Then
                DtpReportFrom.Value = modLoadingData.sDate
                DtpReportTo.Value = modLoadingData.eDate
                ' TabControl1.TabPages.Remove(TabPage2)
                frmMain.btnFileReport.Enabled = False
                txtPofExpense.Text = Description
                'DtpReportFrom.Text = SDateReport
                'DtpReportTo.Text = EdateReport
                txtStatus.SelectedIndex = 0
                modLoadingData.ExpenseCount = Nothing
                frmMain.btnFileReport.Text = "Already Filed"
                frmMain.ToolTip1.SetToolTip(frmMain.btnFileReport, "Already Filed")
                btnUpdate.Enabled = False
                frmMain.ToolStripButton1.Enabled = False
                frmMain.ToolStripButton2.Enabled = False
            Else
                txtPofExpense.Text = Description
                btnUpdate.Enabled = True
                txtStatus.SelectedIndex = 0
                frmMain.btnFileReport.Enabled = True
                modLoadingData.ExpenseCount = Nothing
                frmMain.btnFileReport.Text = "File Report"
                frmMain.ToolTip1.SetToolTip(frmMain.btnFileReport, "File Report")
                frmMain.ToolStripButton1.Enabled = False
                frmMain.ToolStripButton2.Enabled = False
                TabControl1.SelectedTab = TabPage2
            End If
        End If
    End Sub

    Private Sub CbCashAdvanceReceive_CheckedChanged(sender As Object, e As EventArgs) Handles CbCashAdvanceReceive.CheckedChanged
        If CbCashAdvanceReceive.Checked = True Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
            txtAmount.Clear()
            txtRefDoc.Clear()
            txtRefNum.Clear()
            txtRemarks.Clear()
            txtRevFund.Clear()
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Me.Width = 1055
            LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
            Button6.Visible = True
            Button7.Visible = True
            dgvExpense.Visible = True
            AutoSizegrid()
            dgvExpense.Columns("sort").Visible = False
            dgvExpense.Columns("ID").Visible = False
            dgvExpense.Columns("ExpensePerdiem").Visible = False
            dgvExpense.Columns("ExpenseAmount").Visible = False
            dgvExpense.Columns("ExpenseMultiplier").Visible = False
            dgvExpense.Columns("ExpenseInvoice").Visible = False
            dgvExpense.Columns("ExpenseStatus").Visible = False
            dgvExpense.Columns("ExpenseRemarks").Visible = False
            dgvExpense.Columns("ServiceNumber").Visible = False
            dgvExpense.Columns("Type").Visible = False
            dgvExpense.Columns("WorkWith").Visible = False
            dgvExpense.Columns("Total Amount").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvExpense.Columns("Location").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Else
            dgvExpense.Visible = False
            Me.Width = 350
            Button6.Visible = False
            Button7.Visible = False
            Me.TabControl1.Anchor = AnchorStyles.Right
            Me.TabControl1.Anchor = AnchorStyles.Left
        End If
    End Sub

    Private Sub dgvExpense_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpense.CellClick
        Try
            SortNumber = dgvExpense.Rows(e.RowIndex).Cells("Sort").Value
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpense.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                MsgBox("Please Double click on the row you are interested in")
                Exit Sub
            Else
                perdiem = dgvExpense.Rows(e.RowIndex).Cells("ExpensePerdiem").Value
                transactionID = dgvExpense.Rows(e.RowIndex).Cells("ID").Value
                txtLocation.Text = dgvExpense.Rows(e.RowIndex).Cells("Location").Value
                txtExpenseAmount.Text = dgvExpense.Rows(e.RowIndex).Cells("ExpenseAmount").Value
                txtMultiplier.Text = dgvExpense.Rows(e.RowIndex).Cells("ExpenseMultiplier").Value
                txtInvoice.Text = dgvExpense.Rows(e.RowIndex).Cells("ExpenseInvoice").Value
                txtStatus.Text = dgvExpense.Rows(e.RowIndex).Cells("ExpenseStatus").Value
                txtRemarks.Text = dgvExpense.Rows(e.RowIndex).Cells("ExpenseRemarks").Value
                txtCategory.Text = dgvExpense.Rows(e.RowIndex).Cells("Category").Value
                txtParticulars.Text = dgvExpense.Rows(e.RowIndex).Cells("Particulars").Value
                dtpExpenseDate.Text = dgvExpense.Rows(e.RowIndex).Cells("Date").Value
                txtType.Text = dgvExpense.Rows(e.RowIndex).Cells("Type").Value
                txtTotal.Text = Val(txtExpenseAmount.Text) * Val(txtMultiplier.Text)
                txtServiceNumber.Text = dgvExpense.Rows(e.RowIndex).Cells("ServiceNumber").Value
                txtInstrument.Text = IIf(IsDBNull(dgvExpense.Rows(e.RowIndex).Cells("Instrument").Value), "", dgvExpense.Rows(e.RowIndex).Cells("Instrument").Value)
                txtSerialNumber.Text = IIf(IsDBNull(dgvExpense.Rows(e.RowIndex).Cells("Serial Number").Value), "", dgvExpense.Rows(e.RowIndex).Cells("Serial Number").Value)
                modLoadingData.WorkWith = dgvExpense.Rows(e.RowIndex).Cells("WorkWith").Value
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btnExpenseSave.Visible = False
        btnExpenseUpdate.Visible = True
        If perdiem = "0" Or perdiem = "" Then
            CBPerdiem.Checked = False
        Else
            CBPerdiem.Checked = True
        End If
    End Sub
    Private Sub txtExpenseAmount_KeyUp(sender As Object, e As KeyEventArgs) Handles txtExpenseAmount.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtMultiplier.Focus()
        End If
    End Sub
    Private Sub txtExpenseAmount_TextChanged(sender As Object, e As EventArgs) Handles txtExpenseAmount.TextChanged
        txtTotal.Text = Val(txtExpenseAmount.Text) * Val(txtMultiplier.Text)
    End Sub
    Private Sub txtMultiplier_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMultiplier.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtInvoice.Focus()
        End If
    End Sub
    Private Sub txtMultiplier_TextChanged(sender As Object, e As EventArgs) Handles txtMultiplier.TextChanged
        txtTotal.Text = Math.Round(Val(txtExpenseAmount.Text) * Val(txtMultiplier.Text))
    End Sub
    Private Sub btnExpenseSave_Click(sender As Object, e As EventArgs) Handles btnExpenseSave.Click
        Dim str As String
        str = LoadSearchClient(Trim(txtLocation.Text))
        If txtParticulars.Text = Nothing Or txtExpenseAmount.Text = Nothing Then
            MsgBox("Please fill in the Particulars/Expense Amount")
        ElseIf txtType.SelectedItem = Nothing Then
            MsgBox("Please Select Type")
        ElseIf txtCategory.SelectedItem = Nothing Then
            MsgBox("Please Select Category")
        Else
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "") = "0" Then
                If str = "" Or str = 0 Then
                    AddExpenseReport()
                    AddClient(Trim(txtLocation.Text))
                    MsgBox("Add Successfully")
                    clearExpenseData()
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    LoadClient()
                Else
                    AddExpenseReport()
                    MsgBox("Add Successfully")
                    clearExpenseData()
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                End If
            Else
                If str = "" Or str = 0 Then
                    frmAdditionalInput.ShowDialog()
                    frmAdditionalInput.TopMost = True
                    AddExpenseReport()
                    AddClient(Trim(txtLocation.Text))
                    MsgBox("Add Successfully")
                    clearExpenseData()
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    LoadClient()
                Else
                    frmAdditionalInput.ShowDialog()
                    frmAdditionalInput.TopMost = True
                    AddExpenseReport()
                    MsgBox("Add Successfully")
                    clearExpenseData()
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                End If
            End If
        End If
    End Sub
    Private Sub AddExpenseReport()
        AddExpense(dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(Trim(txtLocation.Text)) = "", "Allowance", Trim(Trim(Trim(txtLocation.Text)))), modLoadingData.LoginuserID, modLoadingData.ReportIDExport, IIf(txtServiceNumber.Text = "", "N/A", txtServiceNumber.Text), IIf(txtInstrument.Text = "", "N/A", txtInstrument.Text), IIf(txtSerialNumber.Text = "", "N/A", txtSerialNumber.Text))
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearExpenseData()
        btnExpenseUpdate.Visible = False
        btnExpenseSave.Visible = True
    End Sub
    Private Sub clearExpenseData()
        txtParticulars.Clear()
        txtType.SelectedItem = Nothing
        txtCategory.SelectedItem = Nothing
        txtExpenseAmount.Clear()
        txtMultiplier.Text = "1"
        txtTotal.Text = ""
        txtInvoice.Clear()
        txtRemarks.Clear()
        CBPerdiem.Checked = False
        btnExpenseUpdate.Visible = False
        btnExpenseSave.Visible = True
        txtServiceNumber.Clear()
        txtInstrument.Clear()
        txtSerialNumber.Clear()
    End Sub
    Private Sub btnExpenseUpdate_Click(sender As Object, e As EventArgs) Handles btnExpenseUpdate.Click
        Dim str As String
        str = LoadSearchClient(Trim(txtLocation.Text))
        If txtParticulars.Text = Nothing Or txtExpenseAmount.Text = Nothing Then
            MsgBox("Check Inputs!")
        Else
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "") = "0" Then
                If str = "" Or str = 0 Then
                    UpdateExpense(transactionID, dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(Trim(txtLocation.Text)) = "", "Allowance", Trim(Trim(txtLocation.Text))), modLoadingData.LoginuserID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    AddClient(Trim(txtLocation.Text))
                    AddExpenseHisto(dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, modLoadingData.ReportIDExport, transactionID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    LoadClient()
                    MsgBox("Update Successfully")
                    clearExpenseData()
                Else
                    UpdateExpense(transactionID, dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    AddExpenseHisto(dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, modLoadingData.ReportIDExport, transactionID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    MsgBox("Update Successfully")
                    clearExpenseData()
                End If
            Else
                If str = "" Or str = 0 Then
                    frmAdditionalInput.ShowDialog()
                    frmAdditionalInput.TopMost = True
                    UpdateExpense(transactionID, dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    AddClient(Trim(txtLocation.Text))
                    AddExpenseHisto(dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, modLoadingData.ReportIDExport, transactionID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    LoadClient()
                    MsgBox("Update Successfully")
                    clearExpenseData()
                Else
                    frmAdditionalInput.ShowDialog()
                    frmAdditionalInput.TopMost = True
                    UpdateExpense(transactionID, dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    AddExpenseHisto(dtpExpenseDate.Text, IIf(CBPerdiem.Checked, "1", "0"), txtParticulars.Text, txtInvoice.Text, txtMultiplier.Text, txtType.Text, txtCategory.Text, txtExpenseAmount.Text, txtRemarks.Text, txtStatus.Text, txtTotal.Text, IIf(Trim(txtLocation.Text) = "", "Allowance", Trim(txtLocation.Text)), modLoadingData.LoginuserID, modLoadingData.ReportIDExport, transactionID, txtServiceNumber.Text, txtInstrument.Text, txtSerialNumber.Text)
                    LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
                    MsgBox("Update Successfully")
                    clearExpenseData()
                End If
            End If
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateReport(modLoadingData.ReportIDExport, DtpReportFrom.Text, DtpReportTo.Text, txtPofExpense.Text, txtAmount.Text, DtpReportDate.Text, txtRefDoc.Text, txtRefNum.Text, txtRevFund.Text, IIf(CbCashAdvanceReceive.Checked, "1", "0"))
        LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
        MsgBox("Update Successfully")
        frmMain.LoadingER()
        Me.Close()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LoadingExpenseCount(modLoadingData.ReportIDExport)
        If modLoadingData.ExpenseCount = Nothing Or modLoadingData.ExpenseCount = "" Then
        Else
            If dgvExpense.Rows(0).Selected = True Then
            Else
                Try
                    swapRows(mode.up)
                    Sorting()
                Catch ex As Exception
                End Try
                SortNumber = Val(SortNumber - 1)
                dgvExpense.ClearSelection()
                dgvExpense.Rows(SortNumber).Selected = True
            End If
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        LoadingExpenseCount(modLoadingData.ReportIDExport)
        If modLoadingData.ExpenseCount = Nothing Or modLoadingData.ExpenseCount = "" Then
        Else
            Dim drows As Integer
            drows = dgvExpense.Rows.Count - 1
            If dgvExpense.Rows(drows).Selected = True Then

            Else
                Try
                    swapRows(mode.down)
                    Sorting()
                Catch ex As Exception

                End Try
                SortNumber = Val(SortNumber + 1)
                dgvExpense.ClearSelection()
                dgvExpense.Rows(SortNumber).Selected = True
            End If
        End If
    End Sub
    Private Sub Sorting()
        Try
            Dim sqlSaveSort As New SqlClient.SqlCommand
            Dim a As Integer
            With sqlSaveSort
                .Connection = SQLConnection
                For a = 0 To dgvExpense.Rows.Count - 1
                    .CommandText = "update tbExpenseDetails set Sort ='" & a & "' where ID='" & dgvExpense.Rows(a).Cells(0).Value & "'"
                    .CommandType = CommandType.Text
                    .ExecuteNonQuery()
                Next
                LoadingExpenseReport(modLoadingData.ReportIDExport, modLoadingData.LoginuserID, SDateReport, EdateReport)
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CBPerdiem_CheckedChanged(sender As Object, e As EventArgs) Handles CBPerdiem.CheckedChanged
        If CBPerdiem.Checked = True Then
            txtLocation.Enabled = False
            txtLocation.Text = "Allowance"
            txtInstrument.Enabled = False
            txtInstrument.Text = "N/A"
            txtSerialNumber.Enabled = False
            txtSerialNumber.Text = "N/A"
            txtServiceNumber.Enabled = False
            txtServiceNumber.Text = "N/A"
        Else
            txtLocation.Enabled = True
            txtLocation.SelectedItem = 0
            txtInstrument.Enabled = True
            txtInstrument.Clear()
            txtSerialNumber.Enabled = True
            txtSerialNumber.Clear()
            txtServiceNumber.Enabled = True
            txtServiceNumber.Clear()
        End If
    End Sub
    Private Sub txtInstrument_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInstrument.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtSerialNumber.Focus()
        End If
    End Sub
    Private Sub txtSerialNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSerialNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtServiceNumber.Focus()
        End If
    End Sub
    Private Sub txtParticulars_KeyUp(sender As Object, e As KeyEventArgs) Handles txtParticulars.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtType.Focus()
        End If
    End Sub
    Private Sub txtParticulars_LostFocus(sender As Object, e As EventArgs) Handles txtParticulars.LostFocus
        If txtParticulars.Text Like "*MEAL*" Then
            txtCategory.SelectedIndex = 1
        ElseIf txtParticulars.Text Like "*TRANS*" Then
            txtCategory.SelectedIndex = 0
        Else
            txtCategory.SelectedIndex = 2
        End If
    End Sub
    Private Sub txtType_KeyUp(sender As Object, e As KeyEventArgs) Handles txtType.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtCategory.Focus()
        End If
    End Sub
    Private Sub txtCategory_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCategory.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtExpenseAmount.Focus()
        End If
    End Sub
    Private Sub txtServiceNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtServiceNumber.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtParticulars.Focus()
        End If
    End Sub
    Private Sub txtInvoice_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInvoice.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub
    Private Sub txtLocation_KeyUp1(sender As Object, e As KeyEventArgs) Handles txtLocation.KeyUp
        If e.KeyCode = Keys.Enter Then
            txtInstrument.Focus()
        End If
    End Sub
    Private Sub btnInstrumentHistory_Click(sender As Object, e As EventArgs) Handles btnInstrumentHistory.Click
        History.Show()
        History.BringToFront()
    End Sub
End Class