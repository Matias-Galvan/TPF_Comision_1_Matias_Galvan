using System.Collections;
namespace TPF_Comision_1_Matias_Galvan;
class Program
{

    static void Main(string[] args)
    {
        Menu menu = new Menu();
        int opcion = 0;
        int opcionMenuAdmin = 0;
        int opcionMenuConsulta = 0;
        bool continuarMenuPrincipal = true;
        bool continuarMenuAdmin = true;
        bool continuarMenuConsulta = true;
        bool volverAlMenuPrincipal;
        while (continuarMenuPrincipal)
        {
            Console.Clear();
            mostrarMenuPrincipal();
            if (Int32.TryParse(Console.ReadLine(), out opcion))
            {

                switch (opcion)
                {
                    case 1:
                        while (continuarMenuAdmin)
                        {
                            menu.modAdmin();
                            if (Int32.TryParse(Console.ReadLine(), out opcionMenuAdmin))
                            {
                                switch (opcionMenuAdmin)
                                {
                                    case 1:
                                        menu.ingresarDatos();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuAdmin = true;
                                        continuarMenuPrincipal = false;
                                        break;
                                    case 2:
                                        menu.eliminarDatos();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuAdmin = true;
                                        continuarMenuPrincipal = false;
                                        break;
                                    case 3:
                                        volverAlMenuPrincipal = true;
                                        continuarMenuAdmin = false;
                                        continuarMenuPrincipal = true;
                                        break;
                                    default:
                                        continuarMenuAdmin = true;
                                        break;
                                }
                            }
                            else if (continuarMenuAdmin)
                            {
                                System.Console.WriteLine("Valor incorrecto. Ingrese nuevamente la opcion");
                            }

                        }

                        volverAlMenuPrincipal = continuarMenuPrincipal ? true : false;
                        break;
                    case 2:
                        while (continuarMenuConsulta)
                        {
                            menu.modConsulta();
                            if (Int32.TryParse(Console.ReadLine(), out opcionMenuConsulta))
                            {
                                switch (opcionMenuConsulta)
                                {
                                    case 1:
                                        menu.imprimirArbol();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuConsulta = true;
                                        continuarMenuPrincipal = false;
                                        System.Console.WriteLine(" ");
                                        System.Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        menu.buscarEquipo();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuConsulta = true;
                                        continuarMenuPrincipal = false;
                                        break;
                                    case 3:
                                        menu.imprimirEquiposSubdominio();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuConsulta = true;
                                        continuarMenuPrincipal = false;
                                        break;
                                    case 4:
                                        menu.buscarCantidadPorProfundidad();
                                        volverAlMenuPrincipal = false;
                                        continuarMenuConsulta = true;
                                        continuarMenuPrincipal = false;
                                        break;
                                    case 5:
                                        volverAlMenuPrincipal = true;
                                        continuarMenuConsulta = false;
                                        continuarMenuPrincipal = true;
                                        break;
                                    default: break;
                                }
                            }
                            else if (continuarMenuConsulta)
                            {
                                System.Console.WriteLine("Valor incorrecto. Ingrese nuevamente la opcion");
                            }
                        }
                        volverAlMenuPrincipal = continuarMenuPrincipal ? true : false;
                        break;
                    case 3:
                        Console.Clear();
                        System.Console.WriteLine("Desea salir del sistema? Se perderá cualquier dato que haya ingresado (s/n)");
                        string salir = Console.ReadLine().ToUpper();
                        while (salir == "N")
                        {
                            if (salir == "" && salir != "S" && salir != "N")
                            {
                                System.Console.WriteLine("Opción incorrecta, vuelva a ingresar (s/n)");
                                salir = Console.ReadLine().ToUpper();
                            }
                            else if (salir == "N")
                            {
                                continuarMenuPrincipal = true;
                                break;
                            }
                        }
                        if (salir == "S")
                        {
                            continuarMenuPrincipal = false;
                            System.Console.WriteLine("Saliendo...");
                        }
                        else
                        {
                            continuarMenuPrincipal = true;
                        }

                        break;
                    default:
                        continuarMenuPrincipal = true;
                        break;
                }
            }
            else if (continuarMenuPrincipal)
            {
                System.Console.WriteLine("Valor incorrecto. Ingrese nuevamente la opcion");
            }
        }


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
        System.Console.WriteLine("3- Salir del programa");
        Console.Write("Opcion: ");



    }
    public static bool ManejoError(string mensaje)
    { // Manejo de errores genéricos
        Console.WriteLine(mensaje);
        Console.ReadLine();
        return true;
    }
}

