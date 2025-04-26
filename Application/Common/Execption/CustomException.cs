using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Execption
{
    public class CustomException : Exception
    {
        public CustomException(string error):base(error) 
        {
        }

    }
}
