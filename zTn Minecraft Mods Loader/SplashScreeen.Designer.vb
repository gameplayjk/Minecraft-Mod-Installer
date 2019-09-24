<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreeen
    Inherits MetroFramework.Forms.MetroForm

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TwitchLabel1 = New zTn_Minecraft_Mods_Loader.TwitchLabel()
        Me.ZeroitWin8ProgressRing1 = New Zeroit.Framework.Progress.ZeroitWin8ProgressRing()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TwitchLabel1
        '
        Me.TwitchLabel1.AutoSize = True
        Me.TwitchLabel1.BackColor = System.Drawing.Color.Transparent
        Me.TwitchLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.TwitchLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TwitchLabel1.Location = New System.Drawing.Point(116, 156)
        Me.TwitchLabel1.Name = "TwitchLabel1"
        Me.TwitchLabel1.Size = New System.Drawing.Size(223, 20)
        Me.TwitchLabel1.TabIndex = 0
        Me.TwitchLabel1.Text = "Creditos: Alisson && Deivison"
        '
        'ZeroitWin8ProgressRing1
        '
        Me.ZeroitWin8ProgressRing1.ControlHeight = 60
        Me.ZeroitWin8ProgressRing1.IndicatorColor = System.Drawing.Color.Black
        Me.ZeroitWin8ProgressRing1.Location = New System.Drawing.Point(192, 83)
        Me.ZeroitWin8ProgressRing1.Name = "ZeroitWin8ProgressRing1"
        Me.ZeroitWin8ProgressRing1.RefreshRate = 100
        Me.ZeroitWin8ProgressRing1.Size = New System.Drawing.Size(60, 60)
        Me.ZeroitWin8ProgressRing1.TabIndex = 1
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(137, 29)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(165, 19)
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "zTn Minecraft Mod Loader"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3000
        '
        'SplashScreeen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.ZeroitWin8ProgressRing1)
        Me.Controls.Add(Me.TwitchLabel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreeen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TwitchLabel1 As TwitchLabel
    Friend WithEvents ZeroitWin8ProgressRing1 As Zeroit.Framework.Progress.ZeroitWin8ProgressRing
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents Timer1 As Timer
End Class
