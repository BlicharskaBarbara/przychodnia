using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class BlednyPeselException : Exception
    {
        public BlednyPeselException() : base() { }
        public BlednyPeselException(string message) : base(message) { }
    }
}
