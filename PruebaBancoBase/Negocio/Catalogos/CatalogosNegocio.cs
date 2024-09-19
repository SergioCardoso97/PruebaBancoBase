using Acceso_Datos.Modelos;
using Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Catalogos
{
    public class CatalogosNegocio
    {
        PruebaBancoBaseContext ctx = new();
        
        public Respuesta obtenerCatalogoEstatusPago()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                List<CatEstatusPago> estatus = ctx.CatEstatusPagos.Where(x => x.Activo == true).ToList();
                if (estatus.Count == 0)
                {
                    respuesta.Exito = false;
                    respuesta.Mensaje = "No existen estatus de pago cargados en el sistema";
                    return respuesta;
                }
                respuesta.Exito = true;
                respuesta.Objeto = estatus;
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
