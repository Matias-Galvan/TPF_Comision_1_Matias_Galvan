// using System;
// using System.Collections.Generic;
// using System.IO;

namespace TPF_Comision_1_Matias_Galvan;

class Program

{
    
    static void Main(string[] args)

    {

        System.Console.WriteLine("Iniciando...");
        // ArbolGeneral<string> arbol = new ArbolGeneral<string>("Servidor");
        Menu menu = new Menu();
        int opc;
        menu.mostrarMenuPrincipal();
        opc = int.Parse(Console.ReadLine());
        menu.elegirOpcion(opc);

        
        // ArbolGeneral<string> hijo1 = new ArbolGeneral<string>(20);
        // ArbolGeneral<string> hijo2 = new ArbolGeneral<string>(30);
        // ArbolGeneral<string> hijo3 = new ArbolGeneral<string>(40);

        // arbol.agregarHijo(hijo1);
        // arbol.agregarHijo(hijo2);
        // arbol.agregarHijo(hijo3);

        // for (int i = 1; i < 5; i++)
        // {
        //     hijo1.agregarHijo(new ArbolGeneral<int>(i + 10));
        //     hijo2.agregarHijo(new ArbolGeneral<int>(i + 20));
        //     hijo3.agregarHijo(new ArbolGeneral<int>(i + 30));
        // }

        System.Console.WriteLine("Recorrido preorden");
        // arbol.preOrden();
    }

}