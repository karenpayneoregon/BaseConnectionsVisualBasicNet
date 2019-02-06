Imports SampleSqlConnection.Classes
Public Class Form1
    Private Sub testConnectionButton_Click(sender As Object, e As EventArgs) _
        Handles testConnectionButton.Click

        Dim ops As New DataOperations
        ops.TestSqlConnection()
        If ops.IsSuccessFul Then
            TextBox1.Text = "Successfully connected!!!"
        Else
            TextBox1.Text = ops.LastExceptionMessage
        End If
    End Sub
End Class
