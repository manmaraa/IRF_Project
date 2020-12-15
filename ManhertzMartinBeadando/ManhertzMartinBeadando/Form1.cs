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
        // bool szin = false;
        //double kerek = 0;
      //  int nehezseg = 0;
        bool end = false;
        bool megtalalta = false;
        int r=0;
        bool megy = false;
       Random rnd = new Random();
        
        int xHely = 0;
        int yHely = 0;
        private List<Ball> _balls1 = new List<Ball>();

       // private List<Ball> _balls2 = new List<Ball>();
        private List<Cel> _celok = new List<Cel>();
       /* var cel = CFactory.CreateNew();
        _celok.Add(cel);*/
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
               
                    
                    if (megtalalta == false)
                    {
                        button2.BackColor = Color.White;
                    }
                  
                
                
            }
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
            button1.Visible = false;
            button6.Visible = false; ;
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

            r = rnd.Next(0, 53);

               // foreach (XmlElement item in xkoordinata)
           // {
               // for (int i = 0; i < 53; i++)
                

                
                    yHely = Convert.ToInt32(ykoordinata[r].InnerText);
                   xHely = Convert.ToInt32(xkoordinata[r].InnerText);
                

           // }  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button6.Visible = true;

            if (megy == false)
            {

                //  MessageBox.Show("Keresse meg a kék golyóval a pirosat a győzelem érdekében!!");
               // _celok.Clear();
                var ball = Factory.CreateNew();
                ball.Left = 10;
                ball.Top = 10;
                _balls1.Add(ball);
                panel1.Controls.Add(ball);
                var cel = CFactory.CreateNew();

                cel.Left = xHely;
                cel.Top = yHely;
                _celok.Add(cel);
               
                panel1.Controls.Add(cel);
            }
            
            megy = true;


            MessageBox.Show("Keresse meg a kék golyóval a pirosat a győzelem érdekében!!");
            if (comboBox1.Text == "Kezdő")
            {
                foreach (var cel in _celok)
                {
                    cel.speedB = 2;
                    cel.speedJ = 3;
                    cel.speedF = 2;
                    cel.speedL = 3;
                }
            }
            else if (comboBox1.Text == "Könnyű")
            {
                foreach (var cel in _celok)
                {
                    cel.speedB = 2;
                    cel.speedJ = 5;
                    cel.speedF = 2;
                    cel.speedL = 3;
                };
            }
            else if (comboBox1.Text == "Közepes")
            {
                foreach (var cel in _celok)
                {
                    cel.speedB = 8;
                    cel.speedJ = 13;
                    cel.speedF = 3;
                    cel.speedL = 4;
                }
            }
            else if (comboBox1.Text == "Nehéz")
            {
                foreach (var cel in _celok)
                {
                    cel.speedB = 13;
                    cel.speedJ = 20;
                    cel.speedF = 8;
                    cel.speedL = 28;
                }
            }
            else if (comboBox1.Text == "Lehetetlen")
            {

                foreach (var cel in _celok)
                {
                    cel.speedB = 22;
                    cel.speedJ = 55;
                    cel.speedF = 28;
                    cel.speedL = 17;
                }
            }
           

        }
       void Vege()
        {
            if (end == true)
            {

            
                foreach (var ball in _balls1)
                {
                    MessageBox.Show("Vesztettél, a játéknak vége, a folytatáshoz kezdj új játékot!");

                    panel1.Controls.Remove(ball);
                    panel1.Controls.Clear();
                    panel1.Refresh();
                    ball.Left = 10;
                    ball.Top = 10;
                   
                    megy = false;
                end = false;
                break;
                }
                foreach (var cel1 in _celok)
                {
               // _celok.Remove(cel1);
                    cel1.Left = xHely;
                    cel1.Top = yHely;
                   // break;
                }
                R();
            }

        }
       


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
          
                Vege();
           
            
            if (megtalalta==true)
            {
                  
                
                    button2.BackColor = Color.Yellow;
                
                foreach (var ball in _balls1)
                { 
                    MessageBox.Show("Gratulálunk megtaláltad a labdát");

               // panel1.Controls.Remove(ball);
                panel1.Controls.Clear();
                ball.Left = 10;
                ball.Top = 10;
                megy = false;
                    
                    break;
                }
                foreach (var cel1 in _celok)
                {
                   // cel1.Left = 2000;
                   // cel1.Top =2000 ;
                   // panel1.Controls.Remove(cel1);
                    
                }
              //  _celok.Clear();
                R();
                megtalalta = false;
            }
            foreach (var ball in _balls1)
            {
                foreach (var cel in _celok)
                {

                
                if (cel.Left-ball.Left <=40&&  cel.Top-ball.Top <= 40 && ball.Top-cel.Top <= 40&&  ball.Left-cel.Left <= 40)
                {
                    megtalalta = true;
                        
                    
                }
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
                foreach (var ball in _celok)
                {
                    if (ball.Top >= 0)
                    {
                        ball.MoveBallDown();
                    }
                   if (ball.Top >= panel1.Height-50 )
                    {
                        end = true;
                       
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
                foreach (var ball in _celok)
                {
                    if (ball.Top <= panel1.Height - 50)
                    {
                        ball.MoveBallUp();
                    }
                   
                    if (ball.Top <= 0)
                    {
                        end = true;
                      
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
                foreach (var ball in _celok)
                {
                    if (ball.Left <= panel1.Width-50)
                    {
                        ball.MoveBallRight();
                    }
                    if (ball.Left>= panel1.Width - 50)
                    {
                        end = true;

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
                foreach (var ball in _celok)
                {
                    if (ball.Left >= 0)
                    {
                        ball.MoveBallLeft();
                    }
                    if (ball.Left<=0)
                    {
                        end = true;
                      
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

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. A játék elkezdéséhez válasszon nehézségi szintet. ( ha nem választasz akkor \"Kezdő\" lesz automatikusan.\r\n" +
                "2. Kattintson Az \"Indítás\" gombra. \r\n" +
                "3. A nyilakkal irányítsa a nyilakkal a kék golyót, hogy megtalálja a pirosat. De vigyázz a piros golyó is mozog!!! Amint a kék golyóval ráment a piros golyóra Ön győzött. \r\n" +
                " A piros golyó minden játék alkalmával más-más pozíciót vesz fel. Ha a piros golyó a pálya széléhez ér, vesztettél!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            /* Panel panel1 = new Panel();
             this.Controls.Remove(panel1);
             this.Controls.Add(panel1);*/
           // Application.Restart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
