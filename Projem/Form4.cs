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
    public partial class Form4 : Form
    {
        List<int> indisListesi = new List<int>();
        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommandBuilder cmdb;
        OleDbCommand cmd;
        public Form4()
        {
            InitializeComponent();
        }
        void TabloDoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
            da = new OleDbDataAdapter("SElect *from film", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "film");
            dataGridView1.DataSource = ds.Tables["film"];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            f5.FormClosing += f5_FormClosing;
            this.Visible = false;
            
        }

        void f5_FormClosing(object sender, FormClosingEventArgs e)
        {
            OleDbConnection con = Database.baglan();
            TabloDoldur();
            this.Show();
            //throw new NotImplementedException();
        }

        void KayıtSil(int numara)
        {
            string OleDb = "DELETE FROM film WHERE film_no=@numara";
            cmd = new OleDbCommand(OleDb, con);
            cmd.Parameters.AddWithValue("@film_no", numara);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            OleDbConnection con = Database.baglan();
            TabloDoldur();
            
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
            con.Open();
            da = new OleDbDataAdapter("Select * from film", con);
            ds = new DataSet();
            da.Fill(ds, "film");
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(numara);
            }
            TabloDoldur();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.FormClosing += f2_FormClosing;
            Hide();

        }

        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmdb = new OleDbCommandBuilder(da);
            da.Update(ds, "film");
            MessageBox.Show("Kayıt güncellendi");
        }


   
    }
}
