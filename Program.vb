Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports Squirrel

Public Module Program
    ' <summary>
    ' Make a backup of our settings.
    ' Used to persist settings across updates.
    ' </summary>
    Public Sub BackupSettings()
        Dim settingsFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath
        Dim destination = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\last.config"
        File.Copy(settingsFile, destination, True)

    End Sub
    ''' <summary>
    ''' This code was built to handle the version setting upgrade from 1.2.6 to future versions. 
    ''' </summary>
    Private Sub HandleOldVersionSettingUpgrade()
        Dim folderRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                      "ALTTPRandomizer")

        Dim matchingFolders = New DirectoryInfo(folderRoot).GetDirectories().Where(Function(x) x.Name.StartsWith("croptool.exe_Url_"))

        Dim checkSubPath = "1.2.1.0\user.config"

        Dim found = False
        Dim mostRecent As DateTime
        Dim mostRecentPath As String = Nothing

        For Each folder In matchingFolders
            Dim targetPath = Path.Combine(folder.FullName, checkSubPath)
            If File.Exists(targetPath) Then
                Dim modified = File.GetLastWriteTime(targetPath)

                If Not found OrElse modified > mostRecent Then
                    mostRecent = modified
                    mostRecentPath = targetPath
                    found = True
                End If

            End If
        Next

        If found AndAlso mostRecentPath IsNot Nothing AndAlso File.Exists(mostRecentPath) Then
            RestoreSettings(mostRecentPath, False)
        End If

    End Sub
    ' <summary>
    ' Restore our settings backup if any.
    ' Used to persist settings across updates.
    ' </summary>
    Private Sub RestoreSettings(Optional sourceFile As String = Nothing, Optional runOldVersionUpgrade As Boolean = True)
        'Restore settings after application update            
        Dim destFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath
        If sourceFile Is Nothing Then
            sourceFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\last.config"
            If runOldVersionUpgrade AndAlso Not File.Exists(sourceFile) Then
                HandleOldVersionSettingUpgrade()
                Exit Sub
            End If
        End If
        ' Check if we have settings that we need to restore
        If Not File.Exists(sourceFile) Then
            Exit Sub
        End If
        ' Create directory as needed
        Try
            Directory.CreateDirectory(Path.GetDirectoryName(destFile))
        Catch e As Exception
        End Try


        ' Copy our backup file in place 
        Try
            File.Copy(sourceFile, destFile, True)
        Catch e As Exception
        End Try

        ' Delete backup file
        Try
            File.Delete(sourceFile)
        Catch e As Exception
        End Try

        My.Settings.Reload()
    End Sub

    Private Sub CheckForUpdate(updatePath As String)
        Task.Run(Async Sub()
                     Try
                         Using updateMgr = New UpdateManager(updatePath)
                             BackupSettings()
                             Dim ReleaseEntry = Await updateMgr.UpdateApp()
                             GlobalParam.UpdateVersion = $"Update Version: {If(ReleaseEntry?.Version.ToString(), "No update")}"
                         End Using
                     Catch ex As Exception
                         MessageBox.Show($"Error checking for update: ${ex}")
                     End Try
                 End Sub)
    End Sub
    Private Sub CreateShortcuts(mgr As UpdateManager, v As Version)
        Dim thePath = Path.Combine(Path.GetDirectoryName(Application.StartupPath), $"app-{mgr.CurrentlyInstalledVersion()}", "dashboard.exe")
        mgr.CreateShortcutsForExecutable(thePath, ShortcutLocation.Desktop Or ShortcutLocation.StartMenu, False)

        mgr.CreateShortcutForThisExe()
    End Sub
    Private Sub HandleUpdate(mgr As UpdateManager, v As Version)
        CreateShortcuts(mgr, v)
        RestoreSettings()
    End Sub
    Private Sub DeleteShortcuts(mgr As UpdateManager, v As Version)
        Dim thePath = Path.Combine(Path.GetDirectoryName(Application.StartupPath), $"app-{mgr.CurrentlyInstalledVersion()}", "dashboard.exe")
        mgr.RemoveShortcutsForExecutable(thePath, ShortcutLocation.Desktop Or ShortcutLocation.StartMenu)
        mgr.RemoveShortcutForThisExe()
    End Sub

    Public Sub Main()
        If My.Settings.UpgradeRequired = True Then
            My.Settings.Upgrade()
            My.Settings.UpgradeRequired = False
            My.Settings.Save()
        End If

        Dim testFolder = "C:\TestReleases"

        Dim updatePath = If(ConfigurationManager.AppSettings("ReleasesURL"), testFolder)

        If updatePath <> testFolder OrElse System.IO.Directory.Exists(testFolder) Then
            Try
                Using updateMgr = New UpdateManager(updatePath)

                    ' ReSharper disable AccessToDisposedClosure
                    SquirrelAwareApp.HandleEvents(
                    onInitialInstall:=Sub(v) CreateShortcuts(updateMgr, v),
                    onAppUpdate:=Sub(v) HandleUpdate(updateMgr, v),
                    onAppUninstall:=Sub(v) DeleteShortcuts(updateMgr, v))

                    ' ReSharper enable AccessToDisposedClosure

                End Using

                CheckForUpdate(updatePath)
            Catch ex As Exception
                'MessageBox.Show($"Error checking for update: ${ex}")
            End Try


        End If


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New ObsWebSocketCropper)

    End Sub
End Module
