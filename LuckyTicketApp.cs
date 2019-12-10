using Serilog;
using System;

namespace LuckyTicket
{
    class LuckyTicketApp
    {
        private const int RANK_DIVIDER = 10;
        private const int MAX_RANK_VALUE = 9;

        private readonly int LAST_TIKET_NUMBER;
        private readonly int COUNT_OF_RANKS;

        public LuckyTicketApp( int countOfRanks)
        {
            COUNT_OF_RANKS = countOfRanks;
            LAST_TIKET_NUMBER = CountLastTicketNumber(countOfRanks);
        }

        public int Run(RunMode runMode)
        {
            int result = 0;

            switch (runMode)
            {
                case LuckyTicket.RunMode.Moskow:

                    LuckyTicketCuonter moskowCounter;
                    moskowCounter = new LuckyTicketCuonter(new MoskowAlgorithm(), COUNT_OF_RANKS);
                    result = moskowCounter.CountLucky(1, LAST_TIKET_NUMBER);
                    break;

                case LuckyTicket.RunMode.Piter:

                    LuckyTicketCuonter piterCounter;
                    piterCounter = new LuckyTicketCuonter(new PiterAlgorithm(), COUNT_OF_RANKS);
                    result = piterCounter.CountLucky(1, LAST_TIKET_NUMBER);
                    break;

                default:

                    Log.Logger.Error($"LuckyTiketApp.Run({runMode}) default:");

                    throw new ArgumentException("Can't switch mode");
            }

            return result;
        }

        private int CountLastTicketNumber (int countOfRanks)
        {
            double result = 0;

            for (double index = 0; index < countOfRanks ; index++)
            {
                result = result + MAX_RANK_VALUE * Math.Pow(RANK_DIVIDER, index);
            }

            return Convert.ToInt32(result);
        }
    }
}
