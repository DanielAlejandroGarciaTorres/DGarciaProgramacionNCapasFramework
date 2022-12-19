using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;

            //do
            //{
            //    Console.WriteLine("Inserte una opcion: ");
            //    Console.WriteLine("\n1.-Add");
            //    Console.WriteLine("2.-Update");
            //    Console.WriteLine("3.-Delete");
            //    Console.WriteLine("4.-GetAll");
            //    Console.WriteLine("5.-GetById");
            //    Console.WriteLine("6.-Salir");

            //    opcion = int.Parse(Console.ReadLine());
            //    Console.WriteLine("\n\n");
            //    switch (opcion)
            //    {
            //        case 1:
            //            PL.Usuario.Add();
            //            break;

            //        case 2:
            //            PL.Usuario.Update();
            //            break;

            //        case 3:
            //            PL.Usuario.Delete();
            //            break;

            //        case 4:
            //            PL.Usuario.GetAll();
            //            break;

            //        case 5:
            //            PL.Usuario.GetById();
            //            break;

            //        case 6:
            //            Console.WriteLine("Adios...");
            //            break;

            //        default:
            //            Console.WriteLine("No existe esa opcion");
            //            break;
            //    }

            //} while (opcion != 6);

            do
            {
                Console.WriteLine("Inserte una opcion: ");
                Console.WriteLine("\n1.-Add");
                Console.WriteLine("2.-Update");
                Console.WriteLine("3.-Delete");
                Console.WriteLine("4.-GetAll");
                Console.WriteLine("5.-GetById");
                Console.WriteLine("6.-Salir");

                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");
                switch (opcion)
                {
                    case 1:
                        PL.Producto.Add();
                        break;

                    case 2:
                        PL.Producto.Update();
                        break;

                    case 3:
                        PL.Producto.Delete();
                        break;

                    case 4:
                        PL.Producto.GetAll();
                        break;

                    case 5:
                        PL.Producto.GetById();
                        break;

                    case 6:
                        Console.WriteLine("Adios...");
                        break;

                    default:
                        Console.WriteLine("No existe esa opcion");
                        break;
                }

            } while (opcion != 6);
        }
}
}
