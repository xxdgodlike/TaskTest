using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace TaskTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILog logInfo = GetLogManage("DaliyEmail\\", "DaliyEmail");
            logInfo.Info("开始邮件任务");
            logInfo.Info("读取Excel内容");
            logInfo.Info("----------------------开始发送第1封邮件--------------------------");
            logInfo.Info("连接Qlik服务器成功,序号:1");
            logInfo.Info("设置筛选条件成功,序号:1");
            logInfo.Info("导出Excel成功,序号:1");
            logInfo.Info("发送Email成功,序号:1");
            logInfo.Info("----------------------发送第1封邮件结束--------------------------");
            logInfo.Error("发送Email失败,序号:1;错误消息:测试");
            logInfo.Info("----------------------发送第1封邮件结束--------------------------");
        }

        private static ILog GetLogManage(string logPath, string logName)
        {
            //LevelRangeFilter  
            log4net.Filter.LevelRangeFilter levfilter = new log4net.Filter.LevelRangeFilter();
            levfilter.LevelMax = log4net.Core.Level.Fatal;
            levfilter.LevelMin = log4net.Core.Level.Error;
            levfilter.ActivateOptions();

            //Appender
            log4net.Appender.RollingFileAppender appender = new log4net.Appender.RollingFileAppender();
            appender.File = logPath;
            appender.Encoding = Encoding.UTF8;
            appender.AppendToFile = true;
            appender.RollingStyle = RollingMode.Date;
            appender.DatePattern = '"' + logName + "_" + '"' + "yyyyMMdd" + '"' + ".txt" + '"';
            appender.StaticLogFileName = false;

            ///layout  
            log4net.Layout.PatternLayout layout = new log4net.Layout.PatternLayout("%d [%t] %-5p %c - %m%n");
            layout.Header = "----------------------Start--------------------------" + Environment.NewLine;
            layout.Footer = "----------------------End----------------------------" + Environment.NewLine;
            //  
            appender.Layout = layout;
            appender.ActivateOptions();
            //  
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository("MyRepository");

            log4net.Config.BasicConfigurator.Configure(repository, appender);

            ILog logger = log4net.LogManager.GetLogger(repository.Name, logName);

            return logger;
        }
    }
}
