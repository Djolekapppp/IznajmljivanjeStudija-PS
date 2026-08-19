using Microsoft.Data.SqlClient;

namespace Common.Domen
{
    public class StavkaUgovora : IEntity
    {
        public int IdUgovor { get; set; }
        public int RB { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VremeOd { get; set; }
        public TimeSpan VremeDo { get; set; }
        public double BrojSati { get; set; }
        public double CenaPoSatu { get; set; }
        public double Iznos { get; set; } = 0;
        public Studio Studio { get; set; }

        public string TableName => "StavkaUgovora";

        public string Values => $"{IdUgovor}, {RB}, '{Datum.ToString("yyyyMMdd")}', '{VremeOd}', '{VremeDo}', {BrojSati}, {CenaPoSatu}, {Studio.Id}";

        public string Join => "JOIN Studio ON (StavkaUgovora.IdStudio = Studio.IdStudio)";

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
                StavkaUgovora stavka = new StavkaUgovora()
                {
                    IdUgovor = (int)reader[0],
                    RB = (int)reader[1],
                    Datum = (DateTime)reader[2],
                    VremeOd = (TimeSpan)reader[3],
                    VremeDo = (TimeSpan)reader[4],
                    BrojSati = (double)reader[5],
                    CenaPoSatu = (double)reader[6],
                    Iznos = (double)reader[8],
                    Studio = new Studio()
                    {
                        Id = (int)reader[9],
                        Naziv = (string)reader[10],
                        CenaPoSatu = (double)reader[11],
                        Kapacitet = (int)reader[12]
                    }
                };
                lista.Add(stavka);
            }
            return lista;
        }
    }
}