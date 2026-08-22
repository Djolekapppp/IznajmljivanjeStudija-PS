using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiListuUgovorSO : SOBase
    {
        private readonly Ugovor ugovor;
        public List<Ugovor> Result { get; private set; }

        public VratiListuUgovorSO(Ugovor ugovor)
        {
            this.ugovor = ugovor;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetByCondition(ugovor).Cast<Ugovor>().ToList();
        }
    }
}
