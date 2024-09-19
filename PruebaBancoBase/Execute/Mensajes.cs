using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos.Respuestas
{
    public class Mensajes
    {
        public static String OK { get { return "Operación realizada con Exito"; } }
        public static String Fail { get { return "Error al procesar el registro"; } }

        public static String FailCustom(String Mensaje)
        {
            return "Error al procesar el registro | Error: " + Mensaje;
        }
        public static String Custom404(String Mensaje)
        {
            return "No se encontro el recurso | Recurso: " + Mensaje;
        }
    }
}
