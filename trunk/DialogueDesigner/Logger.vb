Public Class Logger

    Private path As String = Application.StartupPath & "\log.txt"
    Private stream As System.IO.StreamWriter = Nothing

    Public Sub init()

        If System.IO.File.Exists(path) Then
            System.IO.File.Delete(path)
        End If

        stream = System.IO.File.AppendText(path)

    End Sub



    Public Sub closing()
        stream.Close()
    End Sub


    Public Sub log(ByVal value As String)

        Try
            stream.Write(value)
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try

    End Sub


End Class
