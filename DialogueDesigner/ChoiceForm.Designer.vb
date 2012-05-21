<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoiceForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChoiceForm))
        Me.cbChoice = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cbChoice
        '
        Me.cbChoice.FormattingEnabled = True
        Me.cbChoice.Location = New System.Drawing.Point(12, 12)
        Me.cbChoice.Name = "cbChoice"
        Me.cbChoice.Size = New System.Drawing.Size(136, 21)
        Me.cbChoice.TabIndex = 0
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(154, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ChoiceForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(241, 44)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cbChoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChoiceForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choice auswählen..."
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbChoice As System.Windows.Forms.ComboBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
