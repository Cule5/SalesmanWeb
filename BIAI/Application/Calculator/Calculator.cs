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
        private  Stream _stream = null;
        private readonly IAlgorithmService _algorithmService = null;

        Calculator(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }
        

        public async Task RunAlgorithm(FileViewModel fileViewModel)
        {
            await _algorithmService.Execute(fileViewModel);
        }
    }
}
