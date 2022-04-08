Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim t As Integer
    Dim type As String
    Dim h As Integer
    Dim w As Integer
    Dim s As Integer
    Dim r As Integer
    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub
    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then
            Dim d As Object

            If type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.xspeed = xSpeedTrack.Value
            End If
            If type = "Rectangle" Then
                d = New MyRectangle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.h = h
                d.w = w
            End If
            If type = "Circle" Then
                d = New Circle(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.w = w
                d.h = h
            End If
            If type = "Arc" Then
                d = New Arc(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.w = w
                d.h = h
            End If
            If type = "Pie" Then
                d = New Pie(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.w = w
                d.h = h
            End If
            If type = "Poly" Then
                d = New Polygon(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.w = w
                d.h = h
            End If
            If type = "n-Gon" Then
                d = New Pentagon(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, t)
                d.s = s
                d.r = r
            End If
            If type = "Picture" Then
                d = New pbox(PictureBox1.Image, m_Previous, e.Location)
                d.picture = drawBox.Image
                d.w = w
                d.h = h
            End If
            If type = "Rectangle Brush" Then
                d = New RectangleBrush(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.h = h
                d.w = w
                d.color1 = fill1Button.BackColor
                d.color2 = fill2Button.BackColor
            End If
            If type = "Circle Brush" Then
                d = New CircleBrush(PictureBox1.Image, m_Previous, e.Location)
                d.Pen = New Pen(c, t)
                d.h = h
                d.w = w
                d.color1 = fill1Button.BackColor
                d.color2 = fill2Button.BackColor
            End If
            m_shapes.Add(d)
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
        If (refreshBox.Checked) Then
            Refresh()
        End If
    End Sub
    Private Sub redButton_Click(sender As Object, e As EventArgs) Handles redButton.Click
        c = sender.backcolor
    End Sub
    Private Sub blueButton_Click(sender As Object, e As EventArgs) Handles blueButton.Click
        c = sender.backcolor
    End Sub
    Private Sub greenButton_Click(sender As Object, e As EventArgs) Handles greenButton.Click
        c = sender.backcolor
    End Sub
    Private Sub blackButton_Click(sender As Object, e As EventArgs) Handles blackButton.Click
        c = sender.backcolor
    End Sub
    Private Sub fill1Button_Click(sender As Object, e As EventArgs) Handles fill1Button.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.backcolor = c
    End Sub
    Private Sub fill2Button_Click_1(sender As Object, e As EventArgs) Handles fill2Button.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        sender.backcolor = c
    End Sub
    Private Sub WidthTrack_Scroll(sender As Object, e As EventArgs) Handles WidthTrack.Scroll
        t = WidthTrack.Value
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        w = TrackBar2.Value
    End Sub
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        h = TrackBar1.Value
    End Sub
    Private Sub radiusBar_Scroll(sender As Object, e As EventArgs) Handles radiusBar.Scroll
        r = radiusBar.Value
    End Sub
    Private Sub sideUpDown_ValueChanged(sender As Object, e As EventArgs) Handles sideUpDown.ValueChanged
        Integer.TryParse(sideUpDown.Value, s)
    End Sub
    Private Sub lineButton_Click(sender As Object, e As EventArgs) Handles lineButton.Click
        type = "Line"
    End Sub
    Private Sub circleButton_Click(sender As Object, e As EventArgs) Handles circleButton.Click
        type = "Circle"
    End Sub
    Private Sub arcsButton_Click(sender As Object, e As EventArgs) Handles arcsButton.Click
        type = "Arc"
    End Sub
    Private Sub nGonButton_Click(sender As Object, e As EventArgs) Handles nGonButton.Click
        type = "n-Gon"
    End Sub
    Private Sub piesButton_Click(sender As Object, e As EventArgs) Handles piesButton.Click
        type = "Pie"
    End Sub
    Private Sub rectsButton_Click(sender As Object, e As EventArgs) Handles rectsButton.Click
        type = "Rectangle"
    End Sub
    Private Sub triButton_Click(sender As Object, e As EventArgs) Handles triButton.Click
        type = "Poly"
    End Sub
    Private Sub drawBox_Click(sender As Object, e As EventArgs) Handles drawBox.Click
        type = "Picture"
    End Sub
    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        type = "Rectangle Brush"
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        type = "Circle Brush"
    End Sub
    Private Sub imageinsert_Click(sender As Object, e As EventArgs) Handles imageinsert.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        drawBox.Load(OpenFileDialog1.FileName)
    End Sub
    Private Sub saveButton_Click_1(sender As Object, e As EventArgs) Handles saveButton.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub
    Private Sub clearButton_Click_1(sender As Object, e As EventArgs) Handles clearButton.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub
End Class
