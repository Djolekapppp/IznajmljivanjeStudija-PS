using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    public enum Smena
    {
        Prva,
        Druga,
        Treca
    }
    public class TerminDezurstva : IEntity
    {
        public int Id { get; set; }
        public TimeSpan VremeOd { get; set; }
        public TimeSpan VremeDo { get; set; }
        public Smena Smena { get; set; }

        public string TableName => "TerminDezurstva";

        public string Values => $"'{VremeOd}', '{VremeDo}', '{Smena.ToString()}'";

        public string Join => "";

        public string Set => "";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();

            while (reader.Read())
            {
                TerminDezurstva terminDezurstva = new TerminDezurstva()
                {
                    Id = (int)reader[0],
                    VremeOd = (TimeSpan)reader[1],
                    VremeDo = (TimeSpan)reader[2],
                    Smena = (Smena)Enum.Parse(typeof(Smena), reader[3].ToString())
                };
                lista.Add(terminDezurstva);
            }
            return lista;
        }
    }
}
