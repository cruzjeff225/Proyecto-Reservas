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
    public class Clientes
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable obtenerClientes() 
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString)) 
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", con)) 
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool agregarClientes(string Nombre, int DUI, int Telefono, string Correo, string Departamento, DateTime fechaRegistro, int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Cliente" + "(Nombre, DUI, Telefono, Correo, Departamento, fechaRegistro, idUsuario)" +
                    "VALUES (@Nombre, @DUI, @Telefono, @Correo, @Departamento, @fechaRegistro, @idUsuario)", con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@DUI", DUI);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Departamento", Departamento);
                    cmd.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool editarClientes(int idCliente,string Nombre, int DUI, int Telefono, string Correo, string Departamento)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Cliente SET Nombre = @Nombre, DUI = @DUI, Telefono = @Telefono, Correo = @Correo, Departamento = @Departamento WHERE idCliente = @idCliente", con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@DUI", DUI);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Departamento", Departamento);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool eliminarClientes(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE idCliente = @idCliente", con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}
