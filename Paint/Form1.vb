Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub
    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim l As New Circle(PictureBox1.Image, m_Previous, e.Location)
            l.w = TrackBar2.Value
            l.h = TrackBar1.Value
            l.Pen = New Pen(c, w)
            m_shapes.Add(l)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub
    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
        Next
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles WidthTrack.Scroll
        w = WidthTrack.Value
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CustomColorButton.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        CustomColorButton.BackColor = c

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles redButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles organgeButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles yellowButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles greenButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles blueButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles purpleButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles blackButton.Click
        c = sender.backcolor
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles whiteButton.Click
        c = sender.backcolor
    End Sub
    Private Sub grayButton_Click(sender As Object, e As EventArgs) Handles grayButton.Click
        c = sender.backcolor
    End Sub
    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub
End Class
