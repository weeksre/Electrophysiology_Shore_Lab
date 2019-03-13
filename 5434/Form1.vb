Imports System.IO
Imports System.Math
'Imports MLApp


Public Class Form1

	Public WorkingDirectory As String = Directory.GetCurrentDirectory.ToString()
	Public DefaultParameters As String = "Z:\DavidM\TDT Test Case Generator\DavidM Directory\tdtdefaultcase"
    Public LaserData As String = "C:\TDT\SHORELAB\Laser_Calibration_Full.txt"
    Dim CurrentTestCase As String
    Const DEFAULTSTRING As String = "DEFAULT"
	Dim SweepDelimiters As String() = {"@", "@1", "@2", "@r"}
	Dim MATLAB As Object

    'Channel 1 Parameter and Identifier Data
	Dim Ch1TextBoxs As TextBox() = New TextBox() {TextBoxAmp1, TextBoxFreq1, TextBoxDelay1, _
											  TextBoxCh1Dur, TextBoxCH1RFTime, TextBoxModDep1, TextBoxModFreq1}
	Dim Ch1Params As String() = {"Amp1", "Freq1", "Delays1", "ADur1", "ARF1", "ModDep1", "ModFreq1"}

    'Channel 2 Parameter and Identifier Data
	Dim Ch2TextBoxs As TextBox() = New TextBox() {TextBoxAmp2, TextBoxFreq2, TextBoxDelay2, _
											  TextBoxCh2Dur, TextBoxCH2RFTime, TextBoxModDep2, TextBoxModFreq2}
	Dim Ch2Params As String() = {"Amp2", "Freq2", "Delays2", "ADur2", "ARF2", "ModDep2", "ModFreq2"}
    Dim AuditoryTypes As String() = {"SType1", "SType2"}

    'Electrical Parameter Identifier Data
	Dim ETextBoxs As TextBox() = New TextBox() {TextBoxEAmpl, TextBoxEDel, _
											TextBoxEDur, TextBoxEPFreq, TextBoxEPWidth, TextBoxIPGap}
	Dim EParams As String() = {"EAmpl", "EDel", "EDur", "EPFreq", "EPWidth", "IPGap"}
    Dim ElecTypes As String() = {"EStimEnable", "EStimType", "BiPhase"}

    'Control Parameter Identifier Data
    Dim ControlBoxs As TextBox() = New TextBox() {TextBoxPeriod, TextBoxReps}
	Dim ControlParams As String() = {"APeriod", "IOReps"}

	'For use in signal mixing
	Dim MixAudioSignals As Boolean = False

    Dim FileWriter As StreamWriter
    Dim Results As DialogResult
    Dim ReturnData As Double()() = New Double(19)() {}

	Dim Mouse_Signals As Boolean = False



    ' %%%%% Program Control Functions %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    ' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    'Initialize Default Data, Set home directory and initialize
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        'Get default data from user, else load generic form data
        Do
            Results = OpenFileDialogDefault.ShowDialog()
            If Results = DialogResult.Cancel Then
                MsgBox("No Default Selected, using generic")
                OpenFileDialogDefault.FileName = DefaultParameters
            End If
        Loop While (Results = DialogResult.Retry)

        'Initialize control arrays for textboxs
        Ch1TextBoxs(0) = TextBoxAmp1
        Ch1TextBoxs(1) = TextBoxFreq1
        Ch1TextBoxs(2) = TextBoxDelay1
		Ch1TextBoxs(3) = TextBoxCh1Dur
		Ch1TextBoxs(4) = TextBoxCH1RFTime
		Ch1TextBoxs(5) = TextBoxModDep1
		Ch1TextBoxs(6) = TextBoxModFreq1

        Ch2TextBoxs(0) = TextBoxAmp2
        Ch2TextBoxs(1) = TextBoxFreq2
        Ch2TextBoxs(2) = TextBoxDelay2
		Ch2TextBoxs(3) = TextBoxCh2Dur
		Ch2TextBoxs(4) = TextBoxCH2RFTime
		Ch2TextBoxs(5) = TextBoxModDep2
		Ch2TextBoxs(6) = TextBoxModFreq2

        ETextBoxs(0) = TextBoxEAmpl
		ETextBoxs(1) = TextBoxEDel
		ETextBoxs(2) = TextBoxEDur
		ETextBoxs(3) = TextBoxEPFreq
		ETextBoxs(4) = TextBoxEPWidth
		ETextBoxs(5) = TextBoxIPGap

        ControlBoxs(0) = TextBoxPeriod
        ControlBoxs(1) = TextBoxReps

        'Null Set Return Data
        For i As Integer = 0 To 19
            ReturnData(i) = New Double(50000) {}
		Next i
		Ch1Filter.Checked = False
		Ch2Filter.Checked = False
		MixSignals.Checked = False
		Ch1FilterDesign.Visible = False
		RandTrials.Checked = True
		CurrentTestCase = OpenFileDialogDefault.FileName.ToString()
        ButtonLoadTest_Click(sender, e, OpenFileDialogDefault.FileName)
        WorkingDirectory = Directory.GetParent(OpenFileDialogDefault.FileName).ToString()
        WorkDirectory.Text = "Current Directory:    " & WorkingDirectory
        'Check Controlled Input Boxes
        EStimDisable_CheckedChanged(sender, e)
        DisableCh1AM(sender, e)
        DisableCh2AM(sender, e)
        DisableCh1Noise(sender, e)
		DisableCh2Noise(sender, e)
        Form2.Visible = True
        Form3.Enabled = False
		Form3.Visible = False



		Randomize()

    End Sub

    'Exit Program
    Private Sub ButtonQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonQuit.Click

        If MsgBox("Are you sure you want to quit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    'Open TestCase Selector for real time dataform construction
    Private Sub TestCaseSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'Me.Visible = False
        'Form2.Visible = True
    End Sub





    ' %%%%% Form Manipulation Functions %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    ' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    'Clear Channel 1 Data
    Private Sub ClearCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, _
                                Optional ByVal Called As Boolean = False) Handles ClearCh1.Click

        If Called = False Then
            If MsgBox("Are you sure you want to clear Ch1 forms?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim index As Integer = 0
        Do While index < Ch1TextBoxs.Count
            Ch1TextBoxs(index).Clear()
            index = index + 1
        Loop
        Ch1Tone.Checked = True

    End Sub

    'Clear Channel 2 Data
    Private Sub ClearCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, _
                               Optional ByVal Called As Boolean = False) Handles ClearCh2.Click

        If Called = False Then
            If MsgBox("Are you sure you want to clear Ch2 forms?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim index As Integer = 0
        Do While index < Ch2TextBoxs.Count
            Ch2TextBoxs(index).Clear()
            index = index + 1
        Loop
        Ch2Tone.Checked = True

    End Sub

    'Clear Electrical Data
    Private Sub ClearEParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, _
                                       Optional ByVal Called As Boolean = False) _
        Handles ClearEParam.Click

        If Called = False Then
            If MsgBox("Are you sure you want to clear Ch2 forms?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

		EStimTypeBi.Checked = True
        BiPhaseNeg.Checked = True

        Dim index As Integer = 0
        Do While index < ETextBoxs.Count
            ETextBoxs(index).Clear()
            index = index + 1
        Loop
    End Sub

    'Clear All Data
    Private Sub ButtonClrAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, _
                                   Optional ByVal Called As Boolean = False) Handles ButtonClrAll.Click
        If Called = False Then
            If MsgBox("Are you sure you want to clear all forms?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        ClearCh1_Click(sender, e, True)
        ClearCh2_Click(sender, e, True)
        ClearEParam_Click(sender, e, True)
        TextBoxPeriod.Clear()
        TextBoxReps.Clear()
        RepSets.Checked = True
    End Sub

    'Remove last item from textbox text; used to get rid of extra spaces
    Private Sub Remove_Last(ByVal sender As System.Object, ByVal e As System.EventArgs, _
                            ByRef TextBoxData As TextBox)
        TextBoxData.Text = TextBoxData.Text.Remove(TextBoxData.Text.Length - 1, 1)
    End Sub

    'Resets the Data Parameters Stored in ReturnData
    Private Sub Reset_ReturnData(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim index1 As Integer = 0
        Dim index2 As Integer = 0

        Do While index1 < 19
            index2 = 0
            Do While index2 < 50000
                ReturnData(index1)(index2) = 0
                index2 = index2 + 1
            Loop
            index1 = index1 + 1
        Loop
    End Sub

    'Updates displayed filenames at the top of the display
    Private Sub UpdateNames(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal Filename As String)
        Dim index As Integer = 0
        Dim stringbuffer As String() = Split(Filename, "\")
        WorkingDirectory = ""
        Do While index < stringbuffer.GetLength(0) - 1
            WorkingDirectory = WorkingDirectory & stringbuffer(index) & "\"
            index = index + 1
        Loop
        WorkingDirectory = WorkingDirectory.Remove(WorkingDirectory.Length() - 1, 1)
        WorkDirectory.Text = "Current Directory:    " & WorkingDirectory
        CurTestCase.Text = "Current Test Case:     " & stringbuffer(stringbuffer.GetLength(0) - 1)
    End Sub




    ' %%%%% Data Control Safety Routines %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    ' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    'Null ESTim parameters when disabled is checked
    Private Sub EStimDisable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles EStimDisable.CheckedChanged

        Dim index As Integer = 0
        If EStimDisable.Checked = True Then
            TextBoxEAmpl.Clear()
            TextBoxEAmpl.Text = ""
            TextBoxEAmpl.Text = "0"
            Do While index < ETextBoxs.Count
                ETextBoxs(index).ReadOnly = True
                index = index + 1
            Loop
        Else
            Do While index < ETextBoxs.Count
                ETextBoxs(index).ReadOnly = False
                index = index + 1
            Loop
        End If

    End Sub

	Private Sub DisableCh2(ByVal sender As System.Object, ByVal e As System.EventArgs)

		DisableCh2AM(sender, e)
		DisableCh2Noise(sender, e)

		TextBoxAmp2.ReadOnly = True
		TextBoxFreq2.ReadOnly = True
		TextBoxCh2Dur.ReadOnly = True
		TextBoxDelay2.ReadOnly = True

	End Sub

	Private Sub EnableCh2(ByVal sender As System.Object, ByVal e As System.EventArgs)

		TextBoxAmp2.ReadOnly = False
		TextBoxFreq2.ReadOnly = False
		TextBoxCh2Dur.ReadOnly = False
		TextBoxDelay2.ReadOnly = False

		Ch2Filter.Checked = False
		Ch2Filter.Visible = False
		TextBoxModDep2.ReadOnly = False
		TextBoxModFreq2.ReadOnly = False

	End Sub

	'Nulls Ch2 Parameters at appropriate times
	Private Sub DisableCh2AM(ByVal sender As System.Object, ByVal e As System.EventArgs)

		If CH2AM_Check.Checked = False Then
			TextBoxModDep2.Clear()
			TextBoxModFreq2.Clear()
			TextBoxModDep2.Text = ""
			TextBoxModFreq2.Text = ""
			TextBoxModDep2.Text = "0"
			TextBoxModFreq2.Text = "0"
			TextBoxModDep2.ReadOnly = True
			TextBoxModFreq2.ReadOnly = True
		Else
			TextBoxModDep2.ReadOnly = False
			TextBoxModFreq2.ReadOnly = False
		End If


	End Sub

	Private Sub DisableCh2Noise(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	Handles Ch2Noise.CheckedChanged

		If Ch2Noise.Checked = True Then
			TextBoxFreq2.Clear()
			TextBoxFreq2.Text = ""
			TextBoxFreq2.Text = "200"
			TextBoxFreq2.ReadOnly = True
			Ch2Filter.Visible = True
			Ch2Filter.Checked = False
		ElseIf Ch2Noise.Checked = False Then
			TextBoxFreq2.ReadOnly = False
			Ch2Filter.Checked = False
			Ch2Filter.Visible = False
		End If

	End Sub

	'Null Ch1 Parameters at appropriate times
	Private Sub DisableCh1AM(ByVal sender As System.Object, ByVal e As System.EventArgs)

		If CH1AM_Check.Checked = False Then
			TextBoxModDep1.Clear()
			TextBoxModFreq1.Clear()
			TextBoxModDep1.Text = ""
			TextBoxModFreq1.Text = ""
			TextBoxModDep1.Text = "0"
			TextBoxModFreq1.Text = "0"
			TextBoxModDep1.ReadOnly = True
			TextBoxModFreq1.ReadOnly = True
		Else
			TextBoxModDep1.ReadOnly = False
			TextBoxModFreq1.ReadOnly = False
			Ch1Filter.Visible = False
			Ch1Filter.Checked = False
		End If

		If Ch1Noise.Checked = True Then
			TextBoxFreq1.ReadOnly = True
			Ch1Filter.Visible = True
		ElseIf Ch1Noise.Checked = False Then
			TextBoxFreq1.ReadOnly = False
			Ch1Filter.Visible = False
			Ch1Filter.Checked = False
		End If

	End Sub

	Private Sub DisableCh1Noise(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	 Handles Ch1Noise.CheckedChanged

		If Ch1Noise.Checked = True Then
			TextBoxFreq1.Clear()
			TextBoxFreq1.Text = ""
			TextBoxFreq1.Text = "200"
			TextBoxFreq1.ReadOnly = True
			Ch1Filter.Visible = True
		ElseIf Ch1Noise.Checked = False Then
			TextBoxFreq1.ReadOnly = False
			Ch1Filter.Visible = False
			Ch1Filter.Checked = False
		End If

	End Sub

	'Check form inputs to ensure bad values are not put into testcase
	Private Function Check_Data(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim index As Integer = 0
		Dim index1 As Integer = 0
		Dim AuditoryTextBoxControl As TextBox()() = {Ch1TextBoxs, Ch2TextBoxs}

		'Check Control Parameters
		Try
			Do While index < ControlBoxs.GetLength(0)
				Select Case index
					Case 0
						If ControlBoxs(index).Text() * 1.0 < 30 Or ControlBoxs(index).Text() * 1.0 > 500000 Or ControlBoxs(index).Text.Contains(".") Then
							MsgBox("Period is Invalid Input")
							Return False
						End If
					Case 1
						If ControlBoxs(index).Text() * 1.0 > 50000 Then
							MsgBox("Rep Count is Invalid Input")
							Return False
						End If
					Case Else
				End Select
				index = index + 1
			Loop
		Catch
			MsgBox("Bad Control Data")
			Return False
		End Try

		'Check Auditory Parameters
		Try
			index = 0
			Do While index < AuditoryTextBoxControl.GetLength(0)

				index1 = 0
				Do While index1 < AuditoryTextBoxControl(index).GetLength(0)
					Select Case index1
						Case 0

						Case 1

						Case 2

						Case 3

						Case 4

						Case 5

						Case Else
					End Select
					index1 = index1 + 1
				Loop

				index = index + 1
			Loop
		Catch
			Return False
		End Try


		'Check Electrical Parameters
		Try
			index = 0
			Do While index < ETextBoxs.GetLength(0)

				'If Electrical Stimulation is disabled, end checking of parameters
				If EStimDisable.Checked = True Then
					Exit Do
				End If

				Select Case index
					Case 0

					Case 1

					Case 2

					Case 3

					Case 4

					Case 5

					Case 6

					Case Else
				End Select
				index = index + 1
			Loop
		Catch
			Return False
		End Try

		'Data passes primary tests
		Return True
	End Function





	' %%%%% File Writing Functions %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

	'Randomizes the Elements in an array
	Private Sub RandomizeArray(ByVal sender As System.Object, ByVal e As System.EventArgs,
	   ByRef ArrRand1 As Double(), Optional ByRef ArrRand2 As Double() = Nothing)

		'Requires that the zeroth element of the input array is the number of elements to be randomized
		Dim i As Integer = 1
		Dim j As Integer = 1
		Dim temp As Integer
		Dim limit As Integer = ArrRand1(0)
		Randomize()

		If ArrRand2 Is Nothing Then

			For i = 1 To limit
				j = Int((limit - i) * Rnd() + i)

				temp = ArrRand1(i)
				ArrRand1(i) = ArrRand1(j)
				ArrRand1(j) = temp
			Next i
		Else

			Dim temp2 As Integer
			Dim limit2 As Integer = ArrRand2(0)

			If limit <> limit2 Then
				MsgBox("Error in Sweeping")
				Exit Sub
			End If

			For i = 1 To limit
				j = Int((limit - i) * Rnd() + i)
				temp = ArrRand1(i)
				temp2 = ArrRand2(i)
				ArrRand1(i) = ArrRand1(j)
				ArrRand2(i) = ArrRand2(j)
				ArrRand1(j) = temp
				ArrRand2(j) = temp2
			Next i
		End If

	End Sub

	'Constructs appropriately looped arrays for TDT
	Private Function Construct_Data(ByVal sender As System.Object, ByVal e As System.EventArgs)

		Reset_ReturnData(sender, e)

		If RandSets.Checked = True Then
			RandAll.Checked = False
			RandTrials.Checked = False
		ElseIf RandTrials.Checked = True Then
			RandSets.Checked = False
			RandAll.Checked = False
		ElseIf RandAll.Checked = True Then
			RandSets.Checked = False
			RandTrials.Checked = False
		End If

		If Check_Data(sender, e) = False Then
			Return False
		End If

		Dim ChosenIndicies As Double() = New Double(25) {}
		Dim index As Integer = 0
		Do While index < ChosenIndicies.GetLength(0)
			ChosenIndicies(index) = 0
			index = index + 1
		Loop

		Dim Sweep1 As Integer = 0
		Dim Sweep2 As Integer = 0
		Dim SweepR As Integer = 0

		Dim CollectionArray As Double()() = New Double(19)() {}
		For i = 0 To 19
			CollectionArray(i) = New Double(50000) {}
		Next i

		Dim TextBoxControl As TextBox()() = {Ch1TextBoxs, Ch2TextBoxs, ETextBoxs, ControlBoxs}
		Dim firstCount As Integer = 1
		Dim secondCount As Integer = 1

		Dim Data As Array
		Dim counter As Integer = 1
		Dim index1 As Integer = 0
		Dim index2 As Integer = 0
		Do While (index1 < TextBoxControl.GetLength(0))
			index2 = 0
			Do While (index2 < TextBoxControl(index1).Count)

				If (TextBoxControl(index1)(index2).Text.Contains(SweepDelimiters(0))) Then

					'Determine whether two parameters are being swept across each other or merely incremented
					If TextBoxControl(index1)(index2).Text.Contains(SweepDelimiters(1)) Then
						Sweep1 = counter
					ElseIf TextBoxControl(index1)(index2).Text.Contains(SweepDelimiters(2)) Then
						Sweep2 = counter
					ElseIf TextBoxControl(index1)(index2).Text.Contains(SweepDelimiters(3)) Then
						SweepR = counter
					End If
					'Save code for box with sweep parameter
					ChosenIndicies(counter) = counter
					ReturnData(0)(counter) = 10 * (index1 + 1) + (index2 + 1)

					'Data Incrementing Mechanism
					Dim indexA1 As Integer = 1
					If TextBoxControl(index1)(index2).Text.Contains(":") Then

						Data = Split(TextBoxControl(index1)(index2).Text, ":")
						Dim Data2 = Split(Data(0), " ")
						Dim numbah As Double = 1.0 * Data2(1)

						If (1.0 * Data2(1) < 1.0 * Data(2)) Then

							While numbah <= Data(2)
								CollectionArray(counter)(indexA1) = numbah

								'Do Octave Stepping for frequencies unless linear is enabled
								If (TextBoxControl(index1)(index2).Name.ToString.Contains("Freq1") Or
						   TextBoxControl(index1)(index2).Name.ToString.Contains("Freq2")) And
						   LinearEnable.Checked = False Then
									numbah = Round(numbah * 10 ^ (Abs(Data(1) * 0.30103)))
								Else
									numbah = numbah + Data(1) * 1.0
								End If
								indexA1 = indexA1 + 1
							End While
							CollectionArray(counter)(0) = indexA1 - 1

						ElseIf (1.0 * Data2(1) > 1.0 * Data(2)) Then
							While numbah >= Data(2)
								CollectionArray(counter)(indexA1) = numbah
								If (TextBoxControl(index1)(index2).Name.ToString.Contains("Freq1") Or
								 TextBoxControl(index1)(index2).Name.ToString.Contains("Freq2")) And
								 LinearEnable.Checked = False Then
									numbah = Round(numbah * 10 ^ (Abs(Data(1) * -0.30103)))
								Else
									numbah = numbah - Data(1) * 1.0
								End If
								indexA1 = indexA1 + 1
							End While
							CollectionArray(counter)(0) = indexA1 - 1

						End If

					Else
						Data = Split(TextBoxControl(index1)(index2).Text, " ")
						indexA1 = 1
						Dim numbah As Double = 1.0 * Data(1)
						While (indexA1 < Data.GetLength(0))
							numbah = 1.0 * Data(indexA1)
							CollectionArray(counter)(indexA1) = numbah
							indexA1 = indexA1 + 1
						End While
						CollectionArray(counter)(0) = indexA1 - 1
					End If

					counter = counter + 1
				End If
				index2 = index2 + 1
			Loop
			index1 = index1 + 1
		Loop


		'Randomize Arrays before sweeping
		If RandSets.Checked = True Then
			RandTrials.Checked = False
			RandomizeArray(sender, e, CollectionArray(Sweep1))
		End If

		'The ALGORITHM OF DOOOOOOOOMMMM
		Dim IORepper As Integer = TextBoxReps.Text() * 1.0

		If (Sweep1 > 0 And Sweep2 > 0) Then

			Dim Buffer As Double()() = New Double(1)() {}

			index1 = 0
			Do While index1 <= 1
				Buffer(index1) = New Double(50000) {}
				index1 = index1 + 1
			Loop

			firstCount = CollectionArray(Sweep1)(0)
			secondCount = CollectionArray(Sweep2)(0)

			index1 = 1
			index2 = 1
			Dim indexA As Integer = 1
			While index2 <= secondCount
				indexA = 1
				While indexA <= firstCount
					Buffer(0)(index1) = CollectionArray(Sweep1)(indexA)
					index1 = index1 + 1
					indexA = indexA + 1
				End While
				index2 = index2 + 1
			End While

			index1 = 1
			index2 = 1
			Dim limit As Integer = firstCount * secondCount
			While index1 <= limit
				While index1 <= (firstCount * index2)
					Buffer(1)(index1) = CollectionArray(Sweep2)(index2)
					index1 = index1 + 1
				End While
				index2 = index2 + 1
			End While

			Buffer(0)(0) = firstCount * secondCount
			Buffer(1)(0) = firstCount * secondCount

			'If RandTrials.Checked = True Then
			' RandomizeArray(sender, e, Buffer(0), Buffer(1))
			'End If

			index1 = 1
			index2 = 1
			If RepSets.Checked = True Then

				While index2 <= IORepper * firstCount * secondCount
					index1 = 1
					While index1 <= firstCount * secondCount
						ReturnData(Sweep1)(index2) = Buffer(0)(index1)
						ReturnData(Sweep2)(index2) = Buffer(1)(index1)
						index1 = index1 + 1
						index2 = index2 + 1
					End While
				End While

			ElseIf RepTrials.Checked = True Then

				indexA = 1
				While index2 <= firstCount * secondCount
					index1 = 1
					While index1 <= IORepper
						ReturnData(Sweep1)(indexA) = Buffer(0)(index2)
						ReturnData(Sweep2)(indexA) = Buffer(1)(index2)
						index1 = index1 + 1
						indexA = indexA + 1
					End While
					index2 = index2 + 1
				End While

			End If

			ReturnData(0)(0) = (firstCount * secondCount * IORepper)
			index1 = 1
			While ReturnData(0)(index1) <> 0
				ReturnData(index1)(0) = ReturnData(0)(0)
				index1 = index1 + 1
			End While

		ElseIf ChosenIndicies.Sum() > 0 Then

            'Do an average analysis to determine if lengths were properly input
            index1 = 1
			While ChosenIndicies(index1) <> 0
				index1 = index1 + 1
			End While

			index2 = 1
			Dim thesum As Integer = 0
			While index2 < index1
				thesum = thesum + CollectionArray(ChosenIndicies(index2))(0)
				index2 = index2 + 1
			End While
			index1 = index1 - 1

			index2 = 1
			Do While index2 <= index1
				If ((thesum / index1) <> CollectionArray(ChosenIndicies(index2))(0)) Then
					MsgBox("Bad Data Inputs: Size Mismatch with Input#" & ChosenIndicies(index2))
					Return False
				End If
				index2 = index2 + 1
			Loop

			firstCount = CollectionArray(ChosenIndicies(1))(0)

			index1 = 1
			index2 = 1
			Dim indexA1 As Integer = 1
			If RepSets.Checked = True Then

				While index2 <= IORepper * firstCount
					index1 = 1
					While index1 <= firstCount
						indexA1 = 1
						Do While ChosenIndicies(indexA1) <> 0
							ReturnData(indexA1)(index2) = CollectionArray(ChosenIndicies(indexA1))(index1)
							indexA1 = indexA1 + 1
						Loop
						index1 = index1 + 1
						index2 = index2 + 1
					End While
				End While

			ElseIf RepTrials.Checked = True Then

				Dim IndexA As Integer = 1
				While index2 <= firstCount
					index1 = 1
					While index1 <= IORepper
						indexA1 = 1
						Do While ChosenIndicies(indexA1) <> 0
							ReturnData(indexA1)(IndexA) = CollectionArray(ChosenIndicies(indexA1))(index2)
							indexA1 = indexA1 + 1
						Loop
						index1 = index1 + 1
						IndexA = IndexA + 1
					End While
					index2 = index2 + 1
				End While

			End If

			ReturnData(0)(0) = firstCount * IORepper
			index1 = 1
			While ReturnData(0)(index1) <> 0
				ReturnData(index1)(0) = ReturnData(0)(0)
				index1 = index1 + 1
			End While

		ElseIf (ChosenIndicies.Sum() = 0) Then

			ReturnData(0)(0) = IORepper

		End If

		'Final(Randomization)
		If RandAll.Checked And Sweep1 > 0 And Sweep2 > 0 Then
			RandomizeArray(sender, e, ReturnData(Sweep1), ReturnData(Sweep2))
			RandomizeArray(sender, e, ReturnData(Sweep1), ReturnData(Sweep2))
			RandomizeArray(sender, e, ReturnData(Sweep1), ReturnData(Sweep2))
		End If

		Return True
	End Function

	'Write TDT iterative data to testcasefile
	Private Sub Write_TDT_Data(ByVal sender As System.Object, ByVal e As System.EventArgs,
	   ByRef FileWriter As StreamWriter)

		Dim index2 As Integer = 1
		Dim indexD As Integer = 0
		Dim counter As Integer = 1

		Dim Voltage As Double() = New Double(10000) {}
		Dim Power As Double() = New Double(10000) {}
		Dim index_power As Integer = 1
		Dim mixing_variable As String = "FALSE"

		'%%%%%%%%% Control Parameters %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		FileWriter.Write("''Timing Control Parameters" & vbCrLf)
		Do While indexD < ControlBoxs.Count
			FileWriter.Write(ControlParams(indexD) & ": " & ControlBoxs(indexD).Text.ToString() & vbCrLf)
			indexD = indexD + 1
		Loop

		If MixAudioSignals = True Then
			mixing_variable = "TRUE"
		Else
			mixing_variable = "FALSE"
		End If
		FileWriter.Write("MixSignals: ' " & mixing_variable & vbCrLf)

		If Mouse_Signals = True Then
			FileWriter.Write("Mouse: True" & vbCrLf)
		Else
			FileWriter.Write("Mouse: False" & vbCrLf)
		End If

		FileWriter.Write("''" & vbCrLf)


		'%%%%%%%%% Channel One Parameters %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		FileWriter.Write("''Channel One Parameters" & vbCrLf)
		'DavidM'
		If Ch1Tone.Checked Then
			FileWriter.Write("SType1: TONE" & vbCrLf)
			FileWriter.Write("Filter1: FALSE" & vbCrLf)
		Else
			FileWriter.Write("SType1: NOISE" & vbCrLf)
			If Ch1Filter.Checked Then
				FileWriter.Write("Filter1: TRUE" & vbCrLf)
			Else
				FileWriter.Write("Filter1: FALSE" & vbCrLf)
			End If
		End If

		If CH1AM_Check.Checked Then
			FileWriter.Write("CH1AM: TRUE" & vbCrLf)
		Else
			FileWriter.Write("CH1AM: FALSE" & vbCrLf)
		End If

		indexD = 0
		While indexD < Ch1TextBoxs.Count
			FileWriter.Write(Ch1Params(indexD) & ": ")
			index2 = 1
			If (ReturnData(0)(counter) = 11 + indexD) Then
				While index2 <= ReturnData(0)(0)
					FileWriter.Write(ReturnData(counter)(index2) & " ")
					index2 = index2 + 1
				End While
				counter = counter + 1
			Else
				While index2 <= ReturnData(0)(0)
					FileWriter.Write(Ch1TextBoxs(indexD).Text.ToString() & " ")
					index2 = index2 + 1
				End While
			End If
			indexD = indexD + 1
			FileWriter.Write(vbCrLf)
		End While
		index2 = 1
		FileWriter.Write("Filter1: ")
		While index2 <= ReturnData(0)(0)
			If Ch1Filter.Checked = True Then
				FileWriter.Write(1 & " ")
			Else
				FileWriter.Write(0 & " ")
			End If
			index2 = index2 + 1
		End While
		FileWriter.Write(vbCrLf)
		FileWriter.Write("''" & vbCrLf)


		'%%%%%%%%% Channel Two Parameters %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		FileWriter.Write("''Channel Two Parameters" & vbCrLf)
		'DavidM'
		If Ch2Tone.Checked Then
			FileWriter.Write("SType2: TONE" & vbCrLf)
			FileWriter.Write("Filter2: FALSE" & vbCrLf)
		Else
			FileWriter.Write("SType2: NOISE" & vbCrLf)
			If Ch2Filter.Checked Then
				FileWriter.Write("Filter2: TRUE" & vbCrLf)
			Else
				FileWriter.Write("Filter2: FALSE" & vbCrLf)
			End If
		End If

		If CH2AM_Check.Checked Then
			FileWriter.Write("CH2AM: TRUE" & vbCrLf)
		Else
			FileWriter.Write("CH2AM: FALSE" & vbCrLf)
		End If

		indexD = 0
		While indexD < Ch2TextBoxs.Count
			FileWriter.Write(Ch2Params(indexD) & ": ")
			index2 = 1
			If (ReturnData(0)(counter) = 21 + indexD) Then
				While index2 <= ReturnData(0)(0)
					FileWriter.Write(ReturnData(counter)(index2) & " ")
					index2 = index2 + 1
				End While
				counter = counter + 1
			Else
				While index2 <= ReturnData(0)(0)
					FileWriter.Write(Ch2TextBoxs(indexD).Text.ToString() & " ")
					index2 = index2 + 1
				End While
			End If
			indexD = indexD + 1
			FileWriter.Write(vbCrLf)
		End While
		index2 = 1
		FileWriter.Write("Filter2: ")
		While index2 <= ReturnData(0)(0)
			If Ch2Filter.Checked = True Then
				FileWriter.Write(1 & " ")
			Else
				FileWriter.Write(0 & " ")
			End If
			index2 = index2 + 1
		End While
		FileWriter.Write(vbCrLf)
		FileWriter.Write("''" & vbCrLf)


		'%%%%%%%%% Electrical Parameters %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
		FileWriter.Write("''Electrical Parameters" & vbCrLf)
		If EStimEnable.Checked Then
			FileWriter.Write("EStimEnable: TRUE" & vbCrLf)
		Else
			FileWriter.Write("EStimEnable: FALSE" & vbCrLf)
		End If

		If Laser_Tag.Checked Then
			FileWriter.Write("Laser: TRUE" & vbCrLf)
		Else
			FileWriter.Write("Laser: FALSE" & vbCrLf)
		End If

		If EStimTypeBi.Checked Then
			FileWriter.Write("EStimType: BI" & vbCrLf)
		Else
			FileWriter.Write("EStimType: MONO" & vbCrLf)
		End If

		If BiPhaseNeg.Checked Then
			FileWriter.Write("BiPhase: NEG" & vbCrLf)
		Else
			FileWriter.Write("BiPhase: POS" & vbCrLf)
		End If

		indexD = 0
		While indexD < ETextBoxs.Count

			If EParams(indexD) = "EAmpl" And Laser_Tag.Checked Then

				Dim LaserReader = New StreamReader(LaserData)

				Dim temp_string As String
				Dim power_data As String()
				Dim max_power As Double = 1.0
				index_power = 1

				While LaserReader.Peek <> -1
					temp_string = LaserReader.ReadLine()
					power_data = Split(temp_string, ",")

					If index_power = 1 Then
						Voltage(index_power) = 0
						Power(index_power) = 0
					Else
						Voltage(index_power) = Convert.ToDouble(power_data(0))
						Power(index_power) = Convert.ToDouble(power_data(1))
					End If

					index_power = index_power + 1

				End While
				max_power = Power(index_power - 1)

				While index_power <= 10000
					Voltage(index_power) = 5.0
					Power(index_power) = max_power
					index_power = index_power + 1
				End While

				LaserReader.Close()

			End If

			FileWriter.Write(EParams(indexD) & ": ")
			index2 = 1
			If (ReturnData(0)(counter) = 31 + indexD) Then
				While index2 <= ReturnData(0)(0)

					If EParams(indexD) = "EAmpl" And Laser_Tag.Checked Then
						index_power = 0
						While ReturnData(counter)(index2) > Power(index_power)
							index_power = index_power + 1
						End While

						ReturnData(counter)(index2) = Voltage(index_power)
					End If

					FileWriter.Write(ReturnData(counter)(index2) & " ")

					index2 = index2 + 1
				End While
				counter = counter + 1
			Else
				While index2 <= ReturnData(0)(0)
					Dim temp_string As String = ETextBoxs(indexD).Text.ToString()

					If EParams(indexD) = "EAmpl" And Laser_Tag.Checked Then
						index_power = 0
						Dim temp_double As Double = 0.0

						While Convert.ToDouble(ETextBoxs(indexD).Text) >= Power(index_power) And index_power < 10000
							index_power = index_power + 1
						End While
						temp_double = Voltage(index_power)
						temp_string = Convert.ToString(temp_double)
					End If

					FileWriter.Write(temp_string & " ")
					index2 = index2 + 1
				End While
			End If
			indexD = indexD + 1
			FileWriter.Write(vbCrLf)
		End While
		FileWriter.Write("''")

	End Sub

	'Write Constructor Data to testcasefile
	Private Sub Write_Constructor_Data(ByVal sender As System.Object, ByVal e As System.EventArgs,
	  ByRef FileWriter As StreamWriter)

		Dim indexD As Integer = 0

		'Write Main Auditory Control Data
		FileWriter.Write("//USER CONTROL DATA" & vbCrLf)
		FileWriter.Write("//" & vbCrLf)
		FileWriter.Write("//Timing Control Parameters" & vbCrLf)
		Do While indexD < ControlBoxs.Count
			FileWriter.Write("//" & ControlParams(indexD) & ": " & ControlBoxs(indexD).Text.ToString() & vbCrLf)
			indexD = indexD + 1
		Loop
		If RepSets.Checked = True Then
			FileWriter.Write("//RepType: SETS" & vbCrLf)
		Else
			FileWriter.Write("//RepType: TRIALS" & vbCrLf)
		End If
		If LinearEnable.Checked = True Then
			FileWriter.Write("//FreqStep: LINEAR" & vbCrLf)
		Else
			FileWriter.Write("//FreqStep: OCTAVE" & vbCrLf)
		End If
		If RandAll.Checked = True Then
			FileWriter.Write("//RandType: ALL" & vbCrLf)
		ElseIf RandSets.Checked = True Then
			FileWriter.Write("//RandType: BLOCKS" & vbCrLf)
		Else
			FileWriter.Write("//RandType: NONE" & vbCrLf)
		End If

		If MixAudioSignals = True Then
			FileWriter.Write("//MixSignals: TRUE" & vbCrLf)
		Else
			FileWriter.Write("//MixSignals: FALSE" & vbCrLf)
		End If

		If Mouse_Signals = True Then
			FileWriter.Write("//Mouse: True" & vbCrLf)
		Else
			FileWriter.Write("//Mouse: False" & vbCrLf)
		End If

		FileWriter.Write("//" & vbCrLf)


		'Write Channel 1 Data
		'DavidM'
		FileWriter.Write("//Channel One Parameters" & vbCrLf)
		If Ch1Tone.Checked Then
			FileWriter.Write("//SType1: TONE" & vbCrLf)
			FileWriter.Write("//Filter1: FALSE" & vbCrLf)
		Else
			FileWriter.Write("//SType1: NOISE" & vbCrLf)
			If Ch1Filter.Checked Then
				FileWriter.Write("//Filter1: TRUE" & vbCrLf)
			Else
				FileWriter.Write("//Filter1: FALSE" & vbCrLf)
			End If
		End If

		If CH1AM_Check.Checked Then
			FileWriter.Write("//CH1AM: TRUE" & vbCrLf)
		Else
			FileWriter.Write("//CH1AM: FALSE" & vbCrLf)
		End If

		indexD = 0
		Do While indexD < Ch1TextBoxs.Count
			FileWriter.Write("//" & Ch1Params(indexD) & ": " & Ch1TextBoxs(indexD).Text.ToString() & vbCrLf)
			indexD = indexD + 1
		Loop
		FileWriter.Write("//" & vbCrLf)


		'Write Channel 2 Data
		'DavidM'
		FileWriter.Write("//Channel Two Parameters" & vbCrLf)
		If Ch2Tone.Checked Then
			FileWriter.Write("//SType2: TONE" & vbCrLf)
			FileWriter.Write("//Filter2: FALSE" & vbCrLf)
		Else
			FileWriter.Write("//SType2: NOISE" & vbCrLf)
			If Ch2Filter.Checked Then
				FileWriter.Write("//Filter2: TRUE" & vbCrLf)
			Else
				FileWriter.Write("//Filter2: FALSE" & vbCrLf)
			End If
		End If

		If CH2AM_Check.Checked Then
			FileWriter.Write("//CH2AM: TRUE" & vbCrLf)
		Else
			FileWriter.Write("//CH2AM: FALSE" & vbCrLf)
		End If

		indexD = 0
		Do While indexD < Ch2TextBoxs.Count
			FileWriter.Write("//" & Ch2Params(indexD) & ": " & Ch2TextBoxs(indexD).Text.ToString() & vbCrLf)
			indexD = indexD + 1
		Loop
		FileWriter.Write("//" & vbCrLf)


		'Write Electrical Stimulation Data
		FileWriter.Write("//Electrical Parameters" & vbCrLf)
		If EStimEnable.Checked Then
			FileWriter.Write("//EStimEnable: TRUE" & vbCrLf)
		Else
			FileWriter.Write("//EStimEnable: FALSE" & vbCrLf)
		End If

		If EStimTypeBi.Checked Then
			FileWriter.Write("//EStimType: BI" & vbCrLf)
		Else
			FileWriter.Write("//EStimType: MONO" & vbCrLf)
		End If

		If BiPhaseNeg.Checked Then
			FileWriter.Write("//BiPhase: NEG" & vbCrLf)
		Else
			FileWriter.Write("//BiPhase: POS" & vbCrLf)
		End If

		If Laser_Tag.Checked Then
			FileWriter.Write("//Laser: TRUE" & vbCrLf)
		Else
			FileWriter.Write("//Laser: FALSE" & vbCrLf)
		End If

		indexD = 0
		Do While indexD < ETextBoxs.Count
			FileWriter.Write("//" & EParams(indexD) & ": " & ETextBoxs(indexD).Text.ToString() & vbCrLf)
			indexD = indexD + 1
		Loop
		FileWriter.Write("//" & vbCrLf)

		FileWriter.Write("//END OF USER CONTROL DATA" & vbCrLf)
		FileWriter.Write("//" & vbCrLf)
	End Sub

	'Write All data to initially selected test case
	Private Sub ButtonWrtAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
	 Handles ButtonWrtAll.Click

		'Construct Data Arrays; If fails then will break
		If Construct_Data(sender, e) = False Then
			Exit Sub
		End If

		'Select File to Write Test Case to
		Results = SaveFileDialog1.ShowDialog

		While (Results <> DialogResult.OK)
			If (Results = DialogResult.Retry) Then
				Results = SaveFileDialog1.ShowDialog
			ElseIf (Results = DialogResult.Cancel) Then
				Exit Sub
			End If
		End While

		FileWriter = New StreamWriter(SaveFileDialog1.FileName, False)
		CurrentTestCase = SaveFileDialog1.FileName.ToString()
		If Ch1Filter.Checked Then
			'Ch1FilterDesign.PerformClick()
		End If


		'Write Test Case Constructor stored parameters list to test case file
		Write_Constructor_Data(sender, e, FileWriter)

		'Write raw data to be used by TDT Set up to testcase file
		Write_TDT_Data(sender, e, FileWriter)

		MsgBox("Parameters stored to: " & SaveFileDialog1.FileName)
		UpdateNames(sender, e, SaveFileDialog1.FileName().ToString())

		Dim SavedFiles As String() = New String(50) {}
		Dim FileReader = New StreamReader(Form2.Targetlocation)
		Dim index As Integer = 0
		Dim count As Integer = 0
		Do While FileReader.Peek <> -1
			SavedFiles(index) = FileReader.ReadLine().ToString()
			index = index + 1
			count = count + 1
		Loop
		FileReader.Close()

		index = 0
		Do While index < count
			If SavedFiles(index).ToString() = SaveFileDialog1.FileName().ToString() Then
				Form2.compilelabel.Text = "FALSE"
				Form2.compilelabel.ForeColor = Color.Red
				Exit Do
			End If
			index = index + 1
		Loop


		Form2.Change_Directory(sender, e)
		FileWriter.Close()

	End Sub





	' %%%%% Load Data Functions %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

	'Read in data from a textfile
	Public Sub ButtonLoadTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs,
	   Optional ByVal filename As String = DEFAULTSTRING) Handles ButtonLoadTest.Click

		If filename = DEFAULTSTRING Then
			Dim ResultsO As DialogResult
			Do
				ResultsO = OpenFileDialog1.ShowDialog
				filename = OpenFileDialog1.FileName
				If ResultsO = DialogResult.Cancel Then
					Exit Sub
				End If
			Loop Until ResultsO = DialogResult.OK
		End If

		Dim FileReader As StreamReader
		Try
			FileReader = New StreamReader(filename)
			CurrentTestCase = filename
		Catch
			MsgBox("File Did Not Open")
			Exit Sub
		End Try

		UpdateNames(sender, e, filename)

		Dim Buffer As String
		Dim Items As String()

		ButtonClrAll_Click(sender, e, True)

		LoadCh1_Click(sender, e, filename)
		LoadCh2_Click(sender, e, filename)
		LoadEParam_Click(sender, e, filename)
		Dim index As Integer = 1
		While FileReader.Peek <> -1
			Buffer = FileReader.ReadLine
			Items = Split(Buffer, " ")

			index = 1
			Select Case Items(0)
				Case "//APeriod:"
					While index < Items.GetLength(0)
						TextBoxPeriod.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxPeriod)

				Case "//IOReps:"
					While index < Items.GetLength(0)
						TextBoxReps.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxReps)

				Case "//RepType:"
					If Items(1) = "SETS" Then
						RepSets.Checked = True
					Else
						RepTrials.Checked = True
					End If

				Case "//FreqStep:"
					If Items(1) = "LINEAR" Then
						LinearEnable.Checked = True
					Else
						LinearEnable.Checked = False
					End If

				Case "//MixSignals:"
					If Items(1) = "FALSE" Then
						MixSignals.Checked = False
					Else
						MixSignals.Checked = True
					End If

				Case "//Mouse:"
					If Items(1) = "False" Then
						Mouse.Checked = False
					Else
						Mouse.Checked = True
					End If

				Case "//RandType:"
					If Items(1) = "BLOCKS" Then
						RandSets.Checked = True
					ElseIf Items(1) = "ALL" Then
						RandAll.Checked = True
					Else
						RandTrials.Checked = True
					End If
			End Select
		End While

		FileReader.Close()
	End Sub

	'load channel 1 data from a user selected test case
	Private Sub LoadCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs,
	  Optional ByVal filename As String = DEFAULTSTRING) Handles LoadCh1.Click

		Dim ResultsO As DialogResult

		If (filename = DEFAULTSTRING) Then
			Do
				ResultsO = OpenFileDialog1.ShowDialog
				filename = OpenFileDialog1.FileName
				CurrentTestCase = filename
				If ResultsO = DialogResult.Cancel Then
					Exit Sub
				End If
			Loop Until ResultsO = DialogResult.OK
		End If

		Dim FileReader As StreamReader

		Try
			FileReader = New StreamReader(filename)
		Catch
			MsgBox("File Did Not Open")
			Exit Sub
		End Try

		Dim Buffer As String
		Dim Items As String()

		ClearCh1_Click(sender, e, True)
		While FileReader.Peek <> -1
			Buffer = FileReader.ReadLine
			Items = Split(Buffer, " ")
			Dim index As Integer = 1

			'DavidM'
			Select Case Items(0)
				Case "//SType1:"
					Select Case Items(1)
						Case "TONE"
							Ch1Tone.Checked = True
						Case "NOISE"
							Ch1Noise.Checked = True
					End Select
				Case "//CH1AM:"
					Select Case Items(1)
						Case "TRUE"
							CH1AM_Check.Checked = True
						Case "FALSE"
							CH1AM_Check.Checked = False
					End Select
				Case "//Filter1:"
					Select Case Items(1)
						Case "TRUE"
							Ch1Filter.Checked = True
						Case "FALSE"
							Ch1Filter.Checked = False
					End Select
				Case "//ARF1:"
					While index < Items.GetLength(0)
						TextBoxCH1RFTime.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxCH1RFTime)
				Case "//ADur1:"
					While index < Items.GetLength(0)
						TextBoxCh1Dur.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxCh1Dur)
				Case "//Delays1:"
					While index < Items.GetLength(0)
						TextBoxDelay1.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxDelay1)
				Case "//Freq1:"
					While index < Items.GetLength(0)
						TextBoxFreq1.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxFreq1)
				Case "//Amp1:"
					While index < Items.GetLength(0)
						TextBoxAmp1.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxAmp1)
				Case "//ModDep1:"
					While index < Items.GetLength(0)
						TextBoxModDep1.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxModDep1)
				Case "//ModFreq1:"
					While index < Items.GetLength(0)
						TextBoxModFreq1.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxModFreq1)
				Case Else
			End Select

		End While

		FileReader.Close()
	End Sub

	'Load channel 2 data from a user selected testcase
	Private Sub LoadCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs,
	  Optional ByVal filename As String = DEFAULTSTRING) Handles LoadCh2.Click

		Dim ResultsO As DialogResult

		If filename = DEFAULTSTRING Then
			Do
				ResultsO = OpenFileDialog1.ShowDialog
				filename = OpenFileDialog1.FileName
				If ResultsO = DialogResult.Cancel Then
					Exit Sub
				End If
			Loop Until ResultsO = DialogResult.OK
		End If

		Dim FileReader As StreamReader
		FileReader = New StreamReader(filename)

		Dim Buffer As String
		Dim Items As String()

		ClearCh2_Click(sender, e, True)
		While FileReader.Peek <> -1
			Buffer = FileReader.ReadLine
			Items = Split(Buffer, " ")
			Dim index As Integer = 1
			'DavidM'
			Select Case Items(0)
				Case "//SType2:"
					Select Case Items(1)
						Case "TONE"
							Ch2Tone.Checked = True
						Case "NOISE"
							Ch2Noise.Checked = True
					End Select
				Case "//CH2AM:"
					Select Case Items(1)
						Case "TRUE"
							CH2AM_Check.Checked = True
						Case "FALSE"
							CH2AM_Check.Checked = False
					End Select
				Case "//Filter2:"
					Select Case Items(1)
						Case "TRUE"
							Ch2Filter.Checked = True
						Case "FALSE"
							Ch2Filter.Checked = False
					End Select
				Case "//ARF2:"
					While index < Items.GetLength(0)
						TextBoxCH2RFTime.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxCH2RFTime)
				Case "//ADur2:"
					While index < Items.GetLength(0)
						TextBoxCh2Dur.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxCh2Dur)
				Case "//Delays2:"
					While index < Items.GetLength(0)
						TextBoxDelay2.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxDelay2)
				Case "//Freq2:"
					While index < Items.GetLength(0)
						TextBoxFreq2.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxFreq2)
				Case "//Amp2:"
					While index < Items.GetLength(0)
						TextBoxAmp2.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxAmp2)
				Case "//ModDep2:"
					While index < Items.GetLength(0)
						TextBoxModDep2.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxModDep2)
				Case "//ModFreq2:"
					While index < Items.GetLength(0)
						TextBoxModFreq2.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxModFreq2)
				Case Else
			End Select

		End While

		FileReader.Close()
	End Sub

	'Load electrical data from user selected test case
	Private Sub LoadEParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs,
	  Optional ByVal filename As String = DEFAULTSTRING) _
	  Handles LoadEParam.Click

		Dim ResultsO As DialogResult

		If filename = DEFAULTSTRING Then
			Do
				ResultsO = OpenFileDialog1.ShowDialog
				filename = OpenFileDialog1.FileName
				If ResultsO = DialogResult.Cancel Then
					Exit Sub
				End If
			Loop Until ResultsO = DialogResult.OK
		End If

		Dim FileReader As StreamReader
		FileReader = New StreamReader(filename)
		Dim Buffer As String
		Dim Items As String()

		'Reset form boxes
		ClearEParam_Click(sender, e, True)
		While FileReader.Peek <> -1
			Buffer = FileReader.ReadLine
			Items = Split(Buffer, " ")
			Dim index As Integer = 1

			Select Case Items(0)

				Case "//EStimEnable:"
					Select Case Items(1)
						Case "FALSE"
							EStimDisable.Checked = True
						Case "TRUE"
							EStimEnable.Checked = True
					End Select
				Case "//EStimType:"
					Select Case Items(1)
						Case "BI"
							EStimTypeBi.Checked = True
						Case "MONO"
							EStimTypeMono.Checked = True
					End Select
				Case "//BiPhase:"
					Select Case Items(1)
						Case "NEG"
							BiPhaseNeg.Checked = True
						Case "TRUE"
							BiPhasePos.Checked = True
					End Select
				Case "//Laser:"
					Select Case Items(1)
						Case "TRUE"
							Laser_Tag.Checked = True
						Case "FALSE"
							Laser_Tag.Checked = False
					End Select
				Case "//EDel:"
					While index < Items.GetLength(0)
						TextBoxEDel.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxEDel)
				Case "//EAmpl:"
					While index < Items.GetLength(0)
						TextBoxEAmpl.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxEAmpl)
				Case "//EDur:"
					While index < Items.GetLength(0)
						TextBoxEDur.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxEDur)
				Case "//EPFreq:"
					While index < Items.GetLength(0)
						TextBoxEPFreq.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxEPFreq)
				Case "//EPWidth:"
					While index < Items.GetLength(0)
						TextBoxEPWidth.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxEPWidth)
				Case "//IPGap:"
					While index < Items.GetLength(0)
						TextBoxIPGap.AppendText(Items(index) & " ")
						index = index + 1
					End While
					Remove_Last(sender, e, TextBoxIPGap)

				Case Else
			End Select

		End While

		FileReader.Close()

	End Sub

	' %%%%% State Change Functions %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
	' %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


	Private Sub TextBoxFreq2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxFreq2.TextChanged
		If TextBoxFreq2.Text = "200200" Or TextBoxFreq2.Text = "200200200" Then
			TextBoxFreq2.Text = "200"
		End If
	End Sub

	Private Sub TextBoxFreq1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxFreq1.TextChanged
		If TextBoxFreq1.Text = "200200" Or TextBoxFreq1.Text = "200200200" Then
			TextBoxFreq1.Text = "200"
		End If
	End Sub

	Private Sub Ch1Filter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Ch1Filter.CheckedChanged

		If Ch1Filter.Checked = True Then
			Ch1FilterDesign.Visible = True
		Else
			Reset_Filter(sender, e)
			Ch1FilterDesign.Visible = False
			Reset_Filter(sender, e)
		End If


	End Sub

	Private Sub Reset_Filter(sender As System.Object, e As System.EventArgs)

		Dim Filter1File = New StreamWriter(Form2.DataDirectory & "Filter1Coeffs.txt", False)
		Dim ONE As Single = 1.0
		Dim ZERO As Single = 0.0

		Filter1File.Write(ONE & vbCrLf)
		For idx As Integer = 2 To 129
			Filter1File.Write(ZERO & vbCrLf)
		Next

		Filter1File.Close()

	End Sub


	Private Sub Ch1FilterDesign_Click(sender As System.Object, e As System.EventArgs) Handles Ch1FilterDesign.Click

		Dim Filter_Coeffs As Double(,) = New Double(1, 128) {}

		MATLAB = CreateObject("matlab.application")
        MATLAB.Execute("cd 'C:\TDT\SHORELAB\Filtering';")
        MATLAB.Execute("Noise_Stimulus_Generation()")
		Filter_Coeffs = MATLAB.GetVariable("Num", "base")
		MATLAB.Quit()

		Dim FileWriterNew = New StreamWriter(CurrentTestCase & " FILTER COEFFS", False)
		For idx As Integer = 0 To 128
			FileWriterNew.Write(Filter_Coeffs(0, idx) & vbCrLf)
		Next
		FileWriterNew.Close()

	End Sub



	Private Sub Laser_Tag_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Laser_Tag.CheckedChanged

		If Laser_Tag.Checked = True Then
			EStimTypeMono.Checked = True
			BiPhasePos.Checked = True
			BiPhaseNeg.Checked = False
			EStimTypeBi.Enabled = False

			BiPhaseNeg.Enabled = False

		Else

			EStimTypeBi.Checked = True
			BiPhasePos.Checked = True
			EStimTypeBi.Enabled = True
			BiPhaseNeg.Enabled = True

		End If

	End Sub

	Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CH2AM_Check.CheckedChanged

		If CH2AM_Check.Checked = False Then
			TextBoxModDep2.Clear()
			TextBoxModFreq2.Clear()
			TextBoxModDep2.Text = ""
			TextBoxModFreq2.Text = ""
			TextBoxModDep2.Text = "0"
			TextBoxModFreq2.Text = "0"
			TextBoxModDep2.ReadOnly = True
			TextBoxModFreq2.ReadOnly = True
		Else
			TextBoxModDep2.ReadOnly = False
			TextBoxModFreq2.ReadOnly = False
		End If


	End Sub

	Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CH1AM_Check.CheckedChanged

		If CH1AM_Check.Checked = False Then
			TextBoxModDep1.Clear()
			TextBoxModFreq1.Clear()
			TextBoxModDep1.Text = ""
			TextBoxModFreq1.Text = ""
			TextBoxModDep1.Text = "0"
			TextBoxModFreq1.Text = "0"
			TextBoxModDep1.ReadOnly = True
			TextBoxModFreq1.ReadOnly = True
		Else
			TextBoxModDep1.ReadOnly = False
			TextBoxModFreq1.ReadOnly = False
		End If

	End Sub


	Private Sub MixSignals_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles MixSignals.CheckedChanged

		If MixSignals.Checked = True Then
			MixAudioSignals = False
		Else
			MixAudioSignals = True
		End If


	End Sub


	Private Sub Mouse_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Mouse.CheckedChanged

		If Mouse.Checked = True Then
			Mouse_Signals = False
			EnableCh2(sender, e)
			EStimDisable.Checked = False
		Else
			Mouse_Signals = True
			EStimDisable.Checked = True
			DisableCh2(sender, e)

		End If

	End Sub
End Class
