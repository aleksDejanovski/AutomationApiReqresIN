using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HttpApiTest.GetEndpoint
{
    public class ModelGet
    {
        
         public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
    
    }
}
