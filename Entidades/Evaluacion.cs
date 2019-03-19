using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string UniqueId { get; private set; }
        public string Asignatura { get; set; }
        public double Calificacion { get; set; }
        public string Alumno { get; set; }
        public string Nombre { get; set; }
        
        public Evaluacion(string Nombre,string Asignatura, double Calificacion, string Alumno ){
           this.UniqueId =  Guid.NewGuid().ToString();
           this.Asignatura = Asignatura;
           this.Nombre = Nombre;
           this.Alumno = Alumno;
           this.Calificacion = Calificacion;
        } 
    }
}