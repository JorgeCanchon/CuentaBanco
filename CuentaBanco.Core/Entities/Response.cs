using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Entities
{
    public class Response
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Payload { get; set; }
    }
}
