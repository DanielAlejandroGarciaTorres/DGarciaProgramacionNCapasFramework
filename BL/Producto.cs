using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        static public ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor,
                                        producto.Departamento.IdDepartamendo, producto.Descripcion, null);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    } 
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No pude insertar el producto";
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

        static public ML.Result Update(int idProducto, ML.Producto productoModificado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoUpdate(productoModificado.Nombre, productoModificado.PrecioUnitario, productoModificado.Stock, 
                                    productoModificado.Proveedor.IdProveedor, productoModificado.Departamento.IdDepartamendo, productoModificado.Descripcion,
                                    null, idProducto);

                    if (rowAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No fue posible la modificación del usuario";
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

        static public ML.Result Delete(int idProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoDelete(idProducto);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No pude elimar el producto seleccionado";
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

        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    List<DL_EF.ProductoGetAll_Result> productos = context.ProductoGetAll().ToList();

                    if (productos.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DL_EF.ProductoGetAll_Result producto in productos)
                        {
                            ML.Producto recuperaProducto = new ML.Producto();

                            recuperaProducto.IdProducto = producto.IdProducto;
                            recuperaProducto.Nombre = producto.NombreProducto;
                            recuperaProducto.PrecioUnitario = producto.PrecioUnitario;
                            recuperaProducto.Stock = producto.Stock;
                            recuperaProducto.Proveedor = new ML.Proveedor();
                            recuperaProducto.Proveedor.IdProveedor = producto.IdProveedor;
                            recuperaProducto.Proveedor.Nombre = producto.NombreProveedor;
                            recuperaProducto.Proveedor.Telefono = producto.Telefono;
                            recuperaProducto.Departamento = new ML.Departamento();
                            recuperaProducto.Departamento.IdDepartamendo = producto.IdDepartmento;
                            recuperaProducto.Departamento.Nombre = producto.NombreDepartamento;
                            recuperaProducto.Departamento.Area = new ML.Area();
                            recuperaProducto.Departamento.Area.IdArea = producto.IdArea;
                            recuperaProducto.Departamento.Area.Nombre = producto.NombreArea; 
                            recuperaProducto.Descripcion = producto.Descripcion;
                            recuperaProducto.Imagen = producto.Imagen;

                            result.Objects.Add(recuperaProducto);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No pude mostrar los productos";
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

        static public ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.DGarciaProgramacionNCapasEntities context = new DL_EF.DGarciaProgramacionNCapasEntities())
                {
                    DL_EF.ProductoGetByID_Result producto = context.ProductoGetByID(IdProducto).Single();

                    if (producto != null)
                    {
                        result.Object = new Object();

                        ML.Producto recuperaProducto = new ML.Producto();

                        recuperaProducto.IdProducto = producto.IdProducto;
                        recuperaProducto.Nombre = producto.NombreProducto;
                        recuperaProducto.PrecioUnitario = producto.PrecioUnitario;
                        recuperaProducto.Stock = producto.Stock;
                        recuperaProducto.Proveedor = new ML.Proveedor();
                        recuperaProducto.Proveedor.IdProveedor = producto.IdProveedor;
                        recuperaProducto.Proveedor.Nombre = producto.NombreProveedor;
                        recuperaProducto.Proveedor.Telefono = producto.Telefono;
                        recuperaProducto.Departamento = new ML.Departamento();
                        recuperaProducto.Departamento.IdDepartamendo = producto.IdDepartmento;
                        recuperaProducto.Departamento.Nombre = producto.NombreDepartamento;
                        recuperaProducto.Departamento.Area = new ML.Area();
                        recuperaProducto.Departamento.Area.IdArea = producto.IdArea;
                        recuperaProducto.Departamento.Area.Nombre = producto.NombreArea;
                        recuperaProducto.Descripcion = producto.Descripcion;
                        recuperaProducto.Imagen = producto.Imagen;

                        result.Object = recuperaProducto;
                        result.Correct = true;
                        
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No pude encontrar el productos";
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
