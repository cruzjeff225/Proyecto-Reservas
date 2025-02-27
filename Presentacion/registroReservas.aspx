<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registroReservas.aspx.cs" Inherits="Presentacion.registroReservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reservas</title>
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

            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-primary btn-logout" Text="Cerrar Sesión" OnClick="btnLogout_Click"/>
        </nav>

        <div class="show-data">
            <div class="title">
                <h3 class="mb-4">Registro de Reservas </h3>
            </div>
            <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                DataKeyNames="idReserva" 
                OnRowEditing="gvReservas_RowEditing" 
                OnRowUpdating="gvReservas_RowUpdating"
                OnRowCancelingEdit="gvReservas_RowCancelingEdit"
                OnRowDeleting="gvReservas_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="idReserva" HeaderText="ID Reserva" ReadOnly="true" />
                    <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" />
                    <asp:BoundField DataField="idHabitacion" HeaderText="Habitación" />
                    <asp:BoundField DataField="Precio" HeaderText="Total a pagar:" />
                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                    <asp:BoundField DataField="Checkin" HeaderText="Fecha de Ingreso" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="Checkout" HeaderText="Fecha de Salida" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="fechaRegistro" HeaderText="Fecha de Registro" DataFormatString="{0:yyyy-MM-dd}" ReadOnly="true"/>
                    <asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" />
                    <asp:CommandField ShowEditButton="true" EditText="<i class='fas fa-edit'></i>" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="<i class='fas fa-trash'></i>" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
