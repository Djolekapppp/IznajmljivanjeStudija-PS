using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PretraziUgovorSO : SOBase
    {
        private readonly Ugovor ugovor;

        public Ugovor Result { get; set; }

        public PretraziUgovorSO(Ugovor ugovor)
        {
            this.ugovor = ugovor;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetByCondition(ugovor);
            Result = lista.Cast<Ugovor>().FirstOrDefault();
            List<StavkaUgovora> stavke = broker.GetAll(new StavkaUgovora()).Cast<StavkaUgovora>().ToList();

            BindingList<StavkaUgovora> stavkeFiltered = new BindingList<StavkaUgovora>();
            foreach (var stavka in stavke)
            {
                if (stavka.IdUgovor == Result.Id)
                {
                    stavkeFiltered.Add(stavka);
                }
            }
            Result.StavkeUgovora = stavkeFiltered;
        }
    }
}
