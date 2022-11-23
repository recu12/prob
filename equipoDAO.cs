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
    internal class equipoDAO : accesoDB
    {
        private static equipoDAO instancia;
        public int idProvisional = 1;
        public static equipoDAO crearInstancia()
        {
            if (instancia == null)
            {
                instancia = new equipoDAO();
            }
            return instancia;
        }

        public DataTable obtenerPersonas()
        {
            DataTable tabla = new DataTable();
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "SP_CONSULTAR_PERSONAS";
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        public bool crearEquipo(Equipo e)
        {
            bool ok = true;
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            SqlTransaction t = null;
             

            try
            {
                comando.Parameters.Clear();
                conectar();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_INSERTAR_EQUIPO";
                comando.Parameters.AddWithValue("@pais", e.Pais);
                comando.Parameters.AddWithValue("@director_tecnico", e.dT);
                comando.Parameters.Add(p);
                p.Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                idProvisional = (int)p.Value;
                comando.Parameters.Clear();
                int count = 1;

                foreach(Jugador j in e.Jugadores)
                {
                    comando.CommandText = "SP_INSERTAR_DETALLES_EQUIPO";
                    comando.Parameters.AddWithValue("@id_equipo", idProvisional);
                    comando.Parameters.AddWithValue("@id_persona", j.Persona.IdPersona);
                    comando.Parameters.AddWithValue("@camiseta", j.Camiseta);
                    comando.Parameters.AddWithValue("@posicion", j.Posicion);
                    count++;
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }

                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    desconectar();
                }
            }
            return ok;
        }
    }
}
