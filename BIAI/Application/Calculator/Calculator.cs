using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Infrastructure;
using Application.ViewModel;


namespace Application.Calculator
{
    
    public class Calculator:ICalculator
    {
        
        private readonly IAlgorithmService _algorithmService = null;

        public Calculator(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }
        

        public async Task<ResultViewModel> RunAlgorithm(AlgorithmViewModel algorithmViewModel)
        {
            await _algorithmService.Execute(algorithmViewModel);
        }
    }
}
