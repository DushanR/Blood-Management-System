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

namespace Final_Project
{
    public partial class home : KryptonForm
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private int imageNumber = 1;
        private void LoadNextImage()
        {
            if (imageNumber == 7)
            {
                imageNumber = 1;
            }
            slider.ImageLocation = string.Format(@"images\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void btn_doner_Click(object sender, EventArgs e)
        {
            panel1.Height = btn_doner.Height;
            panel1.Top = btn_doner.Top;
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

        private void btn_stock_Click(object sender, EventArgs e)
        {
            this.Hide();
            stock obj = new stock();
            obj.ShowDialog();
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

        private void btn_report_Click(object sender, EventArgs e)
        {
            
            Form2 obj = new Form2();
            obj.ShowDialog();
        }
    }
}
