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

        public override string ToString()
        {
            string hostToString = "Host ID: " + ID + "\n";
            
            foreach (HostingUnit hostingUnit in HostingUnitCollection)
            {
                hostToString += hostingUnit + "\n";
            }
            return hostToString;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            int hostingUnitKey = -1;
            foreach (HostingUnit hostingUnit in HostingUnitCollection)
            {
                if (hostingUnit.approveRequest(guestReq))
                {
                    hostingUnitKey = hostingUnit.HostingUnitKey;
                    break;
                }
                
            }
            return hostingUnitKey;
        }

        public int GetHostAnnualBusyDays()
        {
            int annualBusyDays = 0;
            foreach (HostingUnit hostingUnit in HostingUnitCollection)
            {
                annualBusyDays += hostingUnit.GetAnnualBusyDays();
            }
            return annualBusyDays;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }
    }
}
