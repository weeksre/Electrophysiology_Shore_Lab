Imports TDEVACCXLib
Imports System.IO


Public Class Form3

    'This form is designed to access the TDT Hardware on server 'Local'. This disables OpenController Access to the system.
    'When this form is closed, the connection closes and OpenController resumes primary control over the system.
    'To disable this form's functionality, go to Form1.vb, find the Form1_Load function and set form3.enabled to false.

    Dim TDA As TDevAccX = New TDevAccX

    Dim PrevSwpN As Double = 0.0
    Dim SwpN As Double = 0.0
    Dim SwpCount As Double = 0.0
    Dim Atten1 As Double = 55.5
    Dim Atten2 As Double = 55.5

	Dim HardWareData As String = "C:\TDT\SES\" '"C:\Users\shorelab\Desktop\Stimulus Protocol Filesystem\Hardware Data\"
    Dim displayfile As String() = New String(20) {}

    Dim Attenuator1 As Double() = New Double(50000) {}
    Dim Attenuator2 As Double() = New Double(50000) {}

    Private Sub Get_Attenuators(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FileReader = New StreamReader(HardWareData & "Att1File.txt")

        Dim index As Integer = 1
        Do While FileReader.Peek <> -1
            Attenuator1(index) = FileReader.ReadLine()
            index = index + 1
        Loop
        Attenuator1(0) = index - 2

        FileReader.Close()

        FileReader = New StreamReader(HardWareData & "Att2File.txt")
        index = 1
        Do While FileReader.Peek <> -1
            Attenuator2(index) = FileReader.ReadLine()
            index = index + 1
        Loop

        FileReader.Close()

    End Sub

    Private Sub UpdateLabels(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label2.Text = CStr(TDA.GetTargetVal("AStim.pNum")) & "/" & CStr(TDA.GetTargetVal("AStim.pCount"))
        Label4.Text = CStr(TDA.GetTargetVal("PA5_1.Atten"))
        Label6.Text = CStr(TDA.GetTargetVal("PA5_2.Atten"))
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UpdateLabels(sender, e)
        PollRate.Text = 5
        Timer2.Interval = 5
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Atten1 < 50 Then
            Atten1 = 70.0
        Else
            Atten1 = 30.0
        End If

        If Atten2 < 50 Then
            Atten2 = 70.0
        Else
            Atten2 = 30.0
        End If

        TDA.SetTargetVal("PA5_1.Atten", Atten1)
        TDA.SetTargetVal("PA5_2.Atten", Atten2)

        UpdateLabels(sender, e)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TDA.CloseConnection()
        'Timer1.Enabled = Not Timer1.Enabled

        'If Timer1.Enabled Then
        'Label7.Text = "Switch Test Enabled"
        'Else
        'Label7.Text = "Switch Test Disabled"
        'End If

    End Sub

    Private Sub EndIt(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        TDA.CloseConnection()
    End Sub


    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        PrevSwpN = 0.0
        Debug.Text = "Sampling Frequency: " & TDA.GetDeviceSF("AStim")

        If Timer2.Enabled = False Then
            Get_Attenuators(sender, e)

            StatusLabel.Text = CStr(TDA.ConnectServer("Local"))
            StatusLabel.Text = CStr(TDA.CheckServerConnection())

            'Make sure stimuli are not running
            'TDA.SetTargetVal("AStim.Run", 0)

            'Initialize attenuators
            StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_1.Atten", 120))
            StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_2.Atten", 120))

            'UpdateLabels(sender, e)
            'MsgBox("Attenuators set to 120?")

            'Begin recording, hit zBusTrigA
            StatusLabel.Text = CStr(-1)
            StatusLabel.Text = CStr(TDA.SetSysMode(3))
            Do Until TDA.GetSysMode = 3
				System.Threading.Thread.Sleep(100)


            Loop

            StatusLabel.Text = CStr(TDA.GetSysMode())

            StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_1.Atten", 120))
            StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_2.Atten", 120))

            'UpdateLabels(sender, e)
            'MsgBox("Attenuators set to 120 and status is sysmode, should be 3 for recording?")

            'Reset pulse counter, set pCount to number of trials
            TDA.SetTargetVal("AStim.pCount", Attenuator1(0))
            TDA.SetTargetVal("AStim.pReset", 1)
            TDA.SetTargetVal("AStim.pReset", 0)
            'StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_1.Atten", 120))
            'StatusLabel.Text = CStr(TDA.SetTargetVal("PA5_2.Atten", 120))


            'UpdateLabels(sender, e)
            'MsgBox("Everything ok?")

            'Set it running!
            'TDA.SetSysMode(3)
            'StatusLabel.Text = CStr(TDA.GetSysMode())

            'UpdateLabels(sender, e)
            'MsgBox("Recording but not running")
            MsgBox("Please don't forget to load the state.")

            TDA.SetTargetVal("AStim.Run", 1)

        Else
            TDA.SetTargetVal("AStim.Run", 0)
            TDA.SetSysMode(0) 'Set to idle
            TDA.CloseConnection()
        End If

        'Enable polling
        Timer2.Enabled = Not Timer2.Enabled
        

        'Dim FileReader = New StreamReader(Form2.Targetlocation)
        'Dim index As Integer = 0
        'Dim count As Integer = 0
        'Do While FileReader.Peek <> -1
        '    displayfile(index) = FileReader.ReadLine().ToString()
        '    index = index + 1
        '    count = count + 1
        'Loop
        'FileReader.Close()

        'MsgBox("Test Cases Being Run:" & vbCrLf & vbCrLf & Join(displayfile, vbCrLf) & vbCrLf & "Click WorkBench:Preview/Record to begin. When test is finished, click red stop sign.")

        'MsgBox("2 SwpN set to " & TDA.GetTargetVal("AStim.SwpN"))



        If Timer2.Enabled Then
            Label8.Text = "Watcher Enabled"
            Label7.Text = "Switch Test Disabled"
            'Button1.Enabled = False
            'Form1.Visible = False
            Form2.ShieldDown.Enabled = False
        Else

            MsgBox("Test Cases Finished:" & vbCrLf & vbCrLf & Join(displayfile, vbCrLf))
            displayfile = Nothing
            'Form1.Visible = True
            'Button1.Enabled = True
            Form2.ShieldDown.Enabled = True
            Label7.Text = "Switch Test Enabled"
            Label8.Text = "Watcher Disabled"
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick


        SwpN = TDA.GetTargetVal("AStim.pNum")
        'SwpCount = TDA.GetTargetVal("AStim.pCount")

        If SwpN <> PrevSwpN Then
            TDA.SetTargetVal("PA5_1.Atten", Attenuator1(SwpN + 1))
            TDA.SetTargetVal("PA5_2.Atten", Attenuator2(SwpN + 1))
        End If

        Label2.Text = SwpN & "/" & Attenuator1(0)
        Label4.Text = Attenuator1(SwpN + 1)
        Label6.Text = Attenuator2(SwpN + 1)

        If SwpN = Attenuator1(0) Or 0 = TDA.GetSysMode() Then
            Button2_Click(sender, e)
        End If

        PrevSwpN = SwpN

    End Sub

    Public Sub StimulusLogger(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FileLogger = New StreamWriter("C:\Users\shorelab\Desktop\StimulusProtocolLog.txt", True)
        FileLogger.Write("-------------------------------------------------------------------------------------------------" & vbCrLf & "Date: " & Date.Today() & vbCrLf & "Time: " & Date.Now() & vbCrLf & "Files: ")
        FileLogger.Write(Join(displayfile, vbCrLf))
        FileLogger.Write("-------------------------------------------------------------------------------------------------")
        FileLogger.Close()
    End Sub

   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PollRate.TextChanged
        Timer2.Interval = PollRate.Text * 1.0
    End Sub
End Class