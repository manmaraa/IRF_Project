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
       Random rnd = new Random();
        
        int xHely = 0;
        int yHely = 0;
        private List<Ball> _balls1 = new List<Ball>();
        private List<Ball> _balls2 = new List<Ball>();
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

     

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
            List<int> x = new List<int>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("koordinatak.xml");
            XmlNodeList xkoordinata = xDoc.GetElementsByTagName("X");
            XmlNodeList ykoordinata = xDoc.GetElementsByTagName("Y");
            XmlNodeList koordinataSzam = xDoc.GetElementsByTagName("I");
            
            int r = rnd.Next(1, 44);

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
            var ball = Factory.CreateNew();
            ball.Left = 10;
            ball.Top = 10;
            _balls1.Add(ball);
            
           
           
            panel1.Controls.Add(ball);
            ball = Factory.CreateNew();
          
            ball.Left = xHely;
            ball.Top = yHely;
            _balls2.Add(ball);
            MessageBox.Show(xHely.ToString());
            MessageBox.Show(yHely.ToString());
            panel1.Controls.Add(ball);
          
        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            foreach (var ball in _balls1)
            {
                if (xHely-ball.Left <=10&&  yHely-ball.Top <= 10 && ball.Top-yHely <= 10&&  ball.Left-xHely <= 10)
                {
                    panel1.Controls.Remove(ball);
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

    }
}
