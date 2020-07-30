Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace ConnectionClasses
    ''' <summary>
    ''' Supported providers
    ''' </summary>
    Public Enum Providers
        ''' <summary>
        ''' OleDb data provider
        ''' </summary>
        OleDb
        ''' <summary>
        ''' SQL-Server data provider
        ''' </summary>
        SQLClient
    End Enum
    ''' <summary>
    ''' Connection validator
    ''' </summary>
    Public Class ConnectionValidator
        Inherits BaseExceptionProperties
        ''' <summary>
        ''' Array of data providers
        ''' </summary>
        Private ConnectionTypes() As Type = {GetType(OleDbConnection), GetType(SqlConnection)}
        ''' <summary>
        ''' Test a connection for either OleDb or SqlClient
        ''' </summary>
        ''' <param name="Provider">Managed provider</param>
        ''' <param name="ConnectionString">Connection string composed using AccessConnection or SqlConnection</param>
        ''' <returns>Success</returns>
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