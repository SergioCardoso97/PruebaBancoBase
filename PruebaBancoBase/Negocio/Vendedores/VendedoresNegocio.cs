using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Vendedores;
using Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Vendedores
{
    public class VendedoresNegocio
    {
        PruebaBancoBaseContext ctx = new PruebaBancoBaseContext();
        public Respuesta obtenerTodos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<TblVendedore> vendedores = ctx.TblVendedores.Where(x => x.Activo == true).ToList();
                if (vendedores.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen vendedores cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = vendedores;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta obtenerVendedorPorId(int idVendedor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblVendedore Vendedor = ctx.TblVendedores.Where(x => x.Activo == true && x.Id == idVendedor).FirstOrDefault();
                if (Vendedor == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Vendedor con ese ID";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = Vendedor;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta crearVendedor(CrearVendedor VendedorDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblVendedore Vendedor = new();
                Vendedor.Nombre = VendedorDAO.Nombre;
                Vendedor.Rfc = VendedorDAO.RFC;
                ctx.TblVendedores.Add(Vendedor);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Vendedor Creado Correctamente";
                respuesta.Objeto = Vendedor;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta actualizarVendedor(ActualizarVendedor VendedorDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblVendedore Vendedor = ctx.TblVendedores.Where(x => x.Activo == true && x.Id == VendedorDAO.Id).FirstOrDefault();
                if (Vendedor == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Vendedor con ese ID";
                    return respuesta;
                }
                Vendedor.Nombre = VendedorDAO.Nombre;
                Vendedor.Rfc = VendedorDAO.RFC;
                ctx.TblVendedores.Update(Vendedor);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Vendedor Actualizado Correctamente";
                respuesta.Objeto = Vendedor;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta eliminarVendedor(int idVendedor)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblVendedore Vendedor = ctx.TblVendedores.Where(x => x.Activo == true && x.Id == idVendedor).FirstOrDefault();
                if (Vendedor == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el Vendedor con ese ID";
                    return respuesta;
                }
                Vendedor.Activo = false;
                ctx.TblVendedores.Update(Vendedor);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Vendedor Eliminado Correctamente";
                respuesta.Objeto = Vendedor.Id;
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
