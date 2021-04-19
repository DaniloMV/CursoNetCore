using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Etapa 5 
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("==== Etapa 5 ====");
            //Printer.Beep(1000, cantidad: 10);
            ///ImprimirCursosEscuelaEtapa4(engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Prueba de Polimorfismo");
            var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Underwood" };
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.UniqueId}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            alumnoTest = (Alumno)ob;
            Printer.WriteTitle("ObjetoEscuela Es un Alumno si puede verlo como un Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ///Este objeto nunca fue un Alumno.
            ///Nunca podemos hacer que se vea como un objeto hijo.
            ///ya que fue un objeto Padre
            ///Ya que no tiene todas las características que tiene el hijo.
            // alumnoTest = (Alumno)objDummy;
            // Printer.WriteTitle("ObjetoEscuela Es un Alumno si puede verlo como un Alumno");
            // WriteLine($"Alumno: {alumnoTest.Nombre}");
            // WriteLine($"Alumno: {alumnoTest.UniqueId}");
            // WriteLine($"Alumno: {alumnoTest.GetType()}");

            return;
            ///Etapa 4

            /* var engine = new EscuelaEngine();
            engine.Inicializar();

            ////Printer.DibujarLinea();
            Printer.WriteTitle("==== Etapa 4 ====");
            Printer.Beep(1000,cantidad:10);
            ImprimirCursosEscuelaEtapa4(engine.Escuela);

            return; */

            //////////////////Fin Etapa 4


            /*  var escuela = new Escuela("Sisfel", 2021);
             escuela.Pais="Ecuador";
             escuela.Ciudad ="Cuenca";
             escuela.TipoEscuela = TiposEscuela.Primaria;

             Console.WriteLine(escuela); */

            #region Arreglos
            /* var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            arregloCursos[1] = new Curso()
            {
                Nombre = "102"
            };

            arregloCursos[2] = new Curso()
            {
                Nombre = "103"
            }; */
            /* var curso1 = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            }; */

            /* Curso[] arregloCursos = {

                new Curso
                {
                    Nombre = "101"
                },
                new Curso() { Nombre = "201" },
                new Curso { Nombre = "301" }
            }; */
            #endregion

            /* var listaCursos = new List<Curso>{
                new Curso { Nombre = "101"},
                new Curso() { Nombre = "201" },
                new Curso { Nombre = "301" }
            }; */

            var escuela = new Escuela("Sisfel", 2021, TiposEscuela.Primaria,
                                                ciudad: "Cuenca", pais: "Ecuador"
                                        );

            escuela.ListaCursos = new List<Curso>{
                new Curso { Nombre = "101", Jornada = TiposJornada.Manana},
                new Curso() { Nombre = "201", Jornada = TiposJornada.Manana },
                new Curso { Nombre = "301", Jornada = TiposJornada.Manana }
            };

            ///Le quito el parentisis porque no voy a utilizar un parámetro en el Curso.
            ///escuela.ListaCursos.Add(new Curso() { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.ListaCursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.ListaCursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>{
                new Curso { Nombre = "401", Jornada = TiposJornada.Manana},
                new Curso() { Nombre = "501", Jornada = TiposJornada.Manana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Tarde },
                new Curso { Nombre = "601", Jornada = TiposJornada.Manana }
            };

            escuela.Cursos = new Curso[] {

                new Curso
                {
                    Nombre = "101"
                },
                new Curso() { Nombre = "201" },
                new Curso { Nombre = "301" }
            };

            WriteLine(escuela);
            WriteLine("===========");

            /*  Console.WriteLine(curso1.Nombre+","+curso1.UniqueId);
             Console.WriteLine($"{curso2.Nombre}, {curso2.UniqueId}");
             Console.WriteLine(curso3); */

            /* Console.WriteLine(arregloCursos[0].Nombre);
            Console.WriteLine("Presione enter para continuar.");
            Console.ReadLine();            
            Console.WriteLine(arregloCursos[5].Nombre); */

            /* ImprimirCursosWhile(arregloCursos);
            Console.WriteLine("===========");
            ImprimirCursosDoWhile(arregloCursos);
            Console.WriteLine("===========");
            ImprimirCursosFor(arregloCursos);
            Console.WriteLine("===========");
            ImprimirCursosForEach(arregloCursos); */

            Curso temporal = new Curso { Nombre = "101-Vacacional", Jornada = TiposJornada.Noche };
            ///Eliminar todos los elementos de la lista.
            ////otraColeccion.Clear();
            escuela.ListaCursos.AddRange(otraColeccion);
            escuela.ListaCursos.Add(temporal);

            ImprimirCursosEscuela(escuela);
            WriteLine("Curso.Hash" + temporal.GetHashCode());
            escuela.ListaCursos.Remove(temporal);
            WriteLine("===========");

            ///Predicate Generico de Curso lo que voy hacer voy a ponerle un nombre
            ///es más esto se llama encapsulación de algoritmos le voy asignaral método Precicado
            ///Porque estoy haciendo este paso adicional.
            ///Resulta si Yo miro este Predicate, Preciono Ctrl en Predicado me dice que es un delegado 
            ///y ese delegado devuelve booleano y que recibe un parámetro Generico de un tipo de dato.
            ///Yo le puedo asignar metodos que devuelvan boleano y que reciban como parámetro el tipo de dato
            ///Generico especificado.
            Predicate<Curso> miAlgoritmo = Predicado;

            escuela.ListaCursos.RemoveAll(miAlgoritmo);

            ///Desde C# 3.5 hay inferencia de tipos el ya sabe que este predicado cumple con la especificación
            ///que nos pide este Predicate, es capaz de darse cuenta que cumple no hay necesidad de hacer el Mapping 
            ///Puede inferir con un tipo o el otro 
            ///Como le puedo recibir diferente hay una expresión Lamda y hay otra cosa que se llama delegado.
            ///Puede reescribirlo de la siguiente manera 
            ///El delegate recibe algo como parámetro curso no necesito decirle el tipo por ahora 
            ///Le digo que esto conlleva (=>) Con lleva a evaluar que curso sea 301.
            escuela.ListaCursos.RemoveAll(delegate (Curso cur) { return cur.Nombre == "301"; });

            ///Expresiones lamda que a la final también son un delegado
            escuela.ListaCursos.RemoveAll((Curso cur) => cur.Nombre == "401");

            ///Inclusive puede sin definir el tipo simplemente voy a recibir un cur esta lista es generica de Cursos
            ///por ende lo que voy a recibir de cur es de tipo Curso inclusive ya le incluyo.
            escuela.ListaCursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada == TiposJornada.Manana);

            ImprimirCursosEscuela(escuela);

            int a, b, c;
            a = 7;
            b = a;
            c = b++;
            b = a + b * c;
            c = a >= 100 ? b : c / 10;
            a = (int)Math.Sqrt(b * b + c * c);

            string s = "String literal";
            char l = s[s.Length - 1];

            var numbers = new List<int>(new[] { 1, 2, 3 });
            b = numbers.FindLast(n => n > 1);

            var direction = Directions.Right;
            Console.WriteLine($"Map view direction is {direction}");

            /* var orientation = direction switch
            {
                Directions.Up => Orientation.North,
                Directions.Right => Orientation.East,
                Directions.Down => Orientation.South,
                Directions.Left => Orientation.West,
            };
            Console.WriteLine($"Cardinal orientation is {orientation}"); */
        }

        //////========= Inicio Etapa 4 ==========

        private static void ImprimirCursosEscuelaEtapa4(Escuela escuela)
        {
            WriteLine("===========");
            WriteLine("Curso de la Escuela. List");
            WriteLine("===========");

            if (escuela?.ListaCursos != null)
            {
                foreach (var curso in escuela.ListaCursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}, Jornada {curso.Jornada}");
                }
            }
        }

        /////========== Fin Etapa 4 ==========

        ///Va llamar a este método o función por cada uno de los cursos que esta en la lista 
        ///va preguntar este objeto que se le paso a esta función tiene nombre 301.
        ///el que retorne verdadero es el que va borrar.
        ///Esto en C++ esto se llama un apuntador a una función el que me va ejecutar un código,
        ///me determina si hago o no hago tengo que hacer.
        ///Un delegado me especifica que parámetros de entrada y que parámetros de salida tiene un función.
        ///En C# debe cumplir Funciones seguras.
        private static bool Predicado(Curso cursoobj)   ////////, string codigo="")
        {
            return cursoobj.Nombre == "301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("===========");
            WriteLine("Curso de la Escuela. Arreglo");
            WriteLine("===========");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}");
                }
            }

            WriteLine("===========");
            WriteLine("Curso de la Escuela. List");
            WriteLine("===========");

            if (escuela?.ListaCursos != null)
            {
                foreach (var curso in escuela.ListaCursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}, Jornada {curso.Jornada}");
                }
            }

            /* if (escuela != null && escuela.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}");
                }
            } */

            /* if (escuela.Cursos == null)
                return;
            else
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}");
                }
            } */
        }
        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, id {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, id {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}");
            }
        }

        public enum Directions
        {
            Up,
            Down,
            Right,
            Left
        }

        public enum Orientation
        {
            North,
            South,
            East,
            West
        }

    }
}
