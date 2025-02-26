using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Presentacion
{
	public partial class Reservas : System.Web.UI.Page
	{
		negocioReserva NegocioReserva = new negocioReserva();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["Usuario"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                cargarHabitaciones();
                cargarDescuentos();
            }
		}

		protected void calcularPrecioFinal(object sender, EventArgs e)
		{
			try
			{
				if (DateTime.TryParse(txtCheckin.Text, out DateTime checkin) &&
						DateTime.TryParse(txtCheckout.Text, out DateTime checkout) &&
						decimal.TryParse(txtPrecioInicial.Text, out decimal precioInicial))
				{
					int diasTotal = (checkout - checkin).Days;
					txtDiasTotal.Text = diasTotal.ToString();

					if (diasTotal <= 0)
					{
						txtPrecioFinal.Text = "0.00";
						return;
					}

					decimal precioTotal = precioInicial * diasTotal;

					if (decimal.TryParse(ddlDescuento.SelectedValue, out decimal descuento))
					{
						decimal precioFinal = precioTotal - ((precioTotal * descuento) / 100);
						txtPrecioFinal.Text = precioFinal.ToString("0.00");
					}
				}
			}
			catch (Exception ex)
			{
				txtPrecioFinal.Text = "Error al obtener precio";
			}
		}

		protected void ddlHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
		{
			negocioReserva NegocioReserva = new negocioReserva();
			DataTable dt = NegocioReserva.obtenerHabitaciones();

			int idHabitacion;
			if (int.TryParse(ddlHabitaciones.SelectedValue, out idHabitacion))
				{
                DataRow[] fila = dt.Select("idHabitaciones = " + idHabitacion);

                if (fila.Length > 0)
                {
                    txtPrecioInicial.Text = fila[0]["Precio"].ToString();

                    calcularPrecioFinal(sender, e);
                }
            }
        }

		protected void txtCheckin_TextChanged(object sender, EventArgs e)
		{
			calcularPrecioFinal(sender, e);
		}

		protected void txtCheckout_TextChanged(object sender, EventArgs e)
		{
			calcularPrecioFinal(sender, e);
		}

		private void cargarHabitaciones()
		{
			negocioReserva NegocioReserva = new negocioReserva();
			DataTable dt = NegocioReserva.obtenerHabitaciones();

			ddlHabitaciones.DataSource = dt;
			ddlHabitaciones.DataTextField = "Habitacion";
			ddlHabitaciones.DataValueField = "idHabitaciones";
			ddlHabitaciones.DataBind();

			ddlHabitaciones.Items.Insert(0, new ListItem("-- Selecciona una habitación --", "0"));
		}

		private void cargarDescuentos()
		{
			ddlDescuento.Items.Clear();
			ddlDescuento.Items.Add(new ListItem("Sin descuento", "0"));
			ddlDescuento.Items.Add(new ListItem("10% de descuento", "10"));
			ddlDescuento.Items.Add(new ListItem("20% de descuento", "20"));
		}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            negocioReserva NegocioReserva = new negocioReserva();

            int idCliente = Convert.ToInt32(txtIdCliente.Text);
			int idHabitacion = Convert.ToInt32(ddlHabitaciones.SelectedValue);
			int totalDias = Convert.ToInt32(txtDiasTotal.Text);
			decimal descuento = decimal.Parse(ddlDescuento.SelectedValue);
			DateTime checkin = DateTime.Parse(txtCheckin.Text);
			DateTime checkout = DateTime.Parse(txtCheckout.Text);
			int idUsuario = Convert.ToInt32(Session["idUsuario"]);

			decimal precioFinal = decimal.Parse(txtPrecioFinal.Text);

			bool exito = NegocioReserva.agregarReserva(idCliente, idHabitacion, totalDias, descuento, checkin, checkout, idUsuario);
			if (exito)
            {
                Response.Write("<script>alert('Cliente agregado con éxito');</script>");
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Error al agregar reserva');</script>");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
			Response.Redirect("index.aspx");
        }
    }

}