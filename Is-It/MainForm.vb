''' <summary>
''' Description of form/class/etc.
''' </summary>
Public Partial Class MainForm
	Private arrayCards() As String
	Private arrayDeck() As String
	Private arrayCardface() As String
	Private arrayButtons() As System.Windows.Forms.Button
	
	Private booleanStart As Boolean
	Private integerFirst As Integer
	Private integerCardQuantity As Integer
	Private integerPoints As Integer
	
	Private integerCounter1 As Integer
	Private integerCounter2 As Integer
	Private integerCounter3 As Integer
	Private drawingSize As New System.Drawing.Size()
	Private drawingPoint As New System.Drawing.Point()
	Private randomPicker As New System.Random()
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	Sub ButtonQuitClick(sender As Object, e As EventArgs)
		Me.Dispose() 'You can also use End, but .Dispose() is better for memory-management.
	End Sub
	
	Sub ButtonNewClick(sender As Object, e As EventArgs)
		'Used for (kinda) shorthand.
		integerCardQuantity = updownHorizontal.Value * updownVertical.Value 'As defined by user in runtime MainForm.vb.
		'Also check for odd numbers.
		If System.Decimal.Remainder(integerCardQuantity, 2) > 0 Then
			MsgBox("Can't do odd numbers." & Chr(13) & updownHorizontal.Value & "*" & updownVertical.Value & "=" & integerCardQuantity)
			Exit Sub
		End If
		'Make the array to the right size.
		ReDim arrayCards(integerCardQuantity - 1) '-1 is for the zero-based index
		ReDim arrayDeck(integerCardQuantity - 1) '-1 is for the zero-based index
		ReDim arrayCardface((integerCardQuantity / 2) - 1) '-1 is for the zero-based index
		
		'Fill each arrayCardface(#) with next .jpg from CurrentDirectory.
		integerCounter1 = 0
		For Each cardface As String In arrayCardface
			arrayCardface(integerCounter1) = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory, "*.jpg", System.IO.SearchOption.TopDirectoryOnly)(integerCounter1)
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
			arrayButtons(integerCounter1).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
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
				MsgBox("Yeah!")
				arrayButtons(integerFirst).Enabled = False
				sender.Enabled = False
				integerPoints += 1
				
			'-When false; arrayButtons(integerFirst) & arrayButtons(sender.Tag) = Normal.
			Else
				MsgBox("Nope!")
				arrayButtons(integerFirst).BackgroundImage = Nothing
				sender.BackgroundImage = Nothing
			End If
			integerFirst = Nothing
		End If
		'As last: When points are equal to number of Cardface's then the game is won.
		If integerPoints = integerCardQuantity / 2 Then
			MsgBox("You've won!")
			Application.Restart()
		End If
	End Sub
End Class
