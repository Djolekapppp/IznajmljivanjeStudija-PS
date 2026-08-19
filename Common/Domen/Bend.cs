using Microsoft.Data.SqlClient;

namespace Common.Domen
{
    public class Bend : IEntity
    {
        public int Id { get; set;  }
        public string Naziv { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string KontaktIme { get; set; }
        public int BrojClanova { get; set; }
        public Zanr Zanr { get; set; }

        public string TableName => "Bend";

        public string Values => $"'{Naziv}', '{KontaktTelefon}', '{Email}', '{KontaktIme}', '{BrojClanova}', '{Zanr.Id}'";

        public string Join => "JOIN Zanr ON (Bend.IdZanr = Zanr.IdZanr)";
        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public string Set => $"SET NazivBend = '{Naziv}', KontaktTelefon = '{KontaktTelefon}', Email = '{Email}', KontaktIme = '{KontaktIme}', BrojClanova = {BrojClanova}, IdZanr = {Zanr.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Bend bend = new Bend()
                {
                    Id = (int)reader[0],
                    Naziv = (string)reader[1],
                    KontaktTelefon = (string)reader[2],
                    Email = (string)reader[3],
                    KontaktIme = (string)reader[4],
                    BrojClanova = (int)reader[5],
                    Zanr = new Zanr()
                    {
                        Id = (int)reader[7],
                        Naziv = (string)reader[8]
                    }
                };
                lista.Add(bend);
            }
            return lista;
        }

        public override string ToString()
        {
            return Naziv;
        }
    }
}