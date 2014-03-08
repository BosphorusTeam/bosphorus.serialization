using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosphorus.Serialization.Default.Demo
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
