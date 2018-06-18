using One.Bll;
using One.Dal;
using SVC_BLL;
using SVC_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class Configuracao_SAT : Form
    {
        public Configuracao_SAT()
        {
            InitializeComponent();

            try{

                Contexto objD = new Contexto();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from configuracao";
                DataTable tab = objD.ExecutaConsulta(cmd);

                if (tab.Rows[0]["apontar_vendedor_final_venda"].ToString() == "s")
                    cbSelecioner_Vendedor.Checked = true;

                if (tab.Rows[0].ItemArray[8].ToString() == "s")
                    cbPDVAtacado.Checked = true;

            }catch (Exception ex){
               
            }finally{
               
            }

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                String c_vinculacao = "codigo_vinculacao_fernando";
                String s_licenca = "";
                Double v_imposto = 0;
                Double v_reducao = 0;
                Boolean existe = false;
                bd_pg sql = new bd_pg();
                //Trend_SAT_OO.data.bd_pg sql = new Trend_SAT_OO.data.bd_pg();

                EmpresaBLL empresa_bll = new EmpresaBLL();

                DataTable x = empresa_bll.localizarEmTudo("");
                String xcnpj = x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                //.Rows[1].ToString().Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                //txt_cnpj.Text.ToString();

                sql.AbrirConexao();
                IDataReader dr = sql.RetornaDados("select * from trendsat_clientes where replace(replace(replace(cnpj,'.',''),'-',''),'/','') = '" + xcnpj + "'");

                Int32 codigo_vinculacao = dr.GetOrdinal("codigo_vinculacao");
                Int32 licenca = dr.GetOrdinal("licenca");
                Int32 imposto = dr.GetOrdinal("imposto");
                Int32 reducao = dr.GetOrdinal("reducao_tributaria");

                while (dr.Read())
                {
                    existe = true;
                    c_vinculacao = dr.GetString(codigo_vinculacao);
                    s_licenca = dr.GetDateTime(licenca).ToShortDateString();
                    v_imposto = dr.GetDouble(imposto);
                    v_reducao = dr.GetDouble(reducao);
                }

                sql.FechaConexao();


                if (existe)
                {


                    sql = new bd_pg("DATABASE=erp_trend;Pooling=False;SERVER=177.125.27.78;PORT=5433;UID=sistema;Password=q2aw3@se4;");
                    sql.AbrirConexao();
                    IDataReader dr2 = sql.RetornaDados("select * from erp_clientes where replace(replace(replace(cnpj,'.',''),'-',''),'/','') = '" + xcnpj + "' ");

                    Int32 razao = dr2.GetOrdinal("nome");
                    Int32 fantasia = dr2.GetOrdinal("fantasia");
                    Int32 cnpj = dr2.GetOrdinal("cnpj");
                    Int32 ie = dr2.GetOrdinal("inscricao_estadual");
                    Int32 im = dr2.GetOrdinal("inscricao_municipal");
                    Int32 logradouro = dr2.GetOrdinal("logradouro");
                    Int32 numero = dr2.GetOrdinal("numero");

                    Int32 estado = dr2.GetOrdinal("uf");
                    Int32 municipio = dr2.GetOrdinal("municipio");

                    if (dr2.Read())
                    {
                        empresa_bll.emp_razaoSocial = "Teste";
                        empresa_bll.emp_nomeFantasia = dr2.GetString(fantasia);
                        empresa_bll.emp_cnpj = dr2.GetString(cnpj);

                        empresa_bll.emp_inscricaoEstadual = dr2.GetString(ie);
                        empresa_bll.emp_inscricaoMunicipal = dr2.GetString(im);
                        empresa_bll.emp_logradouro = dr2.GetString(logradouro);
                        empresa_bll.emp_numero = dr2.GetString(numero);

                        empresa_bll.emp_estado = dr2.GetInt32(estado);
                        empresa_bll.emp_cidade = dr2.GetInt32(municipio);

                    }

                    sql.FechaConexao();

                    EmpresaDAL cmd_empresa = new EmpresaDAL();
                    cmd_empresa.excluir(1);
                    cmd_empresa.inserir(1, empresa_bll.emp_razaoSocial, empresa_bll.emp_nomeFantasia, empresa_bll.emp_logradouro, empresa_bll.emp_numero, "", "", empresa_bll.emp_estado, empresa_bll.emp_cidade, "", "", empresa_bll.emp_cnpj, "", "", 0, 0, 0);
                    cmd_empresa.atualiza_informacoes_fiscais(s_licenca, v_imposto, v_reducao);
                    // cmd_empresa.inserir(0, empresa_bll.emp_razaoSocial, "", "",
                    //     "", "", "", 0, 0, "",
                    //     "", "", "", "", 0, 0, 0);
                    
                    // Atualizando Licenã de uso

                    LicencaDAL cmd_licenca = new LicencaDAL();
                    cmd_licenca.limpar_licencas();
                    cmd_licenca.inserir("1", s_licenca);
                    
                    //Configurar ACBR

                    try
                    {

                        Acbr ac = new Acbr();
                        ac.configura_acbr(empresa_bll.emp_cnpj, empresa_bll.emp_inscricaoEstadual, empresa_bll.emp_inscricaoMunicipal, c_vinculacao);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível configurar o ACBR, você deve fazer esta etapa depois !");
                    }

                    MessageBox.Show("Vinculação realizada com sucesso !");

                  
                }
                else
                {
                    MessageBox.Show("CPF/CNPJ Invalido ou incorreto !");
                }

            }
            catch
            {
                MessageBox.Show("Falha ao configurar, verifique a sua conexão com a internet !");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String c_vinculacao = "codigo_vinculacao_fernando";
                String s_licenca = "";
                Double v_imposto = 0;
                Double v_reducao = 0;
                Boolean existe = false;
                bd_pg sql = new bd_pg();
                //Trend_SAT_OO.data.bd_pg sql = new Trend_SAT_OO.data.bd_pg();

                EmpresaBLL empresa_bll = new EmpresaBLL();

                DataTable x = empresa_bll.localizarEmTudo("");
                String xcnpj = x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                //.Rows[1].ToString().Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Trim();
                //txt_cnpj.Text.ToString();

                sql.AbrirConexao();
                IDataReader dr = sql.RetornaDados("select * from trendsat_clientes where replace(replace(replace(cnpj,'.',''),'-',''),'/','') = '" + xcnpj + "'");

                Int32 codigo_vinculacao = dr.GetOrdinal("codigo_vinculacao");
                Int32 licenca = dr.GetOrdinal("licenca");
                Int32 imposto = dr.GetOrdinal("imposto");
                Int32 reducao = dr.GetOrdinal("reducao_tributaria");

                while (dr.Read()){
                    existe = true;
                    c_vinculacao = dr.GetString(codigo_vinculacao);
                    s_licenca = dr.GetDateTime(licenca).ToShortDateString();
                    v_imposto = dr.GetDouble(imposto);
                    v_reducao = dr.GetDouble(reducao);
                }

                sql.FechaConexao();


                if (existe)
                {


                    sql = new bd_pg("DATABASE=erp_trend;Pooling=False;SERVER=177.125.27.78;PORT=5433;UID=sistema;Password=q2aw3@se4;");
                    sql.AbrirConexao();
                    IDataReader dr2 = sql.RetornaDados("select * from erp_clientes where replace(replace(replace(cnpj,'.',''),'-',''),'/','') = '" + xcnpj + "' ");

                    Int32 razao = dr2.GetOrdinal("nome");
                    Int32 fantasia = dr2.GetOrdinal("fantasia");
                    Int32 cnpj = dr2.GetOrdinal("cnpj");
                    Int32 ie = dr2.GetOrdinal("inscricao_estadual");
                    Int32 im = dr2.GetOrdinal("inscricao_municipal");
                    Int32 logradouro = dr2.GetOrdinal("logradouro");
                    Int32 numero = dr2.GetOrdinal("numero");

                    Int32 estado = dr2.GetOrdinal("uf");
                    Int32 municipio = dr2.GetOrdinal("municipio");

                    if (dr2.Read())
                    {
                        empresa_bll.emp_razaoSocial = "Teste";
                        empresa_bll.emp_nomeFantasia = dr2.GetString(fantasia);
                        empresa_bll.emp_cnpj = dr2.GetString(cnpj);

                        empresa_bll.emp_inscricaoEstadual = dr2.GetString(ie);
                        empresa_bll.emp_inscricaoMunicipal = dr2.GetString(im);
                        empresa_bll.emp_logradouro = dr2.GetString(logradouro);
                        empresa_bll.emp_numero = dr2.GetString(numero);

                        empresa_bll.emp_estado = dr2.GetInt32(estado);
                        empresa_bll.emp_cidade = dr2.GetInt32(municipio);

                    }

                    sql.FechaConexao();
                    
                    // Atualizando Licenã de uso

                    LicencaDAL cmd_licenca = new LicencaDAL();
                    cmd_licenca.limpar_licencas();
                    cmd_licenca.inserir("1", s_licenca);
                    
                    //Configurar ACBR

                    try
                    {
                        Acbr ac = new Acbr();
                        ac.configura_acbr(empresa_bll.emp_cnpj, empresa_bll.emp_inscricaoEstadual, empresa_bll.emp_inscricaoMunicipal, c_vinculacao);
                        MessageBox.Show("ACBR Configurado com sucesso !");
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível configurar o ACBR, você deve fazer esta etapa depois !");
                    }

                    EmpresaDAL cmd_empresa = new EmpresaDAL();
                    cmd_empresa.atualiza_informacoes_fiscais(c_vinculacao, v_imposto, v_reducao);

                }
                else
                {
                    MessageBox.Show("CPF/CNPJ Invalido ou incorreto !");
                }

            }
            catch(Exception ee)
            {
                MessageBox.Show("Falha ao configurar, verifique a sua conexão com a internet !");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (!Directory.Exists("C:\\Rede_Sistema"))
                Directory.CreateDirectory("C:\\Rede_Sistema");

            File.WriteAllText("C:\\Rede_Sistema\\ent.txt","SAT.ImprimirExtratoVenda('<CFe><infCFe Id='CFe35170911111111111111591234567890002489587097' versao='0.06' versaoDadosEnt='0.07' versaoSB='000003'><ide><cUF>35</cUF><cNF>958709</cNF><mod>59</mod><nserieSAT>123456789</nserieSAT><nCFe>000248</nCFe><dEmi>20170915</dEmi><hEmi>110734</hEmi><cDV>7</cDV><tpAmb>2</tpAmb><CNPJ>11111111111111</CNPJ><signAC>11111111111111</signAC><assinaturaQRCODE>gFIrxHQk5J2jmEU1+CCoy9EQWfNOrstrbZCcLZ9jxFNw6Av77RWsqWiODL5SERnFiqJi/69SNituZIg4EWPLQrkexJB5fNk8A/RHhjy/kb9AhgD7u2A0DBIU8VjywrtTk8GrS2O2Ku1jJk40xWwW/OHSGvK/QTBVX6XeHLacAHSWA7EnQQ0c79/3vOHxetbFEjyuu4yrVO36d1BWOkkQHmO7xYI81cH0Jefs/LgbTCFmhI9IjA75vculiEFqGzG43Jd9M3XUb18L3VeVVeWW9d+fk4kRZYfHA4bNVe932AzBM3xQDNiluNbhPhtcrIqzJsnL7QFlOKfpgJNmYR95NA==</assinaturaQRCODE><numeroCaixa>001</numeroCaixa></ide><emit><CNPJ>11111111111111</CNPJ><xNome>Estabelecimento de Teste 2</xNome><xFant>Estabelecimento Fantasia 2</xFant><enderEmit><xLgr>rua das flores</xLgr><nro>1005</nro><xCpl>frente</xCpl><xBairro>centro</xBairro><xMun>Sao Paulo</xMun><CEP>00000000</CEP></enderEmit><IE>111111111111</IE><IM>11111</IM><cRegTrib>3</cRegTrib><cRegTribISSQN>2</cRegTribISSQN><indRatISSQN>S</indRatISSQN></emit><dest/><det nItem='1'><prod><cProd>2043</cProd><xProd>Caneta</xProd><NCM>12079190</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>2.00</vUnCom><vProd>2.00</vProd><indRegra>A</indRegra><vItem>2.00</vItem></prod><imposto><vItem12741>0.17</vItem12741><ICMS><ICMSSN900><Orig>0</Orig><CSOSN>900</CSOSN><pICMS>0.17</pICMS><vICMS>0.00</vICMS></ICMSSN900></ICMS><PIS><PISSN><CST>49</CST></PISSN></PIS><COFINS><COFINSSN><CST>49</CST></COFINSSN></COFINS></imposto></det><total><ICMSTot><vICMS>0.00</vICMS><vProd>2.00</vProd><vDesc>0.00</vDesc><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vPISST>0.00</vPISST><vCOFINSST>0.00</vCOFINSST><vOutro>0.00</vOutro></ICMSTot><vCFe>2.00</vCFe><vCFeLei12741>0.17</vCFeLei12741></total><pgto><MP><cMP>01</cMP><vMP>2.00</vMP></MP><vTroco>0.00</vTroco></pgto><infAdic><infCpl>Cumpom impresso para o cliente TESTE 01...</infCpl></infAdic></infCFe><Signature xmlns='http://www.w3.org/2000/09/xmldsig#'><SignedInfo><CanonicalizationMethod Algorithm='http://www.w3.org/TR/2001/REC-xml-c14n-20010315'/><SignatureMethod Algorithm='http://www.w3.org/2001/04/xmldsig-more#rsa-sha256'/><Reference URI='#CFe35170911111111111111591234567890002489587097'><Transforms><Transform Algorithm='http://www.w3.org/2000/09/xmldsig#enveloped-signature'/><Transform Algorithm='http://www.w3.org/TR/2001/REC-xml-c14n-20010315'/></Transforms><DigestMethod Algorithm='http://www.w3.org/2001/04/xmlenc#sha256'/><DigestValue>iqOpcI+KrUYgbJ1eanL1ibWJr2A8lVMiaMteobIlHQQ=</DigestValue></Reference></SignedInfo><SignatureValue>PnDier1gOgku9I3PM3VyRgTSPR8leMz6wEdy36BfLKzm/cnyVOkVXT4COEKWyZZ4cySzRBwYlwKPgjzOiNrPlLbpSCU0VD9w6YLeZTriMH3qtPhk9qVln/aaDcJdk3oKZrALfk7zXhoudibnkG4ogOqTbpvPT0ci7ebzu/sk3VJopcWhQ7YXvOiNM8YuT30MskzPxJ5Ob7I6EweOoAXFroX7zFr4OVz4pQ0XEeyc1umjQOlzCxoYqSE4ScNwRWw0NI2NMMJaR/M2Iksl/c18YF6LElxooTOsZa1js2BxxsnbCo/dR8SaW5TtXrFjjHFt/F2RE3+joG2JqAJoqBAxiQ==</SignatureValue><KeyInfo><X509Data><X509Certificate>MIICyTCCAbGgAwIBAgIIWfD9/TacZSkwDQYJKoZIhvcNAQELBQAwDjEMMAoGA1UEBhMDU0FUMB4XDTE3MDMyMzIwNDUzOVoXDTE5MDMxMzIwNDUzOVowDjEMMAoGA1UECwwDU0FUMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAj4xML0nMM6TLQ/sAJtSuDNoQV5qu9o3OECtbjdqFp78bVN3QNpsKpg2mXGM3J7TI2+E+7qXXBvUmB/XvFMQiExt6YnXcLdcOU1crGDbo6ha0pzD94CVYiacjFhubd23MGYG7OaHgaL1agEk6gXLuOl+GMVLRks7OqhTI42DR6zhNhnyUq++xFkxQ8f91Yp/jiGyrmOtKb/1ji6ph//KX4ZzbQ7wpgt3z6pAAW9yG4/u88x0wNCDta1l0G0eIk8bTXfTjRLtEFATfSyjNEK1IwMNkKghh6zevaYIaDTx9hT6x24jpJ5jZgn8Cjzm7X6dusiYGItTsl02w5Cnpl3NGvwIDAQABoyswKTAnBgNVHREEIDAeoBwGCCsGAQUFBwgFoBAMDnd3dy5zYXQuY29tLmJyMA0GCSqGSIb3DQEBCwUAA4IBAQAxDjWcJFOn+MtBlUWnqiWHnKy8IBkYi16kgogLgIdwQEUQVUySdPIORtgx2+G3q1eh/pPmRJzj5xgcgxjFv7tRQulkfRT0XOsTF1tUFXVXgcEkMMKemiSCzMaB0nij3xHPB1Veec7AUJffDFYwhx1dyu8AbKHrV3cmhDfUYmoLqtj6A/QO1/+WFGFc9vtL+tEXAgVdU6+ahJG3MefC6bCwY+jzG8LclzHDTXEjxpqhpSD3nBxklTY9ALSr9fHT5xGpWXh5Dk9QRW1GNb6maqm076XriGLijBJdRdrB10bPYtRU1vok7vO9GmvHQM49EKUyAl94mof2TzLcpaRjpQAk</X509Certificate></X509Data></KeyInfo></Signature></CFe>')");


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Configuracao_SAT_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cbSelecioner_Vendedor_CheckedChanged(object sender, EventArgs e)
        {
            Contexto objD = new Contexto();
            SqlCommand cmd = new SqlCommand();
            if (cbSelecioner_Vendedor.Checked)
                cmd.CommandText = "update configuracao set apontar_vendedor_final_venda = 's'";
            else
                cmd.CommandText = "update configuracao set apontar_vendedor_final_venda = 'n'";

            objD.ExecutaComando(cmd);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Contexto objD = new Contexto();
            SqlCommand cmd = new SqlCommand();
            if (cbSelecioner_Vendedor.Checked)
                cmd.CommandText = "update configuracao set atacado_pdv = 's'";
            else
                cmd.CommandText = "update configuracao set atacado_pdv = 'n'";

            objD.ExecutaComando(cmd);
        }
    }
}
