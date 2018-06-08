Imports System.Configuration
Imports System.IO
Imports System.Linq
Imports Squirrel

Public Module Program

    Private Sub CheckForUpdate()
        Task.Run(Async Function()
                     Using updateMgr = New UpdateManager(If(ConfigurationManager.AppSettings("ReleasesURL"), "C:\TestReleases"))
                         Return Await updateMgr.UpdateApp()
                     End Using
                 End Function)
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

        If (updatePath <> testFolder OrElse System.IO.Directory.Exists(testFolder)) AndAlso
            File.Exists(Path.Combine(Path.GetDirectoryName(Application.StartupPath), "Update.exe")) Then
            Using updateMgr = New UpdateManager(If(ConfigurationManager.AppSettings("ReleasesURL"), "C:\TestReleases"))

                ' ReSharper disable AccessToDisposedClosure
                SquirrelAwareApp.HandleEvents(
                onInitialInstall:=Sub(v) CreateShortcuts(updateMgr),
                onAppUpdate:=Sub(v) CreateShortcuts(updateMgr),
                onAppUninstall:=Sub(v) DeleteShortcuts(updateMgr))
                ' ReSharper enable AccessToDisposedClosure

            End Using

            CheckForUpdate()

        End If


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New ObsWebSocketCropper)

    End Sub
End Module
