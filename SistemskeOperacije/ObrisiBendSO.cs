using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class ObrisiBendSO : SOBase
    {
        private readonly Bend bend;
        public ObrisiBendSO(Bend bend)
        {
            this.bend = bend;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.DeleteEntity(bend);
        }
    }
    
}
