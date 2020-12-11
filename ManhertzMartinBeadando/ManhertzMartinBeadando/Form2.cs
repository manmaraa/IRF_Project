using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManhertzMartinBeadando
{
    public partial class Form2 : Form
    {
        List<string> kerdesek = new List<string>();
        public Form2()
        {
            InitializeComponent();
            
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var item in kerdesek)
                {
                    kerdesek.Add(textBox1.Text);
                }
                foreach (var item in kerdesek)
                {
                    sw.WriteLine(item);
                }
               
            }
        }
        
    }
}
