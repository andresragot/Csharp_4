using System;
using System.Collections.Generic;
using System.Text;

namespace Combate_por_turnos
{
    class Jugador
    {
        public string Nombre;
        protected Luchador luchadorActual;
        public Jugador(Luchador luchador)
        {
            Console.WriteLine("Dame tu nombre jugador");
            Nombre = Console.ReadLine();
            luchadorActual = luchador;
        }

        public Jugador(string nombre, Luchador luchador)
        {
            Nombre = nombre;
            luchadorActual = luchador;
        }

        public virtual int AtaqueRestaurar()
        {
            luchadorActual.MenuBatalla();
            bool numOpcion;
            int respuesta;
            do
            {
                numOpcion = int.TryParse(Console.ReadLine(), out respuesta);
                if (!numOpcion || respuesta < 1 || respuesta > 2)
                {
                    Console.WriteLine("No es una respuesta valida.");
                }
            } while (!numOpcion || respuesta < 1 || respuesta > 2);
            return respuesta;
        }

        public virtual int EscogerAtaque()
        {
            luchadorActual.Ataques();
            bool numOpcion;
            int respuesta;
            do
            {
                numOpcion = int.TryParse(Console.ReadLine(), out respuesta);
                if (!numOpcion || respuesta < 1 || respuesta > luchadorActual.Nivel || luchadorActual.PrecioAtaques[respuesta - 1] > luchadorActual.Stamina)
                {
                    Console.WriteLine("No es una respuesta valida.");
                }
            } while (!numOpcion || respuesta < 1 || respuesta > luchadorActual.Nivel || luchadorActual.PrecioAtaques[respuesta - 1] > luchadorActual.Stamina);
            return respuesta;
        }
    }
}
