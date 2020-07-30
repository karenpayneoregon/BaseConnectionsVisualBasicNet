Imports System.Data.OleDb
Imports BaseConnectionLibrary.Interfaces
Imports BaseConnectionLibrary.LanguageExtensions

Namespace ConnectionClasses
    ''' <summary>
    ''' Responsible for creating a Microsoft Access connection string
    ''' </summary>
    Public MustInherit Class AccessConnection
        Inherits BaseExceptionProperties
        Implements IConnection

        ''' <summary>
        ''' Create base OleDbConnectionStringBuilder
        ''' </summary>
        Private ReadOnly _builder As New OleDbConnectionStringBuilder With
            {
                .Provider = "Microsoft.ACE.OLEDB.12.0"
            }
        ''' <summary>
        ''' Database name and path
        ''' </summary>
        Protected DefaultCatalog As String = ""
        ''' <summary>
        ''' Connection string without user name and password
        ''' </summary>
        ''' <returns>Connection string based on <see cref="DefaultCatalog"/> </returns>
        Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
            Get

                If DefaultCatalog.IsNullOrWhiteSpace() Then
                    Throw New Exception("Database name and path not provided.")
                End If

                _builder.DataSource = DefaultCatalog

                Return _builder.ConnectionString

            End Get
        End Property
        ''' <summary>
        ''' Connection string with user name and password. Currently not coded
        ''' </summary>
        ''' <returns>Currently an empty string</returns>
        Public Property ConnectionStringWithPassword() As String
    End Class
End Namespace