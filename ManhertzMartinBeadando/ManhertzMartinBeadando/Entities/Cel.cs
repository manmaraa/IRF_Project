using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManhertzMartinBeadando.Entities
{
   public class Cel:Label
    {
       public int speedB = 1;
        public int speedJ = 1;
        public int speedF = 1;
        public int speedL = 1;
        public Cel()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Ball_Paint;
            
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }



        protected void DrawImage(Graphics g)
        {
          
            g.FillEllipse(new SolidBrush(Color.Red), 0, 0, Width, Height);
            

        }
        public void MoveBallLeft()
        {
            Left -= speedB;
        }
        public void MoveBallRight()
        {
            Left += speedJ;
        }
        public void MoveBallDown()
        {
            Top += speedL;
        }
        public void MoveBallUp()
        {
            Top -= speedF;
        }
    }
}
