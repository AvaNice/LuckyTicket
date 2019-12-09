namespace LuckyTicket
{
    class PiterAlgorithm : ITicketAlgorithm
    {
        private const int STEP_FOR_EVEN = 2;

        private ITicket _ticket;

        public bool IsLucky(ITicket ticket)
        {
            _ticket = ticket;

            int sumOfEven;
            int sumOfOdd;

            sumOfEven = Count(true);
            sumOfOdd = Count(false);

            if (sumOfEven == sumOfOdd)
            {
                return true;
            }

            return false;
        }

        private int Count(bool countEven)
        {
            int sum = 0;
            int from = 0;

            if (countEven)
            {
                from = 1;
            }

            for (int index = from; index < _ticket.CountOfRanks; index += STEP_FOR_EVEN)
            {
                sum += _ticket[index];
            }

            return sum;
        }
    }
}
