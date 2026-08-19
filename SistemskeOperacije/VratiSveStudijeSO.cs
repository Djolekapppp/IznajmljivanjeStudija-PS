using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiSveStudijeSO : SOBase
    {
        public List<Studio> Result {  get; set; }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Studio()).Cast<Studio>().ToList();
        }
    }
}
