using System;
using System.Collections.Generic;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Menu
    {
        private string opcion1;
        private string opcion2;
        private string opcion3;

        public Menu()
        {

        }

        public void mostrarMenuPrincipal()
        {
            Console.Clear();
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("DNS - GESTIÓN DE DIRECCIONES IP");
            System.Console.WriteLine("*****************************");
            System.Console.WriteLine("Menú principal");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("1- Módulo de administración");
            System.Console.WriteLine("2- Módulo de consultas");
            System.Console.WriteLine("3- Salir del programa");
            Console.Write("Opcion: ");
            int opcionElegida = int.Parse(Console.ReadLine());
            this.menuAdmin(opcionElegida);

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
                default:
                    System.Console.WriteLine("Errorardo");
                    break;
            }

            return opcion;
        }

        public void modAdmin(){
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
            System.Console.WriteLine("1-Ver dirección IP con todos los servicios(Dominio/Equipo)");
            System.Console.WriteLine("2-Ver todos los equipos de un subdominio(Subdominio/Equipos)");
            System.Console.WriteLine("3-Ver por profundidad dominios, subdominios o equipos");
            System.Console.WriteLine("4-Regresar al menú principal");
            Console.Write("Opcion: ");
        }

        public int menuAdmin(int opcion){
            switch (opcion)
            {
                case 1:
                break;
                case 2:
                break;
                case 3:
                break;
                default:
                break;
            }
            return opcion;
        }
    }
}