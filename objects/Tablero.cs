using System;
using System.Collections.Generic;
using System.Data;

namespace flota_consola.objects
{
    internal class Tablero
    {
        private int[,] mar = new int[10, 10];
        private List<Barco> barcos = new List<Barco>();

        public Tablero()
        {
            
        }

        // Metodos de cracion y modificacion tablero
        public void ModificarBarco()
        {

        }

        public void GenerarManual()
        {
            GenerarBarcos();
            GenerarCampoAgua();
            AddBarcosToTablero(1);
            MostrarEstado();
        }

        public void GenerarAleatorio()
        {
            GenerarBarcos();
            GenerarTableroAleatorio();
        }

        private void GenerarBarcos()
        {
            char[] characters = { 'X', 'Y' };
            Random r = new Random();
            while (barcos.Count != 10)
            {
                Barco barco = new Barco();
                if (barcos.Count < 4) { barco.Espacios = 1; }                              //4 barcos de un cuadrado    S - Submarino   - 1
                else if (barcos.Count >= 4 && barcos.Count < 7) { barco.Espacios = 2; }    //3 barcos de 2 cuadrados    F - Flota       - 2
                else if (barcos.Count >= 7 && barcos.Count < 9) { barco.Espacios = 3; }    //2 barcos de 3 cuadrados    A - Acorazado   - 3
                else if (barcos.Count == 9) { barco.Espacios = 4; }                        //1 barco de 4 cuadrados     P - Portaviones - 4

                int rn = r.Next(0, 2);
                barco.Orientacion = characters[rn];
                barcos.Add(barco);
            }
        }

        private void GenerarTableroAleatorio()
        {
            // Generamos el tablero con todo a 0
            GenerarCampoAgua();
            // Añadimos los barcos al tablero
            AddBarcosToTablero(0);
        }

