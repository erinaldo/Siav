using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmVisualizarCupom : Form
    {
        public frmVisualizarCupom()
        {
            InitializeComponent();
        }
        public String TextoCupom { get; set; }
        private void frmVisualizarCupom_Load(object sender, EventArgs e)
        {
            richTextBoxCupom.Text = TextoCupom.ToString();
        }
    }
}
