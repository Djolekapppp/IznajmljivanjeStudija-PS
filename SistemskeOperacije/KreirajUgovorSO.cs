using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class KreirajUgovorSO : SOBase
    {
        private Ugovor ugovor;
        private List<StavkaUgovora> stavke;
        public int Result { get; set; }

        public KreirajUgovorSO(Ugovor ugovor)
        {
            this.ugovor = ugovor;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Create(ugovor);
        }
    }
}
