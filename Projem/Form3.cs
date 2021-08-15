using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Projem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
        void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        
        void bilgiAl(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            baglantiKur();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                cmb.Items.Add(oku[1].ToString());
            }
            con.Close();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            bilgiAl("SELECT * FROM film", comboBox1);
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            bilgiAl("SELECT * FROM salon", comboBox3);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                Form6 rezerve = new Form6();
                rezerve.film_ad = comboBox1.Text;
                rezerve.salon_ad = comboBox3.Text;
                rezerve.film_seans = comboBox2.Text;
                rezerve.Show();
                rezerve.FormClosing += rezerve_FormClosing;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen film bilgilerini eksiksiz doldurunuz!!!");
            }
        }

        void rezerve_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            f1.FormClosing += f1_FormClosing;
            this.Visible = false;
        }

        void f1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }
        
    }
}
