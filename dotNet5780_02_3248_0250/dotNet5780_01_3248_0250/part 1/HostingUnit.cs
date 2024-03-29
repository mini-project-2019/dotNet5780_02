﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    class HostingUnit : IComparable
    {
        // A static variable that presents the number of total instances of HostingUnit
        static private long stSerialKey = 0;

        private long _HostingUnitKey;
        public long HostingUnitKey
        {
            get
            {
                return _HostingUnitKey;
            }
            private set
            {
                _HostingUnitKey = value;
            }
        }


        // Dr Visen told us we can make Diary this way
        public bool[][] Diary = new bool[12][];

        public HostingUnit()
        {
            HostingUnitKey = stSerialKey++;

            // Visen agreed this
            Diary[0] = new bool[31];
            Diary[2] = new bool[31];
            Diary[4] = new bool[31];
            Diary[6] = new bool[31];
            Diary[7] = new bool[31];
            Diary[9] = new bool[31];
            Diary[11] = new bool[31];
            Diary[1] = new bool[29];
            Diary[3] = new bool[30];
            Diary[5] = new bool[30];
            Diary[8] = new bool[30];
            Diary[10] = new bool[30];
        }




        public bool approveRequest(GuestRequest GR)
        {

            for (int i = 0; i < GR.getDuration() - 1; i++)
            // Signs nights and not days
            {
                if (Diary[GR.EntryDate.AddDays(i).Month - 1][GR.EntryDate.AddDays(i).Day - 1])
                // If there is at least one occupied day then the order rejected
                /* Decreases the parameters in 1 to fix from ranges 
                   of [1, 31], [1, 12] to [0, 30], [0, 11]
                */
                {
                    GR.IsApproved = false;
                    return false;
                }
            }

            for (int i = 0; i < GR.getDuration() - 1; i++)
            // Signs the new occupied days
            /* Decreases the parameters in 1 to fix from ranges 
               of [1, 31], [1, 12] to [0, 30], [0, 11]
            */
            {
                Diary[GR.EntryDate.AddDays(i).Month - 1][GR.EntryDate.AddDays(i).Day - 1] = true;
            }

            GR.IsApproved = true;
            return true;
        }





        public int GetAnnualBusyDays()
        // I made this method's declaration because I have to use it in Host
        {
            int count = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < Diary[i].Length; j++)
                {
                    if (Diary[i][j])
                    {
                        while (Diary[i][j])
                        {
                            count++;
                            int tmpMonth = i;
                            i = getNewMonth(j, i, 1);
                            j = getNewDay(j, tmpMonth, 1);
                        }

                        /* In any sequence of vacations the last day is not 
                        counted in the loop because of it's false in the array */
                        count += 1;
                    }
                }
            }
            return count;
        }

        public float GetAnnualBusyPercentage()
        {
            return (float)(GetAnnualBusyDays() / 366.0);
        }




        public override string ToString()
        {
            return HostingUnitKey + ": " + occupiedDays_ToString();
        }

        private string occupiedDays_ToString()
        {
            string occupiedDays = "";
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < Diary[i].Length; j++)
                {
                    if (Diary[i][j])
                    {
                        int startMonth = i, startDay = j;
                        while (Diary[i][j] || // Regular situation
                                              /* Makes sure that when two vacations are overlapping 
                                                 but not cut each other, the vacations are considered as one vacation
                                              */
                            (!Diary[i][j] && Diary[getNewMonth(j, i, 1)][getNewDay(j, i, 1)]))
                        {
                            // Increases the end date of the vacation in 1
                            int tmpMonth = i;
                            i = getNewMonth(j, i, 1);
                            j = getNewDay(j, tmpMonth, 1);
                        }

                        occupiedDays += (startDay + 1) + "/" + (startMonth + 1) +
                                        " - " +
                                        (j + 1) + "/" + (i + 1) +
                                        ", ";
                        /* Increase the parameters in 1 to fix from ranges 
                           of [0, 30], [0, 11] to [1, 31], [1, 12]
                        */
                    }
                }
            }

            // Deletes the last 2 characters - ", "
            return occupiedDays.Substring(0, occupiedDays.Length - 2);
        }







        private int getNewMonth(int day, int month, int duration)
        // Returns the month of the last day of the request in range of [0, 30]
        {
            return month + (day + duration) / Diary[month].Length;
        }

        private int getNewDay(int day, int month, int duration)
        // Returns the location in month of the last day of the request in range of [0, 11]
        {
            return ((day + duration) % Diary[month].Length);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            HostingUnit otherHostingUnit = obj as HostingUnit;
            if (otherHostingUnit != null)
            {
                return this.GetAnnualBusyDays().CompareTo(otherHostingUnit.GetAnnualBusyDays());
            }
            else
            {
                throw new ArgumentException("Object is not a HostingUnit");
            }
        }
    }
}