using Common.Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Kontroler
    {
        private static Kontroler instance;

        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }

        private Kontroler()
        {
        }

        public Zaposleni PrijaviSe(Zaposleni z)
        {
            LoginSO so = new LoginSO(z);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Bend> VratiSveBendove()
        {
            VratiSveBendoveSO so = new VratiSveBendoveSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Studio> VratiSveStudije()
        {
            VratiSveStudijeSO so = new VratiSveStudijeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        // Now returns the generated Ugovor Id
        public int KreirajUgovor(Ugovor ugovor)
        {
            KreirajUgovorSO so = new KreirajUgovorSO(ugovor);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void PromeniUgovor(Ugovor ugovor)
        {
            PromeniUgovorSO so = new PromeniUgovorSO(ugovor);
            so.ExecuteTemplate();
        }

        public void ObrisiUgovor(Ugovor ugovor)
        {
            ObrisiUgovorSO so = new ObrisiUgovorSO(ugovor);
            so.ExecuteTemplate();
        }

        internal object VratiSveZanrove()
        {
            VratiListuSviZanrSO so = new VratiListuSviZanrSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        internal int KreirajBend(Bend bend)
        {
            KreirajBendSO so = new KreirajBendSO(bend);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal void PromeniBend(Bend bend)
        {
            PromeniBendSO so = new PromeniBendSO(bend);
            so.ExecuteTemplate();
        }

        internal void ObrisiBend(Bend bend)
        {
            ObrisiBendSO so = new ObrisiBendSO(bend);
            so.ExecuteTemplate();
        }

        internal List<Bend> VratiListuBend(Bend bend)
        {
            VratiListuBendSO so = new VratiListuBendSO(bend);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal void UbaciTerminDezurstva(TerminDezurstva terminDezurstva)
        {
            UbaciTerminDezurstvaSO so = new UbaciTerminDezurstvaSO(terminDezurstva);
            so.ExecuteTemplate();
        }

        internal List<Zaposleni> VratiSveZaposlene()
        {
            VratiSveZaposleneSO so = new VratiSveZaposleneSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        internal List<Ugovor> VratiListuUgovor(Ugovor ugovor)
        {
            VratiListuUgovorSO so = new VratiListuUgovorSO(ugovor);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal object PretraziUgovor(Ugovor ugovor)
        {
            PretraziUgovorSO so = new PretraziUgovorSO(ugovor);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
