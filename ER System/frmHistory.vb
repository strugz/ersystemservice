Public Class frmHistory
    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Search By: " + modLoadingData.DataToLoad
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If modLoadingData.DataToLoad = "Hospital" Then
            If txtName.Text <> "" Then
                LoadClientToGrid(txtName.Text)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Instrument" Then
            If txtName.Text <> "" Then
                LoadHistory(txtName.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Serial Number" Then
            If txtName.Text <> "" Then
                LoadHistory(txtName.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Service Number" Then
            If txtName.Text <> "" Then
                LoadHistory(txtName.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        End If
    End Sub
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If modLoadingData.DataToLoad = "Hospital" Then
            If txtHospitalClient.Text <> "" Or dgvHistory.Rows(e.RowIndex).Cells("Code").Value = "MDMPI" Then
                If dgvHistory.Rows(e.RowIndex).Cells("Code").Value = "MDMPI" Then
                    If txtHospitalClient.Text <> "MDMPI" Then
                        txtHospitalClient.Text += dgvHistory.Rows(e.RowIndex).Cells("Code").Value
                        txtFrom.Enabled = True
                    End If
                Else
                    frmEReport.txtLocation.Text = dgvHistory.Rows(e.RowIndex).Cells("Code").Value + " to " + txtHospitalClient.Text
                    txtName.Clear()
                    txtHospitalClient.Clear()
                    txtFrom.Clear()
                    dgvHistory.DataSource = Nothing
                    Me.Close()
                End If
            Else
                frmEReport.txtLocation.Text = dgvHistory.Rows(e.RowIndex).Cells("Code").Value
                txtName.Clear()
                dgvHistory.DataSource = Nothing
                Me.Close()
            End If
        ElseIf modLoadingData.DataToLoad = "Instrument" Then
            frmEReport.txtInstrument.Text = dgvHistory.Rows(e.RowIndex).Cells("Instrument").Value
            txtName.Clear()
            dgvHistory.DataSource = Nothing
            Me.Close()
        ElseIf modLoadingData.DataToLoad = "Serial Number" Then
            frmEReport.txtSerialNumber.Text = dgvHistory.Rows(e.RowIndex).Cells("Serial Number").Value
            txtName.Clear()
            dgvHistory.DataSource = Nothing
            Me.Close()
        ElseIf modLoadingData.DataToLoad = "Service Number" Then
            frmEReport.txtServiceNumber.Text = dgvHistory.Rows(e.RowIndex).Cells("Service Number").Value
            txtName.Clear()
            dgvHistory.DataSource = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub frmHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        txtName.Clear()
        dgvHistory.DataSource = Nothing
        txtFrom.Enabled = False
        txtHospitalClient.Clear()
    End Sub

    Private Sub txtFrom_TextChanged(sender As Object, e As EventArgs) Handles txtFrom.TextChanged
        If modLoadingData.DataToLoad = "Hospital" Then
            If txtFrom.Text <> "" Then
                LoadClientToGrid(txtFrom.Text)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Instrument" Then
            If txtFrom.Text <> "" Then
                LoadHistory(txtFrom.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Serial Number" Then
            If txtFrom.Text <> "" Then
                LoadHistory(txtFrom.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        ElseIf modLoadingData.DataToLoad = "Service Number" Then
            If txtFrom.Text <> "" Then
                LoadHistory(txtFrom.Text, modLoadingData.DataToLoad)
                Me.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                Me.dgvHistory.AllowUserToAddRows = True
            Else
                Me.dgvHistory.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub txtHospitalClient_TextChanged(sender As Object, e As EventArgs) Handles txtHospitalClient.TextChanged

    End Sub
End Class