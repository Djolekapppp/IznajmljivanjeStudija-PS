using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveZaposleneSO : SOBase
    {
        public List<Zaposleni> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Zaposleni()).Cast<Zaposleni>().ToList();
        }
    }
}
