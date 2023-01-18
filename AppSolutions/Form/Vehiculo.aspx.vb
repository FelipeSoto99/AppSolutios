Public Class Vehiculo
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Buscar()
    End Sub

    Public Sub Buscar()
        Dim dtRVehiculo As DataTable = ObjUniversal.Vehiculo(0, txtPlacaBc.Text, txtCapacidadBc.Text, "", "", "", "", "", "", ddlActivos.SelectedValue, "Buscar")
        If dtRVehiculo.Rows.Count > 0 Then
            GVVehiculo.DataSource = dtRVehiculo
            GVVehiculo.DataBind()
            Alerta1.Visible = False
        Else
            GVVehiculo.DataSource = Nothing
            GVVehiculo.DataBind()
            Alerta1.Visible = True
        End If
    End Sub

    Public Sub Crear()
        Dim FechaVencSoat As String = ""
        Dim FechaVencTecno As String = ""
        Dim FechaVencRegistroCarga As String = ""

        If Trim(txtPlacaAdd.Text) = "" Or Trim(txtCapacidadAdd.Text) = "" Or Trim(TxtSoatAdd.Text) = "" Or Trim(TxtTecnoAdd.Text) = "" Or
            dtpFechaVencSoat.Value = "" Or dtpFechaVencTecno.Value = "" Or dtpFechaVencRegistroCarga.Value = "" Or Trim(txtRegistroCargaAdd.Text) = "" Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdVehiculos", "FuncionModaladdVehiculos();", True)
            Exit Sub
        End If

        If CInt(txtCapacidadAdd.Text > 1000) Then
            ObjUniversal.SendNotify("La capacidad maxima de carga de los vehículos no puede exceder los 1000 Kg", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdVehiculos", "FuncionModaladdVehiculos();", True)
            Exit Sub
        End If


        Dim mensaje As String = "Se ha creado el registro con éxito"
        If ViewState("Accion") = "Modificar" Then
            mensaje = "Se ha modificado los datos del registro con éxito"
        End If

        If Len(Trim(dtpFechaVencSoat.Value)) > 8 Then
            FechaVencSoat = Mid(dtpFechaVencSoat.Value, 7, 4) + "-" + Mid(dtpFechaVencSoat.Value, 4, 2) + "-" + Mid(dtpFechaVencSoat.Value, 1, 2)
        End If

        If Len(Trim(dtpFechaVencTecno.Value)) > 8 Then
            FechaVencTecno = Mid(dtpFechaVencTecno.Value, 7, 4) + "-" + Mid(dtpFechaVencTecno.Value, 4, 2) + "-" + Mid(dtpFechaVencTecno.Value, 1, 2)
        End If

        If Len(Trim(dtpFechaVencRegistroCarga.Value)) > 8 Then
            FechaVencRegistroCarga = Mid(dtpFechaVencRegistroCarga.Value, 7, 4) + "-" + Mid(dtpFechaVencRegistroCarga.Value, 4, 2) + "-" + Mid(dtpFechaVencRegistroCarga.Value, 1, 2)
        End If

        Dim dtRutasAdd As DataTable = ObjUniversal.Vehiculo(ViewState("ID"), txtPlacaAdd.Text, txtCapacidadAdd.Text, TxtSoatAdd.Text,
                                                            FechaVencSoat, TxtTecnoAdd.Text, FechaVencTecno, txtRegistroCargaAdd.Text, FechaVencRegistroCarga, 1, ViewState("Accion"))

        If dtRutasAdd.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify(mensaje, 1)
        Else
            ObjUniversal.SendNotify(dtRutasAdd.Rows(0).Item("Bandera"), 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdVehiculos", "FuncionModaladdVehiculos();", True)
        End If

    End Sub

    Private Sub GVVehiculo_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVVehiculo.RowCommand
        If e.CommandName = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVVehiculo.DataKeys(index).Values(0)
            limpiar()
            Dim dtVehiculo As DataTable = ObjUniversal.Vehiculo(ViewState("ID"), "", "", "", "", "", "", "", "", -1, "Buscar")
            If dtVehiculo.Rows.Count > 0 Then
                txtPlacaAdd.Text = dtVehiculo.Rows(0).Item("Placa")
                txtCapacidadAdd.Text = dtVehiculo.Rows(0).Item("CapacidadCarga")
                TxtSoatAdd.Text = dtVehiculo.Rows(0).Item("Soat")
                TxtTecnoAdd.Text = dtVehiculo.Rows(0).Item("Tecnomecanica")
                dtpFechaVencSoat.Value = dtVehiculo.Rows(0).Item("FechaVencSoat")
                dtpFechaVencTecno.Value = dtVehiculo.Rows(0).Item("FechaVenTecno")
                txtRegistroCargaAdd.Text = dtVehiculo.Rows(0).Item("RegistroTransporteCarga")
                dtpFechaVencRegistroCarga.Value = dtVehiculo.Rows(0).Item("FechaVenTransporteCarga")
            End If

            lbAdd.Text = "Actualizar"
            lblEvento.Text = "Actualizar vehículo"
            ViewState("Accion") = "Modificar"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdVehiculos", "FuncionModaladdVehiculos();", True)
        End If

        If e.CommandName = "DesActivar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GVVehiculo.DataKeys(index).Values(0)

            Dim dtRutas As DataTable = ObjUniversal.Vehiculo(ViewState("ID"), "", "", "", "", "", "", "", "", -1, "Buscar")
            Dim mensaje As String = "activado"
            Dim SwActivo As Integer = 1
            If dtRutas.Rows(0).Item("SwActivo") = True Then
                mensaje = "desactivado"
                SwActivo = 0
            End If

            Dim dtVehiculoDes As DataTable = ObjUniversal.Vehiculo(ViewState("ID"), "", "", "", "", "", "", "", "", SwActivo, "SwActivo")
            If dtVehiculoDes.Rows(0).Item("Bandera") = "1" Then
                Buscar()
                ObjUniversal.SendNotify("El registro se ha " & mensaje & " con éxito", 1)
            Else
                ObjUniversal.SendNotify(dtVehiculoDes.Rows(0).Item("Bandera"), 3)
            End If

        End If

    End Sub

    Private Sub lbNew_Click(sender As Object, e As EventArgs) Handles lbNew.Click
        lbAdd.Text = "Crear"
        lblEvento.Text = "Crear vehículo"
        ViewState("Accion") = "Crear"
        limpiar()
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModaladdVehiculos", "FuncionModaladdVehiculos();", True)
    End Sub
    Private Sub GVVehiculo_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GVVehiculo.RowDataBound
        Dim Estado As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lEstado"), System.Web.UI.WebControls.Label)
        Dim VencimientoRegistro As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lVencimientoRegistro"), System.Web.UI.WebControls.Label)
        Dim VencimientoTecno As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lVencimientoTecno"), System.Web.UI.WebControls.Label)
        Dim VencimientoSoat As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("lVencimientoSoat"), System.Web.UI.WebControls.Label)
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

            If VencimientoTecno.Text = 1 Then
                VencimientoTecno.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(2)) + " Días para el vencimiento "
                If GVVehiculo.DataKeys(e.Row.RowIndex).Values(2) <= 10 Then
                    VencimientoTecno.ForeColor = Drawing.Color.DarkOrange
                End If
            Else
                VencimientoTecno.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(2)) + " Días de vencimiento"
                VencimientoTecno.ForeColor = Drawing.Color.Red
            End If

            If VencimientoRegistro.Text = 1 Then
                VencimientoRegistro.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(4)) + " Días para el vencimiento "
                If GVVehiculo.DataKeys(e.Row.RowIndex).Values(4) <= 10 Then
                    VencimientoRegistro.ForeColor = Drawing.Color.DarkOrange
                End If
            Else
                VencimientoRegistro.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(4)) + " Días de vencimiento"
                VencimientoRegistro.ForeColor = Drawing.Color.Red
            End If

            If VencimientoSoat.Text = 1 Then
                VencimientoSoat.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(3)) + " Días para el vencimiento "
                If GVVehiculo.DataKeys(e.Row.RowIndex).Values(3) <= 10 Then
                    VencimientoSoat.ForeColor = Drawing.Color.DarkOrange
                End If
            Else
                VencimientoSoat.Text = CStr(GVVehiculo.DataKeys(e.Row.RowIndex).Values(3)) + " Días de vencimiento"
                VencimientoSoat.ForeColor = Drawing.Color.Red
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

    Public Sub limpiar()
        txtPlacaAdd.Text = ""
        TxtSoatAdd.Text = ""
        TxtTecnoAdd.Text = ""
        txtCapacidadAdd.Text = ""
        dtpFechaVencSoat.Value = ""
        dtpFechaVencTecno.Value = ""
        dtpFechaVencRegistroCarga.Value = ""
        txtRegistroCargaAdd.Text = ""
    End Sub

    Protected Sub GVVehiculo_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVVehiculo.PageIndexChanging
        Me.GVVehiculo.PageIndex = e.NewPageIndex()
        Me.GVVehiculo.DataBind()
    End Sub
    Protected Sub GVVehiculo_PageIndexChanged(sender As Object, e As EventArgs) Handles GVVehiculo.PageIndexChanged
        Buscar()
    End Sub

    Private Sub GVVehiculo_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GVVehiculo.RowDeleting
        ViewState("ID") = Me.GVVehiculo.DataKeys(e.RowIndex).Value
        Dim dtVehiculoDes As DataTable = ObjUniversal.Vehiculo(ViewState("ID"), "", "", "", "", "", "", "", "", 0, "Eliminar")
        If dtVehiculoDes.Rows(0).Item("Bandera") = "1" Then
            Buscar()
            ObjUniversal.SendNotify("El registro se ha eliminado con éxito", 1)
        Else
            ObjUniversal.SendNotify(dtVehiculoDes.Rows(0).Item("Bandera"), 3)
        End If
    End Sub
End Class