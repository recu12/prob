using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipoQ22.Domino
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string dT { get; set; }
        public List<Jugador> Jugadores { get; set; }

        public Equipo()
        {
            Jugadores = new List<Jugador>();
        }
        public void agregarJugador(Jugador jugador)
        {
            Jugadores.Add(jugador);
        }
        public void eliminarJugador(int index)
        {
            Jugadores.RemoveAt(index);
        }

    }
}
