<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRMLOGIN.aspx.cs" Inherits="FACTURACION.LOGIN.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=1280, initial-scale=1.0"/>
    <!-- Titulo de la aplicación -->
    <title>Sistema Facturación</title>

    <!-- Icono que identifica la aplicación -->
    <link rel="shortcut icon" type="image/x-icon" href="/IMAGENES/Favicon.png"/>

    <!-- Colocar fondo y fijar resolución a 1280x1024 -->
    <style type="text/css">
        html {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #0b0f19;
        }
        body {
            width: 1280px;
            height: 1024px;
            min-height: 1024px;
            max-width: 1280px;
            max-height: 1024px;
            margin: 0 auto;
            position: relative;
            background-image: url('/IMAGENES/Fondo1.jpg');
            background-size: 1280px 1024px;
            background-repeat: no-repeat;
            background-position: center top;
            box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.85);
            overflow: hidden;
            box-sizing: border-box;
        }
        #contenedorLogin {
            width: 1280px;
            height: 1024px;
            position: relative;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedorLogin">
            <asp:PlaceHolder ID="PhUnused" runat="server" Visible="false">
                <asp:Button ID="Button1" runat="server" Text="Button" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                <asp:Panel ID="Panel2" runat="server"></asp:Panel>
                <asp:Panel ID="Panel3" runat="server"></asp:Panel>
            </asp:PlaceHolder>
            <asp:Timer ID="Timer1" runat="server" Enabled="false"></asp:Timer>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:Image ID="ImgCajasAlmacen" runat="server"
                ImageUrl="~/Imagenes/CajasAlmacen.png" CssClass="CajasAlmacen" Height="430px"
                Width="790px" />

            <div id="Logo">
                <h1>SISTEMA</h1>
                <h3>DE FACTURACION ELECTRONICA</h3>
            </div>

            <asp:Panel ID="PnlAcceso" runat="server" BorderColor="Black" BorderStyle="Solid"
                CssClass="PnlAcceso" Width="520px" Height="268px"
                BackImageUrl="~/Imagenes/FondoLogin.png">

                <asp:Panel ID="PnlControl" runat="server" Height="37px" Width="520px"
                    BackColor="#3399FF">
                    <asp:Label ID="LblControl" runat="server" Text="Control de Acceso" Font-Bold="True"
                        ForeColor="White" Font-Size="Larger" CssClass="LblControl"></asp:Label>
                </asp:Panel>

                <asp:Image ID="ImgCerradura" runat="server"
                    ImageUrl="~/Imagenes/CerraduraRoja.png" Height="85px" Width="95px"
                    CssClass="ImgCerradura" />

                <asp:Label ID="LblUsuario" runat="server" Text="Usuario.:" Font-Bold="True"
                    ForeColor="White" Font-Size="Large" CssClass="LblUsuario"></asp:Label>

                <asp:Label ID="LblClave" runat="server" Text="Clave.:" Font-Bold="True"
                    ForeColor="White" Font-Size="Large" CssClass="LblClave"></asp:Label>

                <asp:TextBox ID="TxtUsuario" runat="server" Font-Bold="True" ToolTip="Introdusca su Usuario"
                    Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled"
                    CssClass="TxtUsuario"></asp:TextBox>

                <asp:TextBox ID="TxtClave" runat="server" Font-Bold="True" ToolTip="Introdusca su Clave"
                    Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled"
                    CssClass="TxtClave" TextMode="Password"></asp:TextBox>

                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" Font-Bold="True"
                    ToolTip="Presione para Aceptar la validacion" BorderStyle="Outset" Width="80px"
                    Height="40px" CssClass="BtnAceptar" OnClick="BtnAceptar_Click"/>

                <asp:Panel ID="PnlMensaje" runat="server" Height="37px" Width="520px"
                    CssClass="PnlMensaje" BackColor="Black">
                    <asp:Label ID="LblMensaje" runat="server" Text="Mensaje.:" Font-Bold="True"
                        ForeColor="White" CssClass="LblMensaje"></asp:Label>
                </asp:Panel>
            </asp:Panel>

            <asp:Timer ID="Timer2" runat="server" Interval="5000" Enabled="False"
                OnTick="Timer1_Tick1"></asp:Timer>
        </div>
    </form>
</body>
</html>
