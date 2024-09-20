using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Ordenes;
using Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Ordenes
{
    public class OrdenesNegocio
    {
        PruebaBancoBaseContext ctx = new PruebaBancoBaseContext();
        public Respuesta obtenerTodos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<TblOrdene> Ordenes = ctx.TblOrdenes.Where(x => x.Activo == true).Include(x => x.RelOrdenesProductos).ToList();
                if (Ordenes.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen Ordenes cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Ordenes;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta obtenerOrdenPorId(int idOrden)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblOrdene Orden = ctx.TblOrdenes.Where(x => x.Activo == true && x.Id == idOrden).Include(x => x.RelOrdenesProductos).FirstOrDefault();
                if (Orden == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Orden con ese ID";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Orden;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta obtenerOrdenesPorCliente(int idCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<TblOrdene> Ordenes = ctx.TblOrdenes.Where(x => x.Activo == true && x.IdTblCliente == idCliente).Include(x => x.RelOrdenesProductos).ToList();
                if (Ordenes.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen Ordenes para ese Cliente cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Ordenes;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta crearOrden(CrearOrden OrdenDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblOrdene Orden = new();
                Orden.IdTblCliente = OrdenDAO.IdCliente;
                ctx.TblOrdenes.Add(Orden);
                ctx.SaveChanges();
                foreach (var item in OrdenDAO.ordenProductos)
                {
                    RelOrdenesProducto ordenProducto = new();
                    ordenProducto.IdTblProductos = item.IdProducto;
                    ordenProducto.IdTblOrdenes = Orden.Id;
                    ctx.RelOrdenesProductos.Add(ordenProducto);
                    ctx.SaveChanges();
                }
                respuesta.Exito = true;
                respuesta.Mensaje = "Orden Creado Correctamente";
                respuesta.Objeto = Orden;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta actualizarOrden(ActualizarOrden OrdenDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblOrdene Orden = ctx.TblOrdenes.Where(x => x.Activo == true && x.Id == OrdenDAO.Id).FirstOrDefault();
                if (Orden == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Orden con ese ID";
                    return respuesta;
                }
                Orden.IdTblCliente = OrdenDAO.IdCliente;
                ctx.TblOrdenes.Update(Orden);
                ctx.SaveChanges();
                ctx.RelOrdenesProductos.RemoveRange(ctx.RelOrdenesProductos.Where(x => x.IdTblOrdenes == Orden.Id).ToList());
                ctx.SaveChanges();
                foreach (var item in OrdenDAO.ordenProductos)
                {
                    RelOrdenesProducto ordenProducto = new();
                    ordenProducto.IdTblProductos = item.IdProducto;
                    ordenProducto.IdTblOrdenes = Orden.Id;
                    ctx.RelOrdenesProductos.Add(ordenProducto);
                    ctx.SaveChanges();
                }
                respuesta.Exito = true;
                respuesta.Mensaje = "Orden Actualizado Correctamente";
                respuesta.Objeto = Orden;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta eliminarOrden(int idOrden)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblOrdene Orden = ctx.TblOrdenes.Where(x => x.Activo == true && x.Id == idOrden).FirstOrDefault();
                if (Orden == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Orden con ese ID";
                    return respuesta;
                }
                Orden.Activo = false;
                ctx.TblOrdenes.Update(Orden);
                ctx.SaveChanges();
                ctx.RelOrdenesProductos.RemoveRange(ctx.RelOrdenesProductos.Where(x => x.IdTblOrdenes == Orden.Id).ToList());
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Orden Eliminado Correctamente";
                respuesta.Objeto = Orden.Id;
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
