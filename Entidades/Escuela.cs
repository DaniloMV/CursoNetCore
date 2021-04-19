using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase
    {
        ///public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        
        /* string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }
        */
        public int AnioCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        ///Lista generica de Cursos
        public List<Curso> ListaCursos { get; set; }
        public Curso[] Cursos { get; set; }

        /* public Escuela(string nombreEntrada, int anio)
        {
            this.nombre = nombreEntrada;
            AnioCreacion = anio;
        } */

        //////Como pasar con tuplas
        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);

        ///Valores opcionales
        public Escuela(string nombre, int anio,
                        TiposEscuela tipos,
                        string pais = "", string ciudad = "")
        {
            //Asignación de tuplas
            (Nombre, AnioCreacion) = (nombre, anio);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            /////return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}