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
        
        

        public async Task<ResultViewModel> Execute(AlgorithmViewModel algorithmViewModel)
        {
            var cities = await SetCities(algorithmViewModel);
            Environment.CitySize = cities.Count;
            _population=Population.CreatePopulation(new Path(cities),Environment.PopulationSize);
            for (int i = 0; i < 5; ++i)
            {
                _population = _population.EvolvePopulation();
            }

            var result = _population.FindBestPath();
        }

        private async Task<List<City>> SetCities(AlgorithmViewModel algorithmViewModel)
        {
            var resultList=new List<City>();
            using (Stream stream=algorithmViewModel.File.OpenReadStream())
            {
                using (StreamReader streamReader=new StreamReader(stream))
                {
                    string line = null;
                    while ((line= streamReader.ReadLine())!=null)
                    {
                        string[] splitString = line.Split(' ');
                        double paramX = double.Parse(splitString[0]);
                        double paramY = double.Parse(splitString[1]);
                        
                        City newCity=new City(paramX,paramY);
                        resultList.Add(newCity);
                    }
                }
            }
            return resultList;
        }
    }
}
