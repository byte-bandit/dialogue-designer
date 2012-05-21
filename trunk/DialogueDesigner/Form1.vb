Public Class Form1

    Dim dialogueArray() As String
    Dim dialogLib As List(Of Dialogue) = New List(Of Dialogue)
    Dim path As String = Application.StartupPath & "\Dialogues.txt"
    Dim scriptus_inst As Scriptus = New Scriptus()






    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Select Case MsgBox("Speichern vor dem Beenden?", MsgBoxStyle.YesNoCancel, "Dialogue Designer")

            Case MsgBoxResult.Yes
                btnSave_Click(Nothing, Nothing)

            Case MsgBoxResult.Cancel
                e.Cancel = True

        End Select


    End Sub







    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getDialoguesFromTextFile()
        fillDialoguesComboBox()
    End Sub




    Private Sub getDialoguesFromTextFile()
        Try
            dialogueArray = System.IO.File.ReadAllLines(path)
        Catch ex As Exception
            MsgBox("Could not find Dialogues.txt. Exiting.", MsgBoxStyle.Critical, Me.Name)
            Me.Close()
            Return
        End Try

        Dim cuD As Dialogue = Nothing
        Dim cuT As Topic = Nothing
        Dim choices As List(Of KeyValuePair(Of Topic, String)) = New List(Of KeyValuePair(Of Topic, String))

        For s As Integer = 0 To dialogueArray.Length - 1

            Dim line As String = dialogueArray(s).Trim()
            Dim lines() As String = line.Split(Chr(34))

            If lines.Length = 1 Then

                'We have no "" arguments -> Dialogue or Goto or Trigger
                Dim parts() As String = lines(0).Split(" ")

                'Do we have a new Dialogue
                If parts(0) = "@DIALOGUE" Then

                    loadInChoices(choices, cuD)

                    choices.Clear()

                    cuD = (New Dialogue(parts(1)))
                    dialogLib.Add(cuD)
                    Continue For

                End If

                'Do we have a Goto?
                If parts(0) = "@CHOICE" Then

                    For o = 1 To parts.Length - 1

                        choices.Add(New KeyValuePair(Of Topic, String)(cuT, parts(o)))

                    Next
                    Continue For
                End If


                'Do we have a Trigger?
                If parts(0) = "@TRIGGER" Then

                    cuT._trigger = New Script(parts(1))
                    Continue For
                End If

            Else

                'We have "" arguemtns -> topic, info, goodbye
                Dim cmd As String = lines(0)
                Dim param As String = lines(1)
                Dim cmdParts() As String = cmd.Split(" ")

                If cmdParts(0) = "@TOPIC" Then

                    cuT = New Topic(cmdParts(1), param)
                    cuD._topics.Add(cuT)
                    Continue For

                End If

                If cmdParts(0) = "@INFO" Then

                    cuT._info.Add(New Info(param, False))
                    Continue For

                End If

                If cmdParts(0) = "@GOODBYE" Then

                    cuT._info.Add(New Info(param, True))
                    Continue For

                End If

            End If

        Next

        loadInChoices(choices, cuD)
    End Sub





    Private Sub loadInChoices(ByRef choices As List(Of KeyValuePair(Of Topic, String)), ByRef cuD As Dialogue)

        If choices.Count > 0 Then

            For Each kv As KeyValuePair(Of Topic, String) In choices

                For Each t As Topic In cuD._topics

                    If t Is kv.Key Then

                        For Each t2 As Topic In cuD._topics

                            If t2._id = kv.Value Then

                                t._choice.Add(t2)

                            End If

                        Next


                    End If

                Next

            Next

        End If

    End Sub



    Private Sub fillDialoguesComboBox()

        dialoguesComboBox.Items.Clear()

        For Each d As Dialogue In dialogLib
            dialoguesComboBox.Items.Add(d._id)
        Next

        dialoguesComboBox.SelectedIndex = 0
    End Sub





    Private Sub dialoguesComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dialoguesComboBox.SelectedIndexChanged
        topicsListBox.Items.Clear()

        For Each d As Dialogue In dialogLib

            If d._id = dialoguesComboBox.SelectedItem.ToString Then

                For Each t As Topic In d._topics

                    topicsListBox.Items.Add(t._id)

                Next

            End If

        Next

        If topicsListBox.Items.Count > 0 Then
            topicsListBox.Sorted = True
        Else
            topicNameTextBox.Text = String.Empty
            infosDGV.Columns.Clear()
            infosDGV.Rows.Clear()
            choiceListBox.Items.Clear()
        End If


    End Sub







    Private Sub topicsListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles topicsListBox.SelectedIndexChanged

        Try
            topicNameTextBox.Text = getTopicById(getDialogueByString(Me.dialoguesComboBox.SelectedItem.ToString), topicsListBox.SelectedItem.ToString)._text
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try

        FillDGV()

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        If t._trigger IsNot Nothing Then
            tbResult.Text = t._trigger._name
        End If

        fillPreview()

    End Sub




    Private Sub FillDGV()

        infosDGV.Rows.Clear()
        infosDGV.Columns.Clear()
        choiceListBox.Items.Clear()


        infosDGV.Columns.Add("c_id", "#")
        infosDGV.Columns.Add("c_content", "Content")
        infosDGV.Columns.Add("c_goodbye", "Goodbye?")

        Dim t As Topic = getTopicById(getDialogueByString(dialoguesComboBox.SelectedItem.ToString), topicsListBox.SelectedItem.ToString)
        Dim cnt As Integer = 1

        If t Is Nothing Then
            Return
        End If

        For Each i As Info In t._info

            infosDGV.Rows.Add(cnt, i._text, i._goodbye.ToString)
            cnt += 1

        Next

        For Each t2 As Topic In t._choice

            choiceListBox.Items.Add(t2._id)

        Next


        infosDGV.RowHeadersVisible = False
        infosDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        infosDGV.Columns(2).Width = 75
        infosDGV.Columns(0).Width = 25
        infosDGV.AllowUserToAddRows = False
        infosDGV.AllowUserToDeleteRows = False
        infosDGV.AllowUserToOrderColumns = False
        infosDGV.AllowUserToResizeColumns = False
        infosDGV.AllowUserToResizeRows = False
        infosDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        infosDGV.MultiSelect = False
        infosDGV.ReadOnly = True
    End Sub


    Private Sub choiceListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles choiceListBox.DoubleClick
        If choiceListBox.SelectedItem IsNot Nothing Then

            Dim t As Topic = getTopicById(GetDialogue(), choiceListBox.SelectedItem.ToString)

            If t IsNot Nothing Then
                topicsListBox.SelectedItem = t._id
            End If


        End If
    End Sub




    Private Sub btnNewDialogue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDialogue.Click
        Dim newItem As String = InputBox("Eindeutige Dialog ID")
        dialogLib.Add(New Dialogue(newItem))
        Reload()

        For Each item In dialoguesComboBox.Items
            If item.ToString = newItem Then
                dialoguesComboBox.SelectedItem = item
            End If
        Next
    End Sub


    Private Sub Reload()

        Dim selD = dialoguesComboBox.SelectedItem
        Dim selT = topicsListBox.SelectedIndex
        fillDialoguesComboBox()

        Try
            dialoguesComboBox.SelectedItem = selD
            topicsListBox.SelectedIndex = selT
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        If t._trigger IsNot Nothing Then
            tbResult.Text = t._trigger._name
        End If

        fillPreview()


    End Sub




    Private Sub fillPreview()

        Dim d As Dialogue = GetDialogue()
        Dim fouls As List(Of Topic) = New List(Of Topic)
        previewBox.Text = String.Empty

        wrpl(d._id, Color.Red)

        wrpl("", Color.Red)

        For Each t As Topic In d._topics

            RecursiveDFill(t, 0, fouls)

        Next

    End Sub



    Private Sub RecursiveDFill(ByVal t As Topic, ByVal inc As Integer, ByRef fouls As List(Of Topic))

        If fouls.Contains(t) Then

            Return

        End If

        If t._id = "GREETING" Then
            For Each i As Info In t._info

                If i._goodbye Then
                    wrpl("NPC: " & i._text & " (G)", Color.Crimson)
                Else
                    wrpl("NPC: " & i._text, Color.Orange)
                End If

            Next

            Return
        End If

        Dim preamble As String = String.Empty

        For n = 0 To inc - 1
            preamble = preamble & vbTab
        Next

        wrpl(preamble & "Player: " & t._text, Color.Green)

        inc += 1

        preamble = String.Empty

        For n = 0 To inc - 1
            preamble = preamble & vbTab
        Next

        For Each i As Info In t._info

            If i._goodbye Then
                wrpl(preamble & "NPC : " & i._text & " (G)", Color.Crimson)
            Else
                wrpl(preamble & "NPC : " & i._text, Color.DarkGoldenrod)
            End If

        Next

        For Each c As Topic In t._choice

            RecursiveDFill(c, inc, fouls)
            fouls.Add(c)

        Next

        inc -= 1

    End Sub


    Private Sub wrpl(ByVal str As String, ByVal col As Color)

        Dim length As Integer = previewBox.TextLength
        previewBox.AppendText(str)
        previewBox.SelectionStart = length
        previewBox.SelectionLength = str.Length
        previewBox.SelectionColor = col
        previewBox.AppendText(vbNewLine)
        previewBox.SelectedText = String.Empty

    End Sub




    Private Sub topicsContextNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles topicsContextNew.Click

        Dim newTopc As String = InputBox("Topic ID")

        GetDialogue._topics.Add(New Topic(newTopc))

        Reload()

        topicsListBox.SelectedIndex = topicsListBox.Items.Count - 1

    End Sub







    Private Sub infosContextNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles infosContextNew.Click

        Dim newInfo As String = InputBox("Info Text")

        Dim t As Topic = getTopicById(GetDialogue(), topicsListBox.SelectedItem.ToString)

        t._info.Add(New Info(newInfo))

        Reload()

    End Sub







    Private Sub infosContextEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles infosContextEdit.Click

        If infosDGV.SelectedCells.Count < 1 Then
            Return
        End If

        Dim t As Topic = getTopicById(GetDialogue(), topicsListBox.SelectedItem.ToString)

        For Each i As Info In t._info

            If i._text = infosDGV.SelectedCells(1).Value.ToString Then

                Dim newInfo As String = InputBox("Info Text", "", i._text)
                i._text = newInfo

            End If

        Next

        Reload()

    End Sub







    Private Sub infosContextGoodbye_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles infosContextGoodbye.Click
        If infosDGV.SelectedCells.Count < 1 Then
            Return
        End If

        Dim t As Topic = getTopicById(GetDialogue(), topicsListBox.SelectedItem.ToString)

        For Each i As Info In t._info

            If i._text = infosDGV.SelectedCells(1).Value.ToString Then

                If i._goodbye Then i._goodbye = False Else i._goodbye = True

            End If

        Next

        Reload()
    End Sub










    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim b As System.Text.StringBuilder = New System.Text.StringBuilder()

        For Each d As Dialogue In dialogLib

            b.AppendLine("@DIALOGUE " & d._id)

            For Each t As Topic In d._topics

                b.AppendLine(vbTab & "@TOPIC " & t._id & " " & Chr(34) & t._text & Chr(34))

                For Each i As Info In t._info

                    If i._goodbye Then
                        b.AppendLine(vbTab & vbTab & "@GOODBYE " & Chr(34) & i._text & Chr(34))
                    Else
                        b.AppendLine(vbTab & vbTab & "@INFO " & Chr(34) & i._text & Chr(34))
                    End If


                Next

                If t._trigger IsNot Nothing Then
                    b.AppendLine(vbTab & vbTab & "@TRIGGER " & t._trigger._name)
                End If

                Dim choiceS As String = String.Empty

                For Each t2 As Topic In t._choice

                    choiceS = choiceS & " " & t2._id

                Next

                If choiceS IsNot String.Empty Then

                    b.AppendLine(vbTab & vbTab & "@CHOICE" & choiceS)

                End If





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





    Public Function GetDialogue() As Dialogue

        Return getDialogueByString(Me.dialoguesComboBox.SelectedItem.ToString)

    End Function




    Private Sub choiceContextEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles choiceContextEdit.Click

        Dim t As Topic = Nothing

        Try
            t = getTopicById(getDialogueByString(dialoguesComboBox.SelectedItem.ToString), topicsListBox.SelectedItem.ToString)
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try

        If t Is Nothing Then

            Return

        End If

        Dim f As ChoiceForm = New ChoiceForm
        f.ShowDialog(Me)

        If f.DialogResult = Windows.Forms.DialogResult.OK Then

            For Each t2 As Topic In GetDialogue._topics

                If t2._id = f.cbChoice.SelectedItem.ToString Then

                    t._choice.Add(t2)

                End If

            Next

        End If

        Reload()



    End Sub









    Private Sub btnDeleteDialogue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDialogue.Click


        If MsgBox(dialoguesComboBox.SelectedItem.ToString & " wirklich löschen?", MsgBoxStyle.YesNo, "Dialogue Designer") = MsgBoxResult.Yes Then

            Dim d As Dialogue = getDialogueByString(dialoguesComboBox.SelectedItem.ToString)

            If d IsNot Nothing Then

                Try
                    dialogLib.Remove(d)
                Catch ex As Exception
                    Debug.Print(ex.ToString)
                End Try

            End If

            Reload()

        End If


    End Sub











    Private Function getDialogueByString(ByVal identifier As String) As Dialogue

        For Each d As Dialogue In dialogLib

            If d._id = identifier Then

                Return d

            End If

        Next

        Return Nothing

    End Function






    Private Function getTopicById(ByVal dialog As Dialogue, ByVal identifier As String) As Topic

        For Each t As Topic In dialog._topics

            If t._id = identifier Then

                Return t

            End If

        Next

        Return Nothing

    End Function






    Private Function getInfoByID(ByVal topic As Topic, ByVal identifier As String) As Info

        For Each i As Info In topic._info

            If i._text = identifier Then

                Return i

            End If

        Next

        Return Nothing

    End Function









    Private Sub btnChangeID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeID.Click

        Dim d As Dialogue = getDialogueByString(dialoguesComboBox.SelectedItem.ToString)

        If d Is Nothing Then
            Return
        End If

        Dim s As String = InputBox("Neue ID Bezeichnung", "Dialogue Designer", d._id)

        If s IsNot String.Empty Then

            d._id = s
            Reload()

        End If



    End Sub



    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub







    Private Sub topicsContextDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles topicsContextDelete.Click

        GetDialogue._topics.Remove(getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString))

        Reload()

    End Sub







    Private Sub topicNameTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles topicNameTextBox.LostFocus

        getTopicById(GetDialogue(), topicsListBox.SelectedItem.ToString)._text = topicNameTextBox.Text

    End Sub








    Private Sub choiceContextDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles choiceContextDelete.Click

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        For Each c As Topic In t._choice

            If c._id = choiceListBox.SelectedItem.ToString Then

                t._choice.Remove(c)
                Exit For

            End If

        Next

        Reload()

    End Sub







    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        For Each c As Info In t._info

            If c._text = infosDGV.SelectedCells(1).Value.ToString Then

                t._info.Remove(c)
                Exit For

            End If

        Next

        Reload()

    End Sub







    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click

        If infosDGV.SelectedCells.Count < 1 Then
            Return
        End If

        If infosDGV.SelectedCells(0).RowIndex = 0 Then
            Return
        End If

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        For i As Integer = 0 To t._info.Count - 1

            If t._info(i)._text = infosDGV.SelectedCells(1).Value.ToString Then

                Dim pl As Info = t._info(i - 1)
                t._info(i - 1) = t._info(i)
                t._info(i) = pl
                Exit For

            End If

        Next

        Dim v As Integer = infosDGV.SelectedCells(0).RowIndex

        Reload()

        infosDGV.Rows(v - 1).Selected = True

    End Sub





    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click

        If infosDGV.SelectedCells.Count < 1 Then
            Return
        End If

        If infosDGV.SelectedCells(0).RowIndex = infosDGV.Rows.Count - 1 Then
            Return
        End If

        Dim t As Topic = getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)

        For i As Integer = 0 To t._info.Count - 1

            If t._info(i)._text = infosDGV.SelectedCells(1).Value.ToString Then

                Dim pl As Info = t._info(i + 1)
                t._info(i + 1) = t._info(i)
                t._info(i) = pl
                Exit For

            End If

        Next

        Dim v As Integer = infosDGV.SelectedCells(0).RowIndex

        Reload()

        infosDGV.Rows(v + 1).Selected = True

    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        infosContextNew_Click(Nothing, Nothing)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteToolStripMenuItem_Click(Nothing, Nothing)
    End Sub







    Private Sub topicsContextEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles topicsContextEdit.Click

        Dim t As Topic = Nothing

        Try
            t = getTopicById(getDialogueByString(dialoguesComboBox.SelectedItem.ToString), topicsListBox.SelectedItem.ToString)
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try

        If t Is Nothing Then

            Return

        End If

        Dim S As String = InputBox("Topic ID", "Dialogue Designer", t._id)

        If S Is String.Empty Then
            Return
        End If

        t._id = S

        Reload()

    End Sub







    Private Sub btnScriptus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScriptus.Click

        scriptus_inst.ShowDialog()

        If scriptus_inst.currentScript IsNot String.Empty Then

            getTopicById(GetDialogue, topicsListBox.SelectedItem.ToString)._trigger = scriptus_inst.currentScript

            Reload()

        End If

    End Sub


