using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.Model;

namespace WcfService.Services.Contracts
{
    public interface IPrestamo
    {
        List<Prestamo> GetAll();
        bool Insert();
        bool Update();
        bool Delete();
    }
}
