<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Habitaciones.aspx.cs" Inherits="Presentacion.Habitaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Habitaciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar">
            <a class="navbar-brand">Reservas</a>
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-primary btn-logout" Text="Cerrar Sesión" OnClick="btnLogout_Click" />
        </nav>
        <div class="show-data">
            <div class="title">
                <h3 class="mb-4">Lista de Habitaciones </h3>
            </div>
            <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                DataKeyNames="idHabitaciones" OnRowEditing="gvHabitaciones_RowEditing"
                OnRowUpdating="gvHabitaciones_RowUpdating"
                OnRowCancelingEdit="gvHabitaciones_RowCancelingEdit"
                OnRowDeleting="gvHabitaciones_RowDeleting" OnSelectedIndexChanged="gvHabitaciones_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="idHabitaciones" HeaderText="ID" />
                    <asp:BoundField DataField="Numero" HeaderText="Numero" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Huespedes" HeaderText="Huespedes" />
                    <asp:BoundField DataField="idUsuario" HeaderText="ID Usuario" />
                    <asp:CommandField ShowEditButton="true" EditText="<i class='fas fa-edit'></i>" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="<i class='fas fa-trash'></i>" />
                </Columns>
            </asp:GridView>
            <br />
            <div class="title">
                <h3 class="mb-4">Agregar Nueva Habitación</h3>
            </div>
            <div class="mb-3 row">
                <label for="txtNumero" class="col-sm-2 col-form-label">Número:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Número"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtDescripcion" class="col-sm-2 col-form-label">Descripción:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Descripción"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtHuespedes" class="col-sm-2 col-form-label">Huéspedes:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtHuespedes" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Huéspedes"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtIdUsuario" class="col-sm-2 col-form-label">ID Usuario:</label>
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-select">
                    </asp:DropDownList>
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
