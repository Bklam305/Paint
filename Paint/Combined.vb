Public Class Combined
    Public Property Pen As Pen
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Dim points(2) As Point
    Public Property w As Integer
    Public Property h As Integer
    Public Property color1 As Color
    Public Sub New(i As Image, a As Point, b As Point)
        Pen = Pens.Red
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Dim frac As Integer
        frac = m_a.X - (41 / 2)
        Dim dec As Integer
        dec = m_a.Y - (41 / 2)
        Using g As Graphics = Graphics.FromImage(m_image)
            points(0) = New Point(m_a.X, m_a.Y)
            points(1) = New Point(m_a.X, m_a.Y - h)
            points(2) = New Point(m_a.X - w, m_a.Y)
            g.FillEllipse(New SolidBrush(color1), frac, dec, w, h)
            g.FillPolygon(New SolidBrush(color1), points)
        End Using
    End Sub
End Class
