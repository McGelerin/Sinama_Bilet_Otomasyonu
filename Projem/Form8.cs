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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        DataSet ds;
        
        void TabloDoldur()
        
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb");
            da = new OleDbDataAdapter("SElect *from veri", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "veri");
            dataGridView1.DataSource = ds.Tables["veri"];
            con.Close();
        }
        
        private void Form8_Load(object sender, EventArgs e)
        {
            OleDbConnection con = Database.baglan();
            TabloDoldur();

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
