Imports System.Environment

Public Class vars
    Public Shared app_version As String = "1.0.0"
    Public Shared appData As String = GetFolderPath(SpecialFolder.ApplicationData)
    Public Shared Mods_Folder As String = appData + "\.minecraft\mods\"
    Public Shared ModName As String

    Public Shared ModDescription As String
    Public Shared ModPicUrl As String
    Public Shared pic_Folder As String = Application.StartupPath + "\pics\"

    Public Shared FTP_USERNAME As String = "ztn@scorpionpremium.com" ' Exemplo: root
    Public Shared FTP_PASSWORD As String = "coxinha123"  ' exemplo: root123
    Public Shared FTP_URL As String = "ftp://ftp.scorpionpremium.com/" '  exemplo ftp://ftp.yoursite.com/


End Class
