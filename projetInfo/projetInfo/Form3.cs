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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            pBmort.BackColor = Color.Transparent;
            Image gameOver = Image.FromFile(@".\gameOver.png");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
 
        }

        public void SetScore(int score){
            this.labelScore.Text = "Score : "+score +"";


        }

        private void bnOk_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Dispose();

        }
    }
}
