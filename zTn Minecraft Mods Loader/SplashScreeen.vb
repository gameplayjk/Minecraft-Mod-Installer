Imports System.IO
Imports System.Net
Imports MetroFramework

Public Class SplashScreeen
    Inherits MetroFramework.Forms.MetroForm
    Private Sub SplashScreeen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim getver = New WebClient()
            Dim cloud_ver = getver.DownloadString("http://api.scorpionpremium.com/zTn/app_version.txt")
            If Not cloud_ver = vars.app_version Then
                MetroMessageBox.Show(Me, "Versao " + cloud_ver + " Esta disponivel em nosso site, faca o download para continuar usando!", "Nova Versao!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch

        End Try

        If Not Directory.Exists(vars.Mods_Folder) Then
            MsgBox("A Pasta Mods nao foi encontrada em sua AppData, verifique se o seu jogo esta instalado Ou se existe a pasta Mods dentro da mesma", MessageBoxIcon.Error)
            Application.Exit()
        End If
        Form1.Show()
        Hide()
    End Sub
End Class