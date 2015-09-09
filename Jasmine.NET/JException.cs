
namespace JasmineNET
{
    using System;

    [Serializable]
    public class JException : Exception
    {

        public JException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public JException(string message)
            : base(message)
        {

        }



        public static JException Throw(string message)
        {
            JException ex = new JException(message);
            throw ex;
        }

        public static JException Throw(string message, params string[] args)
        {
            JException ex = new JException(string.Format(message, args));
            throw ex;
        }

        public static JException Throw(string message, Exception innerException)
        {
            JException ex = new JException(message, innerException);
            throw ex;
        }

        public static JException Throw(Exception innerException, string message, params string[] args)
        {
            JException ex = new JException(string.Format(message, args), innerException);
            throw ex;
        }
    }
}
