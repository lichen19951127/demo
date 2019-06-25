Imports System.Web.Mvc

Namespace Controllers
    Public Class TestController
        Inherits Controller

        ' GET: Test
        Function Index() As ActionResult
            Return View()
        End Function

        Function Login() As ActionResult
            Return View()
        End Function


        Function PostLogin(Name As String, Pwd As String) As ActionResult
            If Name = "admin" And Pwd = "123" Then
                Return Content("<script>location.href='/test/index'</script>")
            Else
                Return Content("<script>location.href='/test/login'</script>")
            End If
        End Function
    End Class
End Namespace