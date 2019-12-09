using System;
using System.IO;

namespace LuckyTicket
{
    class LuckyTicketUI
    {
        public string GetUserPath()
        {
            Console.Write($"{TextMessages.ENTER} {TextMessages.PATH} = ");

            string input = Console.ReadLine();

            if (File.Exists(input))
            {
                return input;
            }

            Console.WriteLine(TextMessages.FILE_DONT_EXIST);

            return GetUserPath();
        }

        public void ShowResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
