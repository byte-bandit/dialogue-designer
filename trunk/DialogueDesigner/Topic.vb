Public Class Topic
    Public _info As List(Of Info) = New List(Of Info)
    Public _text As String = String.Empty
    Public _choice As List(Of Topic) = New List(Of Topic)
    Public _id As String = String.Empty
    Public _trigger As Script = Nothing


    Public Sub New()

    End Sub


    Public Sub New(ByVal id As String)

        Me._id = id

    End Sub

    Public Sub New(ByVal id As String, ByVal text As String, Optional ByVal choice As List(Of Topic) = Nothing, Optional ByVal info As List(Of Info) = Nothing)

        If choice Is Nothing Then

            choice = New List(Of Topic)

        End If

        Me._text = text
        Me._choice = choice
        Me._id = id

        If (info IsNot Nothing) Then
            Me._info = info
        End If
    End Sub
End Class