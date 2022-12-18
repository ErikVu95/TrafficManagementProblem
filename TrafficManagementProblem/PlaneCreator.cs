using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementProblem
{
    internal class PlaneCreator
    {
        public List<Plane> Planes = new();

        public PlaneCreator()
        {
            CreatePlanes();
        }

        private char RandomChar()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return chars[random.Next(0, chars.Length)];
        }

        private char RandomNumber()
        {
            Random random = new Random();
            string numbers = "1234567890";
            return numbers[random.Next(0, numbers.Length)];
        }

        private void CreatePlanes()
        {
            for (int index = 0; index < 10; index++)
            {
                string planeId = "";

                for (int i = 0; i < 2; i++)
                {
                    planeId += RandomChar();
                }
                for (int i = 0; i < 4; i++)
                {
                    planeId += RandomNumber();
                }

                Planes.Add(new(planeId));
            }
        }
    }
}
