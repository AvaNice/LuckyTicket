using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket
{
    class MoskowAlgorithm : ITicketAlgorithm
    {
        private const int RANK_DIVIDER = 10;
        private readonly int COUNT_OF_RANKS;

        public MoskowAlgorithm(int countOfRanks)
        {
            COUNT_OF_RANKS = countOfRanks;
        }
        public bool IsLucky(int number)
        {
            int sumFirstHalf;
            int sumSecondHalf;

            var splitedNumber = new int[COUNT_OF_RANKS];

            splitedNumber = SplitNumber(number);

            sumFirstHalf = CountHalf(splitedNumber, 0, COUNT_OF_RANKS / 2);
            sumSecondHalf = CountHalf(splitedNumber, COUNT_OF_RANKS / 2, COUNT_OF_RANKS);

            if (sumFirstHalf == sumSecondHalf)
            {
                return true;
            }

            return false;
        }

        private int[] SplitNumber(int number)
        {
            var splitedNumber = new int[COUNT_OF_RANKS];

            int buff = splitedNumber.Length - 1;

            while ( number > RANK_DIVIDER - 1)
            {
                splitedNumber[buff] = number % RANK_DIVIDER;
                number = number / RANK_DIVIDER;
                buff--;
            }

            splitedNumber[buff] = number;

            return splitedNumber;
        }

        private int CountHalf(int[] splitedNumber, int from, int to)
        {
            int result = 0;

            for (int index = from; index < to; index++)
            {
                result += splitedNumber[index];
            }

            return result;
        }
    }
}
