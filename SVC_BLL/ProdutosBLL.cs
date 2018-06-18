using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class ProdutosBLL
    {
        public int pro_codigo { get; set; }
        public String pro_nome { get; set; }
        public decimal pro_quantidade { get; set; }
        public Decimal pro_precoCusto { get; set; }
        public Decimal pro_precoVenda { get; set; }
        public Decimal pro_precoAtacado { get; set; }
        public int pro_categoria { get; set; }
        public int pro_grupo { get; set; }
        public int pro_subGrupo { get; set; }
        public int pro_unidade { get; set; }
        public int pro_estoqueMin { get; set; }
        public int pro_estoqueMax { get; set; }
        public DateTime pro_dataCadastro { get; set; }
        public String pro_codigoBarra { get; set; }
        public int pro_marca { get; set; }
        public int pro_fornecedor { get; set; }
        public int pro_tamanho { get; set; }
        public Decimal pro_margem { get; set; }
        public Decimal pro_comissao { get; set; }
        public String ncm { get; set; }
        public int cfop { get; set; }
        public byte[] pro_imagem { get; set; }


        public decimal pro_aliquota { get; set; }
        public decimal porcentagem_tributos { get; set; }
        public string pro_csosn { get; set; }
        public string pro_cst { get; set; }
        public string cest{ get; set; }

        public ProdutosBLL()
        { }

        ProdutosDAL objDAL = null;

        public void limpar()
        {
            try
            {
                this.pro_codigo = 0;
                this.pro_nome = null;
                this.pro_quantidade = 0;
                this.pro_precoCusto = 0;
                this.pro_precoVenda = 0;
                this.pro_categoria = 0;
                this.pro_grupo = 0;
                this.pro_subGrupo = 0;
                this.pro_unidade = 0;
                this.pro_estoqueMin= 0;
                this.pro_estoqueMax = 0;
                this.pro_dataCadastro = DateTime.Now;
                this.pro_codigoBarra = null;
                this.pro_marca = 0;
                this.pro_fornecedor = 0;
                this.pro_tamanho = 0;
                this.pro_margem = 0;
                this.pro_comissao = 0;

                this.pro_aliquota = 0;
                this.porcentagem_tributos = 0;
                this.pro_csosn = null;
                this.pro_cst = null;
                this.cest = null;
                this.pro_cst = null;
                this.pro_imagem = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void inserir()
        {
            try
            {
                objDAL = new ProdutosDAL();
                this.pro_codigo = objDAL.inserir(this.pro_nome, this.pro_quantidade, this.pro_precoCusto, this.pro_precoVenda, this.pro_precoAtacado, this.pro_categoria, this.pro_grupo, this.pro_subGrupo, this.pro_unidade, this.pro_estoqueMin, this.pro_estoqueMax, this.pro_dataCadastro, this.pro_codigoBarra, this.pro_marca, this.pro_fornecedor, this.pro_tamanho, this.pro_margem, this.pro_comissao, this.cfop, this.ncm, this.pro_aliquota, this.porcentagem_tributos, this.pro_csosn, this.pro_cst, this.cest);
                objDAL = null;
            }catch (Exception){
                throw;
            }
        }

        public void alterar()
        {
            try
            {
                objDAL = new ProdutosDAL();
                objDAL.alterar(this.pro_codigo, this.pro_nome, this.pro_quantidade, this.pro_precoCusto, this.pro_precoVenda, this.pro_precoAtacado, this.pro_categoria, this.pro_grupo, this.pro_subGrupo, this.pro_unidade, this.pro_estoqueMin, this.pro_estoqueMax, this.pro_dataCadastro, this.pro_codigoBarra, this.pro_marca, this.pro_fornecedor, this.pro_tamanho, this.pro_margem, this.pro_comissao, this.cfop, this.ncm, this.pro_aliquota, this.porcentagem_tributos, this.pro_csosn, this.pro_cst, this.cest);
                objDAL = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void alterarQuantidade()
        {
            try
            {
                objDAL = new ProdutosDAL();
                objDAL.alterarQuantidade(this.pro_codigo, this.pro_quantidade);
                objDAL = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void excluir()
        {
            try
            {
                objDAL = new ProdutosDAL();
                objDAL.excluir(this.pro_codigo);
                objDAL = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizar()
        {
            try
            {
                objDAL = new ProdutosDAL();
                this.pro_codigo = objDAL.localizar(this.pro_codigo);
                objDAL = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizar(String descricao, String atributo)
        {
            try
            {
                DataTable tab;
                objDAL = new ProdutosDAL();

                tab = objDAL.localizar(atributo, descricao);
                        if (tab.Rows.Count > 0)
                        {

                            this.pro_codigo = int.Parse(tab.Rows[0]["pro_codigo"].ToString());
                            this.pro_nome = tab.Rows[0]["pro_nome"].ToString();
                            this.pro_quantidade = int.Parse(tab.Rows[0]["pro_quantidade"].ToString());
                            this.pro_precoCusto = Decimal.Parse(tab.Rows[0]["pro_precoCusto"].ToString());
                            this.pro_precoVenda = Decimal.Parse(tab.Rows[0]["pro_precoVenda"].ToString());
                            this.pro_categoria = int.Parse(tab.Rows[0]["pro_categoria"].ToString());
                            if (tab.Rows[0]["pro_grupo"] != DBNull.Value)
                                this.pro_grupo = int.Parse(tab.Rows[0]["pro_grupo"].ToString());
                            else
                                this.pro_grupo = 0;
                            if (tab.Rows[0]["pro_subGrupo"] != DBNull.Value)
                                this.pro_subGrupo = int.Parse(tab.Rows[0]["pro_subGrupo"].ToString());
                            else
                                this.pro_subGrupo = 0;
                            if (tab.Rows[0]["pro_unidade"] != DBNull.Value)
                                this.pro_unidade = int.Parse(tab.Rows[0]["pro_unidade"].ToString());
                            else
                                this.pro_unidade = 0;
                            //this.pro_estoqueMin = int.Parse(tab.Rows[0]["   "].ToString());
                            //this.pro_estoqueMax = int.Parse(tab.Rows[0]["pro_estoqueMax"].ToString());
                            this.pro_dataCadastro = DateTime.Parse(tab.Rows[0]["pro_dataCadastro"].ToString());
                            if (tab.Rows[0]["pro_codigoBarra"] != DBNull.Value)
                                this.pro_codigoBarra = tab.Rows[0]["pro_codigoBarra"].ToString();
                            else
                                this.pro_codigoBarra = null;

                            try { this.pro_marca = int.Parse(tab.Rows[0]["pro_marca"].ToString()); }
                            catch { }
                            this.pro_fornecedor = int.Parse(tab.Rows[0]["pro_fornecedor"].ToString());
                            
                            if (tab.Rows[0]["pro_tamanho"] != DBNull.Value)
                                this.pro_tamanho = int.Parse(tab.Rows[0]["pro_tamanho"].ToString());
                            else
                                this.pro_tamanho = 0;

                            if (tab.Rows[0]["pro_margem"] != DBNull.Value)
                                this.pro_margem = Decimal.Parse(tab.Rows[0]["pro_margem"].ToString());
                            else
                                this.pro_margem = 0;
                            //
                            //if (tab.Rows[0]["pro_comissao"] != DBNull.Value)
                            //    this.pro_comissao = Decimal.Parse(tab.Rows[0]["pro_comissao"].ToString());
                            //else
                            //    this.pro_comissao = 0;

                        }
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizarLeave(String descricao, String atributo)
        {
            try{
                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarLeave(descricao, atributo);

                if (tab.Rows.Count > 0){

                        this.pro_codigo = int.Parse(tab.Rows[0]["pro_codigo"].ToString());
                        this.pro_nome = tab.Rows[0]["pro_nome"].ToString();
                        this.pro_quantidade = int.Parse(tab.Rows[0]["pro_quantidade"].ToString());
                        this.pro_precoCusto = Decimal.Parse(tab.Rows[0]["pro_precoCusto"].ToString());
                        this.pro_precoVenda = Decimal.Parse(tab.Rows[0]["pro_precoVenda"].ToString());
                        this.pro_precoAtacado = Decimal.Parse(tab.Rows[0]["precoAtacado"].ToString());
                        this.pro_categoria = int.Parse(tab.Rows[0]["pro_categoria"].ToString());
                        if (tab.Rows[0]["pro_grupo"] != DBNull.Value)
                            this.pro_grupo = int.Parse(tab.Rows[0]["pro_grupo"].ToString());
                        else
                            this.pro_grupo = 0;
                        if (tab.Rows[0]["pro_subGrupo"] != DBNull.Value)
                            this.pro_subGrupo = int.Parse(tab.Rows[0]["pro_subGrupo"].ToString());
                        else
                            this.pro_subGrupo = 0;
                        if (tab.Rows[0]["pro_unidade"] != DBNull.Value)
                            this.pro_unidade = int.Parse(tab.Rows[0]["pro_unidade"].ToString());
                        else
                            this.pro_unidade = 0;
                        this.pro_estoqueMin = int.Parse(tab.Rows[0]["pro_estoqueMin"].ToString());
                        this.pro_estoqueMax = int.Parse(tab.Rows[0]["pro_estoqueMax"].ToString());
                        this.pro_dataCadastro = DateTime.Parse(tab.Rows[0]["pro_dataCadastro"].ToString());
                        if (tab.Rows[0]["pro_codigoBarra"] != DBNull.Value)
                            this.pro_codigoBarra = tab.Rows[0]["pro_codigoBarra"].ToString();
                        else
                            this.pro_codigoBarra = null;
                        try {
                            this.pro_marca = int.Parse(tab.Rows[0]["pro_marca"].ToString());
                        }
                        catch { }
                        this.pro_fornecedor = int.Parse(tab.Rows[0]["pro_fornecedor"].ToString());
                        if (tab.Rows[0]["pro_tamanho"] != DBNull.Value)
                            this.pro_tamanho = int.Parse(tab.Rows[0]["pro_tamanho"].ToString());
                        else
                            this.pro_tamanho = 0;
                        if (tab.Rows[0]["pro_margem"] != DBNull.Value)
                            this.pro_margem = Decimal.Parse(tab.Rows[0]["pro_margem"].ToString());
                        else
                            this.pro_margem = 0;
                        if (tab.Rows[0]["pro_comissao"] != DBNull.Value)
                            this.pro_comissao = Decimal.Parse(tab.Rows[0]["pro_comissao"].ToString());
                        else
                            this.pro_comissao = 0;

                        if (tab.Rows[0]["pro_cfop"] != DBNull.Value)
                            this.cfop = Int32.Parse(tab.Rows[0]["pro_cfop"].ToString());
                        else
                            this.cfop = 0;

                        this.ncm = tab.Rows[0]["pro_ncm"].ToString().Trim();

                        try { this.pro_imagem = (byte[])tab.Rows[0]["Imagem"]; }catch { }
                        try { this.pro_aliquota = decimal.Parse(tab.Rows[0]["aliquota"].ToString().Trim()); }catch { }
                        try { this.porcentagem_tributos = decimal.Parse(tab.Rows[0]["porcentagem_tributos"].ToString().Trim());}catch { }
                        try { this.pro_csosn = tab.Rows[0]["csosn"].ToString().Trim();}catch { }
                        try { this.pro_cst = tab.Rows[0]["cst"].ToString().Trim();}catch { }
                        try { this.cest = tab.Rows[0]["cest"].ToString().Trim(); }catch { }

                }
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarComRetorno(String descricao, String atributo)
        {
            try{
                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception){
                throw;
            }
        }
        //localizarProdutoCodigoBarra
        public DataTable localizarProdutoCodigoBarra(String descricao){

            try{

                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarProdutoCodigoBarra(descricao);
                objDAL = null;
                return tab;

            }catch (Exception){
                throw;
            }

        }

        public DataTable localizarEmTudo(String descricao){

            try{

                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarEmTudo(descricao);
                objDAL = null;
                return tab;

            }catch (Exception){

                throw;

            }
        }

        public DataTable localizarEmTudoLITE(String descricao,Boolean ver_tudo)
        {

            try
            {

                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarEmTudo_LITE(descricao,ver_tudo);
                objDAL = null;
                return tab;

            }
            catch (Exception)
            {

                throw;

            }
        }

        public DataTable localizarEmTudo_Balanca(String descricao)
        {

            try{

                DataTable tab;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarEmTudo_LITE_Balanca(descricao);
                objDAL = null;
                return tab;

            }
            catch (Exception)
            {

                throw;

            }
        }

        

        public void localizarPrimeiroUltimo(String descricao){

            try{

                DataTable tab = null;
                int codigo = 0;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.pro_codigo = codigo;
                objDAL = null;

            }
            catch (Exception){
                throw;
            }

        }

        public void localizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                DataTable tab = null;
                objDAL = new ProdutosDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.pro_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
