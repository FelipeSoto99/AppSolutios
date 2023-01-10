<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Principal.Master" CodeBehind="Personas.aspx.vb" Inherits="AppSolutions.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script>
        function FuncionModaladdPersonas() {
            $("#ModaladdPersonas").modal("show")
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
        <li class="breadcrumb-item active">Personas</li>
    </ol>
</asp:Content>

<%--<asp:Content ID="Content8" ContentPlaceHolderID="main_content" runat="server">
</asp:Content>--%>

<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="pnPersonas" runat="server" Visible="true">
        <div class="panel panel-default" id="Pnprincipal" runat="server">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-lg-8">
                        Personas 
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
                    <div class="col-lg-4">
                        Nombre:
                         <asp:TextBox ID="txtNombreBc" runat="server" CssClass="form-control">
                         </asp:TextBox>
                    </div>

                    <div class="col-lg-4">
                        Apellido:
                         <asp:TextBox ID="txtApellidoBc" runat="server" CssClass="form-control">
                         </asp:TextBox>
                    </div>

                    <div class="col-lg-4">
                        Identificación:
                         <asp:TextBox ID="txtIdentificacionBc" runat="server" CssClass="form-control">
                         </asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-lg-4">
                        Activos
                            <asp:DropDownList ID="ddlActivos" runat="server" CssClass="form-control" Style="text-transform: uppercase">
                                <asp:ListItem Value=-1 Selected="True">Seleccionar estado</asp:ListItem>
                                <asp:ListItem Value=0>No</asp:ListItem>
                                <asp:ListItem Value=1 >Si</asp:ListItem>
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
                        <asp:GridView ID="GVPersonas" runat="server" AutoGenerateColumns="False" CellPadding="10"
                            CssClass="table table-striped table-bordered table-hover" Font-Size="Small" AllowPaging="True"
                            DataKeyNames="PersonaID,SwActivo,DíasFaltantes">
                            <HeaderStyle BackColor="#E6E6E6" Font-Bold="True" ForeColor="#424242" />
                            <PagerStyle HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#ffffcc" />
                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                            <Columns>
                                <asp:BoundField DataField="PersonaID" HeaderText="Cod. Interno"  Visible="false">
                                    <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre">
                                    <ItemStyle Width="45%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumeroIdentificacion" HeaderText="Número identificación">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Telefono" HeaderText="Número de contacto">
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Vencimiento de la licencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lVencimiento" runat="server" Text='<%# Bind("Vencimiento")%>'></asp:Label>
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

    <!-- Modal Para agregar personas-->
    <div id="ModaladdPersonas" class="modal fade" role="dialog" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <strong>
                        <asp:Label ID="lblEvento" runat="server" Text="Crear personas"></asp:Label></strong>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-lg-6">
                            Nombres:
                            <asp:TextBox ID="txtNombreAdd" runat="server" CssClass="form-control" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            Apellidos:
                            <asp:TextBox ID="txtapellidoAdd" runat="server" CssClass="form-control" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-4">
                            Tipo de identificación:
                            <asp:DropDownList ID="ddlTipoIdentificacionAdd" runat="server" CssClass="form-control" required=""></asp:DropDownList>
                        </div>

                        <div class="col-lg-4">
                            Número de identificación:
                            <asp:TextBox ID="txtNumIdentificacionAdd" runat="server" CssClass="form-control" required="" Style="text-transform: uppercase"> </asp:TextBox>
                        </div>

                         <div class="col-lg-4">
                            Telefono:
                            <asp:TextBox ID="txtTelefonoAdd" TextMode="Number" runat="server" CssClass="form-control" required=""> </asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group row">                     

                        <div class="col-lg-4">
                            N° de licencia de conducción:
                            <asp:TextBox ID="txtNumLicencia" TextMode="Number" runat="server" CssClass="form-control" required=""> </asp:TextBox>
                        </div>

                        <div class="col-lg-6">
                            Fecha vencimiento de licencia de conducción:
                                     <div class='input-group date' id='rdpFechaVenc'>
                                         <input type='text' class="form-control" id="dtpFechaVenc" runat="server" placeholder="dd/mm/aaaa"
                                             data-toggle="tooltip" title="Formato dd/mm/aaaa" data-placement="left" />
                                         <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                     </div>
                            <script type="text/javascript">
                                $(function () {
                                    $('#rdpFechaVenc').datetimepicker({
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
