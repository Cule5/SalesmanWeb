using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Environment
{
    public static class Environment
    {
        public static double MutationRate { set; get; } 
        public static int PopulationSize { set; get; } 
        public static int TournamentSize { set; get; }
        public static int CitySize { set; get; }
        public static int GenerationSize { set; get; }
    }
}
