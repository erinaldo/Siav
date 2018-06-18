using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One
{
    public partial class super_grid : Form
    {
        public super_grid(DataTable x)
        {
            InitializeComponent();
            dataGridView1.DataSource = x;
        }

        private void super_grid_Load(object sender, EventArgs e)
        {

        }
    }
}
