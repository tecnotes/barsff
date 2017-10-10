Public Class fwatch
    Public Function catcher(ByRef mount As String) As String
        Dim returnmsg As String = Nothing

        Try

        Catch ex As Exception
            returnmsg = ex.Message
        End Try
        Return returnmsg
    End Function

End Class
