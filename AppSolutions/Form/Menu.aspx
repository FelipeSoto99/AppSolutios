<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Principal.Master" CodeBehind="Menu.aspx.vb" Inherits="AppSolutions.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
    </ol>
</asp:Content>

<%--<asp:Content ID="Content8" ContentPlaceHolderID="main_content" runat="server">
</asp:Content>--%>

<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      

    <%--Pagina del template https://bootsnipp.com/snippets/raZdP--%>
    
        <div class="row">
            <div class="col-md-3 col-sm-4" id="btn_SolicitudDesc" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Personas.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(187, 120, 36, 0.1)">
                           <%-- <center><i class="fa fa-user-plus" style="color:#BB7824"></i></center>--%>
                             <center><i class="fa fa-user-circle" style="color:#BB7824"></i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Personas  
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Vehiculo" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Vehiculo.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(22, 160, 133, 0.1)">
                            <center><i class = "fa fa-bus" style="color:#16A085"></i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Vehiculos           
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_materiales" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Materiales.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(121, 90, 71, 0.1)">
                            <center><i class = "fa fa-file-text" style="color:#795a47"></i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Materiales           
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Rutas" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Ruta.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(250, 188, 9, 0.1)">
                            <center><i class="fa fa-building" style="color:#fabc09"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Rutas           
                            </h4>
                        </div>

                    </a>
                </div>
            </div>
              <div class="col-md-3 col-sm-4" id="btn_AsigancionRuta" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="AsignarRutas.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(51, 105, 232, 0.1)">
                            <center><i class="fa fa-truck" style="color:#3369e8"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Asignación de rutas    
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="Btn_Informes" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Informes.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(187, 120, 36, 0.1)">
                            <center><i class="fa fa-file-excel-o" style="color:#BB7824"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Informes    
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <%--<div class="col-md-3 col-sm-4" id="btn_DocumentosReq" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="DocumentosDescuento.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(213, 15, 37, 0.1)">
                            <center><i class="fa fa-book" style="color:#d50f25"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Documentos Requeridos           
                                <div class="pull-right badge" id="WrForms"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_DocTipoDescuentos" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="DocTipoDescuentos.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(187, 120, 36, 0.1)">
                            <center><i class="fa fa-book" style="color:#d50f25"> </i><i class="fa fa-dollar" style="color:#3369e8"></i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Documentos - TipoDescuento        
                                <div class="pull-right badge" id="WrForms"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_DepTipoDescuentos" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="DepTipoDescuentos.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(22, 160, 133, 0.1)">
                            <center><i class="fa fa-building" style="color:#fabc09"> </i> <i class="fa fa-dollar" style="color:#3369e8"></i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Dependencias - TipoDescuento        
                                <div class="pull-right badge" id="WrForms"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Estados" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Estados.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(250, 188, 9, 0.1)">
                            <center><i class="fa fa-stack-exchange" style="color:#fabc09"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Estados           
                                <div class="pull-right badge" id="WrGridSystem"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Periodos" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Periodos.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(121, 90, 71, 0.1)">
                            <center><i class="fa fa-refresh" style="color:#795a47"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Periodos           
                                <div class="pull-right badge" id="WrNavigation"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Informes" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="ModuloInformes.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(121, 90, 71, 0.1)">
                            <center><i class="fa fa-clone" style="color:#795a47"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Informes          
                                <div class="pull-right badge" id="WrNavigation"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_ExterderFechas" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="ExtenderFechas.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(51, 105, 232, 0.1)">
                            <center><i class="fa fa-calendar" style="color:#3369e8"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Extender fechas     
                                <div class="pull-right badge" id="WrNavigation"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>   
            <div class="col-md-3 col-sm-4" id="btn_FechasNoHabiles" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="FechasNoHabiles.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(213, 15, 37, 0.1)">
                            <center><i class="fa fa-calendar-o" style="color:#d50f25"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Fechas no hábiles     
                                <div class="pull-right badge" id="WrNavigation"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-3 col-sm-4" id="btn_Bitacora" runat="server" visible="true">
                <div class="wrimagecard wrimagecard-topimage">
                    <a href="Bitacora.aspx">
                        <div class="wrimagecard-topimage_header" style="background-color: rgba(187, 120, 36, 0.1)">
                            <center><i class="fa fa-book" style="color:#16A085"> </i></center>
                        </div>
                        <div class="wrimagecard-topimage_title">
                            <h4>Bitacora     
                                <div class="pull-right badge" id="WrNavigation"></div>
                            </h4>
                        </div>
                    </a>
                </div>
            </div>--%>
        </div>
    
    <%-- Manejo de mensajes alertas --%>
    <div class="alert alert-warning" id="pnAlert" runat="server" visible="false" style="text-align: left">
        <div class="form-group row">
            <div class="col-lg-1" style="text-align: right">
                <i class="fa fa-exclamation-circle fa-3x" aria-hidden="true"></i>
            </div>
            <div class="col-lg-11">
                <strong>
                    <asp:Label ID="lMensaje1" runat="server" Text="Label:"></asp:Label></strong><br />
                <strong>
                    <asp:Label ID="lMensaje2" runat="server" Text="Label"></asp:Label></strong>
                <asp:Label ID="lMensajeDanger" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
