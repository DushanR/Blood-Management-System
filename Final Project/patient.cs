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
    public partial class patient : KryptonForm
    {
        public patient()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void btn_doner_Click(object sender, EventArgs e)
        {
            this.Hide();
            doner obj = new doner();
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

        private void patient_Load(object sender, EventArgs e)
        {
            try
            {
                Con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");
                Con.Open();
                da = new SqlDataAdapter("select * from Patient", Con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void btn_save_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Patient ID can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



                    String Patient_Name, Patient_Address, Patient_gender, Patient_bloodgroup;
                    int Patient_ID, Patient_Age, Patient_TP;

                    Patient_Name = txt_name.Text;
                    Patient_ID = Convert.ToInt32(txt_id.Text);
                    Patient_Age = Convert.ToInt32(txt_age.Text);
                    Patient_TP = Convert.ToInt32(txt_tp.Text);
                    Patient_Address = txt_address.Text;

                    if (rb_male.Checked == true)
                    {
                        Patient_gender = "Male";
                    }
                    else
                    {
                        Patient_gender = "Female";
                    }

                    Patient_bloodgroup = combo_blood.Text;




                    Con.Open();
                    cmd = new SqlCommand("Insert into patient(Patient_ID,Patient_Name,Patient_Address,Patient_Age,Patient_TP,Patient_bloodgroup,Patient_gender) values('" + Patient_ID + "','" + Patient_Name + "','" + Patient_Address + "','" + Patient_Age + "','" + Patient_TP + "','" + Patient_bloodgroup + "','" + Patient_gender + "')", Con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {

                        MessageBox.Show("Data saved sucessfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        patient obj = new patient();
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
                MessageBox.Show("Patient ID Can be number only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Form4 obj = new Form4();
            obj.ShowDialog();
        }
    }
}
