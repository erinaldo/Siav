using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Dal;

namespace One.Dal
{
    public class Contexto : IDisposable
    {
        #region Propriedades

        public String StrConexao { get; set; }
        public SqlConnection Con { get; set; }
        #endregion

        #region Contrutores
        Acesso config = new Acesso();
        public Contexto(string str){

            this.StrConexao = str;
            this.Con = new SqlConnection(StrConexao);

        }

        public Contexto()
        {

            this.StrConexao = config.readDriverSQL();
            //switch (GlobalDAL.Con)
            //{
            //    case "EquipamentosCia":


            //        break;
            //    default:
            //        this.StrConexao = config.readDriverSQL();
            //        break;
            //}
            this.Con = new SqlConnection(StrConexao);

            try
            {

               // this.Con.Open();
               // this.Con.Close();
            }
            catch
            {
                // System.IO.File.WriteAllText(@System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "pegando_conexao_v2.txt", "Chegou aqui");
                //
                // this.StrConexao = config.readDriverSQLV12();
                // this.Con = new SqlConnection(StrConexao);
                // System.IO.File.WriteAllText(@System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "testando_conexao_v2.txt", "Chegou aqui");
                //
                // this.Con.Open();
                // this.Con.Close();
            }
        }

        public void Contexto_local(String text)
        {
            
            this.StrConexao = config.readDriverSQL_teste(text);
            this.Con = new SqlConnection(StrConexao);

        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método responsável por abrir a conexão com o banco de dados.
        /// </summary>
        public void AbreConexao()
        {
            try
            {
                Con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean testa_conexao()
        {
            try
            {
                AbreConexao();
                FechaConexao();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Método responsável por fechar a conexão com o banco de dados.
        /// </summary>
        public void FechaConexao()
        {
            try
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.FechaConexao();
        }

        /// <summary>
        /// Executa comandos de insert, update e delete sem retornar nada.
        /// </summary>
        public void ExecutaComando(SqlCommand cmd)
        {
            try
            {
                AbreConexao();

                cmd.Connection = this.Con;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                FechaConexao();
            }
        }

        /// <summary>
        /// Método responsável por executar estruções no bd retornando o id do registro afetado.
        /// </summary>
        public int ExecutaComandoInsert(SqlCommand cmd, String nometabela)
        {
            int codigo = 0;

            try
            {
                cmd.CommandText += string.Concat(";select @@identity ", nometabela);
                AbreConexao();
                cmd.Connection = Con;
                codigo = int.Parse(cmd.ExecuteScalar().ToString());
                FechaConexao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigo;
        }

        /// <summary>
        /// Método responsável por executar consultas no bd e retornar um dataset com o resultado.
        /// </summary>
        public DataTable ExecutaConsulta(SqlCommand cmd)
        {
            try
            {
                using (DataTable tab = new DataTable())
                {
                    cmd.Connection = Con;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tab);

                        return tab;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecutaConsulta_old(SqlCommand cmd)
        {
            try
            {
                using (DataTable tab = new DataTable())
                {
                    cmd.Connection = Con;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tab);

                        return tab;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PreencheComboBox(ComboBox cb, String nometabela, String campocodigo, String descricao, String filtro, String ordem)
        {
            try
            {
                String sql = "select * from " + nometabela;

                if (filtro != "")
                    sql += " where " + filtro;

                if (ordem != "")
                    sql += " order by " + ordem;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;

                    //datatable contem o retorno do sql
                    DataTable tab = ExecutaConsulta(cmd);

                    //vinculando o datatable no combobox
                    cb.DataSource = tab;

                    //indicar ao combobox, qual campo é o codigo
                    cb.ValueMember = campocodigo;
                    //indicar ao combobox, qual campo exibir
                    if (nometabela == "cfop")
                        cb.DisplayMember = descricao;
                    else
                        cb.DisplayMember = descricao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PreencheComboBoxCliente(ComboBox cb, String nometabela, String campocodigo, String descricao, String filtro, String ordem)
        {
            try
            {
                String sql = "select cli_codigo,CASE WHEN (cli_tipo_pessoa = 'Pessoa Física') THEN cli_nome ELSE cli_razao_social END 'Cliente' from " + nometabela;

                if (filtro != "")
                {
                    sql += " where " + filtro;
                }

                if (ordem != "")
                {
                    sql += " order by " + ordem;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;

                    //datatable contem o retorno do sql
                    DataTable tab = ExecutaConsulta(cmd);

                    //vinculando o datatable no combobox
                    cb.DataSource = tab;

                    //indicar ao combobox, qual campo é o codigo
                    cb.ValueMember = campocodigo;

                    //indicar ao combobox, qual campo exibir
                    cb.DisplayMember = descricao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PreencheComboBoxFornecedores(ComboBox cb, String nometabela, String campocodigo, String descricao, String filtro, String ordem)
        {
            try
            {
                String sql = "select for_codigo,CASE WHEN for_tipo_fornecedor = 'Pessoa Jurídica' THEN for_razaoSocial ELSE for_nome END 'Fornecedores' from " + nometabela;

                if (filtro != "")
                {
                    sql += " where " + filtro;
                }

                if (ordem != "")
                {
                    sql += " order by " + ordem;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;

                    //datatable contem o retorno do sql
                    DataTable tab = ExecutaConsulta(cmd);

                    //vinculando o datatable no combobox
                    cb.DataSource = tab;

                    //indicar ao combobox, qual campo é o codigo
                    cb.ValueMember = campocodigo;

                    //indicar ao combobox, qual campo exibir
                    cb.DisplayMember = descricao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PreencheComboBox(ComboBox cb, String nometabela, String campocodigo, String descricao, String filtro, String agrupa, String ordem)
        {
            try
            {
                String sql = "select ga.gacod,ga.ganome from " + nometabela;

                if (filtro != "")
                {
                    sql += " where " + filtro;
                }

                if (agrupa != "")
                {
                    sql += " group by " + agrupa;
                }

                if (ordem != "")
                {
                    sql += " order by " + ordem;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;

                    //datatable contem o retorno do sql
                    DataTable tab = ExecutaConsulta(cmd);

                    //vinculando o datatable no combobox
                    cb.DataSource = tab;

                    //indicar ao combobox, qual campo é o codigo
                    cb.ValueMember = campocodigo;

                    //indicar ao combobox, qual campo exibir
                    cb.DisplayMember = descricao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public void preencheComboBox(ComboBox cbFuncionario, string p1, string p2, string p3, string p4, string p5)
        {
            throw new NotImplementedException();
        }
    }

    public enum Posicao
    {
        Primeiro = 0,
        Proximo = 1,
        Anterior = 2,
        Ultimo = 3
    }
}
