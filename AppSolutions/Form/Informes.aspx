<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Principal.Master" CodeBehind="Informes.aspx.vb" Inherits="AppSolutions.Informes" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style8 {
            color: #CC3300;
            font-size: large;
        }

        .auto-style9 {
            font-size: medium;
            color: #FFFFFF;
        }
    </style>
    <style type="text/css">
        .panel-DarkTurquoise {
            border-color: #5F9EA0;
        }

            .panel-DarkTurquoise > .panel-heading {
                border-color: #5F9EA0;
                color: white;
                background-color: #5F9EA0;
            }

            .panel-DarkTurquoise > a {
                color: #5F9EA0;
            }

                .panel-DarkTurquoise > a:hover {
                    color: #5F9EA0;
                }
    </style>
    <style type="text/css">
        .doc-header .doc-title {
            /*color: #40babd;*/
            color: #A4A4A4;
            margin-top: 0;
            font-size: 25px;
        }

        /*.body-green .doc-header .doc-title {
            color: #75c181;
        }

        .body-blue .doc-header .doc-title {
            color: #58bbee;
        }

        .body-orange .doc-header .doc-title {
            color: #F88C30;
        }

        .body-red .doc-header .doc-title {
            color: #f77b6b;
        }

        .body-pink .doc-header .doc-title {
            color: #EA5395;
        }

        .body-purple .doc-header .doc-title {
            color: #8A40A7;
        }*/

        .doc-section .section-title {
            font-size: 26px;
            margin-top: 0;
            margin-bottom: 0;
            font-weight: bold;
            padding-bottom: 10px;
            border-bottom: 1px solid #d7d7d7;
        }

        .section-block {
            padding-top: 15px;
            padding-bottom: 15px;
        }

            .section-block .block-title {
                margin-top: 0;
            }

            .section-block .list > li {
                margin-bottom: 10px;
            }

            .section-block .list ul > li {
                margin-top: 5px;
            }
    </style>
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
        <li class="breadcrumb-item active">Informes</li>
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
    <div class="panel-body">
            <div class="panel panel-default" id="pnMenu" runat="server">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-DarkTurquoise">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-bar-chart fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="h1"></div>
                                            <div>Rutas activas</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <span class="pull-left">
                                        <asp:LinkButton ID="lbInfVehiculoRutAct" runat="server">Ver Detalles</asp:LinkButton></span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-DarkTurquoise">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-bar-chart fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="h1"></div>
                                            <div>Rutas terminadas</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <span class="pull-left">
                                        <asp:LinkButton ID="LbRutasTerminadas" runat="server">Ver Detalles</asp:LinkButton></span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-DarkTurquoise">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-bar-chart fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="h1"></div>
                                            <div>Vehiculo con rutas activas detallado</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <span class="pull-left">
                                        <asp:LinkButton ID="lbInfVehiculoRutDetallado" runat="server">Ver Detalles</asp:LinkButton></span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="panel panel-DarkTurquoise">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-xs-3">
                                            <i class="fa fa-bar-chart fa-5x"></i>
                                        </div>
                                        <div class="col-xs-9 text-right">
                                            <div class="h1"></div>
                                            <div>Vehiculos</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer">
                                    <span class="pull-left">
                                        <asp:LinkButton ID="lbInfVehiculos" runat="server">Ver Detalles</asp:LinkButton></span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>       
            
            
            
            <%--Informe de seguimiento--%>
        <asp:Panel ID="pnInfoRutaDetallado" runat="server" Visible="false">
            <div class="panel panel-primary">
                <div class="panel-heading"><i class="fa fa-file-o" aria-hidden="true"></i>&nbsp;Rutas activas</div>
                <div class="panel-body">
                    <div class="form-group row">
                        <div class="col-lg-3">
                            Persona a cargo:     
                            <telerik:RadComboBox ID="RcPersonaCargo" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                        </telerik:RadComboBox>
                        </div>

                        <div class="col-lg-3">
                            Placa:              
                            <telerik:RadComboBox ID="RcPlaca" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>    
                         <div class="col-lg-6">
                            Rutas:
                             <telerik:RadComboBox ID="RcRutas" runat="server" Filter="Contains"
                            Width="100%" Height="200px" CssClass="form-control" required="" align="center">
                            </telerik:RadComboBox>
                        </div>
                    </div>

                    <div class="form-group row">   
                        <div class="col-lg-3">                           
                            <asp:LinkButton ID="LbBuscar" runat="server" CssClass="btn btn-success" Text="New"><i class="fa fa-search" aria-hidden="true"></i>&nbsp;Buscar&nbsp;</asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="form-group row" style="background-color: #F2F2F2">
                        <div class="col-lg-12">
                            <strong>Listado de rutas activas</strong>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-12">
                            <asp:GridView ID="gvRutasActivas" runat="server" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ID"
                                CssClass="table table-striped table-bordered table-hover" Font-Size="Small" AllowPaging="True">
                                <HeaderStyle BackColor="#E6E6E6" Font-Bold="True" ForeColor="#424242" />
                                <PagerStyle HorizontalAlign="Center" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <Columns>
                                    <asp:BoundField DataField="Vehículo" HeaderText="Vehículo">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Persona a cargo" HeaderText="Persona a cargo">
                                        <ItemStyle Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lugar origen / Lugar destino" HeaderText="Lugar origen / Lugar destino">
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbDetalles" runat="server" Text="" CommandName="VerDetalle" CommandArgument='<%# Eval("ID")%>'
                                                data-toggle="tooltip" title="Descargar detalles" ForeColor="#28a745"> 
                                            <span class="fa fa-file-excel-o"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="alert alert-info" role="alert" id="Alert" runat="server" visible="false">¡Aviso! No hay resultados para mostrar....</div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        </div>
</asp:Content>
