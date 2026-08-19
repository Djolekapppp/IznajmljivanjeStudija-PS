using Microsoft.Data.SqlClient;
using Common.Domen;
using System.Diagnostics;
using System.Data;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }
        public void RollBack()
        {
            connection.Rollback();
        }
        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Add(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {obj.TableName} values ({obj.Values})";
            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void CloseConnection()
        {
            connection.CloseConnection();
        }
        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from {entity.TableName} {entity.Join}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> GetByCondition(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.TableName} {entity.Join} {entity.SelectCondition}";
            Debug.WriteLine(command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public void DeleteEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {entity.TableName} {entity.DeleteCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void UpdateByCondition(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.TableName} {entity.Set} {entity.UpdateCondition}";
            Debug.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public int Create(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {obj.TableName} {obj.InsertCondition}";
            Debug.WriteLine(cmd.CommandText);
            object id = cmd.ExecuteScalar();
            cmd.Dispose();
            return (int)id;
        }

    }
}
