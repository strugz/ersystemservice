<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DgvReportDetails = New System.Windows.Forms.DataGridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SignatoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPrev = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuForms = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActiveFormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousFormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuExpenseDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.fmsExpenseSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CtrlLLogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ESCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.detect = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.Button()
        Me.btnReportData = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnFileReport = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ttuser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslUserDept = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.Button()
        Me.colored = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DgvReportDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.colored, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DgvReportDetails
        '
        Me.DgvReportDetails.AllowUserToAddRows = False
        Me.DgvReportDetails.AllowUserToDeleteRows = False
        Me.DgvReportDetails.AllowUserToResizeColumns = False
        Me.DgvReportDetails.AllowUserToResizeRows = False
        Me.DgvReportDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvReportDetails.BackgroundColor = System.Drawing.Color.White
        Me.DgvReportDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DgvReportDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgvReportDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvReportDetails.Location = New System.Drawing.Point(4, 163)
        Me.DgvReportDetails.Name = "DgvReportDetails"
        Me.DgvReportDetails.ReadOnly = True
        Me.DgvReportDetails.RowHeadersVisible = False
        Me.DgvReportDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvReportDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DgvReportDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvReportDetails.Size = New System.Drawing.Size(1041, 546)
        Me.DgvReportDetails.TabIndex = 7
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 16)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuForms, Me.AboutToolStripMenuItem, Me.CommandToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1049, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserAccountToolStripMenuItem, Me.SignatoryToolStripMenuItem, Me.ChangePasswordToolStripMenuItem1, Me.tsmiPrev})
        Me.MenuFile.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuFile.ForeColor = System.Drawing.Color.Black
        Me.MenuFile.Image = CType(resources.GetObject("MenuFile.Image"), System.Drawing.Image)
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(156, 25)
        Me.MenuFile.Text = "Account Settings"
        '
        'UserAccountToolStripMenuItem
        '
        Me.UserAccountToolStripMenuItem.Image = CType(resources.GetObject("UserAccountToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UserAccountToolStripMenuItem.Name = "UserAccountToolStripMenuItem"
        Me.UserAccountToolStripMenuItem.Size = New System.Drawing.Size(291, 26)
        Me.UserAccountToolStripMenuItem.Text = "User Account"
        Me.UserAccountToolStripMenuItem.Visible = False
        '
        'SignatoryToolStripMenuItem
        '
        Me.SignatoryToolStripMenuItem.Image = CType(resources.GetObject("SignatoryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SignatoryToolStripMenuItem.Name = "SignatoryToolStripMenuItem"
        Me.SignatoryToolStripMenuItem.Size = New System.Drawing.Size(291, 26)
        Me.SignatoryToolStripMenuItem.Text = "Signatory"
        '
        'ChangePasswordToolStripMenuItem1
        '
        Me.ChangePasswordToolStripMenuItem1.Image = CType(resources.GetObject("ChangePasswordToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ChangePasswordToolStripMenuItem1.Name = "ChangePasswordToolStripMenuItem1"
        Me.ChangePasswordToolStripMenuItem1.Size = New System.Drawing.Size(291, 26)
        Me.ChangePasswordToolStripMenuItem1.Text = "Change Password/Email Setup"
        '
        'tsmiPrev
        '
        Me.tsmiPrev.Image = CType(resources.GetObject("tsmiPrev.Image"), System.Drawing.Image)
        Me.tsmiPrev.Name = "tsmiPrev"
        Me.tsmiPrev.Size = New System.Drawing.Size(291, 26)
        Me.tsmiPrev.Text = "Previous ER"
        '
        'MenuForms
        '
        Me.MenuForms.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiveFormsToolStripMenuItem, Me.PreviousFormsToolStripMenuItem, Me.MenuExpenseDetails, Me.fmsExpenseSummary})
        Me.MenuForms.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuForms.ForeColor = System.Drawing.Color.Black
        Me.MenuForms.Image = CType(resources.GetObject("MenuForms.Image"), System.Drawing.Image)
        Me.MenuForms.Name = "MenuForms"
        Me.MenuForms.Size = New System.Drawing.Size(84, 25)
        Me.MenuForms.Text = "Forms"
        '
        'ActiveFormsToolStripMenuItem
        '
        Me.ActiveFormsToolStripMenuItem.Image = CType(resources.GetObject("ActiveFormsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActiveFormsToolStripMenuItem.Name = "ActiveFormsToolStripMenuItem"
        Me.ActiveFormsToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.ActiveFormsToolStripMenuItem.Text = "For Approval"
        '
        'PreviousFormsToolStripMenuItem
        '
        Me.PreviousFormsToolStripMenuItem.Image = CType(resources.GetObject("PreviousFormsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreviousFormsToolStripMenuItem.Name = "PreviousFormsToolStripMenuItem"
        Me.PreviousFormsToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.PreviousFormsToolStripMenuItem.Text = "Previous Forms"
        '
        'MenuExpenseDetails
        '
        Me.MenuExpenseDetails.Name = "MenuExpenseDetails"
        Me.MenuExpenseDetails.Size = New System.Drawing.Size(208, 26)
        Me.MenuExpenseDetails.Text = "Expense Details"
        Me.MenuExpenseDetails.Visible = False
        '
        'fmsExpenseSummary
        '
        Me.fmsExpenseSummary.Name = "fmsExpenseSummary"
        Me.fmsExpenseSummary.Size = New System.Drawing.Size(208, 26)
        Me.fmsExpenseSummary.Text = "Expense Summary"
        Me.fmsExpenseSummary.Visible = False
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(82, 25)
        Me.AboutToolStripMenuItem.Text = "About"
        Me.AboutToolStripMenuItem.Visible = False
        '
        'CommandToolStripMenuItem
        '
        Me.CommandToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CtrlLLogoutToolStripMenuItem, Me.ESCToolStripMenuItem})
        Me.CommandToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CommandToolStripMenuItem.Name = "CommandToolStripMenuItem"
        Me.CommandToolStripMenuItem.Size = New System.Drawing.Size(95, 25)
        Me.CommandToolStripMenuItem.Text = "Command"
        '
        'CtrlLLogoutToolStripMenuItem
        '
        Me.CtrlLLogoutToolStripMenuItem.Name = "CtrlLLogoutToolStripMenuItem"
        Me.CtrlLLogoutToolStripMenuItem.Size = New System.Drawing.Size(185, 26)
        Me.CtrlLLogoutToolStripMenuItem.Text = "Ctrl + L Logout"
        '
        'ESCToolStripMenuItem
        '
        Me.ESCToolStripMenuItem.Name = "ESCToolStripMenuItem"
        Me.ESCToolStripMenuItem.Size = New System.Drawing.Size(185, 26)
        Me.ESCToolStripMenuItem.Text = "ESC"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.HelpToolStripMenuItem.Image = CType(resources.GetObject("HelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(72, 25)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(112, 26)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(865, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Logout"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(975, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 19)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Exit"
        '
        'detect
        '
        Me.detect.AutoSize = True
        Me.detect.Location = New System.Drawing.Point(932, 55)
        Me.detect.Name = "detect"
        Me.detect.Size = New System.Drawing.Size(0, 15)
        Me.detect.TabIndex = 21
        Me.detect.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(869, 73)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 23)
        Me.txtSearch.TabIndex = 11
        Me.txtSearch.Visible = False
        '
        'lbltime
        '
        Me.lbltime.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.Black
        Me.lbltime.Location = New System.Drawing.Point(525, 1)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(44, 21)
        Me.lbltime.TabIndex = 23
        Me.lbltime.Text = "TIME"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ToolStripButton1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ToolStripButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Location = New System.Drawing.Point(673, 51)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(113, 101)
        Me.ToolStripButton1.TabIndex = 4
        Me.ToolStripButton1.Text = "Show Reports"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.ToolStripButton1, "Search Expense Reports")
        Me.ToolStripButton1.UseVisualStyleBackColor = False
        '
        'btnReportData
        '
        Me.btnReportData.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnReportData.BackColor = System.Drawing.Color.Transparent
        Me.btnReportData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReportData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnReportData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnReportData.ForeColor = System.Drawing.Color.Black
        Me.btnReportData.Image = CType(resources.GetObject("btnReportData.Image"), System.Drawing.Image)
        Me.btnReportData.Location = New System.Drawing.Point(316, 51)
        Me.btnReportData.Name = "btnReportData"
        Me.btnReportData.Size = New System.Drawing.Size(113, 101)
        Me.btnReportData.TabIndex = 3
        Me.btnReportData.Text = "Insert Expense"
        Me.btnReportData.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnReportData, "Insert Expense")
        Me.btnReportData.UseVisualStyleBackColor = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrintPreview.BackColor = System.Drawing.Color.Transparent
        Me.btnPrintPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrintPreview.ForeColor = System.Drawing.Color.Black
        Me.btnPrintPreview.Image = CType(resources.GetObject("btnPrintPreview.Image"), System.Drawing.Image)
        Me.btnPrintPreview.Location = New System.Drawing.Point(554, 51)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(113, 101)
        Me.btnPrintPreview.TabIndex = 0
        Me.btnPrintPreview.Text = "Print Preview"
        Me.btnPrintPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnPrintPreview, "Print Preview")
        Me.btnPrintPreview.UseVisualStyleBackColor = False
        '
        'btnFileReport
        '
        Me.btnFileReport.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFileReport.BackColor = System.Drawing.Color.Transparent
        Me.btnFileReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFileReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnFileReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnFileReport.ForeColor = System.Drawing.Color.Black
        Me.btnFileReport.Image = CType(resources.GetObject("btnFileReport.Image"), System.Drawing.Image)
        Me.btnFileReport.Location = New System.Drawing.Point(435, 51)
        Me.btnFileReport.Name = "btnFileReport"
        Me.btnFileReport.Size = New System.Drawing.Size(113, 101)
        Me.btnFileReport.TabIndex = 1
        Me.btnFileReport.Text = "File Report"
        Me.btnFileReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnFileReport, "File Report")
        Me.btnFileReport.UseVisualStyleBackColor = False
        '
        'Timer2
        '
        '
        'Timer3
        '
        Me.Timer3.Enabled = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1006, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(27, 27)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 19
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(918, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 27)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ttuser, Me.ToolStripStatusLabel2, Me.tsslUserDept})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 712)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(1049, 30)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Image = CType(resources.GetObject("ToolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(70, 25)
        Me.ToolStripStatusLabel1.Text = "User:"
        '
        'ttuser
        '
        Me.ttuser.ForeColor = System.Drawing.Color.Black
        Me.ttuser.Name = "ttuser"
        Me.ttuser.Size = New System.Drawing.Size(62, 25)
        Me.ttuser.Text = "Name"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(256, 25)
        Me.ToolStripStatusLabel2.Text = "                            Department:"
        '
        'tsslUserDept
        '
        Me.tsslUserDept.ForeColor = System.Drawing.Color.Black
        Me.tsslUserDept.Name = "tsslUserDept"
        Me.tsslUserDept.Size = New System.Drawing.Size(52, 25)
        Me.tsslUserDept.Text = "Dept"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ToolStripButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Location = New System.Drawing.Point(673, 51)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(113, 101)
        Me.ToolStripButton2.TabIndex = 22
        Me.ToolStripButton2.Text = "Show Reports"
        Me.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton2.UseVisualStyleBackColor = False
        '
        'colored
        '
        Me.colored.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.colored.Image = CType(resources.GetObject("colored.Image"), System.Drawing.Image)
        Me.colored.Location = New System.Drawing.Point(0, 158)
        Me.colored.Name = "colored"
        Me.colored.Size = New System.Drawing.Size(1049, 559)
        Me.colored.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.colored.TabIndex = 20
        Me.colored.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1049, 129)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1049, 742)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStripButton1)
        Me.Controls.Add(Me.DgvReportDetails)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.detect)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnReportData)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnFileReport)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.ToolStripButton2)
        Me.Controls.Add(Me.colored)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                                                                                 " &
    "                                                                                " &
    "                            ER System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DgvReportDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.colored, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DgvReportDetails As System.Windows.Forms.DataGridView
    Friend WithEvents MenuForms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiveFormsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousFormsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.Button
    Friend WithEvents btnReportData As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnFileReport As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents colored As System.Windows.Forms.PictureBox
    Friend WithEvents detect As System.Windows.Forms.Label
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SignatoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ttuser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslUserDept As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsmiPrev As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents CommandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CtrlLLogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents MenuExpenseDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.Button
    Friend WithEvents fmsExpenseSummary As System.Windows.Forms.ToolStripMenuItem

End Class
