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
                Response.Redirect("principal.aspx");
            }
            else 
            {
                lblError.Text = resultado;
                lblError.Visible = true;
            }
        }
    }
}