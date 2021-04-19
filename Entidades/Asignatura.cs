using System;

namespace CoreEscuela.Entidades
{
    public class Asignatura : EntidadSistema
    {
        public Asignatura() => (this.UniqueId) =(Guid.NewGuid().ToString());
    }
}