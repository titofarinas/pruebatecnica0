using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WcfService.Services.Contracts
{
    public interface IClienteService
    {

        int InsertCliente(string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado);
        Model.Cliente GetCliente(int clienteId);
        void UpdateCliente(int clienteId, string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado);
        void DeleteCliente(int clienteId);

    }
}
