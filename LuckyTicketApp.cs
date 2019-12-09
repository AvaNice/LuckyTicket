using System;
using System.IO;

namespace LuckyTicket
{
    class LuckyTicketApp
    {
        private readonly int LAST_TIKET_NUMBER;
        private readonly LuckyTicketUI UI = new LuckyTicketUI();
        private readonly int COUNT_OF_RANKS;

        public LuckyTicketApp(int lastTiketNumber, int countOfRanks)
        {
            LAST_TIKET_NUMBER = lastTiketNumber;
            COUNT_OF_RANKS = countOfRanks;
        }

        public void Start()
        {
           
            try
            {
                RunMode runMod = GetMode(UI.GetUserPath());

                UI.ShowResult(RunMode(runMod).ToString());
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

        public RunMode GetMode(string path)
        {
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();

            switch (line.ToLower())
            {
                case TextMessages.MOSKOW:

                    return LuckyTicket.RunMode.Moskow;

                case TextMessages.PITER:

                    return LuckyTicket.RunMode.Piter;

                default:

                    //TODO log

                    throw new ArgumentException(TextMessages.CANT_READ_MODE);

            }
        }

        public int RunMode(RunMode userMode)
        {
            switch (userMode)
            {
                case LuckyTicket.RunMode.Moskow:

                    var moskowCounter = new LuckyTicketCuonter(new MoskowAlgorithm(), COUNT_OF_RANKS);

                    return moskowCounter.CountLucky(1, LAST_TIKET_NUMBER);

                case LuckyTicket.RunMode.Piter:

                    var piterCounter = new LuckyTicketCuonter(new PiterAlgorithm(), COUNT_OF_RANKS);

                    return piterCounter.CountLucky(1, LAST_TIKET_NUMBER);

                default:

                    //TODO log
                    throw new ArgumentException();
            }
        }
    }
}
