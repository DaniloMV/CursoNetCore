using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        ////public Alumno() => (this.UniqueId) = (Guid.NewGuid().ToString());
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}