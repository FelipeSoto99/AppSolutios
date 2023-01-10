Public Class Login
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub lbIngresar_Click(sender As Object, e As EventArgs) Handles lbIngresar.Click
        If txtUser.Text = "" Or txtPass.Text = "" Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            Exit Sub
        End If
        'Usuario:123456789 -  Clave:123
        Dim dt As DataTable = ObjUniversal.Usuarios(0, txtUser.Text, txtPass.Text, 0, "InicioSesion")
        If dt.Rows(0).Item("Bandera") = "1" Then
            Response.Redirect("~/Form/Menu.aspx", False)
        Else
            ObjUniversal.SendNotify(dt.Rows(0).Item("Bandera"), 3)
            Exit Sub
        End If

    End Sub
End Class