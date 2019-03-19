using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public void Inicializar()
        {
            //Creamos Una Escuela
            Escuela = new Escuela("Aza Academy", 2019, TiposEscuela.Primaria, Ciudad: "Saltillo", Pais: "México");
            CargarCursos(Escuela);
            Curso.ImprimirCursos(Escuela);
            CargarAsignaturas(Escuela);
            CargarAlumnos(Escuela);
            CargarEvaluaciones(Escuela);

            //Remover colecciónes que cumplan con una condición usando expresiones Lambda
            // escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada == TiposJornada.Noche);

        }

        private void CargarEvaluaciones(Escuela escuela)
        {
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    //Lista de Evaluaciones de Alumnos
                    List<Evaluacion> LEA = new List<Evaluacion>();
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            double calif = Math.Round(DoubleRandom(0.0, 5.0), 2);

                            var eval = new Evaluacion(
                                $"{asignatura.Nombre} ev #{i}",
                                asignatura.Nombre,
                                calif,
                                alumno.Nombre
                            );

                            LEA.Add(eval);
                        }

                        alumno.Evaluaciones = LEA;
                    }
                }
            }
        }

        private void CargarAlumnos(Escuela escuela)
        {
            Random r = new Random();
            foreach (var curso in escuela.Cursos)
            {
                r.Next(5, 10);
                var listAlumnos = GenerarAlumnos(5);
                curso.Alumnos = listAlumnos;
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listAlumnos = from n1 in nombre1
                              from n2 in nombre2
                              from a1 in apellido1
                              select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();

        }

        private void CargarAsignaturas(Escuela escuela)
        {
            foreach (var curso in escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matemáticas"} ,
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private void CargarCursos(Escuela escuela)
        {
            escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101 - Primer Grado" , Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201 - Segundo Grado", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301 - Tercer Grado",  Jornada = TiposJornada.Mañana}
            };

            //Agregamos un Curso mas
            Curso tmp = new Curso { Nombre = "401 - Cuarto grado", Jornada = TiposJornada.Mañana };
            Escuela.Cursos.Add(tmp);
        }
        static double DoubleRandom(double min, double max)
        {
            Random r = new Random();
            return r.NextDouble() * 5;
        }
    }
}