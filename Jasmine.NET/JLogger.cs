namespace JasmineNET
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using log4net;

    internal sealed class JLogger : ILogger
    {
        public static ILogger Default { get; private set; }

        static JLogger()
        {
            Default = new JLogger();
        }

        private JLogger()
        {

        }

        public void Error(object item)
        {
            this.GetLogger().Error(item);
        }

        public void Error(string item, params object[] args)
        {
            this.GetLogger().ErrorFormat(item, args);
        }

        public void Information(object item)
        {
            this.GetLogger().Info(item);
        }

        public void Information(string item, params object[] args)
        {
            this.GetLogger().InfoFormat(item, args);
        }

        public void Verbose(object item)
        {
            this.GetLogger().Debug(item);
        }

        public void Verbose(string item, params object[] args)
        {
            this.GetLogger().DebugFormat(item, args);
        }

        public void Warning(object item)
        {
            this.GetLogger().Warn(item);
        }

        public void Warning(string item, params object[] args)
        {
            this.GetLogger().WarnFormat(item, args);
        }

        public void RecordMethod(Action method)
        {
            var logger = LogManager.GetLogger(method.Target.ToString());
            logger.InfoFormat("Begin method {0}", method.Method.Name);
            method.Invoke();
            logger.InfoFormat("Finish method {0}", method.Method.Name);
        }

        private string GetCallerName()
        {
            var externalCaller = new StackTrace().GetFrames().Where(o => o.GetMethod().DeclaringType != GetType()).FirstOrDefault();

            if (externalCaller != null)
            {
                var method = externalCaller.GetMethod();
                return string.Concat(method.DeclaringType.Name, ".", method.Name);
            }

            return string.Empty;
        }

        private ILog GetLogger()
        {
            return LogManager.GetLogger(this.GetCallerName());

        }
    }
}
