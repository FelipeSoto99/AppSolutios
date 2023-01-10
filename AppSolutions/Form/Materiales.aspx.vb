Public Class Materiales
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Buscar()
        End If
    End Sub

    Public Sub Buscar()
        Dim dtMateriales As DataTable = ObjUniversal.Materiales(0, txtDescripBc.Text, txtPresentBc.Text, 0, ddlActivos.SelectedValue, "Buscar")
        If dtMateriales.Rows.Count > 0 Then
            GVMateriales.DataSource = dtMateriales
            GVMateriales.DataBind()
            Alerta1.Visible = False
        Else
            GVMateriales.DataSource = Nothing
            GVMateriales.DataBind()
            Alerta1.Visible = True
        End If
    End Sub

    Public Sub Crear()
        If Trim(txtDescripcionAdd.Text) = "" Or Trim(txtPresentacionAdd.Text) = "" Or Trim(txtPesoAdd.Text) = "" Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
            Exit Sub
        End If

        If ObjUniversal.ComprobarFormatoNumeros(txtPesoAdd.Text) = False Then
            ObjUniversal.SendNotify("El formato del peso no es valido, el valor debe ser numerico y en caso de decimal debe ser con coma ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
            Exit Sub
        End If

        If Int(txtPesoAdd.Text) <= 0 Then
            ObjUniversal.SendNotify("El peso del material no puede ser igual o menor a 0 kg", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
            Exit Sub
        End If

        Dim mensaje As String = "Se ha creado el material con éxito"
        If ViewState("Accion") = "Modificar" Then
            mensaje = "Se ha modificado los datos del material con éxito"
        End If


        Dim dtMaterialAdd As DataTable = ObjUniversal.Materiales(ViewState("ID"), txtDescripcionAdd.Text, txtPresentacionAdd.Text, Convert.ToDecimal(Replace(txtPesoAdd.Text, ".", ",")), 1, ViewState("Accion"))
        If dtMaterialAdd.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify(mensaje, 1)
        Else
            ObjUniversal.SendNotify(dtMaterialAdd.Rows(0).Item("Bandera"), 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
        End If

    End Sub

    Private Sub GVMateriales_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVMateriales.RowCommand
        If e.CommandName = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVMateriales.DataKeys(index).Values(0)
            Limpiar()
            Dim dtMaterial As DataTable = ObjUniversal.Materiales(ViewState("ID"), "", "", 0, -1, "Buscar")
            If dtMaterial.Rows.Count > 0 Then
                txtDescripcionAdd.Text = dtMaterial.Rows(0).Item("Descripcion")
                txtPesoAdd.Text = dtMaterial.Rows(0).Item("peso")
                txtPresentacionAdd.Text = dtMaterial.Rows(0).Item("Presentacion")
            End If

            lbAdd.Text = "Actualizar"
            lblEvento.Text = "Actualizar material"
            ViewState("Accion") = "Modificar"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
        End If

        If e.CommandName = "DesActivar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVMateriales.DataKeys(index).Values(0)

            Dim dtMaterial As DataTable = ObjUniversal.Materiales(ViewState("ID"), "", "", 0, -1, "Buscar")
            Dim mensaje As String = "activado"
            Dim SwActivo As Integer = 1
            If dtMaterial.Rows(0).Item("SwActivo") = True Then
                mensaje = "desactivado"
                SwActivo = 0
            End If

            Dim dtMaterialDes As DataTable = ObjUniversal.Materiales(ViewState("ID"), "", "", 0, SwActivo, "SwActivo")
            If dtMaterialDes.Rows(0).Item("Bandera") = "1" Then
                Buscar()
                ObjUniversal.SendNotify("El registro se ha " & mensaje & " con éxito", 1)
            Else
                ObjUniversal.SendNotify(dtMaterialDes.Rows(0).Item("Bandera"), 3)
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
            End If

        End If

    End Sub

    Private Sub lbNew_Click(sender As Object, e As EventArgs) Handles lbNew.Click
        lbAdd.Text = "Crear"
        lblEvento.Text = "Crear material"
        ViewState("Accion") = "Crear"
        Limpiar()
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
    End Sub

    Private Sub GVMateriales_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVMateriales.RowDataBound
        Dim Estado As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lEstado"), System.Web.UI.WebControls.Label)
        Dim btnDesactivar As System.Web.UI.WebControls.LinkButton = DirectCast(e.Row.FindControl("LbDesactivar"), System.Web.UI.WebControls.LinkButton)
        Try
            If Estado.Text = True Then
                Estado.CssClass = "fa fa-check fa-1x" : Estado.ForeColor = Drawing.Color.Green
                btnDesactivar.ForeColor = Drawing.Color.Green
                btnDesactivar.CssClass = "fa fa-toggle-on  fa-lg"
            Else
                Estado.CssClass = "fa fa-times fa-1x" : Estado.ForeColor = Drawing.Color.Red
                btnDesactivar.ForeColor = Drawing.Color.Red
                btnDesactivar.CssClass = "fa fa-toggle-off fa-lg"
            End If

            Estado.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lbBuscar_Click(sender As Object, e As EventArgs) Handles lbBuscar.Click
        Buscar()
    End Sub

    Private Sub lbAdd_Click(sender As Object, e As EventArgs) Handles lbAdd.Click
        Crear()
    End Sub

    Protected Sub GVMateriales_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVMateriales.PageIndexChanging
        Me.GVMateriales.PageIndex = e.NewPageIndex()
        Me.GVMateriales.DataBind()
    End Sub
    Protected Sub GVMateriales_PageIndexChanged(sender As Object, e As EventArgs) Handles GVMateriales.PageIndexChanged
        Buscar()
    End Sub

    Private Sub GVMateriales_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GVMateriales.RowDeleting
        ViewState("ID") = Me.GVMateriales.DataKeys(e.RowIndex).Value
        Dim dtMaterialDes As DataTable = ObjUniversal.Materiales(ViewState("ID"), "", "", 0, 0, "Eliminar")
        If dtMaterialDes.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify("El material se ha eliminado con éxito", 1)
        Else
            ObjUniversal.SendNotify(dtMaterialDes.Rows(0).Item("Bandera"), 3)
        End If
    End Sub

    Public Sub Limpiar()
        txtDescripcionAdd.Text = ""
        txtPesoAdd.Text = ""
        txtPresentacionAdd.Text = ""
    End Sub

End Class