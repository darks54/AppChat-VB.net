<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_pseudo = New System.Windows.Forms.TextBox()
        Me.btn_valider = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_serveur = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pseudo :"
        '
        'tb_pseudo
        '
        Me.tb_pseudo.Location = New System.Drawing.Point(67, 6)
        Me.tb_pseudo.Name = "tb_pseudo"
        Me.tb_pseudo.Size = New System.Drawing.Size(205, 20)
        Me.tb_pseudo.TabIndex = 2
        '
        'btn_valider
        '
        Me.btn_valider.Location = New System.Drawing.Point(105, 58)
        Me.btn_valider.Name = "btn_valider"
        Me.btn_valider.Size = New System.Drawing.Size(75, 23)
        Me.btn_valider.TabIndex = 5
        Me.btn_valider.Text = "Valider"
        Me.btn_valider.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Serveur :"
        '
        'tb_serveur
        '
        Me.tb_serveur.Location = New System.Drawing.Point(67, 32)
        Me.tb_serveur.Name = "tb_serveur"
        Me.tb_serveur.Size = New System.Drawing.Size(205, 20)
        Me.tb_serveur.TabIndex = 4
        '
        'Options
        '
        Me.AcceptButton = Me.btn_valider
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 89)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_serveur)
        Me.Controls.Add(Me.btn_valider)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tb_pseudo)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 128)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 128)
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tb_pseudo As TextBox
    Friend WithEvents btn_valider As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_serveur As TextBox
End Class
