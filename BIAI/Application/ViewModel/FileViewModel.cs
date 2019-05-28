using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel
{
    public class FileViewModel
    {
        public IFormFile File { set; get; }
    }
}
