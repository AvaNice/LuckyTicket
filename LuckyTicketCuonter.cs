namespace LuckyTicket
{
    class LuckyTicketCuonter
    {
        ITicketAlgorithm _algorithm;
        public LuckyTicketCuonter(ITicketAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public int CountLucky(int minValue, int maxValue)
        {
            int counter = 0;

            for (int index = minValue; index <= maxValue; index++)
            {
                if (_algorithm.IsLucky(index))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
