using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Final_Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection Con;
        SqlCommand cmd;
        SqlDataAdapter da;


        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {


                Con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");
                Con.Open();
                da = new SqlDataAdapter("select * from Doner", Con);
                DataTable dt = new DataTable();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter admin password");
            }
            else if (txt_id.Text.Length == 0)
            {
                MessageBox.Show("Please enter doner id");
            }

            else if (textBox1.Text == "dush")
            {
                if (txt_id.Text.Length == 0)
                {
                    MessageBox.Show("Enter valaid Doner Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Con.Open();

                    int Doner_Id;
                    Doner_Id = Convert.ToInt32(txt_id.Text);

                    cmd = new SqlCommand("delete from Doner where Doner_Id = '" + txt_id.Text + "'", Con);
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
            else
            {
                MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            doner obj = new doner();
            obj.ShowDialog();
        }
    }
}
