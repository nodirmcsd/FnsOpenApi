using System;
using FnsOpenApi.Domain.Interfaces;
using NLog;

namespace FnsOpenApi.Services
{
    public class LogWriter : ILogWriter
    {
        private readonly ILogger _logger;
        public LogWriter()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        
        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error($"Error occured: {ex.Message}");
            _logger.Error(ex);
        }

        public void Error(string className, Exception ex)
        {
            _logger.Error($"Error occured at {className}: {ex.Message}");
            _logger.Error(ex);
        }
        
        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }
    }
}
