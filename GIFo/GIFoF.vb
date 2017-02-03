Public Class GIFoF
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Dim image As String = Launcher.path
    Dim animatedImage As New Bitmap(image)
    Dim currentlyAnimating As Boolean = False
    Dim framecounter As Integer = 0
    Dim framecount As Integer
    Dim framdim As Imaging.FrameDimension

    Dim pause As Boolean = False

    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)
        PictureBox1.Invalidate()
    End Sub

    Sub AnimateImage()
        Drawer.Start()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

        If pause = False Then
            AnimateImage()
            ImageAnimator.UpdateFrames()
            e.Graphics.DrawImage(Me.animatedImage, New Point(0, 0))
            framecounter += 1
            If framecounter > framecount Then
                framecounter = 0

            End If
        Else
            AnimateImage()
            e.Graphics.DrawImage(Me.animatedImage, New Point(0, 0))
            framecounter += 1
            If framecounter > framecount Then
                framecounter = 0
            End If
        End If

    End Sub

    Private Sub GIFoF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Options.Start()
        Me.CenterToScreen()
        Guardian.Start()
        framdim = New Imaging.FrameDimension(animatedImage.FrameDimensionsList(0))
        framecount = animatedImage.GetFrameCount(framdim)
    End Sub

    Private Sub Guardian_Tick(sender As Object, e As EventArgs) Handles Guardian.Tick
        Me.Height = My.Settings.imgheight
        Me.Width = My.Settings.imgwidth

        PictureBox2.Location = New Point((Me.DisplayRectangle.Width - PictureBox2.Width) / 2, My.Settings.imgheight / 2
                                         )
        If ControlsToolStripMenuItem.Checked Then
            ProgressBar1.Visible = False
            PictureBox2.Visible = True
        Else

            ProgressBar1.Visible = False
            PictureBox2.Visible = False

        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub


    Private Sub Drawer_Tick(sender As Object, e As EventArgs) Handles Drawer.Tick
        If Not currentlyAnimating Then
            ImageAnimator.Animate(animatedImage, New EventHandler(AddressOf Me.OnFrameChanged))
            currentlyAnimating = True
        End If
    End Sub

    Private Sub ControlsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlsToolStripMenuItem.Click

    End Sub

    Private Sub Options_Tick(sender As Object, e As EventArgs) Handles Options.Tick
        Me.PictureBox2.Parent = Me.PictureBox1
        SendMessage(ProgressBar1.Handle, 1040, 3, 0)
        ProgressBar1.Maximum = framecount + 1
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = ProgressBar1.Maximum
        Else
            ProgressBar1.Value = framecounter
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        If pause = True Then
            'unpause
            pause = False
            PictureBox2.Image = My.Resources.stop_5c5252_100

        Else
            'pause
            pause = True
            PictureBox2.Image = My.Resources.play_5c5252_100
        End If
    End Sub

    Private Sub OenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OenToolStripMenuItem.Click
        Launcher.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If pause = True Then
            'unpause
            pause = False
            PictureBox2.BackgroundImage = My.Resources.stop_5c5252_100

        Else
            'pause
            pause = True
            PictureBox2.BackgroundImage = My.Resources.play_5c5252_100
        End If
    End Sub
End Class