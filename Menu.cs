using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Menu
    {

        ArbolGeneral arbol = new ArbolGeneral();

        public Menu()
        {

        }
        /* Métodos */

        public void modAdmin()
        {
            Console.Clear();
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("MÓDULO ADMINISTRACIÓN");
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("1-Ingresar dominio nuevo");
            System.Console.WriteLine("2-Eliminar equipo");
            System.Console.WriteLine("3-Regresar al menú principal");
            Console.Write("Opcion: ");

        }

        public void modConsulta()
        {
            Console.Clear();
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("MÓDULO CONSULTAS");
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("1-Imprimir la red actual");
            System.Console.WriteLine("2-Ver equipo con su dirección IP y servicios");
            System.Console.WriteLine("3-Ver todos los equipos de un subdominio(Subdominio/Equipos)");
            System.Console.WriteLine("4-Cantidad de ");
            System.Console.WriteLine("5-Regresar al menú principal");
            Console.Write("Opcion: ");
        }

        public void imprimirArbol()
        {
            int cantNodos = arbol.ancho();
            if (cantNodos == 1)
            {
                System.Console.WriteLine("Red vacía. Ingrese dominios para visualizar");
            }
            else
            {
                arbol.armarImprimirRed(arbol, cantNodos);
            }

        }

        public void ingresarDatos()
        {
            bool continuarIngreso;
            continuarIngreso = true;
            try
            {
                while (continuarIngreso)
                {
                    Console.Clear();
                    System.Console.WriteLine("Paso 1 / Ingresar nombre de dominio completo, es.wikipedia.org");

                    Regex validarURL = new Regex(@"^(?!(?:www\.)?google\.com)([\da-zA-Z.-]+)\.([a-zA-Z.]{2,6})([\/\w .-]*)*\/?$");
                    string nombreDominio = Console.ReadLine();
                    string[] nombreDominioArray = nombreDominio.Split('.');
                    while (nombreDominioArray.Count() <= 2)
                    {
                        System.Console.WriteLine("Debe ingresar un dominio válido, vuelva a intentarlo");
                        nombreDominio = Console.ReadLine();
                        nombreDominioArray = nombreDominio.Split('.');
                    }
                    while (!validarURL.IsMatch(nombreDominio))
                    {
                        System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                        nombreDominio = Console.ReadLine();
                    }

                    Cola<Nodo> cola = separarDominioSupInfIngreso(nombreDominio, false);
                    Cola<Nodo> colaIngresar = separarDominioSupInfIngreso(nombreDominio, true);
                    if (!arbol.verificarURL(cola))
                    {
                        arbol.ingresarNodo(colaIngresar);
                        System.Console.WriteLine("Ingreso exitoso");
                        System.Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        continuarIngreso = false;
                        Console.Clear();
                    }
                    else
                    {
                        System.Console.WriteLine("Atención! Se encontró la URL. ¿Desea sobreescribir el equipo? (s/n)");
                        string seleccion = Console.ReadLine().ToUpper();
                        while (seleccion == "S")
                        {
                            if (seleccion == "" && seleccion != "S" && seleccion != "N")
                            {
                                System.Console.WriteLine("Opción incorrecta, vuelva a ingresar (s/n)");
                                seleccion = Console.ReadLine().ToUpper();
                            }
                            else if (seleccion == "S")
                            {
                                arbol.ingresarNodo(colaIngresar);
                                System.Console.WriteLine("Ingreso exitoso");
                                System.Console.WriteLine("Presione una tecla para continuar...");
                                Console.ReadKey();
                                continuarIngreso = false;
                                Console.Clear();
                                break;
                            }
                        }
                        if (seleccion == "N")
                        {
                            continuarIngreso = false;

                        }
                        else
                        {
                            continuarIngreso = true;
                        }
                    }

                }

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public void eliminarDatos()
        {
            bool continuarEliminacion;
            continuarEliminacion = true;
            try
            {
                while (continuarEliminacion)
                {
                    Console.Clear();
                    System.Console.WriteLine("Paso 1 / Ingresar nombre de dominio completo, es.wikipedia.org");

                    Regex validarURL = new Regex(@"^(?!(?:www\.)?google\.com)([\da-zA-Z.-]+)\.([a-zA-Z.]{2,6})([\/\w .-]*)*\/?$");
                    string nombreDominio = Console.ReadLine();
                    string[] nombreDominioArray = nombreDominio.Split('.');
                    while (nombreDominioArray.Count() <= 2)
                    {
                        System.Console.WriteLine("Debe ingresar un dominio válido");
                        nombreDominio = Console.ReadLine();
                        nombreDominioArray = nombreDominio.Split('.');
                    }
                    while (!validarURL.IsMatch(nombreDominio))
                    {
                        System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                        nombreDominio = Console.ReadLine();
                    }

                    Cola<Nodo> cola = separarDominioSupInfIngreso(nombreDominio, true);
                    Cola<Nodo> colaEliminar = separarDominioSupInfIngreso(nombreDominio, true);

                    if (arbol.verificarURL(cola))
                    {
                        arbol.eliminarNodoHoja(colaEliminar);
                        System.Console.WriteLine("Eliminación exitosa");
                        System.Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        continuarEliminacion = false;
                        Console.Clear();
                    }
                    else
                    {
                        System.Console.WriteLine("URL no encontrada. ¿Desea volver a intentarlo? (s/n)");
                        string seleccion = Console.ReadLine().ToUpper();
                        while (seleccion == "S")
                        {
                            if (seleccion == "" && seleccion != "S" && seleccion != "N")
                            {
                                System.Console.WriteLine("Opción incorrecta, vuelva a ingresar (s/n)");
                                seleccion = Console.ReadLine().ToUpper();
                            }
                            else if (seleccion == "S")
                            {
                                continuarEliminacion = true;
                                break;
                            }
                        }
                        if (seleccion == "N")
                        {
                            continuarEliminacion = false;

                        }
                        else
                        {
                            continuarEliminacion = true;
                        }
                    }

                }

            }
            catch (System.Exception)
            {

                throw;
            }

            System.Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();

        }

        public void buscarEquipo()
        {
            bool continuarBusqueda;
            continuarBusqueda = true;
            try
            {
                while (continuarBusqueda)
                {
                    System.Console.WriteLine("Paso 1 / Ingresar nombre de dominio completo, es.wikipedia.org");
                    Regex validarURL = new Regex(@"^(?!(?:www\.)?google\.com)([\da-zA-Z.-]+)\.([a-zA-Z.]{2,6})([\/\w .-]*)*\/?$");
                    string nombreDominio = Console.ReadLine();
                    string[] nombreDominioArray = nombreDominio.Split('.');
                    while (nombreDominioArray.Count() <= 2)
                    {
                        System.Console.WriteLine("Debe ingresar un dominio válido");
                        nombreDominio = Console.ReadLine();
                        nombreDominioArray = nombreDominio.Split('.');
                    }
                    while (!validarURL.IsMatch(nombreDominio))
                    {
                        System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                        nombreDominio = Console.ReadLine();
                    }

                    Cola<Nodo> cola = separarDominioSupInfIngreso(nombreDominio, true);
                    Cola<Nodo> colaBuscar = separarDominioSupInfIngreso(nombreDominio, true);
                    if (arbol.verificarURL(cola))
                    {
                        string resultado = arbol.imprimirEquipo(colaBuscar);
                        Console.Write(resultado);
                        System.Console.WriteLine(" ");
                        System.Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        continuarBusqueda = false;
                        Console.Clear();
                    }
                    else
                    {
                        System.Console.WriteLine("Equipo no encontrado. ¿Desea volver a iniciar la búsqueda? (s/n)");
                        string seleccion = Console.ReadLine().ToUpper();
                        while (seleccion == "S")
                        {
                            if (seleccion == "" && seleccion != "S" && seleccion != "N")
                            {
                                System.Console.WriteLine("Opción incorrecta, vuelva a ingresar (s/n)");
                                seleccion = Console.ReadLine().ToUpper();
                            }
                            else if (seleccion == "S")
                            {
                                continuarBusqueda = true;
                                break;
                            }
                        }
                        if (seleccion == "N")
                        {
                            continuarBusqueda = false;

                        }
                        else
                        {
                            continuarBusqueda = true;
                        }

                    }


                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public void imprimirEquiposSubdominio()
        {
            System.Console.WriteLine("Paso 1 / Ingresar nombre de dominio completo, es.wikipedia.org");
            Regex validarURL = new Regex(@"^(?!(?:www\.)?google\.com)([\da-zA-Z.-]+)\.([a-zA-Z.]{2,6})([\/\w .-]*)*\/?$");
            string nombreDominio = Console.ReadLine();
            string[] nombreDominioArray = nombreDominio.Split('.');
            while (nombreDominioArray.Count() <= 1)
            {
                System.Console.WriteLine("Debe ingresar un dominio válido");
                nombreDominio = Console.ReadLine();
                nombreDominioArray = nombreDominio.Split('.');
            }
            while (!validarURL.IsMatch(nombreDominio))
            {
                System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                nombreDominio = Console.ReadLine();
            }

            Cola<Nodo> cola = separarDominioSupInfIngreso(nombreDominio, true);
            arbol.mostrarEquiposSubdominio(cola);
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void buscarCantidadPorProfundidad()
        {
            Console.Clear();
            System.Console.WriteLine("Ingrese la profundidad: ");
            int profundidad = int.Parse(Console.ReadLine());
            int cantidad = arbol.imprimirCantidadPorProfundidad(profundidad);
            System.Console.WriteLine(cantidad);
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static Cola<Nodo> separarDominioSupInfIngreso(string nomDominio, bool buscarNodo)
        {
            string tipo = "";
            string[] nombreDominioArray = nomDominio.Split('.');
            //Lo doy vuelta si voy a ingresar dominios
            // if (!buscarNodo)
            // {
            Array.Reverse(nombreDominioArray);
            // }

            Cola<Nodo> cola = new Cola<Nodo>();

            int contador = nombreDominioArray.Length - 1;

            while (contador >= 0)
            {
                foreach (var item in nombreDominioArray)
                {
                    if (contador == nombreDominioArray.Length - 1)
                    {
                        tipo = "DOMINIOSUP";
                        Nodo nuevoNodoDominioSuperior = new Nodo(item, tipo);
                        cola.encolar(nuevoNodoDominioSuperior);
                    }
                    else if (contador != 0)
                    {
                        tipo = "SUBDOMINIO";
                        Nodo nuevoNodoDominioInferior = new Nodo(item, tipo);
                        cola.encolar(nuevoNodoDominioInferior);
                    }
                    //Es para eliminar
                    else if (contador == 0)
                    {
                        if (buscarNodo)
                        {
                            tipo = "EQUIPO";
                            Nodo nuevoNodo = new Nodo(item, tipo);
                            cola.encolar(nuevoNodo);
                        }
                        else//Es para insertar
                        {
                            tipo = "EQUIPO";
                            Nodo nuevoNodo = new Nodo(item, Nodo.ingresarIP(), tipo);
                            nuevoNodo.agregarServicio();
                            cola.encolar(nuevoNodo);
                        }

                    }
                    contador--;

                }

            }
            return cola;
        }
    }
}