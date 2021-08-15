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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayıt yeniKayıt;

            yeniKayıt = new Kayıt(textBox1.Text, textBox2.Text, textBox4.Text);

            OleDbConnection con = Database.baglan();

            string sorgu = "INSERT INTO film (film_ad, film_tur, film_yönetmen) VALUES ('" + yeniKayıt.Film_ad + "', '" + yeniKayıt.Film_tur + "',  '" + yeniKayıt.Film_yönetmen + "')";

            OleDbCommand cmd = new OleDbCommand(sorgu, con);

            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc != 1)
                MessageBox.Show("Ekleme Basarısız!");
            con.Close();

            Form4 f4 = new Form4();


            this.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

    }
}
