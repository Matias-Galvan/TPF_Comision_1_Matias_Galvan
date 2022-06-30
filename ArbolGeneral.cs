using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace TPF_Comision_1_Matias_Galvan
{
    public class ArbolGeneral
    {

        // private T dato;
        private Nodo dato;
        string nombreRaizPrincipal;

        private List<ArbolGeneral> hijos = new List<ArbolGeneral>();

        public ArbolGeneral(Nodo dato)
        {
            this.dato = dato;
        }

        public ArbolGeneral(string nombreRaizPrincipal)
        {
            this.nombreRaizPrincipal = nombreRaizPrincipal;
        }

        public ArbolGeneral()
        {

        }

        public Nodo getDatoRaiz()
        {
            return this.dato;
        }

        public List<ArbolGeneral> getHijos()
        {
            return hijos;
        }

        public void agregarHijo(ArbolGeneral hijo)
        {
            this.getHijos().Add(hijo);
        }

        public void eliminarHijo(ArbolGeneral hijo)
        {
            this.getHijos().Remove(hijo);
        }

        public bool esVacio()
        {
            return this.dato == null;
        }

        public int contarHijos()
        {
            return this.getHijos().Count;
        }

        public bool esHoja()
        {
            return this.dato != null && this.getHijos().Count == 0;
        }

        public List<ArbolGeneral> copiaHijos(List<ArbolGeneral> copiaEliminacion)
        {
            List<ArbolGeneral> lista = new List<ArbolGeneral>();
            foreach (ArbolGeneral aux in copiaEliminacion)
            {
                lista.Add(aux);
            }
            return lista;
        }

        public void ingresarNodo(Cola<Nodo> cola)
        {
            if (cola.mayorQueCero())
            {
                bool nodo_encontrado = false;
                ArbolGeneral nuevoNodo = new ArbolGeneral(cola.desencolar());
                foreach (ArbolGeneral aux in hijos)
                {
                    //comparar
                    if (aux.getDatoRaiz().getNombreNodo() == nuevoNodo.getDatoRaiz().getNombreNodo())
                    {
                        nodo_encontrado = true;
                        aux.ingresarNodo(cola);
                    }
                }
                //sino lo encontre, lo agrego a la lista
                if (nodo_encontrado == false)
                {
                    hijos.Add(nuevoNodo);
                    //Reviso si faltan cargar datos
                    if (!cola.esVacia())
                    {
                        nuevoNodo.ingresarNodo(cola);
                    }
                }
            }

        }
        // public void obtenerRaiz(Cola<Nodo> cola)
        // {
        //     ArbolGeneral eliminarNodo = new ArbolGeneral(cola.desencolar());
        //     this.eliminarNodoHoja(eliminarNodo);
        // }

        public void eliminarNodoHoja(Cola<Nodo> cola)
        {
            //Lista para verificar que no hayan quedado subdominios sin borrar
            List<ArbolGeneral> espejo = copiaHijos(hijos);
            if (!cola.esVacia())
            {
                ArbolGeneral eliminarNodo = new ArbolGeneral(cola.desencolar());
                foreach (ArbolGeneral arbolAux in hijos)
                {

                    if (eliminarNodo.esHoja())
                    {
                        arbolAux.eliminarNodoHoja(cola);
                    }
                }
                if (cola.esVacia())
                {
                    //Limpieza del arbol para ver que no hayan quedado dominios
                    foreach (ArbolGeneral aux in espejo)
                    {
                        if (aux.getDatoRaiz().getNombreNodo() == eliminarNodo.getDatoRaiz().getNombreNodo() && aux.esHoja())
                        {
                            hijos.Remove(aux);
                        }
                        else
                        {
                            return;
                        }

                    }
                }
            }


            foreach (ArbolGeneral aux in espejo)
            {
                if (aux.esHoja())
                {
                    if (aux.contarHijos() == 0)
                    {
                        hijos.Remove(aux);
                    }
                }

            }




        }

        // public ArbolGeneral eliminarNodoHoja(ArbolGeneral raiz)
        // {
        //     if (raiz == null)
        //     {
        //         return null;
        //     }
        //     // if (raiz.getHijos().Count == 0)
        //     // {
        //     //     return null;
        //     // }
        //     for (int i = 0; i < raiz.getHijos().Count; i++)
        //     {
        //         ArbolGeneral hijoNodo = (ArbolGeneral)raiz.getHijos()[i];
        //         if (hijoNodo.getHijos().Count == 0)
        //         {
        //             for (int j = 0; j < raiz.getHijos().Count - 1; j++)
        //             {
        //                 raiz.getHijos()[j] = raiz.getHijos()[j + 1];
        //             }
        //             raiz.getHijos().RemoveAt(raiz.getHijos().Count - 1);
        //             i--;
        //         }
        //     }
        //     for (int i = 0; i < raiz.getHijos().Count; i++)
        //     {
        //         raiz.getHijos()[i] = eliminarNodoHoja((ArbolGeneral)raiz.getHijos()[i]);
        //     }
        //     return raiz;

        // }

        // public int altura()
        // {
        //     return 0;
        // }


        // public int nivel(Nodo dato)
        // {
        //     return 0;
        // }

        // public void preOrden()
        // {
        //     //Se procesa la raiz
        //     if (!this.esVacio())
        //     {
        //         //Console.Write("└─" + dato.getNombreNodo() + " ");
        //         System.Console.WriteLine(dato.getNombreNodo() + " ");
        //     }
        //     //Luego se procesan los hijos
        //     if (!this.esHoja())
        //     {
        //         foreach (ArbolGeneral hijo in this.getHijos())
        //         {
        //             // Console.Write("├─");
        //             // Console.Write("| ");
        //             hijo.preOrden();
        //         }
        //     }
        // }

        public void porNiveles()
        {
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral arbolAux;

            cola.encolar(this);
            while (cola.distintoQueCero())
            {
                int contador = cola.contarElementos();
                while (!cola.esVacia())
                {
                    while (contador > 0)
                    {
                        arbolAux = cola.desencolar();
                        if (arbolAux.dato == null)
                        {
                            System.Console.WriteLine();
                            //Console.Write(arbolAux.getHijos()[0].getDatoRaiz().getNombreNodo() + " ");
                        }
                        else
                        {
                            Console.WriteLine(arbolAux.getDatoRaiz().getNombreNodo() + " ");
                        }
                        foreach (var hijos in arbolAux.getHijos())
                        {
                            cola.encolar(hijos);
                            contador--;
                        }
                    }
                    Console.WriteLine();
                }


            }


        }

        public int ancho()
        {
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral arbolAux;

            int nivel = 0;
            int contNodos = 0;

            cola.encolar(this);
            cola.encolar(null);

            while (!cola.esVacia())
            {
                arbolAux = cola.desencolar();

                if (arbolAux == null)
                {

                    if (!cola.esVacia())

                        cola.encolar(null);
                    nivel++;
                }
                else
                {
                    contNodos++;
                    foreach (var hijo in arbolAux.getHijos())
                    {
                        cola.encolar(hijo);
                    }
                }

            }


            return contNodos;
        }

        static void imprimirRed(ArbolGeneral nodoRaiz, bool[] marcador, int profundidad, bool esUltimo)
        {
            //Si la raiz es nula termino el metodo
            if (nodoRaiz == null)
            {
                return;
            }
            //Loopeo para imprimir las profundidades de la raiz actual
            for (int i = 1; i < profundidad; i++)
            {
                //Condicion cuando se explora en profundidad
                if (marcador[i] == true)
                {
                    Console.Write("| "
                    + " "
                    + " "
                    + " ");
                }
                //Sino se imprimen los espacios en blanco
                else
                {
                    Console.Write(" "
                    + " "
                    + " "
                    + " ");
                }
            }

            //Condicion cuando el nodo actual es la raiz
            if (profundidad == 0 && nodoRaiz.dato != null)
                System.Console.WriteLine(nodoRaiz.getDatoRaiz().getNombreNodo());
            //Condicion cuando el nodo es el ultimo en explorar en profundidad
            else if (esUltimo)
            {
                Console.Write("+--- " + nodoRaiz.getDatoRaiz().getNombreNodo() + '\n');
                //Si no tiene mas hijos, cambio la profundidad a falso
                marcador[profundidad] = false;
            }
            else if (!esUltimo && nodoRaiz.dato != null)
            {
                Console.Write("+--- " + nodoRaiz.getDatoRaiz().getNombreNodo() + '\n');
            }

            int contador = 0;
            foreach (ArbolGeneral nodo in nodoRaiz.getHijos())
            {
                ++contador;
                //Llamadas recursivas para los nodos hijos
                imprimirRed(nodo, marcador, profundidad + 1,
                contador == (nodoRaiz.getHijos().Count) - 1);
            }
            marcador[profundidad] = true;
        }

        public void armarImprimirRed(ArbolGeneral raiz, int total)
        {
            //Arreglo para mantener el tracking de las profundidades
            bool[] marcador = new bool[total];
            for (int i = 0; i < total; i++)
                marcador[i] = true;
            imprimirRed(raiz, marcador, 0, false);
        }


    }
}
