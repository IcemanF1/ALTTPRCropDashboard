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

    ' <summary>
    ' Restore our settings backup if any.
    ' Used to persist settings across updates.
    ' </summary>
    Private Sub RestoreSettings()
        'Restore settings after application update            
        Dim destFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath
        Dim sourceFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\last.config"
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
                             Await updateMgr.UpdateApp()
                         End Using
                     Catch ex As Exception
                         MessageBox.Show($"Error checking for update: ${ex}")
                     End Try
                 End Sub)
    End Sub
    Private Sub CreateShortcuts(mgr As UpdateManager)
        Dim thePath = Path.Combine(Path.GetDirectoryName(Application.StartupPath), $"app-{mgr.CurrentlyInstalledVersion()}", "dashboard.exe")
        mgr.CreateShortcutsForExecutable(thePath, ShortcutLocation.Desktop Or ShortcutLocation.StartMenu, False)

        mgr.CreateShortcutForThisExe()
    End Sub
    Private Sub DeleteShortcuts(mgr As UpdateManager)
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
                    onInitialInstall:=Sub(v) CreateShortcuts(updateMgr),
                    onAppUpdate:=Sub(v) CreateShortcuts(updateMgr),
                    onAppUninstall:=Sub(v) DeleteShortcuts(updateMgr),
                    onFirstRun:=Sub() RestoreSettings())

                    ' ReSharper enable AccessToDisposedClosure

                End Using

                CheckForUpdate(updatePath)
            Catch ex As Exception
                MessageBox.Show($"Error checking for update: ${ex}")
            End Try


        End If


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New ObsWebSocketCropper)

    End Sub
End Module
