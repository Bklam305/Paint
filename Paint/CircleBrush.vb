﻿Public Class CircleBrush
    Public Property Pen As Pen
    Public Property color1 As Color
    Public Property color2 As Color

    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Property w As Integer
    Public Property h As Integer
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            Dim lingrBrush As Drawing.Drawing2D.LinearGradientBrush
            lingrBrush = New Drawing.Drawing2D.LinearGradientBrush(
                            New Point(0, 10),
                            New Point(200, 10),
                            color1,
                            color2)
            g.FillEllipse(lingrBrush, m_a.X, m_a.Y, h, w)
        End Using
    End Sub
End Class
