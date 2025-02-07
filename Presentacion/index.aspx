<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentacion.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
     <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <div class="login-form">
        <form runat="server">
            <div class="form-name">
                <asp:Label ID="txtPrincipal" runat="server" Text="<strong>Inicio de Sesión</strong>"></asp:Label>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control item" placeholder="Usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control item" placeholder="Contraseña"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" />
            </div>
            <div class="txt">
                <span>¿Olvidaste tu <strong>usuario/contraseña</strong>?</span>
            </div>
        </form>
    </div>
</body>
</html>
