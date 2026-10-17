<%-- Página de inicio del sistema. Usa el master principal y muestra los datos del usuario autenticado. --%>
<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/LOGIN/MainMaster.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FACTURACION.HomePage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceholder" runat="server">
    <%-- Sección de encabezado (vacía por ahora) --%>
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceholder" runat="server">
    <div class="mantenimiento-card">
        <h2>Bienvenido al Sistema de Facturaci&oacute;n</h2>
        <div class="mantenimiento-img-container">
            <img src="/IMAGENES/CajasAlmacen.png" alt="Cajas Almacen" class="img-cajas-almacen" />
        </div>
    </div>

    <%-- Etiquetas ocultas que almacenan los datos del usuario obtenidos de sesión --%>
    <asp:Label ID="codeLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="usernameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="nameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="surnameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="departmentLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="roleLabel" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
