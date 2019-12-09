using System;
using System.IO;

namespace LuckyTicket
{
    class LuckyTicketApp
    {
        private const int LAST_TIKET_NUMBER = 999999;
        private const int COUNT_OF_RANKS = 6;
        private readonly LuckyTicketUI UI = new LuckyTicketUI();

        public void Start()
        {
           
            try
            {
                UserMode userMod = GetMode(UI.GetUserPath());

                UI.ShowResult(RunMode(userMod).ToString());
            }

            catch (IOException ex)
            {
                // TODO log
                UI.ShowResult(TextMessages.FILE_DONT_EXIST);
            }

            catch (ArgumentException ex)
            {
                //TODO log
                UI.ShowResult(TextMessages.CANT_READ_MODE);
            }

            Start();
        }

        public UserMode GetMode(string path)
        {
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();

            switch (line.ToLower())
            {
                case TextMessages.MOSKOW:

                    return UserMode.Moskow;

                case TextMessages.PITER:

                    return UserMode.Piter;

                default:

                    //TODO log

                    throw new ArgumentException(TextMessages.CANT_READ_MODE);

            }
        }

        public int RunMode(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.Moskow:

                    var moskowCounter = new LuckyTicketCuonter(new MoskowAlgorithm(COUNT_OF_RANKS));

                    return moskowCounter.CountLucky(1, LAST_TIKET_NUMBER);

                case UserMode.Piter:

                    var piterCounter = new LuckyTicketCuonter(new PiterAlgorithm(COUNT_OF_RANKS));

                    return piterCounter.CountLucky(1, LAST_TIKET_NUMBER);

                default:

                    //TODO log
                    throw new ArgumentException();
            }
        }
    }
}
