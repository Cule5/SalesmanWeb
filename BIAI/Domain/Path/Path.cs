using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Path
{
    class Path
    {
        public IList<City.City> Cities { private set; get; }
        public double Distance { private set; get; }
        public double Fitness { private set; get; }

        public Path(List<Domain.City.City>cities)
        {
            Cities = cities;
            Distance = CalculateDistance();
            Fitness = CalculateFitness();
        }

        public Path Shuffle()
        {
            List<City.City> list = new List<City.City>(Cities);
            Random random=new Random();
            int n = list.Count;

            while (n > 1)
            {
                --n;
                int k = random.Next(n + 1);
                City.City v = list[k];
                list[k] = list[n];
                list[n] = v;
            }
            return new Path(list);
        }


        private double CalculateDistance()
        {
            double result = 0;

            return result;
        }

        private double CalculateFitness()
        {
            double result = 0;

            return result;
        }
        
    }
}
