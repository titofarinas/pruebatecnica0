﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WcfService.Services.Contracts;

namespace WcfService.Services
{
    public class ClienteService : IClienteService
    {
        private readonly string _connectionString;

        public ClienteService(string connectionString)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["dbtest"].ConnectionString;
        }

        public Model.Cliente GetCliente(int clienteId)
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
                            return new Model.Cliente
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
                        }
                    }
                }
            }

            return null;
        }

        public int InsertCliente(string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void UpdateCliente(int clienteId, string numeroIdentificacion, string tipoIdentificacion, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int direccionId, bool estado)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
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
                    command.Parameters.AddWithValue("@direccion_id", direccionId);
                    command.Parameters.AddWithValue("@estado", estado);

                    connection.Open();
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