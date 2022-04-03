using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class BlednyNumerTelefonuException : Exception
    {
        public BlednyNumerTelefonuException() : base() { }
        public BlednyNumerTelefonuException(string message) : base(message) { }
    }
}
