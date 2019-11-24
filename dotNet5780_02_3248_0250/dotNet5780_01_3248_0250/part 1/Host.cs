using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class Host
    {
        private int ID;
        private List<HostingUnit> _HostingUnitCollection;
        public List<HostingUnit> HostingUnitCollection
        {
            get
            {
                return _HostingUnitCollection;
            }
            private set
            {
                _HostingUnitCollection = new List<HostingUnit>(value);
            }
        }

        public Host(int ID, List<HostingUnit> hostingUnits)
        {
            this.ID = ID;
            HostingUnitCollection = hostingUnits;
            foreach (HostingUnit hostingUnit in HostingUnitCollection)
            {
                hostingUnit.reset();
            }
        }


    }
}
