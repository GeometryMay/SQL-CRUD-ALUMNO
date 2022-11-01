using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosEscritorio.modelo
{
    internal class Alumno
    {
        private string nombres;
        private int calificacion;

        public string Nombres { get => nombres; set => nombres = value; }
        public int Calificacion { get => calificacion; set => calificacion=value; }

        public Alumno()
        {
            this.nombres = "";
            this.calificacion = 0;
        }
    }
}
