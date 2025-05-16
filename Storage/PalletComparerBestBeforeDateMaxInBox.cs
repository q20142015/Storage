using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    internal class PalletComparerBestBeforeDateMaxInBox : IComparer<Pallet>
    {
        public int Compare(Pallet p1, Pallet p2)
        {
            if (p1.GetMaxDateInBox() > p2.GetMaxDateInBox())
            { return 1; }
            else if (p1.GetMaxDateInBox() < p2.GetMaxDateInBox())
            { return -1; }
            else
            {        
                return 0; 
            }
        }
    }
}