        private void GenerarCampoAgua()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mar[i, j] = 0;
                }
            }
        }

        private void AddBarcosToTablero(int modo)
        {
            foreach (Barco barco in barcos)
            {
                //Crear posicion inicial del barco
                int x = 0;
                int y = 0;
                
                if (modo==0)
                {
                    Random r = new Random();
                    while (barco.Posicion == null)
                    {
                        x = r.Next(0, 10);
                        y = r.Next(0, 10);

                        int[] posicionInicial = { x, y };
                        barco.Posicion = posicionInicial;

                        ComprobarPosiciones(barco);
                    }
                }
                else { PreguntarPosicion(barco); }                

                // Colocar barco
                x = barco.Posicion[0];
                y = barco.Posicion[1];
                int contTamBarco = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (barco.Orientacion == 'X')
                        {
                            if (i == x && j == y && contTamBarco < barco.Espacios)
                            {
                                mar[i, j] = barco.Espacios;
                                y++;
                                contTamBarco++;
                            }
                        }
                        else if (barco.Orientacion == 'Y')
                        {
                            if (i == x && j == y && contTamBarco < barco.Espacios)
                            {
                                mar[i, j] = barco.Espacios;
                                x++;
                                contTamBarco++;
                            }
                        }
                        if (contTamBarco == barco.Espacios) { j = 10; i = 10; }
                    }
                }
            }
        }

        private void ComprobarPosiciones(Barco barco)
        {
            int col = barco.Posicion[0];
            int fila = barco.Posicion[1];

            if (col > 9 || fila > 9) { throw new Exception("El barco se cae del tablero."); }
            int posInicio = IIf(barco.Orientacion == 'X', col, fila);
            int varFija = IIf(barco.Orientacion != 'X', col, fila);
            int casillasFuturas = (varFija + barco.Espacios) - 1;
            for (int i = varFija; i <= casillasFuturas; i++)
            {
                try
                {
                    if (mar[IIf(barco.Orientacion == 'X', posInicio, i), IIf(barco.Orientacion == 'Y', posInicio, i)] != 0) { throw new Exception("El barco lo vas a poner encima de otro.");}
                }
                catch(Exception e) {
                    barco.Posicion = null;
                    if (!e.Message.Contains("El barco")) { Pantalla.PintarError("El barco se cae del tablero."); } else { Pantalla.PintarError(e.Message); }
                }
            }
        }

        private void PreguntarPosicion(Barco barco)
        {
            string[] barcosNombres = { "Submarino", "Flota","Acorazado","Portaviones" };
            int[] posicionArr = { 0, 0 };
            bool error = false;
            do
            {
                try
                {
                    string menuPregunta = "\n" +
                        MostrarEstado() + "\n" +
                        "| " + barcosNombres[barco.Espacios - 1] + " | vidas: " + barco.Espacios + "\n" +
                        "Escriba la posición de inicio y despúes la final. [Letra,Número]:" + "\n" +
                        "Posición inicial: ";

                    string[] posInicial = Pantalla.PintarclQry(menuPregunta).TrimStart('[').TrimEnd(']').Split(',');
                    posicionArr[0] = ParseLetraToNumero(posInicial[0]);
                    posicionArr[1] = int.Parse(posInicial[1])-1;
                    if (barco.Espacios != 1)
                    {
                        string oriCadena = Pantalla.PintarQry("Orientación del barco [X=Horizontal,Y=Vertical]: ").ToUpper();
                        if (oriCadena != "X" && oriCadena != "Y") { throw new Exception("Solo se admiten los valores 'X' y 'Y'."); }
                        char ori = char.Parse(oriCadena);
                        barco.Orientacion = ori;
                    }
                    else { barco.Orientacion = 'X'; }

                    barco.Posicion = (int[])posicionArr.Clone();
                    ComprobarPosiciones(barco);
                    error = false;
                }
                catch(Exception e)
                {
                    Pantalla.PintarError(IIf(e.Message.Contains("matriz"),"La posición introducida no es válida.",e.Message));
                    error = true;
                }
            } while (error);
        }

        private int ParseLetraToNumero(string letra)
        {
            string[] arr = { "a", "b", "c", "d", "e","f","g","h","i","j" };
            int n = Array.IndexOf(arr, letra);
            return n;
        }

        //Metodos de acciones de juego
        public void MarcarCasilla()
        {
        }

        // Metodos de pintar por pantalla
        public string MostrarEstado()
        {
            string panel = "";
            int x = 1;
            char y = 'A';
            char[] tipoBarco = { 'S', 'F', 'A', 'P' };

            for (int i = -1; i < 10; i++)
            {
                for (int j = -1; j < 10; j++)
                {
                    if (i == -1 && j == -1) { panel += " "; }
                    else if (i == -1 && j != -1) { panel += x++; }
                    else if (j == -1 && i != -1) { panel += y++; }
                    else if (i != -1 && j != -1) { if (mar[i, j] != 0) { panel += tipoBarco[mar[i, j] - 1]; } else { panel += "~"; } }
                    
                    panel += " ";
                }
                panel += "\n";
            }

            return panel;
        }

        public string MostrarEstadoCensura()
        {
            string panel = "";
            int x = 1;
            char y = 'A';
            char[] tipoBarco = { 'S', 'F', 'A', 'P' };

            for (int i = -1; i < 10; i++)
            {
                for (int j = -1; j < 10; j++)
                {
                    if (i == -1 && j == -1) { panel += " "; }
                    else if (i == -1 && j != -1) { panel += x++; }
                    else if (j == -1 && i != -1) { panel += y++; }
                    else if (i != -1 && j != -1) { panel += "~"; }

                    panel += " ";
                }
                panel += "\n";
            }

            return panel;
        }

        // Metodos para online
        public string TransferirTabla()
        {
            string cadena = "";

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cadena += mar[i, j].ToString() + ";";
                }
            }
            cadena = cadena.TrimEnd(';');
            return cadena;
        }



        T IIf<T>(bool expression, T truePart, T falsePart)
        { return expression ? truePart : falsePart; }
    }
}
