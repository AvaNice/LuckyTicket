using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket
{
    interface ITicket
    {
        int CountOfRanks { get; }

        int this[int index] { get; }
    }
}
