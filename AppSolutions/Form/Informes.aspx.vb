Imports System.Security.Cryptography
Imports System.IO
Imports ClosedXML.Excel

Public Class Informes
    Inherits System.Web.UI.Page
    Dim ObjUniversal As New CLUniversal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

    Public Sub Placa()
        Dim dt As DataTable = ObjUniversal.Informes("", 0, 0, 0, 0, "Placa")
        If dt.Rows.Count > 0 Then
            With Me.RcPlaca
                .Items.Clear()
                .DataSource = dt
                .DataValueField = "VehiculoID"
                .DataTextField = "Placa"
                .DataBind()
            End With
            RcPlaca.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione placa", "-1"))
        Else
            RcPlaca.Items.Clear()
            RcPlaca.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione placa", "-1"))
        End If
    End Sub

    Public Sub Ruta()
        Dim dt As DataTable = ObjUniversal.Informes("", 0, 0, 0, 0, "Ruta")
        If dt.Rows.Count > 0 Then
            With Me.RcRutas
                .Items.Clear()
                .DataSource = dt
                .DataValueField = "RutaID"
                .DataTextField = "Ruta"
                .DataBind()
            End With
            RcRutas.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione ruta", "-1"))
        Else
            RcRutas.Items.Clear()
            RcRutas.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione ruta", "-1"))
        End If
    End Sub

    Public Sub Persona()
        Dim dt As DataTable = ObjUniversal.Informes("", 0, 0, 0, 0, "PersonasCargo")
        If dt.Rows.Count > 0 Then
            With Me.RcPersonaCargo
                .Items.Clear()
                .DataSource = dt
                .DataValueField = "PersonaID"
                .DataTextField = "Nombre"
                .DataBind()
            End With
            RcPersonaCargo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione ruta", "-1"))
        Else
            RcPersonaCargo.Items.Clear()
            RcPersonaCargo.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione ruta", "-1"))
        End If
    End Sub

    Private Sub Descargas(dt As DataTable)
        Dim cultura_anterior As System.Globalization.CultureInfo
        cultura_anterior = System.Globalization.CultureInfo.CurrentCulture
        'Se crea este formato para los valores numericos que tienen comas y punto como separadores
        Dim cultura_invariable As New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture = cultura_invariable

        Dim nameFile As String = "Informes.xlsx"

        Dim FullPathName As String = System.AppDomain.CurrentDomain.BaseDirectory & "\Exportar\" & nameFile

        If dt.Rows.Count > 0 Then

            ConvertXLSX(dt, FullPathName)
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" & nameFile)
            Response.Flush()
            Response.TransmitFile(FullPathName)
            Response.End()

            File.Delete(FullPathName)

            'Se restablece la cultura inicial
            System.Threading.Thread.CurrentThread.CurrentCulture = cultura_anterior

        Else
            ObjUniversal.SendNotify(" No hay datos para exportar ", "3")
        End If
    End Sub
    Public Sub ConvertXLSX(ByVal dt As DataTable, ByVal FullPathName As String)
        Try
            Dim wb = New XLWorkbook()
            Dim dataTable = dt
            dataTable.TableName = "informes"
            ' Add a DataTable as a worksheet
            wb.Worksheets.Add(dataTable)
            wb.SaveAs(FullPathName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lbInfVehiculoRutAct_Click(sender As Object, e As EventArgs) Handles lbInfVehiculoRutAct.Click
        Dim dt As DataTable = ObjUniversal.Informes("", 1, 0, 0, 0, "VehiculosRutaAct")
        If dt.Rows.Count > 0 Then
            Descargas(dt)
        Else
            ObjUniversal.SendNotify(" No hay datos para mostrar ", "3")
        End If
    End Sub

    Private Sub lbInfVehiculos_Click(sender As Object, e As EventArgs) Handles lbInfVehiculos.Click
        Dim dt As DataTable = ObjUniversal.Informes("", 0, 0, 0, 0, "VehiculosDoc")
        If dt.Rows.Count > 0 Then
            Descargas(dt)
        Else
            ObjUniversal.SendNotify(" No hay datos para mostrar ", "3")
        End If
    End Sub

    Private Sub lbInfVehiculoRutDetallado_Click(sender As Object, e As EventArgs) Handles lbInfVehiculoRutDetallado.Click
        pnMenu.Visible = False
        pnInfoRutaDetallado.Visible = True
        Placa()
        Ruta()
        Persona()
    End Sub

    Private Sub LbBuscar_Click(sender As Object, e As EventArgs) Handles LbBuscar.Click
        Dim dt As DataTable = ObjUniversal.Informes("", 0, RcPlaca.SelectedValue, RcPersonaCargo.SelectedValue, RcRutas.SelectedValue, "BuscarVehiculosRuta")
        If dt.Rows.Count > 0 Then
            gvRutasActivas.DataSource = dt
            gvRutasActivas.DataBind()
            Alert.Visible = False
        Else
            gvRutasActivas.DataSource = Nothing
            gvRutasActivas.DataBind()
            Alert.Visible = True
        End If
    End Sub

    Private Sub gvRutasActivas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRutasActivas.RowCommand
        Dim ID As Integer = Convert.ToInt32(e.CommandArgument)
        If e.CommandName = "VerDetalle" Then
            Dim dt As DataTable = ObjUniversal.Informes("", ID, 0, 0, 0, "VehiculosRutaDetallado")
            If dt.Rows.Count > 0 Then
                Descargas(dt)
            Else
                ObjUniversal.SendNotify(" No hay datos para mostrar ", "3")
            End If
        End If
    End Sub

    Private Sub LbRutasTerminadas_Click(sender As Object, e As EventArgs) Handles LbRutasTerminadas.Click
        Dim dt As DataTable = ObjUniversal.Informes("", 2, 0, 0, 0, "VehiculosRutaTer")
        If dt.Rows.Count > 0 Then
            Descargas(dt)
        Else
            ObjUniversal.SendNotify(" No hay datos para mostrar ", "3")
        End If
    End Sub
End Class