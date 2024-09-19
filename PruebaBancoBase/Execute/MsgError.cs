namespace Acceso_Datos.Modelos
{
    public class MsgError
    {
        public const String Add = "Error al agregar elemento";
        public const String Update = "Error al actualizar elemento";
        public const String Status = "Error al actualizar estatus del elemento";
        public const String Select = "Error al listar información";
        public const String Remove = "Error al Eliminar elemento";
        public const String RemoveRange = "Error al Eliminar elementos";
        public const String Mail = "No fue posible enviar el correo";
    }
    public static class Error
    {
        public static Respuesta set(String tipe, String Error)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Exito = false;
            Respuesta_.Error = Error;
            Respuesta_.Mensaje = tipe;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, String Error, int id)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Exito = false;
            Respuesta_.Error = Error;
            Respuesta_.Mensaje = tipe;
            Respuesta_.Id = id;
            return Respuesta_;
        }
    }

}
