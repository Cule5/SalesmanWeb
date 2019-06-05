using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Path
{
    public class Path
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
            
            var counter = list.Count;

            while (counter > 1)
            {
                --counter;
                var k = Random.Next(counter + 1);
                var tmpCity = list[k];
                list[k] = list[counter];
                list[counter] = tmpCity;
            }
            return new Path(list);
        }

        public Domain.Path.Path Crossover(Domain.Path.Path path)
        {
            int firstIndex = Random.Next(0, path.Cities.Count);
            int secondIndex = Random.Next(firstIndex, path.Cities.Count);
            List<City.City> rangedList = this.Cities.ToList().GetRange(firstIndex, secondIndex - firstIndex + 1);
            List<City.City> ms = path.Cities.Except(rangedList).ToList();
            List<City.City> resultList = ms.Take(firstIndex)
                .Concat(rangedList)
                .Concat(ms.Skip(firstIndex))
                .ToList();
            return new Path(resultList);
        }


        public void Mutate()
        {
            if (Random.NextDouble() < Environment.Environment.MutationRate)
            {
                var i = Random.Next(0, Cities.Count);
                var j = Random.Next(0, Cities.Count);
                var city = Cities[i];
                Cities[i] = Cities[j];
                Cities[j] = city;
            }
        }

        private double CalculateDistance()
        {
            var result = 0.0;
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
