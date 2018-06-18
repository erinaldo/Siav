using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class VendedorDal
    {
        #region Propriedades

        public Contexto contexto { get; set; }

        #endregion

        #region Construtores

        public VendedorDal()
        {
            this.contexto = new Contexto();
        }

        #endregion

        #region Métodos

        public int IncluirVendedor(string nomeVendedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = string.Concat("INSERT INTO VENDEDOR(nome) ",
                                                 "VALUES ('", nomeVendedor, "')");

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        int idNovoVendedor = contexto.ExecutaComandoInsert(cmd, "Vendedor");

                        return idNovoVendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarVendedor(int idVendedor, string nomeVendedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = string.Concat("UPDATE VENDEDOR",
                                                 "SET NOME = ", nomeVendedor,
                                                 " WHERE ID = ", idVendedor);

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        contexto.ExecutaComando(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExcluirVendedor(int idVendedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "DELETE VENDEDOR WHERE ID = " + idVendedor;

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        contexto.ExecutaComando(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultarTodosVendedor()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM VENDEDOR";

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        DataTable dtVendedor = contexto.ExecutaConsulta(cmd);
                        dtVendedor.TableName = "Vendedor";

                        return dtVendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultarVendedorPorPosicao(Posicao posicao, int idVendedorAtual)
        { 
            string query = string.Empty;
            
            switch (posicao)
	        {
		        case Posicao.Primeiro:
                    query = "SELECT * FROM VENDEDOR WHERE id = (SELECT MIN(id) as id FROM VENDEDOR)";
                    break;
                case Posicao.Proximo:
                    query = "SELECT top 1 * FROM VENDEDOR WHERE ID > " + idVendedorAtual;
                    break;
                case Posicao.Anterior:
                    query = "SELECT TOP 1 * FROM VENDEDOR WHERE ID < " + idVendedorAtual;
                    break;
                case Posicao.Ultimo:
                    query = "SELECT * FROM VENDEDOR WHERE id = (SELECT MAX(id) as id FROM VENDEDOR)";
                    break;
	        }

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;

                    using (contexto)
                    {
                        DataTable dtVendedor = contexto.ExecutaConsulta(cmd);
                        dtVendedor.TableName = "Vendedor";

                        return dtVendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultarVendedorComFiltro(int idVendedor, string nomeVendedor)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM VENDEDOR WHERE";

                    if (idVendedor != 0)
                    {
                        query += "id = " + idVendedor;
                    }

                    if (!string.IsNullOrEmpty(nomeVendedor))
                    {
                        if (idVendedor != 0)
                        {
                            query += " AND ";
                        }

                        query += "NOME = " + nomeVendedor;
                    }

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        DataTable dtVendedor = contexto.ExecutaConsulta(cmd);
                        dtVendedor.TableName = "Vendedor";

                        return dtVendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ConsultarVendedorPorTodosFiltro(string textoPesquisa)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = string.Concat("SELECT * FROM VENDEDOR ",
                                                 "WHERE id LIKE '%", textoPesquisa, "%' ", 
                                                 "or nome LIKE '%", textoPesquisa, "%'");

                    cmd.CommandText = query;

                    using (contexto)
                    {
                        DataTable dtVendedor = contexto.ExecutaConsulta(cmd);
                        dtVendedor.TableName = "Vendedor";

                        return dtVendedor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
