using Serilog;
using System;
using System.IO;

namespace LuckyTicket
{
    class Program
    {
        private const int COUNT_OF_RANKS = 6;

        static void Main(string[] args = null)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("log.txt")
               .CreateLogger();

            LuckyTicketUI userInterface = new LuckyTicketUI();

            try
            {
                var app = new LuckyTicketApp(COUNT_OF_RANKS);
                RunMode runMode;
                int result;

                runMode = GetMode(userInterface.GetUserPath());
                result = app.Run(runMode);

                Log.Logger.Debug($"Algorithm({COUNT_OF_RANKS}) return {result}");

                userInterface.ShowResult(result.ToString());
            }
            catch (IOException ex)
            {
                Log.Logger.Error($"{ex.Message}");
                userInterface.ShowResult(TextMessages.FILE_ERROR);
            }
            catch (ArgumentException ex)
            {
                Log.Logger.Error($"{ex.Message}");
                userInterface.ShowResult(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message}");
            }

            Main();
        }

        public static RunMode GetMode(string path)
        {
            RunMode runMode;
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();

            switch (line.ToLower())
            {
                case TextMessages.MOSKOW:

                    runMode = LuckyTicket.RunMode.Moskow;
                    break;

                case TextMessages.PITER:

                    runMode = LuckyTicket.RunMode.Piter;
                    break;

                default:

                    Log.Logger.Debug($"GetMode() default: cant read mode in {line}");

                    throw new ArgumentException(TextMessages.CANT_READ_MODE);

            }

            return runMode;
        }
    }
}
