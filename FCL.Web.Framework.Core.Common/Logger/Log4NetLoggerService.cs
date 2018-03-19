using System;
using System.ComponentModel.Composition;
using FCL.Web.Framework.Core.Common.Contracts;
using log4net;
using log4net.Config;

namespace FCL.Web.Framework.Core.Common.Logger
{
    [Export(typeof(ILoggerService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Log4NetLoggerService : ILoggerService
    {
        private ILog logger;
        private bool isConfigured = false;

        public Log4NetLoggerService()
        {
            if (!isConfigured)
            {
                logger = LogManager.GetLogger(typeof(Log4NetLoggerService));
                XmlConfigurator.Configure();
            }
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
        public void Warn(string message)
        {
            logger.Warn(message);
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }
        public void Error(string message)
        {
            logger.Error(message);
        }
        public void Error(Exception ex)
        {
            logger.Error(ex.Message, ex);
        }
        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
        public void Fatal(Exception ex)
        {
            logger.Fatal(ex.Message, ex);
        }
    }
}
