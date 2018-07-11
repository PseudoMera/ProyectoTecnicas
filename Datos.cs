using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MoreLinq;
using System.Xml.Serialization;
using System.IO;

namespace login
{
    class Datos
    {
        private List<Materia> materias = new List<Materia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();
        public string ruta = System.IO.Directory.GetCurrentDirectory();

       public void cargarMaterias()
        {

            string prueba = System.IO.File.ReadAllText(ruta + "\\materias.json");
            materias = JsonConvert.DeserializeObject<List<Materia>>(prueba);
            //  dialog = MessageBox.Show(cantidad.ToString(), "Salir", MessageBoxButtons.YesNo);
        }


       public void cargarEstudiantes()
         {
            string prueba = System.IO.File.ReadAllText(ruta + "\\estudiantes.json");
            estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(prueba);

        }

        public List<Estudiante> obtenerEstudiantes()
        {
            return this.estudiantes;
        }

        public void editarMateria(Materia actual, Materia nueva)
        {
            if(materias == null)
            {
                materias = new List<Materia>();
            }
            cargarMaterias();
            int indice = materias.FindIndex(x => x.materiaCodigo == actual.materiaCodigo && x.materiaProfesor == actual.materiaProfesor);
            MessageBox.Show(indice.ToString(), "save", MessageBoxButtons.YesNo);
            if (indice != -1)
            {
                MessageBox.Show("Cambio", "save", MessageBoxButtons.YesNo);
                materias[indice] = nueva;
            }
            guardarMaterias();

        }

        public void eliminarMateria(Materia eliminar)
        {
            if (materias == null)
            {
                materias = new List<Materia>();
            }
            cargarMaterias();
            int indice = materias.FindIndex(x => x.materiaCodigo == eliminar.materiaCodigo && x.materiaProfesor == eliminar.materiaProfesor);
            if (indice != -1)
            {
                materias.RemoveAt(indice);
            }
            guardarMaterias();

        }

        public List<Materia> obtenerMaterias()
        {
            return this.materias;
        }

        public void agregarEstudiante(Estudiante estudianteAGuardar)
        {
            if(estudiantes == null)
            {
                estudiantes = new List<Estudiante>();
            }
            cargarEstudiantes();
            this.estudiantes.Add(estudianteAGuardar);
            guardarEstudiantes();
        }

        public void agregarMateria(Materia materiaAGuardar)
        {
            if(materias == null)
            {
                materias = new List<Materia>();
            }
            cargarMaterias();
            this.materias.Add(materiaAGuardar);
            guardarMaterias();
        }
        
        public void guardarEstudiantes()
        {
            string dir = ruta + "\\estudiantes.json";
            //  cargarEstudiantes();
            string res = JsonConvert.SerializeObject(estudiantes, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dir, res);
        }
        
        public void guardarMaterias()
        {
            string dir = ruta + "\\materias.json";
            //  cargarEstudiantes();
            string res = JsonConvert.SerializeObject(materias, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dir, res);
        }
        /*
       public void guardarMateriasActuales()
        {
            string dir = ruta + "\\materias.xml";
            XElement xelement = XElement.Load(dir);
            IEnumerable<XElement> materiasCargadas = xelement.Elements();
            // Read the entire XML
            foreach (var asignatura in materiasCargadas)
            {
                Materia prueba = new Materia()
                {
                    materiaNombre = asignatura.Element("Nombre").Value,
                    materiaCodigo = asignatura.Element("Codigo").Value,
                    materiaProfesor = asignatura.Element("Profesor").Value,
                    materiaId = Convert.ToInt32(asignatura.Element("ID").Value),
                    materiaCreditos = Convert.ToInt32(asignatura.Element("Creditos").Value),
                    materiaNota = Convert.ToInt32(asignatura.Element("Nota").Value),
                    letra = asignatura.Element("Letra").Value,
                    calificacion = Convert.ToDouble(asignatura.Element("Calificacion").Value)
                };
                if(!materias.Contains(prueba))
                     materias.Add(prueba);
            }

            var xEle = new XElement("Materias",
                             from materia in materias
                             select new XElement("Materia",
                                  new XElement("ID", materia.materiaId),
                                  new XElement("Codigo", materia.materiaCodigo),
                                  new XElement("Nombre", materia.materiaNombre),
                                  new XElement("Profesor", materia.materiaProfesor),
                                  new XElement("Creditos", materia.materiaCreditos),
                                  new XElement("Nota", materia.materiaNota),
                                  new XElement("Calificacion", materia.calificacion),
                                  new XElement("Letra", materia.letra),
                                  new XElement("Estudiantes",
                                      from estudiante in materia.estudiantes
                                      select new XElement("Estudiante",
                                          new XElement("Usuario", estudiante.usuario),
                                          new XElement("Nombre", estudiante.nombre),
                                          new XElement("Apellido", estudiante.apellido),
                                          new XElement("Carrera", estudiante.carrera),
                                          new XElement("Contrasena", estudiante.contrasena),
                                          new XElement("ID", estudiante.id)
                                        ))
                         ));
            xEle.Save(ruta + "\\materias.xml");
        }
        */

    }
}
