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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub redButton_Click(sender As Object, e As EventArgs) Handles redButton.Click
        c = sender.backcolor
        ClosePanel()
    End Sub
    Private Sub blueButton_Click(sender As Object, e As EventArgs) Handles blueButton.Click
        c = sender.backcolor
        ClosePanel()
    End Sub
    Private Sub greenButton_Click(sender As Object, e As EventArgs) Handles greenButton.Click
        c = sender.backcolor
        ClosePanel()
    End Sub
    Private Sub blackButton_Click(sender As Object, e As EventArgs) Handles blackButton.Click
        c = sender.backcolor
        ClosePanel()
    End Sub
    Private Sub fill1Button_Click(sender As Object, e As EventArgs) Handles fill1Button.Click
        CloseColorPanel()
        sender.backcolor = c
    End Sub
    Private Sub fill2Button_Click(sender As Object, e As EventArgs) Handles fill2Button.Click
        CloseColorPanel()
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
        TrackBar2.Value = 0
        TrackBar1.Value = 0
        Panel1.Visible = True
        TrackBar1.Visible = False
        TrackBar2.Visible = False
        radiusBar.Visible = False
        radiusLabel.Visible = False
        sideUpDown.Visible = False
        Label6.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Panel2.Visible = False
    End Sub
    Private Sub nGonButton_Click(sender As Object, e As EventArgs) Handles nGonButton.Click
        type = "n-Gon"
        TrackBar2.Value = 0
        TrackBar1.Value = 0
        Panel1.Visible = True
        Panel2.Visible = True
        radiusBar.Visible = True
        radiusLabel.Visible = True
        sideUpDown.Visible = True
        Label6.Visible = True
    End Sub
    Private Sub circleButton_Click(sender As Object, e As EventArgs) Handles circleButton.Click
        type = "Circle"
        MainPanel()
    End Sub
    Private Sub arcsButton_Click(sender As Object, e As EventArgs) Handles arcsButton.Click
        type = "Arc"
        MainPanel()
    End Sub
    Private Sub piesButton_Click(sender As Object, e As EventArgs) Handles piesButton.Click
        type = "Pie"
        MainPanel()
    End Sub
    Private Sub rectsButton_Click(sender As Object, e As EventArgs) Handles rectsButton.Click
        type = "Rectangle"
        MainPanel()
    End Sub
    Private Sub triButton_Click(sender As Object, e As EventArgs) Handles triButton.Click
        type = "Poly"
        MainPanel()
    End Sub
    Private Sub drawBox_Click(sender As Object, e As EventArgs) Handles drawBox.Click
        type = "Picture"
        MainPanel()
    End Sub
    Private Sub circleBrush_Click(sender As Object, e As EventArgs) Handles circleBrush.Click
        type = "Circle Brush"
        MainPanel()
    End Sub
    Private Sub squareBrush_Click(sender As Object, e As EventArgs) Handles squareBrush.Click
        type = "Rectangle Brush"
        MainPanel()
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
        fill2Button.BackColor = Color.White
        fill1Button.BackColor = Color.White
    End Sub
    Sub MainPanel()
        TrackBar1.Visible = True
        TrackBar2.Visible = True
        TrackBar2.Value = 0
        TrackBar1.Value = 0
        Panel1.Visible = True
        radiusBar.Visible = False
        radiusLabel.Visible = False
        sideUpDown.Visible = False
        Label6.Visible = False
        Label2.Visible = True
        Label3.Visible = True
        Panel2.Visible = False
    End Sub
    Sub ClosePanel()
        If WidthTrack.Value <= 0 & TrackBar1.Value <= 0 Then
            Panel1.Visible = False
        End If
        If xSpeedTrack.Value <= 0 & WidthTrack.Value <= 0 Then
            Panel1.Visible = False
        End If
        If radiusBar.Value <= 0 & sideUpDown.Value <= 0 Then
            Panel2.Visible = False
        End If
    End Sub
    Sub CloseColorPanel()
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        If WidthTrack.Value <= 0 & TrackBar1.Value <= 0 Then
            Panel1.Visible = False
        End If
        If xSpeedTrack.Value <= 0 & WidthTrack.Value <= 0 Then
            Panel1.Visible = False
        End If
        If radiusBar.Value <= 0 & sideUpDown.Value <= 0 Then
            Panel2.Visible = False
        End If
    End Sub
End Class
