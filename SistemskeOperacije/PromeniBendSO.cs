using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PromeniBendSO : SOBase
    {
        private readonly Bend bend;
        public PromeniBendSO(Bend bend)
        {
            this.bend = bend;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.UpdateByCondition(bend);
        }
    }
}
