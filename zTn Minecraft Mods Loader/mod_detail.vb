Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports MetroFramework

Public Class mod_detail
    Inherits MetroFramework.Forms.MetroForm
    Dim liArquivos As New List(Of String)


    Private Sub Mod_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Text = "Instalar " + vars.ModName
        Modname_Lb.Text = vars.ModName
        mod_picture.Image = Image.FromFile(vars.pic_Folder + "\modpic.jpg")
        TextBox1.Text = vars.ModDescription

        Try 'Conexao FTP
            Dim request As FtpWebRequest = CType(WebRequest.Create(vars.FTP_URL + vars.ModName + "/versions/"), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = New NetworkCredential(vars.FTP_USERNAME, vars.FTP_PASSWORD)
            request.UsePassive = True
            request.UseBinary = True
            request.KeepAlive = True
            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream
            Dim reader As StreamReader = New StreamReader(responseStream)
            liArquivos = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries).ToList
            For i = 0 To liArquivos.Count - 1
                If liArquivos(i).IndexOf(".") = -1 Then
                    mod_Versions.Items.Add(liArquivos(i))

                End If
            Next
        Catch
            MsgBox("Ocorreu um Erro ao Carregar a Lista de Mods, Tente Novamente.")
            Application.Restart()
        End Try

    End Sub

    Private Sub TwitchButton1_Click(sender As Object, e As EventArgs) Handles TwitchButton1.Click
        If mod_Versions.SelectedIndex = -1 Then
            MetroMessageBox.Show(Me, "Selecione uma Versão antes de Instalar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim getjar = New WebClient()

            Dim myUri As New Uri("http://api.scorpionpremium.com/zTn/mods_ids/" + vars.ModName + "/versions/" + mod_Versions.SelectedItem + "/Optifine.jar")

            AddHandler getjar.DownloadFileCompleted, AddressOf OnDownloadComplete
            getjar.DownloadFileAsync(myUri, vars.Mods_Folder + "\" + vars.ModName + "_" + mod_Versions.SelectedItem + ".jar")
            Label1.Visible = True

        End If
    End Sub
    Private Sub OnDownloadComplete(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            MetroMessageBox.Show(Me, vars.ModName + " Foi Instalado com Sucesso!", "Instalado!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Label1.Visible = False
            mod_Versions.Enabled = False
        Else
            MetroMessageBox.Show(Me, " Ocorreu um erro ao Tentar baixar " + vars.ModName + ",Tente Novamente.", "Erro ao Instalar :(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mod_Versions.Enabled = True
            Label1.Visible = False

        End If
    End Sub

    Private Sub TwitchBigButton1_Click(sender As Object, e As EventArgs) Handles TwitchBigButton1.Click
        Close()
    End Sub
End Class