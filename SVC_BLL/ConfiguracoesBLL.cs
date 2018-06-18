using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class ConfiguracoesBLL{
        
        public int codigo { get; set; }

        public String emp_tributos { get; set; }
        public String emp_reducao { get; set; }

        public Boolean vendedor_final { get; set; }

        // TREND
        public String cnpj_softwarehouse { get; set; }
        public String codigo_vinculacao { get; set; }
        
        public configuracoes_ambiente ambiente { get; set; }
        public int n_nota { get; set; }
        public int controle_sequencia { get; set; }

        public String acbr_path { get; set; }
        
            
        ConfiguracoesDAL objDAL = null;

        public void inserir()
        {
            try{
                objDAL = new ConfiguracoesDAL();
                //objDAL.inserir(this.emp_regime.GetHashCode(), this.emp_razaoSocial, this.emp_nomeFantasia, this.emp_logradouro, this.emp_numero, this.emp_bairro, this.emp_cep, this.emp_estado, this.emp_cidade, this.emp_inscricaoEstadual, this.emp_cnpj, this.emp_telefone, this.emp_fax, this.emp_valorJuros, this.emp_multa, this.emp_qtdDias);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void popula_campos(){

        }

        public void localizar()
        {

            try
            {
                DataTable tab;
                objDAL = new ConfiguracoesDAL();
                tab = objDAL.localizar();
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["id"].ToString());
                    this.cnpj_softwarehouse = tab.Rows[0]["cnpj_sh"].ToString();
                    this.codigo_vinculacao = tab.Rows[0]["codigo_vinculacao"].ToString();
                    this.emp_reducao = tab.Rows[0]["empresa_reducao"].ToString();
                    this.emp_tributos = tab.Rows[0]["empresa_tributo"].ToString();
                    this.acbr_path = tab.Rows[0]["acbr_path"].ToString();
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }


    public enum configuracoes_ambiente{
        homologacao = 0,
        producao = 1
    }





}
