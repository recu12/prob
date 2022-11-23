using EquipoQ22.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EquipoQ22.Datos
{
    public interface IEquipoDao
    {
        DataTable getObtenerPersonas();
        bool getCrearEquipo(Equipo e);
    }
}
