<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="Presentacion.Reservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Clientes</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
                <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">Reservas</a>

            <div class="collapse navbar-collapse">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="Clientes.aspx">Clientes</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Reservas.aspx">Reservas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="registroReserva.aspx">Registro Reservas</a>
                    </li>
                </ul>
            </div>

            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-primary btn-logout" Text="Cerrar Sesión" OnClick="btnLogout_Click" />
        </nav>
        <div class="show-data">
            <br />
            <div class="title">
                <h3 class="mb-4">Agregar Nueva Reserva</h3>
            </div>
            <div class="mb-3 row">
                <label for="txtIdCliente" class="col-sm-2 col-form-label">ID Cliente:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control placeholder-cursiva" placeholder="ID Cliente"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtHabitaciones" class="col-sm-2 col-form-label">Habitación:</label>
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlHabitaciones" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlHabitaciones_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtPrecioInicial" class="col-sm-2 col-form-label">Precio Inicial:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPrecioInicial" runat="server" CssClass="form-control placeholder-cursiva" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtDescuento" class="col-sm-2 col-form-label">Descuento:</label>
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlDescuento" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="calcularPrecioFinal"> 
                    </asp:DropDownList>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtCheckin" class="col-sm-2 col-form-label">Fecha de Ingreso:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtCheckin" runat="server" CssClass="form-control placeholder-cursiva" TextMode="Date" AutoPostBack="true" OnTextChanged="calcularPrecioFinal"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtCheckout" class="col-sm-2 col-form-label">Fecha de Salida:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtCheckout" runat="server" CssClass="form-control placeholder-cursiva" TextMode="Date" AutoPostBack="true" OnTextChanged="calcularPrecioFinal"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtDiasTotal" class="col-sm-2 col-form-label">Días en Estadía:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtDiasTotal" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Total Días de Estadía" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtPrecioFinal" class="col-sm-2 col-form-label">Precio Final:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPrecioFinal" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Precio Final" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <div class="col-sm-8">
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-add" Text="Agregar" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

