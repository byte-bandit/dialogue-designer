<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scriptus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scriptus))
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbScripts = New System.Windows.Forms.ComboBox
        Me.rtb = New System.Windows.Forms.RichTextBox
        Me.btnNew = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(293, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Speichern"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbScripts
        '
        Me.cbScripts.FormattingEnabled = True
        Me.cbScripts.Location = New System.Drawing.Point(12, 14)
        Me.cbScripts.Name = "cbScripts"
        Me.cbScripts.Size = New System.Drawing.Size(194, 21)
        Me.cbScripts.TabIndex = 1
        '
        'rtb
        '
        Me.rtb.Location = New System.Drawing.Point(12, 41)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(356, 397)
        Me.rtb.TabIndex = 2
        Me.rtb.Text = ""
        Me.rtb.WordWrap = False
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(212, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Neu"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Scriptus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 450)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.rtb)
        Me.Controls.Add(Me.cbScripts)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Scriptus"
        Me.Text = "Scriptus"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbScripts As System.Windows.Forms.ComboBox
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
End Class
