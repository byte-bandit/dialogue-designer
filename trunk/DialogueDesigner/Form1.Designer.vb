<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.topicsListBox = New System.Windows.Forms.ListBox
        Me.topicsContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.topicsContextNew = New System.Windows.Forms.ToolStripMenuItem
        Me.topicsContextEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.topicsContextDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.dialoguesComboBox = New System.Windows.Forms.ComboBox
        Me.topicNameTextBox = New System.Windows.Forms.TextBox
        Me.infosDGV = New System.Windows.Forms.DataGridView
        Me.infosContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.infosContextNew = New System.Windows.Forms.ToolStripMenuItem
        Me.infosContextEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.infosContextGoodbye = New System.Windows.Forms.ToolStripMenuItem
        Me.choiceListBox = New System.Windows.Forms.ListBox
        Me.choiceContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.choiceContextEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.grpChoice = New System.Windows.Forms.GroupBox
        Me.btnNewDialogue = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnDeleteDialogue = New System.Windows.Forms.Button
        Me.btnChangeID = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.choiceContextDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.previewBox = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.topicsContext.SuspendLayout()
        CType(Me.infosDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.infosContext.SuspendLayout()
        Me.choiceContext.SuspendLayout()
        Me.grpChoice.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'topicsListBox
        '
        Me.topicsListBox.ContextMenuStrip = Me.topicsContext
        Me.topicsListBox.FormattingEnabled = True
        Me.topicsListBox.Location = New System.Drawing.Point(12, 51)
        Me.topicsListBox.Name = "topicsListBox"
        Me.topicsListBox.Size = New System.Drawing.Size(120, 420)
        Me.topicsListBox.TabIndex = 1
        '
        'topicsContext
        '
        Me.topicsContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.topicsContextNew, Me.topicsContextEdit, Me.topicsContextDelete})
        Me.topicsContext.Name = "topicsContext"
        Me.topicsContext.Size = New System.Drawing.Size(108, 70)
        '
        'topicsContextNew
        '
        Me.topicsContextNew.Name = "topicsContextNew"
        Me.topicsContextNew.Size = New System.Drawing.Size(107, 22)
        Me.topicsContextNew.Text = "New..."
        '
        'topicsContextEdit
        '
        Me.topicsContextEdit.Name = "topicsContextEdit"
        Me.topicsContextEdit.Size = New System.Drawing.Size(107, 22)
        Me.topicsContextEdit.Text = "Edit..."
        '
        'topicsContextDelete
        '
        Me.topicsContextDelete.Name = "topicsContextDelete"
        Me.topicsContextDelete.Size = New System.Drawing.Size(107, 22)
        Me.topicsContextDelete.Text = "Delete"
        '
        'dialoguesComboBox
        '
        Me.dialoguesComboBox.FormattingEnabled = True
        Me.dialoguesComboBox.Location = New System.Drawing.Point(12, 12)
        Me.dialoguesComboBox.Name = "dialoguesComboBox"
        Me.dialoguesComboBox.Size = New System.Drawing.Size(121, 21)
        Me.dialoguesComboBox.TabIndex = 0
        '
        'topicNameTextBox
        '
        Me.topicNameTextBox.Location = New System.Drawing.Point(139, 13)
        Me.topicNameTextBox.Name = "topicNameTextBox"
        Me.topicNameTextBox.Size = New System.Drawing.Size(709, 20)
        Me.topicNameTextBox.TabIndex = 2
        '
        'infosDGV
        '
        Me.infosDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.infosDGV.ContextMenuStrip = Me.infosContext
        Me.infosDGV.Location = New System.Drawing.Point(138, 51)
        Me.infosDGV.Name = "infosDGV"
        Me.infosDGV.Size = New System.Drawing.Size(672, 144)
        Me.infosDGV.TabIndex = 3
        '
        'infosContext
        '
        Me.infosContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.infosContextNew, Me.infosContextEdit, Me.infosContextGoodbye, Me.DeleteToolStripMenuItem})
        Me.infosContext.Name = "infosContext"
        Me.infosContext.Size = New System.Drawing.Size(123, 92)
        '
        'infosContextNew
        '
        Me.infosContextNew.Name = "infosContextNew"
        Me.infosContextNew.Size = New System.Drawing.Size(122, 22)
        Me.infosContextNew.Text = "New..."
        '
        'infosContextEdit
        '
        Me.infosContextEdit.Name = "infosContextEdit"
        Me.infosContextEdit.Size = New System.Drawing.Size(122, 22)
        Me.infosContextEdit.Text = "Edit..."
        '
        'infosContextGoodbye
        '
        Me.infosContextGoodbye.Name = "infosContextGoodbye"
        Me.infosContextGoodbye.Size = New System.Drawing.Size(122, 22)
        Me.infosContextGoodbye.Text = "Goodbye"
        '
        'choiceListBox
        '
        Me.choiceListBox.ContextMenuStrip = Me.choiceContext
        Me.choiceListBox.FormattingEnabled = True
        Me.choiceListBox.Location = New System.Drawing.Point(6, 19)
        Me.choiceListBox.Name = "choiceListBox"
        Me.choiceListBox.Size = New System.Drawing.Size(120, 95)
        Me.choiceListBox.TabIndex = 4
        '
        'choiceContext
        '
        Me.choiceContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.choiceContextEdit, Me.choiceContextDelete})
        Me.choiceContext.Name = "choiceContext"
        Me.choiceContext.Size = New System.Drawing.Size(108, 48)
        '
        'choiceContextEdit
        '
        Me.choiceContextEdit.Name = "choiceContextEdit"
        Me.choiceContextEdit.Size = New System.Drawing.Size(107, 22)
        Me.choiceContextEdit.Text = "Add..."
        '
        'grpChoice
        '
        Me.grpChoice.Controls.Add(Me.choiceListBox)
        Me.grpChoice.Location = New System.Drawing.Point(712, 201)
        Me.grpChoice.Name = "grpChoice"
        Me.grpChoice.Size = New System.Drawing.Size(136, 125)
        Me.grpChoice.TabIndex = 4
        Me.grpChoice.TabStop = False
        Me.grpChoice.Text = "Choice"
        '
        'btnNewDialogue
        '
        Me.btnNewDialogue.Location = New System.Drawing.Point(718, 332)
        Me.btnNewDialogue.Name = "btnNewDialogue"
        Me.btnNewDialogue.Size = New System.Drawing.Size(120, 23)
        Me.btnNewDialogue.TabIndex = 5
        Me.btnNewDialogue.Text = "Neuer Dialog"
        Me.btnNewDialogue.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(718, 419)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Speichern"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDeleteDialogue
        '
        Me.btnDeleteDialogue.Location = New System.Drawing.Point(718, 390)
        Me.btnDeleteDialogue.Name = "btnDeleteDialogue"
        Me.btnDeleteDialogue.Size = New System.Drawing.Size(120, 23)
        Me.btnDeleteDialogue.TabIndex = 7
        Me.btnDeleteDialogue.Text = "Dialog löschen"
        Me.btnDeleteDialogue.UseVisualStyleBackColor = True
        '
        'btnChangeID
        '
        Me.btnChangeID.Location = New System.Drawing.Point(718, 361)
        Me.btnChangeID.Name = "btnChangeID"
        Me.btnChangeID.Size = New System.Drawing.Size(120, 23)
        Me.btnChangeID.TabIndex = 6
        Me.btnChangeID.Text = "Dialog ID anpassen"
        Me.btnChangeID.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(718, 448)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(120, 23)
        Me.btnQuit.TabIndex = 9
        Me.btnQuit.Text = "Beenden"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'choiceContextDelete
        '
        Me.choiceContextDelete.Name = "choiceContextDelete"
        Me.choiceContextDelete.Size = New System.Drawing.Size(107, 22)
        Me.choiceContextDelete.Text = "Delete"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'btnUp
        '
        Me.btnUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUp.Location = New System.Drawing.Point(816, 124)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(32, 32)
        Me.btnUp.TabIndex = 10
        Me.btnUp.Text = "▲"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDown.Location = New System.Drawing.Point(816, 162)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(32, 32)
        Me.btnDown.TabIndex = 11
        Me.btnDown.Text = "▼"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(816, 51)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 32)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(816, 86)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(32, 32)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "X"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'previewBox
        '
        Me.previewBox.Location = New System.Drawing.Point(6, 19)
        Me.previewBox.Name = "previewBox"
        Me.previewBox.ReadOnly = True
        Me.previewBox.Size = New System.Drawing.Size(555, 245)
        Me.previewBox.TabIndex = 14
        Me.previewBox.Text = ""
        Me.previewBox.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.previewBox)
        Me.GroupBox1.Location = New System.Drawing.Point(139, 201)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 270)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dialog Vorschau"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 481)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnChangeID)
        Me.Controls.Add(Me.btnDeleteDialogue)
        Me.Controls.Add(Me.btnNewDialogue)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.grpChoice)
        Me.Controls.Add(Me.infosDGV)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.topicNameTextBox)
        Me.Controls.Add(Me.dialoguesComboBox)
        Me.Controls.Add(Me.topicsListBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Dialogue Designer"
        Me.topicsContext.ResumeLayout(False)
        CType(Me.infosDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.infosContext.ResumeLayout(False)
        Me.choiceContext.ResumeLayout(False)
        Me.grpChoice.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents topicsListBox As System.Windows.Forms.ListBox
    Friend WithEvents dialoguesComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents topicNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents infosDGV As System.Windows.Forms.DataGridView
    Friend WithEvents choiceListBox As System.Windows.Forms.ListBox
    Friend WithEvents grpChoice As System.Windows.Forms.GroupBox
    Friend WithEvents btnNewDialogue As System.Windows.Forms.Button
    Friend WithEvents topicsContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents topicsContextNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents infosContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents infosContextNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents infosContextEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents infosContextGoodbye As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents choiceContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents choiceContextEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeleteDialogue As System.Windows.Forms.Button
    Friend WithEvents btnChangeID As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents topicsContextEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents topicsContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents choiceContextDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents previewBox As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
