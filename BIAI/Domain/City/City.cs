using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.City
{
    public class City
    {
        public double ParameterX {private set; get; }
        public double ParameterY {private set; get; }

        public City(double parameterX,double parameterY)
        {
            ParameterX = parameterX;
            ParameterY = parameterY;
        }

        public double DistanceToCity(City city)
        {
            return Math.Sqrt(Math.Pow((city.ParameterX - ParameterX), 2) + Math.Pow((city.ParameterY - ParameterY), 2));
        }

        public override string ToString()
        {
            var resultString = $"{ParameterX}, {ParameterY}";
            return resultString;
        }
    }
}
