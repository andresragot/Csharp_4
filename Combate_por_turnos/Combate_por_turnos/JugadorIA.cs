using System;
using System.Collections.Generic;
using System.Text;

namespace Combate_por_turnos
{
    class JugadorIA : Jugador
    {
        public JugadorIA(Luchador luchador) : base("IA", luchador)
        {

        }

        public override int AtaqueRestaurar()
        {
            luchadorActual.MenuBatalla();
            Random rng = new Random();
            int respuesta = rng.Next(1, 3);
            Console.WriteLine("La IA escogió el numero " + respuesta);
            return respuesta;
        }

        public override int EscogerAtaque()
        {
            luchadorActual.Ataques();
            Random rng = new Random();
            int respuesta;
            do
            {
                respuesta = rng.Next(1, luchadorActual.Nivel);

            } 
            while (luchadorActual.PrecioAtaques[respuesta - 1] > luchadorActual.Stamina);
            
            Console.WriteLine("La IA escogió el numero " + respuesta);
            
            return respuesta;
        }
    }

}
