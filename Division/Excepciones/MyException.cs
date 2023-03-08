using System;

namespace Division.Excepciones
{
    public class MyException : Exception
    {
        public MyException(string message) : base($"Mensaje personalizado: {message}"){}
    
        public static void ThrowMyException()
        {
            throw new MyException("Ha ocurrido una excepción personalizada.");
        }
    }

    
}
