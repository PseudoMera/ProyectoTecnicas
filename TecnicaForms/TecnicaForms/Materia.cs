using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    public class Materia
    {
        public int materiaId { get; set; }
        public string materiaNombre { get; set; }
        public string materiaCodigo { get; set; }
        public string materiaProfesor { get; set; }
        public int materiaCreditos { get; set; }
        public int materiaNota { get; set; }
        public string letra { get; set; }
        public int cantidadEstudiante { get; set; }
        public List<Estudiante> estudiantes { get; set; } 
        public bool materiaSeleccionada { get; set; }
        public double calificacion { get; set; }

    }
}