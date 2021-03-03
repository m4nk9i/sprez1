using System.Collections.Generic;


namespace sprez1
{

    
    class Kulka

    {
        public Wek2d poz,pred,przysp;
        public double masa,r;
        public bool zaczep;
        public Kulka()
        {
            poz = new Wek2d(0, 0);
            pred = new Wek2d(0, 0);
            przysp = new Wek2d(0, 0);
            zaczep = false;
            masa = 0.5f;
            r = 0;
        }
        public Kulka(double px,double py) :this()
        {
            poz = new Wek2d(px, py);

        }

        public void licz(double dt)
        {
            if (zaczep==false)
            {
                pred += przysp * dt;
                poz += pred * dt;
            }
        }

        public override string ToString()
        {
            return "poz " + poz.ToString() + " pred " + pred.ToString() + " przysp " + przysp.ToString();
        }

    }
    class Sprezyna
    {
        public Kulka koniec, poczatek;
        public double k;
        public double len;
        public double F;
        public Sprezyna()
        {
            k = 0.5f;
            len = 30;
            F = 0;
            
        }
        public Sprezyna(Kulka po,Kulka ko):this()
        {
            koniec = ko;
            poczatek = po;
        }
        public void licz()
        {
            Wek2d tw = poczatek.poz - koniec.poz;
            double l = tw.Dlugosc()-len;
            F = (-k * l);
            tw.Norm();
            Wek2d wF = new Wek2d(tw.x * F, tw.y * F);
            poczatek.przysp += wF / poczatek.masa;
            koniec.przysp -= wF/koniec.masa;
               
        }
        public override string ToString()
        {
            return "k= "+k.ToString()+" len="+len.ToString()+" F="+F.ToString();
        }
    }
    class Fizyka
    {
        public List<Kulka> kulki;
        public List<Sprezyna> sprezyny;
        public void InitFiz()
        {
            Kulka tkul;
            Sprezyna tspr;
            for (int i=0;i<32;i++)
            {
                tkul = new Kulka(300 - 10 * i, 10 + 10 * i);
                kulki.Add(tkul);
            }
         //   tkul = new Kulka(200, 10);
          //  kulki.Add(tkul);

            kulki[0].zaczep = true;
          //  kulki[kulki.Count - 1].zaczep = true;
            for (int i=0;i<kulki.Count-1;i++)
            {
                tspr = new Sprezyna(kulki[i], kulki[i + 1]);
                Wek2d twek = kulki[i].poz - kulki[i + 1].poz;
                tspr.len = twek.Dlugosc();
                sprezyny.Add(tspr);
            }
        }

        public void licz()
        {

            foreach (Kulka kul in kulki)
            {
                kul.przysp.x = 0;
                kul.przysp.y = 0;
                //kul.pred.x = 0;
                //kul.pred.y = 0;
            }

            foreach (Sprezyna spr in sprezyny)
            {
                spr.licz();
            }
            /// grawitacja
            foreach (Kulka kul in kulki)
            {
                kul.przysp.y += 0.005;
            }

            foreach (Kulka kul in kulki)
            {
                kul.licz(1);
            }
        }

        public override string ToString()
        {
            string tstr=""+sprezyny.Count.ToString();
            foreach(Sprezyna spr in sprezyny)
            {
                tstr += spr.ToString() + "\r\n";
            }
            foreach(Kulka kul in kulki)
            {
                tstr += kul.ToString() + "\r\n";
            }
            return tstr;
        }

        public Fizyka()
        {
            kulki = new List<Kulka>();
            sprezyny = new List<Sprezyna>();
            InitFiz();
        }
    }
}
