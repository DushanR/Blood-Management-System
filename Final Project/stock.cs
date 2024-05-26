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
    public partial class stock : KryptonForm
    {
        public stock()
        {
            InitializeComponent();
            GetData();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-376L562;Initial Catalog=register;Integrated Security=True");

        private void GetData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Doner", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label9.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from patient", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            label13.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from ruser", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            label14.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '"+ "A+" +"'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            label15.Text = dt3.Rows[0][0].ToString();

            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "A-" + "'", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            label16.Text = dt4.Rows[0][0].ToString();

            SqlDataAdapter sda5 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "B+" + "'", con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            label17.Text = dt5.Rows[0][0].ToString();

            SqlDataAdapter sda6 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "B-" + "'", con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            label18.Text = dt6.Rows[0][0].ToString();

            SqlDataAdapter sda7 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "O+" + "'", con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            label19.Text = dt7.Rows[0][0].ToString();

            SqlDataAdapter sda8 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "O-" + "'", con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            label20.Text = dt8.Rows[0][0].ToString();

            SqlDataAdapter sda9 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "AB+" + "'", con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            label21.Text = dt9.Rows[0][0].ToString();

            SqlDataAdapter sda10 = new SqlDataAdapter("select count(*) from Doner where Doner_bloodgroup = '" + "AB-" + "'", con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            label22.Text = dt10.Rows[0][0].ToString();

            con.Close();
        }

        private void btn_doner_Click(object sender, EventArgs e)
        {
            this.Hide();
            doner obj = new doner();
            obj.ShowDialog();
        }

        private void btn_patient_Click(object sender, EventArgs e)
        {
            this.Hide();
            patient obj = new patient();
            obj.ShowDialog();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            home obj = new home();
            obj.ShowDialog();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.ShowDialog();
        }

    }
}
