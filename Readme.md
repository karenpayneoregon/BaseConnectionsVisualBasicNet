# Base connection library (VB.NET/C#)

This repository is for base classes used for connecting to both SQL-Server, MS-Access and Oracle databases using several classes for both easily creating connections along with a generalized method to detect runtime exceptions.

> This code may not suit every developer's need and also may seem like overkill to the novice developer. The intent is to have a base class that can be used in any project in one or more Visual Studio solutions. Although the code is VB.NET, the base library can be used with C# also.

## Getting started
- Add the class project [KarenBase](https://github.com/karenpayneoregon/BaseConnectionsVisualBasicNet/tree/master/KarenBase) to your Visual Studio solution, rename the project if so desired.
- Add a reference to KarenBase to your Windows forms project.
- ***Set*** `DatabaseServer` to your server e.g. KARENS-PC or for SQL-Server Express .\SQLEXPRESS
- ***Set*** `DefaultCatalog` to the targeted database in the server above.
- Follow the example in the project SampleSqlConnection for SQL-Server. MS-Access example to follow.

## Test projects
See the following [repository](http://example.com) which focuses more on using this library 
with C# but does have a VB.NET project for SQL-Server.

### Requires
- Microsoft Visual Studio 2015 or higher.

### Tips
- [IsSuccessFul](https://github.com/karenpayneoregon/BaseConnectionsVisualBasicNet/blob/master/KarenBase/Classes/BaseExceptionProperties.vb) from the base exception class allow a type to be returned from a function such as a [List(Of T)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2) or [DataTable](https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netframework-4.7.2) without the need to be concerned with if there had been a runtime exception as after the method calls and before using the return item check IsSuccessFul.

```csharp
Imports SampleSqlConnection.Classes

Public Class Form1
    Private Sub testConnectionButton_Click(sender As Object, e As EventArgs) _
        Handles testConnectionButton.Click

        Dim ops As New DataOperations
        ops.ReadAllCustomersIntoDataTable()

        If ops.IsSuccessFul Then
            ' use the return type
        Else
            ' don't use the return type
        End If
    End Sub
End Class
```
Simple example for Oracle
```csharp
Public Class DataOperations
    Inherits OracleConnection

    Public Sub New()
        DataServer = "MyOracleDB"
        UserId = "myUsername"
        Password = "myPassword"
    End Sub
End Class
```
**New edition**
Started work on a generic connection open test class named ConnectionClasses, more to follow.

```csharp
Imports BaseConnectionLibrary.ConnectionClasses

Public Class Form1
    Private Sub sqlServerExistsButton_Click(sender As Object, e As EventArgs) _
        Handles sqlServerExistsButton.Click

        Dim mockedConnectionString =
                "Data Source=KARENS-PC;" &
                "Initial Catalog=NorthWindAzure3;" &
                "Integrated Security=True"
        Dim ops As New ConnectionValidator
        Dim result = ops.OpenTest(Providers.SQLClient, mockedConnectionString)
        If result Then
            MessageBox.Show("Connection opened successfully")
        Else
            If ops.HasException Then
                MessageBox.Show(
                    $"Failed opening connection{Environment.NewLine}{ops.LastExceptionMessage}")
            End If
        End If
    End Sub
End Class
```

For a C# version of this library see [the following repository](https://github.com/karenpayneoregon/BaseConnectionsCS).

## NuGet package

PM> Install-Package BaseConnectionLibrary -Version 1.0.0
