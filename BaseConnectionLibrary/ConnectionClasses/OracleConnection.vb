Imports BaseConnectionLibrary.Interfaces
Imports BaseConnectionLibrary.LanguageExtensions
''' <summary>
''' Oracle connection
''' </summary>
Public MustInherit Class OracleConnection
    Inherits BaseExceptionProperties
    Implements IConnection
    ''' <summary>
    ''' Uses TNS
    ''' </summary>
    ''' <returns>True if TNS, false otherwise</returns>
    Public Property UseTNS() As Boolean
    ''' <summary>
    ''' Database server
    ''' </summary>
    ''' <returns>Database provider</returns>
    Public Property DataServer() As String
    ''' <summary>
    ''' Host
    ''' </summary>
    ''' <returns>The database server set</returns>
    Public Property Host() As String
    ''' <summary>
    ''' Port to use to connect to database which defaults to 1521
    ''' </summary>
    ''' <returns></returns>
    Public Property Port() As Integer = 1521
    ''' <summary>
    ''' Service name
    ''' </summary>
    ''' <returns>Name of service</returns>
    Public Property ServiceName() As String

    ''' <summary>
    ''' Use or not use PersistSecurityInfo for connection. Default is true
    ''' </summary>
    ''' <returns>Value for PersistSecurityInfo</returns>
    Public Property PersistSecurityInfo() As Boolean = True
    ''' <summary>
    ''' Defaults to false for Enlist
    ''' </summary>
    ''' <returns>True or false</returns>
    Public Property Enlist() As Boolean = False
    ''' <summary>
    ''' Defaults to 10
    ''' </summary>
    ''' <returns>Cache size for connection</returns>
    Public Property StatementCacheSize() As Integer = 10
    Public Property Pooling() As Boolean = True

    ''' <summary>
    ''' Defaults to 15
    ''' </summary>
    ''' <returns>Timeout for connection</returns>
    Public Property ConnectionTimeout() As Integer = 15
    ''' <summary>
    ''' User Id to make connection
    ''' </summary>
    ''' <returns>User id</returns>
    Public Property UserId() As String
    ''' <summary>
    ''' User password for secure connection
    ''' </summary>
    ''' <returns>Password of user</returns>
    Public Property Password() As String
    ''' <summary>
    ''' Compose connection string from properties above.
    ''' </summary>
    ''' <returns>connection composed from properties set</returns>
    Private Function ComposeConnectionString() As String

        Dim template = ""

        If UseTNS Then

            template = $"Data Source={DataServer};Persist Security Info={PersistSecurityInfo};" &
                       $"Enlist={Enlist};Pooling={Pooling};Statement Cache Size={StatementCacheSize};"

            If UserId.IsNullOrWhiteSpace() Then
                Return template
            End If

            If Not Password.IsNullOrWhiteSpace() Then
                template = template & $"User ID={UserId};Password={Password};"
            End If
        Else
            Throw New NotImplementedException()
        End If

        Return template

    End Function
    ''' <summary>
    ''' Connection string suitable to use to make a connection
    ''' </summary>
    ''' <returns>Oracle connection string</returns>
    Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
        Get
            Return ComposeConnectionString()
        End Get
    End Property

End Class


