using DataAccessLayer.Dal;
using One.Bll;
using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace One.Scripts
{
    public partial class sqlserver_nova_versao : Form
    {
        public sqlserver_nova_versao()
        {
            InitializeComponent();
        }

        private void sqlserver_nova_versao_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            Contexto cmd = new Contexto();
            cmd.Contexto_local(nome_base.Text);

            try{
                cmd.AbreConexao();
                cmd.FechaConexao();
                MessageBox.Show("Conexão realizada com sucesso !");
            }catch{
                MessageBox.Show("Não foi possível se conectar !");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Contexto cmd = new Contexto();
            cmd.Contexto_local(nome_base.Text);

            try
            {
                cmd.AbreConexao();
                cmd.FechaConexao();

                nome_base.Enabled = false;
                timer1.Enabled = true;
                label1.Text = "Coletando Dados";
                label2.Text = "Inicializando";
                
                // Selecionando fornecedores
                //StringBuilder sb = new StringBuilder();
                //
                //cmd.AbreConexao();
                //DataTable dt = cmd.ExecutaConsulta(new SqlCommand() { CommandText = "select * from fornecedores"});
                //
                //foreach (DataRow r in dt.Rows){
                //    sb.Append("insert into fornecedores (for_razaoSocial,for_cnpj,for_ie,for_email,for_cep,for_logradouro,for_numero,for_complemento");
                //    sb.Append(",for_bairro,for_cidade,for_telefone,for_fax,for_status,for_cpf,for_rg,for_tipo_fornecedor,for_nome,for_tipo)");
                //    sb.Append("values('" + r["for_razaoSocial"].ToString() + "','" + r["for_cnpj"].ToString() + "','" + r["for_ie"] + "',");
                //    sb.Append("'" + r["for_email"].ToString() + "','" + r["for_cep"].ToString() + "','" + r["for_logradouro"].ToString() + "','" + r["for_numero"].ToString() + "','" + r["for_complemento"].ToString() + "',");
                //    sb.Append("'" + r["for_bairro"].ToString() + "','" + r["for_cidade"].ToString() + "','" + r["for_telefone"].ToString() + "',");
                //    sb.Append("'" + r["for_fax"].ToString() + "','" + r["for_status"].ToString() + "','" + r["for_cpf"].ToString() + "',");
                //    sb.Append("'" + r["for_rg"].ToString() + "','" + r["for_tipo_fornecedor"].ToString() + "','" + r["for_nome"].ToString() + "','" + r["for_tipo"].ToString() + "');");
                //}
                //
                //
                //cmd.ExecutaComando(new SqlCommand() { CommandText = sb.ToString() });
                //cmd.FechaConexao();




                // Selecionando 
            }
            catch
            {
                MessageBox.Show("Não foi possível se conectar !");
            }
        }

        Int32 atividade = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1 - Coletando Fabricantes
            // 
            //  - Coletando Clientes
            // 
            progressBar1.Maximum = 2;
            label1.Text = "Coletando Dados";
            Thread.Sleep(5000);

            if (atividade > 2)
            {
                label1.Text = "Coleta realizada com sucesso !";
                label2.Text = "...";
                timer1.Enabled = false;
                //progressBar1.Value = atividade;
            }
           

          
            if (atividade == 2)
            {
                label2.Text = "Selecionando Produtos";
                progressBar1.Value = atividade;
                atividade++;

                ProdutosBLL cmd = new ProdutosBLL();
                //DataTable dt = cmd.localizarComRetorno("", "pro_nome");

                Contexto sqlcmd = new Contexto();
                sqlcmd.Contexto_local(nome_base.Text);

                sqlcmd.AbreConexao();
                DataTable dt = sqlcmd.ExecutaConsulta(new SqlCommand() { CommandText = "select * from produtos" });
                sqlcmd.FechaConexao();

                foreach (DataRow dtRow in dt.Rows){
                    cmd.limpar();
                    cmd.pro_nome = dtRow["pro_nome"].ToString();
                    cmd.pro_quantidade = decimal.Parse(dtRow["pro_quantidade"].ToString());
                    cmd.pro_precoCusto = decimal.Parse(dtRow["pro_precoCusto"].ToString());
                    cmd.pro_precoVenda = decimal.Parse(dtRow["pro_precoVenda"].ToString());
                    cmd.pro_categoria = 0;
                    cmd.pro_grupo = 0;
                    cmd.pro_subGrupo = 0;
                    cmd.pro_unidade = 0;
                    cmd.pro_estoqueMin = int.Parse(dtRow["pro_estoqueMin"].ToString());
                    cmd.pro_estoqueMax = 0;
                    cmd.pro_dataCadastro = DateTime.Now;
                    cmd.pro_codigoBarra = dtRow["pro_codigoBarra"].ToString();
                    cmd.pro_marca = 0;
                    cmd.pro_fornecedor = 0;
                    cmd.pro_tamanho = 0;
                    cmd.pro_margem = 0;
                    cmd.pro_comissao = 0;
                    cmd.pro_aliquota = 0;
                    cmd.porcentagem_tributos = 0;
                    cmd.pro_csosn = "";
                    cmd.pro_cst = "";
                    cmd.cest = "";
                    cmd.pro_cst = "";
                    cmd.pro_imagem = null;
                    cmd.cfop = int.Parse(dtRow["pro_cfop"].ToString());
                    cmd.ncm = dtRow["pro_ncm"].ToString();
                    cmd.inserir();
                }

                
            }

            if (atividade == 1){
                label2.Text = "Selecionando Grupos";
                progressBar1.Value = atividade;
                atividade++;

                GrupoBLL cmd = new GrupoBLL();
                DataTable dt = cmd.localizarComRetorno("","gru_descricao");


                foreach (DataRow dtRow in dt.Rows) {
                    cmd.limpar();
                    try { cmd.gru_codigo = Int32.Parse(dtRow["gru_codigo"].ToString()); }catch { }
                    try { cmd.gru_descricao = dtRow["gru_descricao"].ToString(); } catch { }
                    cmd.inserir();
                }
            }
            
            if (atividade == 0)
            {
                label2.Text = "Selecionando Fabricantes";
                progressBar1.Value = atividade;
                atividade++;                

                FornecedoresBLL cmd = new FornecedoresBLL();
                DataTable dt = cmd.localizarComRetorno_SQLSERVER("", "", nome_base.Text);

                foreach (DataRow dtRow in dt.Rows){

                    cmd.limpar();
                    try{cmd.for_codigo = Int32.Parse(dtRow.ItemArray[0].ToString());}catch{}
                    try{cmd.for_cnpj = dtRow.ItemArray[2].ToString();}catch{}
                    try{cmd.for_ie = dtRow.ItemArray[3].ToString();}catch{}
                    try{cmd.for_email = dtRow.ItemArray[4].ToString();}catch{}
                    try{cmd.for_cep = dtRow.ItemArray[5].ToString();}catch{}
                    try{cmd.for_razaoSocial = dtRow.ItemArray[1].ToString();}catch{}
                    try{cmd.for_logradouro = dtRow.ItemArray[6].ToString();}catch{}
                    try{cmd.for_numero = dtRow.ItemArray[7].ToString();}catch{}
                    try{cmd.for_complemento = dtRow.ItemArray[8].ToString();}catch{}
                    try{cmd.for_bairro = dtRow.ItemArray[9].ToString();}catch{}
                    try{cmd.for_cidade = Int32.Parse(dtRow.ItemArray[10].ToString());}catch{}
                    try{cmd.for_telefone = dtRow.ItemArray[11].ToString();}catch{}
                    try{cmd.for_fax = dtRow.ItemArray[12].ToString();}catch{}
                    try{cmd.for_status = dtRow.ItemArray[13].ToString();}catch{}
                    try{cmd.for_cpf = dtRow.ItemArray[14].ToString();}catch{}
                    try{cmd.for_rg = dtRow.ItemArray[15].ToString();}catch{}
                    try{cmd.for_tipo_fornecedor = dtRow.ItemArray[16].ToString();}catch{}
                    try{cmd.for_nome = dtRow.ItemArray[17].ToString();}catch{}
                    try { cmd.for_tipo = dtRow.ItemArray[18].ToString(); }catch { }
                    cmd.inserir();
               
                }
            }

        }
    }
}
