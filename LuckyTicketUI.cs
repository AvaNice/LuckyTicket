using Serilog;
using System;
using System.IO;

namespace LuckyTicket
{
    public class LuckyTicketUI
    {
        public string GetUserPath()
        {
            Console.Write($"{TextMessages.ENTER} {TextMessages.PATH} = ");

            string input = Console.ReadLine();

            if (File.Exists(input))
            {
                return input;
            }

            Log.Logger.Debug($"User input incorrect path: {input}");

            Console.WriteLine(TextMessages.FILE_DONT_EXIST);

            return GetUserPath();
        }

        public void ShowResult(string result)
        {
            Console.WriteLine(result);
        }

        public bool IsOneMore()
        {
            string input;
            bool result;

            Console.WriteLine(TextMessages.NEED_MORE);
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case TextMessages.YES:
                case TextMessages.YES_SECOND:
                    result = true;
                    break;

                case TextMessages.NO:
                case TextMessages.NO_SECOND:
                    result = false;
                    break;

                default:
                    Log.Logger.Information($"UI default. User input {input}");
                    Console.WriteLine(TextMessages.CANT_READ_MORE);

                    return IsOneMore();
            }

            return result;
        }
    }
}
