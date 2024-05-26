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
    public partial class doner : KryptonForm
    {
        public doner()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void btn_patient_Click(object sender, EventArgs e)
        {
            this.Hide();
            patient obj = new patient();
            obj.ShowDialog();
        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            this.Hide();
            stock obj = new stock();
            obj.ShowDialog();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.ShowDialog();
        }


        private void doner_Load(object sender, EventArgs e)
        {
            try
            {


                Con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");
                Con.Open();
                da = new SqlDataAdapter("select * from Doner", Con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_id.Clear();
            txt_age.Clear();
            txt_address.Clear();
            txt_tp.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {



        }


        private void label9_Click(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Are you sure to logout", "logout", MessageBoxButtons.YesNo);
            if (Dialog == DialogResult.Yes)
            {

                MessageBox.Show("Logout Successfuly", "info", MessageBoxButtons.OK);
                this.Hide();
                login obj = new login();
                obj.ShowDialog();
            }
        }

        private void btn_save_Click_1(object sender, EventArgs e)
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
                else if (txt_id.Text.Length == 0)
                {
                    MessageBox.Show("Doner ID can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_tp.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Please enter a Telephone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_tp.Text.Length < 10)
                {
                    MessageBox.Show("Check telephone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_tp.Text.Length > 10)
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


                else
                {



                    String Doner_Name, Doner_Address, Doner_gender, Doner_bloodgroup;
                    int Doner_Id, Doner_Age, Doner_TP;

                    Doner_Name = txt_name.Text;
                    Doner_Id = Convert.ToInt32(txt_id.Text);
                    Doner_Age = Convert.ToInt32(txt_age.Text);
                    Doner_TP = Convert.ToInt32(txt_tp.Text);
                    Doner_Address = txt_address.Text;

                    if (rb_male.Checked == true)
                    {
                        Doner_gender = "Male";
                    }
                    else
                    {
                        Doner_gender = "Female";
                    }

                    Doner_bloodgroup = combo_blood.Text;




                    Con.Open();
                    cmd = new SqlCommand("Insert into Doner(Doner_Id,Doner_Name,Doner_Address,Doner_Age,Doner_TP,Doner_bloodgroup,Doner_gender) values('" + Doner_Id + "','" + Doner_Name + "','" + Doner_Address + "','" + Doner_Age + "','" + Doner_TP + "','" + Doner_bloodgroup + "','" + Doner_gender + "')", Con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {

                        MessageBox.Show("Data saved sucessfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        doner obj = new doner();
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

            catch (FormatException)
            {
                MessageBox.Show("Doner ID Can be number only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show("Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("Are you sure to logout", "logout", MessageBoxButtons.YesNo);
            if (Dialog == DialogResult.Yes)
            {

                MessageBox.Show("Logout Successfuly", "info", MessageBoxButtons.OK);
                this.Hide();
                login obj = new login();
                obj.ShowDialog();
            }
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            
            Form2 obj = new Form2();
            obj.ShowDialog();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 obj = new Form3();
            obj.ShowDialog();
            
        }
    }
}

