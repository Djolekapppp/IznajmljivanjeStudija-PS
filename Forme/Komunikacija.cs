using Common;
using Common.Domen;
using Common.Komunikacija;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Forme
{
    internal class Komunikacija
    {
        //singleton
        private static Komunikacija instance;

        public static Komunikacija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Komunikacija();
                }
                return instance;
            }
        }

        private Komunikacija()
        {
        }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);

            serializer = new JsonNetworkSerializer(socket);
        }

        public Zaposleni Login(string username, string password)
        {
            Zahtev z = new Zahtev()
            {
                Operacija = Operacija.Prijava,
                Objekat = new Zaposleni
                {
                    Username = username,
                    Password = password
                }
            };

            serializer.Send(z);

            Odgovor o = serializer.Receive<Odgovor>();

            if (!o.Uspesno)
            {
                throw new Exception(o.Greska);
            }

            Zaposleni zaposleni = serializer.ReadType<Zaposleni>(o.Objekat);

            return zaposleni;
        }

        internal List<Bend> VratiSveBendove()
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = Operacija.VratiSveBendove
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Bend>>(odgovor.Objekat);
        }

        internal List<Studio> VratiSveStudije()
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = Operacija.VratiSveStudije
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Studio>>(odgovor.Objekat);
        }

        internal int KreirajUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = ugovor,
                Operacija = Operacija.KreirajUgovor
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }

            return serializer.ReadType<int>(odgovor.Objekat);
        }

        internal void PromeniUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = ugovor,
                Operacija = Operacija.PromeniUgovor
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
        }

        internal Odgovor ObrisiUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = ugovor,
                Operacija = Operacija.ObrisiUgovor
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Receive<Odgovor>();
            return odgovor;
        }

        internal void ObrisiBend(Bend bend)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = bend,
                Operacija = Operacija.ObrisiBend
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
        }

        internal List<Zanr> VratiListuSviZanr()
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = Operacija.VratiSveZanrove
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Zanr>>(odgovor.Objekat);
        }

        internal int KreirajBend(Bend bend)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = bend,
                Operacija = Operacija.KreirajBend
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();

            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<int>(odgovor.Objekat);
        }

        internal void PromeniBend(Bend bend)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = bend,
                Operacija = Operacija.PromeniBend
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
        }

        internal List<Bend> VratiListuBend(Bend bend)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = bend,
                Operacija = Operacija.VratiListuBend
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Bend>>(odgovor.Objekat);
        }

        internal void UbaciTerminDezurstva(TerminDezurstva termin)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = termin,
                Operacija = Operacija.UbaciTerminDezurstva
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();

            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
        }

        internal List<Zaposleni> VratiSveZaposlene()
        {
            Zahtev zahtev = new Zahtev()
            {
                Operacija = Operacija.VratiSveZaposlene
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Zaposleni>>(odgovor.Objekat);
        }

        internal List<Ugovor> VratiListuUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = ugovor,
                Operacija = Operacija.VratiListuUgovor
            };
            serializer.Send(zahtev);

            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<List<Ugovor>>(odgovor.Objekat);
        }

        internal Ugovor PretraziUgovor(Ugovor ugovor)
        {
            Zahtev zahtev = new Zahtev()
            {
                Objekat = ugovor,
                Operacija = Operacija.PretraziUgovor
            };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return serializer.ReadType<Ugovor>(odgovor.Objekat);
        }
    }
}
