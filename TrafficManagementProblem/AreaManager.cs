using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class AreaManager
    {
        private static readonly string FileName = "MapData.txt";
        private string[] _map = File.ReadAllLines(FileName);
        private readonly PlaneCreator _planeCreator = new();
        private readonly List<Zone> _zones = new();
        private readonly List<Plane> _planes = new();
        Random _random = new();

        public AreaManager()
        {
            _planes = _planeCreator.Planes;
            ParseLine(_map);
            Initialize();
        }

        private void Initialize()
        {
            while (true)
            {
                UpdatePlaneLocations();
                UpdatePlaneCoordinates();
                if (_planes.Count is 0) return;
            }
        }

        private void ParseLine(string[] args)
        {
            foreach (string line in args)
            {
                if (line.Contains("circle"))
                {
                    ParseCircle(line);
                }
                else if (line.Contains("rectangle"))
                {
                    ParseRectangle(line);
                }
            }
        }

        private void ParseCircle(string line)
        {
            var split = line.Split(' ');
            var zoneType = split[0];
            var shape = split[1];

            var startindex = split[3].IndexOf('(') + 1;
            var lastBeforeComma3 = split[3].IndexOf(',') - startindex;
            var commaindex3 = split[3].IndexOf(',') + 1;
            var lastindex3 = split[3].LastIndexOf(')') - commaindex3;

            var radius = Convert.ToInt32(split[4]);

            var coordinate1 = Convert.ToInt32(split[3].Substring(startindex, lastBeforeComma3));
            var coordinate2 = Convert.ToInt32(split[3].Substring(commaindex3, lastindex3));

            _zones.Add(new Zone(zoneType, shape, new Coordinate(coordinate1, coordinate2), radius));
        }

        private void ParseRectangle(string line)
        {
            var split = line.Split(' ');
            var zoneType = split[0];
            var shape = split[1];

            var startindex = split[3].IndexOf('(') + 1;
            var lastBeforeComma3 = split[3].IndexOf(',') - startindex;
            var lastBeforeComma4 = split[4].IndexOf(',') - startindex;
            var commaindex3 = split[3].IndexOf(',') + 1;
            var commaindex4 = split[4].IndexOf(',') + 1;
            var lastindex3 = split[3].LastIndexOf(')') - commaindex3;
            var lastindex4 = split[4].LastIndexOf(')') - commaindex4;

            var coordinate1 = Convert.ToInt32(split[3].Substring(startindex, lastBeforeComma3));
            var coordinate2 = Convert.ToInt32(split[3].Substring(commaindex3, lastindex3));
            var coordinate3 = Convert.ToInt32(split[4].Substring(startindex, lastBeforeComma4));
            var coordinate4 = Convert.ToInt32(split[4].Substring(commaindex4, lastindex4));

            _zones.Add(new(zoneType, shape, new Coordinate(coordinate1, coordinate2), new Coordinate(coordinate3, coordinate4)));
        }

        private void UpdatePlaneLocations()
        {
            Console.Clear();
            var fireZone = _zones.FirstOrDefault(x => x.Type == "fire");
            var warningZone = _zones.FirstOrDefault(x => x.Type == "warn");
            var safeZone = _zones.FirstOrDefault(x => x.Type == "safe");
            List<Plane> deadPlanes = new();
            PrintPlanes();

            foreach (var plane in _planes)
            {
                //FireZone
                if (IsInsideZone(fireZone, plane) && !IsInsideZone(safeZone, plane))
                {
                    Console.WriteLine($"Shooting {plane.Id} at ({plane.Coordinates.X},{plane.Coordinates.Y}) ");
                    deadPlanes.Add(plane);
                }

                //WarningZone
                else if (IsInsideZone(warningZone, plane) && !IsInsideZone(safeZone, plane))
                {
                    Console.WriteLine($"Warning {plane.Id}");
                }
            }
            _planes.RemoveAll(x => deadPlanes.Contains(x));
            Thread.Sleep(1000);
        }

        private bool IsInsideZone(Zone zones, Plane plane)
        {
            return (plane.Coordinates.X >= zones.StartCoordinates.X
                    && plane.Coordinates.X <= zones.EndCoordinates.X
                    && plane.Coordinates.Y >= zones.StartCoordinates.Y
                    && plane.Coordinates.Y <= zones.EndCoordinates.Y);
        }

        private void UpdatePlaneCoordinates()
        {
            foreach (var plane in _planes)
            {
                var updateX = _random.Next(-1, 2);
                var updateY = _random.Next(-1, 2);
                plane.Coordinates.X += updateX;
                plane.Coordinates.Y += updateY;
            }
        }

        private void PrintPlanes()
        {
            foreach (var plane in _planes)
            {
                Console.Write($"{plane.Id}" + $"({plane.Coordinates.X},{plane.Coordinates.Y}) ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}


