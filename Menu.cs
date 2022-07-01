using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Menu
    {
        private string opcion1;
        private string opcion2;
        private string opcion3;

        public int opc;

        ArbolGeneral arbol = new ArbolGeneral("Servidor");

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
            System.Console.WriteLine("Paso 1 / Ingresar nombre de dominio completo, es.wikipedia.org");

            Regex validarURL = new Regex(@"^(?!(?:www\.)?google\.com)([\da-zA-Z.-]+)\.([a-zA-Z.]{2,6})([\/\w .-]*)*\/?$");
            string nombreDominio = Console.ReadLine();
            string[] nombreDominioArray = nombreDominio.Split('.');
            while (nombreDominioArray.Count() <= 2)
            {
                System.Console.WriteLine("Debe ingresar un dominio válido");
                nombreDominioArray = nombreDominio.Split('.');
            }
            while (!validarURL.IsMatch(nombreDominio))
            {
                System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                nombreDominio = Console.ReadLine();
            }

            Cola<Nodo> cola = separarDominioSupInfIngreso(nombreDominio, false);
            arbol.ingresarNodo(cola);
            System.Console.WriteLine("Ingreso exitoso");
            System.Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void eliminarDatos()
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
            arbol.eliminarNodoHoja(cola);
            System.Console.WriteLine("Eliminación exitosa");
            System.Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void buscarEquipo()
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
            string resultado = arbol.imprimirEquipo(cola);
            Console.Write(resultado);
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
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
            string[] nombreDominioArray = nomDominio.Split('.');
            Array.Reverse(nombreDominioArray);
            Cola<Nodo> cola = new Cola<Nodo>();

            int contador = nombreDominioArray.Length - 1;

            while (contador >= 0)
            {
                foreach (var item in nombreDominioArray)
                {
                    if (contador == nombreDominioArray.Length - 1)
                    {
                        Nodo nuevoNodoDominioSuperior = new Nodo(item);
                        cola.encolar(nuevoNodoDominioSuperior);
                    }
                    else if (contador != 0)
                    {
                        Nodo nuevoNodoDominioInferior = new Nodo(item);
                        cola.encolar(nuevoNodoDominioInferior);
                    }
                    //Es la raiz
                    else if (contador == 0)
                    {
                        if (buscarNodo)
                        {
                            Nodo nuevoNodo = new Nodo(item);
                            cola.encolar(nuevoNodo);
                        }
                        else//Es la hoja
                        {
                            Nodo nuevoNodo = new Nodo(item, Nodo.ingresarIP());
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