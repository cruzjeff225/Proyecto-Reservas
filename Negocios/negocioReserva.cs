using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class negocioReserva
    {
        Reservas reservasN = new Reservas();

        public DataTable obtenerReservas()
        {
            return reservasN.obtenerReservas();
        }

        public DataTable obtenerHabitaciones()
        {
            return reservasN.obtenerHabitaciones();
        }

        private int generarIdReserva()
        {
            return int.Parse(DateTime.Now.ToString("MMddHHmm"));
        }

        public decimal calcularPrecio(DateTime Ckeckin, DateTime Checkout, int idHabitacion, decimal Descuento)
        {
            int totalDias = (Checkout - Ckeckin).Days;

            decimal precioInicial = idHabitacion == 1 ? 125.00m : 80.0m;
            decimal precioLibreIVA = precioInicial * totalDias;
            decimal descuentoAplicar = (precioLibreIVA * Descuento) / 100;
            decimal precioFinal = precioLibreIVA - descuentoAplicar;

            return precioFinal;
        }

        public bool agregarReserva(int idCliente, int idHabitacion, int Dias, decimal Descuento, DateTime Checkin, DateTime Checkout, int idUsuario)
        {
            int idReserva = generarIdReserva();
            DateTime fechaRegistro = DateTime.Now;
            decimal Precio = calcularPrecio(Checkin, Checkout, idHabitacion, Descuento);

            return reservasN.agregarReserva(idReserva, idCliente, idHabitacion, Precio, Descuento, Checkin, Checkout, fechaRegistro, idUsuario);
        }

        public bool editarReserva(int idReserva, int idCliente, int idHabitacion, decimal Precio, decimal Descuento, DateTime Checkin, DateTime Checkout)
        {
            return reservasN.editarReserva(idReserva, idCliente, idHabitacion, Precio, Descuento, Checkin, Checkout);
        }

        public bool eliminarReserva(int idReserva)
        {
            return reservasN.eliminarReserva(idReserva);
        }
    }
}
