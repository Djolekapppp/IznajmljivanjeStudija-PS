using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    public class Ugovor : IEntity
    {
        public int Id { get; set; }
        public DateTime DatumSklapanja { get; set; }
        public Status Status { get; set; } 
        public Zaposleni Zaposleni { get; set; }
        public Bend Bend { get; set; }
        public BindingList<StavkaUgovora> StavkeUgovora { get; set; } = new BindingList<StavkaUgovora>();
        public double UkupnaCena { get; set; } = 0;

        public string TableName => "Ugovor";
        public string Values => $"'{DatumSklapanja.ToString("yyyyMMdd")}', '{Status.ToString()}', {Zaposleni.Id}, {Bend.Id}, {UkupnaCena}";

        public string Join => "JOIN Zaposleni ON (Ugovor.IdZaposleni = Zaposleni.IdZaposleni) JOIN Bend ON (Ugovor.IdBend = Bend.IdBend) JOIN Zanr ON (Bend.IdZanr = Zanr.IdZanr)";

        public string SelectCondition { get; set; }
        public string InsertCondition { get; set; }
        public string UpdateCondition { get; set; }
        public string DeleteCondition { get; set; }

        public string Set => $"SET DatumSklapanja = '{DatumSklapanja}', Status = '{Status}', IdZaposleni = {Zaposleni.Id}, IdBend = {Bend.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                Ugovor ugovor = new Ugovor()
                {
                    Id = (int)reader[0],
                    DatumSklapanja = (DateTime)reader[1],
                    Status = (Status)Enum.Parse(typeof(Status), (string)reader[2]),
                    UkupnaCena = (double)reader[5],
                    Zaposleni = new Zaposleni()
                    {
                        Id = (int)reader[6],
                        Ime = (string)reader[7],
                        Prezime = (string)reader[8],
                        Username = (string)reader[9],
                        Password = (string)reader[10],
                        Email = (string)reader[11],
                        DatumZaposlenja = (DateTime)reader[12],
                    },
                    Bend = new Bend()
                    {
                        Id = (int)reader[13],
                        Naziv = (string)reader[14],
                        KontaktTelefon = (string)reader[15],
                        Email = (string)reader[16],
                        KontaktIme = (string)reader[17],
                        BrojClanova = (int)reader[18],
                        Zanr = new Zanr()
                        {
                            Id = (int)reader[20],
                            Naziv = (string)reader[21]
                        }
                    } };
                lista.Add(ugovor);
            }
            return lista;
        }
    }
}
