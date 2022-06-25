using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Menu
    {
        private string opcion1;
        private string opcion2;
        private string opcion3;

        public int opc;
        ArbolGeneral<string> arbol = new ArbolGeneral<string>("Servidor");

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

        public void mostrarMenuPrincipal()
        {
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("DNS - GESTIÓN DE DIRECCIONES IP");
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("Menú principal");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("1- Módulo de administración");
            System.Console.WriteLine("2- Módulo de consultas");
            System.Console.WriteLine("3- Salir del programa");
            Console.Write("Opcion: ");


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
                case 3:
                    this.mostrarMenuPrincipal();
                    opc = int.Parse(Console.ReadLine());
                    this.elegirOpcion(opc);
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
                case 4:
                    this.mostrarMenuPrincipal();
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
            while (!validarURL.IsMatch(nombreDominio))
            {
                System.Console.WriteLine("Patrón incorrecto. Vuelva a ingresar el dominio");
                nombreDominio = Console.ReadLine();
            }
            System.Console.WriteLine("Paso 2 / Ingresar dirección IP del equipo , 192.198.0.1");
            string direccionIP = Console.ReadLine();
            System.Console.WriteLine("Paso 3 / Ingresar servicios que provee, www, dns, ftp , routing");
            string servicios = Console.ReadLine();

            this.procesarDatosIngreso(nombreDominio, direccionIP, servicios);




        }

        public void procesarDatosIngreso(string nomDom, string dirIP, string servicios)
        {
            // string resultado = "Finalizo con exito el ingreso";
            string[] nombreDominioArray = nomDom.Split('.');
            Array.Reverse(nombreDominioArray);

            Cola<string> cola = new Cola<string>();
            foreach (var item in nombreDominioArray)
            {
                cola.encolar(item);
            }
            while (!cola.esVacia())
            {
                string dato = cola.desencolar();

                ArbolGeneral<string> hijo1 = new ArbolGeneral<string>(dato);
                arbol.agregarHijo(hijo1);
                

            }
            arbol.preOrden();

            // System.Console.WriteLine(dirIP);
            // System.Console.WriteLine(servicios);

            // System.Console.WriteLine(resultado);
        }

        public void eliminarDatos()
        {
            System.Console.WriteLine("Eliminar rama completa");
        }
    }
}