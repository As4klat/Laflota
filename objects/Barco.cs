using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flota_consola.objects
{
    internal class Barco
    {
        private int espacios;
        private char orientacion;
        private int[] posicion;

        public Barco()
        {
            this.posicion = null;
        }

        public Barco(int espacios, char orientacion, int[] posicion)
        {
            this.espacios = espacios;
            this.orientacion = orientacion;
            this.posicion = posicion;
        }

        public int Espacios
        {
            get { return espacios; } 
            set { espacios = value; }  
        }

        public char Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }

        public int[] Posicion
        {
            get { return posicion; }
            set {
                if (value != null)
                {
                    posicion = new int[value.Length];
                    posicion[0] = value[0];
                    posicion[1] = value[1];
                }
                else
                {
                    posicion = null;    
                }
            }
        }
    }
}
