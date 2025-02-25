using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuarios
    {
        string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public bool validarUsuario(string Usuario, string Contraseña)
        {

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

        public DataTable obtenerUsuarios()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idUsuario, Usuario FROM Usuarios", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int obtenerIdUsuario(string Usuario) 
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idUsuario FROM Usuarios WHERE Usuario = @Usuario", con))
                {
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }

}