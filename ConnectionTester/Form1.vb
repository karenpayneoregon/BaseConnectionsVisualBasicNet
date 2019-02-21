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
