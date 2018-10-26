<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRpt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSendPrint = New System.Windows.Forms.Button()
        Me.cryptRptER = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'btnSendPrint
        '
        Me.btnSendPrint.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSendPrint.Enabled = False
        Me.btnSendPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSendPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendPrint.Location = New System.Drawing.Point(0, 0)
        Me.btnSendPrint.Name = "btnSendPrint"
        Me.btnSendPrint.Size = New System.Drawing.Size(733, 46)
        Me.btnSendPrint.TabIndex = 1
        Me.btnSendPrint.Text = "Send/Print"
        Me.btnSendPrint.UseVisualStyleBackColor = True
        '
        'cryptRptER
        '
        Me.cryptRptER.ActiveViewIndex = -1
        Me.cryptRptER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cryptRptER.Cursor = System.Windows.Forms.Cursors.Default
        Me.cryptRptER.DisplayStatusBar = False
        Me.cryptRptER.DisplayToolbar = False
        Me.cryptRptER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cryptRptER.Location = New System.Drawing.Point(0, 46)
        Me.cryptRptER.Name = "cryptRptER"
        Me.cryptRptER.Size = New System.Drawing.Size(733, 504)
        Me.cryptRptER.TabIndex = 2
        Me.cryptRptER.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 550)
        Me.Controls.Add(Me.cryptRptER)
        Me.Controls.Add(Me.btnSendPrint)
        Me.Name = "frmRpt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSendPrint As System.Windows.Forms.Button
    Friend WithEvents cryptRptER As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
