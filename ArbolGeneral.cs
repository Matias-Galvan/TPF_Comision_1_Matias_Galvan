using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace TPF_Comision_1_Matias_Galvan
{
    public class ArbolGeneral
    {

        // private T dato;
        private Nodo contenido;

        private List<ArbolGeneral> hijos = new List<ArbolGeneral>();

        // public ArbolGeneral(T dato)
        // {
        //     this.dato = dato;
        // }
        public ArbolGeneral(Nodo contenido)
        {
            this.contenido = contenido;
        }

        public ArbolGeneral()
        {

        }

        public Nodo getDatoRaiz()
        {
            return this.contenido;
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
            return this.contenido == null;
        }

        public bool esHoja()
        {
            return this.contenido != null && this.getHijos().Count == 0;
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


        public int altura()
        {
            return 0;
        }


        public int nivel(Nodo dato)
        {
            return 0;
        }

        public void preOrden()
        {
            //Se procesa la raiz
            if (!this.esVacio())
            {
                System.Console.WriteLine(this.getDatoRaiz() + " ");
            }
            //Luego se procesan los hijos
            if (!this.esHoja())
            {
                foreach (var hijo in this.getHijos())
                {
                    hijo.preOrden();
                }
            }
        }

        public void porNiveles()
        {
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral arbolAux;

            cola.encolar(this);
            while (!cola.esVacia())
            {
                arbolAux = cola.desencolar();
                Console.Write(arbolAux.getDatoRaiz() + " ");

                foreach (var hijo in arbolAux.getHijos())
                {
                    cola.encolar(hijo);
                }
            }

        }

        public int ancho()
        {
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral arbolAux;

            int contNodos = 0;
            int ancho = 0;

            cola.encolar(this);
            cola.encolar(null);

            while (!cola.esVacia())
            {
                arbolAux = cola.desencolar();

                if (arbolAux == null)
                {

                    if (contNodos > ancho)
                    {
                        ancho = contNodos;
                        contNodos = 0;
                    }
                    if (!cola.esVacia())

                        cola.encolar(null);
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


            return ancho;
        }

        public int anchoComparar(Cola<string> colaHoja)
        {
            Cola<ArbolGeneral> cola = new Cola<ArbolGeneral>();
            ArbolGeneral arbolAux;

            int contNodos = 0;
            int ancho = 0;

            cola.encolar(this);
            cola.encolar(null);

            while (!cola.esVacia())
            {
                arbolAux = cola.desencolar();


                if (arbolAux == null)
                {

                    if (contNodos > ancho)
                    {
                        ancho = contNodos;
                        contNodos = 0;
                    }
                    if (!cola.esVacia())

                        cola.encolar(null);
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


            return ancho;
        }

    }
}
