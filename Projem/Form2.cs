using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Projem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            Form1 f1 = new Form1();
            f1.Show();
            f1.FormClosing += f1_FormClosing;
            this.Visible = false;
            //f1.ShowDialog();
            
        }

        void f1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            f7.FormClosing += f7_FormClosing;
            this.Hide();
        }

        void f7_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            f4.FormClosing += f4_FormClosing;
            this.Hide();

        }

        void f4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            f8.FormClosing += f8_FormClosing;
            this.Hide();
        }

        void f8_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }
        
        
    }
}
