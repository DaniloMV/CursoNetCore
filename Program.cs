using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
using System.Linq;
using CoreEscuela.Interfaces;
using CoreEscuela.App;
using System.Text;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Etapa 9

            Printer.WriteTitle("Captura de una evaluación por Consola.");

            var newEval = new Evaluacion();

            string nombre, notaEvaluacion;
            float nota;


            WriteLine("Ingrese el nombre de la evaluación.");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                ///throw new ArgumentException("El valor del nombre no puede ser nulo.");
                Printer.WriteTitle("El valor del nombre no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido creada correctamente.");
            }

            WriteLine("Ingrese la nota de la evaluación.");
            Printer.PresioneEnter();
            notaEvaluacion = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(notaEvaluacion))
            {
                ////throw new ArgumentException("El valor de la nota no puede ser vacío.");
                Printer.WriteTitle("El valor de la nota no puede ser vacío");
                WriteLine("Saliendo del programa");

            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaEvaluacion);

                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("la nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresada correctamente.");
                }
                catch (ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es número valido. ");
                    WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.WriteTitle("Finalmente");
                    Printer.Beep(2500, 500, 3);
                }
            }

            return;



            #region Etapa 8
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("==== Etapa 8 ====");

            //Para que me visualice el mensaje de error.
            ////var reporteador = new Reporteador(null);

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evaluacionesList = reporteador.GetListaEvaluaciones();

            ///Nos importa la lista de asignaturas que han sido evaluadas 3.0f no me importa si han sido evaluadas varias veces.
            var listaAsignaturas = reporteador.GetListaAsignaturas();
            var listaEvaXAsig = reporteador.GetDicEvaluacionesXAsignatura();
            var listaPromedioXAsig = reporteador.GetPromedioAlumnoPorAsignatura();


            var listaPromedioXAsigTop5 = reporteador.GetPromedioAlumnoPorAsignaturaTop(5);

            return;

            #endregion


            ///Inicio de la Etapa 7 Funcionalidades Variables de Salida, Diccionario de Datos
            #region Etapa 7

            ///Un evento genera varias acciones, este evento se dispara cada vez que finaliza la aplicación
            ///cada vez que ocurre este evento haga algo.
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            ///Es sumale a lo que ya tiene es como una sobre carga del operador.
            ///Tengo mi controlador de Eventos, sumele a lo que ya hice.
            ///vamos a colocarle como una expresión lamda 
            ///vamos a poner un pitido diferente, Necesito tener la firma del Evento
            ///un objeto y unos argumentos, asi no los tenga me va pedir (0,s)
            ///Lo que se puede decir es un multicast delegate que recibe muchos delegados.
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1);
            ///Ya no quiero este manejador de Evento o este predicado.
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;


            ///var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("==== Etapa 7 ====");
            //Printer.Beep(1000, cantidad: 10);
            ImprimirCursosEscuelaEtapa4(engine.Escuela);
            //Ya no es una lista es una tupla una colección de dos valores.

            var listaObjetosSinEvaluciones = engine.GetObjetosEscuela(isTraeEvaluaciones: false);

            var listaObjetosEvaluacionesConteo = engine.GetObjetosEscuela(
                true, false, false, false);

            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos,
                true, false, false, false);
            ///Aca si me permite agregar ya que no es de solo lectura
            listaObjetos.Add(new Evaluacion { Nombre = "Curso Loco" });

            var listaObjetosLectura = engine.GetObjetosEscuelaLectura(
                out conteoEvaluaciones,
                out conteoAlumnos,
                out conteoAsignaturas,
                out conteoCursos,
                true, false, false, false);

            ///Yo trato de adicionar una Evaluación me sale una advertencia ya que es solo de lectura
            ////listaObjetosLectura.Add( new Evaluacion{Nombre="Curso Loco"});

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Danilo");
            diccionario.Add(23, "Pedro Cando");
            ///Tambien puedo adicionar objetos de esta manera.
            diccionario[0] = "Pekerman";

            foreach (var keyvalorPair in diccionario)
            {
                WriteLine($"key: {keyvalorPair.Key}, Valor: {keyvalorPair.Value}");
            }

            Printer.WriteTitle("Acceso a Diccionario");
            ///Me devuelve una cadena
            WriteLine(diccionario[23]);
            WriteLine(diccionario[0]);
            Printer.WriteTitle("Otro Diccionario");
            ///Diciconario Polimórfico: Que tiene o puede tener varias formas.
            var dic = new Dictionary<string, string>();

            dic["Luna"] = "Cuerpo celeste que gira al rededor de Planeta Tierra.";

            foreach (var keyvalorPair in dic)
            {
                WriteLine($"key: {keyvalorPair.Key}, Valor: {keyvalorPair.Value}");
            }
            ///Las llaves en los diccionarios son irrepetibles.
            dic["Luna"] = "Protagonista de Soy Luna";
            WriteLine(dic["Luna"]);

            var diccionariotemporal = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(diccionariotemporal, true);





            return;

            #endregion


            ///Inicio de la Etapa #6 Interfaces
            #region Etapa 6
            ////var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("==== Etapa 6 ====");
            //Printer.Beep(1000, cantidad: 10);
            ImprimirCursosEscuelaEtapa4(engine.Escuela);

            ////var listaObjetos = engine.GetObjetosEscuela();

            ///engine.Escuela.LimpiarLugar();

            #region INTERFACE vs ABSTRACT CLASS
            /*
            INTERFACE vs ABSTRACT CLASS

            1)Access Specifier 1)Especificador de Acceso

            C# INTERFACE
            In C#, Interface cannot have access specifier for functions. It is public by default.
            En C#, Interface no puede tener especificador de acceso a funciones, es PUBLICO por defecto.

            C# ABSTRACT CLASS
            In C#, abstract class can have access specifier for functions.
            En # La Clase abstracta puede tener especificador de acceso para funciones.

            2) Implementation 2) Implementación

            C# INTERFACE
            In C#, an interface can only have signature not the implementation.
            En C#, una interface solo puede tener firma o declaraciones pero no la implementación.

            C# ABSTRACT CLASS
            Abstract class can provide complete implementation.
            Una clase abstracta puede proporcionar una implementación completa en su definición.

            3) Speed 3) Velocidad

            C# INTERFACE
            Interface is comparatively slow.
            Interface es comparativamente lento.

            C# ABSTRACT CLASS
            Abstract class is fast.
            Clase abstracta es rápida.

            4) Instantiate 4) Instanciamiento

            C# INTERFACE
            Interface is absolutely abstract and cannot be instantiated.
            la interfaz es absolutamente abstracta y no puede ser instanciada.

            C# ABSTRACT CLASS
            Abstract class cannot be instantiated.
            La clase abstracta no puede ser instanciada.

            5) Fields 5) Campos

            C# INTERFACE
            Interface cannot have fields.
            La interfaz no puede tener campos.

            C# ABSTRACT CLASS
            Abstract class can have defined and constants.
            La clase abstracta puede tener campos definidos y constantes.

            6) Methods 6) Métodos

            C# INTERFACE
            Interface has only abstract methods.
            La interfaz solamente tiene métodos abstractos.

            C# ABSTRACT CLASS
            Abstract class can have non-abstract methods.
            La clase abstracta puede tener métodos no abstractos.
            */
            #endregion

            ///Podemos extender el polimorfismo a travez de Interfaces.
            ///Debemos pensar las Interfaces de algo más abstracto, que solo objeto de Interfaces de C#
            ///Hemos utilizado interfaces para cumplir una funcionalidad especifica.
            ///de los objetos que cumplan con la implementación de la Interfaz.
            var listaILugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

            ///La nueva lista me trae solo objetos de Alumnos.
            var listaAlumnos = from obj in listaObjetos
                               where obj is Alumno
                               select (Alumno)obj;

            ///return;
            #endregion

            ///Inicio Etapa 5 Herencia - Polimorfismo
            #region Etapa 5
            ////var engine = new EscuelaEngine();
            ////engine.Inicializar();
            Printer.WriteTitle("==== Etapa 5 ====");
            //Printer.Beep(1000, cantidad: 10);
            ImprimirCursosEscuelaEtapa4(engine.Escuela);

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

            /*
             ///Una clase abstacta no se puede instanciar si se le quita abstrac es para un ejemplo
             var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Underwood" };
             Printer.WriteTitle("ObjetoEscuelaBase");
             WriteLine($"Alumno: {objDummy.Nombre}");
             WriteLine($"Alumno: {objDummy.UniqueId}");
             WriteLine($"Alumno: {objDummy.GetType()}"); */

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

            var evaluacion = new Evaluacion() { Nombre = "Evaluación de Matemáticas", Nota = 4.7f };
            Printer.WriteTitle("Evaluación");
            WriteLine($"Evaluación: {evaluacion.Nombre}");
            WriteLine($"Evaluación: {evaluacion.UniqueId}");
            WriteLine($"Evaluación: {evaluacion.Nota}");
            WriteLine($"Evaluación: {evaluacion.GetType()}");

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            ///Evaluación no es compatible con Alumno.
            ///El polimorfismo es bueno nos puede llevar a cometer errores.
            ///alumnoTest = (Alumno)evaluacion;

            //Si es posible convertirle 
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            ob = evaluacion;
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            ///ob as Alumno = Objeto le puede tomar como Alumno (Tome este objeto como si fuera este objeto).
            ///El me va devolver el objeto transformado como Alumno,
            ///Pero si objeto no me puede transformar como alumno me va devolver null.
            Alumno alumnoRecuperado2 = ob as Alumno;

            ///Esto seria una pregunta subsecuente

            if (alumnoRecuperado2 != null)
            {

            }


            ////return;

            #endregion

            ///Etapa 4 Generar Colecciones
            #region Etapa 4
            /* var engine = new EscuelaEngine();
            engine.Inicializar();

            ////Printer.DibujarLinea();
            Printer.WriteTitle("==== Etapa 4 ====");
            Printer.Beep(1000,cantidad:10);
            ImprimirCursosEscuelaEtapa4(engine.Escuela);

            return; */
            #endregion

            //////========= Inicio Etapa 3  Arreglos ==========
            #region Etapa 3

            /*  var escuela = new Escuela("Sisfel", 2021);
             escuela.Pais="Ecuador";
             escuela.Ciudad ="Cuenca";
             escuela.TipoEscuela = TiposEscuela.Primaria;

             Console.WriteLine(escuela); */


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

            #endregion

        }

        #region Etapa 7
        ///Este es un apuntador a una función de un delegado.
        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }
        #endregion

        #region Etapa 4
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
        #endregion


        #region Etapa 3
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
        #endregion

        #region Loop
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


        #endregion

        #region Enum
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
        #endregion 

    }
}
