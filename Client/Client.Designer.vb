<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Client
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Client))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.flp_pseudo = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabControlSalons = New System.Windows.Forms.TabControl()
        Me.TabPageGeneral = New System.Windows.Forms.TabPage()
        Me.lb_messages = New System.Windows.Forms.ListBox()
        Me.bt_envoyer = New System.Windows.Forms.Button()
        Me.tb_message = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripUsers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChuchoterToolStripTextBox = New System.Windows.Forms.ToolStripMenuItem()
        Me.InviterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btn_options = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStripSalons = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FermerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControlSalons.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.ContextMenuStripUsers.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStripSalons.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 28)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.flp_pseudo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControlSalons)
        Me.SplitContainer1.Size = New System.Drawing.Size(991, 598)
        Me.SplitContainer1.SplitterDistance = 179
        Me.SplitContainer1.TabIndex = 8
        '
        'flp_pseudo
        '
        Me.flp_pseudo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flp_pseudo.BackColor = System.Drawing.Color.White
        Me.flp_pseudo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flp_pseudo.Location = New System.Drawing.Point(3, 4)
        Me.flp_pseudo.Name = "flp_pseudo"
        Me.flp_pseudo.Size = New System.Drawing.Size(173, 591)
        Me.flp_pseudo.TabIndex = 0
        '
        'TabControlSalons
        '
        Me.TabControlSalons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlSalons.Controls.Add(Me.TabPageGeneral)
        Me.TabControlSalons.Location = New System.Drawing.Point(3, 4)
        Me.TabControlSalons.Name = "TabControlSalons"
        Me.TabControlSalons.SelectedIndex = 0
        Me.TabControlSalons.Size = New System.Drawing.Size(802, 591)
        Me.TabControlSalons.TabIndex = 8
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.Controls.Add(Me.lb_messages)
        Me.TabPageGeneral.Controls.Add(Me.bt_envoyer)
        Me.TabPageGeneral.Controls.Add(Me.tb_message)
        Me.TabPageGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGeneral.Size = New System.Drawing.Size(794, 565)
        Me.TabPageGeneral.TabIndex = 0
        Me.TabPageGeneral.Text = "Général"
        Me.TabPageGeneral.UseVisualStyleBackColor = True
        '
        'lb_messages
        '
        Me.lb_messages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_messages.FormattingEnabled = True
        Me.lb_messages.Location = New System.Drawing.Point(6, 6)
        Me.lb_messages.Name = "lb_messages"
        Me.lb_messages.Size = New System.Drawing.Size(782, 524)
        Me.lb_messages.TabIndex = 7
        '
        'bt_envoyer
        '
        Me.bt_envoyer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_envoyer.Location = New System.Drawing.Point(711, 539)
        Me.bt_envoyer.Name = "bt_envoyer"
        Me.bt_envoyer.Size = New System.Drawing.Size(77, 20)
        Me.bt_envoyer.TabIndex = 2
        Me.bt_envoyer.Text = "Envoyer"
        Me.bt_envoyer.UseVisualStyleBackColor = True
        '
        'tb_message
        '
        Me.tb_message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_message.Location = New System.Drawing.Point(6, 539)
        Me.tb_message.Name = "tb_message"
        Me.tb_message.Size = New System.Drawing.Size(699, 20)
        Me.tb_message.TabIndex = 0
        '
        'ContextMenuStripUsers
        '
        Me.ContextMenuStripUsers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChuchoterToolStripTextBox, Me.InviterToolStripMenuItem})
        Me.ContextMenuStripUsers.Name = "ContextMenuStrip1"
        Me.ContextMenuStripUsers.Size = New System.Drawing.Size(131, 48)
        '
        'ChuchoterToolStripTextBox
        '
        Me.ChuchoterToolStripTextBox.Name = "ChuchoterToolStripTextBox"
        Me.ChuchoterToolStripTextBox.Size = New System.Drawing.Size(130, 22)
        Me.ChuchoterToolStripTextBox.Text = "Chuchoter"
        '
        'InviterToolStripMenuItem
        '
        Me.InviterToolStripMenuItem.Name = "InviterToolStripMenuItem"
        Me.InviterToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.InviterToolStripMenuItem.Text = "Inviter"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.btn_options})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1015, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(48, 22)
        Me.ToolStripButton1.Text = "Quitter"
        '
        'btn_options
        '
        Me.btn_options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_options.Image = CType(resources.GetObject("btn_options.Image"), System.Drawing.Image)
        Me.btn_options.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_options.Name = "btn_options"
        Me.btn_options.Size = New System.Drawing.Size(53, 22)
        Me.btn_options.Text = "Options"
        '
        'ContextMenuStripSalons
        '
        Me.ContextMenuStripSalons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerToolStripMenuItem})
        Me.ContextMenuStripSalons.Name = "ContextMenuStripSalons"
        Me.ContextMenuStripSalons.Size = New System.Drawing.Size(112, 26)
        '
        'FermerToolStripMenuItem
        '
        Me.FermerToolStripMenuItem.Name = "FermerToolStripMenuItem"
        Me.FermerToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.FermerToolStripMenuItem.Text = "Fermer"
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 638)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Client"
        Me.Text = "Client"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControlSalons.ResumeLayout(False)
        Me.TabPageGeneral.ResumeLayout(False)
        Me.TabPageGeneral.PerformLayout()
        Me.ContextMenuStripUsers.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStripSalons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents btn_options As ToolStripButton
    Friend WithEvents TabControlSalons As TabControl
    Friend WithEvents TabPageGeneral As TabPage
    Friend WithEvents lb_messages As ListBox
    Friend WithEvents bt_envoyer As Button
    Friend WithEvents tb_message As TextBox
    Friend WithEvents ContextMenuStripUsers As ContextMenuStrip
    Friend WithEvents ChuchoterToolStripTextBox As ToolStripMenuItem
    Friend WithEvents InviterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents flp_pseudo As FlowLayoutPanel
    Friend WithEvents ContextMenuStripSalons As ContextMenuStrip
    Friend WithEvents FermerToolStripMenuItem As ToolStripMenuItem
End Class
