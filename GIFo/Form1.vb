Public Class Form1
    Dim detector As String
    Dim path As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        For i As Integer = 0 To CommandLineArgs.Count - 1
            detector = "1"
            path = CommandLineArgs(i)
        Next
        Label1.Visible = False
        Me.CenterToScreen()
        Timer1.Stop()
        Me.OpenFileDialog1.Filter = "GIF files (*.gif)|*.gif"
        If detector = "1" Then
            Me.PictureBox1.Image = Image.FromFile(path)
            Timer2.Start()

        Else
            Me.OpenFileDialog1.ShowDialog()
        End If
        'Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Me.Width = PictureBox1.Image.Size.Width
        Me.Height = PictureBox1.Image.Size.Height + "63"
    End Sub


    Private Sub OpenAnotherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenAnotherToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Label1.Text = Me.OpenFileDialog1.FileName


        Me.PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Timer1.Start()

        If Label1.Text = "" Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Me.Width = PictureBox1.Image.Size.Width
        Me.Height = PictureBox1.Image.Size.Height + "63"
    End Sub
End Class
