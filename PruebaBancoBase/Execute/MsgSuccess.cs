namespace Acceso_Datos.Modelos
{
    public class MsgSuccess
    {
        public const String Add = "Se agregó elemento";
        public const String Update = "Se actualizó elemento";
        public const String Status = "Se actualizó estatus";
        public const String Select = "Se encontrarón elementos para listar";
        public const String Empty = "No se encotrarón resultados";
        public const String Remove = "Se eliminó elemento";
        public const String RemoveRange = "Se eliminó la lista de elementos";
        public const String Validation = "Validación Exitosa";
        public const String Mail = "Se envió correctamente el correo";
    }

    public static class Success
    {
        public static Respuesta set(String tipe)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, String Anotacion)
        {
          Respuesta Respuesta_ = new Respuesta();
          Respuesta_.Exito = true;
          Respuesta_.Mensaje = tipe;
          Respuesta_.Anotacion= Anotacion;
          return Respuesta_;
        }
    public static Respuesta set(String tipe, Object obj)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            Respuesta_.Objeto = obj;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, Object obj, String anotacion)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            Respuesta_.Objeto = obj;
            Respuesta_.Anotacion = anotacion;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, int id)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Id = id;
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, Object obj, int id)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Id = id;
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            Respuesta_.Objeto = obj;
            return Respuesta_;
        }
        public static Respuesta set(String tipe, Object obj, String anotacion, int id)
        {
            Respuesta Respuesta_ = new Respuesta();
            Respuesta_.Id = id;
            Respuesta_.Exito = true;
            Respuesta_.Mensaje = tipe;
            Respuesta_.Objeto = obj;
            Respuesta_.Anotacion = anotacion;
            return Respuesta_;
        }
    }

}
