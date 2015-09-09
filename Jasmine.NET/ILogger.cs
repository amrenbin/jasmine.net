using System;

namespace JasmineNET
{
    public interface ILogger
    {
        void Verbose(object item);

        void Verbose(string item, params object[] args);

        void Information(object item);

        void Information(string item, params object[] args);

        void Warning(object item);

        void Warning(string item, params object[] args);

        void Error(object item);

        void Error(string item, params object[] args);

        void RecordMethod(Action method);

    }
}
