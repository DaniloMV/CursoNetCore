using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : EntidadSistema
    {
        /////public Evaluacion() => (this.UniqueId) = Guid.NewGuid().ToString();

        ///La evaluación debe ser presentada por un Alumno, esta evaluación
        ///fue presentada por una Persona 
        ///Esa persona es un Alumno de la clase Alumno 
        public Alumno Alumno { get; set; }

        ///Debe ser consiente que esta Evaluación pertence a una Asignatura.
        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }
    }
}