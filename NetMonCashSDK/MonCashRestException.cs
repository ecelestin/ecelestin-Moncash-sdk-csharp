using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK
{
    class MonCashRestException: Exception
    {
        /// <inheritdoc />
        public MonCashRestException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public MonCashRestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
