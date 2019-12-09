namespace LuckyTicket
{
    class PiterAlgorithm : ITicketAlgorithm
    {
        private const int RANK_DIVIDER = 10;
        private readonly int COUNT_OF_RANKS;

        public PiterAlgorithm(int countOfRanks)
        {
            COUNT_OF_RANKS = countOfRanks;
        }
        public bool IsLucky(int number)
        {
            int sumOfEven;
            int sumOfOdd;

            var splitedNumber = new int[COUNT_OF_RANKS];

            splitedNumber = SplitNumber(number);

            sumOfEven = Count(splitedNumber, true);
            sumOfOdd = Count(splitedNumber, false);

            if (sumOfEven == sumOfOdd)
            {
                return true;
            }

            return false;
        }

        private int[] SplitNumber(int number)
        {
            var splitedNumber = new int[COUNT_OF_RANKS];

            int buff = splitedNumber.Length - 1;

            while (number > RANK_DIVIDER - 1)
            {
                splitedNumber[buff] = number % RANK_DIVIDER;
                number = number / RANK_DIVIDER;
                buff--;
            }

            splitedNumber[buff] = number;

            return splitedNumber;
        }

        private int Count(int[] splitedNumber, bool countEven)
        {
            int sum = 0;
            int from = 0;

            if(countEven)
            {
                from = 1;
            }

            for (int index = from; index < splitedNumber.Length; index+=2)
            {
                sum += splitedNumber[index];
            }

            return sum;
        }
    }
}
