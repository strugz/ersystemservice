Public Class frmAdditionalInput
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim StrLength As String = ""
        Dim IntLength As Integer = 0
        For i As Integer = 0 To dgvUser.RowCount - 1
            If dgvUser.Item(0, i).Value = "True" Then
                StrLength += dgvUser.Item(1, i).Value + "/"
            End If
        Next
        If StrLength <> "" Then
            IntLength = StrLength.Length
            StrLength = StrLength.Remove(IntLength - 1)
            frmEReport.txtWorkWith.Text = StrLength
            modLoadingData.WorkWith = StrLength
            Me.Close()
        Else
            MsgBox("Please Choose First!")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmEReport.txtWorkWith.Text = "NONE"
        Me.Close()
    End Sub

    Private Sub frmAdditionalInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedDataGrid()
    End Sub
    Private Sub CheckedDataGrid()
        Dim StrSplitLenght() As String = {""}
        StrSplitLenght = IIf(modLoadingData.WorkWith = "", frmEReport.txtWorkWith.Text.Split("/"),
                             modLoadingData.WorkWith.Split("/"))
        For index As Integer = 0 To IIf(StrSplitLenght.Length = 0, 0, StrSplitLenght.Length - 1)
            For i As Integer = 0 To Me.dgvUser.Rows.Count - 1
                If Me.dgvUser.Rows(i).Cells(1).Value = IIf(StrSplitLenght(index) = "", modLoadingData.WorkWith,
                                                           StrSplitLenght(index)) Then
                    Me.dgvUser.Rows(i).Cells(0).Value = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAdditionalInput_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.dgvUser.DataSource = Nothing
        Me.dgvUser.Columns.Clear()
    End Sub
End Class