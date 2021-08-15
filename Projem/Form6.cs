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
using System.Collections;

namespace Projem
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");

        public string film_ad = "";
        public string salon_ad = "";
        public string film_seans = "";
        ArrayList koltuklar = new ArrayList();
        ArrayList iptalKoltuk = new ArrayList();
        int film_no = 0;
        int salon_no = 0;

        void baglantiKur()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            
            if (((Button)sender).BackColor == Color.Chartreuse) // yeşil
            {
                ((Button)sender).BackColor = Color.Orange;
                if (!koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Add(((Button)sender).Text);
                    koltukYazdir();
                }
                
            }
            else if (((Button)sender).BackColor == Color.Orange) // turuncu
            {
                ((Button)sender).BackColor = Color.Chartreuse;
                if (koltuklar.Contains(((Button)sender).Text))
                {
                    koltuklar.Remove(((Button)sender).Text);
                    koltukYazdir();
                }
                
            }
            else // kırmızı
            {
                if (!iptalKoltuk.Contains(((Button)sender).Text))
                {
                    iptalKoltuk.Add(((Button)sender).Text);
                }
                else
                {
                    iptalKoltuk.Remove(((Button)sender).Text);
                }

                string koltuk = "";
                for (int i = 0; i < iptalKoltuk.Count; i++)
                {
                    koltuk += iptalKoltuk[i].ToString() + ",";
                }
                if (iptalKoltuk.Count >= 1)
                {
                    koltuk = koltuk.Remove(koltuk.Length - 1, 1);
                }
                txtKoltukIptal.Text = koltuk;
            }
        }
        void koltukYazdir()
        {
            string koltuk = "";
            for (int i = 0; i < koltuklar.Count; i++)
            {
                koltuk += koltuklar[i].ToString() + ",";
            }
            if (koltuklar.Count >= 1)
            {
                koltuk = koltuk.Remove(koltuk.Length - 1, 1);
            }
            txtKoltukNo.Text = koltuk;
        }

        void biletAyir()
        {
            baglantiKur();
            string ucret = "";
            if (radioButton2.Checked) ucret = "10";
            else ucret = "15";

            for (int i = 0; i < koltuklar.Count; i++)
            {
                string sql = "INSERT INTO veri(film_no,salon_no,film_tarih,film_seans,koltuk_no,film_ucret) VALUES (" + film_no + "," + salon_no + ",'" + lblTarih.Text + "','" + film_seans + "'," + Convert.ToInt32(koltuklar[i]) + ",'" + ucret + "')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                this.Controls.Find("but" + koltuklar[i].ToString(), true)[0].BackColor = Color.Red;
            }

            con.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            lblFilmAdi.Text = film_ad;
            lblSalonSeans.Text = salon_ad + " / " + film_seans;
            timer1.Enabled = true;
            film_no = Convert.ToInt32(araGetir("SELECT * FROM film WHERE film_ad='" + film_ad + "'"));
            salon_no = Convert.ToInt32(araGetir("SELECT * FROM salon WHERE salon_ad='" + salon_ad + "'"));
            Onceki_veriler();
        }
        void Onceki_veriler()
        {
            baglantiKur();
            string sql = "SELECT * FROM veri WHERE film_no=" + film_no + " AND salon_no=" + salon_no + " AND film_seans='" + film_seans + "'";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                string koltuk_No = oku[5].ToString();
                this.Controls.Find("but" + koltuk_No, true)[0].BackColor = Color.Red;
            }
            con.Close();
        }
        string araGetir(string sql)
        {
            baglantiKur();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            oku.Read();
            string deger = oku[0].ToString();
            con.Close();
            return deger;
        }
        private void lblSaat_Click(object sender, EventArgs e)
        {

        }

        private void lblTarih_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToLongTimeString();
            lblTarih.Text = DateTime.Now.Date.ToShortDateString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (txtKoltukIptal.Text != "")
            {
                baglantiKur();
                for (int i = 0; i < iptalKoltuk.Count; i++)
                {
                    string sql = "DELETE FROM veri WHERE koltuk_no=" + Convert.ToInt32(iptalKoltuk[i]);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    this.Controls.Find("but" + iptalKoltuk[i].ToString(), true)[0].BackColor = Color.Chartreuse;
                }

                con.Close();
                iptalKoltuk.Clear();
                MessageBox.Show(txtKoltukNo.Text + " koltuk numaraları bileti iptal edilmiştir.");
                txtKoltukIptal.Text = "";
            }
            else
            {
                MessageBox.Show("Koltuk numarasını seçmediniz.");
            }
        }

        private void txtKoltukNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (txtKoltukNo.Text != "")
            {
                
                    biletAyir();
                    MessageBox.Show(txtKoltukNo.Text + " no'lu koltuklar ayrılmıştır.");
                    txtKoltukNo.Text = "";
                    koltuklar.Clear();
            }
            else
            {
                MessageBox.Show("Koltuk numarasını seçmediniz.", "Dikkat");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            f3.FormClosing += f3_FormClosing;
            this.Visible = false;
        }

        void f3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }
    }
}
