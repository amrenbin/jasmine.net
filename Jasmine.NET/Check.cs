namespace JasmineNET
{
    class Check
    {
        private Check()
        {

        }

        public static void IsNotNull(object obj)
        {
            if (obj == null)
            {
                JException.Throw(JErrorMessage.CHECK_OBJECTNULL);
            }
        }

        public static void IsBoolean(object obj)
        {
            Check.IsNotNull(obj);
            if (!(obj is bool))
            {
                JException.Throw(JErrorMessage.CHECK_OBJECTISNOTBOOLEAN);
            }
        }

        public static void IsArray(object obj)
        {
            //
            // Currently only array type ([]) is supported. Needs to consider support IEnumerable interface later.

            Check.IsNotNull(obj);
            if (!obj.GetType().IsArray)
            {
                JException.Throw(JErrorMessage.CHECK_OBJECTISNOTARRAY);
            }
        }
    }
}
