﻿namespace Logger
{
    using System;

    using Logger.Interfaces;
    using Logger.Models;
    using Logger.Models.Appenders;
    using Logger.Models.Layouts;

    public class LoggerStart
    {
        public static void Main()
        {
            try
            {
                var simpleLayout = new SimpleLayout();
                var xmlLayout = new XmlLayout();

                IAppender consoleAppender = new ConsoleAppender(simpleLayout);
                IAppender fileAppender = new FileAppender(simpleLayout);
                fileAppender.File = "../../log.txt";

                IAppender fileAppenderXml = new FileAppender(xmlLayout);
                fileAppenderXml.File = "../../log.xml";

                ILogger logger = new Logger(consoleAppender, fileAppender, fileAppenderXml);
                
                // add in logs
                logger.Error("Error parsing JSON.");
                logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
                logger.Warn("Warn - missing files.");
                logger.Fatal("mscorlib.dll does not respond");
                logger.Critical("No connection string found in App.config");

                logger.Info("Everything seems fine");
                logger.Warn("Warning: ping is too high - disconnect imminent");
                logger.Error("Error parsing request");
                logger.Critical("No connection string found in App.config");
                logger.Fatal("mscorlib.dll does not respond");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine();
        }
    }
}
