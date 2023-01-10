<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Principal.Master" CodeBehind="AsignarRutas.aspx.vb" Inherits="AppSolutions.AsignarRutaaspx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script>
        function FuncionModalaAsignarRuta() {
            $("#ModalaAsignarRuta").modal("show")
        }
    </script>

    <script>
        function FuncionModalaAsignarMaterialRuta() {
            $("#ModalaAsignarMaterialRuta").modal("show")
        }
    </script>
</asp:Content>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="main_title" runat="server">
</asp:Content>--%>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="Header" runat="server">
</asp:Content>--%>

<asp:Content ID="Content5" ContentPlaceHolderID="Main_Texto" runat="server">
</asp:Content>

<%--<asp:Content ID="Content6" ContentPlaceHolderID="navbar" runat="server">
</asp:Content>--%>

<asp:Content ID="Content7" ContentPlaceHolderID="Main_pagination" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Menu.aspx">Inicio</a></li>
        <li class="breadcrumb-item active">Asignar rutas</li>
    </ol>
</asp:Content>

<%--<asp:Content ID="Content8" ContentPlaceHolderID="main_content" runat="server">
</asp:Content>--%>

<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .RadComboBox, .RadComboBox * {
            padding: 6px;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="pnMateriales" runat="server" Visible="true">
        <div class="panel panel-default" id="xxx" runat="server">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-lg-8">
                        Asignar rutas 
                    </div>
                    <div class="col-lg-4" style="text-align: right">
                        <asp:LinkButton ID="lbNew" runat="server" CssClass="btn btn-primary" OnClientClick="ShowBlockWindow();"> 
                            <span class="fa fa-plus"></span>&nbsp;Asignar 
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="form-group row" style="background-color: #F2F2F2">
                    <div class="col-lg-12">
                        <strong>Cuadro de Consulta</strong>
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col-lg-4">
                        Persona encargada:
                         <telerik:RadComboBox ID="RcPersonaBC" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                        </telerik:RadComboBox>
                    </div>

                    <div class="col-lg-4">
                        Vehículo(Placa):
                        <telerik:RadComboBox ID="RcVehiculoBC" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                        </telerik:RadComboBox>
                    </div>

                    <div class="col-lg-4">
                        Estado:
                         <telerik:RadComboBox ID="RcEstadoBc" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-lg-8">
                        Ruta:
                         <telerik:RadComboBox ID="RcRutaBC" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                        </telerik:RadComboBox>
                    </div>

                     <div class="col-lg-2" >
                        <br>
                        <asp:LinkButton ID="lbBuscar" runat="server" CssClass="btn btn-success" OnClientClick="ShowBlockWindow();"> 
                            <span class="fa fa-search"></span>&nbsp;Buscar 
                        </asp:LinkButton>
                        <br>
                    </div>

                </div>

                <br />
                <div class="form-group row" style="background-color: #F2F2F2">
                    <div class="col-lg-12">
                        <strong>Listado</strong>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-lg-12">
                        <asp:GridView ID="GvAsignarRuta" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            CssClass="table table-striped table-bordered table-hover" Font-Size="Small" AllowPaging="True"
                            DataKeyNames="AsignacionRutaID,EstadoID,VehiculoID,PersonaID,TrayectoKm">
                            <HeaderStyle BackColor="#E6E6E6" Font-Bold="True" ForeColor="#424242" />
                            <PagerStyle HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <Columns>
                                <asp:BoundField DataField="Ruta" HeaderText="Ruta">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Placa" HeaderText="Vehículo">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="NombreCompleto" HeaderText="Persona encargada">
                                    <ItemStyle Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lEstado" runat="server" Text='<%# Bind("Estado")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEditar" runat="server" CausesValidation="False" CommandName="Editar" CssClass="fa fa-pencil-square-o  fa-lg" Text=""
                                            data-toggle="tooltip" title="Editar Datos" OnClientClick="ShowBlockWindow();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>                                                                       
                                        </asp:LinkButton>
                                        &nbsp;
                                        <asp:LinkButton ID="LbAsigarMaterial" runat="server" CausesValidation="False" CommandName="Materiales" CssClass="fa fa-cubes  fa-lg" Text="" ForeColor="Orange"
                                            data-toggle="tooltip" title="Añadir cargamento" OnClientClick="ShowBlockWindow();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>                                                                       
                                        </asp:LinkButton>                                        
                                         
                                         &nbsp;
                                        <asp:LinkButton ID="lbEliminar" runat="server" CommandName="Delete" CssClass="fa fa-trash-o fa-lg"  Text=""  style="color:#ff0000" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            data-toggle="tooltip" title="Eliminar" OnClientClick="return deletealert2(this, event);">
                                        </asp:LinkButton>
                                        <%-- ============ Alerta de confirmación eliminación de registro ============ --%>
                                        <script>
                                            function deletealert2(ctl, event) {
                                                // STORE HREF ATTRIBUTE OF LINK CTL (THIS) BUTTON
                                                var defaultAction = $(ctl).prop("href");
                                                // CANCEL DEFAULT LINK BEHAVIOUR
                                                event.preventDefault();
                                                swal({
                                                    title: "¿Está Seguro de eliminar este registro?",
                                                    text: "",
                                                    type: "warning",
                                                    showCancelButton: true,
                                                    confirmButtonColor: "#DD6B55",
                                                    confirmButtonText: "Si, ¡Eliminar!",
                                                    cancelButtonText: "No, cancelar",
                                                    closeOnConfirm: false,
                                                    //closeOnCancel: false
                                                },
                                                    function (isConfirm) {
                                                        if (isConfirm) {
                                                            //swal({ title: "Eliminado!", text: "Tu archivo imaginario ha sido eliminado.", type: "success", confirmButtonText: "OK!", closeOnConfirm: false },
                                                            //function () {
                                                            //    // RESUME THE DEFAULT LINK ACTION
                                                            window.location.href = defaultAction;
                                                            return true;
                                                            //});                                                            
                                                        } else {
                                                            //swal("Cancelado", "Tu archivo imaginario es seguro :)", "error");
                                                            return false;
                                                        }
                                                    });
                                            }
                                        </script>
                                        <%-- ============ FIN Alerta de confirmación eliminación de registro ============ --%>

                                        <asp:LinkButton ID="LbEntragado" runat="server" CommandName="Entregado" CssClass="fa fa-check  fa-lg" Text="" ForeColor="green" 
                                            style="color:#0de609" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' data-toggle="tooltip" title="Confirmar entrega" OnClientClick="return deletealert3(this, event);">                                                                     
                                        </asp:LinkButton>
                                        <%-- ============ Alerta de confirmación eliminación de registro ============ --%>
                                        <script>
                                            function deletealert3(ctl, event) {
                                                // STORE HREF ATTRIBUTE OF LINK CTL (THIS) BUTTON
                                                var defaultAction = $(ctl).prop("href");
                                                // CANCEL DEFAULT LINK BEHAVIOUR
                                                event.preventDefault();
                                                swal({
                                                    title: "¿Está Seguro de cambiar el estado a entregado?",
                                                    text: "",
                                                    type: "warning",
                                                    showCancelButton: true,
                                                    confirmButtonColor: "#DD6B55",
                                                    confirmButtonText: "Si, ¡Cambiar estado!",
                                                    cancelButtonText: "No, cancelar",
                                                    closeOnConfirm: false,
                                                    //closeOnCancel: false
                                                },
                                                    function (isConfirm) {
                                                        if (isConfirm) {
                                                            //swal({ title: "Eliminado!", text: "Tu archivo imaginario ha sido eliminado.", type: "success", confirmButtonText: "OK!", closeOnConfirm: false },
                                                            //function () {
                                                            //    // RESUME THE DEFAULT LINK ACTION
                                                            window.location.href = defaultAction;
                                                            return true;
                                                            //});                                                            
                                                        } else {
                                                            //swal("Cancelado", "Tu archivo imaginario es seguro :)", "error");
                                                            return false;
                                                        }
                                                    });
                                            }
                                        </script>
                                        <%-- ============ FIN Alerta de confirmación eliminación de registro ============ --%>

                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="alert alert-info" role="alert" id="Alerta1" runat="server">¡Aviso! No hay resultados para mostrar....</div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>



    <%-- Manejo de mensajes alertas --%>
    <div class="alert alert-danger" id="pnMensajeSinAcceso" runat="server" visible="false">
        <strong>
            <asp:Label ID="lMensaje1" runat="server" Text="Sin acceso"></asp:Label></strong><br />
        <strong>
            <asp:Label ID="lMensaje2" runat="server" Text="Atención!"></asp:Label></strong>
        <asp:Label ID="lMensajeDanger" runat="server" Text="No tienes acceso a este módulo consulta con el administrador"></asp:Label>
    </div>

    <%-- Manejo de mensajes alertas --%>
    <div class="alert alert-warning" id="pnAlert" runat="server" visible="false" style="text-align: left">
        <div class="form-group row">
            <div class="col-lg-1" style="text-align: right">
                <i class="fa fa-exclamation-circle fa-3x" aria-hidden="true"></i>
            </div>
            <div class="col-lg-11">
                <strong>
                    <asp:Label ID="Label2" runat="server" Text="Label:"></asp:Label></strong><br />
                <strong>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></strong>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>

    <!-- Modal Para asignar rutas-->
    <div id="ModalaAsignarRuta" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <strong>
                        <asp:Label ID="lblEvento" runat="server" Text="Asignar ruta"></asp:Label></strong>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-lg-12">
                            Ruta:
                            <telerik:RadComboBox ID="RcRutaAdd" runat="server" Filter="Contains"
                                Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-6">
                            Persona encargada:
                             <telerik:RadComboBox ID="RcPersonaAdd" runat="server" Filter="Contains"
                                Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>

                        <div class="col-lg-6">
                            vehículo:
                            <telerik:RadComboBox ID="RcVehiculoAdd" runat="server" Filter="Contains"
                                Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>
                    </div>     

                    <div class="modal-footer">
                        <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-primary" OnClientClick="ShowBlockWindow();"> <%--<span class="fa fa-plus"></span>--%>&nbsp;Actualizar </asp:LinkButton>
                        &nbsp;&nbsp;
                    <a href="#" data-dismiss="modal" class="btn btn-danger">Salir</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <!-- Modal Para asignar materiales a la ruta-->
    <div id="ModalaAsignarMaterialRuta" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <strong>
                        <asp:Label ID="Label1" runat="server" Text="Materiales de carga"></asp:Label></strong>
                </div>
                <div class="modal-header">
                    <div class="form-group row">
                        <div class="col-lg-4">
                             <strong>Capacidad maxima de carga:</strong>
                            <asp:Label ID="lbCapacidad" runat="server" Text="Label"></asp:Label>   
                        </div>
                        <div class="col-lg-4">
                            <strong>Vehículo(Placa):</strong>
                            <asp:Label ID="lbVehiculo" runat="server" Text="Label"></asp:Label>
                           
                        </div>
                         <div class="col-lg-4">
                            <strong>Trayecto:</strong>
                            <asp:Label ID="LbTrayecto" runat="server" Text="Label"></asp:Label>
                           
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-12">
                           <strong>Ruta:</strong>
                            <asp:Label ID="lbRuta" runat="server" Text="Label"></asp:Label> 
                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-lg-8">
                            <asp:Label ID="LabelMat" runat="server" Text="Material:"></asp:Label>
                            <telerik:RadComboBox ID="RcMaterialAdd" runat="server" Filter="Contains"
                                Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>
                        <div class="col-lg-2">
                            <asp:Label ID="LabelCant" runat="server" Text="Cantidad:"></asp:Label>
                         <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control">
                         </asp:TextBox>
                        </div>

                        <div class="col-lg-2">
                            <br />
                            <asp:LinkButton ID="LbAddMaterial" runat="server" CssClass="btn btn-primary" OnClientClick="ShowBlockWindow();"> 
                                &nbsp;Agregar </asp:LinkButton>
                        </div>
                    </div>   

                    <div class="form-group row">
                    <div class="col-lg-12">
                        <asp:GridView ID="GvMaterialesAsig" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            CssClass="table table-striped table-bordered table-hover" Font-Size="Small" AllowPaging="True"
                            DataKeyNames="RutaMaterialID,pesoNeto">
                            <HeaderStyle BackColor="#E6E6E6" Font-Bold="True" ForeColor="#424242" />
                            <PagerStyle HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <Columns>
                                <asp:BoundField DataField="MaterialID" HeaderText="Cod. Interno" Visible="false">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Materiales" HeaderText="Descripción del material">
                                    <ItemStyle Width="40%" HorizontalAlign="Center" VerticalAlign="Middle"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad"  HeaderText="Cantidad">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Peso de la carga">
                                    <ItemTemplate>
                                        <asp:Label ID="lPeso" runat="server" Text='<%# Bind("Peso")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEliminar" runat="server" CommandName="Delete" CssClass="fa fa-trash-o fa-lg"  Text=""  style="color:#ff0000" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            data-toggle="tooltip" title="Eliminar" OnClientClick="return deletealert2(this, event);">
                                        </asp:LinkButton>
                                        <%-- ============ Alerta de confirmación eliminación de registro ============ --%>
                                        <script>
                                            function deletealert2(ctl, event) {
                                                // STORE HREF ATTRIBUTE OF LINK CTL (THIS) BUTTON
                                                var defaultAction = $(ctl).prop("href");
                                                // CANCEL DEFAULT LINK BEHAVIOUR
                                                event.preventDefault();
                                                swal({
                                                    title: "¿Está Seguro de eliminar este registro?",
                                                    text: "",
                                                    type: "warning",
                                                    showCancelButton: true,
                                                    confirmButtonColor: "#DD6B55",
                                                    confirmButtonText: "Si, ¡Cambiar estado!",
                                                    cancelButtonText: "No, cancelar",
                                                    closeOnConfirm: false,
                                                    //closeOnCancel: false
                                                },
                                                    function (isConfirm) {
                                                        if (isConfirm) {
                                                            //swal({ title: "Eliminado!", text: "Tu archivo imaginario ha sido eliminado.", type: "success", confirmButtonText: "OK!", closeOnConfirm: false },
                                                            //function () {
                                                            //    // RESUME THE DEFAULT LINK ACTION
                                                            window.location.href = defaultAction;
                                                            return true;
                                                            //});                                                            
                                                        } else {
                                                            //swal("Cancelado", "Tu archivo imaginario es seguro :)", "error");
                                                            return false;
                                                        }
                                                    });
                                            }
                                        </script>
                                        <%-- ============ FIN Alerta de confirmación eliminación de registro ============ --%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="15%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                    <div class="form-group row">
                        <div class="col-lg-6" style="align-content: inherit">
                            Peso total de la carga:
                         <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" Enabled="false">
                         </asp:TextBox>
                        </div>

                        <div class="col-lg-6" style="align-content: inherit">
                            Costo de transporte:
                         <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control" Enabled="false">
                         </asp:TextBox>
                        </div>
                    </div>

                    <div class="modal-footer">
                          <asp:LinkButton ID="LbFinalizado" runat="server" CssClass="btn btn-success" OnClientClick="ShowBlockWindow();"> 
                                Cargamento finalizado </asp:LinkButton>
                        &nbsp;&nbsp;
                    <a href="#" data-dismiss="modal" class="btn btn-danger">Salir</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
        

    
</asp:Content>
