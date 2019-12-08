using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeerArchivo
{
    public class Principal
    {

        Datos_Pc Dpc = new Datos_Pc();
        
        //Metodo del menu principal
        public void Menu()
        {
            //opciones del menu
            Console.WriteLine("Bienvenido a menu");
            Console.WriteLine("1.-Mirar inventario");
            Console.WriteLine("2.-Detalles de un objeto");
            Console.WriteLine("3.-Detalles de todos los objetos");
            Console.WriteLine("4.-Editar detalles de objeto");
            Console.WriteLine("5.-Salir");
          
            Console.WriteLine("Elige la opcion");
            //switch para colocar los metodos en las opciones y acceder a ellos
            switch (Console.ReadLine())
            {
                case "1":
                    //llamada del metodo
                    ObtenerComputadoras(Dpc.ID);
                    Console.Clear();
                   
                    break;
                case "2":
                    
                    ObtenerDetalles(Dpc.ID);
                    Console.Clear();
                    break;
                case "3":
                    Mirar();
                    Console.Clear();
                    break;
                case "4":
                    EditarDtos(Dpc.ID);
                    Console.Clear();
                    break;
                case "5":
                    Environment.Exit(0);
                    Console.Clear();
                    break;
                default:
                    break;
            }
            Menu();
            //llamada del menu despues de cada metodo
        }



        //Mirar los detalles de todas las pc
        void Mirar()
        {
            using (StreamReader leer = new StreamReader("Datos.txt"))
            {
                //mira todos los datos del archivo con sus respectivos detalles

                while (!leer.EndOfStream)
                {
                    string x = leer.ReadLine();
                    Console.WriteLine(x);
                    Console.ReadKey();
                }
            }

        }


        //Metodo para obtener detalles de una pc
        public List<Datos_Pc> ObtenerDetalles(int id)
        {   //usa el metodo obtener lineas por medio de la variable datos
            var datos = ObtenerLineas();
            List<Datos_Pc> CompuadorasD = new List<Datos_Pc>();
            Datos_Pc Pe = new Datos_Pc();
            //listas y instancias

            Console.WriteLine("id a buscar: ");
            id = Convert.ToInt32(Console.ReadLine());
            //busca dentro de la lista
            foreach (var item in datos)
            {
                string[] info = item.Split(',');
                Datos_Pc cpu = new Datos_Pc
                {   //arreglo de los valores 
                    ID = int.Parse(info[0]),
                    Nombre = info[1],
                    Modelo = info[2],
                    Ram = int.Parse(info[3]),
                    Procesador = info[4],
                    Tarjeta_Grafica = info[5]
                };

                //condicion para desplegar los valores  en caso de que id coincida con el de la lista
                if (id == cpu.ID)
                {
                    Console.WriteLine("  Id:" + cpu.ID + "  Nombre:" + cpu.Nombre + "  Modelo: " + cpu.Modelo + "Ram: " + cpu.Ram + "  Procesador: " + cpu.Procesador + " Tarjeta grafica: " + cpu.Tarjeta_Grafica);
                    Console.ReadKey();
                }




                //agrega datos
                CompuadorasD.Add(cpu);

            }




            return CompuadorasD;
        }







        //codigo de prueba
        /*public Datos_Pc BuscarComputadoras(int id)
        {
            var Pcss = ObtenerComputadoras(id);
            var p = (from Compu in Pcss
                     where Compu.ID == id
                     select Compu).First();
            return p;
            //Busca dentro de Datos_pc y en los Datos si el id es igual al buscado se selecciona 
        }
        */


        public List<Datos_Pc> ObtenerComputadoras(int id)
            //envia el id como parametro para validar con el
        {   //usa el metodo obtener lineas por medio de la variable datos
            var datos = ObtenerLineas();
            List<Datos_Pc> Computadoras = new List<Datos_Pc>();
            Datos_Pc Pe = new Datos_Pc();
            //listas y instancias


            //busca dentro de la lista
            foreach (var item in datos)
            {   //los datos que estaban en info se dan ala varible item y esta contiene los datos separados por "," comillas.
                string[] info = item.Split(',');
                Datos_Pc pcs = new Datos_Pc
                {   //arreglo
                    ID = int.Parse(info[0]),
                    Nombre = info[1],
                    Modelo = info[2],
                    Ram = int.Parse(info[3]),
                    Procesador = info [4],
                    Tarjeta_Grafica = info [5]

                };

                //muestra el id y el nombre de todos los datos de la lista
                Console.WriteLine("  Id:" + pcs.ID + "  Nombre:" + pcs.Nombre );
                Console.ReadKey();





                //agrega a personas
                Computadoras.Add(pcs);

            }




            return Computadoras;
        }







        //Metodo editar datos
        public List<Datos_Pc> EditarDtos(int id)
        {
            var datos = ObtenerLineas();
            List<Datos_Pc> DatosComp = new List<Datos_Pc>();
            Datos_Pc Pe = new Datos_Pc();
            //listas y instancias



            //busca dentro de la lista
            foreach (var item in datos)
            {
                //Un stream es como se denomina a un objeto utilizado para transferir datos
                //StreamReader y StreamWriter, las cuales están diseñadas para lectura y
                // escritura de archivos de texto.

                StreamWriter escribir;
                //su propósito es únicamente para escribir dentro de un archivo. (u otro stream)
                StreamReader Leer;
                // StreamReader que permiten efectuar lectura desde el archivo.


                Leer = File.OpenText("Datos.txt");
                escribir = File.CreateText("temp.txt");


                string NuevoNom;
                string Cadena, datoM;
                string[] Campos = new string[5];  //arreglo llamado campos
                //separador es una coma para los datos
                char[] separador = { ',' };



                //busca el id
                Console.WriteLine("id a buscar: ");
                datoM = Console.ReadLine();

                //se realiza una lectura adelantada para tomar los valores del archivo
                Cadena = Leer.ReadLine();
                
                //mientras el archivo tenga algo
                while (Cadena != null)
                {
                    //esta parte lo que hace es que almacenamos en capos lo que tiene cadena, separandolo por medio de , que ya habiamos declarado en la variable separador  
                    //obtine lo siguiente ejemplo = 1,Juils,5142,8,AMD,GTX_1080 que es un vector con un arreglo de caracteres con el separador que pusimos 
                    Campos = Cadena.Split(separador);

                    //Trim() elimina todos los caracteres de espacio en blanco desde el principio y final de la cadena. 
                    //Eso significa que spaces, tabs, new lines, returns, y otros surtido de caracteres de espacio en blanco.

                    if (Campos[0].Trim().Equals(datoM))
                    { 
                       //buscamos el valor  si campo en el indice[0] se encuntra y tambien es igual al buscado realiza lo del if y para evitar que existan errores con espacios
                       //usamos el Trim que quita todas las apariciones de espacios del principio y del final (no quita los de enmedio solo principio y final)     
                        // el Equals es como el "=="


                        //ingresamos el nuevo nombre
                        Console.WriteLine("ingrese el nuevo nombre: ");
                        NuevoNom = Console.ReadLine();
                        //modificamos el registro usando el archivo auxiliar y enviamos de parametro toda la linea a ecepcion del nombre viejo lo cambiaremos por el nuevo
                        //en esta parte usamos el archivo temporal
                        escribir.WriteLine(Campos[0]  + "," + NuevoNom + "," + Campos[2] + "," + Campos[3] + "," + Campos[4] + "," + Campos[5]);
                        //al final enviamos un mensaje para que el usuario sepa que su registro fue modificado con exito
                        Console.WriteLine("registro modificado con exito");
                        Console.ReadLine();



                    }
                    else
                    {
                        //encaso de que no lo encuentre enviara la cadena como estaba en el original
                        escribir.WriteLine(Cadena);
                    }
                    //al final de todos manera enviara la cadena
                    Cadena = Leer.ReadLine();
                }


                //cerramos para evitar algun tipo de error
                Leer.Close();
                escribir.Close();
                //eliminamos el archivo datos y renombramos el temop. 
                File.Delete("Datos.txt");
                File.Move("temp.txt", "Datos.txt");


                Console.Clear();
                //llamar a menu
                Menu();

            }




            return DatosComp;
        }






        //Metodo para obtener las lineas del archivo
        public List<string> ObtenerLineas()
        {
            try
            {
                //lista
                List<string> lineas = new List<string>();

                string[] info = null;

                //si el archivo datos existe
                if (File.Exists("Datos.txt"))
                {   //en la variable infor leer todas las lienas de datos.txt
                    info = File.ReadAllLines("Datos.txt");
                    Console.ReadKey();
                }

                foreach (string item in info)
                {
                    //agrega ala lista lineas
                    lineas.Add(item);
                }
                //retorna las lineas
                return lineas;

            }
            catch (System.Exception)
            {
                Console.WriteLine("Valor erroneo");

            }
            return null;
        }











    }
}
