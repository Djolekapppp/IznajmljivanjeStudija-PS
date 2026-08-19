using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Common.Domen
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string Join {  get; }
        string Set { get; }
        List<IEntity> GetReaderList(SqlDataReader reader);

        // Conditions for CRUD operations
        string SelectCondition { get; set; }
        string InsertCondition { get; set; }
        string UpdateCondition { get; set; }
        string DeleteCondition { get; set; }
    }
}
