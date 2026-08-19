using Microsoft.Data.SqlClient;

namespace Common.Domen
{
    public class Zanr : IEntity
    {
        public int Id { get; set; }
        public string Naziv { get; set;}

        public string TableName => "Zanr";

        public string Values => $"'{Naziv}'";
        public string Join => "";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public string Set => "";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Zanr zanr = new Zanr()
                {
                    Id = (int)reader[0],
                    Naziv = (string)reader[1],
                };
                lista.Add(zanr);
            }
            return lista;
        }

        public override string ToString()
        {
            return Naziv;
               
        }
    }
}