using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace Common.Domen
{
    public class Studio : IEntity
    {
        public int Id {  get; set; }
        public string Naziv {  get; set; }
        public double CenaPoSatu { get; set; }
        public int Kapacitet { get; set; }

        public string TableName => "Studio";

        public string Values => $"'{Naziv}', '{CenaPoSatu}', '{Kapacitet}'";

        public string Join => "";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public string Set => $"";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Studio studio = new Studio()
                {
                    Id = (int)reader[0],
                    Naziv = (string)reader[1],
                    CenaPoSatu = (double)reader[2],
                    Kapacitet = (int)reader[3]
                };
                lista.Add(studio);
            }
            return lista;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }

    
}