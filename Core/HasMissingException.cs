using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolBox.Core
{
    public class HasMissingException : Exception
    {
        public HasMissingException(string message) : base(message)
        {
        }
    }
}
