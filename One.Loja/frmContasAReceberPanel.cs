using One.Bll;
using One.Dal;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmContasAReceberPanel : Form
    {
        public frmContasAReceberPanel()
        {
            InitializeComponent();
        }
        public DataTable LocalizarGeralVendas()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat(
                               " Select ID = cli.cli_codigo ,",
	                              "  Cliente = cli.cli_nome ",
                               " ,	Valor   = sum(cr.cr_valorAlterado) ",
                               " From Vendas v",
                               " Join ContasAReceber cr on cr.cr_vendas= v.ven_codigo ",
                               " Join Cliente cli on cli.cli_codigo = v.ven_cliente ",
                               " Where cr.cr_status = 'Aberto' and v.ven_cliente <>1",
                               " Group by cli.cli_nome ,cli.cli_codigo",
                               " order by Cliente"
                        );
                    //cmd.Parameters.AddWithValue("@ID", ID);
                    using (Contexto contexto = new Contexto())
                    {
                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable LocalizarVendasClienteEmAberto(int ID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat(
                               " Select ID = v.ven_codigo,",
                               " Data = Convert(varchar, v.ven_dataVenda, 103) ",
                               " , Valor = (cr.cr_valorAlterado) ",
                               " From Vendas v",
                               " Join ContasAReceber cr on cr.cr_vendas= v.ven_codigo ",
                               " Join Cliente cli on cli.cli_codigo = v.ven_cliente ",
                               " Where cr.cr_status = 'Aberto' and v.ven_cliente <>1 and v.ven_Cliente = @ID",
                               " order by Data"
                        );
                    cmd.Parameters.AddWithValue("@ID", ID);
                    using (Contexto contexto = new Contexto())
                    {
                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmContasAReceberPanel_Load(object sender, EventArgs e)
        {

        }

        private void frmContasAReceberPanel_Shown(object sender, EventArgs e)
        {

            CarregarResumoGeralContas();
        }

        private void CarregarResumoGeralContas()
        {
            dgGeral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataTable tabGeralContas = null;
            tabGeralContas = LocalizarGeralVendas();
            dgGeral.DataSource = tabGeralContas;
        }

        private void dgGeral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgGeral.Rows.Count)
                {
                    int cod = 0;
                    string NomeCliente = "";
                    NomeCliente = dgGeral.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cod = int.Parse(dgGeral.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {
                        dgItensVendas.DataSource = null;
                        DataTable tabItensVenda = null;
                        tabItensVenda = LocalizarVendasClienteEmAberto(cod);
                        dgVendas.DataSource = tabItensVenda;
                        txtCodigoCliente.Text = cod.ToString();
                        txtNomeCliente.Text = NomeCliente.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgVendas.Rows.Count)
                {
                    int cod = 0;
                    cod = int.Parse(dgVendas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {
                        vendaItensDAL vi = new vendaItensDAL();
                        DataTable tabItensVendaItens = null;
                        tabItensVendaItens = vi.localizarLeaveID(cod);
                        dgItensVendas.DataSource = tabItensVendaItens;
                        vi = null;
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtCodigoCliente.Text == String.Empty)
                {
                    throw new Exception("Selecione um cliente para efeturar o pagamento");
                }
                frmContasAReceber frm = new frmContasAReceber();
                frm.CodigoCliente = int.Parse(txtCodigoCliente.Text);
                frm.ShowDialog();
                CarregarResumoGeralContas();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }
        }
    }