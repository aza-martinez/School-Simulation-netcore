using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
        class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();    
            Printer.WriteTitle($"Bienvenidos a la Escuela {engine.Escuela.Nombre}");
        }
    }
}
