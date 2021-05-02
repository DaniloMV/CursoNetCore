using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _dicionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicionarioObjetoEscuela)
        {
            ///Nombre de una variable de un objeto, el dinamicamente va construir el campo.
            ///Vamos hacer que falle nuestra aplicación, si mi diccionario es nulo de plano no podemos visualizar el reporte.
            ///el nombre de que de una variable, de un objeto el dinamicammente va construir el nombre de ese campo.
            if (dicionarioObjetoEscuela == null)
                throw new ArgumentNullException(nameof(dicionarioObjetoEscuela));

            _dicionario = dicionarioObjetoEscuela;
        }

        ///Como acceder de forma segura a los miembros de un diccionario.
        public IEnumerable<Escuela> GetListaEscuela()
        {
            IEnumerable<Escuela> respuesta;
            //Es una buena práctica consultar las llaves del diccionario de manera diferente.
            //Cuando ustedes no sean el que crearon el diccionario  y no sepan que tanta logica hay.
            //se debe independizar la extracción de los datos y la estruccturación de los datos en la forma,
            //que se presenta, estamos trabajando en un reporteador que se extrae los datos.
            //// _dicionario[LlaveDiccionario.Evaluacion];

            //Me devuelve un null por defecto.
            ///var lista = _dicionario.GetValueOrDefault(LlaveDiccionario.Escuela);

            //Intente obtener un valor
            //Me devuelve la firma de este método.
            if (_dicionario.TryGetValue(LlaveDiccionario.Escuela,
                                    out IEnumerable<ObjetoEscuelaBase> lista))
            {
                //Lo que vamos hacer es castear la lista en el caso que sea positivo
                //al valor que debemos devolver 
                respuesta = lista.Cast<Escuela>();
            }
            else
            {
                //Escribir en el log de la auditoria.
                respuesta = null;
            }

            return respuesta;
        }

        ///Como entrego una lista de evaluaciones
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_dicionario.TryGetValue(LlaveDiccionario.Evaluacion,
                                    out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                ///Nos retorne una lista vacía
                return lista.Cast<Evaluacion>();
            }
        }

        ///Que necesitamos saber las asignaturas que han sido evaluadas.
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            ///Lo primero que debemos saber es la lista de evaluaciones.
            listaEvaluaciones = GetListaEvaluaciones();
            ///sobre esta lista de evaluaciones vamos hacer una consulta
            ///de cada evaluación en nuestra lista de evaluaciones 
            ///seleccione la evaluación el nombre de la asignatura

            ///Establezco primero un origen de datos 
            //comienzo siempre por una sentencia en este caso from 
            //Estoy diciendo por cada objeto en mi lista de objetos haga

            //aca le podemos especificar textualmente  cual es el tipo de 
            //mi lista de objetos ya sabemos que Evaluacion
            //por cada evaluación, evaluacion estamos declarando una variable(evaluacion)

            //por cada evaluación de mi lista de evaluaciones le voy a manejar con el nombre de variable evaluacion
            //seleccioneme de todos los datos que traje seleccionemede 
            //cada una de las evaluaciones que encontrado seleccioneme la asignatura.

            ///Tiene más sentido que le diga que solo me traiga algunos tipos de evaluaciones con el comando where
            //donde la nota de evaluación sea 3.0f (f)decimal 

            //Que a este grupo de evaluación traigame solo cosas distintas (Distinct) 
            //que sean diferentes cual va ser el atributo 
            return (from Evaluacion evaluacion in listaEvaluaciones
                    where evaluacion.Nota >= 3.0f
                    select evaluacion.Asignatura.Nombre).Distinct();


        }

        //Hago una sobrecarga del método
        public IEnumerable<string> GetListaAsignaturas()
        {
            //Queda solucionado cuando no quiero pasar un parametro de salida
            return GetListaAsignaturas(
                out var dummy);
        }

        ///Lista de evaluaciones por asignatura 
        //Es un diccionario
        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluacionesXAsignatura()
        {
            var diccionarioRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            //modificamos GetListaAsignaturas como para que variable de salida
            //nos entregara las evaluaciones 
            //No porque aca no le vayamos a obtener 
            //
            var listaAsig = GetListaAsignaturas(out var listaEvaluaciones);

            ///Recoreos el bucle de todas las asignaturas que obtuvimos con el método disting
            foreach (var asignatura in listaAsig)
            {
                //Por cada una de las asignaturas consultamos todas la evaluaciones

                //pero solo traemos evaluaciones cuyo nombre de asignatura coincida
                //con la asignatura actual.
                var evalsAsignatura = from eval in listaEvaluaciones
                                      where eval.Asignatura.Nombre == asignatura
                                      select eval;

                diccionarioRta.Add(asignatura, evalsAsignatura);
            }

            return diccionarioRta;
        }

        //Nos entregue una lista por cada alumno el promedio de cada asignatura.
        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignatura()
        {
            var respuesta = new Dictionary<string, IEnumerable<object>>();

            var dicEvaluacionesXAsignatura = GetDicEvaluacionesXAsignatura();

            ///Esto es un key value pair una entrada al diccionario que tiene 
            ///tiene un idententificador string y una lista de evaluaciones
            //vamos a traer todas las evaluaciones, con esas evaluaciones de cada asignatura sacar el promedio.
            ///
            foreach (var asigConEvaluaciones in dicEvaluacionesXAsignatura)
            {
                ///Linq siempre nos devuelve listas.
                var promedioAlumnos = from evaluciones in asigConEvaluaciones.Value
                                      group evaluciones by new { evaluciones.Alumno.UniqueId, evaluciones.Alumno.Nombre }
                into grupoEvaAlumno
                                      ///Para cada evaluaciones de esta asignatura
                                      ///entregar la información del alumno.
                                      ///Lo que voy a devolver es un objeto compuesto lo que se llama anonimo.
                                      ///un nuevo elemento está estructurado de la siguiente forma.
                                      //cuando ya esta definido debemos asignar a un nombre(AlumnoNombre NombreEvaluacion)
                                      //En linq existe agrupamiento que vamos agrupar por nota y alumno.
                                      //Para una vez agrupado podamos extraer el promedio de notas.
                                      /*select new {
                                          evaluciones.UniqueId,
                                          AlumnoNombre = evaluciones.Alumno.Nombre,
                                          NombreEvaluacion =evaluciones.Nombre, 
                                          evaluciones.Nota
                                      };*/
                                      ///El grupoEvaAlumno.Key es lo mismo evaluciones.Alumno.UniqueId 
                                      ///El nuevo objeto que vamos a crear ahora solo nos falta el promedio
                                      /*
                                      select new
                                      {
                                          AlumnoId = grupoEvaAlumno.Key,
                                          ///con  que campo voy a calular la nota utilizo landa (=>)
                                          Promedio = grupoEvaAlumno.Average(evaluacion => evaluacion.Nota)
                                      };*/
                                      select new AlumnoPromedio
                                      {
                                          alumnoId = grupoEvaAlumno.Key.UniqueId,
                                          alumnoNombre = grupoEvaAlumno.Key.Nombre,
                                          promedio = grupoEvaAlumno.Average(evaluacion => evaluacion.Nota)
                                      };
                //Es un string que representa una asignatura, el key es el nombre de la asignatura,
                //
                respuesta.Add(asigConEvaluaciones.Key, promedioAlumnos);

            }

            return respuesta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignaturaTop(int topMejores)
        {
            var respuesta = new Dictionary<string, IEnumerable<object>>();

            var dicEvaluacionesXAsignatura = GetDicEvaluacionesXAsignatura();

            foreach (var asigConEvaluaciones in dicEvaluacionesXAsignatura)
            {
                var promedioAlumnos = from evaluciones in asigConEvaluaciones.Value
                                      group evaluciones by new { evaluciones.Alumno.UniqueId, evaluciones.Alumno.Nombre }
                into grupoEvaAlumno
                                      select new AlumnoPromedio
                                      {
                                          alumnoId = grupoEvaAlumno.Key.UniqueId,
                                          alumnoNombre = grupoEvaAlumno.Key.Nombre,
                                          promedio = grupoEvaAlumno.Average(evaluacion => evaluacion.Nota)
                                      };
                respuesta.Add(asigConEvaluaciones.Key, promedioAlumnos);
            }
            return respuesta;
        }

    }
}