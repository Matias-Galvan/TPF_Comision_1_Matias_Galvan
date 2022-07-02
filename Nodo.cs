using System;
using System.Collections;
using System.Linq;
using System.Text;
namespace TPF_Comision_1_Matias_Galvan
{
    public class Nodo
    {
        //Atributos
        public string dato, tipo;

        private string direccionIP;

        private ArrayList servicios;

        public List<Nodo> raizNodo = new List<Nodo>();

        //Constructores

        public Nodo()
        {

        }

        public Nodo(string dato, string direccionIP, string tipo)
        {
            this.tipo = tipo;
            this.dato = dato;
            this.direccionIP = direccionIP;
            servicios = new ArrayList();
        }
        public Nodo(string dato, string tipo)
        {
            this.dato = dato;
            this.tipo = tipo;
        }

        public ArrayList verServicios()
        {
            return servicios;
        }

        public string verDirIP()
        {
            return direccionIP;
        }

        //Metodos

        public static string ingresarIP()
        {
            Console.Clear();
            string direccionIP = "";
            bool aceptar = true;
            System.Console.WriteLine("¿Desea generar una IP o agregar manualmente? (s/n)");
            string elegir = Console.ReadLine().ToUpper();
            while (aceptar)
            {
                switch (elegir)
                {
                    case "S":
                        Random primero = new Random();
                        int rPrimero = primero.Next(0, 255);
                        Random segundo = new Random();
                        int rSegundo = segundo.Next(0, 255);
                        Random tercero = new Random();
                        int rTercero = tercero.Next(0, 255);
                        Random cuarto = new Random();
                        int rCuarto = cuarto.Next(0, 255);
                        direccionIP= rPrimero + "." + rSegundo + "." + rTercero + "." + rCuarto;
                        aceptar=false;
                        break;
                    case "N":
                        System.Console.WriteLine("Ingrese el primer octeto");
                        string primerOcteto = Console.ReadLine();
                        System.Console.WriteLine("Ingrese el segundo octeto");
                        string segundoOcteto = Console.ReadLine();
                        System.Console.WriteLine("Ingrese el tercer octeto");
                        string tercerOcteto = Console.ReadLine();
                        System.Console.WriteLine("Ingrese el cuarto octeto");
                        string cuartoOcteto = Console.ReadLine();

                        direccionIP = primerOcteto + "." + segundoOcteto + "." + tercerOcteto + "." + cuartoOcteto;
                        aceptar=false;
                        break;
                    default: break;
                }
            }

            return direccionIP;
        }


        public void agregarServicio()
        {
            string servicioAgregar;
            Console.Clear();
            Console.Write("Paso 3: Ingrese el servicio: ");//agregamos un servicio, puede tener mas de uno.
            servicioAgregar = Console.ReadLine().ToUpper();

            servicios.Add(servicioAgregar);
        }

        public string getNombreNodo()
        {
            return dato;
        }

        public string getTipo()
        {
            return tipo;
        }

        public void setNombreNodo()
        {
            this.dato = (dato == null ? "" : dato);
        }
    }
}