namespace LuckyTicket
{
    public class Ticket : ITicket
    {
        private const int RANK_DIVIDER = 10;

        private int[] _splitedNumber;

        public int CountOfRanks { get; }

        public Ticket(int countOfRanks, int number)
        {
            CountOfRanks = countOfRanks;
            _splitedNumber = SplitNumber(number);
        }

        public int this[int index]
        {
            get
            {
                return _splitedNumber[index];
            }
        }

        private int[] SplitNumber(int number)
        {
            var splitedNumber = new int[CountOfRanks];

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
    }
}
