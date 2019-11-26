using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<Host> lsHosts;
            lsHosts = new List<Host>()
            {
                new Host(1, rand.Next(1,5)),
                new Host(2, rand.Next(1,5)),
                new Host(3, rand.Next(1,5)),
                new Host(4, rand.Next(1,5)),
                new Host(5, rand.Next(1,5))
 };

            foreach (var host in lsHosts)
            {

                GuestRequest gs1 = CreateRandomRequest();
                GuestRequest gs2 = CreateRandomRequest();
                GuestRequest gs3 = CreateRandomRequest();
                switch (rand.Next(1, 4))
                {
                    case 1:
                        host.AssignRequests(gs1);
                        break;
                    case 2:
                        host.AssignRequests(gs1, gs2);
                        break;
                    case 3:
                        host.AssignRequests(gs1, gs2, gs3);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadKey();
        }

        private static GuestRequest CreateRandomRequest()
        {
            Random month = new Random();
            Random day = new Random();
            Random duration = new Random();

            return new GuestRequest(day.Next(1, 29), month.Next(1, 12), duration.Next(2, 10));
        }
    }
}
