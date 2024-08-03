using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.Model;
using WcfService.DTOs;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        private readonly string _connectionString;

        public CustomerService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbtest"].ConnectionString;
        }


        public List<Cliente> GetClientesActivos()
        {
            List<Cliente> clientesActivos = new List<Cliente>();
                        
            string connectionString = ConfigurationManager.ConnectionStrings["dbtest"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetClientesActivos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                cliente_id = (int)reader["cliente_id"],
                                numero_identificacion = reader["numero_identificacion"].ToString(),
                                tipo_identificacion = reader["tipo_identificacion"].ToString(),
                                primer_nombre = reader["primer_nombre"].ToString(),
                                segundo_nombre = reader["segundo_nombre"].ToString(),
                                primer_apellido = reader["primer_apellido"].ToString(),
                                segundo_apellido = reader["segundo_apellido"].ToString(),
                                direccion_id = (int)reader["direccion_id"],
                                estado = (bool)reader["estado"]
                            };

                            clientesActivos.Add(cliente);
                        }
                    }
                }
            }

            return clientesActivos;
        }



        public CustomerDTO GetCliente(int clienteId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cliente_id", clienteId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerDTO
                            {
                                cliente_id = (int)reader["cliente_id"],
                                numero_identificacion = reader["numero_identificacion"].ToString(),
                                tipo_identificacion = reader["tipo_identificacion"].ToString(),
                                primer_nombre = reader["primer_nombre"].ToString(),
                                segundo_nombre = reader["segundo_nombre"].ToString(),
                                primer_apellido = reader["primer_apellido"].ToString(),
                                segundo_apellido = reader["segundo_apellido"].ToString(),                                
                                direccion_id = (int)reader["direccion_id"],
                                direccion = reader["direccion"].ToString(),
                                estado = (bool)reader["estado"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public int InsertCliente(string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, string direccion, bool estado)
        {
            int direccionId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_InsertDireccion", connection)) {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@descripcion", direccion);
                    
                    connection.Open();
                    direccionId = Convert.ToInt32(command.ExecuteScalar());
                }


                using (SqlCommand command = new SqlCommand("sp_InsertCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@numero_identificacion", numeroIdentificacion);
                    command.Parameters.AddWithValue("@tipo_identificacion", tipoIdentificacion);
                    command.Parameters.AddWithValue("@primer_nombre", primerNombre);
                    command.Parameters.AddWithValue("@segundo_nombre", segundoNombre);
                    command.Parameters.AddWithValue("@primer_apellido", primerApellido);
                    command.Parameters.AddWithValue("@segundo_apellido", segundoApellido);
                    command.Parameters.AddWithValue("@direccion_id", direccionId);
                    command.Parameters.AddWithValue("@estado", estado);
                                        
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void UpdateCliente(int clienteId, string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccion_id, string direccion, bool estado)
        {
            

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if (estado == true)
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertDireccion", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@descripcion", direccion);

                       
                        direccion_id = Convert.ToInt32(command.ExecuteScalar());
                    }

                }
                                

                using (SqlCommand command = new SqlCommand("sp_UpdateCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@cliente_id", clienteId);
                    command.Parameters.AddWithValue("@numero_identificacion", numeroIdentificacion);
                    command.Parameters.AddWithValue("@tipo_identificacion", tipoIdentificacion);
                    command.Parameters.AddWithValue("@primer_nombre", primerNombre);
                    command.Parameters.AddWithValue("@segundo_nombre", segundoNombre);
                    command.Parameters.AddWithValue("@primer_apellido", primerApellido);
                    command.Parameters.AddWithValue("@segundo_apellido", segundoApellido);
                    command.Parameters.AddWithValue("@direccion_id", direccion_id);
                    command.Parameters.AddWithValue("@estado", true);

                    
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteCliente(int clienteId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCliente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cliente_id", clienteId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

