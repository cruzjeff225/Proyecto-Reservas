using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocios
{
    public class negocioHabitaciones
    { 
        Habitaciones habitacionesN = new Habitaciones();
        
        public DataTable obtenerHabitaciones()
        {
            return habitacionesN.obtenerHabitaciones();
        }

        public bool agregarHabitaciones(int Numero, string Descripcion, int Huespedes, int idUsuario)
        {
            return habitacionesN.agregarHabitaciones(Numero, Descripcion, Huespedes, idUsuario);
        }

        public bool modificarHabitaciones(int ID, int Numero, string Descripcion, int Huespedes, int idUsuario)
        {
            return habitacionesN.modificarHabitaciones(ID, Numero, Descripcion, Huespedes, idUsuario); 
        }

        public bool eliminarHabitaciones(int ID)
        {
            return habitacionesN.eliminarHabitaciones(ID);
        }
    }
}
