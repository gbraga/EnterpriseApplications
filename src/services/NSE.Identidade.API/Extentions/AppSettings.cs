using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Identidade.API.Extentions
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int ExpirationHours { get; set; }

        public string Issuer { get; set; }

        public string ValidOn { get; set; }
    }
}
