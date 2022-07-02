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

        bool localizado;

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
        public string getDatoRaizString(){
            return this.nombreRaizPrincipal;
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
            return this.nombreRaizPrincipal == null;
        }

        public int contarHijos()
        {
            return this.getHijos().Count;
        }

        public bool esHoja()
        {
            return this.getHijos().Count == 0;
        }

        public List<ArbolGeneral> copiaHijos(List<ArbolGeneral> copiaEliminacion)
        {
            List<ArbolGeneral> lista = new List<ArbolGeneral>();
            foreach (ArbolGeneral aux in copiaEliminacion)
            {
                lista.Add(aux);
            }
            // lista.Reverse();
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
        public virtual bool verificarURL(Cola<Nodo> cola)
        {
            if (cola.distintoQueCero())
            {
                bool localizado=false;
                ArbolGeneral buscarNodo = new ArbolGeneral(cola.desencolar());
                foreach (ArbolGeneral aux in hijos)
                {
                    //Comparar
                    if (aux.getDatoRaiz().getNombreNodo() == buscarNodo.getDatoRaiz().getNombreNodo())
                    {
                        localizado=true;
                        aux.verificarURL(cola);
                    }
                }
                return localizado;
            }
            return localizado;
        }
        public void eliminarNodoHoja(Cola<Nodo> cola)
        {
            //Lista para verificar que no hayan quedado subdominios sin borrar
            List<ArbolGeneral> espejo = copiaHijos(hijos);
            while (!cola.esVacia())
            {
                ArbolGeneral eliminarNodo = new ArbolGeneral(cola.desencolar());
                foreach (ArbolGeneral arbolAux in hijos)
                {

                    if (eliminarNodo.esHoja() && !cola.esVacia())
                    {
                        arbolAux.eliminarNodoHoja(cola);
                    }
                }
                if (cola.esVacia())
                {
                    //Limpieza del arbol para ver que no hayan quedado dominios
                    foreach (ArbolGeneral aux in espejo)
                    {
                        if (aux.esHoja() && aux.getDatoRaiz().getNombreNodo() == eliminarNodo.getDatoRaiz().getNombreNodo())
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

        public void mostrarEquiposSubdominio(Cola<Nodo> cola)
        {
            string resultado = null;
            ArbolGeneral equipo = new ArbolGeneral(cola.desencolar());
            foreach (ArbolGeneral aux in hijos)
            {
                if (cola.contarElementos() >= 2)
                {
                    aux.mostrarEquiposSubdominio(cola);
                }
                else //if (cola.contarElementos() == 0)
                {
                    resultado += "Subdominio: " + equipo.getDatoRaiz().getNombreNodo();
                    foreach (ArbolGeneral item in aux.getHijos())
                    {
                        resultado += "\nHijo: " + item.getDatoRaiz().getNombreNodo();

                    }
                    System.Console.WriteLine(resultado);
                }

            }
        }

        public string imprimirEquipo(Cola<Nodo> cola)
        {
            string nodoEquipo = null;
            ArbolGeneral equipoNombre = new ArbolGeneral(cola.desencolar());

            foreach (ArbolGeneral aux in hijos)
            {
                if (aux.getDatoRaiz().getNombreNodo() == equipoNombre.getDatoRaiz().getNombreNodo() && !cola.esVacia())
                {
                    nodoEquipo = aux.imprimirEquipo(cola);
                }
                else if (aux.getDatoRaiz().getNombreNodo() == equipoNombre.getDatoRaiz().getNombreNodo() && cola.esVacia())
                {
                    if (equipoNombre.esHoja())
                    {
                        return nodoEquipo = "Equipo: " + aux.getDatoRaiz().getNombreNodo() + "\nServicios: " + aux.getDatoRaiz().verServicios()[0] + "\nDirección IP: " + aux.getDatoRaiz().verDirIP();
                    }
                }
            }
            return nodoEquipo;
        }

        public int imprimirCantidadPorProfundidad(int profundidad)
        {
            int contador = 0;
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral aux;
            int nivel = 0;
            cola.encolar(this);
            cola.encolar(null);

            while (!cola.esVacia())
            {
                if (nivel == profundidad)
                {
                    break;
                }

                aux = cola.desencolar();
                if (aux == null)
                {
                    if (!cola.esVacia())
                    {
                        cola.encolar(null);
                        nivel++;
                    }
                }
                else
                {
                    contador++;
                    foreach (var hijo in aux.getHijos())
                    {
                        cola.encolar(hijo);
                    }
                }
            }

            return contador;
        }

        public void preOrden()
        {
            //Se procesa la raiz
            if (!this.esVacio())
            {
                //Console.Write("└─" + dato.getNombreNodo() + " ");
                System.Console.WriteLine(dato.getNombreNodo() + " ");
            }
            //Luego se procesan los hijos
            if (!this.esHoja())
            {
                foreach (ArbolGeneral hijo in this.getHijos())
                {
                    // Console.Write("├─");
                    // Console.Write("| ");
                    hijo.preOrden();
                }
            }
        }

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
