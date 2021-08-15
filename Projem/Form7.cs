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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel_Kayıt yeniKayıt;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                yeniKayıt = new Personel_Kayıt(textBox1.Text, textBox2.Text);
                OleDbConnection con = Database.baglan();

                string sorgu = "INSERT INTO kullanici (k_ad, k_sifre) VALUES ('" + yeniKayıt.Kullanici_ad + "', '" + yeniKayıt.Kullanici_sifre + "')";

                OleDbCommand cmd = new OleDbCommand(sorgu, con);
                int sonuc = cmd.ExecuteNonQuery();

                if (sonuc != 1)
                    MessageBox.Show("Ekleme Basarısız!");
                con.Close();
                this.Close();

            }
            else
                MessageBox.Show("Eksik Bilgi!!");
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Admin" && comboBox1.Text != "")
            {
                baglantiKur();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
             
                cmd.CommandText = "delete from kullanici where k_ad='" + comboBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kullanıcı iptal edilmiştir.");
                comboBox1.Text = "";
            }
            else
                MessageBox.Show("Yanlış Giriş!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            bilgiAl("SELECT * FROM Kullanici", comboBox1);
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
    }
}
