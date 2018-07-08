using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecnicas
{
    class Program
    {
        public static List<Materia> listaMateria = new List<Materia>();
        public static List<Estudiante> listaEstudiante = new List<Estudiante>();
        public static int contadorMateria = 0;
        static void Main(string[] args)
        {
            MenuAdmin();
        }

        public static void RegistrarEstudiante()
        {
            Console.Clear();
            Estudiante estudiante = new Estudiante();
            estudiante.id = listaEstudiante.Count() + 1;
            Console.WriteLine("Introduzca el usuario del estudiante: ");
            estudiante.usuario = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Introduzca la contraseña: ");
            estudiante.contrasena = Console.ReadLine();
            bool nombre = true;
            string nombreEstudiante = "";
            do
            {
                Console.WriteLine("Nombre del estudiante: ");
                nombreEstudiante = Console.ReadLine();
                nombre = ValidarTexto(nombreEstudiante);
            } while (nombre);
            estudiante.nombre = nombreEstudiante;
            bool apellido = true;
            string apellidoEstudiante = "";
            do
            {
                Console.WriteLine("Apellido del estudiante: ");
                apellidoEstudiante = Console.ReadLine();
                apellido = ValidarTexto(apellidoEstudiante);
            } while (apellido);
            estudiante.apellido = apellidoEstudiante;
            Console.Clear();
            Console.WriteLine("Introduzca la carrera del estudiante: ");
            estudiante.carrera = Console.ReadLine();
            string op = "";
            int valor = -1;
            List<Materia> materiasActuales = new List<Materia>();
            materiasActuales = estudiante.Materias;
            do
            {
                Console.Clear();
                MostrarMaterias(listaMateria, 1);
                Console.WriteLine("Selecciona sus materias con el ID o escriba 0 para salir al menu principal: ");
                bool prueba = true;
                do
                {
                    op = Console.ReadLine();
                    prueba = ValidarNumeros(op);
                } while (prueba);
                valor = Int32.Parse(op);
                bool aqui = false;
                Materia proof = listaMateria.Where(x => x.materiaId == valor).FirstOrDefault();
                if (proof != null)
                {
                    Materia materiaTomada = materiasActuales.Where(y => y.materiaId == valor).FirstOrDefault();
                    if (materiaTomada != null)
                    {
                        Console.WriteLine("Ya tiene esta materia seleccionada, seleccione otra.");
                        aqui = true;
                    }
                }
                else
                {
                    Console.WriteLine("La materia no existe.");
                    aqui = true;
                }
                if (!aqui)
                {
                    estudiante.Materias.Add(proof);
                    foreach (Materia mate in listaMateria)
                    {
                        if (mate == proof)
                        {
                            mate.estudiantes.Add(estudiante);
                            break;
                        }
                    }
                    Console.WriteLine("La materia ha sido seleccionada satisfactoriamente.");
                }
                Console.ReadKey();
                aqui = false;
            } while (valor != 0);
            listaEstudiante.Add(estudiante);

        }

        public static void MenuAdmin()
        {         
            string op = "";
            do
            {
                Console.WriteLine("Seleccione la opcion que desea utilizar: ");
                Console.WriteLine("1- Materia");
                Console.WriteLine("2- Estudiante");
                Console.WriteLine("3- Registrar");
                Console.WriteLine("4- Listar estudiantes");
                Console.WriteLine("5- Salir");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        MenuMateria();
                        break;
                    case "2":
                        Console.Clear();
                        MenuEstudiante();
                        break;
                    case "3":
                        RegistrarEstudiante();
                        break;
                    case "4":
                        MostrarEstudiantes(listaEstudiante, 1);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (op != "5");
            return;
        }

        public static void MenuMateria()
        {
            
            string op = "";
            do
            {
                MostrarMaterias(listaMateria, 1);
                Console.WriteLine("Seleccione la opcion que desea utilizar: ");
                Console.WriteLine("1- Agregar materia");
                Console.WriteLine("2- Editar materia");
                Console.WriteLine("3- Eliminar materia");
                Console.WriteLine("4- Salir");
                op = Console.ReadLine(); 
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        AgregarMateria();
                        break;
                    case "2":
                        Console.Clear();
                        EditarMateria();
                        break;
                    case "3":
                        Console.Clear();
                        EliminarMateria();
                        break;
                    case "4":
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (op != "4");
            return;
        }

        public static void MostrarMaterias(List<Materia> materias, int inicio)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cantidad de materias registrados: {0}", materias.Count());
            Console.WriteLine("\n");
            Console.SetCursorPosition(0, inicio);
            Console.Write("Nombre");
            Console.SetCursorPosition(20, inicio);
            Console.Write("Codigo");
            Console.SetCursorPosition(35, inicio);
            Console.Write("ID");
            Console.SetCursorPosition(42, inicio);
            Console.Write("Profesor");
            Console.SetCursorPosition(60, inicio);
            Console.Write("Creditos");
            Console.SetCursorPosition(69, inicio);
            Console.Write("Cantidad de estudiantes");
            foreach (Materia e in materias)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, inicio + 1);
                Console.Write(e.materiaNombre);
                Console.SetCursorPosition(20, inicio + 1);
                Console.Write(e.materiaCodigo);
                Console.SetCursorPosition(35, inicio + 1);
                Console.Write(e.materiaId);
                Console.SetCursorPosition(42, inicio + 1);
                Console.Write(e.materiaProfesor);
                Console.SetCursorPosition(60, inicio + 1);
                Console.Write(e.materiaCreditos);
                Console.SetCursorPosition(69, inicio + 1);
                Console.Write(e.estudiantes.Count);
                inicio++;
            }
            Console.WriteLine("\n");
            return;
        }

        public static void AgregarMateria()
        {
            Materia materia = new Materia();
            Console.WriteLine("Escriba nombre de la materia: ");
            materia.materiaNombre = Console.ReadLine();
            Console.Clear();
            string codigoMateria = "";
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Introduzca el codigo de la materia:");
                    codigoMateria = Console.ReadLine();
                } while (codigoMateria == "");
                var estu = listaMateria.FirstOrDefault(c => c.materiaCodigo == codigoMateria);
                while (estu != null)
                {
                    Console.Clear();
                    Console.WriteLine("Ya existe una materia con el misma codigo. Introduzca otra: ");
                    codigoMateria = Console.ReadLine();
                    estu = listaMateria.FirstOrDefault(c => c.materiaCodigo == codigoMateria);
                }
                Console.Clear();
            } while (codigoMateria == "");
            materia.materiaCodigo = codigoMateria;
            Console.Clear();
            bool profesor = true;
            string nombreProfesor = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Escriba el profesor de la materia: ");
                nombreProfesor = Console.ReadLine();
                profesor = ValidarTexto(nombreProfesor);
            } while (profesor);
            materia.materiaProfesor = nombreProfesor;
            Console.Clear();
            bool creditos = true;
            string valorCreditos = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Escriba la cantidad de creditos: ");
                valorCreditos = Console.ReadLine();
                creditos = ValidarNumeros(valorCreditos);
            } while (creditos);
            materia.materiaCreditos = Int32.Parse(valorCreditos);
            Console.Clear();
            Console.WriteLine("Materia guardada!");
            contadorMateria++;
            materia.materiaId = contadorMateria;
            materia.materiaNota = -1;
            materia.materiaSeleccionada = false;
            listaMateria.Add(materia);
            Console.ReadKey();
            return;
        }

        public static void EditarMateria()
        {          
            bool prueba;
            string valor = "";
            do
            {
                do
                {
                    Console.Clear();
                    MostrarMaterias(listaMateria, 1);
                    Console.WriteLine("Introduzca el ID de la materia a editar: ");
                    valor = Console.ReadLine();
                    prueba = ValidarNumeros(valor);
                } while (prueba);
            } while (valor == "");
            int val = Int32.Parse(valor);
            var e = listaMateria.FirstOrDefault(c => c.materiaId == val);
            List<Materia> lista = new List<Materia>();
            lista.Add(e);
            if (e != null)
            {
                string res = "";
                while (res != "0")
                {
                    MostrarMaterias(lista, 1);

                    Console.WriteLine("Introduzca el campo que desea modificar o 0 si no desea modificar mas nada: ");
                    res = Console.ReadLine();
                    res = res.ToUpper();

                    if (res == "0")
                        break;
                    while (res != "NOMBRE" && res != "PROFESOR" && res != "CODIGO" && res != "0" && res != "CREDITOS")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Introduzca un campo valido (nombre, codigo, area, creditos o 0)");

                        res = Console.ReadLine();
                        res = res.ToUpper();
                    }
                    if (res == "0")
                        break;
                    Console.Clear();
                    string valor2 = "";
                    if (res.Contains("NOMBRE"))
                    {
                        Console.Clear();
                        Console.WriteLine("Introduzca el nombre de la materia: ");
                        valor2 = Console.ReadLine();
                        e.materiaNombre = valor2;
                    }
                    else if (res.Contains("CODIGO"))
                    {
                        Console.Clear();
                        Console.WriteLine("Introduzca el valor para modificar el codigo: ");
                        valor2 = Console.ReadLine();
                        var estu = listaMateria.FirstOrDefault(c => c.materiaCodigo == valor2);
                        while (estu != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Ya existe una materia con el misma codigo. Introduzca otra: ");
                            valor2 = Console.ReadLine();
                            estu = listaMateria.FirstOrDefault(c => c.materiaCodigo == valor2);
                        }
                        Console.Clear();
                        e.materiaCodigo = valor2;

                    }              
                    else if (res.Contains("PROFESOR"))
                    {
                        bool profesor = true;
                        string nombreProfesor = "";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Escriba el profesor de la materia: ");
                            nombreProfesor = Console.ReadLine();
                            profesor = ValidarTexto(nombreProfesor);
                        } while (profesor);
                        e.materiaProfesor = nombreProfesor;
                    }
                    else if (res.Contains("CREDITOS"))
                    {
                        bool creditos = true;
                        string valorCreditos = "";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Escriba la cantidad de creditos: ");
                            valorCreditos = Console.ReadLine();
                            creditos = ValidarNumeros(valorCreditos);
                        } while (creditos);
                        e.materiaCreditos = Int32.Parse(valorCreditos);
                    }
                    Console.WriteLine("Se ha completado la modificacion.");
                }
            }
            else
            {
                Console.WriteLine("La materia no existe. Volviendo al menu anterior");
            }
            Console.ReadKey();
            Console.Clear();
            return;
        }
        
        public static void EliminarMateria()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string res = "";
            do
            {
                Console.Clear();
                MostrarMaterias(listaMateria, 1);
                Console.WriteLine("Introduzca el ID de la materia que desea borrar");
                res = Console.ReadLine();
            } while (res == "");
            int id = Convert.ToInt32(res);
            Console.Clear();
            Materia materia = listaMateria.FirstOrDefault(e => e.materiaId == id);
            List<Materia> lista = new List<Materia>();
            lista.Add(materia);
            if (materia != null)
            {
                if (materia.estudiantes.Count == 0)
                {
                    MostrarMaterias(lista, 1);

                    string respuesta = "";
                    Console.WriteLine("Esta seguro que desea borrar el siguiente estudiante (si/no): ");
                    respuesta = Console.ReadLine();
                    respuesta = respuesta.ToLower();
                    if (respuesta.Contains("si"))
                    {
                        listaMateria.Remove(materia);
                        Console.WriteLine("La materia ha sido borrado satisfactoriamente.");
                    }
                    else
                    {
                        Console.WriteLine("La operacion ha sido cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Ya existen estudiantes registrados en esta materia");
                }
            }
            else
                Console.WriteLine("La materia no existe.");
            Console.ReadKey();
            return;
        }

        public static void MenuEstudiante()
        {
            string op = "";
            do
            {
                Console.Clear();
                Console.WriteLine("1- Ver materias estudiante.");
                Console.WriteLine("2- Borrar estudiante");
                Console.WriteLine("3- Salir");
                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        //FALTA AQUI
                        break;
                    case "2":
                        Console.Clear();
                        EliminarEstudiante();
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
                Console.Clear();
            } while (op != "3");
            return;
        }

        public static void MostrarEstudiantes(List<Estudiante> estudiantes, int inicio)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cantidad de estudiante registrados: {0}", estudiantes.Count());
            Console.WriteLine("\n");
            Console.SetCursorPosition(0, inicio);
            Console.Write("Nombre");
            Console.SetCursorPosition(20, inicio);
            Console.Write("Apellido");
            Console.SetCursorPosition(40, inicio);
            Console.Write("ID");
            Console.SetCursorPosition(55, inicio);
            Console.Write("Indice Trimestral");
            Console.SetCursorPosition(70, inicio);
            Console.Write("Grado de Honor");
            Console.SetCursorPosition(85, inicio);
            Console.Write("Cantidad de materias");
            foreach (Estudiante e in estudiantes)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, inicio + 1);
                Console.Write(e.nombre);
                Console.SetCursorPosition(20, inicio + 1);
                Console.Write(e.apellido);
                Console.SetCursorPosition(40, inicio + 1);
                Console.Write(e.id);
                Console.SetCursorPosition(55, inicio + 1);
                Console.Write(e.indiceTrimestral);
                Console.SetCursorPosition(70, inicio + 1);
                Console.Write(e.gradoHonor);
                Console.SetCursorPosition(85, inicio + 1);
                Console.Write(e.Materias.Count);
                inicio++;
            }
            Console.WriteLine("\n");
            Console.ReadKey();
            return;
        }

        public static void EliminarEstudiante()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string res = "";
            do
            {
                Console.Clear();
                MostrarEstudiantes(listaEstudiante, 1);
                Console.WriteLine("Introduzca el ID del estudiante que desea borrar");
                res = Console.ReadLine();
            } while (res == "");
            int id = Convert.ToInt32(res);
            Console.Clear();
            Estudiante estudiante = listaEstudiante.FirstOrDefault(e => e.id == id);
            List<Estudiante> lista = new List<Estudiante>();
            lista.Add(estudiante);
            if (estudiante != null)
            {
                MostrarEstudiantes(lista, 1);
                string respuesta = "";
                Console.WriteLine("Esta seguro que desea borrar el siguiente estudiante (si/no): ");
                respuesta = Console.ReadLine();
                respuesta = respuesta.ToLower();
                if (respuesta.Contains("si"))
                {
                    listaEstudiante.Remove(estudiante);
                    Console.WriteLine("El estudiante ha sido borrado satisfactoriamente.");
                }
                else
                {
                    Console.WriteLine("La operacion ha sido cancelada.");
                }                         
            }
            else
                Console.WriteLine("El estudiante no existe.");
            Console.ReadKey();
            return;
        }

        public static bool ValidarNumeros(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidarTexto(string texto)
        {
            foreach (char c in texto)
            {
                if (!Char.IsLetter(c) && c != ' ')
                {
                    return true;
                }
            }
            if (string.IsNullOrWhiteSpace(texto))
            {
                return true;
            }
            return false;
        }
    }
}
