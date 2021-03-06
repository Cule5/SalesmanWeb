﻿using System;
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
        

        public  Task<ResultViewModel> RunAlgorithm(AlgorithmViewModel algorithmViewModel)
        {
            return  Task<ResultViewModel>.Factory.StartNew(() =>_algorithmService.Execute(algorithmViewModel));
        }


    }
}
