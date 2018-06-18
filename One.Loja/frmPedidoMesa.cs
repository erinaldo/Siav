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
    public partial class frmPedidoMesa : Form
    {
        public string Codigo { get; set; }
        public bool Finaliza { get; set; }
        public bool EDisponivel { get; set; }

        public frmPedidoMesa()
        {
            InitializeComponent();
        }

        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        VendasDAL objVen = new VendasDAL();
        Button btnDisp = null;
        int posVertDisp = 0;
        Button btnOcup = null;
        int posVertOcup = 0;

        Button btnAtendente = null;
        int posAtendente = 0;

        private void carregarPanelMesasDisponivel()
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                DataTable tab = ConsultarMesas(0);
                flowLayoutDiponivel.AutoScroll = true;
                flowLayoutDiponivel.Controls.Clear();
                flowLayoutDiponivel.Update();
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    btnDisp = new Button();
                    btnDisp.Text = tab.Rows[i]["Numero"].ToString();
                    btnDisp.Name = tab.Rows[i]["Numero"].ToString();
                    btnDisp.BackColor = Color.White;
                    //if (tab.Rows[i]["Imagem"].ToString() != "")
                    //{
                    //byte[] data0 = (byte[])tab.Rows[i]["Imagem"];
                    //MemoryStream ms0 = new MemoryStream(data0);
                    //System.Drawing.Image bitMap = System.Drawing.Image.FromStream(ms0);
                    //btn.BackgroundImage = bitMap;
                    //
                    //this.btnDisp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    //this.btnDisp.BackgroundImage = global::One.Loja.Properties.Resources.VERDE_NOVO;
                    //
                    //data0 = null;
                    //ms0 = null;
                    flowLayoutDiponivel.Update();
                    //}
                    btnDisp.TextAlign = ContentAlignment.BottomCenter;
                    btnDisp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
                    btnDisp.ForeColor = Color.White;
                    btnDisp.BackColor = Color.Green;
                    //Info Buton 
                    btnDisp.FlatStyle = FlatStyle.Flat;
                    btnDisp.Click += btnDisp_Click;
                    btnDisp.Location = new Point(20, posVertDisp);
                    btnDisp.Left = 20;
                    btnDisp.Top = posVertDisp;
                    btnDisp.Width = 100;
                    btnDisp.Height = 100;
                    btnDisp.Font = new Font("Tahoma", 18, FontStyle.Bold);
                    posVertDisp = posVertDisp + 100;
                    flowLayoutDiponivel.Controls.Add(btnDisp);
                    flowLayoutDiponivel.HorizontalScroll.Enabled = true;

                    btnDisp.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                    btnDisp.ContextMenuStrip.Items.Add("Detalhes");
                    btnDisp.ContextMenuStrip.Click += ContextMenuStrip_Click;
                    flowLayoutDiponivel.Update();
                    lblQuantidade.Text = flowLayoutDiponivel.Controls.Count.ToString();
                }
                tab = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void carregarPanelMesasOcupadas(int Atendente)
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                //DataTable tab = ConsultarMesas(1);
                DataTable tab = ConsultarMesasOcupada(Atendente);
                flowLayoutOcupadas.AutoScroll = true;
                flowLayoutOcupadas.Controls.Clear();
                flowLayoutOcupadas.Update();
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    btnOcup = new Button();
                    btnOcup.Text = tab.Rows[i]["Numero"].ToString();// +" " + tab.Rows[i]["Atendente"].ToString();
                    btnOcup.Name = tab.Rows[i]["Numero"].ToString();
                    btnOcup.BackColor = Color.White;
                    //if (tab.Rows[i]["Imagem"].ToString() != "")
                    //{
                    //byte[] data0 = (byte[])tab.Rows[i]["Imagem"];
                    //MemoryStream ms0 = new MemoryStream(data0);
                    //System.Drawing.Image bitMap = System.Drawing.Image.FromStream(ms0);
                    //btn.BackgroundImage = bitMap;

                    //this.btnOcup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    //this.btnOcup.BackgroundImage = global::One.Loja.Properties.Resources.VERMELHO_NOVO;
                    //data0 = null;

                    //ms0 = null;
                    flowLayoutOcupadas.Update();
                    //}
                    btnOcup.TextAlign = ContentAlignment.BottomCenter;
                    btnOcup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
                    btnOcup.ForeColor = Color.White;
                    btnOcup.BackColor = Color.Red;
                    //Info Buton 
                    btnOcup.FlatStyle = FlatStyle.Flat;
                    btnOcup.Click += btn_Click;
                    btnOcup.Location = new Point(20, posVertOcup);
                    btnOcup.Left = 20;
                    btnOcup.Top = posVertOcup;
                    btnOcup.Width = 100;
                    btnOcup.Height = 100;
                    btnOcup.Font = new Font("Tahoma", 25, FontStyle.Bold);
                    posVertOcup = posVertOcup + 100;
                    flowLayoutOcupadas.Controls.Add(btnOcup);
                    flowLayoutOcupadas.HorizontalScroll.Enabled = true;
                    //Envento Menu Strip 
                    btnOcup.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                    btnOcup.ContextMenuStrip.Items.Add("Detalhes");
                    btnOcup.ContextMenuStrip.Name = i.ToString();
                    btnOcup.ContextMenuStrip.Click += ContextMenuStripOcup_Click;
                    btnOcup.ContextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;
                    //Envento Mouse Move
                    this.btnOcup.MouseHover += new System.EventHandler(this.btnOcup_MouseHover);
                    flowLayoutOcupadas.Update();
                    lblQuantidade.Text = flowLayoutOcupadas.Controls.Count.ToString();
                }
                tab = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Detalhes":
                    try
                    {
                        ContextMenuStrip cont = sender as ContextMenuStrip;
                        DataTable tab = null;
                        DataTable tab2 = null;
                        tab2 = ConsultaDetalheMesaVendas(int.Parse(cont.Name));
                        tab = ConsultaDetalheMesa(int.Parse(cont.Name));
                        dgDetalheMesa.DataSource = tab;
                        dgDetalhes.DataSource = tab2;
                        this.dgDetalheMesa.Columns[2].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Trocar":
                        
                    break;
            }
        }

        private void ContextMenuStrip_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cont = sender as ContextMenuStrip;
            MessageBox.Show(cont.SourceControl.Text.ToString());
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {

            Button btnDisp = sender as Button;
            Codigo = btnDisp.Name;
            Finaliza = false;
            frmPDVSkin frm = new frmPDVSkin("0");
            //  frm.CarregarToushMesa(Finaliza,Codigo);
            frm.txtTicket.Enabled = true;
            frm.txtTicket.Visible = true;
            carregarPanelMesasDisponivel();
            carregarPanelMesasOcupadas(0);
            frm = null;
            Contexto con = new Contexto();
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("UPDATE  Mesa SET status=@status Where MesaID = @id");
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Codigo;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int)).Value = 1;
                con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            this.Close();
        }

        private void ContextMenuStripOcup_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btnOcup = sender as Button;
            Codigo = btnOcup.Name;
            Finaliza = true;
            frmPDVSkin frm = new frmPDVSkin("0");
            //frm.txtLocalizarMesa.Text = Codigo;
            carregarPanelMesasOcupadas(0);
            DataTable tab = null;
            DataTable tab2 = null;
            tab2 = ConsultaDetalheMesaVendas(int.Parse(btnOcup.Name));
            tab = ConsultaDetalheMesa(int.Parse(btnOcup.Name));
            dgDetalheMesa.DataSource = tab;
            dgDetalhes.DataSource = tab2;
            this.dgDetalheMesa.Columns[2].Visible = false;
            carregarPanelMesasDisponivel();
            frm = null;
            Contexto con = new Contexto();
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("UPDATE  Mesa SET status=@status Where MesaID = @id");
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Codigo;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int)).Value = 0;
                con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            this.Close();
        }

        private void btnOcup_MouseHover(object sender, EventArgs e)
        {
            DataTable tab = null;
            DataTable tab2 = null;
            Button cont = sender as Button;
            if (cont.Text != "")
            {

                tab2 = ConsultaDetalheMesaVendas(int.Parse(cont.Name));
                tab = ConsultaDetalheMesa(int.Parse(cont.Name));
                dgDetalheMesa.DataSource = tab;
                dgDetalhes.DataSource = tab2;
                this.dgDetalheMesa.Columns[2].Visible = false;
            }
            else
            {
                tab = null;
                tab2 = null;
            }
        }

        private void frmControleMesas_Load(object sender, EventArgs e)
        {

            carregarPanelMesasOcupadas(0);
            dgDetalheMesa.ClearSelection();
            dgDetalheMesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgDetalhes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            lblInfoOcup.Text = "(Disponivél)";
            carregarPanelMesasDisponivel();

        }

        public DataTable ConsultarMesas(int Status)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * From Mesa Where Status = @Status");
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int)).Value = Status;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable ConsultarMesasOcupada(int Atendente)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * From Mesa Where Status =1");
                // String.Concat("Select at.Numero 'Numero',usu.usu_codigo , usu.usu_nome 'Atendente' ",
                // " from Mesa  at  join vendas v on v.ven_ticket = at.Numero  ",
                //"  join usuario usu on usu.usu_codigo =v.ven_usuario ",
                //" where at.Status = 1 and (v.ven_usuario = @Atendente or @Atendente = 0) and usu_status = 'Ativo'");
                cmd.Parameters.Add(new SqlParameter("@Atendente", SqlDbType.Int)).Value = Atendente;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable ConsultarAtendente()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select usu.usu_codigo 'ID', usu.usu_nome 'Nome' from Usuario usu");
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable ConsultaDetalheMesa(int Mesa)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                    " Select Tipo = 'Mesa               :' , Valor =Convert(Varchar,Numero),ord = 1 From Mesa Where Numero =@Mesa",
                    " union ",
                    " Select Tipo = 'Atendente           :' , Valor = Usu.usu_nome  ,ord = 2 From AtendimentoMesa Atm Join Usuario Usu on Usu.usu_codigo = Atm.Atendente Where NumeroMesa = @Mesa and Atm.Status = 1",
                    " union ",
                    " Select  Tipo = 'Hora Abertura      :' , Valor = Substring(Convert(varchar,HoraAbertura),1,8),ord = 3 From AtendimentoMesa at Where at.NumeroMesa = @Mesa and At.Status = 1",
                    " Union ",
                    " Select  Tipo = 'T O T A L         :' , Valor = Convert(Varchar,ven_valorFinal), ord =5     From Vendas Where ven_ticket = @Mesa"
                    );
                cmd.Parameters.Add(new SqlParameter("@Mesa", SqlDbType.Int)).Value = Mesa;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable ConsultaDetalheMesaVendas(int Mesa)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                    " Select ",
                    "  vi.pro_codigo 'Cod.'",
                    " ,	prod.pro_nome 'Desc.'",
                    " , vi.vi_valorUnitario 'Valor' ",
                    " ,	vi.vi_quantidade	'QTD'",
                    " , vi.vi_subtotal	'SubTotal'",
                    " From Vendas v",
                    " Join vendaItens vi on vi.ven_codigo = v.ven_codigo",
                    " Join Produtos prod on prod.pro_codigo = vi.pro_codigo",
                    " Where v.ven_ticket = @Mesa "
                    );
                cmd.Parameters.Add(new SqlParameter("@Mesa", SqlDbType.Int)).Value = Mesa;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {

        }

        private void LoadPedido()
        {
            try
            {
                if (EDisponivel == false)
                {
                    tabMesas.SelectedIndex = 1;
                    ((Control)this.tabMesas.TabPages[1]).Enabled = true;
                    ((Control)this.tabMesas.TabPages[0]).Enabled = false;

                }
                else
                {
                    tabMesas.SelectedIndex = 0;
                    ((Control)this.tabMesas.TabPages[1]).Enabled = false;
                    ((Control)this.tabMesas.TabPages[0]).Enabled = true;
                }
                carregarPanelMesasDisponivel();
                carregarPanelMesasOcupadas(0);
                dgDetalheMesa.ClearSelection();
                dgDetalheMesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgDetalhes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                lblInfoOcup.Text = "(Disponivél)";

            }
            catch (Exception EX)
            {

                MessageBox.Show("Ocorreu um erro:  " + EX.Message);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmPedido_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    break;

                case Keys.F12:
                    this.Close();
                    break;

                //case Keys.F2:
                //    CalcularTotal();
                //    break;

                case Keys.F1:
                    break;

                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void gvPesquisa_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            /* Pegando valor de uma celula do DataGridView */
            string valor = dgv.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (valor == "FATURADO")
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            }
            else
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carregarPanelAtendimento()
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                DataTable tab = ConsultarAtendente();
                flowLayoutAtendente.AutoScroll = true;
                flowLayoutAtendente.Controls.Clear();
                flowLayoutAtendente.Update();
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    btnAtendente = new Button();
                    btnAtendente.Text = tab.Rows[i]["Nome"].ToString();
                    btnAtendente.Name = tab.Rows[i]["ID"].ToString();
                    btnAtendente.BackColor = Color.White;
                    //if (tab.Rows[i]["Imagem"].ToString() != "")
                    //{
                    //byte[] data0 = (byte[])tab.Rows[i]["Imagem"];
                    //MemoryStream ms0 = new MemoryStream(data0);
                    //System.Drawing.Image bitMap = System.Drawing.Image.FromStream(ms0);
                    //btn.BackgroundImage = bitMap;
                    this.btnAtendente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    //  this.btnAtendente.BackgroundImage = global::OneManagerRestor.Properties.Resources.fornecedor_imoveis;
                    //data0 = null;
                    //ms0 = null;
                    flowLayoutAtendente.Update();
                    //}
                    btnAtendente.TextAlign = ContentAlignment.BottomCenter;
                    btnAtendente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
                    btnAtendente.ForeColor = Color.Black;
                    //Info Buton 
                    btnAtendente.FlatStyle = FlatStyle.Flat;
                    btnAtendente.Click += btnAtendente_Click;
                    btnAtendente.Location = new Point(20, posVertDisp);
                    btnAtendente.Left = 20;
                    btnAtendente.Top = posVertDisp;
                    btnAtendente.Width = 70;
                    btnAtendente.Height = 70;
                    btnAtendente.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    posVertDisp = posVertDisp + 70;
                    flowLayoutAtendente.Controls.Add(btnAtendente);
                    flowLayoutAtendente.HorizontalScroll.Enabled = true;

                    btnAtendente.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
                    btnAtendente.ContextMenuStrip.Items.Add("Detalhes");
                    btnAtendente.ContextMenuStrip.Click += ContextMenuStrip_Click;
                    flowLayoutAtendente.Update();

                }
                tab = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAtendente_Click(object sender, EventArgs e)
        {
            Button btnAte = sender as Button;
            carregarPanelMesasOcupadas(int.Parse(btnAte.Name));

        }

        private void tabMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMesas.SelectedIndex == 0)
            {
                TabCarregarMesaDisponivel();
                ((Control)this.tabMesas.TabPages[0]).Enabled = true;
                ((Control)this.tabMesas.TabPages[1]).Enabled = false;
            }
            else
            {
                TabCarregarMesaOcupada();
                ((Control)this.tabMesas.TabPages[1]).Enabled = true;
                ((Control)this.tabMesas.TabPages[0]).Enabled = false;
            }
        }

        private void TabCarregarMesaOcupada()
        {
            carregarPanelMesasOcupadas(0);
            dgDetalhes.DataSource = null;
            dgDetalheMesa.DataSource = null;
            lblItensVendas.Visible = true;
            lblResumoGeral.Visible = true;
            pnlInferioItensVendas.Visible = true;
            pnlSupGeralVendas.Visible = true;
            int TamanhoNormal = this.pnlCentralMesas.Width;
            int TamanhoDinamico = 360;
            int TamanhoFinal = TamanhoNormal - TamanhoDinamico;
            this.pnlCentralMesas.Width = TamanhoFinal;
            lblQuantidade.Text = flowLayoutOcupadas.Controls.Count.ToString();
            lblInfoOcup.Text = "(Ocupadas)";
            carregarPanelAtendimento();
        }

        private void TabCarregarMesaDisponivel()
        {
            carregarPanelMesasDisponivel();
            dgDetalhes.DataSource = null;
            dgDetalheMesa.DataSource = null;
            lblItensVendas.Visible = false;
            lblResumoGeral.Visible = false;
            pnlInferioItensVendas.Visible = false;
            pnlSupGeralVendas.Visible = false;
            int TamanhoNormal = this.pnlCentralMesas.Width;
            int TamanhoDinamico = 360;
            int TamanhoFinal = TamanhoNormal + TamanhoDinamico;
            lblQuantidade.Text = flowLayoutDiponivel.Controls.Count.ToString();
            this.pnlCentralMesas.Width = TamanhoFinal;
            lblInfoOcup.Text = "(Disponivél)";
        }

        private void pnlCentralMesas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPedido_Shown(object sender, EventArgs e)
        {
            LoadPedido();
        }
    }
}
