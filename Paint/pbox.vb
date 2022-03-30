Public Class pbox
    Public Property Picture As Image
    Dim m_image As Image
    Dim m_a As Point
    Dim m_b As Point
    Public Property h As Integer
    Public Property w As Integer
    Public Sub New(i As Image, a As Point, b As Point)
        m_image = i
        m_a = a
        m_b = b
    End Sub
    Public Sub Draw()
        Using g As Graphics = Graphics.FromImage(m_image)
            g.DrawImage(Picture, m_a.X, m_b.Y, w, h)
        End Using
    End Sub
End Class
