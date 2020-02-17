using System;

namespace FnsOpenApi.Client.Interfaces
{
    public interface ILogWriter
    {
        void Error(string message);
        void Error(Exception ex);
        void Error(string className, Exception ex);
        void Trace(string message);
        void Info(string message);
    }
}