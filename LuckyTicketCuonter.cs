namespace LuckyTicket
{
    class LuckyTicketCuonter
    {
        private readonly int COUNT_OF_RANKS;

        private ITicketAlgorithm _algorithm;

        public LuckyTicketCuonter(ITicketAlgorithm algorithm, int countOfRanks)
        {
            _algorithm = algorithm;
            COUNT_OF_RANKS = countOfRanks;
        }

        public int CountLucky(int minValue, int maxValue)
        {
            int counter = 0;

            for (int index = minValue; index <= maxValue; index++)
            {
                if (_algorithm.IsLucky(new Ticket(COUNT_OF_RANKS, index))) 
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
