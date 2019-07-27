using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.Extensions.Logging;
using System;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface ILogRepository:IGenericRepository<LogEntity>
    {
        void LogInfo(string message,string url, LogLevel level);
        void LogError(Exception ex, string url, LogLevel level);
    }
}
