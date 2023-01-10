Public Class Personas
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Buscar()
        End If

    End Sub

    Public Sub TipoIdentificacion()
        Dim dt As DataTable = ObjUniversal.Personas(0, "", "", 0, "", "", "", "", 0, "TipoDocumento")
        If dt.Rows.Count > 0 Then
            With Me.ddlTipoIdentificacionAdd
                .Items.Clear()
                .DataSource = dt
                .DataValueField = "TipoDocumentoID"
                .DataTextField = "Nombre"
                .DataBind()
            End With
            ddlTipoIdentificacionAdd.Items.Insert(0, "Seleccionar tipo de identificación")
        Else
            ddlTipoIdentificacionAdd.Items.Clear()
            ddlTipoIdentificacionAdd.Items.Insert(0, "Seleccionar tipo de identificación")
        End If
    End Sub

    Public Sub Buscar()
        Dim dtPersonas As DataTable = ObjUniversal.Personas(0, txtNombreBc.Text, txtApellidoBc.Text, 0, txtIdentificacionBc.Text, "", "", "", ddlActivos.SelectedValue, "Buscar")
        If dtPersonas.Rows.Count > 0 Then
            GVPersonas.DataSource = dtPersonas
            GVPersonas.DataBind()
            Alerta1.Visible = False
        Else
            GVPersonas.DataSource = Nothing
            GVPersonas.DataBind()
            Alerta1.Visible = True
        End If
    End Sub

    Public Sub Crear()
        If Trim(txtNombreAdd.Text) = "" Or Trim(txtapellidoAdd.Text) = "" Or Trim(txtNumIdentificacionAdd.Text) = "" Or ddlTipoIdentificacionAdd.SelectedIndex = 0 Or
             Trim(txtTelefonoAdd.Text) = "" Or Trim(txtNumLicencia.Text) = "" Or dtpFechaVenc.Value = "" Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdPersonas", "FuncionModaladdPersonas();", True)
            Exit Sub
        End If


        Dim mensaje As String = "Se ha creado el registro con éxito"
        If ViewState("Accion") = "Modificar" Then
            mensaje = "Se ha modificado los datos del registro con éxito"
        End If

        Dim dtPersonaAdd As DataTable = ObjUniversal.Personas(ViewState("ID"), txtNombreAdd.Text, txtapellidoAdd.Text,
                                                               ddlTipoIdentificacionAdd.SelectedValue, txtNumIdentificacionAdd.Text,
                                                               txtNumLicencia.Text, dtpFechaVenc.Value, txtTelefonoAdd.Text, 1, ViewState("Accion"))
        If dtPersonaAdd.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify(mensaje, 1)
        Else
            ObjUniversal.SendNotify(dtPersonaAdd.Rows(0).Item("Bandera"), 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdPersonas", "FuncionModaladdPersonas();", True)
        End If

    End Sub

    Private Sub GVPersonas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPersonas.RowCommand
        If e.CommandName = "Editar" Then
            TipoIdentificacion()
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVPersonas.DataKeys(index).Values(0)
            ddlTipoIdentificacionAdd.Enabled = False
            txtNumIdentificacionAdd.Enabled = False

            Dim dtPersonas As DataTable = ObjUniversal.Personas(ViewState("ID"), "", "", 0, "", "", "", "", -1, "Buscar")
            If dtPersonas.Rows.Count > 0 Then
                txtNombreAdd.Text = dtPersonas.Rows(0).Item("Nombre")
                txtapellidoAdd.Text = dtPersonas.Rows(0).Item("Apellido")
                txtNumIdentificacionAdd.Text = dtPersonas.Rows(0).Item("NumeroIdentificacion")
                ddlTipoIdentificacionAdd.SelectedValue = dtPersonas.Rows(0).Item("TipoDocumentoID")
                txtTelefonoAdd.Text = dtPersonas.Rows(0).Item("Telefono")
                txtNumLicencia.Text = dtPersonas.Rows(0).Item("NumeroLicenciaConduccion")
                dtpFechaVenc.Value = dtPersonas.Rows(0).Item("FechaVencimientoLicencia")
            End If

            lbAdd.Text = "Actualizar"
            lblEvento.Text = "Actualizar material"
            ViewState("Accion") = "Modificar"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdPersonas", "FuncionModaladdPersonas();", True)
        End If

        If e.CommandName = "DesActivar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVPersonas.DataKeys(index).Values(0)

            Dim dtPersonas As DataTable = ObjUniversal.Personas(ViewState("ID"), "", "", 0, "", "", "", "", -1, "Buscar")
            Dim mensaje As String = "activado"
            Dim SwActivo As Integer = 1
            If dtPersonas.Rows(0).Item("SwActivo") = True Then
                mensaje = "desactivado"
                SwActivo = 0
            End If

            Dim dtPersonaDes As DataTable = ObjUniversal.Personas(ViewState("ID"), "", "", 0, "", "", "", "", SwActivo, "SwActivo")
            If dtPersonaDes.Rows(0).Item("Bandera") = "1" Then
                Buscar()
                ObjUniversal.SendNotify("La registro se ha " & mensaje & " con éxito", 1)
            Else
                ObjUniversal.SendNotify(dtPersonaDes.Rows(0).Item("Bandera"), 3)
            End If

        End If

    End Sub

    Private Sub lbNew_Click(sender As Object, e As EventArgs) Handles lbNew.Click
        ddlTipoIdentificacionAdd.Enabled = True
        txtNumIdentificacionAdd.Enabled = True
        TipoIdentificacion()
        Limpiar()
        lbAdd.Text = "Crear"
        lblEvento.Text = "Crear persona"
        ViewState("Accion") = "Crear"
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdPersonas", "FuncionModaladdPersonas();", True)
    End Sub

    Private Sub GVPersonas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVPersonas.RowDataBound
        Dim Vencimiento As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lVencimiento"), System.Web.UI.WebControls.Label)
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

            If Vencimiento.Text = 1 Then
                Vencimiento.Text = CStr(GVPersonas.DataKeys(e.Row.RowIndex).Values(2)) + " Días para el vencimiento"
                If GVPersonas.DataKeys(e.Row.RowIndex).Values(2) <= 10 Then
                    Vencimiento.ForeColor = Drawing.Color.DarkOrange
                End If
            Else
                Vencimiento.Text = CStr(GVPersonas.DataKeys(e.Row.RowIndex).Values(2)) + " Días de vencimiento"
                Vencimiento.ForeColor = Drawing.Color.Red
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

    Protected Sub GVPersonas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPersonas.PageIndexChanging
        Me.GVPersonas.PageIndex = e.NewPageIndex()
        Me.GVPersonas.DataBind()
    End Sub
    Protected Sub GVPersonas_PageIndexChanged(sender As Object, e As EventArgs) Handles GVPersonas.PageIndexChanged
        Buscar()
    End Sub

    Public Sub Limpiar()
        txtNombreAdd.Text = ""
        txtapellidoAdd.Text = ""
        txtNumIdentificacionAdd.Text = ""
        txtNumLicencia.Text = ""
        ddlTipoIdentificacionAdd.SelectedValue = "0"
        txtTelefonoAdd.Text = ""
        dtpFechaVenc.Value = ""
    End Sub

    Private Sub GVPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GVPersonas.RowDeleting
        ViewState("ID") = Me.GVPersonas.DataKeys(e.RowIndex).Value

        Dim dtPersonaDes As DataTable = ObjUniversal.Personas(ViewState("ID"), "", "", 0, "", "", "", "", 0, "Eliminar")
        If dtPersonaDes.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify("El registro se ha eliminado con éxito", 1)
        Else
            ObjUniversal.SendNotify(dtPersonaDes.Rows(0).Item("Bandera"), 3)
        End If
    End Sub
End Class