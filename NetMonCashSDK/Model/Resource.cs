using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMonCashSDK.Model
{
    public class Resource
    {
        public long timestamp { get; set; }
        public String status { get; set; }
        public String path { get; set; }
        public String error { get; set; }
        public String message { get; set; }
        public String error_description { get; set; }
    }
}
