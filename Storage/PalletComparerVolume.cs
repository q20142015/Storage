using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Storage
{
    internal class PalletComparerVolume : IComparer<Pallet>
    {
        public int Compare(Pallet p1, Pallet p2) 
        {
            if (p1.PalletGetVolune() > p2.PalletGetVolune())
            { return 1; }
            else if (p1.PalletGetVolune() < p2.PalletGetVolune())
            { return -1; }
            else
            { return 0;  }
        }
    }
}
