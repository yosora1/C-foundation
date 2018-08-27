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

namespace LoginDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //验证用户登录是否成功
        private void Lgoin_Click(object sender, EventArgs e)
        {
            //采集数据
            String userName = txtLoginName.Text.Trim();
            String passWord = txtLoginPwd.Text;

            //连接数据库校验登录是否成功
            string path = "Data Source=DESKTOP-40POHN9;Initial Catalog=Test;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(path))
            {
                string sql = "select password from UserTable where Name=@userName";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlParameter paramUserName = new SqlParameter("@userName", SqlDbType.NChar, 10)
                    {
                        Value=userName
                    }; 
                    cmd.Parameters.Add(paramUserName);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                System.Diagnostics.Debug.WriteLine(reader.GetString(0).Trim() == passWord);
                                if (reader.GetString(0).Trim() == passWord)
                                {
                                    MessageBox.Show("欢迎");
                                }
                                else
                                {
                                    MessageBox.Show("密码不正确");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户不存在");
                        }
                    }
                }
            }
        }
    }
}
