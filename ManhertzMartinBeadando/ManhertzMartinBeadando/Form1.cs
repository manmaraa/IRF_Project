﻿using ManhertzMartinBeadando.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManhertzMartinBeadando
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;
        private List<Ball> _balls = new List<Ball>();
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
         
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            
            ball.Left = 10;
            ball.Top = 10;
            panel1.Controls.Add(ball);
            ball = Factory.CreateNew();
            x = 100;
            y = 100;
            ball.Left = x;
            ball.Top = y;
            panel1.Controls.Add(ball);

        }

      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
           
            if (keyData == Keys.Up)
            {
                foreach (var ball in _balls)
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
                foreach (var ball in _balls)
                {
                    if (ball.Top >= 0)
                    {
                        ball.MoveBallDown();
                    }
                }
                return true;
            }
          
            if (keyData == Keys.Left)
            {
                foreach (var ball in _balls)
                {
                    if (ball.Top >= 0)
                    {
                        ball.MoveBallLeft();
                    }
                }
                return true;
            }
       
            if (keyData == Keys.Right)
            {
                foreach (var ball in _balls)
                {
                    if (ball.Top >= 0)
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
