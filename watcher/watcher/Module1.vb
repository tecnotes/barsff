Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Security.Permissions

Module Module1

    Sub Main()
        Run()

    End Sub
    Private Sub Run()

        Dim args() As String = System.Environment.GetCommandLineArgs()
        ' If a directory is not specified, exit the program.
        ''If args.Length <> 2 Then
        ' Display the proper way to call the program.
        ''Console.WriteLine("Usage: Watcher.exe (directory)")
        ''Return
        ''End If

        Dim watcher As New FileSystemWatcher()
        'watcher.Path = args(1)
        watcher.Path = "c:\" '/mnt/
        watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)


        ' Add event handlers.
        AddHandler watcher.Changed, AddressOf OnChanged
        AddHandler watcher.Created, AddressOf OnChanged
        AddHandler watcher.Deleted, AddressOf OnChanged
        AddHandler watcher.Renamed, AddressOf OnRenamed

        ' Begin watching.
        watcher.EnableRaisingEvents = True
        watcher.IncludeSubdirectories = True

        ' Wait for the user to quit the program.
        Console.WriteLine("Press 'q' to quit the sample.")
        While Chr(Console.Read()) <> "q"c
        End While
    End Sub

    ' Define the event handlers.
    Private Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)
        ' Specify what is done when a file is changed, created, or deleted.
        Console.WriteLine("File: " & e.FullPath & " " & e.ChangeType)
    End Sub

    Private Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)
        ' Specify what is done when a file is renamed.
        Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath)
    End Sub

End Module
