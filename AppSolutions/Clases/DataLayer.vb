Imports System.Data.SqlClient
Namespace DataLayer
    Public Class SpParametro

#Region "Campos Ocultos"

        Dim _Nombre As String
        Dim _Tipo As SqlDbType
        Dim _Valor As Object
        Dim _Longitud As Integer
        Dim _Escala As Integer


#End Region

#Region "Constructores"

        Public Sub New(ByVal Nombre As String, ByVal Valor As Object, ByVal Tipo As SqlDbType)

            Me._Nombre = Nombre
            Me._Valor = Valor
            Me._Tipo = Tipo

        End Sub

        Public Sub New(ByVal Nombre As String, ByVal Valor As Object, ByVal Tipo As SqlDbType, ByVal Longitud As Integer)

            Me._Nombre = Nombre
            Me._Valor = Valor
            Me._Tipo = Tipo
            Me._Longitud = Longitud

        End Sub

#End Region

#Region "Propiedades"

        Property Nombre() As String
            Get
                Return Me._Nombre
            End Get
            Set(ByVal value As String)
                Me._Nombre = value
            End Set
        End Property

        Property Tipo() As SqlDbType
            Get
                Return Me._Tipo
            End Get
            Set(ByVal value As SqlDbType)
                Me._Tipo = value
            End Set
        End Property

        Property Valor() As Object
            Get
                Return Me._Valor
            End Get
            Set(ByVal value As Object)
                Me._Valor = value
            End Set
        End Property

        Property Longitud() As Integer
            Get
                Return Me._Longitud
            End Get
            Set(ByVal value As Integer)

                Me._Longitud = value
            End Set
        End Property

        Property Escala() As Integer
            Get
                Return Me._Escala
            End Get
            Set(ByVal value As Integer)

                Me._Escala = value
            End Set
        End Property

#End Region

    End Class

    Public Class Datos

