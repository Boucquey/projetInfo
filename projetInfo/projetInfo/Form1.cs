using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Keys direction;
        public Form1()
        {
            InitializeComponent();
        }


        private void Move()
        {
            Point p = new Point();
            p = pB1.Location;

            switch (direction)
            {
                case Keys.Left:
                    p.X -= pB1.Height;
                    break;
                default: break;
            }

            pB1.Location = p;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            direction = e.KeyData;
            Move();
        }
        
    }
}
