using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EquipoQ22.Domino;

namespace EquipoQ22.Servicio
{
    internal interface iServicio
    {
        DataTable ObtenerPersonas();
        bool CrearEquipo(Equipo e);
    }
}
