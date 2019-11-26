using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class Host //: IEnumerable<HostingUnit>
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
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                unit.reset();
            }
        }

        public override string ToString()
        {
            string hostToString = "Host ID: " + ID + "\n";
            
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                hostToString += unit + "\n";
            }
            return hostToString;
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            int hostingUnitKey = -1;
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                if (unit.approveRequest(guestReq))
                {
                    hostingUnitKey = unit.HostingUnitKey;
                    break;
                }
                
            }
            return hostingUnitKey;
        }

        public int GetHostAnnualBusyDays()
        {
            int annualBusyDays = 0;
            foreach (HostingUnit unit in HostingUnitCollection)
            {
                annualBusyDays += unit.GetAnnualBusyDays();
            }
            return annualBusyDays;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest[] requests)
        {
            bool succeededAll = true;

            foreach (GuestRequest request in requests)
            {
                if(SubmitRequest(request) == -1)
                {
                    succeededAll = false;
                }
            }
            return succeededAll;
        }

        public HostingUnit this[int unitKey]
        {
            get
            {
                foreach (HostingUnit unit in HostingUnitCollection)
                {
                    if (unitKey == unit.HostingUnitKey)
                    {
                        return unit;
                    }
                }
                return null;
            }
        }

        /*public IEnumerator<HostingUnit> GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/
    }
}
