Public Class History
    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        LoadHistory(txtName.Text)
        Me.DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridView1.AllowUserToAddRows = True
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class