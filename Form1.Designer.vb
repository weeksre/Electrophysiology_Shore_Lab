<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.ButtonLoadTest = New System.Windows.Forms.Button()
		Me.TextBoxAmp1 = New System.Windows.Forms.TextBox()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
		Me.ButtonClrAll = New System.Windows.Forms.Button()
		Me.TextBoxFreq1 = New System.Windows.Forms.TextBox()
		Me.TextBoxDelay1 = New System.Windows.Forms.TextBox()
		Me.ButtonQuit = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TextBoxDelay2 = New System.Windows.Forms.TextBox()
		Me.TextBoxFreq2 = New System.Windows.Forms.TextBox()
		Me.TextBoxAmp2 = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.TextBoxCH2RFTime = New System.Windows.Forms.TextBox()
		Me.Label22 = New System.Windows.Forms.Label()
		Me.CH2AM_Check = New System.Windows.Forms.CheckBox()
		Me.Ch2Filter = New System.Windows.Forms.CheckBox()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.TextBoxCh2Dur = New System.Windows.Forms.TextBox()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.TextBoxModDep2 = New System.Windows.Forms.TextBox()
		Me.TextBoxModFreq2 = New System.Windows.Forms.TextBox()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Ch2Noise = New System.Windows.Forms.RadioButton()
		Me.Ch2Tone = New System.Windows.Forms.RadioButton()
		Me.LoadCh2 = New System.Windows.Forms.Button()
		Me.ClearCh2 = New System.Windows.Forms.Button()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.TextBoxCH1RFTime = New System.Windows.Forms.TextBox()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.CH1AM_Check = New System.Windows.Forms.CheckBox()
		Me.Ch1Filter = New System.Windows.Forms.CheckBox()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.TextBoxCh1Dur = New System.Windows.Forms.TextBox()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.TextBoxModDep1 = New System.Windows.Forms.TextBox()
		Me.Label17 = New System.Windows.Forms.Label()
		Me.TextBoxModFreq1 = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Ch1Noise = New System.Windows.Forms.RadioButton()
		Me.Ch1Tone = New System.Windows.Forms.RadioButton()
		Me.LoadCh1 = New System.Windows.Forms.Button()
		Me.ClearCh1 = New System.Windows.Forms.Button()
		Me.ButtonWrtAll = New System.Windows.Forms.Button()
		Me.OpenFileDialogDefault = New System.Windows.Forms.OpenFileDialog()
		Me.Label13 = New System.Windows.Forms.Label()
		Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.TextBoxReps = New System.Windows.Forms.TextBox()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.RepTrials = New System.Windows.Forms.RadioButton()
		Me.RepSets = New System.Windows.Forms.RadioButton()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.ClearEParam = New System.Windows.Forms.Button()
		Me.Panel6 = New System.Windows.Forms.Panel()
		Me.TextBoxEPWidth = New System.Windows.Forms.TextBox()
		Me.TextBoxEDur = New System.Windows.Forms.TextBox()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.TextBoxIPGap = New System.Windows.Forms.TextBox()
		Me.Label20 = New System.Windows.Forms.Label()
		Me.TextBoxEPFreq = New System.Windows.Forms.TextBox()
		Me.Label21 = New System.Windows.Forms.Label()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.Label24 = New System.Windows.Forms.Label()
		Me.TextBoxEAmpl = New System.Windows.Forms.TextBox()
		Me.TextBoxEDel = New System.Windows.Forms.TextBox()
		Me.Panel5 = New System.Windows.Forms.Panel()
		Me.Laser_Tag = New System.Windows.Forms.CheckBox()
		Me.Panel8 = New System.Windows.Forms.Panel()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.EStimDisable = New System.Windows.Forms.RadioButton()
		Me.EStimEnable = New System.Windows.Forms.RadioButton()
		Me.Panel10 = New System.Windows.Forms.Panel()
		Me.EStimTypeMono = New System.Windows.Forms.RadioButton()
		Me.EStimTypeBi = New System.Windows.Forms.RadioButton()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.Panel7 = New System.Windows.Forms.Panel()
		Me.BiPhasePos = New System.Windows.Forms.RadioButton()
		Me.BiPhaseNeg = New System.Windows.Forms.RadioButton()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.LoadEParam = New System.Windows.Forms.Button()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Panel9 = New System.Windows.Forms.Panel()
		Me.MixSignals = New System.Windows.Forms.CheckBox()
		Me.LinearEnable = New System.Windows.Forms.CheckBox()
		Me.RandAll = New System.Windows.Forms.RadioButton()
		Me.RandTrials = New System.Windows.Forms.RadioButton()
		Me.RandSets = New System.Windows.Forms.RadioButton()
		Me.CurTestCase = New System.Windows.Forms.Label()
		Me.WorkDirectory = New System.Windows.Forms.Label()
		Me.Panel11 = New System.Windows.Forms.Panel()
		Me.Ch1FilterDesign = New System.Windows.Forms.Button()
		Me.Mouse = New System.Windows.Forms.CheckBox()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.Panel4.SuspendLayout()
		Me.Panel6.SuspendLayout()
		Me.Panel5.SuspendLayout()
		Me.Panel8.SuspendLayout()
		Me.Panel10.SuspendLayout()
		Me.Panel7.SuspendLayout()
		Me.Panel9.SuspendLayout()
		Me.Panel11.SuspendLayout()
		Me.SuspendLayout()
		'
		'ButtonLoadTest
		'
		Me.ButtonLoadTest.Location = New System.Drawing.Point(787, 580)
		Me.ButtonLoadTest.Margin = New System.Windows.Forms.Padding(2)
		Me.ButtonLoadTest.Name = "ButtonLoadTest"
		Me.ButtonLoadTest.Size = New System.Drawing.Size(197, 65)
		Me.ButtonLoadTest.TabIndex = 0
		Me.ButtonLoadTest.Text = "Load New Test Case"
		Me.ButtonLoadTest.UseVisualStyleBackColor = True
		'
		'TextBoxAmp1
		'
		Me.TextBoxAmp1.Location = New System.Drawing.Point(159, 137)
		Me.TextBoxAmp1.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxAmp1.Multiline = True
		Me.TextBoxAmp1.Name = "TextBoxAmp1"
		Me.TextBoxAmp1.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxAmp1.TabIndex = 1
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'ButtonClrAll
		'
		Me.ButtonClrAll.Location = New System.Drawing.Point(787, 649)
		Me.ButtonClrAll.Margin = New System.Windows.Forms.Padding(2)
		Me.ButtonClrAll.Name = "ButtonClrAll"
		Me.ButtonClrAll.Size = New System.Drawing.Size(197, 63)
		Me.ButtonClrAll.TabIndex = 3
		Me.ButtonClrAll.Text = "Clear All Parameters"
		Me.ButtonClrAll.UseVisualStyleBackColor = True
		'
		'TextBoxFreq1
		'
		Me.TextBoxFreq1.Location = New System.Drawing.Point(159, 172)
		Me.TextBoxFreq1.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxFreq1.Multiline = True
		Me.TextBoxFreq1.Name = "TextBoxFreq1"
		Me.TextBoxFreq1.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxFreq1.TabIndex = 4
		'
		'TextBoxDelay1
		'
		Me.TextBoxDelay1.Location = New System.Drawing.Point(159, 207)
		Me.TextBoxDelay1.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxDelay1.Multiline = True
		Me.TextBoxDelay1.Name = "TextBoxDelay1"
		Me.TextBoxDelay1.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxDelay1.TabIndex = 5
		'
		'ButtonQuit
		'
		Me.ButtonQuit.Location = New System.Drawing.Point(988, 648)
		Me.ButtonQuit.Margin = New System.Windows.Forms.Padding(2)
		Me.ButtonQuit.Name = "ButtonQuit"
		Me.ButtonQuit.Size = New System.Drawing.Size(195, 65)
		Me.ButtonQuit.TabIndex = 8
		Me.ButtonQuit.Text = "Exit Program"
		Me.ButtonQuit.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Times New Roman", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(459, 7)
		Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(330, 31)
		Me.Label1.TabIndex = 11
		Me.Label1.Text = "Stimulus Protocol Developer"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'TextBoxDelay2
		'
		Me.TextBoxDelay2.Location = New System.Drawing.Point(163, 206)
		Me.TextBoxDelay2.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxDelay2.Multiline = True
		Me.TextBoxDelay2.Name = "TextBoxDelay2"
		Me.TextBoxDelay2.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxDelay2.TabIndex = 15
		'
		'TextBoxFreq2
		'
		Me.TextBoxFreq2.Location = New System.Drawing.Point(163, 171)
		Me.TextBoxFreq2.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxFreq2.Multiline = True
		Me.TextBoxFreq2.Name = "TextBoxFreq2"
		Me.TextBoxFreq2.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxFreq2.TabIndex = 14
		'
		'TextBoxAmp2
		'
		Me.TextBoxAmp2.Location = New System.Drawing.Point(163, 136)
		Me.TextBoxAmp2.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxAmp2.Multiline = True
		Me.TextBoxAmp2.Name = "TextBoxAmp2"
		Me.TextBoxAmp2.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxAmp2.TabIndex = 12
		'
		'Label2
		'
		Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(55, 15)
		Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(199, 19)
		Me.Label2.TabIndex = 18
		Me.Label2.Text = "Auditory Channel 1 Parameters"
		'
		'Label3
		'
		Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(54, 14)
		Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(199, 19)
		Me.Label3.TabIndex = 19
		Me.Label3.Text = "Auditory Channel 2 Parameters"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.TextBoxCH2RFTime)
		Me.Panel1.Controls.Add(Me.Label22)
		Me.Panel1.Controls.Add(Me.CH2AM_Check)
		Me.Panel1.Controls.Add(Me.Ch2Filter)
		Me.Panel1.Controls.Add(Me.Label28)
		Me.Panel1.Controls.Add(Me.TextBoxCh2Dur)
		Me.Panel1.Controls.Add(Me.Label18)
		Me.Panel1.Controls.Add(Me.TextBoxModDep2)
		Me.Panel1.Controls.Add(Me.TextBoxModFreq2)
		Me.Panel1.Controls.Add(Me.Label19)
		Me.Panel1.Controls.Add(Me.Label9)
		Me.Panel1.Controls.Add(Me.Label11)
		Me.Panel1.Controls.Add(Me.Label10)
		Me.Panel1.Controls.Add(Me.Label4)
		Me.Panel1.Controls.Add(Me.Ch2Noise)
		Me.Panel1.Controls.Add(Me.Ch2Tone)
		Me.Panel1.Controls.Add(Me.LoadCh2)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.ClearCh2)
		Me.Panel1.Controls.Add(Me.TextBoxDelay2)
		Me.Panel1.Controls.Add(Me.TextBoxFreq2)
		Me.Panel1.Controls.Add(Me.TextBoxAmp2)
		Me.Panel1.Location = New System.Drawing.Point(477, 138)
		Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(300, 575)
		Me.Panel1.TabIndex = 20
		'
		'TextBoxCH2RFTime
		'
		Me.TextBoxCH2RFTime.Location = New System.Drawing.Point(163, 276)
		Me.TextBoxCH2RFTime.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxCH2RFTime.Multiline = True
		Me.TextBoxCH2RFTime.Name = "TextBoxCH2RFTime"
		Me.TextBoxCH2RFTime.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxCH2RFTime.TabIndex = 48
		'
		'Label22
		'
		Me.Label22.AutoSize = True
		Me.Label22.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label22.Location = New System.Drawing.Point(52, 279)
		Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label22.Name = "Label22"
		Me.Label22.Size = New System.Drawing.Size(87, 16)
		Me.Label22.TabIndex = 49
		Me.Label22.Text = "Rise/Fall (ms)"
		'
		'CH2AM_Check
		'
		Me.CH2AM_Check.AutoSize = True
		Me.CH2AM_Check.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CH2AM_Check.Location = New System.Drawing.Point(181, 98)
		Me.CH2AM_Check.Margin = New System.Windows.Forms.Padding(2)
		Me.CH2AM_Check.Name = "CH2AM_Check"
		Me.CH2AM_Check.Size = New System.Drawing.Size(42, 17)
		Me.CH2AM_Check.TabIndex = 47
		Me.CH2AM_Check.Text = "AM"
		Me.CH2AM_Check.UseVisualStyleBackColor = True
		'
		'Ch2Filter
		'
		Me.Ch2Filter.AutoSize = True
		Me.Ch2Filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Ch2Filter.Location = New System.Drawing.Point(181, 79)
		Me.Ch2Filter.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch2Filter.Name = "Ch2Filter"
		Me.Ch2Filter.Size = New System.Drawing.Size(48, 17)
		Me.Ch2Filter.TabIndex = 46
		Me.Ch2Filter.Text = "Filter"
		Me.Ch2Filter.UseVisualStyleBackColor = True
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label28.Location = New System.Drawing.Point(52, 241)
		Me.Label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(88, 16)
		Me.Label28.TabIndex = 39
		Me.Label28.Text = "Duration (ms)"
		'
		'TextBoxCh2Dur
		'
		Me.TextBoxCh2Dur.Location = New System.Drawing.Point(163, 241)
		Me.TextBoxCh2Dur.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxCh2Dur.Multiline = True
		Me.TextBoxCh2Dur.Name = "TextBoxCh2Dur"
		Me.TextBoxCh2Dur.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxCh2Dur.TabIndex = 38
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label18.Location = New System.Drawing.Point(52, 311)
		Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(98, 16)
		Me.Label18.TabIndex = 40
		Me.Label18.Text = "Mod Depth (%)"
		'
		'TextBoxModDep2
		'
		Me.TextBoxModDep2.Location = New System.Drawing.Point(163, 311)
		Me.TextBoxModDep2.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxModDep2.Multiline = True
		Me.TextBoxModDep2.Name = "TextBoxModDep2"
		Me.TextBoxModDep2.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxModDep2.TabIndex = 38
		'
		'TextBoxModFreq2
		'
		Me.TextBoxModFreq2.Location = New System.Drawing.Point(163, 345)
		Me.TextBoxModFreq2.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxModFreq2.Multiline = True
		Me.TextBoxModFreq2.Name = "TextBoxModFreq2"
		Me.TextBoxModFreq2.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxModFreq2.TabIndex = 39
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label19.Location = New System.Drawing.Point(52, 348)
		Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(93, 16)
		Me.Label19.TabIndex = 41
		Me.Label19.Text = "Mod Freq (Hz)"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.Location = New System.Drawing.Point(52, 206)
		Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(71, 16)
		Me.Label9.TabIndex = 26
		Me.Label9.Text = "Delay (ms)"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.Location = New System.Drawing.Point(52, 137)
		Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(94, 16)
		Me.Label11.TabIndex = 27
		Me.Label11.Text = "Intensities (dB)"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.Location = New System.Drawing.Point(52, 171)
		Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(105, 16)
		Me.Label10.TabIndex = 28
		Me.Label10.Text = "Frequencies (Hz)"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(51, 72)
		Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(89, 16)
		Me.Label4.TabIndex = 32
		Me.Label4.Text = "Stimulus Type"
		'
		'Ch2Noise
		'
		Me.Ch2Noise.AutoSize = True
		Me.Ch2Noise.Location = New System.Drawing.Point(181, 62)
		Me.Ch2Noise.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch2Noise.Name = "Ch2Noise"
		Me.Ch2Noise.Size = New System.Drawing.Size(52, 17)
		Me.Ch2Noise.TabIndex = 31
		Me.Ch2Noise.TabStop = True
		Me.Ch2Noise.Text = "Noise"
		Me.Ch2Noise.UseVisualStyleBackColor = True
		'
		'Ch2Tone
		'
		Me.Ch2Tone.AutoSize = True
		Me.Ch2Tone.Location = New System.Drawing.Point(181, 45)
		Me.Ch2Tone.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch2Tone.Name = "Ch2Tone"
		Me.Ch2Tone.Size = New System.Drawing.Size(50, 17)
		Me.Ch2Tone.TabIndex = 30
		Me.Ch2Tone.TabStop = True
		Me.Ch2Tone.Text = "Tone"
		Me.Ch2Tone.UseVisualStyleBackColor = True
		'
		'LoadCh2
		'
		Me.LoadCh2.Location = New System.Drawing.Point(55, 472)
		Me.LoadCh2.Margin = New System.Windows.Forms.Padding(2)
		Me.LoadCh2.Name = "LoadCh2"
		Me.LoadCh2.Size = New System.Drawing.Size(197, 35)
		Me.LoadCh2.TabIndex = 23
		Me.LoadCh2.Text = "Load Channel 2 Parameters"
		Me.LoadCh2.UseVisualStyleBackColor = True
		'
		'ClearCh2
		'
		Me.ClearCh2.Location = New System.Drawing.Point(55, 512)
		Me.ClearCh2.Margin = New System.Windows.Forms.Padding(2)
		Me.ClearCh2.Name = "ClearCh2"
		Me.ClearCh2.Size = New System.Drawing.Size(197, 35)
		Me.ClearCh2.TabIndex = 22
		Me.ClearCh2.Text = "Clear Channel 2 Parameters"
		Me.ClearCh2.UseVisualStyleBackColor = True
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(48, 207)
		Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(71, 16)
		Me.Label6.TabIndex = 23
		Me.Label6.Text = "Delay (ms)"
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.TextBoxCH1RFTime)
		Me.Panel2.Controls.Add(Me.Label34)
		Me.Panel2.Controls.Add(Me.CH1AM_Check)
		Me.Panel2.Controls.Add(Me.Ch1Filter)
		Me.Panel2.Controls.Add(Me.Label27)
		Me.Panel2.Controls.Add(Me.TextBoxCh1Dur)
		Me.Panel2.Controls.Add(Me.Label16)
		Me.Panel2.Controls.Add(Me.TextBoxModDep1)
		Me.Panel2.Controls.Add(Me.Label17)
		Me.Panel2.Controls.Add(Me.TextBoxModFreq1)
		Me.Panel2.Controls.Add(Me.Label7)
		Me.Panel2.Controls.Add(Me.Label8)
		Me.Panel2.Controls.Add(Me.Label6)
		Me.Panel2.Controls.Add(Me.Label5)
		Me.Panel2.Controls.Add(Me.Ch1Noise)
		Me.Panel2.Controls.Add(Me.Ch1Tone)
		Me.Panel2.Controls.Add(Me.LoadCh1)
		Me.Panel2.Controls.Add(Me.ClearCh1)
		Me.Panel2.Controls.Add(Me.Label2)
		Me.Panel2.Controls.Add(Me.TextBoxDelay1)
		Me.Panel2.Controls.Add(Me.TextBoxFreq1)
		Me.Panel2.Controls.Add(Me.TextBoxAmp1)
		Me.Panel2.Location = New System.Drawing.Point(177, 137)
		Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(296, 576)
		Me.Panel2.TabIndex = 21
		'
		'TextBoxCH1RFTime
		'
		Me.TextBoxCH1RFTime.Location = New System.Drawing.Point(159, 277)
		Me.TextBoxCH1RFTime.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxCH1RFTime.Multiline = True
		Me.TextBoxCH1RFTime.Name = "TextBoxCH1RFTime"
		Me.TextBoxCH1RFTime.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxCH1RFTime.TabIndex = 50
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label34.Location = New System.Drawing.Point(48, 280)
		Me.Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(87, 16)
		Me.Label34.TabIndex = 51
		Me.Label34.Text = "Rise/Fall (ms)"
		'
		'CH1AM_Check
		'
		Me.CH1AM_Check.AutoSize = True
		Me.CH1AM_Check.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CH1AM_Check.Location = New System.Drawing.Point(183, 93)
		Me.CH1AM_Check.Margin = New System.Windows.Forms.Padding(2)
		Me.CH1AM_Check.Name = "CH1AM_Check"
		Me.CH1AM_Check.Size = New System.Drawing.Size(42, 17)
		Me.CH1AM_Check.TabIndex = 48
		Me.CH1AM_Check.Text = "AM"
		Me.CH1AM_Check.UseVisualStyleBackColor = True
		'
		'Ch1Filter
		'
		Me.Ch1Filter.AutoSize = True
		Me.Ch1Filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Ch1Filter.Location = New System.Drawing.Point(183, 74)
		Me.Ch1Filter.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch1Filter.Name = "Ch1Filter"
		Me.Ch1Filter.Size = New System.Drawing.Size(48, 17)
		Me.Ch1Filter.TabIndex = 45
		Me.Ch1Filter.Text = "Filter"
		Me.Ch1Filter.UseVisualStyleBackColor = True
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label27.Location = New System.Drawing.Point(48, 242)
		Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(88, 16)
		Me.Label27.TabIndex = 36
		Me.Label27.Text = "Duration (ms)"
		'
		'TextBoxCh1Dur
		'
		Me.TextBoxCh1Dur.Location = New System.Drawing.Point(159, 242)
		Me.TextBoxCh1Dur.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxCh1Dur.Multiline = True
		Me.TextBoxCh1Dur.Name = "TextBoxCh1Dur"
		Me.TextBoxCh1Dur.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxCh1Dur.TabIndex = 35
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label16.Location = New System.Drawing.Point(48, 312)
		Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(98, 16)
		Me.Label16.TabIndex = 36
		Me.Label16.Text = "Mod Depth (%)"
		'
		'TextBoxModDep1
		'
		Me.TextBoxModDep1.Location = New System.Drawing.Point(159, 312)
		Me.TextBoxModDep1.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxModDep1.Multiline = True
		Me.TextBoxModDep1.Name = "TextBoxModDep1"
		Me.TextBoxModDep1.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxModDep1.TabIndex = 34
		'
		'Label17
		'
		Me.Label17.AutoSize = True
		Me.Label17.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label17.Location = New System.Drawing.Point(48, 346)
		Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label17.Name = "Label17"
		Me.Label17.Size = New System.Drawing.Size(93, 16)
		Me.Label17.TabIndex = 37
		Me.Label17.Text = "Mod Freq (Hz)"
		'
		'TextBoxModFreq1
		'
		Me.TextBoxModFreq1.Location = New System.Drawing.Point(159, 346)
		Me.TextBoxModFreq1.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxModFreq1.Multiline = True
		Me.TextBoxModFreq1.Name = "TextBoxModFreq1"
		Me.TextBoxModFreq1.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxModFreq1.TabIndex = 35
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(48, 137)
		Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(94, 16)
		Me.Label7.TabIndex = 24
		Me.Label7.Text = "Intensities (dB)"
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.Location = New System.Drawing.Point(48, 172)
		Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(105, 16)
		Me.Label8.TabIndex = 25
		Me.Label8.Text = "Frequencies (Hz)"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.Location = New System.Drawing.Point(48, 74)
		Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(89, 16)
		Me.Label5.TabIndex = 33
		Me.Label5.Text = "Stimulus Type"
		'
		'Ch1Noise
		'
		Me.Ch1Noise.AutoSize = True
		Me.Ch1Noise.Location = New System.Drawing.Point(183, 56)
		Me.Ch1Noise.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch1Noise.Name = "Ch1Noise"
		Me.Ch1Noise.Size = New System.Drawing.Size(52, 17)
		Me.Ch1Noise.TabIndex = 28
		Me.Ch1Noise.TabStop = True
		Me.Ch1Noise.Text = "Noise"
		Me.Ch1Noise.UseVisualStyleBackColor = True
		'
		'Ch1Tone
		'
		Me.Ch1Tone.AutoSize = True
		Me.Ch1Tone.Location = New System.Drawing.Point(183, 39)
		Me.Ch1Tone.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch1Tone.Name = "Ch1Tone"
		Me.Ch1Tone.Size = New System.Drawing.Size(50, 17)
		Me.Ch1Tone.TabIndex = 27
		Me.Ch1Tone.TabStop = True
		Me.Ch1Tone.Text = "Tone"
		Me.Ch1Tone.UseVisualStyleBackColor = True
		'
		'LoadCh1
		'
		Me.LoadCh1.Location = New System.Drawing.Point(52, 473)
		Me.LoadCh1.Margin = New System.Windows.Forms.Padding(2)
		Me.LoadCh1.Name = "LoadCh1"
		Me.LoadCh1.Size = New System.Drawing.Size(197, 35)
		Me.LoadCh1.TabIndex = 24
		Me.LoadCh1.Text = "Load Channel 1 Parameters"
		Me.LoadCh1.UseVisualStyleBackColor = True
		'
		'ClearCh1
		'
		Me.ClearCh1.Location = New System.Drawing.Point(52, 515)
		Me.ClearCh1.Margin = New System.Windows.Forms.Padding(2)
		Me.ClearCh1.Name = "ClearCh1"
		Me.ClearCh1.Size = New System.Drawing.Size(197, 35)
		Me.ClearCh1.TabIndex = 23
		Me.ClearCh1.Text = "Clear Channel 1 Parameters"
		Me.ClearCh1.UseVisualStyleBackColor = True
		'
		'ButtonWrtAll
		'
		Me.ButtonWrtAll.Location = New System.Drawing.Point(988, 580)
		Me.ButtonWrtAll.Margin = New System.Windows.Forms.Padding(2)
		Me.ButtonWrtAll.Name = "ButtonWrtAll"
		Me.ButtonWrtAll.Size = New System.Drawing.Size(195, 65)
		Me.ButtonWrtAll.TabIndex = 22
		Me.ButtonWrtAll.Text = "Write Current Test Case"
		Me.ButtonWrtAll.UseVisualStyleBackColor = True
		'
		'OpenFileDialogDefault
		'
		Me.OpenFileDialogDefault.FileName = "OpenFileDialogDefault"
		'
		'Label13
		'
		Me.Label13.AutoSize = True
		Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.Location = New System.Drawing.Point(30, 106)
		Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label13.Name = "Label13"
		Me.Label13.Size = New System.Drawing.Size(80, 19)
		Me.Label13.TabIndex = 28
		Me.Label13.Text = "Period (ms)"
		'
		'TextBoxPeriod
		'
		Me.TextBoxPeriod.Location = New System.Drawing.Point(24, 129)
		Me.TextBoxPeriod.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxPeriod.Multiline = True
		Me.TextBoxPeriod.Name = "TextBoxPeriod"
		Me.TextBoxPeriod.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxPeriod.TabIndex = 27
		'
		'Label14
		'
		Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label14.AutoSize = True
		Me.Label14.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label14.Location = New System.Drawing.Point(26, 15)
		Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(100, 16)
		Me.Label14.TabIndex = 29
		Me.Label14.Text = "Timing Controls"
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label15.Location = New System.Drawing.Point(37, 173)
		Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(65, 19)
		Me.Label15.TabIndex = 31
		Me.Label15.Text = "Repitions"
		'
		'TextBoxReps
		'
		Me.TextBoxReps.Location = New System.Drawing.Point(24, 194)
		Me.TextBoxReps.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxReps.Multiline = True
		Me.TextBoxReps.Name = "TextBoxReps"
		Me.TextBoxReps.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxReps.TabIndex = 30
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.Label31)
		Me.Panel3.Controls.Add(Me.RepTrials)
		Me.Panel3.Controls.Add(Me.RepSets)
		Me.Panel3.Controls.Add(Me.Label15)
		Me.Panel3.Controls.Add(Me.TextBoxReps)
		Me.Panel3.Controls.Add(Me.Label14)
		Me.Panel3.Controls.Add(Me.Label13)
		Me.Panel3.Controls.Add(Me.TextBoxPeriod)
		Me.Panel3.Location = New System.Drawing.Point(9, 137)
		Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(153, 246)
		Me.Panel3.TabIndex = 33
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label31.Location = New System.Drawing.Point(39, 40)
		Me.Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(68, 19)
		Me.Label31.TabIndex = 42
		Me.Label31.Text = "Rep Type"
		'
		'RepTrials
		'
		Me.RepTrials.AutoSize = True
		Me.RepTrials.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RepTrials.Location = New System.Drawing.Point(29, 74)
		Me.RepTrials.Margin = New System.Windows.Forms.Padding(2)
		Me.RepTrials.Name = "RepTrials"
		Me.RepTrials.Size = New System.Drawing.Size(100, 20)
		Me.RepTrials.TabIndex = 43
		Me.RepTrials.TabStop = True
		Me.RepTrials.Text = "Repeat Trials"
		Me.RepTrials.UseVisualStyleBackColor = True
		'
		'RepSets
		'
		Me.RepSets.AutoSize = True
		Me.RepSets.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RepSets.Location = New System.Drawing.Point(29, 58)
		Me.RepSets.Margin = New System.Windows.Forms.Padding(2)
		Me.RepSets.Name = "RepSets"
		Me.RepSets.Size = New System.Drawing.Size(92, 20)
		Me.RepSets.TabIndex = 42
		Me.RepSets.TabStop = True
		Me.RepSets.Text = "Repeat Sets"
		Me.RepSets.UseVisualStyleBackColor = True
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.ClearEParam)
		Me.Panel4.Controls.Add(Me.Panel6)
		Me.Panel4.Controls.Add(Me.Panel5)
		Me.Panel4.Controls.Add(Me.LoadEParam)
		Me.Panel4.Controls.Add(Me.Label26)
		Me.Panel4.Location = New System.Drawing.Point(779, 138)
		Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(417, 438)
		Me.Panel4.TabIndex = 34
		'
		'ClearEParam
		'
		Me.ClearEParam.Location = New System.Drawing.Point(56, 360)
		Me.ClearEParam.Margin = New System.Windows.Forms.Padding(2)
		Me.ClearEParam.Name = "ClearEParam"
		Me.ClearEParam.Size = New System.Drawing.Size(277, 35)
		Me.ClearEParam.TabIndex = 22
		Me.ClearEParam.Text = "Clear Electrical Parameters"
		Me.ClearEParam.UseVisualStyleBackColor = True
		'
		'Panel6
		'
		Me.Panel6.Controls.Add(Me.TextBoxEPWidth)
		Me.Panel6.Controls.Add(Me.TextBoxEDur)
		Me.Panel6.Controls.Add(Me.Label32)
		Me.Panel6.Controls.Add(Me.Label30)
		Me.Panel6.Controls.Add(Me.TextBoxIPGap)
		Me.Panel6.Controls.Add(Me.Label20)
		Me.Panel6.Controls.Add(Me.TextBoxEPFreq)
		Me.Panel6.Controls.Add(Me.Label21)
		Me.Panel6.Controls.Add(Me.Label23)
		Me.Panel6.Controls.Add(Me.Label24)
		Me.Panel6.Controls.Add(Me.TextBoxEAmpl)
		Me.Panel6.Controls.Add(Me.TextBoxEDel)
		Me.Panel6.Location = New System.Drawing.Point(15, 36)
		Me.Panel6.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel6.Name = "Panel6"
		Me.Panel6.Size = New System.Drawing.Size(206, 245)
		Me.Panel6.TabIndex = 45
		'
		'TextBoxEPWidth
		'
		Me.TextBoxEPWidth.Location = New System.Drawing.Point(104, 161)
		Me.TextBoxEPWidth.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxEPWidth.Multiline = True
		Me.TextBoxEPWidth.Name = "TextBoxEPWidth"
		Me.TextBoxEPWidth.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxEPWidth.TabIndex = 39
		'
		'TextBoxEDur
		'
		Me.TextBoxEDur.Location = New System.Drawing.Point(104, 92)
		Me.TextBoxEDur.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxEDur.Multiline = True
		Me.TextBoxEDur.Name = "TextBoxEDur"
		Me.TextBoxEDur.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxEDur.TabIndex = 35
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label32.Location = New System.Drawing.Point(2, 92)
		Me.Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(88, 16)
		Me.Label32.TabIndex = 36
		Me.Label32.Text = "Duration (ms)"
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label30.Location = New System.Drawing.Point(2, 196)
		Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(100, 16)
		Me.Label30.TabIndex = 43
		Me.Label30.Text = "IPhase Gap (us)"
		'
		'TextBoxIPGap
		'
		Me.TextBoxIPGap.Location = New System.Drawing.Point(104, 196)
		Me.TextBoxIPGap.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxIPGap.Multiline = True
		Me.TextBoxIPGap.Name = "TextBoxIPGap"
		Me.TextBoxIPGap.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxIPGap.TabIndex = 42
		'
		'Label20
		'
		Me.Label20.AutoSize = True
		Me.Label20.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label20.Location = New System.Drawing.Point(2, 126)
		Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label20.Name = "Label20"
		Me.Label20.Size = New System.Drawing.Size(97, 16)
		Me.Label20.TabIndex = 40
		Me.Label20.Text = "Pulse Freq (Hz)"
		'
		'TextBoxEPFreq
		'
		Me.TextBoxEPFreq.Location = New System.Drawing.Point(104, 126)
		Me.TextBoxEPFreq.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxEPFreq.Multiline = True
		Me.TextBoxEPFreq.Name = "TextBoxEPFreq"
		Me.TextBoxEPFreq.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxEPFreq.TabIndex = 38
		'
		'Label21
		'
		Me.Label21.AutoSize = True
		Me.Label21.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label21.Location = New System.Drawing.Point(2, 161)
		Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label21.Name = "Label21"
		Me.Label21.Size = New System.Drawing.Size(102, 16)
		Me.Label21.TabIndex = 41
		Me.Label21.Text = "Pulse Width (us)"
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label23.Location = New System.Drawing.Point(2, 57)
		Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(71, 16)
		Me.Label23.TabIndex = 27
		Me.Label23.Text = "Delay (ms)"
		'
		'Label24
		'
		Me.Label24.AutoSize = True
		Me.Label24.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label24.Location = New System.Drawing.Point(2, 19)
		Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label24.Name = "Label24"
		Me.Label24.Size = New System.Drawing.Size(88, 16)
		Me.Label24.TabIndex = 28
		Me.Label24.Text = "Amplitude (V)"
		'
		'TextBoxEAmpl
		'
		Me.TextBoxEAmpl.Location = New System.Drawing.Point(104, 19)
		Me.TextBoxEAmpl.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxEAmpl.Multiline = True
		Me.TextBoxEAmpl.Name = "TextBoxEAmpl"
		Me.TextBoxEAmpl.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxEAmpl.TabIndex = 14
		'
		'TextBoxEDel
		'
		Me.TextBoxEDel.Location = New System.Drawing.Point(104, 57)
		Me.TextBoxEDel.Margin = New System.Windows.Forms.Padding(2)
		Me.TextBoxEDel.Multiline = True
		Me.TextBoxEDel.Name = "TextBoxEDel"
		Me.TextBoxEDel.Size = New System.Drawing.Size(90, 31)
		Me.TextBoxEDel.TabIndex = 12
		'
		'Panel5
		'
		Me.Panel5.Controls.Add(Me.Laser_Tag)
		Me.Panel5.Controls.Add(Me.Panel8)
		Me.Panel5.Controls.Add(Me.Panel10)
		Me.Panel5.Controls.Add(Me.Panel7)
		Me.Panel5.Location = New System.Drawing.Point(233, 38)
		Me.Panel5.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel5.Name = "Panel5"
		Me.Panel5.Size = New System.Drawing.Size(134, 269)
		Me.Panel5.TabIndex = 44
		'
		'Laser_Tag
		'
		Me.Laser_Tag.AutoSize = True
		Me.Laser_Tag.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Laser_Tag.Location = New System.Drawing.Point(15, 66)
		Me.Laser_Tag.Margin = New System.Windows.Forms.Padding(2)
		Me.Laser_Tag.Name = "Laser_Tag"
		Me.Laser_Tag.Size = New System.Drawing.Size(94, 19)
		Me.Laser_Tag.TabIndex = 43
		Me.Laser_Tag.Text = "Laser Enable"
		Me.Laser_Tag.UseVisualStyleBackColor = True
		'
		'Panel8
		'
		Me.Panel8.Controls.Add(Me.Label33)
		Me.Panel8.Controls.Add(Me.EStimDisable)
		Me.Panel8.Controls.Add(Me.EStimEnable)
		Me.Panel8.Location = New System.Drawing.Point(12, 2)
		Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel8.Name = "Panel8"
		Me.Panel8.Size = New System.Drawing.Size(102, 60)
		Me.Panel8.TabIndex = 42
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label33.Location = New System.Drawing.Point(5, 7)
		Me.Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(90, 16)
		Me.Label33.TabIndex = 37
		Me.Label33.Text = "Electrical Stim"
		'
		'EStimDisable
		'
		Me.EStimDisable.AutoSize = True
		Me.EStimDisable.Location = New System.Drawing.Point(3, 41)
		Me.EStimDisable.Margin = New System.Windows.Forms.Padding(2)
		Me.EStimDisable.Name = "EStimDisable"
		Me.EStimDisable.Size = New System.Drawing.Size(66, 17)
		Me.EStimDisable.TabIndex = 36
		Me.EStimDisable.TabStop = True
		Me.EStimDisable.Text = "Disabled"
		Me.EStimDisable.UseVisualStyleBackColor = True
		'
		'EStimEnable
		'
		Me.EStimEnable.AutoSize = True
		Me.EStimEnable.Location = New System.Drawing.Point(3, 25)
		Me.EStimEnable.Margin = New System.Windows.Forms.Padding(2)
		Me.EStimEnable.Name = "EStimEnable"
		Me.EStimEnable.Size = New System.Drawing.Size(64, 17)
		Me.EStimEnable.TabIndex = 35
		Me.EStimEnable.TabStop = True
		Me.EStimEnable.Text = "Enabled"
		Me.EStimEnable.UseVisualStyleBackColor = True
		'
		'Panel10
		'
		Me.Panel10.Controls.Add(Me.EStimTypeMono)
		Me.Panel10.Controls.Add(Me.EStimTypeBi)
		Me.Panel10.Controls.Add(Me.Label25)
		Me.Panel10.Location = New System.Drawing.Point(12, 90)
		Me.Panel10.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel10.Name = "Panel10"
		Me.Panel10.Size = New System.Drawing.Size(102, 82)
		Me.Panel10.TabIndex = 41
		'
		'EStimTypeMono
		'
		Me.EStimTypeMono.AutoSize = True
		Me.EStimTypeMono.Location = New System.Drawing.Point(3, 50)
		Me.EStimTypeMono.Margin = New System.Windows.Forms.Padding(2)
		Me.EStimTypeMono.Name = "EStimTypeMono"
		Me.EStimTypeMono.Size = New System.Drawing.Size(83, 17)
		Me.EStimTypeMono.TabIndex = 36
		Me.EStimTypeMono.TabStop = True
		Me.EStimTypeMono.Text = "Monophasic"
		Me.EStimTypeMono.UseVisualStyleBackColor = True
		'
		'EStimTypeBi
		'
		Me.EStimTypeBi.AutoSize = True
		Me.EStimTypeBi.Location = New System.Drawing.Point(3, 29)
		Me.EStimTypeBi.Margin = New System.Windows.Forms.Padding(2)
		Me.EStimTypeBi.Name = "EStimTypeBi"
		Me.EStimTypeBi.Size = New System.Drawing.Size(65, 17)
		Me.EStimTypeBi.TabIndex = 35
		Me.EStimTypeBi.TabStop = True
		Me.EStimTypeBi.Text = "Biphasic"
		Me.EStimTypeBi.UseVisualStyleBackColor = True
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label25.Location = New System.Drawing.Point(5, 8)
		Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(89, 16)
		Me.Label25.TabIndex = 32
		Me.Label25.Text = "Stimulus Type"
		'
		'Panel7
		'
		Me.Panel7.Controls.Add(Me.BiPhasePos)
		Me.Panel7.Controls.Add(Me.BiPhaseNeg)
		Me.Panel7.Controls.Add(Me.Label29)
		Me.Panel7.Location = New System.Drawing.Point(12, 178)
		Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel7.Name = "Panel7"
		Me.Panel7.Size = New System.Drawing.Size(102, 65)
		Me.Panel7.TabIndex = 38
		'
		'BiPhasePos
		'
		Me.BiPhasePos.AutoSize = True
		Me.BiPhasePos.Location = New System.Drawing.Point(3, 28)
		Me.BiPhasePos.Margin = New System.Windows.Forms.Padding(2)
		Me.BiPhasePos.Name = "BiPhasePos"
		Me.BiPhasePos.Size = New System.Drawing.Size(84, 17)
		Me.BiPhasePos.TabIndex = 35
		Me.BiPhasePos.TabStop = True
		Me.BiPhasePos.Text = "Positive First"
		Me.BiPhasePos.UseVisualStyleBackColor = True
		'
		'BiPhaseNeg
		'
		Me.BiPhaseNeg.AutoSize = True
		Me.BiPhaseNeg.Location = New System.Drawing.Point(3, 45)
		Me.BiPhaseNeg.Margin = New System.Windows.Forms.Padding(2)
		Me.BiPhaseNeg.Name = "BiPhaseNeg"
		Me.BiPhaseNeg.Size = New System.Drawing.Size(90, 17)
		Me.BiPhaseNeg.TabIndex = 36
		Me.BiPhaseNeg.TabStop = True
		Me.BiPhaseNeg.Text = "Negative First"
		Me.BiPhaseNeg.UseVisualStyleBackColor = True
		'
		'Label29
		'
		Me.Label29.AutoSize = True
		Me.Label29.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label29.Location = New System.Drawing.Point(8, 8)
		Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(88, 16)
		Me.Label29.TabIndex = 37
		Me.Label29.Text = "Biphase Phase"
		'
		'LoadEParam
		'
		Me.LoadEParam.Location = New System.Drawing.Point(56, 321)
		Me.LoadEParam.Margin = New System.Windows.Forms.Padding(2)
		Me.LoadEParam.Name = "LoadEParam"
		Me.LoadEParam.Size = New System.Drawing.Size(277, 35)
		Me.LoadEParam.TabIndex = 23
		Me.LoadEParam.Text = "Load Electrical Parameters"
		Me.LoadEParam.UseVisualStyleBackColor = True
		'
		'Label26
		'
		Me.Label26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label26.AutoSize = True
		Me.Label26.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label26.Location = New System.Drawing.Point(146, 12)
		Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(136, 19)
		Me.Label26.TabIndex = 19
		Me.Label26.Text = "Electrical Parameters"
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Label12
		'
		Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
				  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label12.AutoSize = True
		Me.Label12.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.Location = New System.Drawing.Point(12, 18)
		Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(110, 16)
		Me.Label12.TabIndex = 40
		Me.Label12.Text = "Data Sort Options"
		'
		'Panel9
		'
		Me.Panel9.Controls.Add(Me.Mouse)
		Me.Panel9.Controls.Add(Me.MixSignals)
		Me.Panel9.Controls.Add(Me.LinearEnable)
		Me.Panel9.Controls.Add(Me.RandAll)
		Me.Panel9.Controls.Add(Me.RandTrials)
		Me.Panel9.Controls.Add(Me.RandSets)
		Me.Panel9.Controls.Add(Me.Label12)
		Me.Panel9.Location = New System.Drawing.Point(9, 387)
		Me.Panel9.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel9.Name = "Panel9"
		Me.Panel9.Size = New System.Drawing.Size(153, 189)
		Me.Panel9.TabIndex = 41
		'
		'MixSignals
		'
		Me.MixSignals.AutoSize = True
		Me.MixSignals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.MixSignals.Location = New System.Drawing.Point(15, 113)
		Me.MixSignals.Margin = New System.Windows.Forms.Padding(2)
		Me.MixSignals.Name = "MixSignals"
		Me.MixSignals.Size = New System.Drawing.Size(109, 17)
		Me.MixSignals.TabIndex = 50
		Me.MixSignals.Text = "Mix Audio Signals"
		Me.MixSignals.UseVisualStyleBackColor = True
		'
		'LinearEnable
		'
		Me.LinearEnable.AutoSize = True
		Me.LinearEnable.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LinearEnable.Location = New System.Drawing.Point(15, 91)
		Me.LinearEnable.Margin = New System.Windows.Forms.Padding(2)
		Me.LinearEnable.Name = "LinearEnable"
		Me.LinearEnable.Size = New System.Drawing.Size(112, 18)
		Me.LinearEnable.TabIndex = 42
		Me.LinearEnable.Text = "Linear Frequencies"
		Me.LinearEnable.UseVisualStyleBackColor = True
		'
		'RandAll
		'
		Me.RandAll.AutoSize = True
		Me.RandAll.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RandAll.Location = New System.Drawing.Point(15, 72)
		Me.RandAll.Margin = New System.Windows.Forms.Padding(2)
		Me.RandAll.Name = "RandAll"
		Me.RandAll.Size = New System.Drawing.Size(92, 18)
		Me.RandAll.TabIndex = 40
		Me.RandAll.TabStop = True
		Me.RandAll.Text = "Randomize All"
		Me.RandAll.UseVisualStyleBackColor = True
		'
		'RandTrials
		'
		Me.RandTrials.AutoSize = True
		Me.RandTrials.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RandTrials.Location = New System.Drawing.Point(15, 36)
		Me.RandTrials.Margin = New System.Windows.Forms.Padding(2)
		Me.RandTrials.Name = "RandTrials"
		Me.RandTrials.Size = New System.Drawing.Size(112, 18)
		Me.RandTrials.TabIndex = 39
		Me.RandTrials.TabStop = True
		Me.RandTrials.Text = "No Randomization"
		Me.RandTrials.UseVisualStyleBackColor = True
		'
		'RandSets
		'
		Me.RandSets.AutoSize = True
		Me.RandSets.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.RandSets.Location = New System.Drawing.Point(15, 53)
		Me.RandSets.Margin = New System.Windows.Forms.Padding(2)
		Me.RandSets.Name = "RandSets"
		Me.RandSets.Size = New System.Drawing.Size(110, 18)
		Me.RandSets.TabIndex = 38
		Me.RandSets.TabStop = True
		Me.RandSets.Text = "Randomize Blocks"
		Me.RandSets.UseVisualStyleBackColor = True
		'
		'CurTestCase
		'
		Me.CurTestCase.AutoSize = True
		Me.CurTestCase.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CurTestCase.Location = New System.Drawing.Point(25, 54)
		Me.CurTestCase.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.CurTestCase.Name = "CurTestCase"
		Me.CurTestCase.Size = New System.Drawing.Size(154, 21)
		Me.CurTestCase.TabIndex = 42
		Me.CurTestCase.Text = "Current Test Case: "
		'
		'WorkDirectory
		'
		Me.WorkDirectory.AutoSize = True
		Me.WorkDirectory.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.WorkDirectory.Location = New System.Drawing.Point(25, 20)
		Me.WorkDirectory.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.WorkDirectory.Name = "WorkDirectory"
		Me.WorkDirectory.Size = New System.Drawing.Size(150, 21)
		Me.WorkDirectory.TabIndex = 43
		Me.WorkDirectory.Text = "Current Directory: "
		'
		'Panel11
		'
		Me.Panel11.Controls.Add(Me.WorkDirectory)
		Me.Panel11.Controls.Add(Me.CurTestCase)
		Me.Panel11.Location = New System.Drawing.Point(9, 40)
		Me.Panel11.Margin = New System.Windows.Forms.Padding(2)
		Me.Panel11.Name = "Panel11"
		Me.Panel11.Size = New System.Drawing.Size(1187, 103)
		Me.Panel11.TabIndex = 44
		'
		'Ch1FilterDesign
		'
		Me.Ch1FilterDesign.Location = New System.Drawing.Point(14, 580)
		Me.Ch1FilterDesign.Margin = New System.Windows.Forms.Padding(2)
		Me.Ch1FilterDesign.Name = "Ch1FilterDesign"
		Me.Ch1FilterDesign.Size = New System.Drawing.Size(148, 133)
		Me.Ch1FilterDesign.TabIndex = 45
		Me.Ch1FilterDesign.Text = "Design Channel 1 Filter"
		Me.Ch1FilterDesign.UseVisualStyleBackColor = True
		'
		'Mouse
		'
		Me.Mouse.AutoSize = True
		Me.Mouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Mouse.Location = New System.Drawing.Point(15, 134)
		Me.Mouse.Margin = New System.Windows.Forms.Padding(2)
		Me.Mouse.Name = "Mouse"
		Me.Mouse.Size = New System.Drawing.Size(58, 17)
		Me.Mouse.TabIndex = 51
		Me.Mouse.Text = "Mouse"
		Me.Mouse.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
		Me.ClientSize = New System.Drawing.Size(1208, 735)
		Me.Controls.Add(Me.Ch1FilterDesign)
		Me.Controls.Add(Me.Panel4)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel11)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel9)
		Me.Controls.Add(Me.ButtonWrtAll)
		Me.Controls.Add(Me.ButtonClrAll)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.ButtonQuit)
		Me.Controls.Add(Me.ButtonLoadTest)
		Me.Margin = New System.Windows.Forms.Padding(2)
		Me.Name = "Form1"
		Me.Text = "Test Case Constructor"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.Panel3.ResumeLayout(False)
		Me.Panel3.PerformLayout()
		Me.Panel4.ResumeLayout(False)
		Me.Panel4.PerformLayout()
		Me.Panel6.ResumeLayout(False)
		Me.Panel6.PerformLayout()
		Me.Panel5.ResumeLayout(False)
		Me.Panel5.PerformLayout()
		Me.Panel8.ResumeLayout(False)
		Me.Panel8.PerformLayout()
		Me.Panel10.ResumeLayout(False)
		Me.Panel10.PerformLayout()
		Me.Panel7.ResumeLayout(False)
		Me.Panel7.PerformLayout()
		Me.Panel9.ResumeLayout(False)
		Me.Panel9.PerformLayout()
		Me.Panel11.ResumeLayout(False)
		Me.Panel11.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ButtonLoadTest As System.Windows.Forms.Button
	Friend WithEvents TextBoxAmp1 As System.Windows.Forms.TextBox
	Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
	Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
	Friend WithEvents ButtonClrAll As System.Windows.Forms.Button
	Friend WithEvents TextBoxFreq1 As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxDelay1 As System.Windows.Forms.TextBox
	Friend WithEvents ButtonQuit As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents TextBoxDelay2 As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxFreq2 As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxAmp2 As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents ClearCh2 As System.Windows.Forms.Button
	Friend WithEvents ClearCh1 As System.Windows.Forms.Button
	Friend WithEvents LoadCh2 As System.Windows.Forms.Button
	Friend WithEvents LoadCh1 As System.Windows.Forms.Button
	Friend WithEvents Ch1Noise As System.Windows.Forms.RadioButton
	Friend WithEvents Ch1Tone As System.Windows.Forms.RadioButton
	Friend WithEvents ButtonWrtAll As System.Windows.Forms.Button
	Friend WithEvents OpenFileDialogDefault As System.Windows.Forms.OpenFileDialog
	Friend WithEvents Ch2Noise As System.Windows.Forms.RadioButton
	Friend WithEvents Ch2Tone As System.Windows.Forms.RadioButton
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents Label11 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents TextBoxPeriod As System.Windows.Forms.TextBox
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents TextBoxReps As System.Windows.Forms.TextBox
	Friend WithEvents Panel3 As System.Windows.Forms.Panel
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents TextBoxModDep1 As System.Windows.Forms.TextBox
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents TextBoxModFreq1 As System.Windows.Forms.TextBox
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents TextBoxModDep2 As System.Windows.Forms.TextBox
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents TextBoxModFreq2 As System.Windows.Forms.TextBox
	Friend WithEvents Panel4 As System.Windows.Forms.Panel
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents TextBoxEPFreq As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxEPWidth As System.Windows.Forms.TextBox
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents Label23 As System.Windows.Forms.Label
	Friend WithEvents Label24 As System.Windows.Forms.Label
	Friend WithEvents LoadEParam As System.Windows.Forms.Button
	Friend WithEvents Label26 As System.Windows.Forms.Label
	Friend WithEvents ClearEParam As System.Windows.Forms.Button
	Friend WithEvents TextBoxEAmpl As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxEDel As System.Windows.Forms.TextBox
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents TextBoxIPGap As System.Windows.Forms.TextBox
	Friend WithEvents TextBoxEDur As System.Windows.Forms.TextBox
	Friend WithEvents Label32 As System.Windows.Forms.Label
	Friend WithEvents Label33 As System.Windows.Forms.Label
	Friend WithEvents EStimEnable As System.Windows.Forms.RadioButton
	Friend WithEvents EStimDisable As System.Windows.Forms.RadioButton
	Friend WithEvents Panel6 As System.Windows.Forms.Panel
	Friend WithEvents Panel5 As System.Windows.Forms.Panel
	Friend WithEvents BiPhasePos As System.Windows.Forms.RadioButton
	Friend WithEvents BiPhaseNeg As System.Windows.Forms.RadioButton
	Friend WithEvents EStimTypeBi As System.Windows.Forms.RadioButton
	Friend WithEvents EStimTypeMono As System.Windows.Forms.RadioButton
	Friend WithEvents Label29 As System.Windows.Forms.Label
	Friend WithEvents Label25 As System.Windows.Forms.Label
	Friend WithEvents Panel7 As System.Windows.Forms.Panel
	Friend WithEvents Panel10 As System.Windows.Forms.Panel
	Friend WithEvents Panel8 As System.Windows.Forms.Panel
	Friend WithEvents Label27 As System.Windows.Forms.Label
	Friend WithEvents TextBoxCh1Dur As System.Windows.Forms.TextBox
	Friend WithEvents Label28 As System.Windows.Forms.Label
	Friend WithEvents TextBoxCh2Dur As System.Windows.Forms.TextBox
	Friend WithEvents Label12 As System.Windows.Forms.Label
	Friend WithEvents Panel9 As System.Windows.Forms.Panel
	Friend WithEvents Label31 As System.Windows.Forms.Label
	Friend WithEvents RepTrials As System.Windows.Forms.RadioButton
	Friend WithEvents RepSets As System.Windows.Forms.RadioButton
	Friend WithEvents RandAll As System.Windows.Forms.RadioButton
	Friend WithEvents RandTrials As System.Windows.Forms.RadioButton
	Friend WithEvents RandSets As System.Windows.Forms.RadioButton
	Friend WithEvents LinearEnable As System.Windows.Forms.CheckBox
	Friend WithEvents CurTestCase As System.Windows.Forms.Label
	Friend WithEvents WorkDirectory As System.Windows.Forms.Label
	Friend WithEvents Panel11 As System.Windows.Forms.Panel
	Friend WithEvents Ch1Filter As System.Windows.Forms.CheckBox
	Friend WithEvents Ch2Filter As System.Windows.Forms.CheckBox
	Friend WithEvents Ch1FilterDesign As System.Windows.Forms.Button
	Friend WithEvents Laser_Tag As System.Windows.Forms.CheckBox
	Friend WithEvents CH2AM_Check As CheckBox
	Friend WithEvents CH1AM_Check As CheckBox
	Friend WithEvents TextBoxCH2RFTime As System.Windows.Forms.TextBox
	Friend WithEvents Label22 As System.Windows.Forms.Label
	Friend WithEvents TextBoxCH1RFTime As System.Windows.Forms.TextBox
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents MixSignals As System.Windows.Forms.CheckBox
	Friend WithEvents Mouse As System.Windows.Forms.CheckBox
End Class
