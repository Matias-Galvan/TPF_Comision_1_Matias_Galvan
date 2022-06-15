using System;
using System.Collections.Generic;
using System.IO;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Menu
    {
        private string opcion1;
        private string opcion2;
        private string opcion3;

        public int opc;

        public Menu()
        {

        }

        public void mostrarMenuPrincipal()
        {
            System.Console.Clear();
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

        public int elegirOpcion(int opcion)
        {
            this.mostrarMenuPrincipal();
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

        public int menuAdmin(int opcion)
        {

            switch (opcion)
            {
                case 1:
                    System.Console.WriteLine("Ingrese dominio y todo lo demas");
                    break;
                case 2:
                    System.Console.WriteLine("Eliminar equipo");
                    break;
                case 3:
                    this.mostrarMenuPrincipal();
                    break;
                default:
                    break;
            }
            return opcion;
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
    }
}