using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }
        public int AñoDeCreación { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

       public List<Curso> Cursos { get; set; }           

        public Escuela(string nombre, int año)
        {
            this.nombre = nombre;
            this.AñoDeCreación = año;
        }

        public Escuela(string nombre, int año, TiposEscuela tipos, string Pais = "", string Ciudad = "")
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            this.Pais = Pais;
            this.Ciudad = Ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}