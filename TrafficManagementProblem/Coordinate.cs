using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
