using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicas
{
    class Materia
    {
        public int materiaId { get; set; }
        public string materiaNombre { get; set; }
        public string materiaCodigo { get; set; }
        public string materiaProfesor { get; set; }
        public int materiaCreditos { get; set; }
        public int materiaNota { get; set; }
        public string letra { get; set; }
        public List<Estudiante> estudiantes { get; set; } = new List<Estudiante>();
        public bool materiaSeleccionada { get; set; }

        
        public double calificacion { get; set; } //representa la cantidad de puntos que vale cada materia en base a 4
        public double puntos { get; set; } //representa los puntos una vez multiplicado calificacion * creditos

    }
}
