using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Presentacion
{
	public partial class registroReservas : System.Web.UI.Page
	{
        negocioReserva NegocioReserva = new negocioReserva();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["Usuario"] == null)
            {
            }
            if (!IsPostBack)
            {
                cargarReservas();
            }
        }

        protected void cargarReservas()
        {
            gvReservas.DataSource = NegocioReserva.obtenerReservas();
            gvReservas.DataBind();
        }

        protected void gvReservas_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvReservas.EditIndex = e.NewEditIndex;
            cargarReservas();
        }

        protected void gvReservas_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvReservas.EditIndex = -1;
            cargarReservas();
        }

        protected void gvReservas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int idReserva = Convert.ToInt32(gvReservas.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvReservas.Rows[e.RowIndex];

            int idCliente = Convert.ToInt32((row.Cells[1].Controls[0] as TextBox).Text);
            int idHabitacion = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text);
            decimal Precio = Convert.ToDecimal((row.Cells[3].Controls[0] as TextBox).Text);
            decimal Descuento = Convert.ToDecimal((row.Cells[4].Controls[0] as TextBox).Text);
            DateTime Checkin = Convert.ToDateTime((row.Cells[5].Controls[0] as TextBox).Text);
            DateTime Checkout = Convert.ToDateTime((row.Cells[6].Controls[0] as TextBox).Text);

            if (NegocioReserva.editarReserva(idReserva, idCliente, idHabitacion, Precio, Descuento, Checkin, Checkout)) ;
            {
                gvReservas.EditIndex = -1;
                cargarReservas();
            }
        }

        protected void gvReservas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int idReserva = Convert.ToInt32((gvReservas.DataKeys[e.RowIndex].Value));

            if (NegocioReserva.eliminarReserva(idReserva))
            {
                cargarReservas();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}