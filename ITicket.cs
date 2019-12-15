namespace LuckyTicket
{
    public interface ITicket
    {
        int CountOfRanks { get; }

        int this[int index] { get; }
    }
}
