<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Presentacion.Clientes" %>

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
        <div class="show-data">
            <div class="title">
                <h3 class="mb-4">Lista de Clientes</h3>
            </div>
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                DataKeyNames="idCliente" 
                OnRowEditing ="gvClientes_RowEditing"
                OnRowUpdating ="gvClientes_RowUpdating"
                OnRowCancelingEdit ="gvClientes_RowCancelingEdit"
                OnRowDeleting ="gvClientes_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="DUI" HeaderText="DUI" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                    <asp:CommandField ShowEditButton="true" EditText="<i class='fas fa-edit'></i>" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="<i class='fas fa-trash'></i>" />
                </Columns>
            </asp:GridView>
            <br />
            <div class="title">
                <h3 class="mb-4">Agregar Nuevo Cliente</h3>
            </div>
            <div class="mb-3 row">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Nombre"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtDUI" class="col-sm-2 col-form-label">DUI:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtDUI" runat="server" CssClass="form-control placeholder-cursiva" placeholder="DUI"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtTelefono" class="col-sm-2 col-form-label">Teléfono:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Teléfono"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtCorreo" class="col-sm-2 col-form-label">Correo:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Correo"></asp:TextBox>
                </div>
            </div>

            <div class="mb-3 row">
                <label for="txtDepartamento" class="col-sm-2 col-form-label">Departamento:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control placeholder-cursiva" placeholder="Departamento"></asp:TextBox>
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
