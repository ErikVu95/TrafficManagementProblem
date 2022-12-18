using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class ParseInfo
    {
        private static readonly string FileName = "MapData.txt";
        private string[] _map = File.ReadAllLines(FileName);
        public List<Zone> Zones = new();

        public ParseInfo()
        {
            ParseLine(_map);
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

            var startIndex = split[3].IndexOf('(') + 1;
            var lastBeforeComma = split[3].IndexOf(',') - startIndex;
            var commaIndex = split[3].IndexOf(',') + 1;
            var lastIndex = split[3].LastIndexOf(')') - commaIndex;

            var radius = Convert.ToInt32(split[4]);

            var coordinate1 = Convert.ToInt32(split[3].Substring(startIndex, lastBeforeComma));
            var coordinate2 = Convert.ToInt32(split[3].Substring(commaIndex, lastIndex));

            Zones.Add(new Zone(zoneType, shape, new Coordinate(coordinate1, coordinate2), radius));
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

            Zones.Add(new(zoneType, shape, new Coordinate(coordinate1, coordinate2), new Coordinate(coordinate3, coordinate4)));
        }
    }
}
