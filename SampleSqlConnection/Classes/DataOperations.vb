Imports System.Data.SqlClient
Imports KarenBase.ConnectionClasses

Namespace Classes

    Public Class DataOperations
        Inherits SqlServerConnection

        Public Sub TestSqlConnection()

            DatabaseServer = "KARENS-PC"
            DefaultCatalog = "NorthWindAzure3"

            Using cn As New SqlConnection(ConnectionString)

                Try
                    cn.Open()
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Sub
    End Class
End Namespace