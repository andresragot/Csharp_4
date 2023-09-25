using System;
using System.Collections.Generic;
using System.Text;

namespace Combate_por_turnos
{
    class Guerrero : Luchador
    {
        private string[] NombreAtaques = { "Ataque básico", "Ataque circular al cuerpo del enemigo", "Ataque curtido", "Ataque giratorio", "Ataque doble", "Ataque kung fu", "Ataque mortal" };
        private int[] DañoAtaques = new int[7];

        public Guerrero()
        {
            ManaMaximo = 10;
            Random rng = new Random();
            Console.WriteLine("Creando jugador...");
            Console.WriteLine("¿Como lo llamaremos?");
            Nombre = Console.ReadLine();
            Nivel = 1;
            Fuerza = rng.Next(3, 11);
            ResistenciaMaxima = rng.Next(3, 11);
            Resistencia = ResistenciaMaxima;
            Inteligencia = rng.Next(3, 11);
            VidaMaxima = rng.Next(30, 101);
            Vida = VidaMaxima;
            Mana = ManaMaximo;
            Stamina = Resistencia;
            Fuerza += (int)(Fuerza * 0.3);
            for (int i = 0; i < DañoAtaques.Length; i++)
            {
                DañoAtaques[i] = Fuerza * PrecioAtaques[i] + (i + 1);
            }
        }

        public override string Descriptor()
        {
            string message = "El Guerrero de ";

            message += "Nombre: " + Nombre + "\n";
            message += "Nivel: " + Nivel + "\n";
            message += "Vida: " + Vida + "\n";
            message += "Fuerza: " + Fuerza + "\n";
            message += "Resistencia: " + Resistencia + "\n";
            message += "Inteligencia: " + Inteligencia + "\n";
            message += "Mana: " + Mana;

            return message;
        }

        public override void Jugar()
        {
            Resistencia++;
            Stamina = Resistencia;
        }

        public override string DescriptorBatalla()
        {
            string message = "";

            message += "Turno del Guerrero " + Nombre + ". Nivel " + Nivel + ". Resistencia " + Resistencia + ". Vida " + Vida;

            return message;
        }

        public override void MenuBatalla()
        {
            Console.WriteLine("\t1. Atacar" + "\n\t2. Restaurar Vida"); 
        }

        public override void Ataques()
        {
            for (int i = 0; i < NombreAtaques.Length; i++)
            {
                if (i < Nivel)
                {
                    if (PrecioAtaques[i] <= Stamina)
                        Console.WriteLine((i + 1) + ". " + NombreAtaques[i] + ", Resistencia " + PrecioAtaques[i]);
                }
            }
        }
                

        public override void Atacar(int Ataque, Luchador luchador)
        {
            Resistencia -= PrecioAtaques[Ataque - 1];
            Stamina = Resistencia;
            int Danho = DañoAtaques[Ataque - 1];
            Console.WriteLine("El Guerrero " + Nombre + " hace el " + NombreAtaques[Ataque - 1] + ", que puede causar un daño de  " + Danho + " puntos de vida.");
            luchador.RecibirDanho(Danho);
        }

        public override void RecibirDanho(int Danho)
        {
            Random rng = new Random();

            float valorChance = rng.Next(0, 101);

            if (valorChance <= Fuerza)
            {
                Console.WriteLine("El mago " + Nombre + " ha esquivado el Ataque");
            }
            else
            {
                Console.WriteLine("El mago " + Nombre + " ha recibido daño de " + Danho + " puntos de vida");
                Vida -= Danho;
            }
        }

        public override void RestaurarVida()
        {
            Vida += 10;
        }

        public override void Ganar()
        {
            VidaMaxima += 10;
            Vida = VidaMaxima;
            Nivel++;
            Fuerza++;
            ResistenciaMaxima++;
            Resistencia = ResistenciaMaxima;
            Stamina = Resistencia;
        }

        public override void Perder()
        {
            Vida = VidaMaxima;
            Resistencia = ResistenciaMaxima;
            Stamina = Resistencia;

        }

    }
}
