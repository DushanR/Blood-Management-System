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
    public partial class Rep : KryptonForm
    {
        public Rep()
        {
            InitializeComponent();
        }

        private void Rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Static_Report.ruser' table. You can move, or remove it, as needed.
            this.ruserTableAdapter.Fill(this.Static_Report.ruser);

            this.reportViewer2.RefreshReport();
        }
    }
}
