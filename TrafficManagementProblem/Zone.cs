using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class Zone
    {
        public string Type { get; set; }
        public string Shape { get; set; }
        public int Radius { get; set; }
        public Coordinate StartCoordinates { get; set; }
        public Coordinate EndCoordinates { get; set; }

        public Zone(string type, string shape, Coordinate startCoordinate, Coordinate endCoordinate)
        {
            Type = type;
            Shape = shape;
            StartCoordinates = startCoordinate;
            EndCoordinates = endCoordinate;
        }

        public Zone(string type, string shape, Coordinate centerCoordinate, int radius)
        {
            Type = type;
            Shape = shape;
            Radius = radius;
            CalculateStartAndEndZone(centerCoordinate);
        }

        private void CalculateStartAndEndZone(Coordinate centerCoordinate)
        {
            var x = centerCoordinate.X - Radius;
            var y = centerCoordinate.Y - Radius;
            StartCoordinates = new Coordinate(x, y);
            x = centerCoordinate.X + Radius;
            y = centerCoordinate.Y + Radius;
            EndCoordinates = new Coordinate(x, y);
        }
    }
}
