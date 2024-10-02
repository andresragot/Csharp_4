using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Combate_por_turnos
{
    class Juego
    {
        List<Luchador> luchadores = new List<Luchador>();

        Luchador luchador1;
        Luchador luchador2;

        bool HayJugadorIA = false;

        Jugador jugador1;
        Jugador jugador2;
        JugadorIA jugadorIA;

        public Juego()
        {
            Jugar();
        }

        public void Jugar()
        {
            int opcion = Menu();
            do
            {
                switch (opcion)
                {
                    case 1:
                        CrearPersonaje();
                        break;

                    case 2:
                        if (luchadores.Count >= 2)
                        {
                            Combatir();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No tenemos suficientes luchadores creados");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        break;

                }
                opcion = Menu();
            } 
            while (opcion < 3);
        }

        static int Menu() //Función para mostrar en pantalla el menu
        {
            int opcion;
            bool numOpcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Elige una opción");
                Console.WriteLine(" 1. Crear un nuevo Mago"); //Opción para ver las reglas del juego
                Console.WriteLine(" 2. Combatir"); //Opción para personalizar el tablero y el nombre de los jugadores
                Console.WriteLine(" 3. Salir del programa"); //Opción para jugar la partida
                numOpcion = int.TryParse(Console.ReadLine(), out opcion);
                if (numOpcion == false || opcion < 1 || opcion > 3) //Comando para que el jugador no se pase del limite de opciones en el menu
                {
                    Console.WriteLine("Opción incorrecta, inserte un valor entre 1 y 3. \n Pulse una tecla para continuar");
                    Console.ReadKey();
                }
            } 
            while (!numOpcion || opcion < 1 || opcion > 3);
            
            return opcion;
        }

        public void CrearPersonaje()
        {
            int numeroPersonaje;
            bool Opcion;
            do
            {
                Console.WriteLine("1. Crear un Mago\n2. Crear un Guerrero");
                Opcion = int.TryParse(Console.ReadLine(), out numeroPersonaje);
                if (!Opcion || numeroPersonaje < 1 || numeroPersonaje > 2)
                {
                    Console.WriteLine("No es una respuesta valida.");
                }
            } 
            while (!Opcion || numeroPersonaje < 1 || numeroPersonaje > 2);


            if (numeroPersonaje == 1)
            {
                Mago mago = new Mago();
                luchadores.Add(mago);
                Console.WriteLine();
                Console.WriteLine(mago.Descriptor());
                Console.ReadKey();
            }
            else if (numeroPersonaje == 2)
            {
                Guerrero guerrero = new Guerrero();
                luchadores.Add(guerrero);
                Console.WriteLine();
                Console.WriteLine(guerrero.Descriptor());
                Console.ReadKey();
            }
        }

        public void Combatir()
        {
            EscogerPersonaje();
            EscogerJugador();
            Combate();
        }

        void EscogerJugador()
        {
            Console.WriteLine("1- Jugar con alguien\n2- Jugar contra la computadora");
            bool numOpcion;
            int respuesta;
            do
            {
                numOpcion = int.TryParse(Console.ReadLine(), out respuesta);
                if (!numOpcion || respuesta < 1 || respuesta > 2)
                {
                    Console.WriteLine("No es una respuesta valida.");
                }
            } 
            while (!numOpcion || respuesta < 1 || respuesta > 2);
            
            if(respuesta == 1)
            {
                HayJugadorIA = false;
                jugador1 = new Jugador(luchador1);
                jugador2 = new Jugador(luchador2);
            }
            else
            {
                jugador1 = new Jugador(luchador1);
                jugadorIA = new JugadorIA(luchador2);
                HayJugadorIA = true;
            }
        }

        public int NumeroLuchador(Luchador[] array)
        {
            bool numOpcion = false;
            int respuesta;
            do
            {
                Console.WriteLine("los luchadores se tiene que escoger en el orden de los jugadores, el jugador 1 tendrá al luchador 1");
                Console.WriteLine("Escoge un luchador");
                numOpcion = int.TryParse(Console.ReadLine(), out respuesta);
                
                if (!numOpcion || respuesta < 1 || respuesta > array.Length)
                {
                    Console.WriteLine("No es una respuesta valida.");
                }    
                else if (luchador1 != null)
                {
                    if (luchador1 == array[respuesta - 1])
                    {
                        Console.WriteLine("Escogiste el mismo luchador");
                    }
                }
            } 
            while (!numOpcion || respuesta < 1 || respuesta > array.Length || (luchador1 !=null && luchador1 == array[respuesta-1]));

            return respuesta - 1;
        }

        public void EscogerPersonaje()
        {
            luchador1 = null;
            luchador2 = null;

            Luchador[] luch = luchadores.ToArray();
            int i = 1;
            foreach (Luchador a in luch)
            {
                Console.WriteLine();
                Console.WriteLine(" " + i + " - " + a.Descriptor()); 
                Console.WriteLine();

                i++;
            }

            luchador1 = luch[NumeroLuchador(luch)];
            luchador2 = luch[NumeroLuchador(luch)];

            Console.WriteLine("Luchadores escogidos");
            Console.WriteLine();

            Console.WriteLine("El luchador 1 es " + luchador1.Descriptor());
            Console.WriteLine();
            Console.WriteLine("El luchador 2 es " + luchador2.Descriptor());

            
            Console.ReadKey();

        }

        public void Combate()
        {
            Random rng = new Random();
            int a = rng.Next(1, 3);
            bool ganar = false;
            do
            {
                Console.Clear();

                if (a == 1)
                {
                    luchador1.Jugar();
                    Console.WriteLine("Turno del jugador " + jugador1.Nombre);
                    Console.WriteLine(luchador1.DescriptorBatalla());
                    
                    int decision = jugador1.AtaqueRestaurar();
                    if (decision == 1)
                    {
                        luchador1.Atacar(jugador1.EscogerAtaque(), luchador2);
                        if (luchador2.Vida <= 0)
                        {
                            ganar = true;
                        }
                    }
                    else
                    {
                        luchador1.RestaurarVida();
                    }
                    a = 2;
                }
                else if (a == 2 && HayJugadorIA)
                {
                    luchador2.Jugar();
                    Console.WriteLine("Turno de la " + jugadorIA.Nombre);
                    Console.WriteLine(luchador2.DescriptorBatalla());
                    int decision = jugadorIA.AtaqueRestaurar();
                    if (decision == 1)
                    {
                        luchador2.Atacar(jugadorIA.EscogerAtaque(), luchador1);
                        if (luchador1.Vida <= 0)
                        {
                            ganar = true;
                        }
                    }
                    else
                    {
                        luchador2.RestaurarVida();
                    }
                    a = 1;
                }
                else if( a == 2 )
                {
                    luchador2.Jugar();
                    Console.WriteLine("Turno del jugador " + jugador2.Nombre);
                    Console.WriteLine(luchador2.DescriptorBatalla());
                    int decision = jugador2.AtaqueRestaurar();
                    if (decision == 1)
                    {
                        luchador2.Atacar(jugador2.EscogerAtaque(), luchador1);
                        if (luchador1.Vida <= 0)
                        {
                            ganar = true;
                        }
                    }
                    else
                    {
                        luchador2.RestaurarVida();
                    }
                    a = 1;
                }
                Console.ReadKey();
            } 
            while (!ganar);
          
            if (a == 2)
            {
                Console.WriteLine("Ha ganado el jugador " + jugador1.Nombre+" con el luchador "+luchador1.Nombre);

                luchador1.Ganar();

                luchador2.Perder();

            }
            else if (HayJugadorIA)
            {
                Console.WriteLine("Ha ganado el jugador " + jugadorIA.Nombre + " con el luchador " + luchador2.Nombre);
                
                luchador2.Ganar();

                luchador1.Perder();
            }
            else
            {

                Console.WriteLine("Ha ganado el jugador " + jugador2.Nombre + " con el luchador " + luchador2.Nombre);

                luchador2.Ganar();

                luchador1.Perder();
            }
        }
    }
}
