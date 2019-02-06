Imports KarenBase.Interfaces

Namespace ConnectionClasses
    Public MustInherit Class SqlServerConnection
        Inherits BaseExceptionProperties
        Implements IConnection
        ''' <summary>
        ''' This points to your database server
        ''' </summary>
        Protected DatabaseServer As String = ""
        ''' <summary>
        ''' Name of database containing required tables
        ''' </summary>
        Protected DefaultCatalog As String = ""
        Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
            Get
                Return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security=True"
            End Get
        End Property
    End Class
End Namespace