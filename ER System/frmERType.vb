Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Threading
Imports System.ComponentModel
Public Class frmERType
    Dim subject As String
    Dim dtp As DateTime = Date.Now
    Public Const MyKey As String = "crimsonmonastery2003"
    Public TripleDes As New clsEncryption(MyKey)
    Private Sub frmERType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = False
        frmEReport.TopMost = True
        rbtERF.Checked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        modLoadingData.LocationCode = txtLocationCode.Text
        modLoadingData.LocationName = txtLocationName.Text
        frmLoading.Show()
        frmLoading.TopMost = True
        btnSend.Text = "Sending . ."
        btnSend.Enabled = False
    End Sub

    Public Sub RBUTTON()
        If modLoadingData.RBT = "0" Then
            frmRpt.reportID = modLoadingData.ReportIDExport
            frmRpt.export()
            subject = modLoadingData.LoginUsername + " " + "ER FOR THE MONTH OF " + modLoadingData.sDate.ToString("MMM").ToUpper + " " + dtp.ToString("yyyy").ToUpper
            SendingEmail()
        Else
            frmRpt.reportID = modLoadingData.ReportIDExport
            frmRpt.export()
            subject = modLoadingData.LoginUsername + " " + "Liquidation for  " + modLoadingData.LocationName + " Trip " + modLoadingData.sDate.ToString("MMM").ToUpper + " " + dtp.ToString("yyyy").ToUpper
            SendingEmail()
        End If
    End Sub
    Public Sub Sending()
        txtLocationCode.Clear()
        txtLocationName.Clear()
        RBUTTON()
    End Sub
    Public Sub SendingEmail()
        LoadingUserAccountEmail(modLoadingData.LoginuserID, modLoadingData.LoginDeptID)
        Dim attachment As Attachment = New Attachment(frmRpt.strExportFile)
        Dim message As New MailMessage(TripleDes.DecryptData(modLoadingData.EmailAdd).ToString, modLoadingData.EmailTo, subject,
                                       "This Attachment is original and cannot be edited by any platform." + vbNewLine + "      If they want to change these data they have to create a new report in Expense Management System.")
        message.Attachments.Add(attachment)
        Dim smtpClient As New SmtpClient("mail.marsmandrysdale.com")
        message.Bcc.Add(modLoadingData.EmailBCC)
        smtpClient.EnableSsl = False
        smtpClient.UseDefaultCredentials = False
        Dim credentials As New NetworkCredential(TripleDes.DecryptData(modLoadingData.EmailAdd).ToString, TripleDes.DecryptData(modLoadingData.EmailPass).ToString)
        smtpClient.Credentials = credentials
        smtpClient.Send(message)
        InsertAttachment(LoginUsername + "|" + DateAndTime.Now.ToString("MM/dd/yyyy HH:mm") + "|" + frmRpt.strExportFile)

    End Sub

    Private Sub rbtERF_CheckedChanged(sender As Object, e As EventArgs) Handles rbtERF.CheckedChanged
        If RadioButton2.Checked = True Then
            txtLocationCode.Enabled = True
            txtLocationName.Enabled = True
            modLoadingData.RBT = "1"
        Else
            txtLocationCode.Enabled = False
            txtLocationName.Enabled = False
            txtLocationCode.Clear()
            txtLocationName.Clear()
            modLoadingData.RBT = "0"
        End If
    End Sub
End Class
