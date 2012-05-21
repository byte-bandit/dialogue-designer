Public Class ChoiceForm


    Private list As Dialogue = Form1.getDialogue()



    Private Sub ChoiceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For Each t As Topic In list._topics

            Me.cbChoice.Items.Add(t._id)

        Next

        cbChoice.SelectedIndex = 0

    End Sub



End Class