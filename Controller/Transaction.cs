using System;
using System.Configuration;
using Dapper;
using dsa_marketing.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace dsa_marketing.Controller
{
    public class Transaction
    {
        string connectionString = "Server=127.0.0.1;Port=3306;Database=dsa_cluster;Uid=aidrecabrera;Pwd=aidrecabrera";
        public List<TransactionViewModel> ReadTransaction()
        {
            List<TransactionViewModel> transactionList = new List<TransactionViewModel>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            string selectQuery = "SELECT * FROM transactionview";
            transactionList = connection.Query<TransactionViewModel>(selectQuery).ToList();
            return transactionList;
        }
    }
}
