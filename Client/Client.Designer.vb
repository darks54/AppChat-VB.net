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
        Me.tb_message = New System.Windows.Forms.TextBox()
        Me.bt_envoyer = New System.Windows.Forms.Button()
        Me.bt_connecter = New System.Windows.Forms.Button()
        Me.tb_pseudo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_messages = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'tb_message
        '
        Me.tb_message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_message.Enabled = False
        Me.tb_message.Location = New System.Drawing.Point(12, 64)
        Me.tb_message.Name = "tb_message"
        Me.tb_message.Size = New System.Drawing.Size(575, 20)
        Me.tb_message.TabIndex = 0
        '
        'bt_envoyer
        '
        Me.bt_envoyer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_envoyer.Enabled = False
        Me.bt_envoyer.Location = New System.Drawing.Point(525, 90)
        Me.bt_envoyer.Name = "bt_envoyer"
        Me.bt_envoyer.Size = New System.Drawing.Size(62, 25)
        Me.bt_envoyer.TabIndex = 2
        Me.bt_envoyer.Text = "Envoyer"
        Me.bt_envoyer.UseVisualStyleBackColor = True
        '
        'bt_connecter
        '
        Me.bt_connecter.Location = New System.Drawing.Point(230, 10)
        Me.bt_connecter.Name = "bt_connecter"
        Me.bt_connecter.Size = New System.Drawing.Size(75, 23)
        Me.bt_connecter.TabIndex = 3
        Me.bt_connecter.Text = "Connection"
        Me.bt_connecter.UseVisualStyleBackColor = True
        '
        'tb_pseudo
        '
        Me.tb_pseudo.Location = New System.Drawing.Point(64, 12)
        Me.tb_pseudo.Name = "tb_pseudo"
        Me.tb_pseudo.Size = New System.Drawing.Size(160, 20)
        Me.tb_pseudo.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pseudo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Message :"
        '
        'lb_messages
        '
        Me.lb_messages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lb_messages.FormattingEnabled = True
        Me.lb_messages.Location = New System.Drawing.Point(12, 121)
        Me.lb_messages.Name = "lb_messages"
        Me.lb_messages.Size = New System.Drawing.Size(575, 342)
        Me.lb_messages.TabIndex = 7
        '
        'Client
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 475)
        Me.Controls.Add(Me.lb_messages)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_pseudo)
        Me.Controls.Add(Me.bt_connecter)
        Me.Controls.Add(Me.bt_envoyer)
        Me.Controls.Add(Me.tb_message)
        Me.Name = "Client"
        Me.Text = "Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb_message As TextBox
    Friend WithEvents bt_envoyer As Button
    Friend WithEvents bt_connecter As Button
    Friend WithEvents tb_pseudo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lb_messages As ListBox
End Class
