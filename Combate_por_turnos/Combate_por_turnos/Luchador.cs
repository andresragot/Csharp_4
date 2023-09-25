using System;
using System.Collections.Generic;
using System.Text;

namespace Combate_por_turnos
{
    abstract class Luchador
    {
        protected int _Nivel = 0;
        protected int _Fuerza = 0;
        protected int _Resistencia = 0;
        protected int _Inteligencia = 0;
        protected int _Vida = 0;
        protected string _Nombre = "";
        protected int _Mana = 0;
        protected int _ManaMaximo = 0;
        protected int _VidaMaxima = 0;
        protected int _ResistenciaMaxima = 0;
        protected int _Stamina = 0;

        public int[] PrecioAtaques = { 1, 1, 2, 2, 2, 3, 3 };
        public int Stamina
        {
            get { return _Stamina; }
            set { _Stamina = value; }
        }
        public int ResistenciaMaxima
        {
            get { return _ResistenciaMaxima; }
            set { _ResistenciaMaxima = value; }
        }
        public int VidaMaxima
        {
            get { return _VidaMaxima; }
            set { _VidaMaxima = value; }
        }
        public int ManaMaximo
        {
            get { return _ManaMaximo;}
            set
            {
                _ManaMaximo = value;
            }
        }
        public int Mana
        {
            get { return _Mana; }
            set
            {
                if (_Mana + value <= _ManaMaximo)
                {
                    _Mana = value;
                }
                else
                {
                    _Mana = _ManaMaximo;
                }
            }
        }
        public int Nivel 
        {
            get { return _Nivel; } 
            set { _Nivel = value; }    
        }
        public int Fuerza
        {
            get { return _Fuerza; }
            set { _Fuerza = value; }
        }
        public int Resistencia
        {
            get { return _Resistencia; }
            set
            {
                if (_Resistencia + value <= _ResistenciaMaxima)
                {
                    _Resistencia = value;
                }
                else
                {
                    _Resistencia = _ResistenciaMaxima;
                }
            }
        }
        public int Inteligencia
        {
            get { return _Inteligencia; }
            set { _Inteligencia = value; }
        }
        public int Vida
        {
            get { return _Vida; }
            set { _Vida = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }     

        

        public abstract string Descriptor();

        public abstract void Jugar();

        public abstract string DescriptorBatalla();

        public abstract void MenuBatalla();

        public abstract void Ataques();

        public abstract void Atacar(int Ataque, Luchador luchador);

        public abstract void RecibirDanho(int Danho);

        public abstract void RestaurarVida();

        public abstract void Ganar();
        
        public abstract void Perder();

    }
}
