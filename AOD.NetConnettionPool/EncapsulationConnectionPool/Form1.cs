using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncapsulationConnectionPool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "select count(*) from UserTable where id=@ID";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@ID",SqlDbType.Int,10){Value=textBox2.Text.Trim()}
            };
            int i=(int)SqlHelper.ExecuteScalar(sql,pms);
            if (i > 0)
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<UserClass> list = new List<UserClass>();
            String sql = "select * from UserTable";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserClass user = new UserClass();
                        user.ID = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.password = reader.GetString(2);
                        list.Add(user);
                    }
                }
            }
            MessageBox.Show(list.Count.ToString());
        }
    }
}
