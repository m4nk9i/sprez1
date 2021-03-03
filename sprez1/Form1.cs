using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sprez1
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        Graphics tgraf,graf;
        static Fizyka fiz;
        public Form1()
        {
            InitializeComponent();

            bm = new Bitmap(panel1.Width, panel1.Height);
            tgraf = Graphics.FromImage(bm);
            graf = panel1.CreateGraphics();
            fiz = new Fizyka();
            {
                textBox1.Text += fiz.ToString();
            }
        }

        public void rysujsprezyny()
        {
            foreach (Sprezyna spr in fiz.sprezyny)
            {
                if (spr.F>0)
                {
                    tgraf.DrawLine(Pens.Red, spr.koniec.poz.GetPointF(), spr.poczatek.poz.GetPointF());
                } else
                {
                    tgraf.DrawLine(Pens.Blue, spr.koniec.poz.GetPointF(), spr.poczatek.poz.GetPointF());
                }
                
            }
        }

        public void rysujkulki()
        {
            foreach (Kulka kul in fiz.kulki)
            {
                tgraf.DrawEllipse(Pens.Black, (float)kul.poz.x-5, (float)kul.poz.y - 5, 10, 10);
            }
        }

        private void rysuj()
        {
            tgraf.Clear(Color.White);
            rysujsprezyny();
            rysujkulki();
            graf.DrawImage(bm, new Point(0, 0));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rysuj();
            fiz.licz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text+=fiz.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
