Imports System.IO
Imports AxWMPLib
Public Class Form1
    Private Sub GroupBox1_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each inpath In files
            player1.URL = inpath
            Label3.Text = Path.GetFileName(inpath)

            BunifuFlatButton1.Enabled = True
        Next
    End Sub
    Private Sub GroupBox1_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        player1.Hide()
        GroupBox1.AllowDrop = True
        GroupBox2.AllowDrop = True
        GroupBox3.AllowDrop = True
        GroupBox4.AllowDrop = True
        GroupBox5.AllowDrop = True

        Me.KeyPreview = True
        Label1.TextAlign = ContentAlignment.MiddleCenter
        BunifuFlatButton1.TextAlign = ContentAlignment.MiddleCenter
        BunifuFlatButton3.TextAlign = ContentAlignment.MiddleCenter

        If player1.URL = "" Then
            BunifuFlatButton1.Enabled = False
        End If
        If player2.URL = "" Then
            BunifuFlatButton4.Enabled = False
        End If

        BunifuFlatButton6.Enabled = False
        BunifuFlatButton8.Enabled = False
        BunifuFlatButton10.Enabled = False
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If BunifuFlatButton1.Text = "PLAY" Then
            BunifuFlatButton1.Text = "PAUSE"
            player1.Ctlcontrols.play()
            Timer1.Interval = 1000
            Timer1.Start()
        Else
            BunifuFlatButton1.Text = "PLAY"
            player1.Ctlcontrols.pause()
            Timer1.Interval = 1000
            Timer1.Start()
        End If

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        player1.Ctlcontrols.stop()
        BunifuFlatButton1.Text = "PLAY"
    End Sub

    Private Sub BunifuSlider1_ValueChanged(sender As Object, e As EventArgs) Handles BunifuSlider1.ValueChanged
        player1.settings.volume = BunifuSlider1.Value
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            If BunifuFlatButton1.Text = "PLAY" Then
                BunifuFlatButton1.Text = "PAUSE"
                player1.Ctlcontrols.play()
                Timer1.Interval = 1000
                Timer1.Start()
            Else
                BunifuFlatButton1.Text = "PLAY"
                player1.Ctlcontrols.pause()
                Timer1.Interval = 1000
                Timer1.Start()
            End If
        End If
    End Sub


    Public Sub TimerEventProcessor(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim t As Double = Math.Floor(player1.currentMedia.duration - player1.Ctlcontrols.currentPosition)
        Label1.Text = (t.ToString())
        If t = 0 Then
            BunifuFlatButton1.Text = "PLAY"
        End If
    End Sub

    Public Sub TimerEventProcessor1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim t As Double = Math.Floor(player2.currentMedia.duration - player2.Ctlcontrols.currentPosition)
        Label6.Text = (t.ToString())
        If t = 0 Then
            BunifuFlatButton4.Text = "PLAY"
        End If
    End Sub
    Public Sub TimerEventProcessor2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Dim t As Double = Math.Floor(player3.currentMedia.duration - player3.Ctlcontrols.currentPosition)
        Label8.Text = (t.ToString())
        If t = 0 Then
            BunifuFlatButton6.Text = "PLAY"
        End If
    End Sub
    Public Sub TimerEventProcessor3(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        Dim t As Double = Math.Floor(player4.currentMedia.duration - player4.Ctlcontrols.currentPosition)
        Label10.Text = (t.ToString())
        If t = 0 Then
            BunifuFlatButton8.Text = "PLAY"
        End If
    End Sub

    Public Sub TimerEventProcessor4(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        Dim t As Double = Math.Floor(player5.currentMedia.duration - player5.Ctlcontrols.currentPosition)
        Label12.Text = (t.ToString())
        If t = 0 Then
            BunifuFlatButton10.Text = "PLAY"
        End If
    End Sub

    Private Sub BunifuSlider2_ValueChanged(sender As Object, e As EventArgs) Handles BunifuSlider2.ValueChanged
        'BunifuSlider2.Value
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Label3.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        For Each tra As String In OpenFileDialog1.FileNames
            player1.URL = tra
            BunifuFlatButton1.Enabled = True
        Next
    End Sub

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles BunifuCheckbox1.OnChange
        If BunifuCheckbox1.Checked = True Then
            player1.settings.mute = False
            player2.settings.mute = False
            BunifuSlider2.Enabled = True
        Else
            player1.settings.mute = True
            player2.settings.mute = True
            BunifuSlider2.Enabled = False
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk

        Label13.Text = System.IO.Path.GetFileName(OpenFileDialog2.FileName)
        For Each tra As String In OpenFileDialog2.FileNames
            player2.URL = tra
            BunifuFlatButton4.Enabled = True
        Next
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If BunifuFlatButton4.Text = "PLAY" Then
            BunifuFlatButton4.Text = "PAUSE"
            player2.Ctlcontrols.play()
            Timer2.Interval = 1000
            Timer2.Start()
        Else
            BunifuFlatButton4.Text = "PLAY"
            player2.Ctlcontrols.pause()
            Timer2.Interval = 1000
            Timer2.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        player2.Ctlcontrols.stop()
        BunifuFlatButton4.Text = "PLAY"
    End Sub

    Private Sub GroupBox2_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox2.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each inpath In files
            player2.URL = inpath
            Label13.Text = Path.GetFileName(inpath)

            BunifuFlatButton4.Enabled = True
        Next
    End Sub

    Private Sub GroupBox2_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub BunifuVTrackbar1_ValueChanged(sender As Object, e As EventArgs) Handles BunifuVTrackbar1.ValueChanged

        Dim x As Integer = BunifuVTrackbar1.Value - 50

        For index As Integer = 0 To 100
            If BunifuVTrackbar1.Value = index Then
                player2.settings.volume = 100 - index
            End If
        Next

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        If BunifuFlatButton6.Text = "PLAY" Then
            BunifuFlatButton6.Text = "PAUSE"
            player3.Ctlcontrols.play()
            Timer3.Interval = 1000
            Timer3.Start()
        Else
            BunifuFlatButton6.Text = "PLAY"
            player3.Ctlcontrols.pause()
            Timer3.Interval = 1000
            Timer3.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        player3.Ctlcontrols.stop()
        BunifuFlatButton6.Text = "PLAY"
    End Sub

    Private Sub GroupBox3_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox3.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each inpath In files
            player3.URL = inpath
            Label14.Text = Path.GetFileName(inpath)

            BunifuFlatButton6.Enabled = True
        Next
    End Sub

    Private Sub GroupBox3_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub OpenFileDialog3_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog3.FileOk
        Label14.Text = System.IO.Path.GetFileName(OpenFileDialog3.FileName)
        For Each tra As String In OpenFileDialog3.FileNames
            player3.URL = tra
            BunifuFlatButton6.Enabled = True
        Next
    End Sub

    Private Sub BunifuVTrackbar2_ValueChanged(sender As Object, e As EventArgs) Handles BunifuVTrackbar2.ValueChanged
        Dim x As Integer = BunifuVTrackbar2.Value - 50

        For index As Integer = 0 To 100
            If BunifuVTrackbar2.Value = index Then
                player3.settings.volume = 100 - index
            End If
        Next
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        OpenFileDialog3.ShowDialog()
    End Sub

    Private Sub OpenFileDialog4_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog4.FileOk
        Label15.Text = System.IO.Path.GetFileName(OpenFileDialog4.FileName)
        For Each tra As String In OpenFileDialog4.FileNames
            player4.URL = tra
            BunifuFlatButton8.Enabled = True
        Next
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        If BunifuFlatButton8.Text = "PLAY" Then
            BunifuFlatButton8.Text = "PAUSE"
            player4.Ctlcontrols.play()
            Timer4.Interval = 1000
            Timer4.Start()
        Else
            BunifuFlatButton8.Text = "PLAY"
            player4.Ctlcontrols.pause()
            Timer4.Interval = 1000
            Timer4.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        player4.Ctlcontrols.stop()
        BunifuFlatButton8.Text = "PLAY"
    End Sub

    Private Sub BunifuVTrackbar3_ValueChanged(sender As Object, e As EventArgs) Handles BunifuVTrackbar3.ValueChanged
        Dim x As Integer = BunifuVTrackbar3.Value - 50

        For index As Integer = 0 To 100
            If BunifuVTrackbar3.Value = index Then
                player4.settings.volume = 100 - index
            End If
        Next
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        OpenFileDialog4.ShowDialog()
    End Sub

    Private Sub GroupBox4_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox4.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each inpath In files
            player4.URL = inpath
            Label15.Text = Path.GetFileName(inpath)

            BunifuFlatButton8.Enabled = True
        Next
    End Sub

    Private Sub GroupBox4_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox4.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click

        If BunifuFlatButton10.Text = "PLAY" Then
            BunifuFlatButton10.Text = "PAUSE"
            player5.Ctlcontrols.play()
            Timer5.Interval = 1000
            Timer5.Start()
        Else
            BunifuFlatButton10.Text = "PLAY"
            player5.Ctlcontrols.pause()
            Timer5.Interval = 1000
            Timer5.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        player5.Ctlcontrols.stop()
        BunifuFlatButton10.Text = "PLAY"
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        OpenFileDialog5.ShowDialog()
    End Sub

    Private Sub OpenFileDialog5_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog5.FileOk
        Label16.Text = System.IO.Path.GetFileName(OpenFileDialog5.FileName)
        For Each tra As String In OpenFileDialog5.FileNames
            player5.URL = tra
            BunifuFlatButton10.Enabled = True
        Next
    End Sub

    Private Sub BunifuVTrackbar4_ValueChanged(sender As Object, e As EventArgs) Handles BunifuVTrackbar4.ValueChanged
        Dim x As Integer = BunifuVTrackbar4.Value - 50

        For index As Integer = 0 To 100
            If BunifuVTrackbar4.Value = index Then
                player5.settings.volume = 100 - index
            End If
        Next
    End Sub

    Private Sub GroupBox5_DragDrop(sender As Object, e As DragEventArgs) Handles GroupBox5.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each inpath In files
            player5.URL = inpath
            Label16.Text = Path.GetFileName(inpath)

            BunifuFlatButton10.Enabled = True
        Next
    End Sub

    Private Sub GroupBox5_DragEnter(sender As Object, e As DragEventArgs) Handles GroupBox5.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class
