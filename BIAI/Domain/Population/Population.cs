using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Population
{
    public class Population
    {
        public List<Path.Path> Paths {private set; get; }
        public double MaxFitness {private set; get; }

        public Population(List<Path.Path>paths)
        {
            Paths = paths;
            MaxFitness = CalculateMaxFitness();
        }

        private double CalculateMaxFitness()
        {
            return Paths.Max(path => path.Fitness);
        }

        public Path.Path FindBestPath()
        {
            foreach (Path.Path path in Paths)
            {
                if (path.Fitness.Equals(MaxFitness))
                    return path;
            }
            return null;
        }

        public static Population RandomizePopulation(Path.Path path,int populationSize)
        {
            List<Path.Path> pathList = new List<Path.Path>();
            for (int i = 0; i < populationSize; ++i)
                pathList.Add(path.Shuffle());
            return new Population(pathList);
        }
       
    }
}
