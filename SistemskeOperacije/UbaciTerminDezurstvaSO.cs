using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UbaciTerminDezurstvaSO : SOBase
    {
        private TerminDezurstva terminDezurstva;
        public UbaciTerminDezurstvaSO(TerminDezurstva terminDezurstva)
        {
            this.terminDezurstva = terminDezurstva;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Add(terminDezurstva);
        }
    }
}
