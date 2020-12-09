using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManhertzMartinBeadando.Entities
{
    class Cel:Label
    {
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
            //g.DrawRectangles(new SolidBrush(Color.Red), 0, 0, Width, Height);
        }
    }
}
