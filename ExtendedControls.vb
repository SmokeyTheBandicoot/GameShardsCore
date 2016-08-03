Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms


Namespace ExtendedControls
#Region "Extended GroupBox"
    ''' <summary>
    ''' An Extended GroupBox control that allows you to customize border color
    ''' </summary>
    ''' <remarks></remarks>
    Public Class GroupBoxExt
        Inherits GroupBox

        Private _borderColor As Color

        Public Sub New()
            MyBase.New()
            Me.BorderColor = Color.Black
        End Sub

        Public Property BorderColor() As Color
            Get
                Return Me._borderColor
            End Get
            Set(value As Color)
                Me._borderColor = value
            End Set
        End Property

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim tSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
            Dim borderRect As Rectangle = e.ClipRectangle
            borderRect.Y = CInt((borderRect.Y + (tSize.Height / 2)))
            borderRect.Height = CInt((borderRect.Height - (tSize.Height / 2)))
            ControlPaint.DrawBorder(e.Graphics, borderRect, Me.BorderColor, ButtonBorderStyle.Solid)
            Dim textRect As Rectangle = e.ClipRectangle
            textRect.X = (textRect.X + 6)
            textRect.Width = tSize.Width
            textRect.Height = tSize.Height
            e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
            e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
        End Sub
    End Class
#End Region

#Region "Console"
    Public Class Console
        Inherits RichTextBox

        Public DiagnLevel As DiagnosticLevel

        ''' <summary>
        ''' The information level of the console. User should know if the message he sees is a warning, is critical, and so on. 
        ''' INFORMATION: when the application does something it is supposed to do. Just to inform the user that the program did that thing
        ''' MESSAGE: when the application needs to message the user about something. 
        ''' FINE: when the application executes correctly code that might misbehave giving wrong results. If the application misbehaves, any console output about the error whould be labelled WARNING
        ''' FINER: when the application executes correctly code that might throw an exception. If the application throws the exception, any console output should be labelled ERROR
        ''' FINEST: when the application executes correctly code that might result in a crash. If the application crashes, any other console output should be labelled CRTICAL (and maybe saved in a log .txt file before the program crashes)
        ''' WARNING: when the application misbehaves of might misbehave
        ''' ERROR: when the application throws an exception, the exception text should be labelled ERR0R (Err0r is not a typo, just error is a reserved keyword).
        ''' CRITICAL: when the application is going to crash. (Incompatible OS, missing core files)
        ''' DEBUG: when the console should print info that user shouldn't be able to access
        ''' USER: when the user writes something into the console (a command, or text, or similar)
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum InfoLevel As Byte
            Information
            Message
            Fine
            Finer
            Finest
            Warning
            Err0r
            Critical
            Debug
            User
        End Enum

        ''' <summary>
        ''' Parameter used to control the amount of messages printed in console.
        ''' MINIMAL: only foundamental messages should be labelled MINIMAL
        ''' EXTENDED: secondary information should be labelled EXTENDED
        ''' DEBUG: messages that only developer should be allowed to see
        ''' DETAILED DEBUG: diagnostic: every piece of code should output to console.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum DiagnosticLevel As Byte
            Minimal '       MI
            Extended '      EX
            Debug '         DE
            DetailedDebug ' DD
        End Enum

        'Write To Console Rich Text Box
        ''' <summary>
        ''' Writes message to a RichTextBox
        ''' </summary>
        ''' <param name="level"></param>
        ''' level: level of message. See InfoLevel for more.
        ''' <param name="diagnlvl"></param>
        ''' diagnlvl: diagnostic level: see DiagnosticLevel for more.
        ''' <param name="value"></param>
        ''' value: string to print.
        ''' <param name="sender"></param>
        ''' sender: the control, thread or region of code that prints the message.
        ''' <remarks></remarks>
        Public Sub WTCRTB(ByVal level As InfoLevel, ByVal diagnlvl As DiagnosticLevel, ByVal value As String, Optional ByVal sender As Object = "Unknown")
            'If diagnlvl <= DiagnLevel Then
            Me.SelectionColor = GetColorFromLevel(level)
            Me.AppendText(String.Format("[{0}] [{1}] [{2}] {3}{4}", Now.ToString, sender, level, value, vbNewLine))
            'End If
        End Sub

        Private Function GetColorFromLevel(ByVal level As InfoLevel) As Color
            Select Case True
                Case level = InfoLevel.User
                    Return Color.Purple
                Case level = InfoLevel.Critical
                    Return Color.DarkRed
                Case level = InfoLevel.Debug
                    Return Color.Black
                Case level = InfoLevel.Fine
                    Return Color.Green
                Case level = InfoLevel.Finer
                    Return Color.ForestGreen
                Case level = InfoLevel.Finest
                    Return Color.DarkGreen
                Case level = InfoLevel.Information
                    Return Color.Orange
                Case level = InfoLevel.Message
                    Return Color.Blue
                Case level = InfoLevel.Warning
                    Return Color.Black
                Case level = InfoLevel.Err0r
                    Return Color.Red
                Case Else
                    Return Color.Turquoise
            End Select
        End Function

        Private Sub InitializeComponent()
            Me.SuspendLayout()
            Me.ResumeLayout(False)
        End Sub
    End Class
#End Region

    ''' <summary>
    ''' Extended Picturebox. Supports indexing (ID) for linear (array) and planar (Matrix) indexing
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PictureBoxExt
        Inherits PictureBox

        Private _ID As Integer
        Private _ID2 As Point
        Private _IconLoc As String

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property

        Public Property ID2 As Point
            Get
                Return _ID2
            End Get
            Set(value As Point)
                _ID2 = value
            End Set
        End Property

        Public Property IconLocation() As String
            Get
                Return _IconLoc
            End Get
            Set(value As String)
                _IconLoc = value
            End Set
        End Property

    End Class
End Namespace