Public Class Dialogue
    Public _topics As List(Of Topic) = New List(Of Topic)
    Public _id As String = String.Empty

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String)
        Me._id = id
    End Sub

    Public Sub New(ByVal id As String, ByVal topics As List(Of Topic))
        Me._id = id
        Me._topics = topics
    End Sub
End Class
