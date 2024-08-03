using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.Services.Contracts
{
    public interface IClienteService
    {

        List<Cliente> GetAll();
        bool Insert();
        bool Update();
        bool Delete();

    }
}
