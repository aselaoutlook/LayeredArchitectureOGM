using System;

namespace FCL.Web.Framework.Core.Common.Contracts
{
    public interface ILoggerService
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception ex);
        void Fatal(string message);
        void Fatal(Exception ex);
    }
}
