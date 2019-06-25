Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) And
            String.IsNullOrWhiteSpace(TextBox2.Text) Then
            Response.Write("不能为空")
        Else
            If TextBox1.Text = "admin" And TextBox2.Text = "123" Then
                Response.Write("success")
            Else
                Response.Write("error")
            End If
        End If
    End Sub
End Class