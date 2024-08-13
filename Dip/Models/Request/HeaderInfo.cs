using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Models.Request
{
    internal class HeaderInfo
    {
        public string auth_token { get; set; }
        public string crft_token { get; set; }
        public string cookie { get; set; }
    }
}
