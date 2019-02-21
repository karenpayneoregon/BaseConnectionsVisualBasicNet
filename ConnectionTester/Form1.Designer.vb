<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sqlServerExistsButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'sqlServerExistsButton
        '
        Me.sqlServerExistsButton.Location = New System.Drawing.Point(12, 12)
        Me.sqlServerExistsButton.Name = "sqlServerExistsButton"
        Me.sqlServerExistsButton.Size = New System.Drawing.Size(237, 23)
        Me.sqlServerExistsButton.TabIndex = 0
        Me.sqlServerExistsButton.Text = "SQL-Server exists connect"
        Me.sqlServerExistsButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 105)
        Me.Controls.Add(Me.sqlServerExistsButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Tester"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents sqlServerExistsButton As Button
End Class
