Imports System.Net

Public Class loading
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        Dim getinfo = New WebClient()
        getinfo.DownloadFile("http://api.scorpionpremium.com/zTn/mods_ids/" + vars.ModName + "/pic.jpg", vars.pic_Folder + "\modpic.jpg")

        vars.ModDescription = getinfo.DownloadString("http://api.scorpionpremium.com/zTn/mods_ids/" + Form1.ListBox2.SelectedItem + "/desc.txt")

        Hide()

        mod_detail.ShowDialog()
        Close()

    End Sub

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class