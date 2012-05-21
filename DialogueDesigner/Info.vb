Public Class Info
    Public _text As String = String.Empty
    Public _goodbye As Boolean = False


    Public Sub New()

    End Sub


    Public Sub New(ByVal text As String)
        Me._text = text
    End Sub

    Public Sub New(ByVal text As String, ByVal goodbye As Boolean)
        Me._text = text
        Me._goodbye = goodbye
    End Sub
End Class
