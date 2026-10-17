<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/LOGIN/principal.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FACTURACION._Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentMenu" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
</asp:Content>

<asp:Content ID="ContentPrincipal" ContentPlaceHolderID="contenidoPrincipal" runat="server">
    <div style="text-align: center; padding-top: 30px;">
        <h2>Bienvenido al Sistema de Facturaci&oacute;n</h2>
        <img src="/IMAGENES/CajasAlmacen.png" alt="Cajas Almacen" style="max-width: 790px; height: auto;" />
    </div>

    <asp:Label ID="LblCodigo" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="LblUsuario" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="LblNombre" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="LblApellido" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="LblDepartamento" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="LblCargo" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
