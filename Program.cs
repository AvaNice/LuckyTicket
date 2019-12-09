namespace LuckyTicket
{
    class Program
    {
        private const int COUNT_OF_RANKS = 8;
        private const int LAST_TICKET_NUMBER = 99999999;

        static void Main(string[] args)
        {
            var app = new LuckyTicketApp(LAST_TICKET_NUMBER, COUNT_OF_RANKS);

            app.Start();
        }
    }
}
