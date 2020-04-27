Imports System.Data.OleDb
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshGrid()
    End Sub
    Private Sub RefreshGrid()

        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "select * from Группа"

        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter(c)
        da.Fill(ds, "Группа")
        Grid1.DataSource = ds
        Grid1.DataMember = "Группа"

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New OleDbConnection
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Access\chto.accdb;Persist Security Info=False;"
        conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim c As New OleDbCommand
        c.Connection = conn
        c.CommandText = "insert into Группа(ФИО, Телефон, email) values('Студент','21212121','почта')"
        c.ExecuteNonQuery()
        RefreshGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim k As Integer
        Dim c As New OleDbCommand
        c.Connection = conn
        k = Grid1.CurrentRow.Cells("ID").Value
        c.CommandText = "detele from Группа where ID = " & k
        c.ExecuteNonQuery()
        RefreshGrid()

    End Sub
End Class
