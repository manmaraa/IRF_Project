using ManhertzMartinBeadando.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ManhertzMartinBeadando
{
    public partial class Form1 : Form
    {
        bool megtalalta = false;
        int r=0;
        bool megy = false;
       Random rnd = new Random();
        
        int xHely = 0;
        int yHely = 0;
        private List<Ball> _balls1 = new List<Ball>();

       // private List<Ball> _balls2 = new List<Ball>();
        private List<Cel> _celok = new List<Cel>();
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        private CelFactory _cfactory;
        public CelFactory CFactory
        {
            get { return _cfactory; }
            set { _cfactory = value; }
        }



        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
            CFactory = new CelFactory();
            //List<int> x = new List<int>();
            R();
        }
     void R()
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("koordinatak.xml");
            XmlNodeList xkoordinata = xDoc.GetElementsByTagName("X");
            XmlNodeList ykoordinata = xDoc.GetElementsByTagName("Y");
            //  XmlNodeList koordinataSzam = xDoc.GetElementsByTagName("I");


            r = rnd.Next(0, 43);
            foreach (XmlElement item in xkoordinata)
            {
                
                
                xHely = Convert.ToInt32(xkoordinata[r].InnerText);
                
            }
            foreach (XmlElement item in ykoordinata)
            {
                yHely = Convert.ToInt32(ykoordinata[r].InnerText);

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
         
            if (megy == false)
            {
                MessageBox.Show("Keresse meg a kék golyóval a pirosat a győzelem érdekében!!");

                var ball = Factory.CreateNew();
                ball.Left = 10;
                ball.Top = 10;
                _balls1.Add(ball);



                panel1.Controls.Add(ball);
                var cel = CFactory.CreateNew();

                cel.Left = xHely;
                cel.Top = yHely;
                _celok.Add(cel);
               /* MessageBox.Show(xHely.ToString());
                MessageBox.Show(yHely.ToString());*/
                panel1.Controls.Add(cel);
            }
            megy = true;


        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (megtalalta==true)
            {
                foreach (var ball in _balls1)
                { 
                    MessageBox.Show("Gratulálunk megtaláltad a labdát");

                panel1.Controls.Remove(ball);
                panel1.Controls.Clear();
                ball.Left = 10;
                ball.Top = 10;
                megy = false;
                    megtalalta = false;
                    break;
                }
                R();
            }
            foreach (var ball in _balls1)
            {
                if (xHely-ball.Left <=30&&  yHely-ball.Top <= 30 && ball.Top-yHely <= 30&&  ball.Left-xHely <= 30)
                {
                    megtalalta = true;
                    
                    
                }
            }

            if (keyData == Keys.Up)
            {
                foreach (var ball in _balls1)
                {
                    if (ball.Top >= 0)
                    {
                        ball.MoveBallUp();
                    }
                }
                return true;
            }
            
            if (keyData == Keys.Down)
            {
                foreach (var ball in _balls1)
                {
                    if (ball.Top <= panel1.Height-50)
                    {
                        ball.MoveBallDown();
                    }
                }
                return true;
            }
          
            if (keyData == Keys.Left)
            {
                foreach (var ball in _balls1)
                {
                    if (ball.Left >= 0)
                    {
                        ball.MoveBallLeft();
                    }
                }
                return true;
            }
       
            if (keyData == Keys.Right)
            {
                foreach (var ball in _balls1)
                {
                    if (ball.Left <= panel1.Width-50)
                    {
                        ball.MoveBallRight();
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
