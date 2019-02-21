Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace ConnectionClasses

    Public Enum Providers
        OleDb
        SQLClient
    End Enum

    Public Class ConnectionValidator
        Inherits BaseExceptionProperties

        Private ConnectionTypes() As Type = {GetType(OleDbConnection), GetType(SqlConnection)}
        ''' <summary>
        ''' Test a connection for either OleDb or SqlClient
        ''' </summary>
        ''' <param name="Provider">Managed provider</param>
        ''' <param name="ConnectionString">Connection string composed using AccessConnection or SqlConnection</param>
        ''' <returns></returns>
        Public Function OpenTest(Provider As Providers, ConnectionString As String) As Boolean

            mHasException = False

            Try
                Dim cn = CType(Activator.CreateInstance(ConnectionTypes(Provider)), IDbConnection)
                cn.ConnectionString = ConnectionString
                cn.Open()

                Return True

            Catch ex As Exception
                mHasException = True
                mLastException = ex

            End Try

            Return IsSuccessFul

        End Function
    End Class
End Namespace