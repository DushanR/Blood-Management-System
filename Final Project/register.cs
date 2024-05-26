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
    public partial class register : KryptonForm
    {
        public register()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login obj = new login();
            obj.ShowDialog();
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            txt_address.Clear();
            txt_age.Clear();
            txt_cpassword.Clear();
            txt_name.Clear();
            txt_password.Clear();
            txt_phone.Clear();
        }

        private void register_Load(object sender, EventArgs e)
        {
            

            try
            {


                Con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");
                Con.Open();
                da = new SqlDataAdapter("select * from ruser", Con);
                Con.Close();

            }


            catch (FormatException)
            {
                MessageBox.Show("Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {


                if (txt_name.Text.Length == 0)
                {
                    MessageBox.Show("Name can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_name.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Name can not be have numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_phone.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Please enter a Telephone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_phone.Text.Length < 10)
                {
                    MessageBox.Show("Check telephone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_phone.Text.Length > 10)
                {
                    MessageBox.Show("Check telephone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_address.Text.Length == 0)
                {
                    MessageBox.Show("Address can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_age.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Please enter a age", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_age.Text.Length == 0)
                {
                    MessageBox.Show("Age can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_password.Text.Length == 0)
                {
                    MessageBox.Show("Passwords can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_cpassword.Text.Length == 0)
                {
                    MessageBox.Show("Passwords can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_password.Text != txt_cpassword.Text)
                {
                    MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                else
                {



                    String User_fullname, User_Address, User_gender, User_bloodgroup, User_password, User_cpassword;
                    int User_Age, User_TP;

                    User_fullname = txt_name.Text;
                    User_Age = Convert.ToInt32(txt_age.Text);
                    User_TP = Convert.ToInt32(txt_phone.Text);
                    User_Address = txt_address.Text;


                    if (rb_male.Checked == true)
                    {
                        User_gender = "Male";
                    }
                    else
                    {
                        User_gender = "Female";
                    }


                    User_bloodgroup = combo_blood.Text;
                    User_password = txt_password.Text;
                    User_cpassword = txt_cpassword.Text;




                    Con.Open();
                    cmd = new SqlCommand("Insert into ruser(User_fullname,User_address,User_Age,User_TP,User_bloodgroup,User_gender,User_password,User_cpassword) values('" + User_fullname + "','" + User_Address + "','" + User_Age + "','" + User_TP + "','" + User_bloodgroup + "','" + User_gender + "','" + User_password + "','" + User_cpassword + "')", Con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {



                        this.Hide();
                        sucessfully obj = new sucessfully();
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Data can not save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    Con.Close();
                    Con.Dispose();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
