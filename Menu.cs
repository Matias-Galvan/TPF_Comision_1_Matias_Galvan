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



        public int elegirOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    this.modAdmin();
                    break;
                case 2:
                    this.modConsulta();
                    break;
                case 3:
                    System.Console.WriteLine("Presione una tecla para salir...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    System.Console.WriteLine("Errorardo");
                    break;

            }


            return opcion;
        }

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
            int opcionElegida = int.Parse(Console.ReadLine());
            this.menuAdmin(opcionElegida);

        }

        public void modConsulta()
        {
            Console.Clear();
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("MÓDULO CONSULTAS");
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("1-Ver dirección IP con todos los servicios(Dominio/Equipo)");
            System.Console.WriteLine("2-Ver todos los equipos de un subdominio(Subdominio/Equipos)");
            System.Console.WriteLine("3-Ver por profundidad dominios, subdominios o equipos");
            System.Console.WriteLine("4-Regresar al menú principal");
            Console.Write("Opcion: ");
        }

        public void menuAdmin(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    this.ingresarDatos();
                    break;
                case 2:
                    this.eliminarDatos();
                    break;
                default:
                    break;
            }

        }

        public int menuConsulta(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    System.Console.WriteLine("Imprimiendo ip con todos los servicios....");
                    break;
                case 2:
                    System.Console.WriteLine("Imprimiendo todos los equipos de un subdominio....");
                    break;
                case 3:
                    System.Console.WriteLine("Imprimiendo cantidad de dominios, subdominios, equipos....");
                    break;
                default:
                    break;
            }
            return opcion;
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
            int cantNodos = arbol.ancho();
            arbol.armarImprimirRed(arbol, cantNodos);
            //arbol.preOrden();
            // arbol.porNiveles();




        }

        public void eliminarDatos()
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
            arbol.eliminarNodoHoja(cola);
            int cantNodos = arbol.ancho();
            //arbol.preOrden();
            //arbol.porNiveles();
            arbol.armarImprimirRed(arbol, cantNodos);




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