using System;
using System.Collections.Generic;
using System.IO;

namespace TPF_Comision_1_Matias_Galvan
{
    public class Nodo<T>
    {
        private T dato;
        private List<Nodo<T>> hijos;

        public Nodo(T dato){
            this.dato = dato;
            this.hijos = new List<Nodo<T>>();
        }

        public T getDato(){
            return this.dato;
        }

        public List<Nodo<T>> getHijos(){
            return this.hijos;
        }

        public void setDato(T dato){
            this.dato = dato;
        }

        public void setHijos(List<Nodo<T>> hijos){
            this.hijos = hijos;
        }
    }
}