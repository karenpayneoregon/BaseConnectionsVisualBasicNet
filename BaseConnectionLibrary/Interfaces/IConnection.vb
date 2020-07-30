Namespace Interfaces
    ''' <summary>
    ''' Enforce all connection providers have ConnectionString property
    ''' </summary>
    Public Interface IConnection
        ''' <summary>
        ''' Connection string implemented in specific providers
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property ConnectionString() As String
    End Interface
End Namespace