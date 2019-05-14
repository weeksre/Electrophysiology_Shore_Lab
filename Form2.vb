Imports System.IO
Imports System.Math
Imports System
Imports TDEVACCXLib
Imports ZBUSXLib


Public Class Form2

    'TDT Run Time Variables
    Dim TDA As TDevAccX = New TDevAccX
    Dim zBUS As ZBUSx = New ZBUSx
    Dim Host_Name As String = Net.Dns.GetHostName

    Dim BaseFile As String = "C:\TDT\SHORELAB\"

    Dim PrevSwpN As Double = -1.0
    Dim SwpN As Double = 0.0
    Dim SwpCount As Double = 0.0
    Dim Atten1 As Double = 55.5
    Dim Atten2 As Double = 55.5
	Dim TEMP_VAR As Double = 0.0
    Dim AvgT As Double

    'Dim HardWareData As String = "C:\Users\shorelab\Desktop\Stimulus Protocol Filesystem\Hardware Data\"
    Dim displayfile As String() = New String(20) {}

    Dim Attenuator1 As Double() = New Double(50000) {}
    Dim Attenuator2 As Double() = New Double(50000) {}

    Dim Intensity1 As Double() = New Double(50000) {}
    Dim Frequency1 As Double() = New Double(50000) {}
    Dim Delay1 As Double() = New Double(50000) {}
    Dim Duration1 As Double() = New Double(50000) {}

    Dim Intensity2 As Double() = New Double(50000) {}
    Dim Frequency2 As Double() = New Double(50000) {}
    Dim Delay2 As Double() = New Double(50000) {}
    Dim Duration2 As Double() = New Double(50000) {}

    Dim RecordState As Integer = 3

	Dim MaxAttenuator As String = "120"
	Dim MaxVoltage As String = "10"

    'Data Constructor Variables
    Dim FileWriter As StreamWriter
    Dim FileReader As StreamReader

    Dim ReadingLocation As String = Form1.WorkingDirectory

    'Choose other base when working on U: drive
    'Dim BaseDirectory As String = "U:\DavidM\TDT Test Case Generator\Targets\"
    Dim BaseDirectory As String = BaseFile & "UserFiles\"
    Public Targetlocation As String = BaseDirectory & "FileRunList.txt"
    Public DataDirectory As String = BaseFile & "SES\"
    ' "C:\Users\shorelab\Desktop\Stimulus Protocol Filesystem\Hardware Data\"
    'Public LaserData As String = "C:\Users\shorelab\Desktop\TDT Test Case Generator"

    Public SortFile As String = BaseFile & "sorts.dat"
    Dim Sort_State As Double() = New Double(63) {}
	Dim Auto_Sort_Load As Boolean = False
	Dim Auto_Sort_Save As Boolean = False
	Dim temp_buffer As Double() = New Double(50000) {}

	Dim MAX_FREQ_SIZE As Integer = 46000
	Dim Attarr1 As Double() = New Double(MAX_FREQ_SIZE) {}
	Dim Attarr2 As Double() = New Double(MAX_FREQ_SIZE) {}

	Dim NoiseSeed1 As Double = 0
	Dim NoiseSeed2 As Double = 0

    Dim Mouse_Value As Boolean = False

    Dim RECORDING_DEVICE As String
    Dim STIMULATING_DEVICE As String
    Dim Estim As String

    Public Sub The_Shield_is_Down(ByVal sender As Object, ByVal e As System.EventArgs) Handles ShieldDown.Click

        MouseLabel.Enabled = False

        If Host_Name = "khri-5434sesmon" Then
            RECORDING_DEVICE = "Recording"
            STIMULATING_DEVICE = "Astim" 'Astim --> RZ6_1
            If zBUS.ConnectZBUS("GB") Then
                MsgBox("Connection Established")
            Else
                MsgBox("No Connection")
            End If
        ElseIf Host_Name = "RDE-ShoreLab1" Then
            RECORDING_DEVICE = "RZ2_1"
            STIMULATING_DEVICE = "RX6_1"
            Estim = "RX8_1"
        End If

        Dim Freq1File = New StreamWriter(DataDirectory & "Freq1List.txt", False)
        Dim Intensity1File = New StreamWriter(DataDirectory & "Intensity1List.txt", False)
        Dim Amplitude1File = New StreamWriter(DataDirectory & "Amplitude1List.txt", False)
        Dim Delay1File = New StreamWriter(DataDirectory & "Delay1List.txt", False)
        Dim Dur1File = New StreamWriter(DataDirectory & "Duration1List.txt", False)
        Dim RF1File = New StreamWriter(DataDirectory & "RF1List.txt", False)
        Dim AMFreq1File = New StreamWriter(DataDirectory & "AMFreq1List.txt", False)
        Dim AMDepth1File = New StreamWriter(DataDirectory & "AMDepth1List.txt", False)

        Dim Stim1TypeFile = New StreamWriter(DataDirectory & "Stim1TypeList.txt", False)

        Dim Freq2File = New StreamWriter(DataDirectory & "Freq2List.txt", False)
        Dim Intensity2File = New StreamWriter(DataDirectory & "Intensity2List.txt", False)
        Dim Amplitude2File = New StreamWriter(DataDirectory & "Amplitude2List.txt", False)
        Dim Delay2File = New StreamWriter(DataDirectory & "Delay2List.txt", False)
        Dim Dur2File = New StreamWriter(DataDirectory & "Duration2List.txt", False)
        Dim RF2File = New StreamWriter(DataDirectory & "RF2List.txt", False)
        Dim AMFreq2File = New StreamWriter(DataDirectory & "AMFreq2List.txt", False)
        Dim AMDepth2File = New StreamWriter(DataDirectory & "AMDepth2List.txt", False)

        Dim Stim2TypeFile = New StreamWriter(DataDirectory & "Stim2TypeList.txt", False)

        Dim AmplitudeEFile = New StreamWriter(DataDirectory & "AmplitudeEList.txt", False)
        Dim DelayEFile = New StreamWriter(DataDirectory & "DelayEList.txt", False)
        Dim DurEFile = New StreamWriter(DataDirectory & "DurationEList.txt", False)
        Dim EPWidthFile = New StreamWriter(DataDirectory & "EPWidthList.txt", False)
        Dim IPGapFile = New StreamWriter(DataDirectory & "IPGapList.txt", False)
        Dim EPFreqFile = New StreamWriter(DataDirectory & "EPFreqList.txt", False)

        Dim StimETypeFile = New StreamWriter(DataDirectory & "StimETypeList.txt", False)
        Dim EStimPhaseFile = New StreamWriter(DataDirectory & "EStimPhaseList.txt", False)

        Dim PeriodFile = New StreamWriter(DataDirectory & "PeriodList.txt", False)
        Dim CaseIndexFile = New StreamWriter(DataDirectory & "CaseIndexList.txt", False)


        Dim Attenuator1File = New StreamWriter(DataDirectory & "Att1File.txt", False)
        Dim Attenuator2File = New StreamWriter(DataDirectory & "Att2File.txt", False)

        Dim Filter1File = New StreamWriter(DataDirectory & "Filter1List.txt", False)
        Dim Filter2File = New StreamWriter(DataDirectory & "Filter2List.txt", False)
        Dim Filter1Coeff = New StreamWriter(DataDirectory & "Filter1Coeffs.txt", False)
        Dim Filter2Coeff = New StreamWriter(DataDirectory & "Filter2Coeffs.txt", False)


        Dim IntensityArray1 = New Integer(50000) {}
        Dim IntensityArray2 = New Integer(50000) {}
        Dim FrequencyArray1 = New Integer(50000) {}
        Dim FrequencyArray2 = New Integer(50000) {}
        Dim FileSizeI1 As Integer = 1
        Dim FileSizeI2 As Integer = 1
        Dim FileSizeF1 As Integer = 1
        Dim FileSizeF2 As Integer = 1

        Dim Dur1Count As Integer = 1
        Dim Dur2Count As Integer = 1
        Dim RF1Count As Integer = 1
        Dim RF2Count As Integer = 1
        Dim Delay1Count As Integer = 1
        Dim Delay2Count As Integer = 1
        Dim ModDepth1Count As Integer = 1
        Dim ModDepth2Count As Integer = 1
        Dim ModFreq1Count As Integer = 1
        Dim ModFreq2Count As Integer = 1

        Dim E1Count As Integer = 1
        Dim E2Count As Integer = 1
        Dim E3Count As Integer = 1
        Dim E4Count As Integer = 1
        Dim E5Count As Integer = 1
        Dim E6Count As Integer = 1
        Dim E7Count As Integer = 1

        Dim FileChangeLoc = New Integer(40) {}
        Dim Stim1Type = New Integer(40) {}
        Dim Stim2Type = New Integer(40) {}
        Dim EStimTypeArray = New Integer(40) {}
        Dim EStimPhaseArray = New Integer(40) {}
        Dim PeriodArray = New Integer(40) {}
        Dim Filter1Array = New Integer(40) {}
        Dim Filter2Array = New Integer(40) {}
        Dim testcaseindex As Integer = 1


        Dim TargetFile = New StreamReader(Targetlocation)

        Do Until TargetFile.Peek = -1
            Dim FileName As String = TargetFile.ReadLine().ToString()
            'TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".TestCase", FileName)

            Mouse_Value = FileName.Contains("Mouse") Or FileName.Contains("mouse") Or MouseLabel.Text.Contains("Active")

            FileReader = New StreamReader(FileName)
            Dim lineitem
            Dim sizer
            Dim buffer
            Do Until FileReader.Peek = -1
                sizer = FileReader.ReadLine()
                lineitem = Split(sizer, " ")

                Dim count As Integer = 1
                Do Until (count = UBound(lineitem) + 1)

                    buffer = lineitem(count)
                    If buffer = "" Then
                        Exit Do
                    End If

                    If lineitem(0) = "//" Then
                        Exit Do
                    End If

                    If lineitem(0) = vbCrLf Then
                        Exit Do
                    Else
                        Select Case lineitem(0)

                            Case "APeriod:"
                                PeriodArray(testcaseindex) = 1.0 * buffer

                            Case "Mouse"
                                Select Case buffer
                                    Case "True"
                                        Mouse_Value = True
                                        GetAttenuators(sender, e)

                                    Case "False"
                                        Mouse_Value = False
                                        GetAttenuators(sender, e)

                                End Select

                                'Channel One Parameter Storage
                            Case "SType1:"
                                Select Case buffer
                                    Case "NOISE"
                                        Stim1Type(testcaseindex) = 0
                                    Case "TONE"
                                        Stim1Type(testcaseindex) = 1
                                End Select
                            Case "CH1AM:"
                                Select Case buffer
                                    Case "TRUE"
                                        Stim1Type(testcaseindex) = Stim1Type(testcaseindex) + 2
                                    Case "FALSE"

                                End Select
                            Case "Filter1:"
                                Select Case buffer
                                    Case "TRUE"
                                        Filter1Array(testcaseindex) = 1

                                        Dim CoeffReader = New StreamReader(FileName & " FILTER COEFFS")
                                        While CoeffReader.Peek <> -1
                                            Filter1Coeff.WriteLine(CoeffReader.ReadLine())
                                        End While
                                        CoeffReader.Close()

                                    Case "FALSE"
                                        Filter1Array(testcaseindex) = 0
                                End Select
                            Case "Amp1:"
                                If FileSizeI1 = 1 Then
                                    Intensity1File.Write(buffer & vbCrLf)
                                End If
                                Intensity1File.Write(buffer & vbCrLf)
                                IntensityArray1(FileSizeI1) = 1.0 * buffer
                                FileSizeI1 = FileSizeI1 + 1
                            Case "Freq1:"
                                If buffer = "200200" Then
                                    buffer = "200"
                                End If
                                If FileSizeF1 = 1 Then
                                    Freq1File.Write(buffer & vbCrLf)
                                End If
                                Freq1File.Write(buffer & vbCrLf)
                                FrequencyArray1(FileSizeF1) = 1.0 * buffer
                                FileSizeF1 = FileSizeF1 + 1
                            Case "Delays1:"
                                If Delay1Count = 1 Then
                                    Delay1File.Write(buffer & vbCrLf)
                                    Delay1Count = Delay1Count + 1
                                End If
                                Delay1File.Write(buffer & vbCrLf)
                            Case "ADur1:"
                                If Dur1Count = 1 Then
                                    Dur1File.Write(buffer & vbCrLf)
                                    Dur1Count = Dur1Count + 1
                                End If
                                Dur1File.Write(buffer & vbCrLf)
                            Case "ARF1:"
                                If RF1Count = 1 Then
                                    RF1File.Write(buffer & vbCrLf)
                                    RF1Count = RF1Count + 1
                                End If
                                RF1File.Write(buffer & vbCrLf)
                            Case "ModDep1:"
                                If ModDepth1Count = 1 Then
                                    AMDepth1File.Write(buffer & vbCrLf)
                                    ModDepth1Count = ModDepth1Count + 1
                                End If
                                AMDepth1File.Write(buffer & vbCrLf)
                            Case "ModFreq1:"
                                If ModFreq1Count = 1 Then
                                    AMFreq1File.Write(buffer & vbCrLf)
                                    ModFreq1Count = ModFreq1Count + 1
                                End If
                                AMFreq1File.Write(buffer & vbCrLf)

                                'Channel Two Parameter Storage 
                            Case "SType2:"
                                Select Case buffer
                                    Case "NOISE"
                                        Stim2Type(testcaseindex) = 0
                                    Case "TONE"
                                        Stim2Type(testcaseindex) = 1
                                End Select
                            Case "CH2AM:"
                                Select Case buffer
                                    Case "TRUE"
                                        Stim2Type(testcaseindex) = Stim2Type(testcaseindex) + 2
                                    Case "FALSE"
                                End Select
                            Case "Filter2:"
                                Select Case buffer
                                    Case "TRUE"
                                        Filter2Array(testcaseindex) = 1

                                        Dim CoeffReader = New StreamReader(FileName & " FILTER COEFFS")
                                        While CoeffReader.Peek <> -1
                                            Filter2Coeff.WriteLine(CoeffReader.ReadLine())
                                        End While
                                        CoeffReader.Close()

                                    Case "FALSE"
                                        Filter2Array(testcaseindex) = 0
                                End Select
                            Case "Amp2:"
                                If FileSizeI2 = 1 Then
                                    Intensity2File.Write(buffer & vbCrLf)
                                End If
                                Intensity2File.Write(buffer & vbCrLf)
                                IntensityArray2(FileSizeI2) = 1.0 * buffer
                                FileSizeI2 = FileSizeI2 + 1
                            Case "Freq2:"
                                If buffer = "200200" Then
                                    buffer = "200"
                                End If
                                If FileSizeF2 = 1 Then
                                    Freq2File.Write(buffer & vbCrLf)
                                End If
                                Freq2File.Write(buffer & vbCrLf)
                                FrequencyArray2(FileSizeF2) = 1.0 * buffer
                                FileSizeF2 = FileSizeF2 + 1
                            Case "Delays2:"
                                If Delay2Count = 1 Then
                                    Delay2File.Write(buffer & vbCrLf)
                                    Delay2Count = Delay2Count + 1
                                End If
                                Delay2File.Write(buffer & vbCrLf)
                            Case "ADur2:"
                                If Dur2Count = 1 Then
                                    Dur2File.Write(buffer & vbCrLf)
                                    Dur2Count = Dur2Count + 1
                                End If
                                Dur2File.Write(buffer & vbCrLf)
                            Case "ARF2:"
                                If RF2Count = 1 Then
                                    RF2File.Write(buffer & vbCrLf)
                                    RF2Count = RF2Count + 1
                                End If
                                RF2File.Write(buffer & vbCrLf)
                            Case "ModDep2:"
                                If ModDepth2Count = 1 Then
                                    AMDepth2File.Write(buffer & vbCrLf)
                                    ModDepth2Count = ModDepth2Count + 1
                                End If
                                AMDepth2File.Write(buffer & vbCrLf)
                            Case "ModFreq2:"
                                If ModFreq2Count = 1 Then
                                    AMFreq2File.Write(buffer & vbCrLf)
                                    ModFreq2Count = ModFreq2Count + 1
                                End If
                                AMFreq2File.Write(buffer & vbCrLf)

                                'Electrical Parameter Storage
                            Case "EStimType:"
                                Select Case buffer
                                    Case "MONO"
                                        EStimTypeArray(testcaseindex) = 2
                                    Case "BI"
                                        EStimTypeArray(testcaseindex) = 3
                                End Select
                            Case "BiPhase:"
                                Select Case buffer
                                    Case "NEG"
                                        EStimPhaseArray(testcaseindex) = 0
                                    Case "POS"
                                        EStimPhaseArray(testcaseindex) = 1
                                End Select
                            Case "EAmpl:"
                                If E1Count = 1 Then
                                    AmplitudeEFile.Write(buffer & vbCrLf)
                                    E1Count = E1Count + 1
                                End If
                                AmplitudeEFile.Write(buffer & vbCrLf)
                            Case "EDel:"
                                If E3Count = 1 Then
                                    DelayEFile.Write(buffer & vbCrLf)
                                    E3Count = E3Count + 1
                                End If
                                DelayEFile.Write(buffer & vbCrLf)
                            Case "EDur:"
                                If E4Count = 1 Then
                                    DurEFile.Write(buffer & vbCrLf)
                                    E4Count = E4Count + 1
                                End If
                                DurEFile.Write(buffer & vbCrLf)
                            Case "EPFreq:"
                                If E5Count = 1 Then
                                    EPFreqFile.Write(buffer & vbCrLf)
                                    E5Count = E5Count + 1
                                End If
                                EPFreqFile.Write(buffer & vbCrLf)
                            Case "EPWidth:"
                                If E6Count = 1 Then
                                    EPWidthFile.Write(buffer & vbCrLf)
                                    E6Count = E6Count + 1
                                End If
                                EPWidthFile.Write(buffer & vbCrLf)
                            Case "IPGap:"
                                If E7Count = 1 Then
                                    IPGapFile.Write(buffer & vbCrLf)
                                    E7Count = E7Count + 1
                                End If
                                IPGapFile.Write(buffer & vbCrLf)
                            Case Else
                        End Select
                    End If

                    count = count + 1
                Loop

            Loop
            FileChangeLoc(testcaseindex) = FileSizeI1 - 1
            testcaseindex = testcaseindex + 1
            FileReader.Close()
        Loop

        Dim index As Integer = 1
        Dim att1 As Double = 0
        Dim att2 As Double = 0
        testcaseindex = 1
        Dim newVolt As Double = 0.0
        Dim am_scale As Double = 1.0
        Dim temp_voltage As String = "5"

        GetAttenuators(sender, e)

        Do While index <= FileSizeI1 - 1

            am_scale = 1.0
            'Calculate Channel 1 Attenuation Factor
            If Stim1Type(testcaseindex) = 0 Or Stim1Type(testcaseindex) = 2 Then
                If index = 1 Then
                    Amplitude1File.Write(MaxVoltage & vbCrLf)
                    Attenuator1File.Write((100 - IntensityArray1(index)) & vbCrLf)
                End If
                Amplitude1File.Write(MaxVoltage & vbCrLf)
                Attenuator1File.Write((100 - IntensityArray1(index)) & vbCrLf)
            Else
                If Stim1Type(testcaseindex) = 3 Then
                    IntensityArray1(index) = IntensityArray1(index) + 6
                    am_scale = 0.5
                End If

                att1 = Round(Attarr1(FrequencyArray1(index)) - IntensityArray1(index), 5)

                If att1 < 0 Then
                    If index = 1 Then
                        Amplitude1File.Write(MaxVoltage & vbCrLf)
                        Attenuator1File.Write("0" & vbCrLf)
                    End If
                    Amplitude1File.Write(MaxVoltage & vbCrLf)
                    Attenuator1File.Write("0" & vbCrLf)
                ElseIf att1 > 120 Then
                    newVolt = Round(10 ^ ((-att1 + 120) / 20 + 1), 3)
                    newVolt = newVolt * am_scale
                    If index = 1 Then
                        Amplitude1File.Write(newVolt & vbCrLf)
                        Attenuator1File.Write(MaxAttenuator & vbCrLf)
                    End If
                    Amplitude1File.Write(newVolt & vbCrLf)
                    Attenuator1File.Write(MaxAttenuator & vbCrLf)
                Else

                    If Stim1Type(testcaseindex) = 3 Then
                        temp_voltage = "5"
                    Else
                        temp_voltage = MaxVoltage
                    End If

                    If index = 1 Then
                        Amplitude1File.Write(temp_voltage & vbCrLf)
                        Attenuator1File.Write(att1 & vbCrLf)
                    End If
                    Amplitude1File.Write(temp_voltage & vbCrLf)
                    Attenuator1File.Write(att1 & vbCrLf)
                End If
            End If

            am_scale = 1.0
            'Calculate Channel 2 Attenuation Factor
            If Stim2Type(testcaseindex) = 0 Or Stim2Type(testcaseindex) = 2 Then
                If index = 1 Then
                    Amplitude2File.Write(MaxVoltage & vbCrLf)
                    Attenuator2File.Write((100 - IntensityArray2(index)) & vbCrLf)
                End If
                Amplitude2File.Write(MaxVoltage & vbCrLf)
                Attenuator2File.Write((100 - IntensityArray2(index)) & vbCrLf)
            Else
                If Stim2Type(testcaseindex) = 3 Then
                    IntensityArray2(index) = IntensityArray2(index) + 6
                    am_scale = 0.5
                End If

                att2 = Round(Attarr2(FrequencyArray2(index)) - IntensityArray2(index), 5)

                If att2 < 0 Then
                    If index = 1 Then
                        Amplitude2File.Write(MaxVoltage & vbCrLf)
                        Attenuator2File.Write("0" & vbCrLf)
                    End If
                    Amplitude2File.Write(MaxVoltage & vbCrLf)
                    Attenuator2File.Write("0" & vbCrLf)
                ElseIf att2 > 120 Then
                    newVolt = Round(10 ^ ((-att2 + 120) / 20 + 1), 3)
                    newVolt = newVolt * am_scale
                    If index = 1 Then
                        Amplitude2File.Write(newVolt & vbCrLf)
                        Attenuator2File.Write(MaxAttenuator & vbCrLf)
                    End If
                    Amplitude2File.Write(newVolt & vbCrLf)
                    Attenuator2File.Write(MaxAttenuator & vbCrLf)
                Else

                    If Stim2Type(testcaseindex) = 3 Then
                        temp_voltage = "5"
                    Else
                        temp_voltage = MaxVoltage
                    End If

                    If index = 1 Then
                        Amplitude2File.Write(temp_voltage & vbCrLf)
                        Attenuator2File.Write(att2 & vbCrLf)
                    End If
                    Amplitude2File.Write(temp_voltage & vbCrLf)
                    Attenuator2File.Write(att2 & vbCrLf)
                End If
            End If


            If index = 1 Then
                Stim1TypeFile.Write(Stim1Type(testcaseindex) & vbCrLf)
                Stim2TypeFile.Write(Stim2Type(testcaseindex) & vbCrLf)
                StimETypeFile.Write(EStimTypeArray(testcaseindex) & vbCrLf)
                EStimPhaseFile.Write(EStimPhaseArray(testcaseindex) & vbCrLf)
                PeriodFile.Write(PeriodArray(testcaseindex) & vbCrLf)
                'Remove Me
                CaseIndexFile.Write((testcaseindex) & vbCrLf)
            End If

            Stim1TypeFile.Write(Stim1Type(testcaseindex) & vbCrLf)
            Stim2TypeFile.Write(Stim2Type(testcaseindex) & vbCrLf)
            Filter1File.Write(Filter1Array(testcaseindex) & vbCrLf)
            Filter2File.Write(Filter2Array(testcaseindex) & vbCrLf)
            StimETypeFile.Write(EStimTypeArray(testcaseindex) & vbCrLf)
            EStimPhaseFile.Write(EStimPhaseArray(testcaseindex) & vbCrLf)
            PeriodFile.Write(PeriodArray(testcaseindex) & vbCrLf)
            CaseIndexFile.Write((testcaseindex) & vbCrLf)

            If index = FileChangeLoc(testcaseindex) Then
                testcaseindex = testcaseindex + 1
            End If

            index = index + 1
        Loop

        Freq1File.Close()
        Intensity1File.Close()
        Amplitude1File.Close()
        Delay1File.Close()
        Dur1File.Close()
        RF1File.Close()
        AMFreq1File.Close()
        AMDepth1File.Close()
        Filter1File.Close()
        Filter1Coeff.Close()

        Freq2File.Close()
        Intensity2File.Close()
        Amplitude2File.Close()
        Delay2File.Close()
        Dur2File.Close()
        RF2File.Close()
        AMFreq2File.Close()
        AMDepth2File.Close()
        Filter2File.Close()
        Filter2Coeff.Close()

        AmplitudeEFile.Close()
        DelayEFile.Close()
        DurEFile.Close()
        EPFreqFile.Close()
        EPWidthFile.Close()
        IPGapFile.Close()

        Stim1TypeFile.Close()
        Stim2TypeFile.Close()
        StimETypeFile.Close()
        EStimPhaseFile.Close()
        PeriodFile.Close()
        CaseIndexFile.Close()

        Attenuator1File.Close()
        Attenuator2File.Close()
        TargetFile.Close()

        If RecordState = 2 Then
            StateLabel.Text = "Preview Mode"
            StateLabel.ForeColor = Color.Yellow
        ElseIf RecordState = 3 Then
            StateLabel.Text = "Record Mode"
            StateLabel.ForeColor = Color.Green
        Else
            StateLabel.Text = "Idle Mode"
            StateLabel.ForeColor = Color.Red
        End If

        compilelabel.Text = "TRUE"
        compilelabel.ForeColor = Color.Green

        Button2_Click(sender, e)

    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Form2_Becomes_Visible(sender, e)
        GetAttenuators(sender, e)

        PollRate.Text = 5
        Timer2.Interval = 5

    End Sub

    Private Sub GetAttenuators(ByVal sender As Object, ByVal e As System.EventArgs)

        '' Directions on making new attenuator files:
        '1) Get Calibration data file from Chris for appropriate frequency range
        '2) Read data into Matlab, interpolate data in integer steps from 1:MAX_FREQ_SIZE
        '   --Make adjustments as needed (ie, mouse speakers can be damaged if freqs <= 2k are applied)
        '3) Make sure array is stored as linearly increasing text file
        '4) Any needed instructions can be saved in attenuator file AFTER line>MAX_FREQ_SIZE
        '5) Make sure data is stored in DataDirectory\Calibration Data\speaker#cal###.txt

        '		If Attarr1(0) = MAX_FREQ_SIZE And Attarr2(0) = MAX_FREQ_SIZE Then
        '			Exit Sub
        '		End If
        Dim attenuator1_file As String = "Calibration Data\speaker1cal"

        Dim attenuator2_file As String = "Calibration Data\speaker2cal"

        If Mouse_Value = True Then
            attenuator1_file = attenuator1_file & "_mouse"
            attenuator2_file = attenuator2_file & "_mouse"
        End If

        FileReader = New StreamReader(DataDirectory & attenuator1_file & ".txt")
        Dim index As Integer = 1
        Attarr1(0) = MAX_FREQ_SIZE
        Do
            Attarr1(index) = FileReader.ReadLine()
            index = index + 1
        Loop Until index = MAX_FREQ_SIZE
        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & attenuator2_file & ".txt")
        index = 1
        Attarr2(0) = MAX_FREQ_SIZE
        Do
            Attarr2(index) = FileReader.ReadLine()
            index = index + 1
        Loop Until index = MAX_FREQ_SIZE
        FileReader.Close()

    End Sub

    Private Sub Form2_Becomes_Visible(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

        If Me.Visible = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        ReadingLocation = Form1.WorkingDirectory
        Dim filenames() As String = Directory.GetFiles(ReadingLocation)
        Dim filename As String

        For i = 0 To filenames.Length - 1
            filename = Path.GetFileName(filenames(i))
            ListBox1.Items.Add(filename)
        Next i

        LoadPrevious_Click(sender, e)

    End Sub

    Private Sub ClearCases_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClearCases.Click

        If MsgBox("Are you sure you want to clear selected cases?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            ListBox2.Items.Clear()
            ListBox2_ItemAdded(sender, e)
        Else
            Exit Sub
        End If

    End Sub


    'Modify list box items
    Private Sub ListBox2_ItemAdded(ByVal sender As Object, ByVal e As System.EventArgs)

        compilelabel.Text = "FALSE"
        compilelabel.ForeColor = Color.Red

        Dim i As Integer = 0
        FileWriter = New StreamWriter(Targetlocation, False)
        Do While i < ListBox2.Items.Count
            FileWriter.WriteLine(ReadingLocation & "\" & ListBox2.Items(i))
            i = i + 1
        Loop
        FileWriter.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListBox1.SelectedIndexChanged

        Form1.ButtonLoadTest_Click(sender, e, ReadingLocation & "\" & ListBox1.Items(ListBox1.SelectedIndex))

        ListBox2.Items.Add(ListBox1.Items(ListBox1.SelectedIndex))
        ListBox2_ItemAdded(sender, e)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListBox2.SelectedIndexChanged

        If ListBox2.SelectedIndex() <> -1 Then
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex())
            ListBox2_ItemAdded(sender, e)
        Else
            Exit Sub
        End If
    End Sub


    'Updates list of test cases in available list
    Public Sub Change_Directory(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChangeDirectory.Click

        ListBox1.Items.Clear()
        ReadingLocation = Form1.WorkingDirectory

        Dim filenames() As String = Directory.GetFiles(ReadingLocation)
        Dim filename As String

        For i = 0 To filenames.Length - 1
            filename = Path.GetFileName(filenames(i))
            ListBox1.Items.Add(filename)
        Next i
    End Sub

    Private Sub LoadPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        ListBox2.Items.Clear()

        Dim FileReader = New StreamReader(Targetlocation)
        Dim buffer, buffer2 As String
        Do While FileReader.Peek <> -1
            buffer = FileReader.ReadLine().ToString()
            buffer2 = buffer.Remove(0, ReadingLocation.Count + 1)
            ListBox2.Items.Add(buffer2)
        Loop
        FileReader.Close()
        ListBox2_ItemAdded(sender, e)
    End Sub


    'Updates list of test cases on file
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Timer2.Enabled = True Then
            Timer1.Enabled = False
            Exit Sub
        End If

        Dim FileReader = New StreamReader(Targetlocation)

        ListBox3.Items.Clear()

        Dim buffer As String()
        Dim buffer2 As String
        Do While FileReader.Peek <> -1
            buffer = Split(FileReader.ReadLine().ToString(), "\")
            buffer2 = buffer(buffer.GetLength(0) - 1)
            ListBox3.Items.Add(buffer2)
        Loop
        FileReader.Close()
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged


        If ListBox3.SelectedIndex() <> -1 Then
            Dim targetfile As String = ReadingLocation & "\" & ListBox3.Items(ListBox3.SelectedIndex).ToString()
            Form1.ButtonLoadTest_Click(sender, e, targetfile)
        Else
            Exit Sub
        End If
    End Sub


    'Form 3 Previous Data
    Private Sub RunData(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim index As Integer = 1
        Do Until index = 50000
            Attenuator1(index) = 0
            Attenuator2(index) = 0
            Intensity1(index) = 0
            Intensity2(index) = 0
            Frequency1(index) = 0
            Frequency2(index) = 0
            Delay1(index) = 0
            Delay2(index) = 0
            Duration1(index) = 0
            Duration2(index) = 0
            index = index + 1
        Loop


        Dim FileReader = New StreamReader(DataDirectory & "Att1File.txt")

        index = 1
        Do While FileReader.Peek <> -1
            Attenuator1(index) = FileReader.ReadLine()
            index = index + 1
        Loop
        Attenuator1(0) = index - 2

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Att2File.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Attenuator2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Intensity1List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Intensity1(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Freq1List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Frequency1(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Delay1List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Delay1(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Duration1List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Duration1(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Intensity2List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Intensity2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Freq2List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Frequency2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Delay2List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Delay2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

        FileReader = New StreamReader(DataDirectory & "Duration2List.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Duration2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

    End Sub

    Private Sub UpdateLabels(ByVal sender As Object, ByVal e As System.EventArgs)
        Label15.Text = CStr(TDA.GetTargetVal(STIMULATING_DEVICE + ".pNum")) & "/" & CStr(TDA.GetTargetVal(STIMULATING_DEVICE + ".pCount"))
        Label13.Text = CStr(TDA.GetTargetVal("PA5_1.Atten"))
        Label6.Text = CStr(TDA.GetTargetVal("PA5_2.Atten"))
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        EndIt(sender, e)
    End Sub

    Private Sub EndIt(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        TDA.CloseConnection()
        MouseLabel.Enabled = True
    End Sub


    Public Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Button1.Enabled = True
        PrevSwpN = -1.0

        Dim SystemState As Integer = 2

        If Timer2.Enabled = False Then
            RunData(sender, e)
            SystemState = TDA.ConnectServer("Local")
            System.Threading.Thread.Sleep(1000.0)

            'UpdateLabels(sender, e)
            'MsgBox("Attenuators set to 120?")

            'Set system to standby for data loading
            SystemState = TDA.SetSysMode(1)

            If RecordState = 2 Then
                StateLabel.Text = "Preview Mode"
                StateLabel.ForeColor = Color.Yellow
            ElseIf RecordState = 3 Then
                StateLabel.Text = "Record Mode"
                StateLabel.ForeColor = Color.Green
            Else
                StateLabel.Text = "Idle Mode"
                StateLabel.ForeColor = Color.Red
                MouseLabel.Enabled = True
            End If


            'Public SortFile As String = "C:\TDT\OpenEx\Controller\sorts.dat"
            'Dim Sort_State As Double() = New Double(63) {} '
            'Dim Auto_Sort_Load As Boolean = False
            'Dim Auto_Sort_Save As Boolean = False
            'Thresh1 = TDA.GetTargetVal("Recording.aCSPK~1")
            'TDA.SetTargetVal("Recording.aCSPK~1", Thresh1)

            Dim index As Integer = 0
            Dim value As Byte
            Dim file_length As Integer = 0
            If Auto_Sort_Load = True Then

                Dim sort_file = IO.File.Open(SortFile, FileMode.Open)

                index = 0
                While index <= sort_file.Length
                    temp_buffer(index) = sort_file.ReadByte()
                    index = index + 1
                End While

                index = 64
                Do While index > 0

                    'value = temp_bu
                    'If value <> 0.0 Then
                    Sort_State(index) = Convert.ToDouble(value)
                    TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".aCSPK~" + Convert.ToString(index + 1), 0.01)
                    index = index - 1
                    'End If
                Loop

                FileReader.Close()

            End If

            Timer3.Enabled = True
            SystemState = TDA.SetSysMode(RecordState)
            'TEMP_VAR = TDA.SetSysMode(RecordState)
            System.Threading.Thread.Sleep(1000)
            SystemState = TDA.GetSysMode
            System.Threading.Thread.Sleep(1000)

            Do Until SystemState = RecordState Or index > 5

                System.Threading.Thread.Sleep(1000)

                SystemState = TDA.GetSysMode
                index = index + 1

                If index = 5 Then
                    MsgBox("Error Connecting to Hardware")
                    Return
                End If

            Loop
            Timer3.Enabled = False



            'Reset pulse counter, set pCount to number of trials
            TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".pCount", Attenuator1(0))
            TEMP_VAR = TDA.SetTargetVal(Estim + ".pCount", Attenuator1(0))
            'If Host_Name = "khri-5434sesmon" Then
            'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".pCount", Attenuator1(0))
            'End If

            TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".pReset", 1.0)
            TEMP_VAR = TDA.SetTargetVal(Estim + ".pReset", 1.0)
            'If Host_Name = "khri-5434sesmon" Then
            'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".pReset", 1.0)
            'End If

            System.Threading.Thread.Sleep(10)
            TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".pReset", 0.0)
            TEMP_VAR = TDA.SetTargetVal(Estim + ".pReset", 0.0)
            'If Host_Name = "khri-5434sesmon" Then
            'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".pReset", 0.0)
            'End If
            System.Threading.Thread.Sleep(10)

            If Auto_Sort_Load = False Then
                MsgBox("Please don't forget to load the state.")
            End If


            If Host_Name = "khri-5434sesmon" Then
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".Run", 1.0)
                'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".Run", 1.0)
                'TEMP_VAR = zBUS.zBusTrigB(0, 1, 10)
            ElseIf Host_Name = "RDE-ShoreLab1" Then
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".Run", 1.0)
                TEMP_VAR = TDA.SetTargetVal(Estim + ".Run", 1.0)
            End If

        Else

            If Host_Name = "khri-5434sesmon" Then
                'TEMP_VAR = zBUS.zBusTrigB(0, 2, 10)
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".Run", 0.0)
                'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".Run", 0.0)
            ElseIf Host_Name = "RDE-ShoreLab1" Then
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".Run", 0.0)
                TEMP_VAR = TDA.SetTargetVal(Estim + ".Run", 0.0)
            End If
            'TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".Att-B", 100.0) 'Attenuator2(1)
            TEMP_VAR = TDA.SetSysMode(0) 'Set to idle
            TDA.CloseConnection()
            MouseLabel.Enabled = True
        End If

        'Enable polling
        Timer2.Enabled = Not Timer2.Enabled


        If Timer2.Enabled Then
            ShieldDown.Enabled = False
        Else

            MsgBox("Test Cases Finished:" & vbCrLf & vbCrLf & Join(displayfile, vbCrLf))
            displayfile = Nothing
            ShieldDown.Enabled = True
            Timer1.Enabled = True
            MouseLabel.Enabled = True
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'This function updates parameter values of the TDT RX8 stimulator
        SwpN = TDA.GetTargetVal(STIMULATING_DEVICE + ".pNum")
        System.Threading.Thread.Sleep(1)
        If SwpN <> PrevSwpN Then
            NoiseSeed1 = Round((2 ^ 31) * Rnd() + 1)
            NoiseSeed2 = Round((2 ^ 31) * Rnd() + 1)
            PrevSwpN = SwpN
            TEMP_VAR = TDA.SetTargetVal("PA5_1.Atten", Attenuator1(SwpN + 2))
            'System.Threading.Thread.Sleep(1)
            TEMP_VAR = TDA.SetTargetVal("PA5_2.Atten", Attenuator2(SwpN + 2))
            'System.Threading.Thread.Sleep(1)
            TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".NoiseSeed1", NoiseSeed1)
            'System.Threading.Thread.Sleep(1)
            If Host_Name = "khri-5434sesmon" Then
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".NoiseSeed2", NoiseSeed2)
                'TEMP_VAR = TDA.SetTargetVal(RECORDING_DEVICE + ".NoiseSeed2", NoiseSeed2)
            ElseIf Host_Name = "RDE-ShoreLab1" Then
                TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE + ".NoiseSeed2", NoiseSeed2)
            End If

            'System.Threading.Thread.Sleep(1)
        End If

        LabelNS1.Text = NoiseSeed1.ToString
        LabelNS2.Text = NoiseSeed2.ToString
        Label15.Text = SwpN & "/" & Attenuator1(0)
        Label13.Text = Attenuator1(SwpN + 2)
        Label6.Text = Attenuator2(SwpN + 2)
        Inten1.Text = Intensity1(SwpN + 2)
        Freq1.Text = Frequency1(SwpN + 2)
        Del1.Text = Delay1(SwpN + 2)
        Dur1.Text = Duration1(SwpN + 2)
        Inten2.Text = Intensity2(SwpN + 2)
        Freq2.Text = Frequency2(SwpN + 2)
        Del2.Text = Delay2(SwpN + 2)
        Dur2.Text = Duration2(SwpN + 2)

        ' Reads in voltage from TDT device, calculates temperature, outputs average 
        '        Dim A As Double = (1.471226 * 10 ^ -3)
        '        Dim B As Double = (2.3762276 * 10 ^ -4)
        '        Dim C As Double = (1.0502722 * 10 ^ -7)

        '    If RecordState = 2 Or RecordState = 3 Then

        '     Dim n As Integer = 0
        '     Dim Total As Double = 0
        '     Dim Voltage As Double

        '     Do While n < 1000
        '     Voltage = TDA.GetTargetVal(STIMULATING_DEVICE & ".Voltage")

        '    Dim R As Double = Log(10000.0 * (5.0 / Voltage - 1))
        ' Temp in Kelvin
        '     Dim T As Double = (1.0 / (A + (B * R) + (C * R * R * R)))
        ' Temp in Celcius
        '   Dim Tc As Double = T - 273.15
        ' Temp in Fahrenheit
        ' Dim Tf As Double = (Tc * 1.8) + 32.0

        '    Total = Total + Tc
        '    n = n + 1
        '       Loop

        '     AvgT = Total / 1000.0
        '   AvgT = Math.Round(AvgT, 2)
        '   TEMP_VAR = TDA.SetTargetVal(STIMULATING_DEVICE & ".Temperature", AvgT)
        '   If Host_Name = "khri-5434sesmon" Then
        '   Label25.Text = "N/A"
        '   ElseIf Host_Name = "RDE-ShoreLab1" Then
        '   Label25.Text = CStr(AvgT)
        '   End If

        '  End If

        If SwpN = Attenuator1(0) Or 0 = TDA.GetSysMode() Then
            TEMP_VAR = TDA.SetTargetVal("PA5_1.Atten", 120)
            TEMP_VAR = TDA.SetTargetVal("PA5_2.Atten", 120)
            Label13.Text = MaxAttenuator
            Label6.Text = MaxAttenuator
            Button2_Click(sender, e)
        End If

    End Sub

    Public Sub StimulusLogger(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim FileLogger = New StreamWriter("C:\TDT\SHORELAB\StimulusProtocolLog.txt", True)
        FileLogger.Write("-------------------------------------------------------------------------------------------------" & vbCrLf & "Date: " & Date.Today() & vbCrLf & "Time: " & Date.Now() & vbCrLf & "Files: ")
        FileLogger.Write(Join(displayfile, vbCrLf))
        FileLogger.Write("-------------------------------------------------------------------------------------------------")
        FileLogger.Close()
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PollRate.TextChanged
        Try
            'Dim refresh_rate As String
            Dim refresh_rate_num As Double
            refresh_rate_num = Convert.ToDouble(PollRate.Text)
            Timer2.Interval = CInt(refresh_rate_num)
        Catch
            MsgBox("Bad watchdog timer interval")
        End Try
    End Sub

    Private Sub PreviewButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PreviewButton.CheckedChanged
        If PreviewButton.Checked = True Then
            RecordState = 2
        Else
            RecordState = 3
        End If
    End Sub

    Private Sub RecordButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RecordButton.CheckedChanged
        If RecordButton.Checked = True Then
            RecordState = 3
        Else
            RecordState = 2
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick

        If Timer3.Enabled = True Then
            Timer3.Enabled = False
        End If

        MsgBox("Error connecting to Hardware")
        EndIt(sender, e)

    End Sub

    'This function auto loads the sort saving state prior to experiment protocol execution
    Private Sub Auto_load_sort_state_CheckedChanged(sender As Object, e As System.EventArgs) Handles auto_load_sort_state.CheckedChanged

        If auto_load_sort_state.Checked = True Then
            Auto_Sort_Load = True
        Else
            Auto_Sort_Load = False
        End If

    End Sub


    Private Sub MouseLabel_Click(sender As Object, e As System.EventArgs) Handles MouseLabel.Click

        If Mouse_Value = False Then
            Mouse_Value = True
            MouseLabel.Text = "Mouse State: Active"
        Else
            Mouse_Value = False
            MouseLabel.Text = "Mouse State: Inactive"
        End If

        GetAttenuators(sender, e)


    End Sub

    Private Sub LabelNS2_Click(sender As Object, e As EventArgs) Handles LabelNS2.Click

    End Sub
End Class