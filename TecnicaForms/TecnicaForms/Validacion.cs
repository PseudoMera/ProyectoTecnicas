using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace login
{
    class Validacion
    {
        public Estudiante estu = new Estudiante();
        public bool validarTexto(string s, out string errorMessage)
        {

            if (Regex.IsMatch(s, @"[0-9_-]{1,}"))
            {
                errorMessage = "Solo puede insertar letras y espacio.";
                return false;
            }
            errorMessage = "";
            return true;
        }

        public bool validarNumeros(string s, string campo, out string errorMessage)
        {

            if (Regex.IsMatch(s, @"[a-zA-Z_-]+"))
            {
                errorMessage = "Solo puede insertar digitos";
                return false;
            }

            if (campo == "credito")
            {
                if (Convert.ToInt32(s) > 6)
                {
                    errorMessage = "El maximo numero de creditos son 6.";
                    return false;
                }
            }else if(campo == "calificacion")
            {
                if (Convert.ToInt32(s) > 100 || Convert.ToInt32(s) < 0)
                {
                    errorMessage = "La nota maxima son 100 puntos y la minima son 0 puntos.";
                    return false;
                }

            }

            errorMessage = "";
            return true;
        }


        public bool validarUsuario(string usuario, out string errorMessage)
        {
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            Estudiante estu = new Estudiante();
            if(estudiantes.FirstOrDefault(x => x.usuario == usuario) == null)
            {
                errorMessage = "El usuario no existe.";
                return false;
            }
            else
            {
                estu = estudiantes.FirstOrDefault(x => x.usuario == usuario);
            }
          
            errorMessage = "";
            return true;
        }

        public bool validarClave(string clave, string usuario, out string errorMessage)
        {
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            estu = estudiantes.Find(x => x.usuario == usuario);
            if (estu.contrasena != clave)
            {
                errorMessage = "La clave no es valida.";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public bool validarNombreUsuario(string usuario, out string errorMessage)
        {
            Datos data = new Datos();
            List<Estudiante> estudiantes = new List<Estudiante>();
            data.cargarEstudiantes();
            estudiantes = data.obtenerEstudiantes();
            estu = estudiantes.FirstOrDefault(x => x.usuario == usuario);
           if(estu != null)
            {
                errorMessage = "Ya existe este usuario, por favor crear otro.";
                return false;
            }

            errorMessage = "";
            return true;
        }

    }
}
