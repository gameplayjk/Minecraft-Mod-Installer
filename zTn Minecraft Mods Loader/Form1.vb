Imports System.Environment
Imports System.IO
Imports System.Net

Public Class Form1


    Dim n1_image As String = "https://api.scorpionpremium.com/zTn/best_of_week/1/picid.jpg"

    Private di As New IO.DirectoryInfo(vars.Mods_Folder)
    Private diar1() As IO.FileInfo
    Private dra As IO.FileInfo
    Private i As Integer
    Dim liArquivos As New List(Of String)
    Private Sub Atualizar_Mods_Instalados()
        ListBox1.Items.Clear()
        diar1 = di.GetFiles(".")
        For i = 0 To diar1.Length() - 1
            dra = diar1.GetValue(i)
            If dra.Name.IndexOf(".jar") <> -1 Then
                ListBox1.Items.Add(dra.Name)
            End If
        Next
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AdvantiumCheck1_Click(sender As Object, e As EventArgs) Handles AdvantiumCheck1.Click
        Application.Exit()
    End Sub

    Private Sub TwitchTheme1_Click(sender As Object, e As EventArgs) Handles TwitchTheme1.Click

    End Sub

    Private Sub TwitchBigButton2_Click(sender As Object, e As EventArgs) Handles TwitchBigButton2.Click
        Atualizar_Mods_Instalados()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TwitchBigButton1.Enabled = True
    End Sub

    Private Sub TwitchBigButton1_Click(sender As Object, e As EventArgs) Handles TwitchBigButton1.Click
        If Not ListBox1.SelectedIndex = -1 Then
            My.Computer.FileSystem.DeleteFile(vars.Mods_Folder + "\" + ListBox1.SelectedItem)
        End If
        Atualizar_Mods_Instalados()

    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter


        'PictureBox1.Image = Image.Fro
    End Sub

    Private Sub MetroListView1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False


        Atualizar_Mods_Instalados()

        'Obter Best of The Week
        Dim getpic As WebClient = New WebClient
        'usando o método DownloadFile para efetuar o download
        Try
            getpic.DownloadFile(n1_image, vars.pic_Folder + "\pic1.jpg")

        Catch ex As Exception
            MsgBox(ex.Message & " - " & ex.Source)
        End Try
        'limpa a memoria
        getpic.Dispose()
        PictureBox1.Image = Image.FromFile(vars.pic_Folder + "\pic1.jpg")

        Atualizar_Mods_Instalados()
        Try 'Conexao FTP
            Dim request As FtpWebRequest = CType(WebRequest.Create(vars.FTP_URL), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = New NetworkCredential("ztn@scorpionpremium.com", "coxinha123")
            request.UsePassive = True
            request.UseBinary = True
            request.KeepAlive = True
            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(responseStream)
            liArquivos = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            For i = 0 To liArquivos.Count - 1
                If liArquivos(i).IndexOf(".") = -1 Then
                    ListBox2.Items.Add(liArquivos(i))
                End If
            Next
        Catch
            MsgBox("Ocorreu um Erro ao Carregar a Lista de Mods, Tente Novamente.")
            Application.Restart()
        End Try



        Timer1.Enabled = False
        Directory.CreateDirectory(vars.pic_Folder)
        TwitchGroupBox1.Text = "Mods Instalados em: " + vars.Mods_Folder
        ListBox1.BackColor = Color.FromArgb(44, 44, 44)
        ListBox2.BackColor = Color.FromArgb(44, 44, 44)







    End Sub
    Private Sub MetroListView1_ItemActivate(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
    End Sub

    Private Sub ListBox2_DoubleClick(sender As Object, e As EventArgs) Handles ListBox2.DoubleClick
        Dim getinfo = New WebClient()
        If ListBox2.SelectedIndex <> -1 Then
            vars.ModName = ListBox2.SelectedItem()
            loading.ShowDialog()
            Atualizar_Mods_Instalados()
        End If
    End Sub

    Private Sub AdobeButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TwitchGroupBox1_Enter(sender As Object, e As EventArgs) Handles TwitchGroupBox1.Enter
        Atualizar_Mods_Instalados()
    End Sub
End Class