#Region "Métodos Compartidos"

        Public Shared Function GetDatatable(ByVal Procedimiento As String, ByVal parametros As Collection) As DataTable

            Dim CadenaSql As String = " "


            Try


                Dim Conexion As New SqlConnection()
                Conexion.ConnectionString = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString
                Dim Comando As New SqlCommand()
                Comando.Connection = Conexion
                Comando.CommandType = CommandType.StoredProcedure
                Comando.CommandText = Procedimiento
                Comando.CommandTimeout = 60000
                Dim ObjColecctions As SpParametro
                Dim Parametro As SqlParameter

                For Each ObjColecctions In parametros
                    Parametro = New SqlParameter
                    Parametro.ParameterName = ObjColecctions.Nombre
                    Parametro.SqlDbType = ObjColecctions.Tipo
                    Parametro.Value = ObjColecctions.Valor

                    If ObjColecctions.Tipo = SqlDbType.VarChar Then
                        Parametro.Size = ObjColecctions.Longitud
                    End If


                    CadenaSql &= ObjColecctions.Nombre & " = " & ObjColecctions.Valor.ToString & " | "

                    Comando.Parameters.Add(Parametro)
                Next

                Dim objdatatable As New DataTable
                Dim objAdapter As New SqlDataAdapter(Comando)
                objAdapter.Fill(objdatatable)

                Return objdatatable

                objAdapter.Dispose()
                Conexion.Dispose()
                Comando.Dispose()
                Conexion.Close()

            Catch ex As System.Exception

                'Dim LogErrores As New LogErrores
                'LogErrores.Registrar(Procedimiento, CadenaSql, "GetDataTable", ex.Message)
                'RegistrarError(ex.Message, "Exec " & Procedimiento & " " & CadenaSql)

                Dim objdatatable As New DataTable
                Return objdatatable

            End Try

        End Function
        Public Shared Function GetDatataset(ByVal Procedimiento As String, ByVal parametros As Collection) As DataSet

            Dim CadenaSql As String = " "

            Try

                Dim Conexion As New SqlConnection()
                Conexion.ConnectionString = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString
                Dim Comando As New SqlCommand()
                Comando.Connection = Conexion
                Comando.CommandType = CommandType.StoredProcedure
                Comando.CommandText = Procedimiento
                Comando.CommandTimeout = 60000
                Dim ObjColecctions As SpParametro
                Dim Parametro As SqlParameter
                ' Recorre la coleccion de parametros
                For Each ObjColecctions In parametros
                    Parametro = New SqlParameter
                    Parametro.ParameterName = ObjColecctions.Nombre
                    Parametro.SqlDbType = ObjColecctions.Tipo
                    Parametro.Value = ObjColecctions.Valor

                    If ObjColecctions.Tipo = SqlDbType.Decimal Then
                        Parametro.Scale = ObjColecctions.Escala
                    End If

                    If ObjColecctions.Tipo = SqlDbType.VarChar Then
                        Parametro.Size = ObjColecctions.Longitud
                    End If

                    CadenaSql &= ObjColecctions.Nombre & " = " & ObjColecctions.Valor.ToString & " | "

                    Comando.Parameters.Add(Parametro)
                Next

                Dim objdataset As New DataSet
                Dim objAdapter As New SqlDataAdapter(Comando)
                objAdapter.Fill(objdataset)

                Return objdataset

                objAdapter.Dispose()
                Conexion.Dispose()
                Comando.Dispose()

            Catch ex As System.Exception

                'Dim LogErrores As New LogErrores
                'LogErrores.Registrar(Procedimiento, CadenaSql, "GetDataTable", ex.Message)
                'RegistrarError(ex.Message, "Exec " & Procedimiento & " " & CadenaSql)

                Dim objdataset As New DataSet
                Return objdataset

            End Try

        End Function
        Public Shared Function GetEscalar(ByVal Procedimiento As String, ByVal parametros As Collection) As Object

            Dim CadenaSql As String = " "

            Try

                Dim Conexion As New SqlConnection()
                Conexion.ConnectionString = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString
                Dim Comando As New SqlCommand()
                Comando.Connection = Conexion
                Comando.CommandType = CommandType.StoredProcedure
                Comando.CommandText = Procedimiento
                Comando.CommandTimeout = 60000
                Dim ObjColecctions As SpParametro
                Dim Parametro As SqlParameter
                ' Recorre la coleccion de parametros
                For Each ObjColecctions In parametros
                    Parametro = New SqlParameter
                    Parametro.ParameterName = ObjColecctions.Nombre
                    Parametro.SqlDbType = ObjColecctions.Tipo
                    Parametro.Value = ObjColecctions.Valor

                    If ObjColecctions.Tipo = SqlDbType.Decimal Then
                        Parametro.Scale = ObjColecctions.Escala
                    End If

                    If ObjColecctions.Tipo = SqlDbType.VarChar Then
                        Parametro.Size = ObjColecctions.Longitud
                    End If

                    CadenaSql &= ObjColecctions.Nombre & " = " & ObjColecctions.Valor.ToString & " | "

                    Comando.Parameters.Add(Parametro)

                Next

                Conexion.Open()
                Dim Resultado As Object
                Resultado = Comando.ExecuteScalar
                Conexion.Close()

                Conexion.Dispose()
                Comando.Dispose()

                Return Resultado

            Catch ex As System.Exception

                'Dim LogErrores As New LogErrores
                'LogErrores.Registrar(Procedimiento, CadenaSql, "GetDataTable", ex.Message)
                ' RegistrarError(ex.Message, "Exec " & Procedimiento & " " & CadenaSql)

                Return 0

            End Try

        End Function

        Public Shared Sub Execute(ByVal Procedimiento As String, ByVal parametros As Collection)

            Dim CadenaSql As String = " "

            Try
                Dim Conexion As New SqlConnection()
                Conexion.ConnectionString = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString
                Dim Comando As New SqlCommand()
                Comando.Connection = Conexion
                Comando.CommandType = CommandType.StoredProcedure
                Comando.CommandText = Procedimiento
                Comando.CommandTimeout = 60000
                Dim ObjColecctions As SpParametro
                Dim Parametro As SqlParameter
                ' Recorre la coleccion de parametros
                For Each ObjColecctions In parametros
                    Parametro = New SqlParameter
                    Parametro.ParameterName = ObjColecctions.Nombre
                    Parametro.SqlDbType = ObjColecctions.Tipo
                    Parametro.Value = ObjColecctions.Valor

                    If ObjColecctions.Tipo = SqlDbType.Decimal Then
                        Parametro.Scale = ObjColecctions.Escala
                    End If

                    If ObjColecctions.Tipo = SqlDbType.VarChar Then
                        Parametro.Size = ObjColecctions.Longitud
                    End If

                    CadenaSql &= ObjColecctions.Nombre & " = " & ObjColecctions.Valor.ToString & " | "

                    Comando.Parameters.Add(Parametro)
                Next

                Conexion.Open()
                Dim Resultado As Object
                Resultado = Comando.ExecuteNonQuery

                Conexion.Close()
                Conexion.Dispose()
                Comando.Dispose()

            Catch ex As System.Exception

                'Dim LogErrores As New LogErrores
                'LogErrores.Registrar(Procedimiento, CadenaSql, "GetDataTable", ex.Message)
                'RegistrarError(ex.Message, "Exec " & Procedimiento & " " & CadenaSql)
                Throw ex

            End Try

        End Sub



#End Region

    End Class
End Namespace
