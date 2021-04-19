namespace CoreEscuela.Interfaces
{
    public interface ILugar
    {
        /*Las interfaces son soluciones alternativas para intentar manejar herencia 
        múltple, básicamente son firmas que exigen a las clases que la implementen 
        usar los métodos o propiedades estipulados, la diferencia entre una interface 
        y una clase, es que: en la interface no se puede asociar lógica de negocio 
        sobre sus métodos.
        */
        ///Es importante que una Interfaz no tiene modificadores de acceso, 
        ///todos deben ser publicos por eso no se le pone.
        public string Direccion { get; set; }

        ///Una Interfaz es una definición de una estructura que debe tener un objeto.
        ///Los objetos que implementen está Interfaz, deben cumplir con lo que se especifica.
        ///Una Interfaz es como un contrato, es como ud. va decir que va implementar está interfaz como minimo va ofrecer esta funcionalidad.
        void LimpiarLugar();
    }
}