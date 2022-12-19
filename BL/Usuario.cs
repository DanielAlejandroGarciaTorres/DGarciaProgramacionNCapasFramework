using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ML;
using System.Data;
using System.Security.Cryptography;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using DL_EF;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        static public ML.Result Add (ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = context;


                    cmd.CommandText = "INSERT INTO [Usuarios] ([nombre],[apellidoPaterno],[apellidoMaterno],[correo])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Correo)";

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "UsuarioAdd";

                    SqlParameter[] collection = new SqlParameter[4];


                    collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("Correo", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.Email;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    //int RowsAffected = cmd.ExecuteReader();

                    cmd.Connection.Close();
                    
                    if(RowsAffected > 0)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }

                }
            } 
            catch (Exception e) {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        } 

        static public ML.Result Update( int idUsuario, ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UPDATE Usuarios SET nombre = @Nombre, apellidoPaterno = @ApellidoPaterno, apellidoMaterno = @ApellidoMaterno, correo = @Correo WHERE idAlumno = @IdAlumno";
                    
                    SqlParameter[] collection = new SqlParameter[5];


                    collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;
                    collection[3] = new SqlParameter("Correo", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.Email;
                    collection[4] = new SqlParameter("idAlumno", System.Data.SqlDbType.Int);
                    collection[4].Value = idUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        static public ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "DELETE FROM Usuarios WHERE idAlumno = @IdUsuario";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    collection[0].Value = idUsuario;


                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [idAlumno], [nombre] , [apellidoPaterno], [apellidoMaterno], [correo] FROM [Usuarios]";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Email = row[4].ToString();

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    } 
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tengo registros que mostrar ";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        static public ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [idAlumno], [nombre] , [apellidoPaterno], [apellidoMaterno], [correo] FROM [Usuarios]";
                    cmd.Connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        while (reader.Read())
                        {
                            if (reader.GetInt32(0) == idUsuario)
                            {
                                result.Object = new object();

                                usuario.IdUsuario = reader.GetInt32(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.ApellidoPaterno = reader.GetString(2);
                                usuario.ApellidoMaterno = reader.GetString(3);
                                usuario.Email = reader.GetString(4);

                                result.Object = usuario;
                                result.Correct = true;

                                break;
                            }
                        }   
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        //---------------------------------------------------------------------------

        static public ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = context;


                    //cmd.CommandText = "INSERT INTO [Usuarios] ([nombre],[apellidoPaterno],[apellidoMaterno],[correo])VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Correo)";

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UsuarioAdd";

                    SqlParameter[] collection = new SqlParameter[13];


                    collection[0] = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", System.Data.SqlDbType.Char);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", System.Data.SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;
                    collection[11] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                    collection[11].Value = DBNull.Value;
                    collection[12] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[12].Value = usuario.Rol.IdRol;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    //int RowsAffected = cmd.ExecuteReader();

                    cmd.Connection.Close();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        static public ML.Result UpdateSP(int idUsuario, ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UsuarioUpdate";

                    SqlParameter[] collection = new SqlParameter[14];


                    collection[0] = new SqlParameter("UserName", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", System.Data.SqlDbType.Char);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", System.Data.SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", System.Data.SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("CURP", System.Data.SqlDbType.VarChar);
                    collection[10].Value = usuario.CURP;
                    collection[11] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                    collection[11].Value = DBNull.Value;
                    collection[12] = new SqlParameter("IdRol", SqlDbType.Int);
                    collection[12].Value = usuario.Rol.IdRol;
                    collection[13] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    collection[13].Value = idUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        static public ML.Result DeleteSP(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.CommandText = "UsuarioDelete";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    collection[0].Value = idUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        static public ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UsuarioGetAll";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[12].ToString();
                            usuario.Email = row[4].ToString();
                            usuario.Password = row[5].ToString();
                            usuario.FechaNacimiento = row[6].ToString();
                            usuario.Sexo = row[7].ToString();
                            usuario.Telefono = row[8].ToString();
                            usuario.Celular = row[9].ToString();
                            usuario.CURP = row[10].ToString();
                            //usuario.Imagen = row[11].ToString();
                            usuario.Rol.IdRol = int.Parse(row[13].ToString());
                            

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tengo registros que mostrar ";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        static public ML.Result GetByIdSP(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UsuarioGetById";

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                    collection[0].Value = idUsuario;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = reader.GetInt32(0);
                        usuario.UserName = reader.GetString(1);
                        usuario.Nombre = reader.GetString(2);
                        usuario.ApellidoPaterno = reader.GetString(3);
                        usuario.ApellidoMaterno = reader.GetString(12);
                        usuario.Email = reader.GetString(4);
                        usuario.Password = reader.GetString(5);
                        usuario.FechaNacimiento = reader.GetDateTime(6).ToShortDateString();
                        usuario.Sexo = reader.GetString(7);
                        usuario.Telefono = reader.GetString(8);
                        usuario.Celular = reader.GetString(9);
                        usuario.CURP = reader.GetString(10);
                        //usuario.Image = row[11].ToString();
                        usuario.Rol.IdRol = reader.GetInt32(13);


                        result.Object = usuario; //BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No entontre al usuario deseado";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        //---------------------------------------------------------------------------

        static public ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.Email, 
                            usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular,
                            usuario.CURP, null,  usuario.ApellidoMaterno, usuario.Rol.IdRol, usuario.Direccion.Calle, 
                            usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Algo salio mal al insertar el elemento.";
                    }  
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result UpdateEF(int idUsuario, ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioUpdate(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.Email, usuario.Password,
                        usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, null, usuario.ApellidoMaterno,
                        usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,
                        usuario.Direccion.Colonia.IdColonia, idUsuario);

                    if ( rowAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Algo salio mal al modificar al usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }

            return result;
        }

        static public ML.Result DeleteEF(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioDelete(idUsuario);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Algo salio mal al eliminar al usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    List<DL_EF.UsuarioGetAll_Result> usuarios =  context.UsuarioGetAll().ToList();

                    if (usuarios.Count > 0)
                    {
                        result.Objects = new List<object> ();
                        foreach (DL_EF.UsuarioGetAll_Result usuario in usuarios)
                        {
                            ML.Usuario nuevoUsuario = new ML.Usuario();

                            nuevoUsuario.IdUsuario = usuario.IdUsuario;
                            nuevoUsuario.UserName = usuario.UserName;
                            nuevoUsuario.Nombre = usuario.NombreUsuario;
                            nuevoUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                            nuevoUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                            nuevoUsuario.Email = usuario.Email;
                            nuevoUsuario.Password = usuario.Password;
                            nuevoUsuario.FechaNacimiento = usuario.FechaNacimiento.ToShortDateString();
                            nuevoUsuario.Sexo = usuario.Sexo;
                            nuevoUsuario.Telefono = usuario.Telefono;
                            nuevoUsuario.Celular = usuario.Celular;
                            nuevoUsuario.CURP = usuario.CURP; 
                            nuevoUsuario.Imagen = usuario.Imagen;
                            nuevoUsuario.Rol = new ML.Rol();
                            nuevoUsuario.Rol.IdRol = usuario.IdRol;
                            nuevoUsuario.Rol.Nombre = usuario.NombreRol;
                            nuevoUsuario.Direccion = new ML.Direccion();
                            nuevoUsuario.Direccion.IdDireccion = usuario.IdDireccion;
                            nuevoUsuario.Direccion.Calle = usuario.Calle;
                            nuevoUsuario.Direccion.NumeroInterior = usuario.NumeroInterior;
                            nuevoUsuario.Direccion.NumeroExterior = usuario.NumeroExterior;
                            nuevoUsuario.Direccion.Colonia = new ML.Colonia();
                            nuevoUsuario.Direccion.Colonia.IdColonia = usuario.IdColonia;
                            nuevoUsuario.Direccion.Colonia.Nombre = usuario.NombreColonia;
                            nuevoUsuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            nuevoUsuario.Direccion.Colonia.Municipio.IdMunicipio = usuario.IdMunicipio;
                            nuevoUsuario.Direccion.Colonia.Municipio.Nombre = usuario.NombreMunicipio;
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuario.IdEstado;
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado.Nombre = usuario.NombreEstado;
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuario.IdPais;
                            nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuario.NombrePais;


                            result.Objects.Add (nuevoUsuario);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Algo salio mal al eliminar al usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.UsuarioGetById_Result usuario = context.UsuarioGetById(idUsuario).Single();

                    if (usuario != null)
                    {
                        ML.Usuario nuevoUsuario = new ML.Usuario();

                        nuevoUsuario.IdUsuario = usuario.IdUsuario;
                        nuevoUsuario.UserName = usuario.UserName;
                        nuevoUsuario.Nombre = usuario.NombreUsuario;
                        nuevoUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                        nuevoUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                        nuevoUsuario.Email = usuario.Email;
                        nuevoUsuario.Password = usuario.Password;
                        nuevoUsuario.FechaNacimiento = usuario.FechaNacimiento.ToShortDateString();
                        nuevoUsuario.Sexo = usuario.Sexo;
                        nuevoUsuario.Telefono = usuario.Telefono;
                        nuevoUsuario.Celular = usuario.Celular;
                        nuevoUsuario.CURP = usuario.CURP;
                        nuevoUsuario.Imagen = usuario.Imagen;
                        nuevoUsuario.Rol = new ML.Rol();
                        nuevoUsuario.Rol.IdRol = usuario.IdRol;
                        nuevoUsuario.Rol.Nombre = usuario.NombreRol;
                        nuevoUsuario.Direccion = new ML.Direccion();
                        nuevoUsuario.Direccion.IdDireccion = usuario.IdDireccion;
                        nuevoUsuario.Direccion.Calle = usuario.Calle;
                        nuevoUsuario.Direccion.NumeroInterior = usuario.NumeroInterior;
                        nuevoUsuario.Direccion.NumeroExterior = usuario.NumeroExterior;
                        nuevoUsuario.Direccion.Colonia = new ML.Colonia();
                        nuevoUsuario.Direccion.Colonia.IdColonia = usuario.IdColonia;
                        nuevoUsuario.Direccion.Colonia.Nombre = usuario.NombreColonia;
                        nuevoUsuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        nuevoUsuario.Direccion.Colonia.Municipio.IdMunicipio = usuario.IdMunicipio;
                        nuevoUsuario.Direccion.Colonia.Municipio.Nombre = usuario.NombreMunicipio;
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado.IdEstado = usuario.IdEstado;
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado.Nombre = usuario.NombreEstado;
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = usuario.IdPais;
                        nuevoUsuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = usuario.NombrePais;

                        result.Object = nuevoUsuario;  //boxing
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;  
        }

        //---------------------------------------------------------------------------

        static public ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario nuevoUsuario = new DL_EF.Usuario();

                    nuevoUsuario.UserName = usuario.UserName;
                    nuevoUsuario.Nombre = usuario.Nombre;
                    nuevoUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                    nuevoUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                    nuevoUsuario.Email = usuario.Email;
                    nuevoUsuario.Password = usuario.Password;
                    nuevoUsuario.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    nuevoUsuario.Sexo = usuario.Sexo;
                    nuevoUsuario.Telefono = usuario.Telefono;
                    nuevoUsuario.Celular = usuario.Celular;
                    nuevoUsuario.CURP = usuario.CURP;
                    nuevoUsuario.Imagen = null;
                    nuevoUsuario.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(nuevoUsuario);

                    if (context.SaveChanges() > 0)
                    {
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Algo salio mal al insertar el nuevo usuario";
                    }
 
                }
                
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result UpdateLINQ(int idUsuario, ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario  modificaUsuario =  (from user in context.Usuarios where user.IdUsuario == idUsuario select user).Single();

                    //Console.WriteLine(usuarioModifica.ElementType)

                    if (modificaUsuario != null)
                    {
                        modificaUsuario.UserName = usuario.UserName;
                        modificaUsuario.Nombre = usuario.Nombre;
                        modificaUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                        modificaUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                        modificaUsuario.Email = usuario.Email;
                        modificaUsuario.Password = usuario.Password;
                        modificaUsuario.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        modificaUsuario.Sexo = usuario.Sexo;
                        modificaUsuario.Telefono = usuario.Telefono;
                        modificaUsuario.Celular = usuario.Celular;
                        modificaUsuario.CURP = usuario.CURP;
                        modificaUsuario.Imagen = null;
                        modificaUsuario.IdRol = usuario.Rol.IdRol;
                    
                        if (context.SaveChanges() > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Algo salio mal al modificar al usuario";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result DeleteLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioRemueve = (from user in context.Usuarios where user.IdUsuario == idUsuario select user).Single();
                    context.Usuarios.Remove(usuarioRemueve);

                    if (context.SaveChanges() > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No pude eliminar el usuario seleccionado";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result GetAllLINQ()
        {
            ML.Result result = new Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    List<DL_EF.Usuario>  usuariosTabla = (from users in context.Usuarios select users).ToList();

                    result.Objects = new List<object>();

                    if (usuariosTabla.Count > 0)
                    {
                        foreach (DL_EF.Usuario usuario in usuariosTabla)
                        {
                            ML.Usuario nuevoUsuario = new ML.Usuario();

                            nuevoUsuario.IdUsuario = usuario.IdUsuario;
                            nuevoUsuario.UserName = usuario.UserName;
                            nuevoUsuario.Nombre = usuario.Nombre;
                            nuevoUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                            nuevoUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                            nuevoUsuario.Email = usuario.Email;
                            nuevoUsuario.Password = usuario.Password;
                            nuevoUsuario.FechaNacimiento = usuario.FechaNacimiento.ToShortDateString();
                            nuevoUsuario.Sexo = usuario.Sexo;
                            nuevoUsuario.Telefono = usuario.Telefono;
                            nuevoUsuario.Celular = usuario.Celular;
                            nuevoUsuario.CURP = usuario.CURP;
                            nuevoUsuario.Imagen = usuario.Imagen;
                            nuevoUsuario.Rol = new ML.Rol();
                            nuevoUsuario.Rol.IdRol = usuario.IdRol;

                            result.Objects.Add(nuevoUsuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tengo usuarios para mostrar";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static public ML.Result GetByIdLINQ(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuario = (from user in context.Usuarios where user.IdUsuario == idUsuario select user).Single();

                    if (usuario != null)
                    {
                        ML.Usuario selectUsuario = new ML.Usuario();

                        selectUsuario.IdUsuario = usuario.IdUsuario;
                        selectUsuario.Nombre = usuario.Nombre;
                        selectUsuario.ApellidoPaterno = usuario.ApellidoPaterno;
                        selectUsuario.ApellidoMaterno = usuario.ApellidoMaterno;
                        selectUsuario.Email = usuario.Email;
                        selectUsuario.Password = usuario.Password;
                        selectUsuario.FechaNacimiento = usuario.FechaNacimiento.ToShortDateString();
                        selectUsuario.Sexo = usuario.Sexo;
                        selectUsuario.Telefono = usuario.Telefono;
                        selectUsuario.Celular = usuario.Celular;
                        selectUsuario.CURP = usuario.CURP;
                        selectUsuario.Imagen = usuario.Imagen;
                        selectUsuario.Rol = new ML.Rol();
                        selectUsuario.Rol.IdRol = usuario.IdRol;

                        result.Object = selectUsuario;  //boxing
                        result.Correct = true;
                    } 
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No encontre el usuario solicitado";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
