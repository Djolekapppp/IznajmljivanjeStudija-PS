using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiListuBendSO: SOBase
    {
        private readonly Bend bend;
        public List<Bend> Result { get; private set; }
        public VratiListuBendSO(Bend bend)
        {
            this.bend = bend;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetByCondition(bend).Cast<Bend>().ToList();
        }
    
    }
}
