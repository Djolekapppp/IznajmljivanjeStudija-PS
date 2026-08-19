using Common;
using Common.Domen;
using Common.Komunikacija;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Server
{
    internal class ClientHandler
    {
        Socket klijent;
        private JsonNetworkSerializer serializer;

        public ClientHandler(Socket klijent)
        {
            this.klijent = klijent;
            serializer = new JsonNetworkSerializer(klijent);
        }

        public void Handle()
        {
            try
            {
                while (true)
                {
                    Zahtev z = serializer.Receive<Zahtev>();
                    Odgovor odgovor = ProcesuirajZahtev(z);
                    serializer.Send(odgovor);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                serializer?.Close();
            }

        }

        private Odgovor ProcesuirajZahtev(Zahtev? zahtev)
        {
            Odgovor odgovor = new Odgovor();
            odgovor.Uspesno = true;
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Prijava:
                        odgovor.Objekat = Kontroler.Instance.PrijaviSe(serializer.ReadType<Zaposleni>(zahtev.Objekat));
                        break;
                    case Operacija.VratiSveBendove:
                        odgovor.Objekat = Kontroler.Instance.VratiSveBendove();
                        break;
                    case Operacija.VratiSveStudije:
                        odgovor.Objekat = Kontroler.Instance.VratiSveStudije();
                        break;
                    case Operacija.KreirajUgovor:
                        odgovor.Objekat = Kontroler.Instance.KreirajUgovor(serializer.ReadType<Ugovor>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniUgovor:
                        Kontroler.Instance.PromeniUgovor(serializer.ReadType<Ugovor>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiUgovor:
                        Kontroler.Instance.ObrisiUgovor(serializer.ReadType<Ugovor>(zahtev.Objekat));
                        break;
                    case Operacija.VratiSveZanrove:
                        odgovor.Objekat = Kontroler.Instance.VratiSveZanrove();
                        break;
                    case Operacija.KreirajBend:
                        odgovor.Objekat = Kontroler.Instance.KreirajBend(serializer.ReadType<Bend>(zahtev.Objekat));
                        break;
                    case Operacija.PromeniBend:
                        Kontroler.Instance.PromeniBend(serializer.ReadType<Bend>(zahtev.Objekat));
                        break;
                    case Operacija.VratiListuBend:
                        odgovor.Objekat = Kontroler.Instance.VratiListuBend(serializer.ReadType<Bend>(zahtev.Objekat));
                        break;
                    case Operacija.ObrisiBend:
                        Kontroler.Instance.ObrisiBend(serializer.ReadType<Bend>(zahtev.Objekat));
                        break;
                    case Operacija.UbaciTerminDezurstva:
                        Kontroler.Instance.UbaciTerminDezurstva(serializer.ReadType<TerminDezurstva>(zahtev.Objekat));
                        break;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                odgovor.Uspesno = false;
                odgovor.Greska = ex.Message;
            }
            return odgovor;

        }

    }
}
