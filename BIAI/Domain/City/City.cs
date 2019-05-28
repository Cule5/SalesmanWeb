using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.City
{
    class City
    {
        public string CityName {private set; get; }
        public double ParameterX {private set; get; }
        public double ParameterY {private set; get; }

        public City(string cityName,double parameterX,double parameterY)
        {
            CityName = cityName;
            ParameterX = parameterX;
            ParameterY = parameterY;
        }

        public double DistanceToCity(City city)
        {
            return Math.Sqrt(Math.Pow((city.ParameterX - ParameterX), 2) + Math.Pow((city.ParameterY - ParameterY), 2));
        }

    }
}
