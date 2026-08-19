using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    internal class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DbConnection()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=iznajmljivanjeStudija;Integrated security=True");
        }

        public void OpenConnection()
        {
            connection?.Open();
        }
        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
    
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
