Imports AppSolutions.DataLayer
Public Class CLUniversal

    Public Function Usuarios(ByVal UsuarioID As Integer,
                               ByVal Identificacion As String,
                               ByVal Contrasena As String,
                               ByVal SwActivo As Integer,
                               ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@UsuarioID", UsuarioID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Identificacion", Identificacion, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Contrasena", Contrasena, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@SwActivo", SwActivo, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Usuarios", ObjCollection)
        Return dt
    End Function
    Public Function Materiales(ByVal MaterialID As Integer,
                               ByVal Descripcion As String,
                               ByVal Presentacion As String,
                               ByVal PesoKg As Decimal,
                               ByVal SwActivo As Integer,
                               ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@MaterialID", MaterialID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Descripcion", Descripcion, SqlDbType.NVarChar, 500)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Presentacion", Presentacion, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@PesoKg", PesoKg, SqlDbType.Decimal)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@SwActivo", SwActivo, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Materiales", ObjCollection)
        Return dt
    End Function

    Public Function Personas(ByVal PersonaID As Integer,
                              ByVal Nombre As String,
                              ByVal Apellido As String,
                              ByVal TipoDocumentoID As Integer,
                              ByVal NumeroIdentificacion As String,
                              ByVal NumerolicenciaConduccion As String,
                              ByVal fechaVenc As String,
                              ByVal Telefono As String,
                              ByVal SwActivo As Integer,
                              ByVal Accion As String) As DataTable

        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@PersonaID", PersonaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Nombre", Nombre, SqlDbType.NVarChar, 500)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Apellido", Apellido, SqlDbType.NVarChar, 500)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@TipoDocumentoID", TipoDocumentoID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@NumeroIdentificacion", NumeroIdentificacion, SqlDbType.NVarChar, 20)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@NumerolicenciaConduccion", NumerolicenciaConduccion, SqlDbType.NVarChar, 20)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@fechaVenc", fechaVenc, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Telefono", Telefono, SqlDbType.NVarChar, 20)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@SwActivo", SwActivo, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Personas", ObjCollection)
        Return dt
    End Function

    Public Function Vehiculo(ByVal VehiculoID As Integer,
                              ByVal Placa As String,
                              ByVal CapacidadCarga As String,
                              ByVal Soat As String,
                              ByVal FechaVencSoat As String,
                              ByVal Tecnomecanica As String,
                              ByVal FechaVenTecno As String,
                              ByVal RegistroTransporteCarga As String,
                              ByVal FechaVenTransporteCarga As String,
                              ByVal SwActivo As Integer,
                              ByVal Accion As String) As DataTable

        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@VehiculoID", VehiculoID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Placa", Placa, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@CapacidadCarga", CapacidadCarga, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Soat", Soat, SqlDbType.NVarChar, 15)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@FechaVencSoat", FechaVencSoat, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Tecnomecanica", Tecnomecanica, SqlDbType.NVarChar, 15)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@FechaVenTecno", FechaVenTecno, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@RegistroTransporteCarga", RegistroTransporteCarga, SqlDbType.NVarChar, 15)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@FechaVenTransporteCarga", FechaVenTransporteCarga, SqlDbType.NVarChar, 10)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@SwActivo", SwActivo, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Vehiculos", ObjCollection)
        Return dt
    End Function

    Public Function Rutas(ByVal RutaID As Integer,
                          ByVal LugarOrigen As Integer,
                          ByVal LugarDestino As Integer,
                          ByVal TrayectoKm As Decimal,
                          ByVal SwActivo As Integer,
                          ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@RutaID", RutaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@LugarOrigen", LugarOrigen, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@LugarDestino", LugarDestino, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@TrayectoKm", TrayectoKm, SqlDbType.Decimal)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@SwActivo", SwActivo, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Rutas", ObjCollection)
        Return dt
    End Function

    Public Function AsignacionRutas(ByVal AsignacionRutaID As Integer,
                                    ByVal RutaID As Integer,
                                    ByVal VehiculoID As Integer,
                                    ByVal PersonaID As Integer,
                                    ByVal EstadoID As Integer,
                                    ByVal CostoTransporte As String,
                                    ByVal PesoTotal As String,
                                    ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@AsignacionRutaID", AsignacionRutaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@RutaID", RutaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@VehiculoID", VehiculoID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@PersonaID", PersonaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@EstadoID", EstadoID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@CostoTransporte", CostoTransporte, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@PesoTotal", PesoTotal, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_AsignacionRutas", ObjCollection)
        Return dt
    End Function

    Public Function RutaMateriales(ByVal RutaMaterialID As Integer,
                                   ByVal AsignacionRutaID As Integer,
                                   ByVal MaterialID As Integer,
                                   ByVal Cantidad As Decimal,
                                   ByVal CostoTransporte As String,
                                   ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@RutaMaterialID", RutaMaterialID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@AsignacionRutaID", AsignacionRutaID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@MaterialID", MaterialID, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Cantidad", Cantidad, SqlDbType.Decimal)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@CostoTransporte", CostoTransporte, SqlDbType.NVarChar, 50)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_RutaMateriales", ObjCollection)
        Return dt
    End Function

    Public Function Informes(ByVal VarString1 As String,
                                   ByVal VarInteger1 As Integer,
                                   ByVal VarInteger2 As Integer,
                                   ByVal VarInteger3 As Integer,
                                   ByVal VarInteger4 As Integer,
                                   ByVal Accion As String) As DataTable
        Dim ObjCollection As New Collection
        Dim ObjParametro As New SpParametro("@VarString1", VarString1, SqlDbType.NVarChar, 500)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@VarInteger1", VarInteger1, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@VarInteger2", VarInteger2, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@VarInteger3", VarInteger3, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@VarInteger4", VarInteger4, SqlDbType.Int)
        ObjCollection.Add(ObjParametro)
        ObjParametro = New SpParametro("@Accion", Accion, SqlDbType.NVarChar, 30)
        ObjCollection.Add(ObjParametro)

        Dim dt As DataTable = Datos.GetDatatable("SP_Informes", ObjCollection)
        Return dt
    End Function


    Public Sub SendNotify(msg As String, noti As String)
        With System.Web.HttpContext.Current.Session
            .Add("NombreVariable", "Notificacion")
            .Add("Msg", msg)
            .Add("TipoNotificacion", noti)
        End With
    End Sub

    Public Function ConverNumeroPuntos(number As Int64) As String
        Dim Valor As String = number.ToString("$##,###,##0")
        Return Valor
    End Function

    Public Function ComprobarFormatoNumeros(seLETRASComprobar As String) As Boolean
        Dim sFormato As [String]
        sFormato = "^[0-9-,-.]*$"
        If Regex.IsMatch(seLETRASComprobar, sFormato) Then
            If Regex.Replace(seLETRASComprobar, sFormato, [String].Empty).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

End Class
