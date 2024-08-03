using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Services.Contracts;
using System.Configuration;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cliente.svc or Cliente.svc.cs at the Solution Explorer and start debugging.
    public class Cliente 
    {

        private readonly IClienteService _clienteService;
               

        public Model.Cliente GetCliente(int clienteId)
        {
            return _clienteService.GetCliente(clienteId);
            
        }

        public int InsertCliente(string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado)
        {
            return _clienteService.InsertCliente(numeroIdentificacion,tipoIdentificacion,primerNombre,segundoNombre,primerApellido,segundoApellido, direccionId, estado);
        }

        public void UpdateCliente(int clienteId, string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado)
        {
            _clienteService.UpdateCliente(clienteId, numeroIdentificacion, tipoIdentificacion, primerNombre, segundoNombre, primerApellido, segundoApellido, direccionId, estado);
        }


        public void DeleteCliente(int clienteId)
        {
           _clienteService.DeleteCliente(clienteId);
        }
    }
}
