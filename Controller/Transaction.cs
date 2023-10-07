using System;
using System.Configuration;
using Dapper;
using dsa_marketing.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace dsa_marketing.Controller
{
    public class Transaction : TransactionsModel
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection connection;
        public Transaction(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new MySqlConnection(_configuration.GetConnectionString("default"));
        }
        
    }
}
