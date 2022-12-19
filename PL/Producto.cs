using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        static public void Add()
        {
            ML.Result result = new ML.Result();
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("INGRESE LOS DATOS DEL PRODUCTO\n");
            Console.WriteLine("Nombre:");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Precio unitario:");
            producto.PrecioUnitario = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Stock:");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Id Proveedor:");
            producto.Proveedor = new ML.Proveedor();   
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Id Departamento:");
            producto.Departamento = new ML.Departamento();   
            producto.Departamento.IdDepartamendo = int.Parse(Console.ReadLine());
            Console.WriteLine("Descripcion: ");
            producto.Descripcion = Console.ReadLine();
            //producto.Imagen = null

            result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("\n-------------PRODUCTO INSERTADO-------------\n");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void Update()
        {
            ML.Result result = new ML.Result();
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("INGRESE LOS DATOS DEL PRODUCTO A MODIFICAR\n");

            Console.WriteLine("\nIngrese el ID del producto a modificar");
            int idProducto = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre:");
            producto.Nombre = Console.ReadLine();
            Console.WriteLine("Precio unitario:");
            producto.PrecioUnitario = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Stock:");
            producto.Stock = int.Parse(Console.ReadLine());
            Console.WriteLine("Id Proveedor:");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());
            Console.WriteLine("Id Departamento:");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamendo = int.Parse(Console.ReadLine());
            Console.WriteLine("Descripcion: ");
            producto.Descripcion = Console.ReadLine();

            result = BL.Producto.Update(idProducto, producto);

            if (result.Correct)
            {
                Console.WriteLine("\n-------------PRODUCTO MODIFICADO------------\n");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void Delete()
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("INGRESE LOS DATOS DEL PRODUCTO A ELLIMINAR\n");

            Console.WriteLine("\nIngrese el ID del producto a modificar");
            int idProducto = int.Parse(Console.ReadLine());

            result =  BL.Producto.Delete(idProducto);

            if (result.Correct)
            {
                Console.WriteLine("\n--------------PRODUCTO ELIMINADO------------\n");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void GetAll()
        {
            ML.Result result = new ML.Result();

            result = BL.Producto.GetAll();

            if (result.Correct)
            {

                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("\nDETALLES DE PRODUCTO\n");

                    Console.WriteLine("Id producto: " + producto.IdProducto);
                    Console.WriteLine("Nombre: " + producto.Nombre);
                    Console.WriteLine("Precio unitario: " + producto.PrecioUnitario);
                    Console.WriteLine("Stock: " + producto.Stock);
                    Console.WriteLine("Id proveedor : " + producto.Proveedor.IdProveedor);
                    Console.WriteLine("Nombre proveedor : " + producto.Proveedor.Nombre);
                    Console.WriteLine("Telefono proveedor : " + producto.Proveedor.Telefono);
                    Console.WriteLine("Id departamento: " + producto.Departamento.IdDepartamendo);
                    Console.WriteLine("Nombre departamento: " + producto.Departamento.Nombre);
                    Console.WriteLine("Id area: " + producto.Departamento.Area.IdArea);
                    Console.WriteLine("Nombre area: " + producto.Departamento.Area.Nombre);
                    Console.WriteLine("Descripcion: " + producto.Descripcion);
                    Console.WriteLine("Imagen: " + producto.Imagen);

                    Console.WriteLine("\n-------------------------------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void GetById()
        {
            ML.Result result = new ML.Result();

            Console.WriteLine("Ingrese el ID del producto que desea visualizar:");

            result = BL.Producto.GetById(int.Parse(Console.ReadLine()));

            if (result.Correct)
            {
                ML.Producto producto = (ML.Producto) result.Object;
            
                Console.WriteLine("\nDETALLES DE PRODUCTO\n");

                Console.WriteLine("Id producto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio unitario: " + producto.PrecioUnitario);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Id proveedor : " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Nombre proveedor : " + producto.Proveedor.Nombre);
                Console.WriteLine("Telefono proveedor : " + producto.Proveedor.Telefono);
                Console.WriteLine("Id departamento: " + producto.Departamento.IdDepartamendo);
                Console.WriteLine("Nombre departamento: " + producto.Departamento.Nombre);
                Console.WriteLine("Id area: " + producto.Departamento.Area.IdArea);
                Console.WriteLine("Nombre area: " + producto.Departamento.Area.Nombre);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine("Imagen: " + producto.Imagen);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }

             
        }
    }
}
