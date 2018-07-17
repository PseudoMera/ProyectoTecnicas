using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace login
{
    class Datos
    {
        private List<Materia> materias = new List<Materia>();
        private List<Estudiante> estudiantes = new List<Estudiante>();
        private List<Profesor> profesores = new List<Profesor>();
        public string ruta = System.IO.Directory.GetCurrentDirectory();

       public void cargarMaterias()
        {
            if(!File.Exists(ruta + "\\materias.json"))
            {
                File.Create(ruta + "\\materias.json");
            }

            string prueba = System.IO.File.ReadAllText(ruta + "\\materias.json");
            materias = JsonConvert.DeserializeObject<List<Materia>>(prueba);
            if (materias == null)
                materias = new List<Materia>();
        }

        public void cargarProfesores()
        {
            if (!File.Exists(ruta + "\\profesores.json"))
            {
                using (FileStream fs = File.Create(ruta + "\\profesores.json"))
                {

                }
            }

            string prueba = System.IO.File.ReadAllText(ruta + "\\profesores.json");
            profesores = JsonConvert.DeserializeObject<List<Profesor>>(prueba);
            if (profesores == null)
                profesores = new List<Profesor>();
        }

       public void cargarEstudiantes()
         {

            if (!File.Exists(ruta + "\\estudiantes.json"))
            {
                File.Create(ruta + "\\estudiantes.json");
            }

            string prueba = System.IO.File.ReadAllText(ruta + "\\estudiantes.json");
            estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(prueba);
            if (estudiantes == null)
                estudiantes = new List<Estudiante>();

        }

        public List<Profesor> obtenerProfesor()
        {
            return this.profesores;
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
            cargarEstudiantes();
            this.estudiantes.Add(estudianteAGuardar);
            guardarEstudiantes();
        }

        public void agregarMateria(Materia materiaAGuardar)
        {
            cargarMaterias();
            this.materias.Add(materiaAGuardar);
            guardarMaterias();
        }

        public void agregarProfesor(Profesor profesorAGuardar)
        {
            cargarProfesores();
            this.profesores.Add(profesorAGuardar);
            guardarProfesores();
        }

        public void editarMateria(Materia actual, Materia nueva)
        {
            //Nombre - Codigo - Creditos - Profesor
            cargarMaterias();
            string oldId = actual.materiaId;
            int indice = materias.FindIndex(x => x.materiaId == actual.materiaId);
            if (indice != -1)
            {
                materias[indice] = nueva;
            }
            foreach (Materia mat in materias)
            {

                foreach (Estudiante estu in mat.estudiantes)
                {
                  foreach(Materia mate in estu.Materias)
                    {
                        if(mate.materiaId == oldId)
                        {
                            mate.materiaNombre = nueva.materiaNombre;
                            mate.materiaCodigo = nueva.materiaCodigo;
                        }
                    }

                }
            }
            
            guardarMaterias();

            cargarEstudiantes();

            foreach (Estudiante estu in estudiantes)
            {

                foreach (Materia mat in estu.Materias)
                {
                    if (mat.materiaId == oldId)
                    {
                        mat.materiaNombre = nueva.materiaNombre;
                        mat.materiaCodigo = nueva.materiaCodigo;
                    }

                }
            }

            guardarEstudiantes();

        }

        public void editarEstudiante(Estudiante actual, Estudiante nueva)
        {
            cargarEstudiantes();
            int indice = estudiantes.FindIndex(x => x.id == actual.id);
            if (indice != -1)
            {
                estudiantes[indice] = nueva;
            }
            guardarEstudiantes();
            cargarMaterias();

            for (int i = 0; i < materias.Count(); i++)
            {
                for (int q = 0; q < materias[i].estudiantes.Count(); q++)
                {
                    if (materias[i].estudiantes[q].id == nueva.id)
                    {
                        materias[i].estudiantes[q] = nueva;
                    }
                }
            }

            guardarMaterias();

        }

        public void editarProfesor(Profesor actual, Profesor nueva)
        {
            cargarProfesores();
            int indice = profesores.FindIndex(x => x.id == actual.id);
            string oldName = actual.nombre;
            if (indice != -1)
            {
                profesores[indice] = nueva;
            }
            guardarProfesores();

            cargarMaterias();
            if (oldName != nueva.nombre)
            {
                for (int i = 0; i < materias.Count(); i++)
                {

                    if (materias[i].materiaProfesor == oldName)
                    {
                        materias[i].materiaProfesor = nueva.nombre;
                    }

                    for (int q = 0; q < materias[i].estudiantes.Count(); q++)
                    {
                        for (int z = 0; z < materias[i].estudiantes[q].Materias.Count(); z++)
                        {
                            if (materias[i].estudiantes[q].Materias[z].materiaProfesor == oldName)
                            {
                                materias[i].estudiantes[q].Materias[z].materiaProfesor = nueva.nombre;
                            }
                        }
                    }

                }
                cargarEstudiantes();

                foreach (Estudiante estu in estudiantes)
                {

                    foreach (Materia mat in estu.Materias)
                    {
                        if (mat.materiaProfesor == oldName)
                        {
                            mat.materiaProfesor = nueva.nombre;
                        }

                    }
                }
                guardarEstudiantes();
                guardarMaterias();
            }
        }


        public void eliminarMateria(Materia eliminar)
        {
            cargarMaterias();
            int indice = materias.FindIndex(x => x.materiaCodigo == eliminar.materiaCodigo && x.materiaProfesor == eliminar.materiaProfesor);
            if (indice != -1)
            {
                materias.RemoveAt(indice);
            }
            guardarMaterias();

            cargarProfesores();
            foreach(Profesor p in profesores)
            {
                if(p.nombre == eliminar.materiaProfesor)
                {
                    p.cantidadMaterias--;
                }
            }
            guardarProfesores();
        }

        public void elimiarProfesor(Profesor eliminar)
        {
            cargarProfesores();
            int indice = profesores.FindIndex(x => x.id == eliminar.id);
            if (indice != -1)
            {
                profesores.RemoveAt(indice);
            }
            guardarProfesores();

        }

        public void eliminarEstudiante(Estudiante eliminar)
        {
            cargarEstudiantes();
            int indice = estudiantes.FindIndex(x => x.id == eliminar.id);
            if (indice != -1)
            {
                estudiantes.RemoveAt(indice);
            }
            guardarEstudiantes();

            cargarMaterias();
            foreach(Materia mat in materias)
            {
                List<Estudiante> rest = new List<Estudiante>();
                for(int q = 0; q < mat.estudiantes.Count(); q++)
                {
                    if(mat.estudiantes[q].id != eliminar.id)
                    {
                        rest.Add(mat.estudiantes[q]);
                    }
                }
                mat.estudiantes = rest;
            }

            guardarMaterias();
            

        }


        public void guardarEstudiantes()
        {
            string dir = ruta + "\\estudiantes.json";
            string res = JsonConvert.SerializeObject(estudiantes, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dir, res);
        }
        
        public void guardarMaterias()
        {
            string dir = ruta + "\\materias.json";
            string res = JsonConvert.SerializeObject(materias, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dir, res);
        }

        public void guardarProfesores()
        {
            string dir = ruta + "\\profesores.json";
            string res = JsonConvert.SerializeObject(profesores, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(dir, res);
        }

    }
}
