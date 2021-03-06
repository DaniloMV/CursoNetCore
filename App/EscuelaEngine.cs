using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.Entidades
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Sisfel", 2021, TiposEscuela.Primaria,
                            ciudad: "Cuenca", pais: "Ecuador"
                    );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario,
                        bool isImprimirEvaluacion = false)
        {
            foreach (var objetodiccionario in diccionario)
            {
                Printer.WriteTitle(objetodiccionario.Key.ToString());

                foreach (var valor in objetodiccionario.Value)
                {
                    switch (objetodiccionario.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (isImprimirEvaluacion)
                                Console.WriteLine(valor);
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine($"Escuela: {valor}");
                            break;
                        case LlaveDiccionario.Curso:
                            var cursotemporal = valor as Curso;
                            if (cursotemporal != null)
                            {
                                ////int cantidadAlumnos = ((Curso)valor).Alumnos.Count;
                                Console.WriteLine($"Curso: {valor.Nombre}, Cantidad Alumnos: { cursotemporal.Alumnos.Count }");
                            }
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine($"Alumno: {valor}");
                            break;
                        default:
                            Console.WriteLine(valor);
                            break;
                    }

                    /* if (valor is Evaluacion)
                    {
                        if (isImprimirEvaluacion)
                            Console.WriteLine(valor);
                    }
                    else if (valor is Escuela)
                        Console.WriteLine($"Escuela: {valor}");
                    else if (valor is Alumno)
                        Console.WriteLine($"Alumno: {valor}");
                    else
                        Console.WriteLine(valor); */
                }
            }
        }
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.ListaCursos);

            var listaTemporalAsignaturas = new List<Asignatura>();
            var listaTemporalAlumnos = new List<Alumno>();
            var listaTemporalEvaluaciones = new List<Evaluacion>();

            foreach (var curso in Escuela.ListaCursos)
            {
                listaTemporalAsignaturas.AddRange(curso.Asignaturas);
                listaTemporalAlumnos.AddRange(curso.Alumnos);
                curso.Alumnos.ForEach(alumno =>
                    listaTemporalEvaluaciones.AddRange(alumno.Evaluaciones));

                /* foreach (var alumno in curso.Alumnos)
                {
                    listaTemporalEvaluaciones.AddRange(alumno.Evaluaciones);
                } */
            }

            diccionario.Add(LlaveDiccionario.Asignatura, listaTemporalAsignaturas);
            diccionario.Add(LlaveDiccionario.Alumno, listaTemporalAlumnos.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion, listaTemporalEvaluaciones);
            return diccionario;
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
          bool isTraeEvaluaciones = true,
          bool isTraeAlumnos = true,
          bool isTraeAsignaturas = true,
          bool isTraeCursos = true
          )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public List<ObjetoEscuelaBase> GetObjetosEscuela(
          out int conteoEvaluaciones,
          bool isTraeEvaluaciones = true,
          bool isTraeAlumnos = true,
          bool isTraeAsignaturas = true,
          bool isTraeCursos = true
          )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public List<ObjetoEscuelaBase> GetObjetosEscuela(
          out int conteoEvaluaciones,
          out int conteoCursos,
          bool isTraeEvaluaciones = true,
          bool isTraeAlumnos = true,
          bool isTraeAsignaturas = true,
          bool isTraeCursos = true
          )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out conteoCursos);
        }
        public List<ObjetoEscuelaBase> GetObjetosEscuela(
          out int conteoEvaluaciones,
          out int conteoCursos,
          out int conteoAsignaturas,
          bool isTraeEvaluaciones = true,
          bool isTraeAlumnos = true,
          bool isTraeAsignaturas = true,
          bool isTraeCursos = true
          )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out conteoAsignaturas, out conteoCursos);
        }

        ///Los par??metros opcionales tiene que listar al ??ltimo
        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool isTraeEvaluaciones = true,
            bool isTraeAlumnos = true,
            bool isTraeAsignaturas = true,
            bool isTraeCursos = true
            )
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (isTraeCursos)
                listaObj.AddRange(Escuela.ListaCursos);

            conteoCursos = Escuela.ListaCursos.Count;

            foreach (var curso in Escuela.ListaCursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;

                if (isTraeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (isTraeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                conteoAlumnos += curso.Alumnos.Count;

                if (isTraeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj;
        }

        ///Es de modo de solo lectura.
        ///Igual todos los m??todos me deben devolver una lista de solo lectura.
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuelaLectura(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool isTraeEvaluaciones = true,
            bool isTraeAlumnos = true,
            bool isTraeAsignaturas = true,
            bool isTraeCursos = true
            )
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (isTraeCursos)
                listaObj.AddRange(Escuela.ListaCursos);

            conteoCursos = Escuela.ListaCursos.Count;

            foreach (var curso in Escuela.ListaCursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;

                if (isTraeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (isTraeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                conteoAlumnos += curso.Alumnos.Count;

                if (isTraeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }


        public (List<ObjetoEscuelaBase>, int) GetObjetosEscuelaTupla(
            bool isTraeEvaluaciones = true,
            bool isTraeAlumnos = true,
            bool isTraeAsignaturas = true,
            bool isTraeCursos = true
            )
        {
            int conteoEvaluaciones = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (isTraeCursos)
                listaObj.AddRange(Escuela.ListaCursos);


            foreach (var curso in Escuela.ListaCursos)
            {
                if (isTraeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (isTraeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (isTraeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return (listaObj, conteoEvaluaciones);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.ListaCursos);
            foreach (var curso in Escuela.ListaCursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);
                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }
            return listaObj;
        }


        #region  M??todos de Carga
        private void CargarEvaluaciones()
        {
            //Recorro los Cursos creados
            foreach (var curso in Escuela.ListaCursos)
            {
                //Recorro las Asignaturas creadas en el Curso
                foreach (var asignatura in curso.Asignaturas)
                {
                    //Recorro los Alumnos creados en el Curso
                    foreach (var alumno in curso.Alumnos)
                    {
                        alumno.Evaluaciones.AddRange(CargarEvaluacionAlAzar(alumno, asignatura));
                    }
                }
            }
        }

        private List<Evaluacion> CargarEvaluacionAlAzar(Alumno alumno, Asignatura asignatura)
        {
            var listaEvaluaciones = new List<Evaluacion>();

            for (int i = 1; i <= 5; i++)
            {
                listaEvaluaciones.Add(new Evaluacion
                {
                    Alumno = alumno,
                    Asignatura = asignatura,
                    Nombre = $" Parcial: { i } ",
                    Nota = Nota()
                });
            }
            return listaEvaluaciones;
        }

        private float Nota()
        {
            Random rdm = new Random();
            decimal nota = rdm.Next(0, 50) / Math.Round((decimal)10, 1);
            return (float)nota;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.ListaCursos)
            {
                ///Tenga en cuenta algo a cada Curso le vamos a ingresar la misma lista de Asignaturas.
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{ Nombre = "Matem??ticas" },
                    new Asignatura{ Nombre = "Educaci??n F??sica" },
                    new Asignatura{ Nombre = "Castellano" },
                    new Asignatura{ Nombre = "Ciencias Naturales" }
                };
                ///curso.Asignaturas.AddRange(listaAsignaturas);

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> CargarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicol??s" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            ///Esto es un producto Cartesiano seleccionamos estos datos,
            ///vamos hacer como un select seleccioneme, creeme un nuevo alumno
            ///y ese Alumno tiene unos atributos que le vamos a llenar 
            ///pero el Nombre cual va ser tenemos ese producto Cartesiano,
            ///vamos a genrar una cadena formateada 
            ///
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.ListaCursos = new List<Curso>{
                new Curso { Nombre = "101", Jornada = TiposJornada.Manana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Manana },
                new Curso { Nombre = "301", Jornada = TiposJornada.Manana },
                new Curso { Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Tarde }
            };
            Random rnd = new Random();

            foreach (var curso in Escuela.ListaCursos)
            {
                ///curso.Alumnos.AddRange(CargarAlumnos());
                int cantidadRandom = rnd.Next(5, 20);
                curso.Alumnos = CargarAlumnosAlAzar(cantidadRandom);
            }
        }
        #endregion
    }
}