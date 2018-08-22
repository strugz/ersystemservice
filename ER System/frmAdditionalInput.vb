Public Class frmAdditionalInput

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim x As String
        Me.TopMost = False
      
        If CheckBox1.Checked = True Then
            x = MsgBox("Are you sure you want to check the option below?" & vbNewLine & "If YES your work with for the remaining transaction is NONE", MsgBoxStyle.YesNoCancel, "Check")
            If x = MsgBoxResult.Yes Then
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "0")
            Else
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "1")
            End If
        End If

    End Sub
    Private Sub frmAdditionalInput_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyValue = Keys.Escape) = True Then
            modMaintenance.WorkWith = IIf(txtWorkWith.Text = "", "N/A", txtWorkWith.Text)
            Me.Close()
        End If
    End Sub
    Private Sub frmAdditionalInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmEReport.TopMost = False
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\ER System\Settings", "Additional", "") = "1" Then
            CheckBox1.Checked = False
        End If
    End Sub
End Class