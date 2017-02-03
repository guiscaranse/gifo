
Public Class Form2
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Dim animatedImage As New Bitmap("c://1.gif")
    Dim currentlyAnimating As Boolean = False
    Dim framecounter As Integer = 0
    Dim framecount As Integer
    Dim framdim As Imaging.FrameDimension
    Dim statusali As String
    Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)
        PictureBox1.Invalidate()
    End Sub

    Sub AnimateImage()
        Timer2.Start()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

        If statusali = "1" Then
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

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Timer1.Start()
        statusali = "1"
        framdim = New Imaging.FrameDimension(animatedImage.FrameDimensionsList(0))
        framecount = animatedImage.GetFrameCount(framdim)
        Timer1.Start()


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendMessage(ProgressBar1.Handle, 1040, 3, 0)
        ProgressBar1.Maximum = framecount + 1
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = ProgressBar1.Maximum
        Else
            ProgressBar1.Value = framecounter
        End If
        Label1.Text = framecounter
        Label2.Text = statusali
        Label3.Text = framecount

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If statusali = "3" Then
            statusali = "1"
            Button1.Text = "Stop"
        Else
            Button1.Text = "Start"
            statusali = "3"
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Not currentlyAnimating Then
            ImageAnimator.Animate(animatedImage, New EventHandler(AddressOf Me.OnFrameChanged))
            currentlyAnimating = True
        End If
    End Sub
End Class