End Class













'If dialogueArray(s).Trim.StartsWith("@DIALOGUE") Then

'    cuD = New Dialogue(dialogueArray(s).Substring(10))
'    dialogLib.Add(cuD)

'    s += 1

'    While Not (dialogueArray(s).Trim.StartsWith("@DIALOGUE"))

'        If dialogueArray(s).Trim().StartsWith("@TOPIC") Then
'            Debug.Print("_" & dialogueArray(s).Trim() & "_")
'            cuT = New Topic(dialogueArray(s).Trim().Substring(7, dialogueArray(s).Trim().IndexOf(" ", 8)), dialogueArray(s).Trim().Substring(dialogueArray(s).Trim().IndexOf(" ", 8)).Trim(Chr(34)))
'            cuD._topics.Add(cuT)
'        End If

'        If dialogueArray(s).Trim().StartsWith("SAY") Then
'            cuT._info.Add(New Info(dialogueArray(s).Trim().Substring(4).Trim(Chr(34)), False))

'        ElseIf dialogueArray(s).Trim().StartsWith("GOODBYE") Then
'            cuT._info.Add(New Info(dialogueArray(s).Trim().Substring(8).Trim(Chr(34)), True))

'        ElseIf dialogueArray(s).Trim().StartsWith("GOTO") Then
'            cuT._choice = New Topic(dialogueArray(s).Trim().Substring(5).Trim(Chr(34)))
'        End If


'        s += 1

'        If s >= dialogueArray.Length Then
'            Return
'        End If

'    End While

'    s -= 1
'End If