<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Principal.Master" CodeBehind="Vehiculo.aspx.vb" Inherits="AppSolutions.Vehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script>
        function FuncionModaladdVehiculos() {
            $("#ModaladdVehiculos").modal("show")
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
        <li class="breadcrumb-item active">Vehículos</li>
    </ol>
</asp:Content>
<%--<asp:Content ID="Content8" ContentPlaceHolderID="main_content" runat="server">
</asp:Content>--%>

<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="pnVehiculo" runat="server" Visible="true">
        <div class="panel panel-default" id="xxx" runat="server">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-lg-8">
                        Vehículos 
                    </div>
                    <div class="col-lg-4" style="text-align: right">
                        <asp:LinkButton ID="lbNew" runat="server" CssClass="btn btn-primary" OnClientClick="ShowBlockWindow();"> 
                            <span class="fa fa-plus"></span>&nbsp;Nuevo 
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
                    <div class="col-lg-3">
                        Placa:
                         <asp:TextBox ID="txtPlacaBc" runat="server" CssClass="form-control">
                         </asp:TextBox>
                    </div>

                    <div class="col-lg-3">
                        Capacidad de carga:
                         <asp:TextBox ID="txtCapacidadBc" runat="server" CssClass="form-control">
                         </asp:TextBox>
                    </div>

                     <div class="col-lg-3">
                        Activos
                            <asp:DropDownList ID="ddlActivos" runat="server" CssClass="form-control" Style="text-transform: uppercase">
                                <asp:ListItem Value=-1 Selected="True"> Seleccionar estado </asp:ListItem>
                                <asp:ListItem Value=0> No </asp:ListItem>
                                <asp:ListItem Value=1 > Si </asp:ListItem>
                            </asp:DropDownList>
                    </div>

                    <div class="col-lg-2" style="text-align: left">
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
                        <asp:GridView ID="GVVehiculo" runat="server" AutoGenerateColumns="False" CellPadding="3"
                            CssClass="table table-striped table-bordered table-hover" Font-Size="Small" AllowPaging="True"
                            DataKeyNames="VehiculoID,SwActivo,DíasFaltantesTecno,DíasFaltantesSoat,DíasFaltantesRegistroCarga">
                            <HeaderStyle BackColor="#E6E6E6" Font-Bold="True" ForeColor="#424242" />
                            <PagerStyle HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <Columns>
                                <asp:BoundField DataField="VehiculoID" HeaderText="Cod. Interno">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Placa" HeaderText="Placa"  >
                                    <ItemStyle Width="20%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CapacidadCarga" HeaderText="Capacidad de carga">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vencimiento tecnomecanica">
                                    <ItemTemplate>
                                        <asp:Label ID="lVencimientoTecno" runat="server" Text='<%# Bind("VencimientoTecno")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vencimiento del soat">
                                    <ItemTemplate>
                                        <asp:Label ID="lVencimientoSoat" runat="server" Text='<%# Bind("VencimientoSoat")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vencimiento del la tarjeta de transporte de carga">
                                    <ItemTemplate>
                                        <asp:Label ID="lVencimientoRegistro" runat="server" Text='<%# Bind("VencimientoRegistroCarga")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label ID="lEstado" runat="server" Text='<%# Bind("SwActivo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEditar" runat="server" CausesValidation="False" CommandName="Editar" CssClass="fa fa-pencil-square-o  fa-lg" Text=""
                                            data-toggle="tooltip" title="Editar Datos" OnClientClick="ShowBlockWindow();" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>                                                                       
                                        </asp:LinkButton>

                                        &nbsp;
                                        <asp:LinkButton ID="LbDesactivar" runat="server" CommandName="DesActivar" CssClass="fa fa-toggle-on  fa-lg" Text=""  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                            data-toggle="tooltip" title="Activar/Desactivar"  OnClientClick="return deletealert1(this, event);">
                                        </asp:LinkButton>
                                         <%-- ============ Alerta de confirmación desactivar de registro ============ --%>
                                        <script>
                                            function deletealert1(ctl, event) {
                                                // STORE HREF ATTRIBUTE OF LINK CTL (THIS) BUTTON
                                                var defaultAction = $(ctl).prop("href");
                                                // CANCEL DEFAULT LINK BEHAVIOUR
                                                event.preventDefault();
                                                swal({
                                                    title: "¿Está Seguro de cambiar el estado de este registro?",
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
                                        <%-- ============ FIN Alerta de confirmación desactivar de registro ============ --%>


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

    <!-- Modal Para agregar Materiles-->
    <div id="ModaladdVehiculos" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <strong>
                        <asp:Label ID="lblEvento" runat="server" Text="Crear vehículo"></asp:Label></strong>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-lg-6">
                            Placa:
                            <asp:TextBox ID="txtPlacaAdd"  runat="server" CssClass="form-control" required=""  Style="text-transform: uppercase;" > </asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            Capacidad de carga:
                            <asp:TextBox ID="txtCapacidadAdd" runat="server" CssClass="form-control" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>                        
                    </div>
                    <div class="form-group row">   
                        <div class="col-lg-6">
                            Soat:
                            <asp:TextBox ID="TxtSoatAdd" runat="server" CssClass="form-control" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            Fecha vencimiento del soat:
                                     <div class='input-group date' id='rdpFechaVencSoat'>
                                         <input type='text' class="form-control" id="dtpFechaVencSoat" runat="server" placeholder="dd/mm/aaaa"
                                             data-toggle="tooltip" title="Formato dd/mm/aaaa" data-placement="left"  required=""/>
                                         <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                     </div>
                            <script type="text/javascript">
                                $(function () {
                                    $('#rdpFechaVencSoat').datetimepicker({
                                        format: 'DD/MM/YYYY'
                                    });
                                });
                            </script>
                        </div>
                    </div>
                    <div class="form-group row">       
                        <div class="col-lg-6">
                            Técnico Mecánica:
                            <asp:TextBox ID="TxtTecnoAdd" runat="server" CssClass="form-control" TextMode="Number" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>

                        <div class="col-lg-6">
                            Fecha vencimiento tecnomecanica:
                                     <div class='input-group date' id='rdpFechaVencTecno'>
                                         <input type='text' class="form-control" id="dtpFechaVencTecno" runat="server" required="" placeholder="dd/mm/aaaa"
                                             data-toggle="tooltip" title="Formato dd/mm/aaaa" data-placement="left" />
                                         <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                     </div>
                            <script type="text/javascript">
                                $(function () {
                                    $('#rdpFechaVencTecno').datetimepicker({
                                        format: 'DD/MM/YYYY'
                                    });
                                });
                            </script>
                        </div>
                    </div>     
                    <div class="form-group row">       
                        <div class="col-lg-6">
                            Tarjeta Registro de transporte de carga:
                            <asp:TextBox ID="txtRegistroCargaAdd" runat="server" CssClass="form-control" TextMode="Number" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>

                        <div class="col-lg-6">
                            Fecha vencimiento registro de transporte de carga:
                                     <div class='input-group date' id='rdpFechaVencRegistroCarga'>
                                         <input type='text' class="form-control" id="dtpFechaVencRegistroCarga" runat="server" required="" placeholder="dd/mm/aaaa"
                                             data-toggle="tooltip" title="Formato dd/mm/aaaa" data-placement="left" />
                                         <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                     </div>
                            <script type="text/javascript">
                                $(function () {
                                    $('#rdpFechaVencRegistroCarga').datetimepicker({
                                        format: 'DD/MM/YYYY'
                                    });
                                });
                            </script>
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
        

    
</asp:Content>
