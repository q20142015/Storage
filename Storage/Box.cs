using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Storage
{
    internal class Box : StorageObject
    {
        public bool BestBeforeDateReally { get; set; }

        DateOnly bestBeforeDate;
        public override DateOnly BestBeforeDate
        {
            get
            {
                if (BestBeforeDateReally) { return bestBeforeDate; }
                else { return bestBeforeDate.AddDays(100); }
            }
            set
            {
                bestBeforeDate = value;
            }
        }
    }
}
