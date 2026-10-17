<%-- Página única del módulo de Mantenimiento. Agrupa en secciones todas las opciones
    de mantenimiento y permite navegar entre ellas mediante anclas (#id). --%>
<%@ Page Title="Mantenimiento" Language="C#" MasterPageFile="~/mantenimiento/MaintenanceMaster.master" AutoEventWireup="true" CodeBehind="MaintenancePage.aspx.cs" Inherits="FACTURACION.mantenimiento.MaintenancePage" %>

<asp:Content ID="maintenanceContent" ContentPlaceHolderID="maintenanceContentPlaceholder" runat="server">
    <div>
        <h2>Mantenimiento</h2>
        <img src="../IMAGENES/CajasAlmacen.png" alt="Mantenimiento" />
        <p>Seleccione una opci&oacute;n del men&uacute; de mantenimiento.</p>

        <%-- Sección: Crear Empresa --%>
        <section id="empresa">
            <h3>Crear Empresa</h3>
        </section>

        <%-- Sección: Crear Cajas --%>
        <section id="cajas">
            <h3>Crear Cajas</h3>
        </section>

        <%-- Sección: Crear Bodegas --%>
        <section id="bodegas">
            <h3>Crear Bodegas</h3>
        </section>

        <%-- Sección: Crear Clientes --%>
        <section id="clientes">
            <h3>Crear Clientes</h3>
        </section>

        <%-- Sección: Crear Productos --%>
        <section id="productos">
            <h3>Crear Productos</h3>
        </section>

        <%-- Sección: Crear Suplidores --%>
        <section id="suplidores">
            <h3>Crear Suplidores</h3>
        </section>

        <%-- Sección: Crear Código de Barra y QR --%>
        <section id="codigo">
            <h3>Crear Codigo Barra y QR</h3>
        </section>
    </div>
</asp:Content>
