using System;

namespace CoreEscuela.Entidades
{
    public class EntidadSistema
    {
        //public string UniqueId { get; protected internal set; }
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public EntidadSistema()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}