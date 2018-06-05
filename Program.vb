Imports System.Configuration
Imports Squirrel

Public Module Program

    Private Sub HandleEvents()

    End Sub
    Private Sub CheckForUpdate()
        Task.Run(Async Function()
                     Using updateMgr = New UpdateManager(If(ConfigurationManager.AppSettings("TrackerURL"), "C:\TestReleases"))
                         Return Await updateMgr.UpdateApp()
                     End Using
                 End Function)
    End Sub
    Private Sub CreateShortcuts(mgr As UpdateManager)
        mgr.CreateShortcutsForExecutable("dashboard.exe", ShortcutLocation.Desktop Or ShortcutLocation.StartMenu, False)
        mgr.CreateShortcutForThisExe()
    End Sub
    Private Sub DeleteShortcuts(mgr As UpdateManager)
        mgr.RemoveShortcutsForExecutable("dashboard.exe", ShortcutLocation.Desktop Or ShortcutLocation.StartMenu)
        mgr.RemoveShortcutForThisExe()
    End Sub

    Public Sub Main()
        Using updateMgr = New UpdateManager(If(ConfigurationManager.AppSettings("TrackerURL"), "C:\TestReleases"))

            ' ReSharper disable AccessToDisposedClosure
            SquirrelAwareApp.HandleEvents(
            onInitialInstall:=Sub(v) CreateShortcuts(updateMgr),
            onAppUpdate:=Sub(v) CreateShortcuts(updateMgr),
            onAppUninstall:=Sub(v) DeleteShortcuts(updateMgr))
            ' ReSharper enable AccessToDisposedClosure

        End Using

        CheckForUpdate()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New ObsWebSocketCropper)

    End Sub
End Module
