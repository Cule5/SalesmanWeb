using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Path
{
    class Path
    {
        public IList<City.City> Cities { private set; get; }
        public double Distance { private set; get; }
        public double Fitness { private set; get; }
        private Random Random { set;  get; }

        public Path(List<Domain.City.City>cities)
        {
            Cities = cities;
            Distance = CalculateDistance();
            Fitness = CalculateFitness();
            Random=new Random();

        }

        public Path Shuffle()
        {
            List<City.City> list = new List<City.City>(Cities);
            
            int n = list.Count;

            while (n > 1)
            {
                --n;
                int k = Random.Next(n + 1);
                City.City v = list[k];
                list[k] = list[n];
                list[n] = v;
            }
            return new Path(list);
        }

        public Path Crossover(Path path)
        {
            
            int i = Random.Next(0, path.Cities.Count);
            int j = Random.Next(i, path.Cities.Count);
            List<City.City> rangedList = Cities.ToList().GetRange(i, j - i + 1);
            List<City.City> ms = path.Cities.Except(rangedList).ToList();
            List<City.City> c = ms.Take(i)
                .Concat(rangedList)
                .Concat(ms.Skip(i))
                .ToList();
            return new Path(c);
        }

        public Path Mutate()
        {
            List<City.City> tmpList = new List<City.City>(Cities);

            if (Random.NextDouble() < Environment.Environment.MutateRate)
            {
                int i = Random.Next(0, Cities.Count);
                int j = Random.Next(0, Cities.Count);
                City.City v = tmpList[i];
                tmpList[i] = tmpList[j];
                tmpList[j] = v;
            }

            return new Path(tmpList);
        }

        private double CalculateDistance()
        {
            double result = 0;
            for (int i = 0; i < Cities.Count; ++i)
                result += Cities[i].DistanceToCity(Cities[(i + 1) % Cities.Count]);
            return result;
        }

        private double CalculateFitness()
        {
            return 1 / Distance;
        }
        
    }
}
