using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Population
{
    class Population
    {
        public List<Domain.Path.Path> Paths { set; get; }
        public double MaxFitness { set; get; }
    }
}
