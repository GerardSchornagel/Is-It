Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.buttonNew = New System.Windows.Forms.Button()
		Me.buttonQuit = New System.Windows.Forms.Button()
		Me.groupboxMenu = New System.Windows.Forms.GroupBox()
		Me.labelVertical = New System.Windows.Forms.Label()
		Me.labelHorizontal = New System.Windows.Forms.Label()
		Me.updownVertical = New System.Windows.Forms.NumericUpDown()
		Me.updownHorizontal = New System.Windows.Forms.NumericUpDown()
		Me.groupboxBoard = New System.Windows.Forms.GroupBox()
		Me.groupboxMenu.SuspendLayout
		CType(Me.updownVertical,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.updownHorizontal,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'buttonNew
		'
		Me.buttonNew.Location = New System.Drawing.Point(6, 19)
		Me.buttonNew.Name = "buttonNew"
		Me.buttonNew.Size = New System.Drawing.Size(161, 45)
		Me.buttonNew.TabIndex = 0
		Me.buttonNew.Text = "New Game"
		Me.buttonNew.UseVisualStyleBackColor = true
		'
		'buttonQuit
		'
		Me.buttonQuit.Location = New System.Drawing.Point(6, 70)
		Me.buttonQuit.Name = "buttonQuit"
		Me.buttonQuit.Size = New System.Drawing.Size(161, 45)
		Me.buttonQuit.TabIndex = 0
		Me.buttonQuit.Text = "Quit Game"
		Me.buttonQuit.UseVisualStyleBackColor = true
		'
		'groupboxMenu
		'
		Me.groupboxMenu.Controls.Add(Me.labelVertical)
		Me.groupboxMenu.Controls.Add(Me.labelHorizontal)
		Me.groupboxMenu.Controls.Add(Me.updownVertical)
		Me.groupboxMenu.Controls.Add(Me.updownHorizontal)
		Me.groupboxMenu.Controls.Add(Me.buttonNew)
		Me.groupboxMenu.Controls.Add(Me.buttonQuit)
		Me.groupboxMenu.Location = New System.Drawing.Point(12, 12)
		Me.groupboxMenu.Name = "groupboxMenu"
		Me.groupboxMenu.Size = New System.Drawing.Size(176, 425)
		Me.groupboxMenu.TabIndex = 1
		Me.groupboxMenu.TabStop = false
		Me.groupboxMenu.Text = "Menu"
		'
		'labelVertical
		'
		Me.labelVertical.AutoSize = true
		Me.labelVertical.Location = New System.Drawing.Point(79, 150)
		Me.labelVertical.Name = "labelVertical"
		Me.labelVertical.Size = New System.Drawing.Size(72, 13)
		Me.labelVertical.TabIndex = 2
		Me.labelVertical.Text = "Vertical Cards"
		'
		'labelHorizontal
		'
		Me.labelHorizontal.AutoSize = true
		Me.labelHorizontal.Location = New System.Drawing.Point(79, 123)
		Me.labelHorizontal.Name = "labelHorizontal"
		Me.labelHorizontal.Size = New System.Drawing.Size(84, 13)
		Me.labelHorizontal.TabIndex = 2
		Me.labelHorizontal.Text = "Horizontal Cards"
		'
		'updownVertical
		'
		Me.updownVertical.Location = New System.Drawing.Point(6, 148)
		Me.updownVertical.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.updownVertical.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.updownVertical.Name = "updownVertical"
		Me.updownVertical.Size = New System.Drawing.Size(67, 20)
		Me.updownVertical.TabIndex = 1
		Me.updownVertical.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'updownHorizontal
		'
		Me.updownHorizontal.Location = New System.Drawing.Point(6, 121)
		Me.updownHorizontal.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.updownHorizontal.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.updownHorizontal.Name = "updownHorizontal"
		Me.updownHorizontal.Size = New System.Drawing.Size(67, 20)
		Me.updownHorizontal.TabIndex = 1
		Me.updownHorizontal.Value = New Decimal(New Integer() {2, 0, 0, 0})
		'
		'groupboxBoard
		'
		Me.groupboxBoard.Location = New System.Drawing.Point(194, 12)
		Me.groupboxBoard.Name = "groupboxBoard"
		Me.groupboxBoard.Size = New System.Drawing.Size(412, 425)
		Me.groupboxBoard.TabIndex = 2
		Me.groupboxBoard.TabStop = false
		Me.groupboxBoard.Text = "Board"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(618, 449)
		Me.Controls.Add(Me.groupboxBoard)
		Me.Controls.Add(Me.groupboxMenu)
		Me.Name = "MainForm"
		Me.Text = "Is-It?"
		Me.groupboxMenu.ResumeLayout(false)
		Me.groupboxMenu.PerformLayout
		CType(Me.updownVertical,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.updownHorizontal,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private groupboxBoard As System.Windows.Forms.GroupBox
	Private updownHorizontal As System.Windows.Forms.NumericUpDown
	Private updownVertical As System.Windows.Forms.NumericUpDown
	Private labelHorizontal As System.Windows.Forms.Label
	Private labelVertical As System.Windows.Forms.Label
	Private groupboxMenu As System.Windows.Forms.GroupBox
	Private buttonQuit As System.Windows.Forms.Button
	Private buttonNew As System.Windows.Forms.Button
End Class
