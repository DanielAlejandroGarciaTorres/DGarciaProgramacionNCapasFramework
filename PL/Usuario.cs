using ML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        static public void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();

            Console.WriteLine("DATOS DEL USUARIO \n");

            Console.WriteLine("User Name:");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Nombre:");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido materno:");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Email:");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();
            //usuario.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Genero: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono:");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Celular:");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP:");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Rol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            Console.WriteLine("DIRECCION DEL USUARIO\n");
            Console.WriteLine("Calle:");
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("Numero interior:");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("Numero exterior:");
            usuario.Direccion.NumeroExterior = Console.ReadLine();
            Console.WriteLine("Colonia");
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //result = BL.Usuario.Add(usuario);
            //result = BL.Usuario.AddSP(usuario);
            result = BL.Usuario.AddEF(usuario);
            //result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usaurio fue insertado");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void Update()
        {
            string idUsuario;
            ML.Result result = new ML.Result();
            ML.Usuario usuario = new ML.Usuario();  

            
            Console.WriteLine("Ingrese el Id del usuario a modificar:");
            idUsuario = Console.ReadLine();

            Console.WriteLine("DATOS DEL USUARIO: \n");

            Console.WriteLine("User Name:");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Nombre:");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apellido paterno:");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Apellido materno:");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Email:");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento:");
            usuario.FechaNacimiento = Console.ReadLine();
            //usuario.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Genero: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Telefono:");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Celular:");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("CURP:");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Rol:");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            Console.WriteLine("DIRECCION DEL USUARIO");
            Console.WriteLine("Calle:");
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = Console.ReadLine();
            Console.WriteLine("Numero interior:");
            usuario.Direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("Numero exterior:");
            usuario.Direccion.NumeroExterior = Console.ReadLine();
            Console.WriteLine("Colonia");
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());


            //result = BL.Usuario.Update(int.Parse(idUsuario), usuario);
            //result = BL.Usuario.UpdateSP(int.Parse(idUsuario), usuario);
            result = BL.Usuario.UpdateEF(int.Parse(idUsuario), usuario);
            //result = BL.Usuario.UpdateLINQ(int.Parse(idUsuario), usuario);

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue modificado");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }

        }

        static public void Delete()
        {
            string idUsuario;
            ML.Result result = new ML.Result();

            Console.WriteLine("\t\tUsuarios registrados:");

            Console.WriteLine("Ingrese el Id del usuario a eliminar:");
            idUsuario = Console.ReadLine();

            //result = BL.Usuario.Delete(int.Parse(idUsuario));
            //result = BL.Usuario.DeleteSP(int.Parse(idUsuario));
            result = BL.Usuario.DeleteEF(int.Parse(idUsuario));
            //result = BL.Usuario.DeleteLINQ(int.Parse(idUsuario));

            if (result.Correct)
            {
                Console.WriteLine("El usuario fue eliminado");
            }
            else
            {
                Console.WriteLine("El usuario no pudo ser eliminado");
                Console.WriteLine(result.ErrorMessage);
            }
        }

        static public void GetAll()
        {
            ML.Result result = new ML.Result();

            //result = BL.Usuario.GetAll();
            //result = BL.Usuario.GetAllSP();
            result = BL.Usuario.GetAllEF();
            //result = BL.Usuario.GetAllLINQ();

            Console.WriteLine("Los datos del usuario son los siguientes:\n");

            foreach (ML.Usuario usuario in result.Objects)
            {
                Console.WriteLine("Datos personales.\n\n");
                Console.WriteLine("Id Usuario: " + usuario.IdUsuario);
                Console.WriteLine("User Name: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Correo: " + usuario.Email);
                Console.WriteLine("Contrasena: " + usuario.Password);
                Console.WriteLine("Fecha nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Genero: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("CURP: " + usuario.CURP);
                Console.WriteLine("Imagen: " + usuario.Imagen);
                Console.WriteLine("Rol: " + usuario.Rol.Nombre);
                Console.WriteLine("\nDireccion.\n ");
                Console.WriteLine("Calle: " + usuario.Direccion.Calle);
                Console.WriteLine("Numero interior: " + usuario.Direccion.NumeroInterior);
                Console.WriteLine("Numero exterior: " + usuario.Direccion.NumeroExterior);
                Console.WriteLine("Colonia: " + usuario.Direccion.Colonia.Nombre);
                Console.WriteLine("Municipio: " + usuario.Direccion.Colonia.Municipio.Nombre);
                Console.WriteLine("Estado: " + usuario.Direccion.Colonia.Municipio.Estado.Nombre);
                Console.WriteLine("Pais: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre);

                Console.WriteLine("\n--------------------------------------------------\n");
            }
        }

        static public void GetById()
        {
            ML.Result result = new ML.Result();
            int idUsuario;

            Console.WriteLine("Ingresa el id del usuario que deseas visualizar");
            idUsuario = int.Parse(Console.ReadLine());

            //result = BL.Usuario.GetById(idUsuario);
            //result = BL.Usuario.GetByIdSP(idUsuario);
            result = BL.Usuario.GetByIdEF(idUsuario);
            //result = BL.Usuario.GetByIdLINQ(idUsuario);

            if (result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario = (ML.Usuario) result.Object; //unboxing 

                Console.WriteLine("Datos personales.\n\n");
                Console.WriteLine("Id Usuario: " + usuario.IdUsuario);
                Console.WriteLine("User Name: " + usuario.UserName);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Correo: " + usuario.Email);
                Console.WriteLine("Contrasena: " + usuario.Password);
                Console.WriteLine("Fecha nacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Genero: " + usuario.Sexo);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("CURP: " + usuario.CURP);
                Console.WriteLine("Imagen: " + usuario.Imagen);
                Console.WriteLine("Rol: " + usuario.Rol.Nombre);
                Console.WriteLine("\nDireccion.\n ");
                Console.WriteLine("Calle: " + usuario.Direccion.Calle);
                Console.WriteLine("Numero interior: " + usuario.Direccion.NumeroInterior);
                Console.WriteLine("Numero exterior: " + usuario.Direccion.NumeroExterior);
                Console.WriteLine("Colonia: " + usuario.Direccion.Colonia.Nombre);
                Console.WriteLine("Municipio: " + usuario.Direccion.Colonia.Municipio.Nombre);
                Console.WriteLine("Estado: " + usuario.Direccion.Colonia.Municipio.Estado.Nombre);
                Console.WriteLine("Pais: " + usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre);
                Console.WriteLine("\n--------------------------------------------------\n");

            } 
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

    }
}
