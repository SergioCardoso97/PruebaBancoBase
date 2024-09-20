using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Productos;
using Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Productos
{
    public class ProductosNegocio
    {
        PruebaBancoBaseContext ctx = new PruebaBancoBaseContext();
        public Respuesta obtenerTodos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<TblProducto> Productos = ctx.TblProductos.Where(x => x.Activo == true).Include(x => x.IdTblVendedorNavigation).ToList();
                if (Productos.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen Productos cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Productos;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta obtenerProductoPorId(int idProducto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblProducto Producto = ctx.TblProductos.Where(x => x.Activo == true && x.Id == idProducto).Include(x => x.IdTblVendedorNavigation).FirstOrDefault();
                if (Producto == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Producto con ese ID";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Producto;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta crearProducto(CrearProducto ProductoDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblProducto Producto = new();
                Producto.IdTblVendedor = ProductoDAO.IdVendedor;
                Producto.Producto = ProductoDAO.Producto;
                Producto.Precio = ProductoDAO.Precio;
                ctx.TblProductos.Add(Producto);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Producto Creado Correctamente";
                respuesta.Objeto = Producto;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta actualizarProducto(ActualizarProducto ProductoDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblProducto Producto = ctx.TblProductos.Where(x => x.Activo == true && x.Id == ProductoDAO.Id).FirstOrDefault();
                if (Producto == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Producto con ese ID";
                    return respuesta;
                }
                Producto.IdTblVendedor = ProductoDAO.IdVendedor;
                Producto.Producto = ProductoDAO.Producto;
                Producto.Precio = ProductoDAO.Precio;
                ctx.TblProductos.Update(Producto);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Producto Actualizado Correctamente";
                respuesta.Objeto = Producto;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta eliminarProducto(int idProducto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblProducto Producto = ctx.TblProductos.Where(x => x.Activo == true && x.Id == idProducto).FirstOrDefault();
                if (Producto == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Producto con ese ID";
                    return respuesta;
                }
                Producto.Activo = false;
                ctx.TblProductos.Update(Producto);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Producto Eliminado Correctamente";
                respuesta.Objeto = Producto.Id;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
    }
}
