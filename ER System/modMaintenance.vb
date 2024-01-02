Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Microsoft.Win32
Module modMaintenance
    Dim sqlAddDeptSign As New SqlCommand
    Dim sqlUpdateUserAccount As New SqlCommand
    Dim dtUpdateUserAccount As New DataTable
    Dim strError As String
    Public strPassword As String
    Dim dtLoadPassword As New DataTable
    Dim dtDeptPassword As New DataTable
    Dim sqlAddDeptPassword As New SqlCommand
    Dim sqlcmdLoadPassword As New SqlCommand
    Dim sqlcmdUpdateEmailSetup As New SqlCommand
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Public Sub AddReport(ByVal dateFrom As String, ByVal dateto As String,
                         ByVal Description As String, ByVal CashAdvance As String,
                         ByVal cashDate As String, ByVal cashrefdoc As String,
                         ByVal cashrefNumber As String, ByVal balto As String,
                         ByVal revolvingfund As String, ByVal cashCheck As String,
                         ByVal userID As String, ByVal status As String,
                         ByVal Approved As String, ByVal dateFiled As String,
                         ByVal fileStatus As String)

        Dim sqlAddReport As New SqlCommand
        Try
            With sqlAddReport
                .Connection = SQLConnection
                .CommandText = "EXEC sp2_AddReportData '" & dateFrom & "','" & dateto & _
                    "','" & Description & "','" & CashAdvance & "','" & cashDate & "','" & cashrefdoc & _
                    "','" & cashrefNumber & "','" & balto & "','" & revolvingfund & "','" & cashCheck & _
                    "','" & userID & "','" & status & "','" & Approved & "','" & dateFiled & "','" & fileStatus & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub UpdateReport(ByVal reportID As String, ByVal dateFrom As String, ByVal dateto As String,
                         ByVal Description As String, ByVal CashAdvance As String,
                         ByVal cashDate As String, ByVal cashrefdoc As String,
                         ByVal cashrefNumber As String, ByVal revolvingfund As String,
                         ByVal cashCheck As String)
        Dim sqlUpdateReport As New SqlCommand
        Try
            With sqlUpdateReport
                .Connection = SQLConnection
                .CommandText = "EXEC sp2_UpdateReportData '" & reportID & "','" & dateFrom & "','" & dateto & _
                    "','" & Description & "','" & CashAdvance & "','" & cashDate & "','" & cashrefdoc & _
                    "','" & cashrefNumber & "','" & revolvingfund & "','" & cashCheck & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub RefileER(ByVal reportID As String, ByVal status As String)
        Dim sqlcmdRefileER As New SqlCommand
        With sqlcmdRefileER
            .Connection = SQLConnection
            .CommandText = "sp2_RefileER '" & reportID & "','" & status & "'"
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
    End Sub
    Public Sub AddExpense(ByVal transdate As String, ByVal perdiem As String,
                          ByVal particulars As String, ByVal invoice As String,
                          ByVal multiplier As String, ByVal type As String,
                          ByVal category As String, ByVal amount As String,
                          ByVal remarks As String, ByVal status As String,
                          ByVal totalamount As String, ByVal location As String,
                          ByVal userid As String, ByVal reportID As String, ByVal ServiceNumber As String,
                          ByVal Instrument As String, ByVal SerialNumber As String, ByVal WorkWith As String)
        Dim sqlAddExpense As New SqlCommand
        Try
            With sqlAddExpense
                .Connection = SQLConnection
                If WorkWith = Nothing Then
                    .CommandText = "EXEC [sp2_AddExpense] '" & transdate & "','" & perdiem &
                        "','" & particulars & "','" & invoice & "','" & multiplier & "','" & type &
                        "','" & category & "','" & amount & "','" & remarks & "','" & status &
                        "','" & totalamount & "','" & location & "','" & userid & "','" & reportID & "','" & "NONE" & "','" & ServiceNumber &
                        "',,'" & Instrument & "','" & SerialNumber & "'"
                Else
                    .CommandText = "EXEC [sp2_AddExpense] '" & transdate & "','" & perdiem &
                       "','" & particulars & "','" & invoice & "','" & multiplier & "','" & type &
                       "','" & category & "','" & amount & "','" & remarks & "','" & status &
                       "','" & totalamount & "','" & location & "','" & userid & "','" & reportID & "','" & WorkWith & "','" & ServiceNumber &
                       "','" & Instrument & "','" & SerialNumber & "'"
                End If
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddExpenseHisto(ByVal transdate As String, ByVal perdiem As String,
                      ByVal particulars As String, ByVal invoice As String,
                      ByVal multiplier As String, ByVal type As String,
                      ByVal category As String, ByVal amount As String,
                      ByVal remarks As String, ByVal status As String,
                      ByVal totalamount As String, ByVal location As String,
                      ByVal userid As String, ByVal reportID As String, ByVal TransID As String,
                      ByVal ServiceNumber As String, ByVal Instrument As String, ByVal SerialNumber As String)
        Dim sqlAddExpense As New SqlCommand
        Try
            With sqlAddExpense
                .Connection = SQLConnection
                If WorkWith = Nothing Then
                    .CommandText = "EXEC [sp2_AddExpenseHisto] '" & transdate & "','" & perdiem & _
                        "','" & particulars & "','" & invoice & "','" & multiplier & "','" & type & _
                        "','" & category & "','" & amount & "','" & remarks & "','" & status & _
                        "','" & totalamount & "','" & location & "','" & userid & "','" & reportID & "','" & _
                        "NONE" & "','" & TransID & "','" & ServiceNumber & "',,'" & Instrument & "','" & SerialNumber & "'"
                Else
                    .CommandText = "EXEC [sp2_AddExpenseHisto] '" & transdate & "','" & perdiem & _
                       "','" & particulars & "','" & invoice & "','" & multiplier & "','" & type & _
                       "','" & category & "','" & amount & "','" & remarks & "','" & status & _
                       "','" & totalamount & "','" & location & "','" & userid & "','" & reportID & "','" & WorkWith & _
                       "','" & TransID & "','" & ServiceNumber & "','" & Instrument & "','" & SerialNumber & "'"
                End If
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub UpdateExpense(ByVal transID As String, ByVal transdate As String,
                           ByVal perdiem As String, ByVal particulars As String,
                           ByVal invoice As String, ByVal multiplier As String,
                           ByVal type As String, ByVal category As String,
                           ByVal amount As String, ByVal remarks As String,
                           ByVal status As String, ByVal totalamount As String,
                           ByVal location As String, ByVal userid As String, ByVal ServiceNumber As String,
                           ByVal Instrument As String, ByVal SerialNumber As String, ByVal WorkWith As String)
        Dim sqlUpdateExpense As New SqlCommand
        Try
            With sqlUpdateExpense
                .Connection = SQLConnection
                If WorkWith = Nothing Then
                    .CommandText = "EXEC [sp2_updateExpense] '" & transID & "','" & transdate &
            "','" & perdiem & "','" & particulars & "','" & invoice & "','" & multiplier &
            "','" & type & "','" & category & "','" & amount & "','" & remarks & "','" & status &
            "','" & totalamount & "','" & location & "','" & userid & "','" & "NONE" & "','" & ServiceNumber &
            "','" & Instrument & "','" & SerialNumber & "'"
                Else
                    .CommandText = "EXEC [sp2_updateExpense] '" & transID & "','" & transdate &
                "','" & perdiem & "','" & particulars & "','" & invoice & "','" & multiplier &
                "','" & type & "','" & category & "','" & amount & "','" & remarks & "','" & status &
                "','" & totalamount & "','" & location & "','" & userid & "','" & WorkWith & "','" & ServiceNumber &
                "','" & Instrument & "','" & SerialNumber & "'"
                End If

                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub AdduserAccount(ByVal UserID As String, ByVal Fullname As String,
                              ByVal Position As String, ByVal Department As String,
                              ByVal username As String, ByVal Password As String,
                              ByVal emailAdd As String, ByVal EmailPassword As String,
                              ByVal EmailTo As String, ByVal EmailBcc As String,
                              ByVal userlevel As String)
        If Trim(frmUserRegistration.picName) = "" Then
            Dim ms As New IO.MemoryStream()
            '    frmUserRegistration.picSignature.Image.Save(ms, frmUserRegistration.picSignature.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Dim sqlAddUserAccount As New SqlCommand
            Try
                With sqlAddUserAccount
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .CommandText = "EXEC sp2_AddUserAccount '" & UserID & "','" & Fullname & "','" & Position & _
                        "','" & Department & "','" & username & "','" & Password & "','" & emailAdd & "','" & EmailPassword & _
                        "','" & EmailTo & "','" & EmailBcc & "',@Signature,'" & userlevel & "'"
                    .Parameters.Add(New SqlParameter("@Signature", SqlDbType.VarBinary)).Value = arrImage
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                strError = ex.Message
            End Try
        Else
            Dim ms As New IO.MemoryStream()
            frmUserRegistration.picSignature.Image.Save(ms, frmUserRegistration.picSignature.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Dim sqlAddUserAccount As New SqlCommand
            Try
                With sqlAddUserAccount
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .CommandText = "EXEC sp2_AddUserAccount '" & UserID & "','" & Fullname & "','" & Position & _
                        "','" & Department & "','" & username & "','" & Password & "','" & emailAdd & "','" & EmailPassword & _
                        "','" & EmailTo & "','" & EmailBcc & "',@Signature,'" & userlevel & "'"
                    .Parameters.Add(New SqlParameter("@Signature", SqlDbType.VarBinary)).Value = arrImage
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                strError = ex.Message
            End Try
        End If


    End Sub
    Public Sub UpdateUserAccount(ByVal UserID As String, ByVal Fullname As String,
                              ByVal Position As String, ByVal Department As String,
                              ByVal username As String, ByVal Password As String,
                              ByVal EmailTo As String, ByVal EmailBcc As String,
                              ByVal userlevel As String)
        If Trim(frmUserRegistration.picName) = "" Then

            Dim ms As New IO.MemoryStream()
            '    frmUserRegistration.picSignature.Image.Save(ms, frmUserRegistration.picSignature.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Try
                With sqlUpdateUserAccount
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .Parameters.Clear()
                    .CommandText = "sp2_UpdateUserAcc '" & UserID & "','" & Fullname & "','" & Position & _
                        "','" & Department & "','" & username & "','" & Password & _
                        "','" & EmailTo & "','" & EmailBcc & "',@Signature,'" & userlevel & "'"
                    .Parameters.Add(New SqlParameter("@Signature", SqlDbType.VarBinary)).Value = arrImage
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                strError = ex.Message
            End Try
        Else


            Dim ms As New IO.MemoryStream()
            frmUserRegistration.picSignature.Image.Save(ms, frmUserRegistration.picSignature.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Try
                With sqlUpdateUserAccount
                    .Connection = SQLConnection
                    .CommandType = CommandType.Text
                    .Parameters.Clear()
                    .CommandText = "sp2_UpdateUserAcc '" & UserID & "','" & Fullname & "','" & Position & _
                        "','" & Department & "','" & username & "','" & Password & _
                        "','" & EmailTo & "','" & EmailBcc & "',@Signature,'" & userlevel & "'"
                    .Parameters.Add(New SqlParameter("@Signature", SqlDbType.VarBinary)).Value = arrImage
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                strError = ex.Message
            End Try
        End If
    End Sub
    Public Sub AddDeptSign(ByVal deptID As String, ByVal review As String, ByVal endorse As String,
                           ByVal approve As String, ByVal UserID As String)
        Try
            With sqlAddDeptSign
                .Connection = SQLConnection
                .CommandText = "sp2_AddDeptSign '" & deptID & "','" & review & "','" & endorse & "','" & approve & _
                    "','" & UserID & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub UpdateDeptSign(ByVal UserID As String, ByVal deptID As String, ByVal review As String, ByVal endorse As String,
                          ByVal approve As String)
        Try
            With sqlAddDeptSign
                .Connection = SQLConnection
                .CommandText = "[sp2_UpdateDeptSign] '" & UserID & "','" & deptID & "','" & review & "','" & endorse & "','" & approve & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub AddSign(ByVal userID As String, ByVal signID As String, ByVal reportID As String)
        Dim sqlcmdAddSign As New SqlCommand
        Try
            With sqlcmdAddSign
                .Connection = SQLConnection
                .CommandText = "sp2_AddSignature '" & userID & "','" & signID & "','" & reportID & "'"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub DeleteImage(ByVal userID As String, ByVal reportID As String)
        Dim sqlDelete As New SqlCommand
        Try
            With sqlDelete
                .Connection = SQLConnection
                .CommandText = "sp2_DeleteVar"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@reportID", SqlDbType.VarChar).Value = reportID
                .Parameters.AddWithValue("@userID", userID).SqlDbType = SqlDbType.VarChar
                .Parameters.AddWithValue("@Image", DBNull.Value).SqlDbType = SqlDbType.VarBinary

                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            strError = ex.Message
        End Try
    End Sub
    Public Sub ChangePassword(ByVal userid As String, ByVal password As String)
        Try
            With sqlcmdLoadPassword
                .Connection = SQLConnection
                .CommandText = "sp2_ChangePassword"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@userID", SqlDbType.VarChar).Value = userid
                .Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Public Sub DeptAddPassword(ByVal deptID As String, ByVal password As String)
        With sqlAddDeptPassword
            .Connection = SQLConnection
            .CommandText = "sp2_InsertAdminLogin"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("DeptID", deptID).SqlDbType = SqlDbType.VarChar
            .Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar
            .ExecuteNonQuery()
        End With
    End Sub
    Public Sub UpdateEmailSetup(ByVal empId As String, ByVal emailAdd As String, ByVal emailPassword As String, ByVal emailTo As String,
                                ByVal emailBcc As String)
        With sqlcmdUpdateEmailSetup
            .Connection = SQLConnection
            .CommandText = "sp2_UpdateEmailSetup"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@empID", SqlDbType.VarChar).Value = empId
            .Parameters.AddWithValue("@emailAdd", emailAdd).SqlDbType = SqlDbType.VarChar
            .Parameters.AddWithValue("@emailPassword", emailPassword).SqlDbType = SqlDbType.VarChar
            .Parameters.AddWithValue("@emailTo", emailTo).SqlDbType = SqlDbType.VarChar
            .Parameters.AddWithValue("@emailBcc", emailBcc).SqlDbType = SqlDbType.VarChar
            .ExecuteNonQuery()
        End With
    End Sub
    Public Sub AddClient(ByVal ClientName As String)
        Dim sqlcmdAddClient As New SqlCommand
        With sqlcmdAddClient
            .Connection = SQLConnection
            .CommandText = "Insert into tblClient (ClientName) values ('" & ClientName & "')"
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
    End Sub
    Public Sub InsertAttachment(ByVal ReportAttachment As String)
        Dim sqlcmdReportAttachment As New SqlCommand
        With sqlcmdReportAttachment
            .Connection = SQLConnection
            .CommandText = "sp2_InsertAttachment"
            .Parameters.Add("@ReportID", SqlDbType.BigInt).Value = modLoadingData.ReportIDExport
            .Parameters.AddWithValue("@ReportAttachment", ReportAttachment).SqlDbType = SqlDbType.VarChar
            .CommandType = CommandType.StoredProcedure
            .ExecuteNonQuery()
        End With
    End Sub
    Public Sub PrintSendingReport()
        Dim sqlcmdSendReport As New SqlClient.SqlCommand
        With sqlcmdSendReport
            .Connection = SQLConnection
            .CommandText = "sp_InsertSendingStatus"
            .Parameters.Add("@ExportID", SqlDbType.VarChar).Value = modLoadingData.ReportIDExport
            .CommandType = CommandType.StoredProcedure
            .ExecuteNonQuery()
        End With
    End Sub
End Module
