using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Population
{
    class Population
    {
        public List<Domain.Path.Path> Paths {private set; get; }
        public double MaxFitness {private set; get; }

        public Population(List<Domain.Path.Path>paths)
        {
            Paths = paths;
            
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
    }
}
