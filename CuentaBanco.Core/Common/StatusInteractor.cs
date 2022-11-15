using CuentaBanco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CuentaBanco.Core.Common.Constantes;

namespace CuentaBanco.Core.Common
{
    public abstract class StatusInteractor
    {
        public Response GetStatus(Func<Response> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                return new Response() { Status = (int)HttpStatusCode.InternalServerError, Message = $"{ERROR_APP} {e.Message}", Payload = null };
            }
        }
    }
}
