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
    public class Habitaciones
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable obtenerHabitaciones()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Habitaciones", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool agregarHabitaciones(int Numero, string Descripcion, int Huespedes, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Habitaciones" + "(Numero, Descripcion, Huespedes, idUsuario)" +
                    "VALUES (@numero, @descripcion, @huespedes, @idUsuario)", con))
                {
                    cmd.Parameters.AddWithValue("@Numero", Numero);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Huespedes", Huespedes);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool modificarHabitaciones(int ID, int Numero, string Descripcion, int Huespedes, int idUsuario) 
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Habitaciones SET Numero = @Numero, Descripcion = @Descripcion, Huespedes = @Huespedes, idUsuario = @idUsuario WHERE idHabitaciones = @ID",con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Numero", Numero);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Huespedes", Huespedes);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool eliminarHabitaciones(int ID) 
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Habitaciones", con))
                { 
                    cmd.Parameters.AddWithValue("@ID",ID);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}