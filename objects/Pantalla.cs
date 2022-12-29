using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flota_consola.objects
{
    internal class Pantalla
    {
        private static string errorActual;
        private static string textActual;

        public static void PintarError(string error)
        {
            errorActual = "### "+error+" ###\n";
        }
        public static void Pintarclln(string text)
        {
            Console.Clear();
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
        }
        public static string PintarclQryln(string text)
        {
            Console.Clear();
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }
        public static string PintarclQryln(string titulo,string[] text)
        {
            Console.Clear();
            
            string cuerpo = "";
            if (titulo != "") { cuerpo = titulo + "\n"; }

            for (int i = 0; i < text.Length; i++)
            {
                cuerpo += (i+1) + "º " + text[i] + "\n";
            }

            if (errorActual != "" && cuerpo == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(cuerpo);
            textActual = cuerpo;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }

        public static void Pintarln(string text)
        {
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
        }
        public static string PintarQryln(string text)
        {
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }
        public static string PintarQryln(string titulo, string[] text)
        {
            string cuerpo = "";
            if (titulo != "") { cuerpo = titulo + "\n"; }

            for (int i = 0; i < text.Length; i++)
            {
                cuerpo += (i + 1) + "º " + text[i] + "\n";
            }

            if (errorActual != "" && cuerpo == textActual) { Console.WriteLine(errorActual); }
            Console.WriteLine(cuerpo);
            textActual = cuerpo;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }

        public static void Pintarcl(string text)
        {
            Console.Clear();
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.Write(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
        }
        public static string PintarclQry(string text)
        {
            Console.Clear();
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.Write(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }
        public static string PintarclQry(string titulo, string[] text)
        {
            Console.Clear();

            string cuerpo = "";
            if (titulo != "") { cuerpo = titulo + "\n"; }

            for (int i = 0; i < text.Length; i++)
            {
                cuerpo += (i + 1) + "º " + text[i] + "\n";
            }

            if (errorActual != "" && cuerpo == textActual) { Console.WriteLine(errorActual); }
            Console.Write(cuerpo);
            textActual = cuerpo;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }

        public static void Pintar(string text)
        {
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.Write(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
        }
        public static string PintarQry(string text)
        {
            if (errorActual != "" && text == textActual) { Console.WriteLine(errorActual); }
            Console.Write(text);
            textActual = text;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }
        public static string PintarQry(string titulo, string[] text)
        {
            string cuerpo = "";
            if (titulo != "") { cuerpo = titulo + "\n"; }

            for (int i = 0; i < text.Length; i++)
            {
                cuerpo += (i + 1) + "º " + text[i] + "\n";
            }

            if (errorActual != "" && cuerpo == textActual) { Console.WriteLine(errorActual); }
            Console.Write(cuerpo);
            textActual = cuerpo;
            if (errorActual != "") { errorActual = ""; };
            return Console.ReadLine().Trim().ToLower();
        }

    }
}
