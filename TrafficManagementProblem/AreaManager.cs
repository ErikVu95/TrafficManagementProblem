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
        private readonly PlaneCreator _planeCreator = new();
        private readonly ParseInfo _parseInfo = new();
        private readonly List<Zone> _zones = new();
        private readonly List<Plane> _planes = new();
        Random _random = new();

        public AreaManager()
        {
            _planes = _planeCreator.Planes;
            _zones = _parseInfo.Zones;
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

        private bool IsInsideZone(Zone zones, Plane plane)
        {
            return (plane.Coordinates.X >= zones.StartCoordinates.X
                    && plane.Coordinates.X <= zones.EndCoordinates.X
                    && plane.Coordinates.Y >= zones.StartCoordinates.Y
                    && plane.Coordinates.Y <= zones.EndCoordinates.Y);
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


