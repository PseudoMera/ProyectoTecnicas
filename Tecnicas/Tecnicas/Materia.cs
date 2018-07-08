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
        public List<Estudiante> estudiantes { get; set; } = new List<Estudiante>();
        public bool materiaSeleccionada { get; set; }

    }
}
