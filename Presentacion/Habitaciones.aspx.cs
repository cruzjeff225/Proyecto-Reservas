using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Presentacion
{
    public partial class Habitaciones : System.Web.UI.Page
    {
        negocioHabitaciones NegocioHabitaciones = new negocioHabitaciones();
        negocioUsuario NegocioUsuarios = new negocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                CargarHabitaciones();
                CargarUsuarios();
            }
        }

        protected void CargarUsuarios()
        {
            ddlUsuarios.DataSource = NegocioUsuarios.obtenerUsuarios();
            ddlUsuarios.DataTextField = "Usuario";
            ddlUsuarios.DataValueField = "idUsuario";
            ddlUsuarios.DataBind();
        }

        protected void CargarHabitaciones()
        {
            gvHabitaciones.DataSource = NegocioHabitaciones.obtenerHabitaciones();
            gvHabitaciones.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int Numero = Convert.ToInt32(txtNumero.Text);
            string Descripcion = txtDescripcion.Text;
            int Huespedes = Convert.ToInt32(txtHuespedes.Text);
            int idUsuario = int.Parse(ddlUsuarios.SelectedValue);

            bool exito = NegocioHabitaciones.agregarHabitaciones(Numero, Descripcion, Huespedes, idUsuario);
            if (exito)
            {
                Response.Write("<script>alert('Habitación agregada con éxito');</script>");
                CargarHabitaciones();
            }
            else
            {
                Response.Write("<script>alert('Error al agregar la habitación');</script>");
            }
        }

        protected void gvHabitaciones_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvHabitaciones.EditIndex = e.NewEditIndex;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int ID = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvHabitaciones.Rows[e.RowIndex];

            int Numero = int.Parse((row.Cells[1].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            string Descripcion = (row.Cells[2].Controls[0] as System.Web.UI.WebControls.TextBox).Text;
            int Huespedes = int.Parse((row.Cells[3].Controls[0] as System.Web.UI.WebControls.TextBox).Text);
            int idUsuario = int.Parse((row.Cells[4].Controls[0] as System.Web.UI.WebControls.TextBox).Text);

            if (NegocioHabitaciones.modificarHabitaciones(ID, Numero, Descripcion, Huespedes, idUsuario))
            {
                gvHabitaciones.EditIndex = -1;
                CargarHabitaciones();
            }
        }

        protected void gvHabitaciones_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvHabitaciones.EditIndex = -1;
            CargarHabitaciones();
        }

        protected void gvHabitaciones_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(gvHabitaciones.DataKeys[e.RowIndex].Value);

            if (NegocioHabitaciones.eliminarHabitaciones(ID))
            {
                CargarHabitaciones();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void gvHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {

        }
    }
}