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
        private Path _path = null;
        private Population _population = null;
        
        

        public async Task Execute(FileViewModel fileViewModel)
        {
            await SetCities(fileViewModel);
            _population = Population.RandomizePopulation(_path, Environment.PopulationSize);


        }


        private async Task SetCities(FileViewModel fileViewModel)
        {
            using (Stream stream=fileViewModel.File.OpenReadStream())
            {
                using (StreamReader streamReader=new StreamReader(stream))
                {
                    List<City>cities=new List<City>();
                    string line = null;
                    while ((line= streamReader.ReadLine())!=null)
                    {
                        string[] splitString = line.Split(' ');
                        double paramX = double.Parse(splitString[0]);
                        double paramY = double.Parse(splitString[1]);
                        string cityName = splitString[2];
                        City newCity=new City(cityName,paramX,paramY);
                        _path.Cities.Add(newCity);
                    }
                }
            }
        }
    }
}
