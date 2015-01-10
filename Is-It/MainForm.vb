''' <summary>
''' Description of form/class/etc.
''' </summary>
Public Partial Class MainForm
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
	End Sub
	
	Sub ButtonQuitClick(sender As Object, e As EventArgs)
		Me.Dispose()
	End Sub
	
	Sub ButtonNewClick(sender As Object, e As EventArgs)
		'CODE:
		'Make an array with (Shuffled) Cards (Horizontal * Vertical).
		'Make an array with (Unshuffled) Deck (Horizontal * Vertical).
		'Make an array with (Unique's) Cardface (Board cards / 2).
		
		'Fill each arrayCardface(#) with next .jpg from CurrentDirectory.
		'Fill each arrayDeck with (arrayCardface.Index & arrayCardface.Index)
		'Fill each arrayCards through random pick from arrayDeck and shrink arrayDeck.
		
		'VISUAL:
		'Make an array of buttons (Horizontal * Vertical).
		'Fill each button with each arrayCards arrayCardface-reference & button.Tag = arrayCards-reference.
		'Place buttons in groupboxBoard.
	End Sub
	
	Private Sub CardClick(sender As Object, e As EventArgs)
		'Make booleanStart & integerFirst.
		'When the first card is turned booleanStart = True and integerFirst = sender.Tag.
		'When booleanStart = True (Second Card) then Compare both integerFirst and current sender.Tag.
		'-When false; reset booleanStart, arrayButtons(integerFirst) & arrayButtons(sender.Tag) = Normal.
		'-When true; reset booleanStart, disable both Buttons, and write point.
		'As last: When points are equal to number of Cardface's then the game is won.
	End Sub
End Class
