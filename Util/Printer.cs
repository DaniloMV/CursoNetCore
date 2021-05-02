using static System.Console;

namespace CoreEscuela.Entidades
{
    ///Una clase estatica no permite crear nuevas instancias, 
    ///la clase por si misma va funcionar como un objeto.
    public static class Printer
    {
        public static void DrawLine(int tamanio = 10)
        {
            //PadLeft Rellenar a la izquierda.
            string linea = "".PadLeft(tamanio, '=');
            WriteLine(linea);
        }

        public static void PresioneEnter()
        {
            WriteLine("Presione enter para continuar.");
        }

        public static void WriteTitle(string titulo)
        {
            var tamanio = titulo.Length + 4;
            DrawLine(tamanio);
            WriteLine($"| {titulo} |");
            DrawLine(tamanio);
        }

        public static void Beep(int herstz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(herstz, tiempo);
            }
        }
    }
}