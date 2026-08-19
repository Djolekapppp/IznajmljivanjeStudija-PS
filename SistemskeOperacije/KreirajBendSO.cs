using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class KreirajBendSO : SOBase
    {
        private Bend bend;

        public int Result { get; set; }

        public KreirajBendSO(Bend bend)
        {
            this.bend = bend;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Create(bend);
        }
    }
}
