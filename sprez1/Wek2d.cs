using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sprez1
{
    class Wek2d
    {
        public double x, y;
        public  Wek2d()
        {
            x = 0;
            y = 0;
        }
        public Wek2d(Wek2d p)
        {
            x = p.x;
            y = p.y;
        }
        public Wek2d(double px, double py)
        {
            x = px;
            y = py;
        }
        public static Wek2d operator -(Wek2d w1,Wek2d w2)
        {
            return new Wek2d(w1.x - w2.x, w1.y - w2.y);
        }

        public static Wek2d operator +(Wek2d w1, Wek2d w2)
        {
            return new Wek2d(w1.x + w2.x, w1.y + w2.y);
        }
        public static Wek2d operator /(Wek2d w1,double podz)
        {
            return new Wek2d(w1.x / podz, w1.y / podz);
        }

        public static Wek2d operator *(Wek2d w1, double mno)
        {
            return new Wek2d(w1.x * mno, w1.y * mno);
        }

        public PointF GetPointF()
        {
            return new PointF((float)this.x, (float)this.y);
        }
        public double Dlugosc()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public void Norm()
        {
            double l = this.Dlugosc();
            x /= l;
            y /= l;
        }

        public override string ToString()
        {
            return "["+x.ToString()+","+y.ToString()+"]";
        }
    }
}
