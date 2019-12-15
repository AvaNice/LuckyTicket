namespace LuckyTicket
{
    public class MoskowAlgorithm : ITicketAlgorithm
    {
        private ITicket _ticket;

        public bool IsLucky(ITicket ticket)
        {
            _ticket = ticket;

            int sumFirstHalf;
            int sumSecondHalf;
            int countOfRanks;

            countOfRanks = _ticket.CountOfRanks;

            sumFirstHalf = CountHalf(0, countOfRanks >> 1);
            sumSecondHalf = CountHalf(countOfRanks >> 1, countOfRanks);

            if (sumFirstHalf == sumSecondHalf)
            {
                return true;
            }

            return false;
        }

        private int CountHalf(int from, int to)
        {
            int result = 0;

            for (int index = from; index < to; index++)
            {
                result += _ticket[index];
            }

            return result;
        }
    }
}
