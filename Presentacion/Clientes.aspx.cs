using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Presentacion
{
	public partial class Clientes : System.Web.UI.Page
	{
		negocioCliente NegocioCliente = new negocioCliente();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Usuario"] == null)
			{
				Response.Redirect("index.aspx");
			}
			if (!IsPostBack)
			{
				cargarClientes();
			}

		}

		protected void cargarClientes()
		{
			gvClientes.DataSource = NegocioCliente.obtenerClientes();
			gvClientes.DataBind();
		}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
			string Nombre = txtNombre.Text;
			int DUI = Convert.ToInt32(txtDUI.Text);
			int Telefono = Convert.ToInt32(txtTelefono.Text);
			string Correo = txtCorreo.Text;
			string Departamento = txtDepartamento.Text;
			DateTime fechaRegistro = DateTime.Now;
			int idUsuario = Convert.ToInt32(Session["idUsuario"]);

			bool exito = NegocioCliente.agregarCientes(Nombre, DUI, Telefono, Correo, Departamento, fechaRegistro, idUsuario);
			if (exito)
			{
				Response.Write("<script>alert('Cliente agregado con éxito');</script>");
				cargarClientes();
            }
			else 
			{
				Response.Write("<script>alert('Error al agregar cliente');</script>");
            }
        }

		protected void gvClientes_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e) 
		{
			gvClientes.EditIndex = e.NewEditIndex;
			cargarClientes();
		}

		protected void gvClientes_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
		{
			int idCliente = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
			GridViewRow row = gvClientes.Rows[e.RowIndex];

			string Nombre = (row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
			int DUI = int.Parse((row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
			int Telefono = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string Correo = (row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            string Departamento = (row.Cells[5].Controls[0] as System.Web.UI.WebControls.TextBox).Text;

			if(NegocioCliente.editarClientes(idCliente, Nombre, DUI, Telefono, Correo, Departamento)) 
			{
				gvClientes.EditIndex = -1;
				cargarClientes();
			}
        }

		protected void gvClientes_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e) 
		{
			gvClientes.EditIndex = -1;
			cargarClientes();
		}

        protected void gvClientes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idCliente = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);

            if (NegocioCliente.eliminarClientes(idCliente))
            {
                cargarClientes();
            }
        }
    }
}