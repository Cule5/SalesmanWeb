using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Infrastructure;

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
        
        public void LoadStream(Stream stream)
        {
            _stream = stream;
        }

        public async Task RunAlgorithm()
        {

        }
    }
}
