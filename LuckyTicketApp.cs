using Serilog;
using System;

namespace LuckyTicket
{
    public class LuckyTicketApp
    {
        private const int RANK_DIVIDER = 10;
      
        private readonly int _lastTicketNumber;
        private readonly int _countOfRanks;

        public LuckyTicketApp( int countOfRanks)
        {
            _countOfRanks = countOfRanks;
            _lastTicketNumber = CountLastTicketNumber(countOfRanks);
        }

        public int Run(RunMode runMode)
        {
            int result = 0;

            switch (runMode)
            {
                case LuckyTicket.RunMode.Moskow:

                    LuckyTicketCuonter moskowCounter;
                    moskowCounter = new LuckyTicketCuonter(new MoskowAlgorithm(), _countOfRanks);
                    result = moskowCounter.CountLucky(1, _lastTicketNumber);
                    break;

                case LuckyTicket.RunMode.Piter:

                    LuckyTicketCuonter piterCounter;
                    piterCounter = new LuckyTicketCuonter(new PiterAlgorithm(), _countOfRanks);
                    result = piterCounter.CountLucky(1, _lastTicketNumber);
                    break;

                default:

                    Log.Logger.Error($"LuckyTiketApp.Run({runMode}) default:");

                    throw new ArgumentException("Can't switch mode");
            }

            return result;
        }

        private int CountLastTicketNumber (int countOfRanks)
        {
            double result = Math.Pow(RANK_DIVIDER, _countOfRanks) - 1;

            return Convert.ToInt32(result);
        }
    }
}
