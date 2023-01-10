<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/PlantillasMaster/Secundario.Master" CodeBehind="Login.aspx.vb" Inherits="AppSolutions.Login" %>
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
<asp:Content ID="Content6" ContentPlaceHolderID="navbar" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Main_pagination" runat="server">
</asp:Content>
<%--<asp:Content ID="Content8" ContentPlaceHolderID="main_content" runat="server">
</asp:Content>--%>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row" style="margin-top: 50px">
        <div class="col-md-8">
            <div class="jumbotron" style="height: 250px">
                <h2>Solutions S.A.</h2>
                <p align="justify">
                </p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="modal-content" style="height: 250px">
                <div class="panel-heading">
                    <h3 class="panel-title">Inicio de sesión</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div style="margin-left: 10px; margin-right: 10px">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1" style="background-color: #d3d3d3"><i class="fa fa-user fa-1x"></i></span>
                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div style="margin-left: 10px; margin-right: 10px">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon2" style="background-color: #d3d3d3"><i class="fa fa-unlock fa-1x"></i></span>
                                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-6">
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>
                    </div>
                    <div class="form-group" style="text-align: center">
                        <asp:LinkButton ID="lbIngresar" runat="server" CssClass="btn btn-success" Text="Ingresar" Height="30px" Width="200px"
                            OnClientClick="ShowBlockWindow();"> &nbsp;Ingresar&nbsp;<span class="fa fa-sign-in"></span> 
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>
