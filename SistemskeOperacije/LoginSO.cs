using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class LoginSO : SOBase
    {
        private readonly Zaposleni z;

        public Zaposleni Result { get; set; }

        public LoginSO(Zaposleni z)
        {
            this.z = z;
        }

        protected override void ExecuteConcreteOperation()
        {
            // Put the WHERE clause into the entity's SelectCondition so broker.GetByCondition(entity) can use it.
            z.SelectCondition = $"WHERE KorisnickoIme = '{z.Username}' AND Sifra = '{z.Password}'";
            List<IEntity> lista = broker.GetByCondition(z);

            Result = lista.Cast<Zaposleni>().FirstOrDefault();

            if (Result == null)
            {
                throw new Exception("Ne postoji korisnik sa unetim inicijalima");
            }
        }
    }
}
