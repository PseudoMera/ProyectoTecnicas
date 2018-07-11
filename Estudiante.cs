using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    public class Estudiante
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string carrera { get; set; }
        public string contrasena { get; set; }
        public double indiceTrimestral { get; set; }
        public string gradoHonor { get; set; }
        public int id { get; set; }
        public List<Materia> Materias { get; set; } = new List<Materia>();
        public int cantidadMaterias { get; set; }
    }
}
