using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Projem
{
    class Database
    {
        static string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=giris.mdb";
        public static OleDbConnection baglan()
        {
            OleDbConnection con = new OleDbConnection(cs);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA: " + ex.Message);
            }
            return con;
        }
    }
}
