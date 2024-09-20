using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Pagos;
using DAO_DTO.DTO.Pagos;
using Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Pagos
{
    public class PagosNegocio
    {
        PruebaBancoBaseContext ctx = new PruebaBancoBaseContext();
        public Respuesta obtenerEstatusPorId(int idPago)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblPago pago = ctx.TblPagos.Where(x => x.Activo == true && x.Id == idPago).Include(x => x.IdCatEstatusNavigation)
                    .Include(x => x.IdTblClienteNavigation).Include(x => x.IdTblVendedoresNavigation).FirstOrDefault();
                if (pago == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe un pago con ese ID en el sistema";
                    return respuesta;
                }
                ObtenerEstatusPago estatusPago = new();
                estatusPago.IdEstatus = pago.IdCatEstatus;
                estatusPago.Estatus = pago.IdCatEstatusNavigation.Estatus;
                estatusPago.IdCliente = pago.IdTblCliente;
                estatusPago.Cliente = pago.IdTblClienteNavigation.Nombre;
                estatusPago.IdVendedor = pago.IdTblVendedores;
                estatusPago.Vendedor = pago.IdTblVendedoresNavigation.Nombre;
                estatusPago.Concepto = pago.Concepto;
                estatusPago.MontoTotal = pago.MontoTotal;
                respuesta.Exito = true;
                respuesta.Mensaje = "Estatus del Pago";
                respuesta.Objeto = estatusPago; 
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta crearPago(CrearPago pagoDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblPago pago = new TblPago();
                pago.IdCatEstatus = 1;//Estatus por default es Pendiente
                pago.IdTblCliente = pagoDAO.IdCliente;
                pago.IdTblVendedores = pagoDAO.IdVendedor;
                pago.IdTblOrdenes = pagoDAO.IdOrden;
                pago.Concepto = pagoDAO.Concepto;
                pago.CantidadProductos = ctx.RelOrdenesProductos.Where(x => x.IdTblOrdenes == pagoDAO.IdOrden).Count();
                double Montototal = 0;
                foreach (var item in ctx.RelOrdenesProductos.Where(x => x.IdTblOrdenes == pagoDAO.IdOrden).ToList())
                {
                    Montototal += ctx.TblProductos.Where(x => x.Id == item.IdTblProductos).Select(x => x.Precio).FirstOrDefault();
                }
                pago.MontoTotal = Montototal;
                ctx.TblPagos.Add(pago);
                ctx.SaveChanges();
                pago = ctx.TblPagos.Where(x => x.Activo == true && x.Id == pago.Id).Include(x => x.IdCatEstatusNavigation)
                    .Include(x => x.IdTblClienteNavigation).Include(x => x.IdTblVendedoresNavigation).FirstOrDefault();
                ObtenerEstatusPago estatusPago = new();
                estatusPago.IdEstatus = pago.IdCatEstatus;
                estatusPago.Estatus = pago.IdCatEstatusNavigation.Estatus;
                estatusPago.IdCliente = pago.IdTblCliente;
                estatusPago.Cliente = pago.IdTblClienteNavigation.Nombre;
                estatusPago.IdVendedor = pago.IdTblVendedores;
                estatusPago.Vendedor = pago.IdTblVendedoresNavigation.Nombre;
                estatusPago.Concepto = pago.Concepto;
                estatusPago.MontoTotal = pago.MontoTotal;
                respuesta.Exito = true;
                respuesta.Mensaje = "Pago Enviado";
                respuesta.Objeto = estatusPago;
                return  respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta cambiarEstatusPago(int idPago,int idEstatus)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblPago pago = ctx.TblPagos.Where(x => x.Activo == true && x.Id == idPago).Include(x => x.IdCatEstatusNavigation)
                    .Include(x => x.IdTblClienteNavigation).Include(x => x.IdTblVendedoresNavigation).FirstOrDefault();
                if (pago == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe un pago con ese ID en el sistema";
                    return respuesta;
                }
                pago.IdCatEstatus = idEstatus;
                ctx.TblPagos.Update(pago);
                ctx.SaveChanges();
                pago = ctx.TblPagos.Where(x => x.Activo == true && x.Id == idPago).Include(x => x.IdCatEstatusNavigation)
                    .Include(x => x.IdTblClienteNavigation).Include(x => x.IdTblVendedoresNavigation).FirstOrDefault();
                ObtenerEstatusPago estatusPago = new();
                estatusPago.IdEstatus = pago.IdCatEstatus;
                estatusPago.Estatus = pago.IdCatEstatusNavigation.Estatus;
                estatusPago.IdCliente = pago.IdTblCliente;
                estatusPago.Cliente = pago.IdTblClienteNavigation.Nombre;
                estatusPago.IdVendedor = pago.IdTblVendedores;
                estatusPago.Vendedor = pago.IdTblVendedoresNavigation.Nombre;
                estatusPago.Concepto = pago.Concepto;
                estatusPago.MontoTotal = pago.MontoTotal;
                respuesta.Exito = true;
                respuesta.Mensaje = idEstatus == 2 ? "Pago Aceptado" : "Pago Rechazado";
                respuesta.Objeto = estatusPago;
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
