Imports System.IO
Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Runtime.InteropServices

Public Class Client

    'Dim Client As TcpClient
    Private adrIpLocale As IPAddress
    Private ipServeur As IPAddress
    Private portServeur As Integer = 33000
    Private portClient As Integer = 33001
    Private lgMessage As Integer = 1000
    Private sockReception As Socket
    Private epRecepteur As IPEndPoint
    Dim messageBytes() As Byte
    Dim deco As Boolean = False

    Private id As String
    Private users As New List(Of User)
    Private salons As New List(Of Salon)
    Private idCurrentSalon As String = ""

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        adrIpLocale = getAdrIpLocalV4()
        If My.Settings.Pseudo = "" And My.Settings.Server = "" Then
            Dim options As New Options
            If options.ShowDialog() = DialogResult.Cancel Then
                End
            End If
        End If
        Init()

    End Sub

    Private Sub bt_envoyer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_envoyer.Click
        envoyerMessage(tb_message.Text, tb_message.Text)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        deconnexion()
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

    Private Sub connexion()
        envoyer("C#" & My.Settings.Pseudo & "#" & id & "#" & adrIpLocale.ToString)
    End Sub

    Private Sub deconnexion()
        deco = True
        envoyer("D#" & My.Settings.Pseudo & "#" & id)
    End Sub

    Private Sub envoyerMessage(ByVal texte As String, ByVal idSalon As String)
        envoyer("E#" & My.Settings.Pseudo & "#" & idSalon & "#" & texte)
    End Sub

    Private Sub creerSalon(ByVal idInvite As String)
        Dim idSalon = Guid.NewGuid().ToString
        envoyer("S#" & My.Settings.Pseudo & "#" & idSalon & "#" & id & "#" & idInvite)
        idCurrentSalon = idSalon
    End Sub

    Private Sub envoyer(infos As String)
        Dim messageBytes() As Byte
        Dim sock As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim epEmetteur As IPEndPoint = New IPEndPoint(adrIpLocale, 0)
        sock.Bind(epEmetteur)
        Dim epRecepteur As IPEndPoint = New IPEndPoint(ipServeur, portServeur)
        messageBytes = Encoding.Unicode.GetBytes(infos)
        sock.SendTo(messageBytes, epRecepteur)
        sock.Close()
        tb_message.Clear()
        tb_message.Focus()
    End Sub

    Private Sub initReception()
        Try
            messageBytes = New Byte(lgMessage - 1) {}
            sockReception = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            epRecepteur = New IPEndPoint(adrIpLocale, portClient)
            sockReception.Bind(epRecepteur)
            Dim epTemp As EndPoint = New IPEndPoint(IPAddress.Any, 0)
            sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
        Catch ex As Exception
            MsgBox(ex)
            If Options.ShowDialog() = DialogResult.Cancel Then
                End
            End If
            Init()
        End Try
    End Sub

    Private Sub recevoir(AR As IAsyncResult)
        Dim epTemp As EndPoint = DirectCast(New IPEndPoint(IPAddress.Any, 0), EndPoint)
        sockReception.EndReceiveFrom(AR, epTemp)

        Dim strMessage As String = Encoding.Unicode.GetString(messageBytes, 0, messageBytes.Length)
        Dim tabElements As String()
        tabElements = strMessage.Replace(vbNullChar, "").Split("#")
        Select Case tabElements(0)
            Case "R"
                lb_messages.Items.Add(tabElements(1) + " -> " + tabElements(2))
                FlashIcon(MyBase.Handle, FLASHW_TRAY + FLASHW_TIMERNOFG)
                Exit Select
            Case "L"
                users.Clear()
                For Each item In tabElements(1).Split({"/"c}, StringSplitOptions.RemoveEmptyEntries)
                    If Not item.Split(",")(1) = id Then
                        Dim user As New User(item.Split(",")(0), item.Split(",")(1))
                        users.Add(user)
                    End If
                Next
                If Not deco Then
                    ajoutPseudo()
                End If

                'FlashIcon(MyBase.Handle, FLASHW_TRAY + FLASHW_TIMERNOFG)
                Exit Select
        End Select
        Array.Clear(messageBytes, 0, messageBytes.Length)
        sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, epTemp, New AsyncCallback(AddressOf recevoir), Nothing)
    End Sub

    Public Delegate Sub MaMethodeCallBack()
    Public Sub ajoutPseudo()

        If Me.InvokeRequired Then
            Me.Invoke(New MaMethodeCallBack(AddressOf ajoutPseudo))
        Else
            flp_pseudo.Controls.Clear()
            For Each item In users
                Dim label As New Label
                label.Text = item.Pseudo
                label.Name = item.Id
                label.AutoSize = True
                AddHandler label.MouseEnter, AddressOf pseudo_MouseEnter
                label.ContextMenuStrip = ContextMenuStrip1
                flp_pseudo.Controls.Add(label)
            Next
        End If
    End Sub

    Public Sub pseudo_MouseEnter(ByVal sender As Label, ByVal e As System.EventArgs)
        For Each item In flp_pseudo.Controls
            Dim label = CType(item, Label)
            label.BackColor = SystemColors.Control
            sender.ForeColor = SystemColors.ControlText
        Next
        sender.BackColor = SystemColors.Highlight
        sender.ForeColor = SystemColors.HighlightText
    End Sub

    Private Sub Init()
        ipServeur = IPAddress.Parse(My.Settings.Server)
        initReception()
        id = Guid.NewGuid().ToString
        connexion()
        tb_message.Focus()
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

    Private Sub InviterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InviterToolStripMenuItem.Click

    End Sub

    Private Sub ChuchoterToolStripTextBox_Click(sender As Object, e As EventArgs) Handles ChuchoterToolStripTextBox.Click
        Dim label = CType(CType(CType(sender, ToolStripMenuItem).Owner, ContextMenuStrip).SourceControl, Label)
        creerSalon(label.Name)
    End Sub
End Class

