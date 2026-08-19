using Microsoft.Data.SqlClient;

namespace Common.Domen
{
    public class Zaposleni : IEntity
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DatumZaposlenja { get; set; }

        public string TableName => "Zaposleni";
        public string Values => $"'{Ime}','{Prezime}','{Username}','{Password}',{Email},{DatumZaposlenja.ToString("yyyy/MM/dd")}";
        public string Join => "";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public string Set => $"";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> zaposleni = new List<IEntity>();

            while (reader.Read())
            {
                Zaposleni z = new Zaposleni
                {
                    Id = (int)reader[0],
                    Ime = (string)reader[1],
                    Prezime = (string)reader[2],
                    Username = (string)reader[3],
                    Password = (string)reader[4],
                    Email = (string)reader[5],
                    DatumZaposlenja = (DateTime)reader[6],
                };
                zaposleni.Add(z);
            }
            return zaposleni;
        }

        public override string ToString()
        {
            return $"{Id}:'{Ime}','{Prezime}','{Username}','{Password}',{Email},{DatumZaposlenja.ToString("yyyy/MM/dd")}";
        }

    }
}
