using SVC_BLL;
using SVC_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class Configuracao : Form
    {
        ConfiguracoesBLL entidade;
        int codigo = 0;

        public Configuracao()
        {
            InitializeComponent();
            entidade = new ConfiguracoesBLL();
            entidade.localizar();
            codigo = entidade.codigo;

            trend_cnpj.Text = entidade.cnpj_softwarehouse;
            trend_codigo_vinculacao.Text = entidade.codigo_vinculacao;

            emp_reducao.Text = entidade.emp_reducao;
            emp_tributos.Text = entidade.emp_tributos;

            acbr_path.Text = entidade.acbr_path;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.entidade = new ConfiguracoesBLL();

                valida_campos();
                ConfiguracoesDAL cmd = new ConfiguracoesDAL();

                if (this.codigo == 0)
                {
                    codigo = cmd.inserir(entidade.cnpj_softwarehouse, entidade.codigo_vinculacao, entidade.emp_tributos, entidade.emp_reducao, entidade.acbr_path);
                    if (codigo > 0)
                        MessageBox.Show("Configuração Salva com sucesso !");
                }
                else
                {
                    codigo = cmd.inserir2(entidade.cnpj_softwarehouse, entidade.codigo_vinculacao, entidade.emp_tributos, entidade.emp_reducao, entidade.acbr_path);
                    if (codigo > 0)
                        MessageBox.Show("Configuração atualizada com sucesso !");
                    
                }
                //else
                //cmd.atualiza();





                //TrendConfig cmd = new TrendConfig();


                //if()



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void valida_campos()
        {
            // Dados da Empresa ====================================

            if (emp_tributos.Text.Length > 0)
                this.entidade.emp_tributos = emp_tributos.Text;
            else
                this.entidade.emp_tributos = "0";

            if (emp_reducao.Text.Length > 0)
                this.entidade.emp_reducao = emp_reducao.Text;
            else
                this.entidade.emp_reducao = "0";
            // 11.444.406/0001-80

            this.entidade.vendedor_final = check_vendedor_final.Checked;


            // ACBR =================================================

            if (acbr_path.Text.Length > 0)
                entidade.acbr_path = acbr_path.Text;
            else
                entidade.acbr_path = "";
            
            // SOFTWARE HOUSE =======================================

            // CNPJ Software House
            if (trend_cnpj.Text.Length >= 14)
                this.entidade.cnpj_softwarehouse = trend_cnpj.Text;
            else
                throw new Exception("CNPJ da Software House invalido !");

            //codigo vinculacao
            if (trend_codigo_vinculacao.Text.Length > 13)
                this.entidade.codigo_vinculacao = trend_codigo_vinculacao.Text;
            else
                throw new Exception("Código de vinculação do contribuinte com a software house invalido !");

        }

        private void button2_Click(object sender, EventArgs e){
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                acbr_path.Text = folderBrowserDialog1.SelectedPath;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {

        }

        private void acbr_path_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
