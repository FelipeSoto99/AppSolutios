Imports Telerik.Web.UI

Public Class Ruta
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            RutasAdd()
            RutaDestinoBuscar()
            RutaOrigenBuscar()
            Buscar()
        End If

    End Sub

    Public Sub Buscar()
        Dim dtRutas As DataTable = ObjUniversal.Rutas(0, RcOrigenBc.SelectedValue, RcDestinoBc.SelectedValue, 0, ddlActivos.SelectedValue, "Buscar")
        If dtRutas.Rows.Count > 0 Then
            GVRutas.DataSource = dtRutas
            GVRutas.DataBind()
            Alerta1.Visible = False
        Else
            GVRutas.DataSource = Nothing
            GVRutas.DataBind()
            Alerta1.Visible = True
        End If
    End Sub

    Public Sub RutasAdd()
        Dim dtRutas As DataTable = ObjUniversal.Rutas(0, 0, 0, 0, 1, "Rutas")
        If dtRutas.Rows.Count > 0 Then
            With Me.RcDestinoAdd
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "MunicipioID"
                .DataTextField = "NombreRuta"
                .DataBind()
            End With
            RcDestinoAdd.Items.Insert(0, New RadComboBoxItem("Seleccione destino", "-1"))

            With Me.RcOrigenAdd
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "MunicipioID"
                .DataTextField = "NombreRuta"
                .DataBind()
            End With
            RcOrigenAdd.Items.Insert(0, New RadComboBoxItem("Seleccione origen", "-1"))
        Else
            RcDestinoAdd.Items.Clear()
            RcOrigenAdd.Items.Clear()
        End If
    End Sub

    Public Sub RutaDestinoBuscar()
        Dim dtRutas As DataTable = ObjUniversal.Rutas(0, 0, 0, 0, 1, "DestinoInsertados")
        If dtRutas.Rows.Count > 0 Then
            With Me.RcDestinoBc
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "MunicipioID"
                .DataTextField = "NombreRuta"
                .DataBind()
            End With
            RcDestinoBc.Items.Insert(0, New RadComboBoxItem("Seleccione destino", "-1"))
        Else
            RcDestinoBc.Items.Clear()
            RcDestinoBc.Items.Insert(0, New RadComboBoxItem("Seleccione destino", "-1"))
        End If
    End Sub

    Public Sub RutaOrigenBuscar()
        Dim dtRutas As DataTable = ObjUniversal.Rutas(0, 0, 0, 0, 1, "OrigenInsertados")
        If dtRutas.Rows.Count > 0 Then
            With Me.RcOrigenBc
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "MunicipioID"
                .DataTextField = "NombreRuta"
                .DataBind()
            End With
            RcOrigenBc.Items.Insert(0, New RadComboBoxItem("Seleccione origen", "-1"))
        Else
            RcOrigenBc.Items.Clear()
            RcOrigenBc.Items.Insert(0, New RadComboBoxItem("Seleccione origen", "-1"))
        End If
    End Sub

    Public Sub Crear()
        If Trim(TxtTrayectoAdd.Text) = "" Or RcDestinoAdd.SelectedValue = -1 Or RcOrigenAdd.SelectedValue = -1 Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
            Exit Sub
        End If

        If RcDestinoAdd.SelectedValue = RcOrigenAdd.SelectedValue Then
            ObjUniversal.SendNotify(" El lugar de origen y destino no puede ser el mismo ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
            Exit Sub
        End If

        If ObjUniversal.ComprobarFormatoNumeros(TxtTrayectoAdd.Text) = False Then
            ObjUniversal.SendNotify(" El formato del trayecto no es valido,el valor debe ser numerico y en caso de decimal debe ser con coma ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
            Exit Sub
        End If

        If Int(TxtTrayectoAdd.Text) <= 0 Then
            ObjUniversal.SendNotify("El trayecto no puede ser igual o menor a 0 km ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdMateriales", "FuncionModaladdMateriales();", True)
            Exit Sub
        End If

        Dim mensaje As String = "Se ha creado el material con éxito"
        If ViewState("Accion") = "Modificar" Then
            mensaje = "Se ha modificado los datos del material con éxito"
        End If
        Dim dtRutasAdd As DataTable = ObjUniversal.Rutas(ViewState("ID"), RcOrigenAdd.SelectedValue, RcDestinoAdd.SelectedValue, Convert.ToDecimal(Replace(TxtTrayectoAdd.Text, ".", ",")), 1, ViewState("Accion"))
        If dtRutasAdd.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify(mensaje, 1)
        Else
            ObjUniversal.SendNotify(dtRutasAdd.Rows(0).Item("Bandera"), 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
        End If

    End Sub

    Private Sub GVRutas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVRutas.RowCommand
        If e.CommandName = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVRutas.DataKeys(index).Values(0)

            Dim dtRutas As DataTable = ObjUniversal.Rutas(ViewState("ID"), -1, -1, -1, -1, "Buscar")
            If dtRutas.Rows.Count > 0 Then
                RcDestinoAdd.SelectedValue = dtRutas.Rows(0).Item("LugarDestino")
                RcOrigenAdd.SelectedValue = dtRutas.Rows(0).Item("LugarOrigen")
                TxtTrayectoAdd.Text = dtRutas.Rows(0).Item("Trayecto")
            End If

            lbAdd.Text = "Actualizar"
            lblEvento.Text = "Actualizar ruta"
            ViewState("Accion") = "Modificar"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
        End If

        If e.CommandName = "DesActivar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVRutas.DataKeys(index).Values(0)

            Dim dtRutas As DataTable = ObjUniversal.Rutas(ViewState("ID"), -1, -1, -1, -1, "Buscar")
            Dim mensaje As String = "activado"
            Dim SwActivo As Integer = 1
            If dtRutas.Rows(0).Item("SwActivo") = True Then
                mensaje = "desactivado"
                SwActivo = 0
            End If

            Dim dtRutaDes As DataTable = ObjUniversal.Rutas(ViewState("ID"), 0, 0, 0, SwActivo, "SwActivo")
            If dtRutaDes.Rows(0).Item("Bandera") = "1" Then
                Buscar()
                ObjUniversal.SendNotify("El registro se ha " & mensaje & " con éxito", 1)
            Else
                ObjUniversal.SendNotify(dtRutaDes.Rows(0).Item("Bandera"), 3)
                ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
            End If

        End If

    End Sub

    Private Sub lbNew_Click(sender As Object, e As EventArgs) Handles lbNew.Click
        RutasAdd()
        TxtTrayectoAdd.Text = ""
        lbAdd.Text = "Crear"
        lblEvento.Text = "Crear ruta"
        ViewState("Accion") = "Crear"
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdRutas", "FuncionModaladdRutas();", True)
    End Sub

    Private Sub GVRutas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVRutas.RowDataBound
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

    Private Sub GVRutas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GVRutas.RowDeleting
        ViewState("ID") = Me.GVRutas.DataKeys(e.RowIndex).Value

        Dim dtRutaDes As DataTable = ObjUniversal.Rutas(ViewState("ID"), 0, 0, 0, 0, "Eliminar")
        If dtRutaDes.Rows(0).Item("Bandera") = "1" Then
            RutaDestinoBuscar()
            RutaOrigenBuscar()
            Buscar()
            ObjUniversal.SendNotify("El registro se ha eliminado con éxito", 1)
        Else
            ObjUniversal.SendNotify(dtRutaDes.Rows(0).Item("Bandera"), 3)
        End If
    End Sub

    Private Sub lbAdd_Click(sender As Object, e As EventArgs) Handles lbAdd.Click
        Crear()
    End Sub
End Class