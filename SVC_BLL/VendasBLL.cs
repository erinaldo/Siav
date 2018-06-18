using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Bll;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class VendasBLL
    {
        public int codigo { get; set; }
        public int cliente { get; set; }
        public DateTime data { get; set; }
        public int usuario { get; set; }
        public int vendedor { get; set; }
        public int forma_pagamento { get; set; }
        public int parcelas { get; set; }
        public decimal valor { get; set; }
        public String observacao { get; set; }
        public decimal desconto { get; set; }
        public decimal percentual { get; set; }
        public decimal valorFinal { get; set; }
        public decimal juros { get; set; }
        public String ven_status { get; set; }
        public String ven_tipo { get; set; }
        public List<FormaPagamentoCia> lstFormaPagamentoCia { get; set; }
        public int ven_ticket { get; set; }
        public int IDAber { get; set; }

        VendasDAL objDAL = new VendasDAL();
        public String CpfCnpj { get; set; }
        public String xml { get; set; }
        public String NSAT { get; set; }

        public String Data_inicial { get; set; }
        public String Data_final { get; set; }


        public DataTable gestao_vendas(){

            VendasDAL cmd = new VendasDAL();
            return cmd.gestao_seleciona(this.Data_inicial,this.Data_final,this.vendedor);

        }

        public VendasBLL()
        { }

        public void limpar()
        {
            try
            {

                this.codigo = 0;
                this.data = DateTime.Now;
                this.cliente = 21;
                this.usuario = 0;
                this.vendedor = 0;
                this.forma_pagamento = 0;
                this.parcelas = 0;
                this.valor = 0;
                this.observacao = null;
                this.desconto = 0;
                this.percentual = 0;
                this.valorFinal = 0;
                this.ven_status = null;
                this.ven_tipo = null;
                this.ven_ticket = 0;
                this.IDAber = 0;


            }
            catch (Exception)
            {
                throw;
            }
        }

        public void inserir(bool consumidorFinal)
        {
            try
            {
                if (consumidorFinal == true)
                {
                    //this.cliente = 23 Consumidor Final -- Cliente PDV 
                    objDAL = new VendasDAL();
                    this.codigo = objDAL.inserir(this.cliente, this.data, this.usuario, this.vendedor, this.forma_pagamento, this.parcelas, this.valor, this.observacao, this.percentual, this.desconto, this.valorFinal, "Ativo", this.ven_tipo, this.ven_ticket, this.IDAber, this.CpfCnpj);
                    objDAL = null;
                }
                else
                {
                    //this.cliente = 23 Consumidor Final -- Cliente PDV 
                    objDAL = new VendasDAL();
                    this.codigo = objDAL.inserir(this.cliente, this.data, this.usuario, this.vendedor, this.forma_pagamento, this.parcelas, this.valor, this.observacao, this.percentual, this.desconto, this.valorFinal, "Ativo", this.ven_tipo, this.ven_ticket, this.IDAber, this.CpfCnpj);
                    objDAL = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean inserir_venda_promissoria(decimal valor)
        {
            try
            {
                //this.cliente = 23 Consumidor Final -- Cliente PDV 
                objDAL = new VendasDAL();
                this.codigo = objDAL.inserir_venda_promissoria(this.codigo, this.cliente,this.vendedor, this.parcelas, this.juros, this.desconto, this.percentual);

                decimal x = (valor / parcelas);

                DateTime dt = this.data;
                for (int i = 1; i <= this.parcelas; i++)
                {
                    objDAL.inserir_venda_promissoria_meses(codigo, parcelas, dt.ToShortDateString(), juros, x);
                    dt = dt.AddMonths(+1);
                }

                VendasBLL objVen = new VendasBLL();
                VendasDAL cmd_venda = new VendasDAL();

                cmd_venda.inserir(this.cliente, DateTime.Now, vendedor, vendedor, 0,
                this.parcelas, valor, "Promissória", 0,
                0, valor, "Promissoria", "Promissoria", 0, 0,"");
        



                objDAL = null;
                return true;
            }
            catch (Exception e)
            {
                throw;
                return false;
            }
        }


        public String vincula_xml_venda(int id_venda, int sessao, String xmlpuro, String data_hora, String nsat)
        {

            try
            {
                objDAL = new VendasDAL();
                objDAL.alterar_xml(id_venda, sessao, xmlpuro, data_hora, nsat);
                objDAL = null;
                return "";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public void alterar(bool consumidorFinal)
        {
            try
            {
                if (consumidorFinal == true)
                {
                    objDAL = new VendasDAL();
                    objDAL.alterar(this.codigo, this.cliente, this.data, this.usuario, this.vendedor, this.forma_pagamento, this.parcelas, this.valor, this.observacao, this.percentual, this.desconto, this.valorFinal, this.ven_status, this.ven_tipo, this.ven_ticket);
                    objDAL = null;
                }
                else
                {
                    objDAL = new VendasDAL();
                    objDAL.alterar(this.codigo, this.cliente, this.data, this.usuario, this.vendedor, this.forma_pagamento, this.parcelas, this.valor, this.observacao, this.percentual, this.desconto, this.valorFinal, this.ven_status, this.ven_tipo, this.ven_ticket);
                    objDAL = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void cancelarVenda()
        {
            try
            {
                objDAL = new VendasDAL();
                objDAL.cancelarVenda(codigo, this.ven_status);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void alterarTipoVenda()
        {
            try
            {
                objDAL = new VendasDAL();
                objDAL.alterarTipoVenda(this.codigo, this.forma_pagamento, this.parcelas, this.ven_tipo);
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
                objDAL = new VendasDAL();
                objDAL.excluir(this.codigo);
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
                objDAL = new VendasDAL();
                this.codigo = objDAL.localizar(this.codigo);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void retorna_xml()
        {
            try
            {
                objDAL = new VendasDAL();
                this.xml = objDAL.localizar_xml(this.codigo);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizar(String descricao, String atributo)
        {
            // Alteração 02/01/2015 
            // Foi retirado a pesquisa datatable ven_cliente, ven_valortotal e ven_valorfinal para atualizar os valores originais do valor da venda. 
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.cliente = int.Parse(tab.Rows[0]["ven_cliente"].ToString());
                    this.data = DateTime.Parse(tab.Rows[0]["ven_dataVenda"].ToString());
                    this.usuario = int.Parse(tab.Rows[0]["ven_usuario"].ToString());
                    this.vendedor = int.Parse(tab.Rows[0]["ven_vendedor"].ToString());
                    if (tab.Rows[0]["ven_formaPagamento"] != DBNull.Value)
                        this.forma_pagamento = int.Parse(tab.Rows[0]["ven_formaPagamento"].ToString());
                    else
                        this.forma_pagamento = 0;
                    if (tab.Rows[0]["ven_qtdParcelas"] != DBNull.Value)
                        this.parcelas = int.Parse(tab.Rows[0]["ven_qtdParcelas"].ToString());
                    else
                        this.parcelas = 0;
                    this.valor = decimal.Parse(tab.Rows[0]["ven_valorTotal"].ToString());
                    this.observacao = tab.Rows[0]["ven_observacao"].ToString();
                    this.desconto = decimal.Parse(tab.Rows[0]["ven_desconto"].ToString());
                    this.percentual = decimal.Parse(tab.Rows[0]["ven_percentualDesconto"].ToString());
                    this.valorFinal = decimal.Parse(tab.Rows[0]["ven_valorFinal"].ToString());
                    this.ven_status = tab.Rows[0]["ven_status"].ToString();
                    this.ven_tipo = tab.Rows[0]["ven_tipo"].ToString();
                    this.ven_ticket = int.Parse(tab.Rows[0]["ven_ticket"].ToString());
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

            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.cliente = int.Parse(tab.Rows[0]["ven_cliente"].ToString());
                    this.data = DateTime.Parse(tab.Rows[0]["ven_dataVenda"].ToString());
                    this.usuario = int.Parse(tab.Rows[0]["ven_usuario"].ToString());
                    this.vendedor = int.Parse(tab.Rows[0]["ven_vendedor"].ToString());
                    if (tab.Rows[0]["ven_formaPagamento"] != DBNull.Value)
                        this.forma_pagamento = int.Parse(tab.Rows[0]["ven_formaPagamento"].ToString());
                    else
                        this.forma_pagamento = 0;
                    if (tab.Rows[0]["ven_qtdParcelas"] != DBNull.Value)
                        this.parcelas = int.Parse(tab.Rows[0]["ven_qtdParcelas"].ToString());
                    else
                        this.parcelas = 0;
                    this.valor = decimal.Parse(tab.Rows[0]["ven_valorTotal"].ToString());
                    this.observacao = tab.Rows[0]["ven_observacao"].ToString();
                    this.desconto = decimal.Parse(tab.Rows[0]["ven_desconto"].ToString());
                    this.percentual = decimal.Parse(tab.Rows[0]["ven_percentualDesconto"].ToString());
                    this.valorFinal = decimal.Parse(tab.Rows[0]["ven_valorFinal"].ToString());
                    this.ven_status = tab.Rows[0]["ven_status"].ToString();
                    this.ven_tipo = tab.Rows[0]["ven_tipo"].ToString();
                    this.ven_ticket = int.Parse(tab.Rows[0]["ven_ticket"].ToString());
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Novo localizar Ticket FastFood 02/01/2016
        public void localizarLeave_Ticket(String descricao, String atributo)
        {

            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizarLeave_Ticket(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.cliente = int.Parse(tab.Rows[0]["ven_cliente"].ToString());
                    this.data = DateTime.Parse(tab.Rows[0]["ven_dataVenda"].ToString());
                    this.usuario = int.Parse(tab.Rows[0]["ven_usuario"].ToString());
                    this.vendedor = int.Parse(tab.Rows[0]["ven_vendedor"].ToString());
                    if (tab.Rows[0]["ven_formaPagamento"] != DBNull.Value)
                        this.forma_pagamento = int.Parse(tab.Rows[0]["ven_formaPagamento"].ToString());
                    else
                        this.forma_pagamento = 0;
                    if (tab.Rows[0]["ven_qtdParcelas"] != DBNull.Value)
                        this.parcelas = int.Parse(tab.Rows[0]["ven_qtdParcelas"].ToString());
                    else
                        this.parcelas = 0;
                    this.valor = decimal.Parse(tab.Rows[0]["ven_valorTotal"].ToString());
                    this.observacao = tab.Rows[0]["ven_observacao"].ToString();
                    this.desconto = decimal.Parse(tab.Rows[0]["ven_desconto"].ToString());
                    this.percentual = decimal.Parse(tab.Rows[0]["ven_percentualDesconto"].ToString());
                    this.valorFinal = decimal.Parse(tab.Rows[0]["ven_valorFinal"].ToString());
                    this.ven_status = tab.Rows[0]["ven_status"].ToString();
                    this.ven_tipo = tab.Rows[0]["ven_tipo"].ToString();
                    this.ven_ticket = int.Parse(tab.Rows[0]["ven_ticket"].ToString());
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Fim *******************************************
        public DataTable localizarComRetorno(String descricao, String atributo)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable seleciona_promissorias(String search)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.seleciona_promissorias(search);
                objDAL = null;
                return tab;
            }
            catch (Exception){
                throw;
            }
        }

        public DataTable seleciona_promissorias_fechadas(String search)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.seleciona_promissorias_fechadas(search);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }


        

        public DataTable seleciona_promissorias_search(String search)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.seleciona_promissorias_search(search);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable seleciona_promissorias_vencidas(String search)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.seleciona_promissorias_vencidas(search);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable seleciona_promissorias_vencidas_hoje(String search)
       {
           try
           {
               DataTable tab;
               objDAL = new VendasDAL();
               tab = objDAL.seleciona_promissorias_vencidas_hoje_bd(search);
               objDAL = null;
               return tab;
           }
           catch (Exception)
           {
      
               throw;
           }
       }
      


        public DataTable seleciona_promissorias_meses(Int32 id)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.seleciona_promissorias_meses(id);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void baixa_promissoria(Int32 id)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                objDAL.baixa_promissoria(id);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void fecha_promissoria(Int32 id)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                objDAL.fecha_promissoria(id);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public DataTable verificaLimiteClienteMensal(int cli_codigo)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.verificaLimiteClienteMensal(cli_codigo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable verificaLimiteClienteTotal(int cli_codigo)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.verificaLimiteClienteTotal(cli_codigo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarEmTudo(String descricao)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizarEmTudo(descricao);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarCupom(Int32 usuario)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.LocalizarCupom(usuario);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LocalizarSegundaVia(Int32 usuario)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.LocalizarSegundaVia(usuario);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LocalizarRelatorioVenda(String data_inicial, String data_final)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.LocalizarRelatorioVendas(data_inicial, data_final);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean retorna_itens_venda_ao_estoque(int codigo_venda)
        {
            Boolean x = true;

            try
            {

                // Coletando itens da venda
                vendaItensBLL v = new vendaItensBLL();
                v.ven_codigo = codigo_venda;
                DataTable itens = v.localizarComRetorno(v.ven_codigo.ToString(), "ven_codigo");

                // Retornando itens ao estoque
                if (itens.Rows.Count > 0)
                {
                    foreach (DataRow item in itens.Rows)
                    {
                        Int32 codigo_item = Int32.Parse(item["pro_codigo"].ToString());
                        string[] qtd_aux = item["vi_quantidade"].ToString().Split(',');
                        Int32 qtd_item = Int32.Parse(qtd_aux[0]);

                        ProdutosBLL cmd_produto = new ProdutosBLL();
                        cmd_produto.pro_codigo = codigo_item;
                        cmd_produto.localizar("pro_codigo", codigo_item.ToString());
                        cmd_produto.pro_quantidade += qtd_item;
                        cmd_produto.alterarQuantidade();
                    }
                }
                else
                {
                    x = false;
                }


            }
            catch
            {
                x = false;
            }
            return x;
        }

        public DataTable seleciona_itens_venda_troca(String codigo_venda)
        {


            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizar_itens_troca(codigo_venda);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable FormarCupom(int venda)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.FormarCupom(venda);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizarPrimeiroUltimo(String descricao)
        {
            try
            {
                DataTable tab = null;
                int codigo = 0;
                objDAL = new VendasDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.codigo = codigo;
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                DataTable tab = null;
                objDAL = new VendasDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public struct FormaPagamentoCia
        {
            public int idFormaPagamento { get; set; }
            public string nomeFormaPagamento { get; set; }
            public int numeroParcelas { get; set; }
        }


        public DataTable Localiza_Cupom()
        {

            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizar_vendas_troca(this.Data_inicial, this.Data_final);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public String Localiza_Nome_Cliente_promissoria(Int32 id)
        {
            try
            {
                DataTable tab;
                objDAL = new VendasDAL();
                tab = objDAL.localizar_cliente_promissoria(id);
                objDAL = null;
                return tab.Rows[0].ItemArray[0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
