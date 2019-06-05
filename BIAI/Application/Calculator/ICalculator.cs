using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Calculator
{
    public interface ICalculator
    {
        Task<ResultViewModel> RunAlgorithm(AlgorithmViewModel algorithmViewModel);
    }
}
