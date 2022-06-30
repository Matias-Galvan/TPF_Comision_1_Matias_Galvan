using System;
using System.Collections.Generic;
using System.IO;

namespace TPF_Comision_1_Matias_Galvan
{

    public class Cola<T>
    {


        private List<T> datos = new List<T>();

        public void encolar(T elem)
        {
            this.datos.Add(elem);
        }

        public T desencolar()
        {
            T temp = this.datos[0];
            this.datos.RemoveAt(0);
            return temp;
        }

        public T tope()
        {
            return this.datos[0];
        }

        public bool esVacia()
        {
            return this.datos.Count == 0;
        }

        public bool mayorQueCero()
        {
            return this.datos.Count > 0;
        }

        public bool distintoQueCero()
        {
            return this.datos.Count != 0;
        }

        public int contarElementos()
        {
            return this.datos.Count;
        }
    }
}
