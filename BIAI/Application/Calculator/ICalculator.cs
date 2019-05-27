using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calculator
{
    public interface ICalculator
    {
        void LoadStream(Stream stream);
        Task RunAlgorithm();
    }
}
