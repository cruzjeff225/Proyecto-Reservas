using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class negocioCliente
    {
        Clientes clientesN = new Clientes();

        public DataTable obtenerClientes()
        {
            return clientesN.obtenerClientes();
        }

        public bool agregarCientes(string Nombre, int DUI, int Telefono, string Correo, string Departamento, DateTime fechaRegistro, int idUsuario)
        {
            return clientesN.agregarClientes(Nombre, DUI, Telefono, Correo, Departamento, fechaRegistro, idUsuario);
        }

        public bool editarClientes(int idCliente, string Nombre, int DUI, int Telefono, string Correo, string Departamento)
        {
            return clientesN.editarClientes(idCliente, Nombre, DUI, Telefono, Correo, Departamento);
        }

        public bool eliminarClientes(int idCliente)
        {
            return clientesN.eliminarClientes(idCliente);
        }
    }
}