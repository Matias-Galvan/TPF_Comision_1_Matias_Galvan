using System;

namespace TPF_Comision_1_Matias_Galvan
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolGenerico arbol = new ArbolGenerico();
            CNodo raiz=arbol.Insertar("www.", null);
            arbol.Insertar("garrafas.", raiz);
            arbol.Insertar("com", raiz);

           // arbol.preOrden(raiz);

        }
    }

    class CNodo{
        private string dato;

        private CNodo hijo;
        private CNodo hermano;

        public string Dato { get=> dato; set => dato = value; }
        public CNodo Hijo { get=> hijo; set => hijo = value; }
        public CNodo Hermano { get=> hermano; set => hermano = value; }

        public CNodo(){
            dato = "";
            hijo = null;
            hermano = null;
        }

    }

    class ArbolGenerico {

        private CNodo raiz;
        private CNodo trabajo;

        private int i = 0;

        public ArbolGenerico(){
            raiz = new CNodo();
        }

        public CNodo Insertar(string pDato, CNodo pNodo){

            //Si no hay nodo donde insertar, tomamos como si fuera en la raiz

            if (pNodo == null)
            {
                raiz = new CNodo();
                raiz.Dato = pDato;

                //No hay hijo
                raiz.Hijo = null;

                //No hay hermano
                raiz.Hermano = null;

                return raiz;
            }

            //Verificamos si no tiene hijo
            //Insertamos el dato como hijo
            if (pNodo.Hijo == null)
            {
                CNodo temp = new CNodo();
                temp.Dato = pDato;
                //Conectamos el nuevo nodo como hijo
                pNodo.Hijo = temp;

                return temp;
            }else //ya tiene un hijo tenemos que insertarlo como hermano
            {
                trabajo = pNodo.Hijo;

                //Avanzamos hasta el ultimo hermano
                while (trabajo.Hermano!=null)
                {
                    trabajo = trabajo.Hermano;
                }
                //creamos nodo temporal

                CNodo temp = new CNodo();
                temp.Dato =pDato;

                //Unimos el temp al ultimo hermano
                trabajo.Hermano = temp;

                return temp;
            }
        }

        public void preOrden(CNodo pNodo){
            if (pNodo == null)
            
                return;
            
            for (int n = 0; n < i; n++)
            
                Console.Write(" ");
                Console.WriteLine(pNodo.Dato);
            //Se procesa al hijo
            if (pNodo.Hijo!=null)
            {
                i++;
                preOrden(pNodo.Hijo);
                i--;
            }
            //Si tiene hermanos se procesa
            if (pNodo.Hermano != null)
            {
               preOrden(pNodo.Hermano); 
            }
        }
    }
}
