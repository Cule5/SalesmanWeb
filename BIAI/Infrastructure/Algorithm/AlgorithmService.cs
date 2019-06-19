using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Infrastructure;
using Application.ViewModel;
using Domain.City;
using Path= Domain.Path.Path;
using Domain.Population;
using Domain.Environment;
using Environment = Domain.Environment.Environment;



namespace Infrastructure.Algorithm
{
    public class AlgorithmService:IAlgorithmService
    {
        
        private Population _population = null;
        
        

        public ResultViewModel Execute(AlgorithmViewModel algorithmViewModel)
        {
            var cities = SetCities(algorithmViewModel);
            Environment.CitySize = cities.Count;
            Environment.MutationRate = algorithmViewModel.MutationRate;
            Environment.PopulationSize = algorithmViewModel.PopulationSize;
            Environment.TournamentSize = algorithmViewModel.TournamentSize;
            Environment.GenerationSize = algorithmViewModel.GenerationSize;
            _population=Population.CreatePopulation(new Path(cities),Environment.PopulationSize);
            for (int i = 0; i < Environment.GenerationSize; ++i)
            {
                _population = _population.EvolvePopulation();
            }

            var bestPath = _population.FindBestPath();
            var result=new ResultViewModel(){BestPath =bestPath };
            return result;
        }
        

        private List<City> SetCities(AlgorithmViewModel algorithmViewModel)
        {
            var resultList=new List<City>();
            using (Stream stream=algorithmViewModel.File.OpenReadStream())
            {
                using (StreamReader streamReader=new StreamReader(stream))
                {
                    string line = null;
                    while ((line= streamReader.ReadLine())!=null)
                    {
                        var splitString = line.Split(' ');
                        var paramX = double.Parse(splitString[0]);
                        var paramY = double.Parse(splitString[1]);
                        
                        var newCity=new City(paramX,paramY);
                        resultList.Add(newCity);
                    }
                }
            }
            return resultList;
        }
    }
}
