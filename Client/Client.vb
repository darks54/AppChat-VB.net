Imports System.IO
Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Runtime.InteropServices

Public Class Client

    Dim Client As TcpClient
    Private adrIpLocale As IPAddress
    Private separateur As String
    Private ipServeur As IPAddress = IPAddress.Parse("172.16.1.128")
    Private portServeur As Integer = 33000
    Private portClient As Integer = 33001
    Private lgMessage As Integer = 1000
    Private sockReception As Socket
    Private epRecepteur As IPEndPoint
    Dim messageBytes() As Byte


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        adrIpLocale = getAdrIpLocalV4()
        separateur = "#"
    End Sub

    Private Sub bt_connecter_Click(sender As Object, e As EventArgs) Handles bt_connecter.Click
        If Not tb_pseudo.Text = "" Then
            bt_connecter.Enabled = False
            tb_pseudo.Enabled = False
            envoyer("C", "")
            bt_envoyer.Enabled = True
            tb_message.Enabled = True
            initReception()
            tb_message.Focus()
        End If
    End Sub

    Private Sub bt_envoyer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_envoyer.Click
        envoyer("E", tb_message.Text)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        envoyer("D", "")
    End Sub

    Private Function getAdrIpLocalV4()
        Dim hote As String = Dns.GetHostName()
        Dim ipLocales As IPHostEntry = Dns.GetHostEntry(hote)
        For Each ip As IPAddress In ipLocales.AddressList
            If ip.AddressFamily = AddressFamily.InterNetwork Then
                Return ip
            End If
        Next
        Return Nothing

    End Function

    Private Sub envoyer(ByVal typeMessage As String, texte As String)
        Dim messageBytes() As Byte
        Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim epEmetteur As IPEndPoint = New IPEndPoint(adrIpLocale, 0)
        sock.Bind(epEmetteur)
        Dim epRecepteur As IPEndPoint = New IPEndPoint(ipServeur, portServeur)
        Dim infos As String = typeMessage & "#" & tb_pseudo.Text & "#" & texte & "#"

        messageBytes = Encoding.Unicode.GetBytes(infos)
        sock.SendTo(messageBytes, epRecepteur)
        sock.Close()
        tb_message.Clear()
        tb_message.Focus()
    End Sub

    Private Sub initReception()
        messageBytes = New Byte(lgMessage - 1) {}
        sockReception = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        epRecepteur = New IPEndPoint(adrIpLocale, portClient)
        sockReception.Bind(epRecepteur)
        Dim epTemp As EndPoint = New IPEndPoint(IPAddress.Any, 0)
        sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
    End Sub

    Private Sub recevoir(AR As IAsyncResult)
        Dim epTemp As EndPoint = DirectCast(New IPEndPoint(IPAddress.Any, 0), EndPoint)
        sockReception.EndReceiveFrom(AR, epTemp)

        Dim strMessage As String = Encoding.Unicode.GetString(messageBytes, 0, messageBytes.Length)
        Dim tabElements As String()
        tabElements = strMessage.Split("#")
        Select Case tabElements(0)
            Case "R"
                lb_messages.Items.Add(tabElements(1) + " -> " + tabElements(2))
                FlashIcon(MyBase.Handle, FLASHW_TRAY + FLASHW_TIMERNOFG)
                Exit Select
            Case "I"
                lb_messages.Items.Add(tabElements(1))
                FlashIcon(MyBase.Handle, FLASHW_TRAY + FLASHW_TIMERNOFG)
                Exit Select
        End Select
        Array.Clear(messageBytes, 0, messageBytes.Length)
        sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
    End Sub

    Public Structure FLASHWINFO
        Public cbSize As Int32
        Public hwnd As IntPtr
        Public dwFlags As Int32
        Public uCount As Int32
        Public dwTimeout As Int32
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Ansi, ExactSpelling:=True, SetLastError:=False, EntryPoint:="FlashWindowEx")>
    Public Shared Function FlashWindowEx(ByRef pfwi As FLASHWINFO) As Int32
    End Function

    Public Const FLASHW_STOP = 0        ' Stop flashing. The system restores the window to its original state. 
    Public Const FLASHW_CAPTION = &H1   ' Flash the window caption. 
    Public Const FLASHW_TRAY = &H2      ' Flash the taskbar button.
    Public Const FLASHW_ALL = &H3       ' Flash both the window caption and taskbar button. 
    Public Const FLASHW_TIMER = &H4     ' Flash continuously, until the FLASHW_STOP flag is set. 
    Public Const FLASHW_TIMERNOFG = &HC ' Flash continuously until the window comes to the foreground. 

    Public Sub FlashIcon(ByVal Handle%, ByVal Flags%)
        Dim flash As New FLASHWINFO
        flash.cbSize = Marshal.SizeOf(flash) '/// size of structure in bytes
        flash.hwnd = Handle '/// Handle to the window to be flashed
        flash.dwFlags = Flags
        flash.dwTimeout = 500 '/// speed of flashes in MilliSeconds ( can be left out )
        FlashWindowEx(flash) '/// flash the window 
    End Sub

End Class

