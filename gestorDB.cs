using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EquipoQ22.Domino;

namespace EquipoQ22.Datos
{
    internal class gestorDB : IEquipoDao
    {
        public DataTable getObtenerPersonas()
        {
            return equipoDAO.crearInstancia().obtenerPersonas();
        }
        public bool getCrearEquipo(Equipo e)
        {
            return equipoDAO.crearInstancia().crearEquipo(e);
        }
    }
}
