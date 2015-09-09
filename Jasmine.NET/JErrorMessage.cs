namespace JasmineNET
{
    class JErrorMessage
    {
        private JErrorMessage()
        {

        }

        public const string JEXPECT_TOBENULLFAIL = "JExpect.ToBeNull() Fail.";

        public const string JEXPECT_VALUENOTMATCH = "Value does not match. Expected: {0}. Actual: {1}";

        public const string CHECK_OBJECTNULL = "Check.IsNotNull() Fail.";

        public const string CHECK_OBJECTISNOTBOOLEAN = "Check.IsBoolean() Fail.";

        public const string CHECK_OBJECTISNOTARRAY = "Check.IsArray() Fail.";

        public const string JEXPECT_NOTSUPPORTED = "This operation is not operated so far.";
    }
}
