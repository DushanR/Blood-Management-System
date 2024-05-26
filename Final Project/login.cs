using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Final_Project
{
    public partial class login : KryptonForm
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlDataAdapter da;

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            txt_phone.Clear();
            txt_password.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            register obj = new register();
            obj.ShowDialog();
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Con.Open();
        
            {
                int User_TP;
                string User_password;
               
                
                User_TP = Convert.ToInt32(txt_phone.Text.ToString());
                User_password = txt_password.Text;

                try
                {
                    if (txt_phone.Text.Any(char.IsLetter))
                    {
                        MessageBox.Show("Please enter a Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txt_phone.Text.Length < 10)
                    {
                        MessageBox.Show("Check Mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txt_phone.Text.Length > 10)
                    {
                        MessageBox.Show("Check Mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txt_password.Text.Length == 0)
                    {
                        MessageBox.Show("Passwords can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string querry = "SELECT * from ruser WHERE User_TP = '"+txt_phone.Text.ToString()+"' AND User_password = '" + txt_password.Text+ "'";
                    SqlDataAdapter da = new SqlDataAdapter(querry, Con);

                    DataTable dtable = new DataTable();
                    da.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                       // System.Console.WriteLine("Test1");
                       // User_TP = Convert.ToInt32(txt_phone.Text);
                       // Console.WriteLine(User_TP);
                       // User_password = txt_password.Text;

                        this.Hide();
                        home obj = new home();
                        obj.ShowDialog();
                    }
                    else
                    {
                        System.Console.WriteLine("Test1");
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_phone.Clear();
                        txt_password.Clear();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show("Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");
            Con.Open();
            da = new SqlDataAdapter("select * from ruser", Con);
            Con.Close();
        }

        private void check_password_CheckedChanged(object sender, EventArgs e)
        {
            if (check_password.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
    }
}
