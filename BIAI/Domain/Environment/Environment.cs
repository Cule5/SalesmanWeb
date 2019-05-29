using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Environment
{
    public static class Environment
    {
        public static double MutateRate { set; get; }
        public static int PopulationSize { set; get; }
        public static int CitiesNumber { set; get; }
        public static int Elitism { set; get; }
    }
}
