using System;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.Extensions.Logging;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfLogRepository : EfGenericRepository<LogEntity>, ILogRepository
    {
        public void LogError(Exception ex, string url, LogLevel level)
        {
            var logEnt=new LogEntity
            {
                Message = ex.Message,
                Level=(int)level,
                Url = url
            };

            _context.Add(logEnt);
        }

        public void LogInfo(string message, string url, LogLevel level)
        {
            var logEnt = new LogEntity
            {
                Message = message,
                Level = (int)level,
                Url = url
            };

            _context.Add(logEnt);
        }
    }
}
