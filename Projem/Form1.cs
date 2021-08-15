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
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }
        void bilgiAl(string sql, ComboBox cmb)
        {
            cmb.Items.Clear();
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
            con.Open();
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
            bilgiAl("SELECT * FROM kullanici", comboBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {   
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = comboBox1.Text;
            string sifre = textBox2.Text;

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from kullanici where StrComp(k_ad,'" + comboBox1.Text + "',0)=0 and StrComp(k_sifre,'" + textBox2.Text + "',0)=0";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 f2 = new Form2();
                Form3 f3 = new Form3();
                if (comboBox1.Text == "Admin")
                {
                    this.Hide();
                    f2.Show();
                    f2.FormClosing += f2_FormClosing;
                    con.Close();
                    
                    
                }
                else {
                    this.Hide();
                    f3.Show();
                    f3.FormClosing += f3_FormClosing;
                    con.Close();
                                    }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();
        }

        void f3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            //throw new NotImplementedException();
        }

        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            //throw new NotImplementedException();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("--Patrondan Şifre Alın--");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Gerçekten programı kapatmak istiyor musunuz?", "Closing event", MessageBoxButtons.YesNo);

            if (dr == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }
        
    }
}
