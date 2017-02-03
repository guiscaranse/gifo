Public Class Launcher
    Dim detector As String = 0
    Public path As String
    Public imagewidth As String
    Public imageheight As String

    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        For i As Integer = 0 To CommandLineArgs.Count - 1
            detector = "1"
            path = CommandLineArgs(i)
        Next
 
        Me.OpenFileDialog1.Filter = "GIF files (*.gif)|*.gif"

        If detector = "1" Then
            Me.PictureBox1.Image = Image.FromFile(path)

            My.Settings.imgwidth = Me.PictureBox1.Image.Size.Width
            My.Settings.imgheight = Me.PictureBox1.Image.Size.Height + "63"


            GIFoF.Show()
            Me.Close()
        Else
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Else
                Me.Close()

            End If
            Timer1.Start()

        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Me.PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        path = OpenFileDialog1.FileName
        My.Settings.imgwidth = Me.PictureBox1.Image.Size.Width
        My.Settings.imgheight = Me.PictureBox1.Image.Size.Height + "63"

        GIFoF.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        
    End Sub
End Class