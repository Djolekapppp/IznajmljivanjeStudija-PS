using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveBendoveSO : SOBase
    {
        public List<Bend> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Bend()).Cast<Bend>().ToList();
        }
    }
}
