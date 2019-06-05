using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel
{
    public class AlgorithmViewModel
    {
        [Required(ErrorMessage = "You should choose file with input data ")]
        public IFormFile File { set; get; }

        [Required(ErrorMessage = "You should set population size")]
        public int PopulationSize { set; get; }

        [Required(ErrorMessage = "You should set generation size")]
        public int GenerationSize { set;get; }

        [Required(ErrorMessage = "You should set tournament size")]
        public int TournamentSize { set; get; }

        [Required(ErrorMessage = "You should set mutation rate")]
        public double MutationRate { set; get; }

    }
}
