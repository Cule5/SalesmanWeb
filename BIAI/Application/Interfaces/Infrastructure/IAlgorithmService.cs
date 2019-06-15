using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel;

namespace Application.Interfaces.Infrastructure
{
    public interface IAlgorithmService
    {
        ResultViewModel Execute(AlgorithmViewModel algorithmViewModel);
    }
}
