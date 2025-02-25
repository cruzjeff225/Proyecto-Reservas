using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Presentacion
{
    public partial class index : System.Web.UI.Page
    {
        negocioUsuario NegocioUsuario = new negocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Usuario = txtUser.Text.Trim();
            string Contraseña = txtPass.Text.Trim();

            string resultado = NegocioUsuario.login(Usuario, Contraseña);

            if(resultado == "Ok") 
            {
                int idUsuario = NegocioUsuario.obtenerIdUsuario(Usuario);
                if (idUsuario > 0)
                {
                    Session["Usuario"] = Usuario;
                    Session["idUsuario"] = idUsuario;
                    Response.Redirect("Habitaciones.aspx");
                }
                else 
                {
                    lblError.Text = "No se pudo obtener el ID de Usuario";
                    lblError.Visible = true;
                }
            }
            else 
            {
                lblError.Text = resultado;
                lblError.Visible = true;
            }
        }
    }
}