using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace login
{
    class Datos
    {
        private List<Materia> materias = new List<Materia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();
        public string ruta = System.IO.Directory.GetCurrentDirectory();

        public List<Materia> obtenerMaterias()
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
                    materiaId = Convert.ToInt32(asignatura.Element("ID").Value),
                    materiaNota = Convert.ToInt32(asignatura.Element("Nota").Value),
                    calificacion = Convert.ToInt32(asignatura.Element("Calificacion").Value),
                    letra = asignatura.Element("Letra").Value
                });

            }

            return this.materias;
        }

        public List<Estudiante> obtenerEstudiantes()
        {
            return this.estudiantes;
        }

        public void guardarEstudiantes(Estudiante estudianteAGuardar)
        {
            string dir = ruta + "\\estudiantes.xml";
            XElement xelement = XElement.Load(dir);
            IEnumerable<XElement> estudiantesCargados = xelement.Elements();
            // Read the entire XML
            foreach (var student in estudiantesCargados)
            {
                estudiantes.Add(new Estudiante() { usuario = student.Element("Usuario").Value,
                    nombre = student.Element("Nombre").Value,
                    apellido = student.Element("Apellido").Value,
                    carrera = student.Element("Carrera").Value,
                    contrasena = student.Element("Contrasena").Value,
                    cantidadMaterias = Convert.ToInt32(student.Element("CantidadMateria").Value),
                    id = Convert.ToInt32(student.Element("ID").Value)
                });
                
            }
            //This throws an exception when we do the sign up without selecting a subject
            //Implement the try catch for this 
            foreach(Materia mate in estudianteAGuardar.Materias)
            {

                Estudiante estu = new Estudiante();
                estu.usuario = estudianteAGuardar.usuario;
                estu.nombre = estudianteAGuardar.nombre;
                estu.apellido = estudianteAGuardar.apellido;
                estu.carrera = estudianteAGuardar.carrera;
                estu.contrasena = estudianteAGuardar.contrasena;
                foreach(Materia mater in materias)
                {
                    if(mater == mate)
                    {
                        mater.estudiantes.Add(estu);
                    }
                }
            }
            guardarMateriasActuales();
            this.estudiantes.Add(estudianteAGuardar);
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
            xEle.Save(ruta + "\\estudiantes.xml");

        }

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


    }
}
