Imports System.Data.OleDb
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshGrid()
    End Sub
    Private Sub RefreshGrid()

        'Dim c As New OleDbCommand
        ' c.Connection = conn
        ' c.CommandText = "select * from Группа"

        ' Dim ds As New DataSet
        ' Dim da As New OleDbDataAdapter(c)
        ' da.Fill(ds, "Группа")
        ' Grid1.DataSource = ds
        'Grid1.DataMember = "Группа"
        FillGrid(Grid1, "select * from Группа", "Группа")

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Access\chto.accdb;Persist Security Info=False;"
        conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim s1, s2, s3 As String
        Dim r As DialogResult
        Form2.ShowDialog()
        s1 = Form2.TextBox1.Text
        s2 = Form2.TextBox2.Text
        s3 = Form2.TextBox3.Text
        r = Form2.DialogResult
        Form2.Close()

        If r <> DialogResult.OK Then
            Exit Sub
        End If

        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "insert into Группа(ФИО, Телефон, email) values('" & s1 & "','" & s2 & "','" & s3 & "')"
        c.ExecuteNonQuery()

        RefreshGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim k As Integer
        Dim c As New OleDbCommand
        c.Connection = conn
        k = Grid1.CurrentRow.Cells("ID").Value
        c.CommandText = "delete from Группа where ID = " & k
        c.ExecuteNonQuery()
        RefreshGrid()

    End Sub

    Private Sub Grid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellContentClick
        RefreshGrid2()
    End Sub
    Private Sub RefreshGrid2()
        Dim k As Integer
        k = Grid1.CurrentRow.Cells("ID").Value
        FillGrid(Grid2, "select * from Событие where ID_Группа = " & k, "Группа")
    End Sub
End Class
