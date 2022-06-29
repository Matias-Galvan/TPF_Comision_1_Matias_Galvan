using System.Collections;
namespace TPF_Comision_1_Matias_Galvan;
class Program
{

    static void Main(string[] args)
    {
        Menu menu = new Menu();
        int opcion = 0;
        do
        {

            mostrarMenuPrincipal();
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1: menu.modAdmin(); break;
                case 2: menu.modConsulta(); break;

                default: break;
            }

        } while (opcion != 0);

    }

    static void mostrarMenuPrincipal()
    {
        System.Console.WriteLine("*****************************");
        System.Console.WriteLine("DNS - GESTIÓN DE DIRECCIONES IP");
        System.Console.WriteLine("*****************************");
        System.Console.WriteLine("Menú principal");
        System.Console.WriteLine(" ");
        System.Console.WriteLine("1- Módulo de administración");
        System.Console.WriteLine("2- Módulo de consultas");
        System.Console.WriteLine("0- Salir del programa");
        Console.Write("Opcion: ");



    }
}

