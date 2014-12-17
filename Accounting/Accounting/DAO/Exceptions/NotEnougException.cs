using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.DAO
{
    class NotEnougException : Exception
    {
        private string p;

        public NotEnougException(string p)
        {
            // TODO: Complete member initialization
        }
    }
}
