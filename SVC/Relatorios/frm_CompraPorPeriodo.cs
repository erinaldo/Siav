using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using One.Dal;
namespace One.RELATORIOS
{
    public partial class frm_CompraPorPeriodo : Form
    {
        public frm_CompraPorPeriodo()
        {
            InitializeComponent();
        }
        public String controle = "Cancelado";
        public DateTime? dataInical = null;
        public DateTime? dataFinal = null;
        public String marca= "";
        public String grupo = "";

        private void frm_CompraPorPeriodo_Load(object sender, EventArgs e)
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                this.MaximumSize = new Size(this.Width, this.Height);
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbMarca, "Marcas", "mar_codigo", "mar_descricao", "", "");
                objD.PreencheComboBox(cbGrupo, "Grupo", "gru_codigo", "gru_descricao", "", "");
                objD = null;
                cbMarca.SelectedIndex = -1;
                cbGrupo.SelectedIndex = -1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                String dataI,dataF;
                dataI = dtpDataInicial.Value.Year.ToString() + "/"+dtpDataInicial.Value.Day.ToString() +"/"+ dtpDataInicial.Value.Month.ToString();
                dataF = dtpDataFinal.Value.Year.ToString() + "/" + dtpDataFinal.Value.Day.ToString() + "/" + dtpDataFinal.Value.Month.ToString();
                dataInical = dtpDataInicial.Value.Date;//DateTime.Parse(dataI);
                dataFinal = dtpDataFinal.Value.Date; //DateTime.Parse(dataF);

                if (cbMarca.SelectedIndex > -1)
                {
                    marca = cbMarca.SelectedValue.ToString();
                    MarcasBLL objBLL = new MarcasBLL();
                    objBLL.localizarLeave(marca, "mar_codigo");
                    marca = objBLL.mar_descricao;
                    objBLL = null;
                }
                else
                    marca = "";
                if (cbGrupo.SelectedIndex > -1)
                {
                    grupo = cbGrupo.SelectedValue.ToString();
                    GrupoBLL objBLL = new GrupoBLL();
                    objBLL.localizarLeave(marca, "gru_codigo");
                    grupo = objBLL.gru_descricao;
                    objBLL = null;
                }
                else
                    grupo = "";

                controle = "Gerar";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                controle = "";
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
