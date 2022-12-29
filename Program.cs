using flota_consola.objects;
using System;
using System.Threading;

namespace flota_consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Primero mostramos el menu
            bool salir=false;
            while (!salir)
            {
                try
                {
                    string[] opcionesMenu = { "Partida vs IA", "Partida Online", "Salir" };
                    int opcion = int.Parse(Pantalla.PintarclQryln("Seleccione opción:", opcionesMenu));
                    switch (opcion)
                    {
                        case 1:
                            JugadorVsBot();
                            break;
                        case 2:
                            break;
                        case 3:
                            salir = true;
                            string textDespedida = "\n" +
                                "      #####################################  " + "\n" +
                                "    #####                               #####" + "\n" +
                                "    ###         Gracias por jugar         ###" + "\n" +
                                "    #####                               #####" + "\n" +
                                "      #####################################  ";
                            Pantalla.Pintarclln(textDespedida);
                            Thread.Sleep(1000 * 1);
                            break;
                        default:
                            throw new Exception("opcion error");
                    }
                }
                catch (Exception e)
                {
                    Pantalla.PintarError("No se ha selecionado una de las opciones.");
                    salir=false;
                }
            }
        }

        private static void MostrarJuego(string panelPropio, string panelEnemigo)
        {
            string mostrar = panelEnemigo + "\n" +
                            "Tablero enemigo\n" +
                            "----------------- VS -----------------" + "\n" +
                            "Tablero propio\n\n" +
                            panelPropio;
            Pantalla.Pintarclln(mostrar);
        }

        private static void JugadorVsBot()
        {
            //Creamos nuestro tablero sin completar.
            Tablero tabLocal = new Tablero();
            //Creamos y generamos el tablero del bot.
            Tablero tabBot = new Tablero();
            tabBot.GenerarAleatorio();
            //Preguntamos al usuario el modo de generar el tablero.
            string op = "";
            do
            {
                op = Pantalla.PintarclQryln("¿Crear tu tablero [manual] o [aleatorio]?");
                switch (op)
                {
                    case "manual":
                        tabLocal.GenerarManual();
                        break;
                    case "aleatorio":
                        tabLocal.GenerarAleatorio();
                        string modificarOp = Pantalla.PintarclQryln(tabLocal.MostrarEstado() + "\n" + "¿Deseas modificar algo? [Y/N]");
                        if (modificarOp == "y") { tabLocal.ModificarBarco(); }
                        break;
                    default:
                        Pantalla.PintarError("Se ha introducido un opción erronea.");
                        op = "";
                        break;
                }
            } while (op == "");
            MostrarJuego(tabLocal.MostrarEstado(), tabBot.MostrarEstadoCensura());
            Console.ReadLine();
        }
    }
}
