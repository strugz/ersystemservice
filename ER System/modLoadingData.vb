Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Microsoft.Win32
Module modLoadingData
    Public DateFrom As String
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Dim sqlLoadExpense As New SqlCommand
    Dim sqlLoaddata As New SqlCommand
    Dim sqlLoadUserAccount As New SqlCommand

    Dim sqlLoadDepartment As New SqlCommand
    Dim sqlLoadDepartmentManager As New SqlCommand
    Public LoadEndorse, LoadReview, LoadApprove, DeptID As String
    Dim dtLoadUserAccByDept As New DataTable
    Dim sqlcmdLoadUserAccByDept As New SqlCommand
    Dim sqlLoadUserAccEmail As New SqlCommand
    Dim sqlcmdLoadReturnedER As New SqlCommand
    Public EmailAdd As String
    Public EmailPass As String
    Public EmailTo As String
    Public EmailBCC As String
    Public dtLoadDupUser As New DataTable
    Public sqlcmdLoadDupUser As New SqlCommand
    Dim dtLoadExpenseCount As New DataTable
    Dim sqlcmdLoadExpenseCount As New SqlCommand
    Public ExpenseCount As String
    Dim dtLoadOfficersToSign As New DataTable
    Dim sqlcmdLoadOfficersToSign As New SqlCommand
    Public OfficersToSign As String
    Dim dtLoadreportID As New DataTable
    Dim sqlcmdLoadreportID As New SqlCommand
    Public ReportID As String
    Dim dtLoadUserID As New DataTable
    Dim sqlcmdLoadUserID As New SqlCommand
    Public DuplicateUserID As String
    Dim dtLoginUser As New DataTable
    Dim sqlcmdLoginUser As New SqlCommand
    Public LoginuserID As String = Nothing
    Public LoginUsername As String = Nothing
    Public LoginUserLevel As String = Nothing
    Public LoginDeptID As String = Nothing
    Public LoginPassword As String = Nothing
    Public LoginFullname As String = Nothing
    Public LoginDepartment As String = Nothing
    Public sDate As Date = Now.Date
    Public eDate As Date = Now.Date
    Public ReportIDExport As String
    Public ReportNumberStatus As String
    Public RBT As String
    Public LocationCode As String
    Public LocationName As String
    Public MaxUserID As String
    Public ChangeLoad As String
    Public SignedID As String
    Public ExpenseSummaryDateFrom As String
    Public ExpenseSummaryDateTo As String
    Public ReportPrintStatus As String
    Public WorkWith As String
    Public Sub LoadDuplicateUser(ByVal username As String)
        Try
            With sqlcmdLoadDupUser
                .Connection = SQLConnection
                .CommandText = "sp2_LoadDuplicateUser"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                dtLoadDupUser.Reset()
                .Parameters.Add("@username", SqlDbType.VarChar).Value = username
                dtLoadDupUser.Load(.ExecuteReader)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadReturnedER(ByVal userID As String, ByVal dtLoadReturnedER As DataTable)
        Try
            With sqlcmdLoadReturnedER
                .Connection = SQLConnection
                .CommandText = "Select a.ReportDateFrom as [Date From],a.ReportDateTo as [Date To],a.ReportDescription as [Description],a.ReportReturnedForModi as [Need to Modify] from tbReportDetails as a where a.ReportPrintStatus = '1' and a.ReportFileStatus = '0' and a.UserID ='" & userID & "'"
                .CommandType = CommandType.Text
                dtLoadReturnedER.Load(.ExecuteReader)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadDuplicateUserID(ByVal userid As String)
        Try
            With sqlcmdLoadUserID
                .Connection = SQLConnection
                .CommandText = "sp2_LoadDuplicateUserID"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                dtLoadUserID.Reset()
                .Parameters.Add("@userid", SqlDbType.VarChar).Value = userid
                dtLoadUserID.Load(.ExecuteReader)
                If dtLoadUserID.Rows.Count <> 0 Then
                    DuplicateUserID = dtLoadUserID.Rows(0).Item("UserID")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingDataReport(ByVal userID As String, ByVal sDate As String, ByVal eDate As String)
        Try
            Dim dtLoadingER As New DataTable
            With sqlLoaddata
                .Connection = SQLConnection
                .Parameters.Clear()
                dtLoadingER.Reset()
                .CommandText = "sp2_LoadDataReport '" & userID & "','" & sDate & "','" & eDate & "'"
                .Parameters.Add("@userID", SqlDbType.VarChar).Value = userID
                .Parameters.Add("@sDate", SqlDbType.VarChar).Value = sDate
                .Parameters.Add("@eDate", SqlDbType.VarChar).Value = eDate
                .CommandType = CommandType.Text
                dtLoadingER.Load(.ExecuteReader)
                frmMain.DgvReportDetails.DataSource = dtLoadingER
                frmMain.DgvReportDetails.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                frmMain.DgvReportDetails.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                frmMain.DgvReportDetails.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchDataReport(ByVal userID As String, ByVal sDate As String)
        Try
            Dim dtSearchingER As New DataTable
            Dim sqlSearchData As New SqlCommand
            With sqlSearchData
                .Connection = SQLConnection
                .Parameters.Clear()
                .CommandText = "sp2_SearchDataReport '" & userID & "','" & sDate & "'"
                .CommandType = CommandType.Text
                dtSearchingER.Load(.ExecuteReader)
                frmMain.DgvReportDetails.DataSource = dtSearchingER
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingExpenseReport(ByVal reportID As String, ByVal userID As String, ByVal sdate As String, ByVal edate As String)
        Try
            Dim dt As New DataTable
            With sqlLoadExpense
                .Connection = SQLConnection
                .CommandText = "EXEC sp2_LoadExpense'" & reportID & "','" & userID & "'"
                .CommandType = CommandType.Text
                dt.Load(.ExecuteReader)
                frmEReport.dgvExpense.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingExpenseCount(ByVal reportID As String)
        Try
            ExpenseCount = ""
            With sqlcmdLoadExpenseCount
                .Connection = SQLConnection
                .CommandText = "sp2_LoadingExpenseCount"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                dtLoadExpenseCount.Reset()
                .Parameters.Add("@reportID", SqlDbType.Int).Value = reportID
                dtLoadExpenseCount.Load(.ExecuteReader)
                If dtLoadExpenseCount.Rows.Count <> 0 Then
                    ExpenseCount = dtLoadExpenseCount.Rows(0).Item("ReportID").ToString
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingOfficersToSign(ByVal userid As String)
        Try
            With sqlcmdLoadOfficersToSign
                .Connection = SQLConnection
                .CommandText = "sp2_LoadOfficersToSign"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Clear()
                dtLoadOfficersToSign.Reset()
                .Parameters.Add("@userid", SqlDbType.VarChar).Value = userid
                dtLoadOfficersToSign.Load(.ExecuteReader)
                If dtLoadOfficersToSign.Rows.Count <> 0 Then
                    OfficersToSign = dtLoadOfficersToSign.Rows(0).Item("UserID")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingUserAccountEmail(ByVal userid As String, ByVal deptID As String)
        Try
            Dim dt As New DataTable
            With sqlLoadUserAccEmail
                .Connection = SQLConnection
                .CommandText = "sp2_LoadUserAccEmail"
                .CommandType = CommandType.StoredProcedure
                dt.Reset()
                .Parameters.Clear()
                .Parameters.Add("@userid", SqlDbType.Int).Value = userid
                .Parameters.Add("@deptID", SqlDbType.Int).Value = deptID
                dt.Load(.ExecuteReader)
                If dt.Rows.Count <> 0 Then
                    EmailAdd = dt.Rows(0).Item("EmailAdd")
                    EmailPass = dt.Rows(0).Item("EmailPass")
                    EmailTo = dt.Rows(0).Item("EmailTo")
                    EmailBCC = dt.Rows(0).Item("EmailBCC")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingUserAccountFiled(ByVal deptID As String)
        Dim dt As New DataTable
        Try
            With sqlLoadUserAccount
                .Connection = SQLConnection
                .CommandText = "[sp2_LoadUserAccFiled]"
                .CommandType = CommandType.StoredProcedure
                dt.Reset()
                .Parameters.Clear()
                .Parameters.Add("@DeptID", SqlDbType.Int).Value = deptID
                dt.Load(.ExecuteReader)
                frmApprove.dgvUser.DataSource = dt
                frmUserRegistration.dgvUserAccount.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dt.Dispose()
    End Sub
    Public Sub LoadingUserAccount(ByVal deptID As String)
        Dim dt As New DataTable
        Try
            With sqlLoadUserAccount
                .Connection = SQLConnection
                .CommandText = "[sp2_LoadUserAcc]"
                .CommandType = CommandType.StoredProcedure
                dt.Reset()
                .Parameters.Clear()
                .Parameters.Add("@DeptID", SqlDbType.Int).Value = deptID
                dt.Load(.ExecuteReader)
                frmApprove.dgvUser.DataSource = dt
                frmUserRegistration.dgvUserAccount.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingUserAccountPending(ByVal deptID As String)
        Dim dt As New DataTable
        Try
            With sqlLoadUserAccount
                .Connection = SQLConnection
                .CommandText = "[sp2_LoadUserAccPending]"
                .CommandType = CommandType.StoredProcedure
                dt.Reset()
                .Parameters.Clear()
                .Parameters.Add("@DeptID", SqlDbType.Int).Value = deptID
                dt.Load(.ExecuteReader)
                frmApprove.dgvUser.DataSource = dt
                frmUserRegistration.dgvUserAccount.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dt.Dispose()
    End Sub
    Public Sub LoadUserAccountAdmin()
        Dim dt As New DataTable
        Dim sqlcmdLoad As New SqlCommand
        With sqlcmdLoad
            .Connection = SQLConnection
            .CommandText = "sp2_LoadUserAccountAdmin"
            .CommandType = CommandType.StoredProcedure
            dt.Load(.ExecuteReader)
            If dt.Rows.Count = 0 Then
                frmSelectDept.ShowDialog()
                Exit Sub
            End If
        End With
    End Sub
    Public Sub LoadingUserReportDetailsDONE(ByVal userID As String, ByVal FileStatus As String, ByVal signID As String)
        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim sqlLoadUserReport As New SqlCommand
            With sqlLoadUserReport
                .Connection = SQLConnection
                .CommandText = "[sp2_LoadUserReportDetailsDONE] '" & userID & "', '" & FileStatus & "','" & signID & "'"
                .CommandType = CommandType.Text
                dt.Load(.ExecuteReader)
                frmApprove.dgvUserReportDetails.DataSource = Nothing
                frmApprove.dgvUserReportDetails.DataSource = dt
            End With
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadingUserReportDetailsFILED(ByVal userID As String, ByVal FileStatus As String, ByVal signID As String)
        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim sqlLoadUserReport As New SqlCommand
            With sqlLoadUserReport
                .Connection = SQLConnection
                .CommandText = "[sp2_LoadUserReportDetailsFILED] '" & userID & "', '" & FileStatus & "','" & signID & "'"
                .CommandType = CommandType.Text
                dt.Load(.ExecuteReader)
                frmApprove.dgvUserReportDetails.DataSource = Nothing
                frmApprove.dgvUserReportDetails.DataSource = dt
            End With
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadingDeptSignature(ByVal DeptID As String)
        Try
            Dim dt As New DataTable
            Dim sqlLoadDeptSIgn As New SqlCommand
            With sqlLoadDeptSIgn
                .Connection = SQLConnection
                .CommandText = "Select a.Fullname,a.[Signature] from tbUserRegistration as a where DeptID ='" & DeptID & "'"
                .CommandType = CommandType.Text
                dt.Load(.ExecuteReader)
                frmSignature.DataGridView1.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingUserAccDept(ByVal UserID As String)
        Try
            With sqlcmdLoadUserAccByDept
                .Connection = SQLConnection
                dtLoadUserAccByDept.Reset()
                .CommandText = "[sp2_LoadUserAccountByDept]"
                .Parameters.Clear()
                .Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID
                .CommandType = CommandType.StoredProcedure
                dtLoadUserAccByDept.Load(.ExecuteReader)
                If dtLoadUserAccByDept.Rows.Count <> 0 Then
                    DeptID = dtLoadUserAccByDept.Rows(0).Item("emp_DeptID").ToString
                    LoadEndorse = dtLoadUserAccByDept.Rows(0).Item("emp_Endorser").ToString
                    LoadReview = dtLoadUserAccByDept.Rows(0).Item("emp_Reviewer").ToString
                    LoadApprove = dtLoadUserAccByDept.Rows(0).Item("emp_Approver").ToString
                    frmDeptSignature.btnUpdate.Visible = True
                    frmDeptSignature.btnAdd.Visible = False
                Else
                    MsgBox("No Record Found")
                    frmDeptSignature.btnUpdate.Visible = False
                    frmDeptSignature.btnAdd.Visible = True
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingDepartment()
        Try
            Dim dt As New DataTable
            With sqlLoadDepartment
                .Parameters.Clear()
                .Connection = SQLConnection
                .CommandText = "sp2_LoadDepartment"
                .CommandType = CommandType.StoredProcedure
                dt.Load(.ExecuteReader)
                frmSelectDept.cbbDept.DataSource = dt
                frmSelectDept.cbbDept.ValueMember = "ID"
                frmSelectDept.cbbDept.DisplayMember = "emp_Dept"

                frmUserRegistration.cbDepartment.DataSource = dt
                frmUserRegistration.cbDepartment.ValueMember = "ID"
                frmUserRegistration.cbDepartment.DisplayMember = "emp_Dept"

                frmExpenseDetails.cbbEmployeeDept.DataSource = dt
                frmExpenseDetails.cbbEmployeeDept.DisplayMember = "emp_Dept"
                frmExpenseDetails.cbbEmployeeDept.ValueMember = "ID"

                frmDeptSignature.cbbDept.DataSource = dt
                frmDeptSignature.cbbDept.ValueMember = "ID"
                frmDeptSignature.cbbDept.DisplayMember = "emp_Dept"
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingDepartmentManager(ByVal Dept As String)
        Try
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            With sqlLoadDepartmentManager
                .Connection = SQLConnection
                .Parameters.Clear()
                dt.Reset()
                .CommandText = "sp2_LoadDeparmentManager'" & Dept & "'"
                .CommandType = CommandType.Text
                dt.Load(.ExecuteReader)
                If dt.Rows.Count <> 0 Then
                    LoadEndorse = dt.Rows(0).Item("emp_Endorser")
                    LoadReview = dt.Rows(0).Item("emp_Reviewer")
                    LoadApprove = dt.Rows(0).Item("emp_Approver")
                Else
                    LoadEndorse = Nothing
                    LoadApprove = Nothing
                    LoadReview = Nothing
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadReportID(ByVal reportID As String)
        Try
            With sqlcmdLoadreportID
                .Connection = SQLConnection
                .CommandText = "sp2_LoadreportID"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@reportID", SqlDbType.VarChar).Value = reportID
                dtLoadreportID.Load(.ExecuteReader)
                If dtLoadreportID.Rows.Count <> 0 Then
                    reportID = dtLoadreportID.Rows(0).Item("ReportFileStatus")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoginUserAccount(ByVal Username As String, ByVal Password As String)
        Try
            With sqlcmdLoginUser
                .Connection = SQLConnection
                .CommandText = "sp2_LoginUser"
                dtLoginUser.Reset()
                .Parameters.Clear()
                .Parameters.Add("@username", SqlDbType.VarChar).Value = Username
                .Parameters.Add("@password", SqlDbType.VarChar).Value = Password
                .CommandType = CommandType.StoredProcedure
                .ExecuteNonQuery()
                dtLoginUser.Load(.ExecuteReader)
                If dtLoginUser.Rows.Count <> 0 Then
                    LoginuserID = dtLoginUser.Rows(0).Item("UserID").ToString
                    LoginUsername = dtLoginUser.Rows(0).Item("username")
                    LoginUserLevel = dtLoginUser.Rows(0).Item("Userlevel")
                    LoginDeptID = dtLoginUser.Rows(0).Item("DeptID")
                    LoginPassword = TripleDes.DecryptData(dtLoginUser.Rows(0).Item("Password"))
                    LoginFullname = dtLoginUser.Rows(0).Item("Fullname")
                    LoginDepartment = dtLoginUser.Rows(0).Item("emp_Dept")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dtLoginUser.Dispose()
    End Sub
    Public Sub loadingPreviousER(ByVal userID As String, ByVal sdate As String, ByVal edate As String)
        Try
            Dim dt As New DataTable
            Dim sqlcmdLoadPrevious As New SqlClient.SqlCommand
            With sqlcmdLoadPrevious
                .Connection = conn
                .CommandText = "[sp2_LoadDataReport]"
                .Parameters.Add("@userID", SqlDbType.VarChar).Value = userID
                .Parameters.Add("@sDate", SqlDbType.VarChar).Value = sdate
                .Parameters.Add("@eDate", SqlDbType.VarChar).Value = edate
                .CommandType = CommandType.StoredProcedure
                dt.Load(.ExecuteReader)
                frmPreviousER.DataGridView1.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadingExpenseER(ByVal userID As String, ByVal reportID As String, ByVal sdate As String, ByVal edate As String)
        Try
            Dim dt As New DataTable
            Dim sqlcmdLoadExpenseER As New SqlClient.SqlCommand
            With sqlcmdLoadExpenseER
                .Connection = conn
                .CommandText = "sp_LoadExpense"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@ReportID", SqlDbType.VarChar).Value = reportID
                .Parameters.Add("@userID", SqlDbType.VarChar).Value = userID
                .Parameters.Add("@sDate", SqlDbType.VarChar).Value = sdate
                .Parameters.Add("@eDate", SqlDbType.VarChar).Value = edate
                dt.Load(.ExecuteReader)
                frmPreviousERExpense.DataGridView1.DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadMaxUserID()
        Dim dtLoadMaxUserID As New DataTable
        Dim sqlcmdLoadMaxUserID As New SqlCommand
        With sqlcmdLoadMaxUserID
            .Connection = SQLConnection
            .CommandText = "sp2_LoadUserIDMax"
            .CommandType = CommandType.StoredProcedure
            dtLoadMaxUserID.Load(.ExecuteReader)
            If dtLoadMaxUserID.Rows.Count <> 0 Then
                MaxUserID = dtLoadMaxUserID.Rows(0).Item("User ID")
            End If
        End With
    End Sub
    Public Sub LoadSignatorySigned(ByVal signID As String, ByVal userID As String, ByVal reportID As String)
        Dim dtLoadSignatorySigned As New DataTable
        Dim sqlcmdLoadSignatorySigned As New SqlCommand
        With sqlcmdLoadSignatorySigned
            .Connection = SQLConnection
            .CommandText = "sp2_LoadSignatorySigned"
            .Parameters.Add("@signID", SqlDbType.NVarChar).Value = signID
            .Parameters.Add("@userID", SqlDbType.NVarChar).Value = userID
            .Parameters.Add("@ReportID", SqlDbType.NVarChar).Value = reportID
            .CommandType = CommandType.StoredProcedure
            dtLoadSignatorySigned.Load(.ExecuteReader)
            If dtLoadSignatorySigned.Rows.Count <> 0 Then
                SignedID = dtLoadSignatorySigned.Rows(0).Item("ReportReserveStatus1")
            End If
        End With
    End Sub
    Public Sub LoadExpenseDetails(ByVal Location As String, ByVal DeptID As String)
        Dim dtLoadExpenseDetails As New DataTable
        Dim sqlcmdLoadExpenseDetails As New SqlCommand
        With sqlcmdLoadExpenseDetails
            .Connection = SQLConnection
            .CommandText = "[sp2_LoadExpenceDetails]"
            .Parameters.Add("@Location", SqlDbType.NVarChar).Value = Location
            .Parameters.Add("@DeptID", SqlDbType.NVarChar).Value = DeptID
            .CommandType = CommandType.StoredProcedure
            dtLoadExpenseDetails.Load(.ExecuteReader)
            frmExpenseDetails.dgvViewingExpenseDetails.DataSource = dtLoadExpenseDetails
        End With
    End Sub
    Public Sub LoadClient()
        Dim dtLoadClient As New DataTable
        Dim sqlcmdLoadClient As New SqlCommand
        With sqlcmdLoadClient
            .Connection = SQLConnection
            dtLoadClient.Reset()
            .Parameters.Clear()
            .CommandText = "Select a.ID,a.clientName from tblClient as a order by a.clientName"
            .CommandType = CommandType.Text
            dtLoadClient.Load(.ExecuteReader)
            frmExpenseDetails.cbbClientName.DataSource = dtLoadClient
            frmExpenseDetails.cbbClientName.ValueMember = "ID"
            frmExpenseDetails.cbbClientName.DisplayMember = "clientName"

            frmEReport.txtLocation.DataSource = dtLoadClient
            frmEReport.txtLocation.ValueMember = "ID"
            frmEReport.txtLocation.DisplayMember = "clientName"
        End With
    End Sub
    Public Function LoadSearchClient(ByVal ClientName As String)
        Dim dtLoadSearchClient As New DataTable
        Dim sqlcmdLoadSearchClient As New SqlCommand
        With sqlcmdLoadSearchClient
            .Connection = SQLConnection
            .CommandText = "Select * from tblClient as a where a.clientName = '" & ClientName & "'"
            .CommandType = CommandType.Text
            dtLoadSearchClient.Load(.ExecuteReader)
        End With
        LoadSearchClient = dtLoadSearchClient.Rows.Count.ToString
    End Function
    Public Sub LoadHistory(ByVal Details As String)
        Dim dtLoadHistory As New DataTable
        Dim sqlcmdLoadHistory As New SqlCommand
        With sqlcmdLoadHistory
            .Connection = SQLConnection
            .CommandText =
                    "select a.Instrument as 'Details',a.ExpenseLocation from tbExpenseDetails as a " & _
                        "where a.Instrument <> '' and a.Instrument <> 'N/A' and a.Instrument like '%" & Details & "%'" & _
                                "Union all " & _
                    "select a.SerialNumber as 'Details' from tbExpenseDetails as a " & _
                        "where a.SerialNumber <> '' and a.SerialNumber <> 'N/A' and a.SerialNumber like '%" & Details & "%'" & _
                                "Union all " & _
                    "select a.ServiceNumber as 'Details' from tbExpenseDetails as a " & _
                        "where a.ServiceNumber <> '' and a.ServiceNumber <> 'N/A' and a.ServiceNumber Like '%" & Details & "%'"
            .CommandType = CommandType.Text
            dtLoadHistory.Load(.ExecuteReader)

            History.DataGridView1.DataSource = dtLoadHistory

        End With
    End Sub


End Module
