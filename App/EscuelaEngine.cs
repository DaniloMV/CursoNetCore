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

        public  List<ObjetoEscuelaBase> GetObjetosEscuela()
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

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.ListaCursos)
            {
                ///Tenga en cuenta algo a cada Curso le vamos a ingresar la misma lista de Asignaturas.
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{ Nombre = "Matemáticas" },
                    new Asignatura{ Nombre = "Educación Física" },
                    new Asignatura{ Nombre = "Castellano" },
                    new Asignatura{ Nombre = "Ciencias Naturales" }
                };
                ///curso.Asignaturas.AddRange(listaAsignaturas);

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> CargarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
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
    }
}