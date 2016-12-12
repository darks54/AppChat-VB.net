Imports System.Text.RegularExpressions

Public Class Options
    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btn_valider.Click
        If tb_pseudo.Text = "" Then
            MsgBox("Pseudo non renseigné.")
            Exit Sub
        Else
            My.Settings.Pseudo = tb_pseudo.Text
        End If

        If Regex.Match(tb_serveur.Text, "\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", RegexOptions.Singleline).Success Then

            My.Settings.Server = tb_serveur.Text
        Else
            MsgBox("Adresse IP incorrecte.")
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tb_pseudo.Text = My.Settings.Pseudo
        tb_serveur.Text = My.Settings.Server
    End Sub
End Class