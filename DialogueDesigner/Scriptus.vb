Public Class Scriptus

    Private path As String = Application.StartupPath & "\Scripts.br2"
    Private lines() As String = Nothing
    Private scriptlib As List(Of Script) = New List(Of Script)

    Public currentScript As Script = Nothing

    Private Sub Scriptus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lines = System.IO.File.ReadAllLines(path)
        Catch ex As Exception
            Debug.Print(ex.ToString)
            MsgBox("ERROR OPENING SCRIPT FILE.")
            Me.Close()
        End Try

        readScripts()
        fillCB()
        cbScripts.SelectedIndex = 0
    End Sub





    Private Sub fillCB()

        Dim sel As Integer = 0

        sel = cbScripts.SelectedIndex

        cbScripts.Items.Clear()
        cbScripts.Items.Add("___NONE")

        For Each s As Script In scriptlib

            cbScripts.Items.Add(s._name)

        Next

        cbScripts.Sorted = True
        cbScripts.SelectedIndex = sel

    End Sub



    Private Sub readScripts()

        scriptlib.Clear()

        For s As Integer = 0 To lines.Count - 1

            Dim line As String = lines(s).Trim

            If line.StartsWith("@SCRIPT") Then

                scriptlib.Add(New Script(line.Substring(8)))

                s += 1

                While Not (lines(s).Trim.StartsWith("@SCRIPT"))

                    scriptlib(scriptlib.Count - 1).cmds.Add(lines(s).Trim)
                    s += 1

                    If s > lines.Length - 1 Then
                        Exit While
                    End If

                End While

                s -= 1


            End If

        Next

    End Sub







    Private Sub cbScripts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbScripts.SelectedIndexChanged

        If cbScripts.SelectedIndex = 0 Then
            rtb.Text = String.Empty
            currentScript = Nothing
            Return
        End If

        For Each s As Script In scriptlib

            If s._name = cbScripts.SelectedItem.ToString Then

                currentScript = s

                rtb.Text = String.Empty

                For Each v As String In s.cmds

                    rtb.Text = rtb.Text & v & vbNewLine

                Next

            End If

        Next

    End Sub






    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Dim s As String = InputBox("Script ID", "Scriptus")

        If s Is Nothing Then
            Return
        End If

        scriptlib.Add(New Script(s))

        fillCB()



    End Sub







    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If cbScripts.SelectedIndex = 0 Then
            Return
        End If

        For Each s As Script In scriptlib

            If s._name = cbScripts.SelectedItem.ToString Then

                For Each l As String In rtb.Lines
                    s.cmds.Add(l)
                Next

            End If

        Next



        Dim b As System.Text.StringBuilder = New System.Text.StringBuilder()

        For Each s As Script In scriptlib

            b.AppendLine("@SCRIPT " & s._name)

            For Each t As String In s.cmds

                b.AppendLine(vbTab & t)

            Next

        Next



        Try
            If System.IO.File.Exists(path & ".bak") Then
                System.IO.File.Delete(path & ".bak")
            End If
            System.IO.File.Copy(path, path & ".bak")
            System.IO.File.WriteAllText(path, b.ToString)
        Catch ex As Exception
            Debug.Print(ex.ToString)
            Return
        End Try

        MsgBox("Erfolgreich gespeichert!")

    End Sub



End Class