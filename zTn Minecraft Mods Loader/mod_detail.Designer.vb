<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mod_detail
    Inherits MetroFramework.Forms.MetroForm

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mod_picture = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.mod_Versions = New MetroFramework.Controls.MetroComboBox()
        Me.TwitchButton1 = New zTn_Minecraft_Mods_Loader.TwitchButton()
        Me.TwitchBigButton1 = New zTn_Minecraft_Mods_Loader.TwitchBigButton()
        Me.Modname_Lb = New zTn_Minecraft_Mods_Loader.TwitchLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.mod_picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mod_picture
        '
        Me.mod_picture.Location = New System.Drawing.Point(23, 63)
        Me.mod_picture.Name = "mod_picture"
        Me.mod_picture.Size = New System.Drawing.Size(347, 206)
        Me.mod_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mod_picture.TabIndex = 0
        Me.mod_picture.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(26, 294)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ShortcutsEnabled = False
        Me.TextBox1.Size = New System.Drawing.Size(313, 150)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "text"
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(399, 272)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(217, 19)
        Me.MetroLabel1.TabIndex = 5
        Me.MetroLabel1.Text = "Selecione uma Versão Para Instalar:"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(23, 272)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(120, 19)
        Me.MetroLabel2.TabIndex = 6
        Me.MetroLabel2.Text = "Descricão do Mod:"
        '
        'mod_Versions
        '
        Me.mod_Versions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mod_Versions.FontSize = MetroFramework.MetroComboBoxSize.Small
        Me.mod_Versions.FontWeight = MetroFramework.MetroComboBoxWeight.Light
        Me.mod_Versions.FormattingEnabled = True
        Me.mod_Versions.ItemHeight = 19
        Me.mod_Versions.Location = New System.Drawing.Point(399, 304)
        Me.mod_Versions.Name = "mod_Versions"
        Me.mod_Versions.Size = New System.Drawing.Size(207, 25)
        Me.mod_Versions.TabIndex = 7
        Me.mod_Versions.Theme = MetroFramework.MetroThemeStyle.Light
        Me.mod_Versions.UseSelectable = True
        '
        'TwitchButton1
        '
        Me.TwitchButton1.BackColor = System.Drawing.Color.Transparent
        Me.TwitchButton1.Colors = New zTn_Minecraft_Mods_Loader.Bloom(-1) {}
        Me.TwitchButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TwitchButton1.Customization = ""
        Me.TwitchButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.TwitchButton1.Image = Nothing
        Me.TwitchButton1.Location = New System.Drawing.Point(471, 409)
        Me.TwitchButton1.Name = "TwitchButton1"
        Me.TwitchButton1.NoRounding = False
        Me.TwitchButton1.Size = New System.Drawing.Size(105, 31)
        Me.TwitchButton1.TabIndex = 4
        Me.TwitchButton1.Tag = "purple"
        Me.TwitchButton1.Text = "Instalar"
        Me.TwitchButton1.Transparent = True
        Me.TwitchButton1.twNoRounding = False
        '
        'TwitchBigButton1
        '
        Me.TwitchBigButton1.BackColor = System.Drawing.Color.Transparent
        Me.TwitchBigButton1.Colors = New zTn_Minecraft_Mods_Loader.Bloom(-1) {}
        Me.TwitchBigButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TwitchBigButton1.Customization = ""
        Me.TwitchBigButton1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.TwitchBigButton1.Image = Nothing
        Me.TwitchBigButton1.Location = New System.Drawing.Point(582, 409)
        Me.TwitchBigButton1.Name = "TwitchBigButton1"
        Me.TwitchBigButton1.NoRounding = False
        Me.TwitchBigButton1.Size = New System.Drawing.Size(119, 30)
        Me.TwitchBigButton1.TabIndex = 3
        Me.TwitchBigButton1.Tag = "black"
        Me.TwitchBigButton1.Text = "Voltar"
        Me.TwitchBigButton1.Transparent = True
        Me.TwitchBigButton1.twDoesTurnPurple = False
        Me.TwitchBigButton1.twStarred = False
        Me.TwitchBigButton1.twTabPage = Nothing
        Me.TwitchBigButton1.twTabPageNumber = 1
        '
        'Modname_Lb
        '
        Me.Modname_Lb.AutoSize = True
        Me.Modname_Lb.BackColor = System.Drawing.Color.Transparent
        Me.Modname_Lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Modname_Lb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Modname_Lb.Location = New System.Drawing.Point(387, 77)
        Me.Modname_Lb.Name = "Modname_Lb"
        Me.Modname_Lb.Size = New System.Drawing.Size(123, 20)
        Me.Modname_Lb.TabIndex = 1
        Me.Modname_Lb.Text = "ModName.SQL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Unispace", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(452, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Fazendo Download..."
        Me.Label1.Visible = False
        '
        'mod_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 447)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mod_Versions)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.TwitchButton1)
        Me.Controls.Add(Me.TwitchBigButton1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Modname_Lb)
        Me.Controls.Add(Me.mod_picture)
        Me.MaximizeBox = False
        Me.Name = "mod_detail"
        Me.Resizable = False
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Install [MODNAME.SQL]"
        Me.TopMost = True
        CType(Me.mod_picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mod_picture As PictureBox
    Friend WithEvents Modname_Lb As TwitchLabel
    Public WithEvents TextBox1 As TextBox
    Friend WithEvents TwitchBigButton1 As TwitchBigButton
    Friend WithEvents TwitchButton1 As TwitchButton
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents mod_Versions As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label1 As Label
End Class
