using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    internal class PalletComparerBestBeforeDate : IComparer<Pallet>
    {
        public int Compare(Pallet p1, Pallet p2)
        {
            if (p1.BestBeforeDate > p2.BestBeforeDate)
            { return 1; }
            else if (p1.BestBeforeDate < p2.BestBeforeDate)
            { return -1; }
            else
            {
                if (p1.Weight > p2.Weight)
                { return 1; }
                else if (p1.Weight < p2.Weight)
                { return -1; }
                else
                { return 0; }
            }
        }
    }
}
