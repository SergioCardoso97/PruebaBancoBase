using Acceso_Datos.Modelos;
using DAO_DTO.DAO.Clientes;
using Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clientes
{
    public class ClientesNegocio
    {
        PruebaBancoBaseContext ctx = new PruebaBancoBaseContext();
        public Respuesta obtenerTodos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<TblCliente> clientes = ctx.TblClientes.Where(x => x.Activo == true).ToList();
                if (clientes.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen clientes cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = clientes;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta obtenerClientePorId(int idCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblCliente cliente = ctx.TblClientes.Where(x => x.Activo == true && x.Id == idCliente).FirstOrDefault();
                if (cliente == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el cliente con ese ID";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = cliente;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta crearCliente(CrearCliente clienteDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblCliente cliente = new();
                cliente.Nombre = clienteDAO.Nombre;
                cliente.Rfc = clienteDAO.RFC;
                ctx.TblClientes.Add(cliente);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Cliente Creado Correctamente";
                respuesta.Objeto = cliente;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta actualizarCliente(ActualizarCliente clienteDAO)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblCliente cliente = ctx.TblClientes.Where(x => x.Activo == true && x.Id == clienteDAO.Id).FirstOrDefault();
                if (cliente == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el cliente con ese ID";
                    return respuesta;
                }
                cliente.Nombre = clienteDAO.Nombre;
                cliente.Rfc = clienteDAO.RFC;
                ctx.TblClientes.Update(cliente);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Cliente Actualizado Correctamente";
                respuesta.Objeto = cliente;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                return respuesta;
            }
        }
        public Respuesta eliminarCliente(int idCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                TblCliente cliente = ctx.TblClientes.Where(x => x.Activo == true && x.Id == idCliente).FirstOrDefault();
                if (cliente == null)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existe el cliente con ese ID";
                    return respuesta;
                }
                cliente.Activo = false;
                ctx.TblClientes.Update(cliente);
                ctx.SaveChanges();
                respuesta.Exito = true;
                respuesta.Mensaje = "Cliente Eliminado Correctamente";
                respuesta.Objeto = cliente.Id;
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
