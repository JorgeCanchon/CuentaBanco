using CuentaBanco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.UsesCases
{
    public interface IClienteInteractor
    {
        Response InsertClient(Cliente cliente);
        Response GetClients();
        Response UpdateClient(Cliente cliente);
        Response DeleteClient(int id);
    }
}
