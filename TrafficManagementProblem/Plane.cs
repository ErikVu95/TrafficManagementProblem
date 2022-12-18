using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class Plane
    {
        public string Id { get; set; }

        public Coordinate Coordinates;

        public Plane(string id)
        {
            Id = id;
            Coordinates = new Coordinate();
        }
    }
}
