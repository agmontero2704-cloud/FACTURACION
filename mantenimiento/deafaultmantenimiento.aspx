<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="deafaultmantenimiento.aspx" Inherits="FACTURACION.mantenimiento.deafaultmantenimiento" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <%-- inicio de la aplicacion --%>
            <h2>&nbsp mantenimiento</h2>
            <img src="../IMAGENES/IMAGENES/CajasAlmacen.png" />
           <asp:Content ID="Content2" ContentPlaceHolderID="contenidoMenuContextual" runat="server">
    
   </asp:Content>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoPrincipal" runat="server">

    <asp:ContentPlaceHolder ID="contenidoPrincipal" runat="server">
    </asp:ContentPlaceHolder>



            
        </div>
    </form>
</body>
</html>
