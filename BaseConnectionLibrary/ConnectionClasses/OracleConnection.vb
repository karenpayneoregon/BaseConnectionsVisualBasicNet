Imports BaseConnectionLibrary.Interfaces

Public MustInherit Class OracleConnection
    Inherits BaseExceptionProperties
    Implements IConnection

    Public Property UseTNS() As Boolean
    Public Property DataServer() As String
    Public Property Host() As String
    Public Property Port() As Integer = 1521
    Public Property ServiceName() As String

    ''' <summary>
    ''' Defaults to true
    ''' </summary>
    ''' <returns></returns>
    Public Property PersistSecurityInfo() As Boolean = True
    ''' <summary>
    ''' Defaults to false
    ''' </summary>
    ''' <returns></returns>
    Public Property Enlist() As Boolean = False
    ''' <summary>
    ''' Defaults to 10
    ''' </summary>
    ''' <returns></returns>
    Public Property StatementCacheSize() As Integer = 10
    Public Property Pooling() As Boolean = True

    ''' <summary>
    ''' Defaults to 15
    ''' </summary>
    ''' <returns></returns>
    Public Property ConnectionTimeout() As Integer = 15

    Public Property UserId() As String
    Public Property Password() As String
    ''' <summary>
    ''' Compose connection string from properties above.
    ''' </summary>
    ''' <returns></returns>
    Private Function ComposeConnectionString() As String

        Dim template = ""

        If UseTNS Then

            template = $"Data Source={DataServer};Persist Security Info={PersistSecurityInfo};" &
                       $"Enlist={Enlist};Pooling={Pooling};Statement Cache Size={StatementCacheSize};"

            If String.IsNullOrWhiteSpace(UserId) Then
                Return template
            End If

            If Not String.IsNullOrWhiteSpace(Password) Then
                template = template & $"User ID={UserId};Password={Password};"
            End If
        Else
            Throw New NotImplementedException()
        End If

        Return template

    End Function

    Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
        Get
            Return ComposeConnectionString()
        End Get
    End Property

End Class


