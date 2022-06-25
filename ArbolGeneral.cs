using System;
using System.Collections.Generic;
using System.IO;

namespace TPF_Comision_1_Matias_Galvan
{
    public class ArbolGeneral<T>
    {

        private Nodo<T> raiz;

        private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

        public ArbolGeneral(T dato)
        {
            this.raiz = new Nodo<T>(dato);
        }

        private ArbolGeneral(Nodo<T> nodo)
        {
            this.raiz = nodo;
        }

        private Nodo<T> getRaiz()
        {
            return raiz;
        }

        public T getDatoRaiz()
        {
            return this.getRaiz().getDato();
        }

        public List<ArbolGeneral<T>> getHijos()
        {
            List<ArbolGeneral<T>> temp = new List<ArbolGeneral<T>>();
            foreach (var item in this.raiz.getHijos())
            {
                temp.Add(new ArbolGeneral<T>(item));
            }
            return temp;
        }

        public void agregarHijo(ArbolGeneral<T> hijo)
        {
            this.raiz.getHijos().Add(hijo.getRaiz());
        }

        public void eliminarHijo(ArbolGeneral<T> hijo)
        {
            this.raiz.getHijos().Remove(hijo.getRaiz());
        }

        public bool esVacio()
        {
            return this.raiz == null;
        }

        public bool esHoja()
        {
            return this.raiz != null && this.getHijos().Count == 0;
        }

        public int altura()
        {
            return 0;
        }


        public int nivel(T dato)
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
            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

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
            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

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
            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

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
