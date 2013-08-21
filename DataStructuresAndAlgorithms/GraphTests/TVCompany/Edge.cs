using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVCompany
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int startHouse, int endHouse, int distance)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.Distance = distance;
        }

        public int StartHouse { get; set; }

        public int EndHouse { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Edge otherConnection)
        {
            int distanceDifference = this.Distance.CompareTo(otherConnection.Distance);

            if (distanceDifference == 0)
            {
                return this.StartHouse.CompareTo(otherConnection.StartHouse);
            }

            return distanceDifference;
        }

        public override string ToString()
        {
            string output = string.Format("From house {0} to house {1} -> distance = {2}", this.StartHouse, this.EndHouse, this.Distance);

            return output;
        }
    }
}
