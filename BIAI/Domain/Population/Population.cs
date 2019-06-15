using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Population
{
    public class Population
    {
        public List<Path.Path> Paths { set; get; }
        public double MaxFitness {private set; get; }
        private Random Random { set; get; }


        public Population(List<Path.Path>paths)
        {
            this.Paths = paths;
            this.MaxFitness = CalculateMaxFitness();
            this.Random=new Random();
        }

        public static Population CreatePopulation(Path.Path path, int populationSize)
        {
            var pathList = new List<Path.Path>();
            for (int i = 0; i < populationSize; ++i)
                pathList.Add(path.Shuffle());
            return new Population(pathList);
        }

        private double CalculateMaxFitness()
        {
            return Paths.Max(path => path.Fitness);
        }

        

        public Path.Path FindBestPath()
        {
            foreach (var path in this.Paths)
            {
                if (path.Fitness.Equals(MaxFitness))
                    return path;
            }
            return null;
        }


        private  Path.Path TournamentSelection()
        {
            var pathList=new List<Path.Path>();
            for (int i = 0; i < Environment.Environment.TournamentSize; ++i)
            {
                var randomIndex = (int)(Random.NextDouble() * this.Paths.Count);
               
                pathList.Add(this.Paths[randomIndex]);
                
            }
            var tmpPopulation=new Population(pathList);
            var fittestPath= tmpPopulation.FindBestPath();
            return fittestPath;
        }

        public Population EvolvePopulation()
        {
            var pathList=new List<Path.Path>();
            for (int i = 0; i < Environment.Environment.PopulationSize; ++i)
            {
                var firstPath = this.TournamentSelection();
                var secondPath = this.TournamentSelection();
                var child = firstPath.Crossover(secondPath);
                child.Mutate();
                pathList.Add(child);
            }

            
            return new Population(pathList);
        }
    }
}
