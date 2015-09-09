

namespace JasmineNET
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    public class JExpect
    {
        private object obj;

        private bool not = false;

        private JExpect(object obj)
            : this(obj, false)
        {
        }

        private JExpect(object obj, bool not)
        {
            this.obj = obj;
            this.not = not;
        }

        public static JExpect For(object obj)
        {
            JExpect jexp = new JExpect(obj);
            return jexp;
        }

        public static void Fail(string message, params string[] args)
        {
            JExpect.Fail(string.Format(message, args));
        }

        public static void Fail(string message)
        {
            JException.Throw(message);
        }

        public static void Fail()
        {
            var caller = new StackTrace().GetFrame(1).GetMethod();
            string message = string.Format("FAILURE from {0}.{1}.", caller.Name, caller.DeclaringType.Name);
            JExpect.Fail(message);
        }

        public JExpect ToEqual(object expect)
        {
            Check.IsNotNull(this.obj);
            Check.IsNotNull(expect);
            if ((!this.not) && (!obj.Equals(expect)) ||
                this.not && obj.Equals(expect))
            {
                JExpect.Fail();
            }

            return this;
        }

        public JExpect Not()
        {
            JExpect jexp = new JExpect(this.obj, true);
            return jexp;
        }

        public JExpect ToMatch(string regex)
        {
            Check.IsNotNull(this.obj);
            Check.IsNotNull(regex);
            var match = Regex.Match(Convert.ToString(this.obj), regex, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            if (((!this.not) && (!match.Success)) ||
                    (this.not && match.Success))
            {
                JExpect.Fail();
            }

            return this;
        }

        public JExpect ToBeNull()
        {
            if (((!this.not) && this.obj != null) ||
                    (this.not && this.obj == null))
            {
                JExpect.Fail(JErrorMessage.JEXPECT_TOBENULLFAIL);
            }

            return this;
        }

        public JExpect ToBeTruthy()
        {
            Check.IsBoolean(this.obj);
            var bObj = Convert.ToBoolean(this.obj);
            if (((!this.not) && (!bObj)) ||
                    this.not && bObj)
            {
                JExpect.Fail();
            }

            return this;
        }

        public JExpect ToBeFalsy()
        {
            return this.Not().ToBeTruthy();
        }

        public JExpect ToContain(object elementObj)
        {
            Check.IsArray(this.obj);
            Check.IsNotNull(elementObj);
            var elementType = this.obj.GetType().GetElementType();
            if (!elementType.Equals(elementObj.GetType()))
            {
                JExpect.Fail(JErrorMessage.JEXPECT_VALUENOTMATCH, elementType.Name, elementObj.GetType().Name);
            }

            var arrayObj = (Array)this.obj;
            bool contains = false;
            for (int i = 0; i < arrayObj.Length; i++)
            {
                if (arrayObj.GetValue(i).Equals(elementObj))
                {
                    contains = true;
                    break;
                }
            }

            if (((!this.not) && (!contains)) || (this.not && contains))
            {
                JExpect.Fail();
            }

            return this;
        }

        public JExpect ToBeGreaterThan()
        {
            Fail(JErrorMessage.JEXPECT_NOTSUPPORTED);
            return this;
        }

        public JExpect ToBeLessThan()
        {
            Fail(JErrorMessage.JEXPECT_NOTSUPPORTED);
            return this;
        }

        public JExpect ToBeCloseTo()
        {
            Fail(JErrorMessage.JEXPECT_NOTSUPPORTED);
            return this;
        }

        public JExpect ToThrow()
        {
            Fail(JErrorMessage.JEXPECT_NOTSUPPORTED);
            return this;
        }

        public JExpect ToThrowError()
        {
            Fail(JErrorMessage.JEXPECT_NOTSUPPORTED);
            return this;
        }
    }
}
