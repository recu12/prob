using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EquipoQ22.Datos;
using EquipoQ22.Domino;

namespace EquipoQ22.Servicio
{
    internal class equipoServicio : iServicio
    {
        IEquipoDao dao;
        public equipoServicio()
        {
            dao = new gestorDB();
        }

        public DataTable ObtenerPersonas()
        {
            return dao.getObtenerPersonas();
        }
        public bool CrearEquipo(Equipo e)
        {
            return dao.getCrearEquipo(e);
        }
    }
}
