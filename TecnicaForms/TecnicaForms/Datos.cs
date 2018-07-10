using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreLinq;

namespace login
{
    class Datos
    {
        private List<Materia> materias = new List<Materia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();
        public string ruta = System.IO.Directory.GetCurrentDirectory();

       public void cargarMaterias()
        {
            int inicio = 0;
            string dir = ruta + "\\materias.xml";
            XElement xelement = XElement.Load(dir);
            IEnumerable<XElement> materiasCargadas = xelement.Elements();
            // Read the entire XML
            foreach (var asignatura in materiasCargadas)
            {
                Materia mate = new Materia();

                mate.materiaNombre = asignatura.Element("Nombre").Value;
                mate.materiaCodigo = asignatura.Element("Codigo").Value;
                mate.materiaProfesor = asignatura.Element("Profesor").Value;
                mate.materiaCreditos = Convert.ToInt32(asignatura.Element("Creditos").Value);
                mate.materiaId = Convert.ToInt32(asignatura.Element("ID").Value);
                mate.materiaNota = Convert.ToInt32(asignatura.Element("Nota").Value);
                mate.calificacion = Convert.ToInt32(asignatura.Element("Calificacion").Value);
                mate.cantidadEstudiante = Convert.ToInt32(asignatura.Element("CantidadEstudiante").Value);
                mate.letra = asignatura.Element("Letra").Value;

                 for (int i = 0; i < inicio + mate.cantidadEstudiante; i++)
                {
                    mate.estudiantes.Add(new Estudiante()
                    {
                        // listBox1.Items.Add(xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value);
                        id = Convert.ToInt32(xelement.Descendants("Estudiante").ElementAt(i).Element("ID").Value),
                        nombre = xelement.Descendants("Estudiante").ElementAt(i).Element("Nombre").Value,
                        apellido = xelement.Descendants("Estudiante").ElementAt(i).Element("Apellido").Value,
                        carrera = xelement.Descendants("Estudiante").ElementAt(i).Element("Carrera").Value
                    });
                }

                materias.Add(mate);
                inicio += mate.cantidadEstudiante;

            }
            int cantidad = 0;
            //     var distinctItems =  materias.Select(x => x.materiaCodigo).Distinct();
            cantidad = materias.Count;
            DialogResult dialog = MessageBox.Show(cantidad.ToString(), "Salir", MessageBoxButtons.YesNo);
          //  var distinctItems = materias.DistinctBy(x => x.materiaCodigo).ToList();
           // materias.Clear();
           // cantidad = 0;
          //  foreach(var item in distinctItems)
         //   {
          //      materias.Add(item);
         //       cantidad++;
         //   }
        //  dialog = MessageBox.Show(cantidad.ToString(), "Salir", MessageBoxButtons.YesNo);
        }


       public void cargarEstudiantes()
         {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            XElement xelement = XElement.Load(ruta + "\\estudiantes.xml");
            IEnumerable<XElement> elementos = xelement.Elements();
            int inicio = 0;
            bool primero = true;
            // Read the entire XML
            foreach (var objeto in elementos)
            {
                Estudiante estu = new Estudiante();
                estu.nombre = objeto.Element("Nombre").Value;
                estu.apellido = objeto.Element("Apellido").Value;
                estu.carrera = objeto.Element("Carrera").Value;
                estu.usuario = objeto.Element("Usuario").Value;
                estu.id = Convert.ToInt32(objeto.Element("ID").Value);
                estu.cantidadMaterias = Convert.ToInt32(objeto.Element("CantidadMateria").Value);
                if (estu.cantidadMaterias > 0)
                {
                    for (int i = 0; i < inicio + estu.cantidadMaterias; i++)
                    {
                        materias.Add(new Materia()
                        {
                            // listBox1.Items.Add(xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value);
                            materiaCodigo = xelement.Descendants("Materia").ElementAt(i).Element("Codigo").Value,
                            materiaNombre = xelement.Descendants("Materia").ElementAt(i).Element("Nombre").Value,
                            materiaProfesor = xelement.Descendants("Materia").ElementAt(i).Element("Profesor").Value,
                            materiaCreditos = Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Creditos").Value),
                            materiaNota = Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Nota").Value),
                            calificacion = Convert.ToInt32(xelement.Descendants("Materia").ElementAt(i).Element("Calificacion").Value),
                            letra = xelement.Descendants("Materia").ElementAt(i).Element("Letra").Value
                        });
                    }
                    inicio += estu.cantidadMaterias;
                }
                estudiantes.Add(estu);
                primero = false;
            }
        }

        public List<Estudiante> obtenerEstudiantes()
        {
            return this.estudiantes;
        }

        public List<Materia> obtenerMaterias()
        {
            return this.materias;
        }

        public void agregarEstudiante(Estudiante estudianteAGuardar)
        {
            this.estudiantes.Add(estudianteAGuardar);
        }

        public void agregarMateria(Materia materiaAGuardar)
        {
            this.materias.Add(materiaAGuardar);
        }
        
        public void guardarEstudiantes()
        {
            string dir = ruta + "\\estudiantes.xml";
            cargarEstudiantes();
            var xEle = new XElement("Estudiantes",
                             from estudiante in estudiantes
                             select new XElement("Estudiante",
                                  new XElement("Usuario", estudiante.usuario),
                                  new XElement("Nombre", estudiante.nombre),
                                  new XElement("Apellido", estudiante.apellido),
                                  new XElement("Carrera", estudiante.carrera),
                                  new XElement("Contrasena", estudiante.contrasena),
                                  new XElement("ID", estudiante.id),
                                  new XElement("CantidadMateria", estudiante.cantidadMaterias),
                                  new XElement("Materias",
                                      from materia in estudiante.Materias
                                      select new XElement("Materia",
                                          new XElement("ID", materia.materiaId),
                                          new XElement("Codigo", materia.materiaCodigo),
                                          new XElement("Nombre", materia.materiaNombre),
                                          new XElement("Profesor", materia.materiaProfesor),
                                          new XElement("Creditos", materia.materiaCreditos),
                                          new XElement("Nota", materia.materiaNota),
                                          new XElement("Calificacion", materia.calificacion),
                                          new XElement("Letra", materia.letra)
                                        ))
                         ));

            xEle.Save(dir);

        }
        /*
        public void guardarMaterias(Materia materiaAGuardar)
        {
            string dir = ruta + "\\materias.xml";
            XElement xelement = XElement.Load(dir);
            IEnumerable<XElement> materiasCargadas = xelement.Elements();
            // Read the entire XML
            foreach (var asignatura in materiasCargadas)
            {
                materias.Add(new Materia()
                {
                    materiaNombre = asignatura.Element("Nombre").Value,
                    materiaCodigo = asignatura.Element("Codigo").Value,
                    materiaProfesor = asignatura.Element("Profesor").Value,
                    materiaCreditos = Convert.ToInt32(asignatura.Element("Creditos").Value),
                    materiaId = Convert.ToInt32(asignatura.Element("ID").Value)
                });

            }
            this.materias.Add(materiaAGuardar);
            List<Materia> materiasGuardar = new List<Materia>();
 
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
