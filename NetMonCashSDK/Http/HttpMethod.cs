using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Http
{
    /// <summary>
    /// Defines supported HTTP methods.
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// HTTP GET.
        /// </summary>
        Get,

        /// <summary>
        /// HTTP POST.
        /// </summary>
        Post,

        /// <summary>
        /// HTTP PUT.
        /// </summary>
        Put,

        /// <summary>
        /// HTTP PATCH.
        /// </summary>
        Patch,

        /// <summary>
        /// HTTP DELETE.
        /// </summary>
        Delete
    }
}
