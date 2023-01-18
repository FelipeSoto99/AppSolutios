Imports Telerik.Web.UI

Public Class AsignarRutaaspx
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PersonaBuscar()
            RutaBuscar()
            VehiculoBuscar()
            EstadoBuscar()
            Buscar()
        End If
    End Sub

    Public Sub MaterialesAdd()
        Dim dtMateriales As DataTable = ObjUniversal.RutaMateriales(0, 0, 0, 0, "", "Materiales")
        If dtMateriales.Rows.Count > 0 Then
            With Me.RcMaterialAdd
                .Items.Clear()
                .DataSource = dtMateriales
                .DataValueField = "MaterialID"
                .DataTextField = "Descripcion"
                .DataBind()
            End With
            RcMaterialAdd.Items.Insert(0, New RadComboBoxItem("Seleccione material", "-1"))
        Else
            RcMaterialAdd.Items.Clear()
            RcMaterialAdd.Items.Insert(0, New RadComboBoxItem("Seleccione material", "-1"))
        End If
    End Sub

    Public Sub RutaBuscar()
        Dim dtRutas As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, 0, 0, "", "", "RutasBuscar")
        If dtRutas.Rows.Count > 0 Then
            With Me.RcRutaBC
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "RutaID"
                .DataTextField = "Ruta"
                .DataBind()
            End With
            RcRutaBC.Items.Insert(0, New RadComboBoxItem("Seleccione ruta", "-1"))
        Else
            RcRutaBC.Items.Clear()
            RcRutaBC.Items.Insert(0, New RadComboBoxItem("Seleccione ruta", "-1"))
        End If
    End Sub

    Public Sub PersonaBuscar()
        Dim dtPersona As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, 0, 0, "", "", "PersonaBuscar")
        If dtPersona.Rows.Count > 0 Then
            With Me.RcPersonaBC
                .Items.Clear()
                .DataSource = dtPersona
                .DataValueField = "PersonaID"
                .DataTextField = "NombreCompleto"
                .DataBind()
            End With
            RcPersonaBC.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        Else
            RcPersonaBC.Items.Clear()
            RcPersonaBC.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        End If
    End Sub

    Public Sub VehiculoBuscar()
        Dim dtPersona As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, 0, 0, "", "", "VehiculoBuscar")
        If dtPersona.Rows.Count > 0 Then
            With Me.RcVehiculoBC
                .Items.Clear()
                .DataSource = dtPersona
                .DataValueField = "VehiculoID"
                .DataTextField = "Placa"
                .DataBind()
            End With
            RcVehiculoBC.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        Else
            RcVehiculoBC.Items.Clear()
            RcVehiculoBC.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        End If
    End Sub

    Public Sub EstadoBuscar()
        Dim dtEstado As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, 0, 0, "", "", "EstadoBuscar")
        If dtEstado.Rows.Count > 0 Then
            With Me.RcEstadoBc
                .Items.Clear()
                .DataSource = dtEstado
                .DataValueField = "EstadoID"
                .DataTextField = "Descripcion"
                .DataBind()
            End With
            RcEstadoBc.Items.Insert(0, New RadComboBoxItem("Seleccione estado", "-1"))
        Else
            RcEstadoBc.Items.Clear()
            RcEstadoBc.Items.Insert(0, New RadComboBoxItem("Seleccione estado", "-1"))
        End If
    End Sub

    Public Sub RutaAdd()
        Dim dtRutas As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, 0, 0, "", "", "Rutas")
        If dtRutas.Rows.Count > 0 Then
            With Me.RcRutaAdd
                .Items.Clear()
                .DataSource = dtRutas
                .DataValueField = "RutaID"
                .DataTextField = "Ruta"
                .DataBind()
            End With
            RcRutaAdd.Items.Insert(0, New RadComboBoxItem("Seleccione ruta", "-1"))
        Else
            RcRutaAdd.Items.Clear()
            RcRutaAdd.Items.Insert(0, New RadComboBoxItem("Seleccione ruta", "-1"))
        End If
    End Sub

    Public Sub PersonaAdd(ID As Integer)
        Dim dtpersonas As DataTable = ObjUniversal.AsignacionRutas(0, 0, 0, ID, 0, "", "", "Personas")
        If dtpersonas.Rows.Count > 0 Then
            With Me.RcPersonaAdd
                .Items.Clear()
                .DataSource = dtpersonas
                .DataValueField = "PersonaID"
                .DataTextField = "NombreCompleto"
                .DataBind()
            End With
            RcPersonaAdd.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        Else
            RcPersonaAdd.Items.Clear()
            RcPersonaAdd.Items.Insert(0, New RadComboBoxItem("Seleccione persona", "-1"))
        End If
    End Sub

    Public Sub VehiculoAdd(ID As Integer)
        Dim dtVehiculo As DataTable = ObjUniversal.AsignacionRutas(0, 0, ID, 0, 0, "", "", "Vehiculos")
        If dtVehiculo.Rows.Count > 0 Then
            With Me.RcVehiculoAdd
                .Items.Clear()
                .DataSource = dtVehiculo
                .DataValueField = "VehiculoID"
                .DataTextField = "Vehiculo"
                .DataBind()
            End With
            RcVehiculoAdd.Items.Insert(0, New RadComboBoxItem("Seleccione vehículo", "-1"))
        Else
            RcVehiculoAdd.Items.Clear()
            RcVehiculoAdd.Items.Insert(0, New RadComboBoxItem("Seleccione vehículo", "-1"))
        End If
    End Sub

    Public Sub Buscar()
        Dim dtAsignarRutas As DataTable = ObjUniversal.AsignacionRutas(0, RcRutaBC.SelectedValue, RcVehiculoBC.SelectedValue, RcPersonaBC.SelectedValue, RcEstadoBc.SelectedValue, "", "", "Buscar")
        If dtAsignarRutas.Rows.Count > 0 Then
            GvAsignarRuta.DataSource = dtAsignarRutas
            GvAsignarRuta.DataBind()
            Alerta1.Visible = False
        Else
            GvAsignarRuta.DataSource = Nothing
            GvAsignarRuta.DataBind()
            Alerta1.Visible = True

        End If
    End Sub

    Public Sub Crear()
        If RcRutaAdd.SelectedValue = -1 Or RcVehiculoAdd.SelectedValue = -1 Or RcPersonaAdd.SelectedValue = -1 Then
            ObjUniversal.SendNotify("Todos los campos son obligatorios", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarRuta", "FuncionModalaAsignarRuta();", True)
            Exit Sub
        End If

        Dim mensaje As String = "Se ha asignado la ruta con éxito"
        If ViewState("Accion") = "Modificar" Then
            mensaje = "Se ha modificado la ruta con éxito"
        End If

        Dim dtAsignarRutaAdd As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), RcRutaAdd.SelectedValue, RcVehiculoAdd.SelectedValue, RcPersonaAdd.SelectedValue, 4, "", "", ViewState("Accion"))
        If dtAsignarRutaAdd.Rows.Count > 0 Then
            Buscar()
            ObjUniversal.SendNotify(mensaje, 1)
        Else
            ObjUniversal.SendNotify("No se ha podido asignar la ruta ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarRuta", "FuncionModalaAsignarRuta();", True)
        End If

    End Sub

    Private Sub GvAsignarRuta_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvAsignarRuta.RowCommand
        If e.CommandName = "Editar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GvAsignarRuta.DataKeys(index).Values(0)
            Dim estado As Integer = GvAsignarRuta.DataKeys(index).Values(1)
            If estado <> 4 Then
                Habilitar(False)
            Else
                Habilitar(True)
            End If


            Dim dtAsignarRuta As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), -1, -1, -1, -1, "", "", "Buscar")
            If dtAsignarRuta.Rows.Count > 0 Then
                RutaAdd()
                VehiculoAdd(dtAsignarRuta.Rows(0).Item("VehiculoID"))
                PersonaAdd(dtAsignarRuta.Rows(0).Item("PersonaID"))

                RcRutaAdd.SelectedValue = dtAsignarRuta.Rows(0).Item("RutaID")
                RcPersonaAdd.SelectedValue = dtAsignarRuta.Rows(0).Item("PersonaID")
                RcVehiculoAdd.SelectedValue = dtAsignarRuta.Rows(0).Item("VehiculoID")
            End If

            lbAdd.Text = "Actualizar"
            lblEvento.Text = "Actualizar la asiganción de ruta"
            ViewState("Accion") = "Modificar"
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarRuta", "FuncionModalaAsignarRuta();", True)
        End If

        If e.CommandName = "Materiales" Then
            lbVehiculo.Text = ""
            lbCapacidad.Text = ""
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GvAsignarRuta.DataKeys(index).Values(0)

            Dim estado As Integer = GvAsignarRuta.DataKeys(index).Values(1)
            If estado <> 4 Then
                HabilitarMaterial(False)
            Else
                HabilitarMaterial(True)
            End If

            BuscarMateriales()
            MaterialesAdd()

            Dim dtAsignarRutas As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), -1, -1, -1, -1, "", "", "Buscar")
            If dtAsignarRutas.Rows.Count > 0 Then
                lbVehiculo.Text = dtAsignarRutas.Rows(0).Item("Placa")
                lbCapacidad.Text = dtAsignarRutas.Rows(0).Item("CapacidadCarga") & " Kg"
                lbRuta.Text = dtAsignarRutas.Rows(0).Item("Ruta")
                LbTrayecto.Text = dtAsignarRutas.Rows(0).Item("TrayectoKm") & " Km"
                ViewState("Trayecto") = dtAsignarRutas.Rows(0).Item("TrayectoKm")
            End If

            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
        End If


        If e.CommandName = "Entregado" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("ID") = Me.GvAsignarRuta.DataKeys(index).Values(0)
            Dim dtAsignarRutas As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), 0, 0, 0, 2, "", "", "CambiarEstado")
            ObjUniversal.SendNotify(" Se ha cambiado el estado con éxito ", 1)
            Buscar()
        End If

    End Sub

    Public Sub Habilitar(Accion As Boolean)
        RcRutaAdd.Enabled = Accion
        RcPersonaAdd.Enabled = Accion
        RcVehiculoAdd.Enabled = Accion
        lbAdd.Visible = Accion
    End Sub

    Public Sub HabilitarMaterial(Accion As Boolean)
        GvMaterialesAsig.Columns(4).Visible = Accion
        LbAddMaterial.Visible = Accion
        RcMaterialAdd.Visible = Accion
        txtCantidad.Visible = Accion
        LabelCant.Visible = Accion
        LabelMat.Visible = Accion
        LbFinalizado.Visible = Accion
    End Sub
    Public Sub Limpiar()
        RcPersonaAdd.SelectedValue = -1
        RcRutaAdd.SelectedValue = -1
        RcVehiculoAdd.SelectedValue = -1
    End Sub

    Private Sub lbAdd_Click(sender As Object, e As EventArgs) Handles lbAdd.Click
        Crear()
    End Sub

    Private Sub lbNew_Click(sender As Object, e As EventArgs) Handles lbNew.Click
        Habilitar(True)
        VehiculoAdd(0)
        PersonaAdd(0)
        RutaAdd()
        lbAdd.Text = "Crear"
        lblEvento.Text = "asiganar ruta"
        ViewState("Accion") = "Crear"
        txtCantidad.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarRuta", "FuncionModalaAsignarRuta();", True)
    End Sub

    Private Sub GvAsignarRuta_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvAsignarRuta.RowDeleting
        Dim Index As Integer = Convert.ToInt32(e.RowIndex)
        Dim ID As Integer = Me.GvAsignarRuta.DataKeys(Index).Values(0)
        Dim dtAsignarRuta As DataTable = ObjUniversal.AsignacionRutas(ID, -1, -1, -1, -1, "", "", "Eliminar")
        If dtAsignarRuta.Rows(0).Item("Bandera") = "1" Then
            ObjUniversal.SendNotify("Se ha eliminado con éxito", 1)
            Buscar()
            RutaBuscar()
            PersonaBuscar()
            VehiculoBuscar()
        Else
            ObjUniversal.SendNotify(dtAsignarRuta.Rows(0).Item("Bandera"), 3)
        End If
    End Sub

    Private Sub LbAddMaterial_Click(sender As Object, e As EventArgs) Handles LbAddMaterial.Click
        If RcMaterialAdd.SelectedValue = -1 Or txtCantidad.Text = "" Then
            ObjUniversal.SendNotify(" Todos los campos son obligatorios ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
            Exit Sub
        End If

        If Int(txtCantidad.Text) <= 0 Then
            ObjUniversal.SendNotify(" La cantidad no puede ser menor o igual a 0 ", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
            Exit Sub
        End If


        Dim dtMateriales As DataTable = ObjUniversal.RutaMateriales(0, ViewState("ID"), RcMaterialAdd.SelectedValue, Convert.ToDecimal(txtCantidad.Text), "", "Crear")
        If dtMateriales.Rows(0).Item("Bandera") = "1" Then
            MaterialesAdd()
            RcMaterialAdd.SelectedValue = -1
            txtCantidad.Text = ""
            BuscarMateriales()
            ObjUniversal.SendNotify(" Se ha creado el registro con éxito ", 1)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
        Else
            ObjUniversal.SendNotify(dtMateriales.Rows(0).Item("Bandera"), 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
        End If
    End Sub

    Public Sub BuscarMateriales()
        Dim dtTotalMateriales As DataTable = ObjUniversal.RutaMateriales(0, ViewState("ID"), 0, 0, "", "Total")
        Dim dtMateriales As DataTable = ObjUniversal.RutaMateriales(0, ViewState("ID"), 0, 0, "", "Buscar")
        If dtMateriales.Rows.Count > 0 Then
            GvMaterialesAsig.DataSource = dtMateriales
            GvMaterialesAsig.DataBind()
            txtTotal.Text = dtTotalMateriales.Rows(0).Item("TOTAL") & " Kg"
            Dim Valor As Int64 = dtTotalMateriales.Rows(0).Item("Precio") * CDbl("800.000")
            txtCosto.Text = ObjUniversal.ConverNumeroPuntos(Valor)
        Else
            GvMaterialesAsig.DataSource = Nothing
            GvMaterialesAsig.DataBind()
            txtTotal.Text = "0"
            txtCosto.Text = "0"
        End If
    End Sub

    Private Sub GvMaterialesAsig_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvMaterialesAsig.RowDeleting
        ViewState("RutaMatID") = Me.GvMaterialesAsig.DataKeys(e.RowIndex).Value
        Dim dtMaterialEliminar As DataTable = ObjUniversal.RutaMateriales(ViewState("RutaMatID"), 0, 0, 0, "", "Eliminar")
        BuscarMateriales()
        ObjUniversal.SendNotify("El material se ha eliminado con éxito", 1)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
    End Sub

    Private Sub LbFinalizado_Click(sender As Object, e As EventArgs) Handles LbFinalizado.Click
        If GvMaterialesAsig.Rows.Count < 1 Then
            BuscarMateriales()
            ObjUniversal.SendNotify("Para finalizar el cargamento por lo menos debe haber un material asignado a la ruta", 3)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "FuncionModalaAsignarMaterialRuta", "FuncionModalaAsignarMaterialRuta();", True)
            Exit Sub
        End If

        For i As Integer = 0 To GvAsignarRuta.Rows.Count - 1
            Dim Trayecto As Decimal = ViewState("Trayecto") / 5
            Dim Peso As String = ObjUniversal.ConverNumeroPuntos(Trayecto * Me.GvMaterialesAsig.DataKeys(i).Values(1) * CDbl("800.000"))
            Dim dtCostoMaterial As DataTable = ObjUniversal.RutaMateriales(Me.GvMaterialesAsig.DataKeys(i).Values(0), 0, 0, 0, Peso, "CostoMaterial")
        Next

        Dim dtMaterialEliminar As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), 0, 0, 0, 1, "", "", "CambiarEstado")
        Dim dtCosto As DataTable = ObjUniversal.AsignacionRutas(ViewState("ID"), 0, 0, 0, 0, txtCosto.Text, txtTotal.Text, "Costo")
        Buscar()
    End Sub

    Private Sub GvAsignarRuta_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GvAsignarRuta.RowDataBound
        Dim btnEliminar As System.Web.UI.WebControls.LinkButton = DirectCast(e.Row.FindControl("lbEliminar"), System.Web.UI.WebControls.LinkButton)
        Dim btnEntregado As System.Web.UI.WebControls.LinkButton = DirectCast(e.Row.FindControl("LbEntragado"), System.Web.UI.WebControls.LinkButton)


        Try
            Dim Estado As String = GvAsignarRuta.DataKeys(e.Row.RowIndex).Values(1)
            If Estado = 1 Then
                btnEliminar.Visible = False
                btnEntregado.Visible = True
            ElseIf Estado = 2 Then
                btnEliminar.Visible = False
                btnEntregado.Visible = False
            Else
                btnEliminar.Visible = True
                btnEntregado.Visible = False
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class