using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DTOs;
using WcfService.Model;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Cliente> GetClientesActivos();

        [OperationContract]
        int InsertCliente(string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, bool estado);
        [OperationContract]
        CustomerDTO GetCliente(int clienteId);
        [OperationContract]
        void UpdateCliente(int clienteId, string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccion_id, string direccion, bool estado);
        [OperationContract] 
        void DeleteCliente(int clienteId);
    }
}
