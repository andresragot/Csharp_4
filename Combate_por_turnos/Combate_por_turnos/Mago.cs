using System;
using System.Collections.Generic;
using System.Text;

namespace Combate_por_turnos
{
    class Mago:Luchador 
    {
        protected string[] NombreHechizos = { "Luz Continua", "Rayo Eléctrico", "Bola de Fuego", "Tormenta de Truenos", "Ola Flamígera", "Anillo de Electricidad", "Apocalipsis Ígneo" };
        private int[] DañoHechizos = new int[7];

        
        public Mago()
        {   
            ManaMaximo = 10;
            Random rng = new Random();
            Console.WriteLine("Creando jugador...");
            Console.WriteLine("¿Como lo llamaremos?");
            Nombre = Console.ReadLine();
            Nivel = 1;
            Fuerza = rng.Next(3, 11);
            Resistencia = rng.Next(3, 11);
            Inteligencia = rng.Next(3, 11);
            VidaMaxima = rng.Next(30, 101);
            Vida = VidaMaxima;
            Inteligencia += (int) (Inteligencia * 0.3f);
            Mana = ManaMaximo;
            Stamina = Mana;
            
            for (int i = 0; i<DañoHechizos.Length; i++)
            {
                DañoHechizos[i] = Inteligencia * PrecioAtaques[i] + (i + 1);
            }
        }

        public override string Descriptor()
        {
            string message = "El Mago de ";

            message += "Nombre: " + Nombre+ "\n";
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
            Mana++;
            Stamina = Mana;
        }

        public override string DescriptorBatalla()
        {
            string message = "";

            message += "Turno del mago " + Nombre + ". Nivel " + Nivel + ". Mana " + Mana + ". Vida " + Vida;

            return message;
        }

        public override void MenuBatalla()
        {
            Console.WriteLine("\t1. Atacar" + "\n\t2. Restaurar Vida");                
        }

        public override void Ataques()
        {

            for (int i = 0; i < NombreHechizos.Length; i++)
            {
                if (i < Nivel)
                {
                    if (PrecioAtaques[i] <= Stamina)
                        Console.WriteLine((i + 1) + ". " + NombreHechizos[i] + ", Mana " + PrecioAtaques[i]);
                }
            }
        }

        public override void Atacar(int Ataque, Luchador luchador)
        {
            Mana -= PrecioAtaques[Ataque - 1];
            Stamina = Mana;
            int Danho = DañoHechizos[Ataque - 1];
            Console.WriteLine("El mago "+Nombre+" lanza un hechizo de "+NombreHechizos[Ataque-1]+", que puede causar un daño de  "+Danho+" puntos de vida.");
            luchador.RecibirDanho(Danho);
        }

        public override void RecibirDanho(int Danho)
        {
            Random rng = new Random();

            float valorChance = rng.Next(0, 101);

            if (valorChance <= Inteligencia)
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
            Inteligencia++;
            ManaMaximo++;
            Mana = ManaMaximo;
            Stamina = Mana;
        }

        public override void Perder()
        {
            Vida = VidaMaxima;
            Mana = ManaMaximo;
            Stamina = Mana;
        }
    }
}
