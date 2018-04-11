Imports System.IO
Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class Serveur

    Private lgMessage As Integer = 1000
    Private portServeur As Integer = 33000
    Private portClient As Integer = 33001
    Private adrIpLocale As IPAddress
    Private separateur As Char()
    Private sockReception As Socket
    Private epRecepteur As IPEndPoint
    Private messageBytes As Byte()
    Private users As New List(Of User)
    Private salons As New List(Of Salon)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon.Icon = Me.Icon
        CheckForIllegalCrossThreadCalls = False
        initReception()
    End Sub

    Private Function getAdrIpLocaleV4() As IPAddress
        Dim hote As String = Dns.GetHostName()
        Dim ipLocales As IPHostEntry = Dns.GetHostEntry(hote)
        For Each ip As IPAddress In ipLocales.AddressList
            If ip.AddressFamily = AddressFamily.InterNetwork Then
                Return ip
            End If
        Next
        Return Nothing
    End Function

    Private Sub initReception()
        messageBytes = New Byte(lgMessage - 1) {}
        adrIpLocale = getAdrIpLocaleV4()
        separateur = New Char(0) {}
        separateur(0) = "#"c
        sockReception = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        epRecepteur = New IPEndPoint(adrIpLocale, portServeur)
        sockReception.Bind(epRecepteur)
        Dim epTemp As EndPoint = DirectCast(New IPEndPoint(IPAddress.Any, 0), EndPoint)
        sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
    End Sub

    Private Sub envoyerBroadcast(pseudo As String, texte As String)
        Dim messageBroadcast As Byte()
        Dim sockEmission As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        sockEmission.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
        Dim epEmetteur As New IPEndPoint(adrIpLocale, 0)
        sockEmission.Bind(epEmetteur)
        Dim epRecepteur As New IPEndPoint(IPAddress.Broadcast, portClient)
        Dim strMessage As String = "R" & "#" & pseudo & "#" & texte
        messageBroadcast = Encoding.Unicode.GetBytes(strMessage)
        sockEmission.SendTo(messageBroadcast, epRecepteur)
        sockEmission.Close()
    End Sub

    Private Sub envoyerBroadcastInfo(texte As String)
        Dim messageBroadcast As Byte()
        Dim sockEmission As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        sockEmission.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
        Dim epEmetteur As New IPEndPoint(adrIpLocale, 0)
        sockEmission.Bind(epEmetteur)
        Dim epRecepteur As New IPEndPoint(IPAddress.Broadcast, portClient)
        Dim strMessage As String = "I" & "#" & texte
        messageBroadcast = Encoding.Unicode.GetBytes(strMessage)
        sockEmission.SendTo(messageBroadcast, epRecepteur)
        sockEmission.Close()
    End Sub

    Private Sub envoyerBroadcastUsers()
        Dim messageBroadcast As Byte()
        Dim sockEmission As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        sockEmission.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
        Dim epEmetteur As New IPEndPoint(adrIpLocale, 0)
        sockEmission.Bind(epEmetteur)
        Dim epRecepteur As New IPEndPoint(IPAddress.Broadcast, portClient)
        Dim value As New List(Of String)
        For Each item In users
            value.Add(item.Pseudo & "," & item.Id)
        Next
        Dim strMessage As String = "L" & "#" & String.Join("/", value.ToArray)
        messageBroadcast = Encoding.Unicode.GetBytes(strMessage)
        sockEmission.SendTo(messageBroadcast, epRecepteur)
        sockEmission.Close()
    End Sub

    Private Sub recevoir(AR As IAsyncResult)
        Dim epTemp As EndPoint = DirectCast(New IPEndPoint(IPAddress.Any, 0), EndPoint)
        sockReception.EndReceiveFrom(AR, epTemp)

        Dim strMessage As String = Encoding.Unicode.GetString(messageBytes, 0, messageBytes.Length)
        Dim tabElements As String()
        tabElements = strMessage.Replace(vbNullChar, "").Split(separateur, StringSplitOptions.RemoveEmptyEntries)
        Console.WriteLine(tabElements(0))
        Select Case tabElements(0)
            Case "C"
                Dim user As New User(tabElements(1), tabElements(2), IPAddress.Parse(tabElements(3)))
                users.Add(user)
                lb_clients.Items.Add(tabElements(1))
                envoyerBroadcastUsers()
                Exit Select
            Case "E"
                envoyerBroadcast(tabElements(1), tabElements(2))
                Exit Select
            Case "D"
                users.Remove(users.Find(Function(c) c.Id = tabElements(2)))
                lb_clients.Items.Remove(tabElements(1))
                envoyerBroadcastUsers()
                Exit Select
            Case "S"
                Dim salon As New Salon(tabElements(2))
                salon.Users.Add(users.Find(Function(c) c.Id = tabElements(3)))
                salon.Users.Add(users.Find(Function(c) c.Id = tabElements(4)))
                salons.Add(salon)
                lb_clients.Items.Remove(tabElements(1))
                envoyerBroadcastUsers()
                Exit Select
            Case "Q"
                Dim salon = salons.Find(Function(c) c.Id = tabElements(2))
                salon.Users.Remove(salon.Users.Find(Function(c) c.Id = tabElements(3)))

                'envoyerBroadcastUsers()
                Exit Select
        End Select
        Array.Clear(messageBytes, 0, messageBytes.Length)
        sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            Me.Visible = False
            NotifyIcon.Visible = True

            With NotifyIcon
                .BalloonTipIcon = ToolTipIcon.Info
                .BalloonTipTitle = "Serveur de messagerie"
                .BalloonTipText = "Le serveur est accessible depuis la zone de notification."
            End With
            NotifyIcon.ShowBalloonTip(2000)

        End If
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub AfficherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfficherToolStripMenuItem.Click
        Me.ShowInTaskbar = True
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False
    End Sub

    Private Sub NotifyIcon_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon.DoubleClick
        Me.ShowInTaskbar = True
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False
    End Sub
End Class
