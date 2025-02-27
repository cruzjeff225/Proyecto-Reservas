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
    public class Reservas
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public DataTable obtenerReservas() 
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reserva",con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable obtenerHabitaciones()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT idHabitaciones, CONCAT(idHabitaciones, ' - ', Descripcion) AS Habitacion, CASE WHEN Huespedes = 4 THEN 125.00 ELSE 80.00 END AS Precio FROM Habitaciones", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool agregarReserva(int idReserva, int idCliente, int idHabitacion, decimal Precio, decimal Descuento, DateTime Checkin, DateTime Checkout, DateTime fechaRegistro, int idUsuario) 
        {
            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Reserva" + "(idReserva, idCliente, idHabitacion, Precio, Descuento, Checkin, Checkout, fechaRegistro, idUsuario)"
                    + "VALUES (@idReserva, @idCliente, @idHabitacion, @Precio, @Descuento, @Checkin, @Checkout, @fechaRegistro, @idUsuario)", con))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("idHabitacion", idHabitacion);
                    cmd.Parameters.AddWithValue("@Precio", Precio);
                    cmd.Parameters.AddWithValue("@Descuento", Descuento);
                    cmd.Parameters.AddWithValue("@Checkin", Checkin);
                    cmd.Parameters.AddWithValue("@Checkout", Checkout);
                    cmd.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool editarReserva(int idReserva, int idCliente, int idHabitacion, decimal Precio, decimal Descuento, DateTime Checkin, DateTime Checkout)
        {

            using (SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Reserva SET idHabitacion = @idHabitacion, Precio = @Precio, Descuento = @Descuento, Checkin = @Checkin, Checkout = @Checkout WHERE idReserva = @idReserva", con))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);
                    cmd.Parameters.AddWithValue("@idHabitacion", idHabitacion);
                    cmd.Parameters.AddWithValue("@Precio", Precio);
                    cmd.Parameters.AddWithValue("@Descuento", Descuento);
                    cmd.Parameters.AddWithValue("@Checkin", Checkin);
                    cmd.Parameters.AddWithValue("@Checkout", Checkout);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool eliminarReserva(int idReserva)
        {
            using(SqlConnection con = new SqlConnection(conexionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Reserva WHERE idReserva = @idReserva", con))
                {
                    cmd.Parameters.AddWithValue("idReserva", idReserva);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

    }
}
