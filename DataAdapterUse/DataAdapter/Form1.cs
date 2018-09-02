using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constr = "Data Source=DESKTOP-40POHN9;Initial Catalog=Test;Integrated Security=True";
            String sql = "select * from UserTable";
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter=new SqlDataAdapter(sql,constr))
            {
                adapter.Fill(dt);
            }
            this.dataGridView1.DataSource = dt;
        }
    }
}
