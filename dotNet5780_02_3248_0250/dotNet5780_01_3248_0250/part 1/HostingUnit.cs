using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class HostingUnit
    {
        static private int stSerialKey = 0;

        public int _HostingUnitKey;
        public int HostingUnitKey
        {
            get
            {
                return _HostingUnitKey;
            }
            set
            {
                _HostingUnitKey = value;
            }
        }

        private bool[,] diary;

        public HostingUnit() // test
        {
            HostingUnitKey = stSerialKey++;
            diary = new bool[12,31];
        }
    }
}
