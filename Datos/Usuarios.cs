using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuarios
    {

        public bool validarUsuario(string Usuario, string Contraseña)
        {
            string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexionString)) 
            {
                con.Open();
                using (SqlCommand consulta = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña", con)) 
                {
                    consulta.Parameters.AddWithValue("@Usuario", Usuario);
                    consulta.Parameters.AddWithValue("@Contraseña", Contraseña);

                    int count = (int) consulta.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
