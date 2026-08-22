using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class PromeniUgovorSO : SOBase
    {
        private readonly Ugovor ugovor;

        public PromeniUgovorSO(Ugovor ugovor)
        {
            this.ugovor = ugovor;
        }

        protected override void ExecuteConcreteOperation()
        {
            List<StavkaUgovora> oldStavke = broker.GetByCondition(new StavkaUgovora { SelectCondition = $"WHERE IdUgovor = {ugovor.Id}" }).Cast<StavkaUgovora>().ToList();

            foreach (var stavka in oldStavke)
            {
                stavka.DeleteCondition = $"WHERE RB = {stavka.RB} AND IdUgovor = {stavka.IdUgovor}";
                broker.DeleteEntity(stavka);
            }

            int i = 1;
            foreach (var stavka in ugovor.StavkeUgovora)
            {
                stavka.RB = i;
                stavka.IdUgovor = ugovor.Id;
                try
                {
                    broker.Add(stavka);
                    i++;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Neuspešno dodavanje stavke, {stavka.RB}, {stavka.Studio.Naziv}, {ex.Message}");
                        
                }
            }
            ugovor.UpdateCondition = "WHERE IdUgovor = " + ugovor.Id;
            broker.UpdateByCondition(ugovor);
        }
    }
}
