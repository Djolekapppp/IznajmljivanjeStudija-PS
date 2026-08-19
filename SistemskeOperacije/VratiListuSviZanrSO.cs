using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiListuSviZanrSO : SOBase
    {
        public List<Zanr> Result { get; set; }
        protected override void ExecuteConcreteOperation()
        {
            List<IEntity> lista = broker.GetAll(new Zanr());
            Result = lista.Cast<Zanr>().ToList();
        }
    }
}
