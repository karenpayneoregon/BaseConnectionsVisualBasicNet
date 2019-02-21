Imports BaseConnectionLibrary.Interfaces

Namespace ConnectionClasses
    Public MustInherit Class SqlServerConnection
        Inherits BaseExceptionProperties
        Implements IConnection
        ''' <summary>
        ''' This points to your database server
        ''' </summary>
        Protected DatabaseServer As String = ""
        ''' <summary>
        ''' Gets or sets the name of the database associated with the connection.
        ''' </summary>
        Protected DefaultCatalog As String = ""
        ''' <summary>
        ''' Gets or sets a Boolean value that indicates whether User ID and Password are specified 
        ''' in the connection (when false) or whether the current Windows account credentials are used 
        ''' for authentication (when true).
        ''' </summary>
        Protected IntegratedSecurity As Boolean = True
        Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
            Get
                Return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security={IntegratedSecurity}"
            End Get
        End Property
    End Class
End Namespace