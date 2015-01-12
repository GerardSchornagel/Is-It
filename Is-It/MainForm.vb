''' <summary>
''' Main Form of game.
''' </summary>
Public Class MainForm
Inherits System.Windows.Forms.Form
'Form Controls
	Private timerTime As System.Windows.Forms.Timer
	Private groupboxMenu As System.Windows.Forms.GroupBox
	Private buttonNew As System.Windows.Forms.Button
	Private buttonQuit As System.Windows.Forms.Button
	Private updownHorizontal As System.Windows.Forms.NumericUpDown
	Private labelHorizontal As System.Windows.Forms.Label
	Private updownVertical As System.Windows.Forms.NumericUpDown
	Private labelVertical As System.Windows.Forms.Label
	Private labelOdd As System.Windows.Forms.Label
	Private labelDirectory As System.Windows.Forms.Label
	Private textboxDirectory As System.Windows.Forms.TextBox
	Private checkboxSizemode As System.Windows.Forms.CheckBox
	Private labelClicks As System.Windows.Forms.Label
	Private labelClicksTotal As System.Windows.Forms.Label
	Private labelTime As System.Windows.Forms.Label
	Private labelTimeTotal As System.Windows.Forms.Label
	Private labelFound As System.Windows.Forms.Label
	Private labelFoundTotal As System.Windows.Forms.Label
	Private groupboxBoard As System.Windows.Forms.GroupBox
	'Array's
	Private arrayCards() As String
	Private arrayDeck() As String
	Private arrayCardface() As String
	Private arrayButtons() As System.Windows.Forms.Button
	'Main Variable's
	Private booleanStart As Boolean
	Private integerFirst As Integer
	Private integerCardQuantity As Integer
	'Looping variable's
	Private integerCounter1 As Integer
	Private integerCounter2 As Integer
	Private integerCounter3 As Integer
	Private drawingSize As New System.Drawing.Size()
	Private drawingPoint As New System.Drawing.Point()
	Private randomPicker As New System.Random()
	
	Private Sub MainFormLayout()
		'Populate reserved memory with a default template.
		Me.timerTime = New System.Windows.Forms.Timer()
		Me.groupboxMenu = New System.Windows.Forms.GroupBox()
		Me.buttonNew = New System.Windows.Forms.Button()
		Me.buttonQuit = New System.Windows.Forms.Button()
		Me.updownHorizontal = New System.Windows.Forms.NumericUpDown()
		Me.labelHorizontal = New System.Windows.Forms.Label()
		Me.updownVertical = New System.Windows.Forms.NumericUpDown()
		Me.labelVertical = New System.Windows.Forms.Label()
		Me.labelOdd = New System.Windows.Forms.Label()
		Me.labelDirectory = New System.Windows.Forms.Label()
		Me.textboxDirectory = New System.Windows.Forms.TextBox()
		Me.checkboxSizemode = New System.Windows.Forms.CheckBox()
		Me.labelClicks = New System.Windows.Forms.Label()
		Me.labelClicksTotal = New System.Windows.Forms.Label()
		Me.labelTime = New System.Windows.Forms.Label()
		Me.labelTimeTotal = New System.Windows.Forms.Label()
		Me.labelFound = New System.Windows.Forms.Label()
		Me.labelFoundTotal = New System.Windows.Forms.Label()
		Me.groupboxBoard = New System.Windows.Forms.GroupBox()
		'Suspend (drawing)layout for faster and smoother processing.
		Me.groupboxMenu.SuspendLayout
		Me.SuspendLayout
		
		'MainForm
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(640, 480)
		Me.Name = "MainForm"
		Me.Text = "Is-It?"
		Me.Controls.Add(Me.groupboxMenu)
		Me.Controls.Add(Me.groupboxBoard)
		AddHandler Me.Resize, AddressOf MainFormResize
		'timerTime
		Me.timerTime.Enabled = False
		Me.timerTime.Interval = 1000
		AddHandler Me.timerTime.Tick, AddressOf Me.TimerTimeTick
		'groupboxMenu
		Me.groupboxMenu.Location = New System.Drawing.Point(6, 6)
		Me.groupboxMenu.Name = "groupboxMenu"
		Me.groupboxMenu.Size = New System.Drawing.Size((Me.ClientSize.Width - 18) / 4, Me.ClientSize.Height - 12)
		Me.groupboxMenu.TabStop = false
		Me.groupboxMenu.Text = "Menu"
		Me.groupboxMenu.Controls.Add(Me.buttonNew)
		Me.groupboxMenu.Controls.Add(Me.buttonQuit)
		Me.groupboxMenu.Controls.Add(Me.updownHorizontal)
		Me.groupboxMenu.Controls.Add(Me.labelHorizontal)
		Me.groupboxMenu.Controls.Add(Me.updownVertical)
		Me.groupboxMenu.Controls.Add(Me.labelVertical)
		Me.groupboxMenu.Controls.Add(Me.labelOdd)
		Me.groupboxMenu.Controls.Add(Me.labelDirectory)
		Me.groupboxMenu.Controls.Add(Me.textboxDirectory)
		Me.groupboxMenu.Controls.Add(Me.checkboxSizemode)
		Me.groupboxMenu.Controls.Add(Me.labelClicks)
		Me.groupboxMenu.Controls.Add(Me.labelClicksTotal)
		Me.groupboxMenu.Controls.Add(Me.labelTime)
		Me.groupboxMenu.Controls.Add(Me.labelTimeTotal)
		Me.groupboxMenu.Controls.Add(Me.labelFound)
		Me.groupboxMenu.Controls.Add(Me.labelFoundTotal)
		'buttonNew
		Me.buttonNew.Location = New System.Drawing.Point(6, 18)
		Me.buttonNew.Name = "buttonNew"
		Me.buttonNew.Size = New System.Drawing.Size(groupboxMenu.ClientSize.Width - 12, 36)
		Me.buttonNew.TabIndex = 0
		Me.buttonNew.Text = "New Game"
		Me.buttonNew.UseVisualStyleBackColor = true
		AddHandler Me.buttonNew.Click, AddressOf Me.ButtonNewClick
		'buttonQuit
		Me.buttonQuit.Location = New System.Drawing.Point(6, buttonNew.Location.Y + buttonNew.Height + 6)
		Me.buttonQuit.Name = "buttonQuit"
		Me.buttonQuit.Size = New System.Drawing.Size(groupboxMenu.ClientSize.Width - 12, 36)
		Me.buttonQuit.TabIndex = 1
		Me.buttonQuit.Text = "Quit Game"
		Me.buttonQuit.UseVisualStyleBackColor = true
		AddHandler Me.buttonQuit.Click, AddressOf Me.ButtonQuitClick
		'updownHorizontal
		Me.updownHorizontal.Location = New System.Drawing.Point(6, buttonQuit.Location.Y + buttonQuit.Height + 6)
		Me.updownHorizontal.Maximum = New Decimal(New Integer() {18, 0, 0, 0})
		Me.updownHorizontal.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.updownHorizontal.Name = "updownHorizontal"
		Me.updownHorizontal.Size = New System.Drawing.Size((groupboxMenu.ClientSize.Width - 18) / 3, 20)
		Me.updownHorizontal.TabIndex = 2
		Me.updownHorizontal.Value = New Decimal(New Integer() {4, 0, 0, 0})
		AddHandler Me.updownHorizontal.ValueChanged, AddressOf Me.UpdownValueChanged
		'labelHorizontal
		Me.labelHorizontal.AutoSize = true
		Me.labelHorizontal.Location = New System.Drawing.Point(Me.updownHorizontal.Width + 12, Me.updownHorizontal.Location.Y + 2)
		Me.labelHorizontal.Name = "labelHorizontal"
		Me.labelHorizontal.TabStop = False
		Me.labelHorizontal.Text = "Horizontal Cards"
		'updownVertical
		Me.updownVertical.Location = New System.Drawing.Point(6, Me.updownHorizontal.Location.Y + Me.updownHorizontal.Height + 6)
		Me.updownVertical.Maximum = New Decimal(New Integer() {16, 0, 0, 0})
		Me.updownVertical.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
		Me.updownVertical.Name = "updownVertical"
		Me.updownVertical.Size = New System.Drawing.Size((groupboxMenu.ClientSize.Width - 18) / 3, 20)
		Me.updownVertical.TabIndex = 3
		Me.updownVertical.Value = New Decimal(New Integer() {3, 0, 0, 0})
		AddHandler Me.updownVertical.ValueChanged, AddressOf Me.UpdownValueChanged
		'labelVertical
		Me.labelVertical.AutoSize = true
		Me.labelVertical.Location = New System.Drawing.Point(Me.updownVertical.Width + 12, Me.updownVertical.Location.Y + 2)
		Me.labelVertical.Name = "labelVertical"
		Me.labelVertical.TabStop = False
		Me.labelVertical.Text = "Vertical Cards"
		'labelOdd
		Me.labelOdd.AutoSize = True
		Me.labelOdd.ForeColor = System.Drawing.Color.Crimson
		Me.labelOdd.Location = New System.Drawing.Point(6 , Me.labelVertical.Location.Y + Me.labelVertical.Height + 6)
		Me.labelOdd.Name = "labelOdd"
		Me.labelOdd.TabStop = False
		Me.labelOdd.Text = "Odd"
		Me.labelOdd.Visible = False
		'labelDirectory
		Me.labelDirectory.AutoSize = true
		Me.labelDirectory.Location = New System.Drawing.Point(6 , Me.labelOdd.Location.Y + Me.labelOdd.Height + 6)
		Me.labelDirectory.Name = "labelDirectory"
		Me.labelDirectory.TabStop = False
		Me.labelDirectory.Text = "Image Sub-Directory"
		'textboxDirectory
		Me.textboxDirectory.AutoSize = False
		Me.textboxDirectory.Location = New System.Drawing.Point(6 , Me.labelDirectory.Location.Y + Me.labelDirectory.Height + 6)
		Me.textboxDirectory.Name = "textboxDirectory"
		Me.textboxDirectory.Size = New system.Drawing.Size(Me.groupboxMenu.ClientSize.Width - 12, 20)
		Me.textboxDirectory.TabStop = True
		Me.textboxDirectory.TabIndex = 4
		Me.textboxDirectory.Text = "\"
		'checkboxSizemode
		Me.checkboxSizemode.AutoSize = False
		Me.checkboxSizemode.Checked = False
		Me.checkboxSizemode.Location = New System.Drawing.Point(6 , Me.textboxDirectory.Location.Y + Me.textboxDirectory.Height + 6)
		Me.checkboxSizemode.Name = "labelDirectory"
		Me.checkboxSizemode.Size = New system.Drawing.Size(Me.groupboxMenu.ClientSize.Width - 12, 20)
		Me.checkboxSizemode.TabStop = True
		Me.checkboxSizemode.TabIndex = 5
		Me.checkboxSizemode.Text = "Zoom"
		AddHandler Me.checkboxSizemode.CheckedChanged, AddressOf Me.CheckboxSizemodeCheckedChanged
		'labelClicks
		Me.labelClicks.AutoSize = true
		Me.labelClicks.Location = New System.Drawing.Point(6 , Me.checkboxSizemode.Location.Y + Me.checkboxSizemode.Height + 6)
		Me.labelClicks.Name = "labelClicks"
		Me.labelClicks.TabStop = False
		Me.labelClicks.Text = "Total Clicks:"
		'labelClicksTotal
		Me.labelClicksTotal.AutoSize = true
		Me.labelClicksTotal.Location = New System.Drawing.Point(Me.labelClicks.Location.X + Me.labelClicks.Width + 6 , Me.labelClicks.Location.Y)
		Me.labelClicksTotal.Name = "labelClicksTotal"
		Me.labelClicksTotal.TabStop = False
		Me.labelClicksTotal.Text = "0"
		'labelTime
		Me.labelTime.AutoSize = true
		Me.labelTime.Location = New System.Drawing.Point(6 , Me.labelClicksTotal.Location.Y + Me.labelClicksTotal.Height + 6)
		Me.labelTime.Name = "labelTime"
		Me.labelTime.TabStop = False
		Me.labelTime.Text = "Total Seconds:"
		'labelTimeTotal
		Me.labelTimeTotal.AutoSize = true
		Me.labelTimeTotal.Location = New System.Drawing.Point(Me.labelTime.Location.X + Me.labelTime.Width + 6 , Me.labelTime.Location.Y)
		Me.labelTimeTotal.Name = "labelTimeTotal"
		Me.labelTimeTotal.TabStop = False
		Me.labelTimeTotal.Text = "0"
		'labelFound
		Me.labelFound.AutoSize = true
		Me.labelFound.Location = New System.Drawing.Point(6 , Me.labelTimeTotal.Location.Y + Me.labelTimeTotal.Height + 6)
		Me.labelFound.Name = "labelFound"
		Me.labelFound.TabStop = False
		Me.labelFound.Text = "Total Found:"
		'labelFoundTotal
		Me.labelFoundTotal.AutoSize = true
		Me.labelFoundTotal.Location = New System.Drawing.Point(Me.labelFound.Location.X + Me.labelFound.Width + 6 , Me.labelFound.Location.Y)
		Me.labelFoundTotal.Name = "labelFoundTotal"
		Me.labelFoundTotal.TabStop = False
		Me.labelFoundTotal.Text = "0"
		'groupboxBoard
		Me.groupboxBoard.Location = New System.Drawing.Point(Me.groupboxMenu.Width + 12, 6)
		Me.groupboxBoard.Name = "groupboxBoard"
		Me.groupboxBoard.Size = New System.Drawing.Size(((Me.ClientSize.Width - 18) / 4) * 3, Me.ClientSize.Height - 12)
		Me.groupboxBoard.TabStop = False
		Me.groupboxBoard.Text = "Board"
		'Resumes (drawing)layout of MainForm
		Me.groupboxMenu.ResumeLayout(false)
		Me.groupboxMenu.PerformLayout
		Me.ResumeLayout(false)
	End Sub
	
	Public Sub New()
		Me.MainFormLayout()
	End Sub
	
	Private Sub MainFormResize(sender As Object, e As EventArgs)
		Me.groupboxMenu.Location = New System.Drawing.Point(6, 6)
		Me.groupboxMenu.Size = New System.Drawing.Size((Me.ClientSize.Width - 18) / 4, Me.ClientSize.Height - 12)
		Me.buttonNew.Location = New System.Drawing.Point(6, 18)
		Me.buttonNew.Size = New System.Drawing.Size(groupboxMenu.ClientSize.Width - 12, 36)
		Me.buttonQuit.Location = New System.Drawing.Point(6, buttonNew.Location.Y + buttonNew.Height + 6)
		Me.buttonQuit.Size = New System.Drawing.Size(groupboxMenu.ClientSize.Width - 12, 36)
		Me.updownHorizontal.Location = New System.Drawing.Point(6, buttonQuit.Location.Y + buttonQuit.Height + 6)
		Me.updownHorizontal.Size = New System.Drawing.Size((groupboxMenu.ClientSize.Width - 18) / 3, 20)
		Me.labelHorizontal.Location = New System.Drawing.Point(Me.updownHorizontal.Width + 12, Me.updownHorizontal.Location.Y + 2)
		Me.updownVertical.Location = New System.Drawing.Point(6, Me.updownHorizontal.Location.Y + Me.updownHorizontal.Height + 6)
		Me.updownVertical.Size = New System.Drawing.Size((groupboxMenu.ClientSize.Width - 18) / 3, 20)
		Me.labelVertical.Location = New System.Drawing.Point(Me.updownVertical.Width + 12, Me.updownVertical.Location.Y + 2)
		Me.labelOdd.Location = New System.Drawing.Point(6 , Me.labelVertical.Location.Y + Me.labelVertical.Height + 6)
		Me.labelDirectory.Location = New System.Drawing.Point(6 , Me.labelOdd.Location.Y + Me.labelOdd.Height + 6)
		Me.textboxDirectory.Location = New System.Drawing.Point(6 , Me.labelDirectory.Location.Y + Me.labelDirectory.Height + 6)
		Me.textboxDirectory.Size = New system.Drawing.Size(Me.groupboxMenu.ClientSize.Width - 12, 20)
		Me.checkboxSizemode.Location = New System.Drawing.Point(6 , Me.textboxDirectory.Location.Y + Me.textboxDirectory.Height + 6)
		Me.checkboxSizemode.Size = New system.Drawing.Size(Me.groupboxMenu.ClientSize.Width - 12, 20)
		Me.labelClicks.Location = New System.Drawing.Point(6 , Me.checkboxSizemode.Location.Y + Me.checkboxSizemode.Height + 6)
		Me.labelClicksTotal.Location = New System.Drawing.Point(Me.labelClicks.Location.X + Me.labelClicks.Width + 6 , Me.labelClicks.Location.Y)
		Me.labelTime.Location = New System.Drawing.Point(6 , Me.labelClicksTotal.Location.Y + Me.labelClicksTotal.Height + 6)
		Me.labelTimeTotal.Location = New System.Drawing.Point(Me.labelTime.Location.X + Me.labelTime.Width + 6 , Me.labelTime.Location.Y)
		Me.labelFound.Location = New System.Drawing.Point(6 , Me.labelTimeTotal.Location.Y + Me.labelTimeTotal.Height + 6)
		Me.labelFoundTotal.Location = New System.Drawing.Point(Me.labelFound.Location.X + Me.labelFound.Width + 6 , Me.labelFound.Location.Y)
		Me.groupboxBoard.Location = New System.Drawing.Point(Me.groupboxMenu.Width + 12, 6)
		Me.groupboxBoard.Size = New System.Drawing.Size(((Me.ClientSize.Width - 18) / 4) * 3, Me.ClientSize.Height - 12)
		
		If arrayButtons IsNot Nothing Then
			integerCounter1 = 0
			For Each button As System.Windows.Forms.Button In arrayButtons
				drawingSize.Height = (groupboxBoard.ClientSize.Height - ((updownVertical.Value * 3) + 19)) / updownVertical.Value
				drawingSize.Width = (groupboxBoard.ClientSize.Width - ((updownHorizontal.Value * 3) + 3)) / updownHorizontal.Value
				drawingPoint.Y = ((CType(System.Decimal.Truncate((integerCounter1 / updownHorizontal.Value)), Integer)) * (drawingSize.Height + 3)) + 19
				drawingPoint.X = (System.Decimal.Remainder(integerCounter1, updownHorizontal.Value) * (drawingSize.Width + 3)) + 3
				button.Location = drawingPoint
				button.Size = drawingSize
				
				integerCounter1 += 1
			Next
		End If
	End Sub
	
	Private Sub TimerTimeTick(sender As Object, e As EventArgs)
		labelTimeTotal.Text += 1
	End Sub
	
	Private Sub UpdownValueChanged(sender As Object, e As EventArgs)
		If System.Decimal.Remainder((updownHorizontal.Value * updownVertical.Value), 2) > 0 Then
			labelOdd.Visible = True
			buttonNew.Enabled = False
			
		Else
			labelOdd.Visible = False
			buttonNew.Enabled = True
		End If
	End Sub
	
	Private Sub CheckboxSizemodeCheckedChanged(sender As Object, e As EventArgs)
		If sender.Checked = False Then
			sender.Text = "Zoom"
			If arrayButtons IsNot Nothing Then
				For Each button As System.Windows.Forms.Button In arrayButtons
					button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
				Next
			End If
		Else
			sender.Text = "Stretch"
			If arrayButtons IsNot Nothing Then
				For Each button As System.Windows.Forms.Button In arrayButtons
					button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
				Next
			End If	
		End If
	End Sub
	
	Private Sub ButtonQuitClick(sender As Object, e As EventArgs)
		Me.Dispose() 'You can also use End, but .Dispose() is better for memory-management.
	End Sub
	
	Private Sub ButtonNewClick(sender As Object, e As EventArgs)
		'Used for (kinda) shorthand.
		integerCardQuantity = updownHorizontal.Value * updownVertical.Value 'As defined by user in runtime MainForm.vb.
		'Check for enough Pictures
		If System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory & textboxDirectory.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).GetUpperBound(0) + 1 < integerCardQuantity / 2 Then
			MsgBox("Directory doesn't contain enough jpg's, please lower cards (-" & (integerCardQuantity / 2) - System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory & textboxDirectory.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).GetUpperBound(0) & ") or add jpg's (+" & System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory & textboxDirectory.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly).GetUpperBound(0) - (integerCardQuantity / 2) & ").")
			Exit Sub
		End If
		'Make the array to the right size.
		ReDim arrayCards(integerCardQuantity - 1) '-1 is for the zero-based index
		ReDim arrayDeck(integerCardQuantity - 1) '-1 is for the zero-based index
		ReDim arrayCardface((integerCardQuantity / 2) - 1) '-1 is for the zero-based index
		
		'Fill each arrayCardface(#) with next .jpg from CurrentDirectory.
		integerCounter1 = 0
		For Each cardface As String In arrayCardface
			arrayCardface(integerCounter1) = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory & textboxDirectory.Text, "*.jpg", System.IO.SearchOption.TopDirectoryOnly)(integerCounter1)
			integerCounter1 += 1
		Next
		
		'Fill each arrayDeck with (arrayCardface.Index & arrayCardface.Index)
		integerCounter1 = 0
		integerCounter2 = 0
		For Each cardface As String In arrayCardface
			arrayDeck(integerCounter1) = integerCounter2
			arrayDeck(integerCounter1 + 1) = integerCounter2
			integerCounter1 += 2
			integerCounter2 += 1
		Next
		'Fill each arrayCards through random pick from arrayDeck and shrink arrayDeck.
		integerCounter1 = 0
		integerCounter2 = 0
		integerCounter3 = 0
		For Each card As String In arrayCards
			integerCounter2 = randomPicker.Next(arrayDeck.GetUpperBound(0)) 'Pick random card.
			arrayCards(integerCounter1) = arrayDeck(integerCounter2) 'Transfer random card from Deck to Cards
			arrayDeck(integerCounter2) = ""
			integerCounter2 = 0
			integerCounter3 = 0
			For Each cardface As String In arrayDeck
				If cardface = "" Then
					integerCounter2 += 1
				Else
					arrayDeck(integerCounter3) = arrayDeck(integerCounter2)
					integerCounter2 += 1
					integerCounter3 += 1
				End If
			Next
			ReDim Preserve arrayDeck(arrayDeck.GetUpperBound(0) - 1)
			integerCounter1 += 1
			integerCounter2 = 0
		Next
		
		'Make the array to the right size.
		ReDim arrayButtons(integerCardQuantity - 1)
		'Calculate Height and Width of buttons.
		'-Size = Get usable space, subtract needed spacing, divide by number of cards.
		drawingSize.Height = (groupboxBoard.ClientSize.Height - ((updownVertical.Value * 3) + 19)) / updownVertical.Value
		drawingSize.Width = (groupboxBoard.ClientSize.Width - ((updownHorizontal.Value * 3) + 3)) / updownHorizontal.Value
		'Fill each button with each arrayCards arrayCardface-reference & button.Tag = arrayCards-reference.
		integerCounter1 = 0
		For Each button As system.Windows.Forms.Button In arrayButtons
			arrayButtons(integerCounter1) = New System.Windows.Forms.Button()
			If Me.checkboxSizemode.Text = "Zoom" Then arrayButtons(integerCounter1).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom Else arrayButtons(integerCounter1).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
			'Get grid numbers & Multiply with size and spacing.
			drawingPoint.Y = ((CType(System.Decimal.Truncate((integerCounter1 / updownHorizontal.Value)), Integer)) * (drawingSize.Height + 3)) + 19
			drawingPoint.X = (System.Decimal.Remainder(integerCounter1, updownHorizontal.Value) * (drawingSize.Width + 3)) + 3
			arrayButtons(integerCounter1).Location = drawingPoint
			arrayButtons(integerCounter1).Name = integerCounter1
			arrayButtons(integerCounter1).Size = drawingSize
			arrayButtons(integerCounter1).Tag = arrayCards(integerCounter1)
			arrayButtons(integerCounter1).TextAlign = System.Drawing.ContentAlignment.BottomCenter
			arrayButtons(integerCounter1).UseVisualStyleBackColor = True
			AddHandler arrayButtons(integerCounter1).Click, AddressOf CardClick
			groupboxBoard.Controls.Add(arrayButtons(integerCounter1))
			
			integerCounter1 += 1
		Next
		MsgBox("Start!")
		timerTime.Enabled = True
	End Sub
	
	Private Sub CardClick(sender As Object, e As EventArgs)
		'When the first card is turned booleanStart = True and integerFirst = sender.Tag
		If booleanStart = False Then
			booleanStart = True
			'Flip over Card
			sender.BackgroundImage = System.Drawing.Image.FromFile(arrayCardface(sender.Tag))
			integerFirst = sender.Name
			
		'When booleanStart = True (Second Card) then Compare both integerFirst and current sender.Tag.
		Else
			If integerFirst = sender.Name Then Exit Sub
			booleanStart = False
			'Flip over Card
			sender.BackgroundImage = System.Drawing.Image.FromFile(arrayCardface(sender.Tag))
			
			'Compare with previous and when true, disable both Buttons and write point.
			If arrayButtons(integerFirst).Tag = sender.Tag Then
				arrayButtons(integerFirst).Enabled = False
				sender.Enabled = False
				labelFoundTotal.Text += 1
				
			'-When false; arrayButtons(integerFirst) & arrayButtons(sender.Tag) = Normal.
			Else
				timerTime.Enabled = False
				MsgBox("Nope!")
				timerTime.Enabled = True
				arrayButtons(integerFirst).BackgroundImage = Nothing
				sender.BackgroundImage = Nothing
			End If
			integerFirst = Nothing
		End If
		labelClicksTotal.Text += 1
		'As last: When points are equal to number of Cardface's then the game is won.
		If labelFoundTotal.Text = integerCardQuantity / 2 Then
			timerTime.Enabled = False
			MsgBox("You've won!")
			Application.Restart()
		End If
	End Sub
End Class
  