using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenT2.Models
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public double Promedio { get; set; }

        public Alumno()
        {
            this.Promedio = (Nota1 + Nota2 + Nota3 + Nota4) / 4;
        }
    }
}