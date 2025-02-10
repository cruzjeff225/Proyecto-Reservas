using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class negocioUsuario
    {
        Usuarios dataUsuarios = new Usuarios();

        public string login(string Usuario, string Contraseña)
        {
            if (dataUsuarios.validarUsuario(Usuario, Contraseña))
            {
                return "Ok";
            }
            else
            {
                return "Usuario o contraseña incorrectos. Intentalo nuevamente";
            }
        }
    }
}
