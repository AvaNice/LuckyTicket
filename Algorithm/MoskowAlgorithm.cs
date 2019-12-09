using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket
{
    class MoskowAlgorithm : ITicketAlgorithm
    {
        private const int BISECTOR = 2;

        private ITicket _ticket;

        public bool IsLucky(ITicket ticket)
        {
            _ticket = ticket;

            int sumFirstHalf;
            int sumSecondHalf;
            int countOfRanks;

            countOfRanks = _ticket.CountOfRanks;

            sumFirstHalf = CountHalf(0, countOfRanks / BISECTOR);
            sumSecondHalf = CountHalf(countOfRanks / BISECTOR, countOfRanks);

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
