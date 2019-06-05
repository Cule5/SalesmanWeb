using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Environment
{
    public static class Environment
    {
        public static double MutationRate { set; get; } = 0.0015;
        public static int PopulationSize { set; get; } = 10;
        public static int TournamentSize { set; get; } = 5;
        public static int CitySize { set; get; }
        public static bool Elitism { set; get; } = true;
    }
}
