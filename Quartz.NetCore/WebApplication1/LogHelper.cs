using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1
{
    public class LogHelpr
    {
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Debug(string info)
        {
            logger.Debug(info);
        }

        public static void Info(string info)
        {
            logger.Info(info);
        }

        public static void Error(Exception ex, string info = "")
        {
            logger.Error(ex);
        }

    }
}
