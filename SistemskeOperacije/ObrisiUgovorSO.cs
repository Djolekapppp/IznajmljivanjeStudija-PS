using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiUgovorSO : SOBase
    {
        private readonly Ugovor ugovor;

        public ObrisiUgovorSO(Ugovor ugovor)
        {
            this.ugovor = ugovor;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(ugovor);
        }
    }
}
