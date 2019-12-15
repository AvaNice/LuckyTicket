namespace LuckyTicket
{
    public class LuckyTicketCuonter
    {
        private readonly int _countOfRanks;

        private ITicketAlgorithm _algorithm;

        public LuckyTicketCuonter(ITicketAlgorithm algorithm, int countOfRanks)
        {
            _algorithm = algorithm;
            _countOfRanks = countOfRanks;
        }

        public int CountLucky(int minValue, int maxValue)
        {
            int counter = 0;

            for (int index = minValue; index <= maxValue; index++)
            {
                if (_algorithm.IsLucky(new Ticket(_countOfRanks, index))) 
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
