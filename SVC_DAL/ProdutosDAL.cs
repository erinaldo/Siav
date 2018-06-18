using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class ProdutosDAL
    {
        public ProdutosDAL()
        { }

        Contexto objD = null;

        //inserção
        public int inserir(String pro_nome, decimal pro_quantidade, Decimal pro_precoCusto, Decimal pro_precoVenda,Decimal pro_precoAtacado, int pro_categoria, 
            int pro_grupo, int pro_subgrupo, int pro_unidade, int pro_estoqueMin, int pro_estoqueMax, DateTime pro_dataCadastro,
            String pro_codigoBarra, int pro_marca, int pro_fornecedor, int pro_tamanho, Decimal pro_margem, Decimal pro_comissao,Int32 cfop,String ncm,decimal aliquota,
            decimal porcentagem_tributos,string csosn,string cst,string cest){
          
            SqlCommand cmd = null;
            try{
                int codigo;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Produtos" +
                    "(pro_nome,pro_quantidade, pro_precoCusto, pro_precoVenda,precoAtacado, pro_categoria, pro_grupo, pro_subGrupo, pro_unidade, pro_estoqueMin,pro_estoqueMax,pro_dataCadastro,pro_codigoBarra,pro_marca,pro_fornecedor, pro_tamanho, pro_margem, pro_comissao,pro_cfop,pro_ncm,aliquota,porcentagem_tributos,csosn,cst,cest)" +
                    " VALUES (@pro_nome,@pro_quantidade, @pro_precoCusto, @pro_precoVenda,@pro_precoAtacado, @pro_categoria, @pro_grupo, @pro_subGrupo, @pro_unidade,@pro_estoqueMin,@pro_estoqueMax,@pro_dataCadastro,@pro_codigoBarra,@pro_marca,@pro_fornecedor,@pro_tamanho,@pro_margem,@pro_comissao,@pro_cfop,@pro_ncm,@aliquota,@porcentagem_tributos,@csosn,@cst,@cest)";

                cmd.Parameters.Add(new SqlParameter("@pro_nome", SqlDbType.VarChar)).Value = pro_nome;
                cmd.Parameters.Add(new SqlParameter("@pro_quantidade", SqlDbType.Decimal)).Value = pro_quantidade;
                cmd.Parameters.Add(new SqlParameter("@pro_precoCusto", SqlDbType.Decimal)).Value = pro_precoCusto;
                cmd.Parameters.Add(new SqlParameter("@pro_precoVenda", SqlDbType.Decimal)).Value = pro_precoVenda;
                cmd.Parameters.Add(new SqlParameter("@pro_precoAtacado", SqlDbType.Decimal)).Value = pro_precoAtacado;
                
                cmd.Parameters.Add(new SqlParameter("@pro_categoria", SqlDbType.Int)).Value = pro_categoria;

                if (pro_grupo == 0){
                    cmd.Parameters.Add(new SqlParameter("@pro_grupo", SqlDbType.Int)).Value = DBNull.Value; //Se não tiver grupo
                }   
                else{
                    cmd.Parameters.Add(new SqlParameter("@pro_grupo", SqlDbType.Int)).Value = pro_grupo;
                }
                    
                if (pro_subgrupo == 0){
                    cmd.Parameters.Add(new SqlParameter("@pro_subgrupo", SqlDbType.Int)).Value = DBNull.Value; //Se não tiver SubGrupo
                }   
                else{
                    cmd.Parameters.Add(new SqlParameter("@pro_subgrupo", SqlDbType.Int)).Value = pro_subgrupo;
                }
   
                if(pro_unidade == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_unidade", SqlDbType.Int)).Value = DBNull.Value;
                }   
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_unidade", SqlDbType.Int)).Value = pro_unidade;
                }
                
                cmd.Parameters.Add(new SqlParameter("@pro_estoqueMin", SqlDbType.Int)).Value = pro_estoqueMin;
                cmd.Parameters.Add(new SqlParameter("@pro_estoqueMax", SqlDbType.Int)).Value = pro_estoqueMax;
                cmd.Parameters.Add(new SqlParameter("@pro_dataCadastro", SqlDbType.DateTime)).Value = pro_dataCadastro;

                if (pro_codigoBarra == "" || pro_codigoBarra == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = DBNull.Value;
                }   
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = pro_codigoBarra;
                }

                if (pro_marca != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_marca", SqlDbType.Int)).Value = pro_marca;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_marca", SqlDbType.Int)).Value = DBNull.Value;
                }

                if (pro_fornecedor == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_fornecedor", SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_fornecedor", SqlDbType.Int)).Value = pro_fornecedor;
                }

                if (pro_tamanho == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_tamanho", SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_tamanho", SqlDbType.Int)).Value = pro_tamanho;
                }

                if (pro_margem == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_margem", SqlDbType.Float)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_margem", SqlDbType.Float)).Value = pro_margem;
                }
                    
                if (pro_comissao == 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_comissao", SqlDbType.Float)).Value = DBNull.Value;
                }   
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pro_comissao", SqlDbType.Float)).Value = pro_comissao;
                }
                cmd.Parameters.Add(new SqlParameter("@pro_cfop", SqlDbType.Int)).Value = cfop;
                cmd.Parameters.Add(new SqlParameter("@pro_ncm", SqlDbType.Int)).Value = ncm;
                
                cmd.Parameters.Add(new SqlParameter("@aliquota", SqlDbType.Float)).Value = aliquota;
                cmd.Parameters.Add(new SqlParameter("@porcentagem_tributos", SqlDbType.Float)).Value = porcentagem_tributos;
                cmd.Parameters.Add(new SqlParameter("@csosn", SqlDbType.VarChar)).Value = csosn;
                cmd.Parameters.Add(new SqlParameter("@cst", SqlDbType.VarChar)).Value = cst;
                cmd.Parameters.Add(new SqlParameter("@cest", SqlDbType.VarChar)).Value = cest;
                                
                codigo = objD.ExecutaComandoInsert(cmd,"Produtos");
                                
                cmd = null;
                objD = null;
                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //alterar
        public void alterar(int pro_codigo, String pro_nome, decimal pro_quantidade, Decimal pro_precoCusto, Decimal pro_precoVenda,Decimal pro_precoAtacado,
            int pro_categoria, int pro_grupo, int pro_subgrupo, int pro_unidade, int pro_estoqueMin, int pro_estoqueMax,
            DateTime pro_dataCadastro, String pro_codigoBarra, int pro_marca, int pro_fornecedor, int pro_tamanho,
            Decimal pro_margem, Decimal pro_comissao, Int32 cfop, String ncm, decimal aliquota, decimal porcentagem_tributos,
            string csosn, string cst, string cest)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Produtos" +
                    " SET pro_nome=@pro_nome, pro_quantidade=@pro_quantidade, pro_precoCusto=@pro_precoCusto,"+
                    " pro_precoVenda=@pro_precoVenda,precoAtacado=@pro_precoAtacado, "+
                    " pro_categoria=@pro_categoria, pro_grupo=@pro_grupo, pro_subGrupo=@pro_subGrupo,"+
                    " pro_unidade=@pro_unidade, pro_estoqueMin = @pro_estoqueMin, pro_estoqueMax = @pro_estoqueMax,"+
                    " pro_dataCadastro=@pro_dataCadastro, pro_codigoBarra=@pro_codigoBarra, pro_marca=@pro_marca, pro_fornecedor=@pro_fornecedor, pro_tamanho = @pro_tamanho, pro_margem=@pro_margem, pro_comissao=@pro_comissao," +
                    " pro_cfop=@cfop,pro_ncm = @ncm,aliquota = @aliquota, porcentagem_tributos = @porcentagem_tributos, " +
                    " csosn = @csosn , cst = @cst, cest = @cest WHERE " +
                    " pro_codigo=@pro_codigo";
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = pro_codigo;
                cmd.Parameters.Add(new SqlParameter("@pro_nome", SqlDbType.VarChar)).Value = pro_nome;
                cmd.Parameters.Add(new SqlParameter("@pro_quantidade", SqlDbType.Decimal)).Value = pro_quantidade;
                cmd.Parameters.Add(new SqlParameter("@pro_precoCusto", SqlDbType.Decimal)).Value = pro_precoCusto;
                cmd.Parameters.Add(new SqlParameter("@pro_precoAtacado", SqlDbType.Decimal)).Value = pro_precoAtacado;
                              
                cmd.Parameters.Add(new SqlParameter("@pro_precoVenda", SqlDbType.Decimal)).Value = pro_precoVenda;
                
                cmd.Parameters.Add(new SqlParameter("@pro_categoria", SqlDbType.Int)).Value = pro_categoria;
                if (pro_grupo == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_grupo", SqlDbType.Int)).Value = DBNull.Value; //Se não tiver grupo
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_grupo", SqlDbType.Int)).Value = pro_grupo;
                if (pro_subgrupo == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_subgrupo", SqlDbType.Int)).Value = DBNull.Value; //Se não tiver SubGrupo
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_subgrupo", SqlDbType.Int)).Value = pro_subgrupo;
                if (pro_unidade == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_unidade", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_unidade", SqlDbType.Int)).Value = pro_unidade;
                cmd.Parameters.Add(new SqlParameter("@pro_estoqueMin", SqlDbType.Int)).Value = pro_estoqueMin;
                cmd.Parameters.Add(new SqlParameter("@pro_estoqueMax", SqlDbType.Int)).Value = pro_estoqueMax;
                cmd.Parameters.Add(new SqlParameter("@pro_dataCadastro", SqlDbType.DateTime)).Value = pro_dataCadastro;
                if (pro_codigoBarra == "" || pro_codigoBarra == null)
                    cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = pro_codigoBarra;
                cmd.Parameters.Add(new SqlParameter("@pro_marca", SqlDbType.Int)).Value = pro_marca;
                if (pro_fornecedor == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_fornecedor", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_fornecedor", SqlDbType.Int)).Value = pro_fornecedor;
                if(pro_tamanho == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_tamanho", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_tamanho", SqlDbType.Int)).Value = pro_tamanho;
                if (pro_margem == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_margem", SqlDbType.Float)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_margem", SqlDbType.Float)).Value = pro_margem;
                if (pro_comissao == 0)
                    cmd.Parameters.Add(new SqlParameter("@pro_comissao", SqlDbType.Float)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@pro_comissao", SqlDbType.Float)).Value = pro_comissao;

                cmd.Parameters.Add(new SqlParameter("@cfop", SqlDbType.Int)).Value = cfop;
                cmd.Parameters.Add(new SqlParameter("@ncm", SqlDbType.Int)).Value = ncm;

                cmd.Parameters.Add(new SqlParameter("@aliquota", SqlDbType.Float)).Value = aliquota;
                cmd.Parameters.Add(new SqlParameter("@porcentagem_tributos", SqlDbType.Float)).Value = porcentagem_tributos;
                cmd.Parameters.Add(new SqlParameter("@csosn", SqlDbType.VarChar)).Value = csosn;
                cmd.Parameters.Add(new SqlParameter("@cst", SqlDbType.VarChar)).Value = cst;
                cmd.Parameters.Add(new SqlParameter("@cest", SqlDbType.VarChar)).Value = cest;

                objD.ExecutaComando(cmd);
            
            }catch (Exception ex){
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void alterarQuantidade(int pro_codigo, decimal pro_quantidade)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Produtos" +
                    " SET pro_quantidade=@pro_quantidade"+
                    " WHERE" +
                    " pro_codigo=@pro_codigo";
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = pro_codigo;
                cmd.Parameters.Add(new SqlParameter("@pro_quantidade", SqlDbType.Decimal)).Value = pro_quantidade;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int pro_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Produtos" +
                    " WHERE" +
                    " pro_codigo=@pro_codigo";
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = pro_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        //selecionar várias linhas
        public DataTable localizar(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Produtos" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao + "%";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarLeave(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Produtos" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        //selecionar uma linha - um código
        public int localizar(int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Produtos" +
                    " WHERE pro_codigo = @codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo",
                    SqlDbType.Int)).Value = codigo;
                tab = objD.ExecutaConsulta(cmd);
                cmd = null;
                objD = null;
                if (tab.Rows.Count > 0)
                    return int.Parse(tab.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable localizarEmTudo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT  p.pro_codigo 'Código',p.pro_nome 'Produto',TipoProduto 'Tipo',p.pro_precoCusto 'Custo',p.pro_precoVenda 'Venda'," +
                                   " p.pro_codigoBarra 'C.Barras',Convert(varchar,p.pro_dataCadastro,103) 'Dt Cad.', p.pro_quantidade 'Disponivél'," +
                                   " p.pro_estoqueMin 'Mínimo',p.pro_estoqueMax 'Máximo',p.pro_tamanho 'Tamanho',p.pro_margem 'Margem', p.pro_comissao 'Tara'," +
                                   " m.mar_descricao 'Marca',u.uni_descricao 'UND', g.gru_descricao 'Grupo', sg.sg_descricao 'Subgrupo', c.cat_descricao 'Categoria'" +
                            " FROM Grupo g Right JOIN Produtos p on g.gru_codigo = p.pro_grupo " +
                                    " LEFT JOIN SubGrupo sg on p.pro_subGrupo = sg.sg_codigo " +
                                    " LEFT JOIN Marcas m on p.pro_marca = m.mar_codigo " +
                                    " LEFT JOIN Empresa e on p.pro_marca = e.emp_codigo" +
                                    " LEFT JOIN Categoria c on p.pro_categoria = c.cat_codigo " +
                                    " LEFT JOIN Unidades u on p.pro_unidade = u.uni_codigo " +
                            " WHERE p.pro_codigo like @descricao or p.pro_nome like @descricao " +
                                    " or p.pro_codigoBarra like @descricao"+
                                    " or p.pro_quantidade like @descricao or p.pro_precoCusto like @descricao " +
                                    " or p.pro_precoVenda like @descricao or g.gru_descricao like @descricao or sg.sg_descricao like @descricao " +
                                    " or p.pro_estoqueMin like @descricao or p.pro_estoqueMax like @descricao or p.pro_dataCadastro like @descricao " +
                                    " or p.pro_margem like @descricao or p.pro_tamanho like @descricao" +
                                    " or m.mar_descricao like @descricao or c.cat_descricao like @descricao or u.uni_descricao like @descricao";
              
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = "%" + descricao + "%";

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarEmTudo_LITE(String descricao, Boolean ver_tudo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT TOP 50 " +
                  " [pro_codigo] as Código " +
                  ",[pro_dataCadastro] as Data_Cadastro " +
                  ",[pro_nome] as Produto " +
                  ",[pro_quantidade] as Quantidade " +
                  ",[pro_estoqueMin] as Minimo " +
                  ",[pro_precoCusto] as R$_Custo " +
                  ",[pro_precoVenda] as R$_Venda " +
                  ",[pro_codigoBarra] as EAN" +
                  ",[pro_tamanho] as Tamanho " +
                  ",[pro_ncm] as NCM " +
                  ",[pro_cfop] as CFOP " +

              "FROM Produtos " +
                " Where [pro_codigoBarra] like @descricao or [pro_codigo] like @descricao or [pro_dataCadastro] like @descricao or [pro_nome] like @descricao or [pro_ncm] like @descricao or [pro_cfop] like @descricao";
                      
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = "" + descricao + "%";

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarEmTudo_LITE_Balanca(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT TOP 50  " +
                    " [pro_codigo] as Código " +
                    ",[pro_dataCadastro] as Data_Cadastro " +
                    ",[pro_nome] as Produto " +
                    ",[pro_quantidade] as Quantidade " +
                    ",[pro_estoqueMin] as Minimo " +
                    ",[pro_precoCusto] as R$_Custo " +
                    ",[pro_precoVenda] as R$_Venda " +
                    ",[pro_codigoBarra] as EAN" +
                    ",[pro_tamanho] as Tamanho " +
                    ",[pro_ncm] as NCM " +
                    ",[pro_cfop] as CFOP " +

                    "FROM Produtos a" +
                    " inner join unidades as b on a.pro_unidade = b.uni_codigo " +
                    " Where [pro_codigoBarra] like @descricao or [pro_codigo] like @descricao or [pro_dataCadastro] like @descricao or [pro_nome] like @descricao or [pro_ncm] like @descricao or [pro_cfop] like @descricao"
                    +" and b.uni_descricao = 'KG'";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = "" + descricao + "%";

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarProdutoCodigoBarra(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID = prod.pro_codigo, Valor = prod.pro_precoVenda, UN = und.uni_descricao,CBarras = prod.pro_codigoBarra, Descricao = prod.pro_nome, Imagem = prod.imagem FROM Produtos prod join Unidades und on und.uni_codigo = prod.pro_unidade  " +
                    " WHERE prod.pro_codigoBarra like '"+descricao+"%' and pro_quantidade >0 ";
                //cmd.Parameters.Add(new SqlParameter("@descricao",SqlDbType.VarChar)).Value = descricao;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarPrimeiroUltimo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "ultimo")
                {
                    cmd.CommandText = "SELECT pro_codigo = max(pro_codigo) FROM Produtos";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT pro_codigo = min(pro_codigo) FROM Produtos";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                     SqlDbType.VarChar)).Value = descricao;
                }
                tab = objD.ExecutaConsulta(cmd);

            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable localizarProxAnterior(String descricao, int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "proximo")
                    cmd.CommandText = "SELECT pro_codigo FROM Produtos WHERE pro_codigo = (SELECT MIN(pro_codigo) FROM Produtos WHERE pro_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT pro_codigo FROM Produtos WHERE pro_codigo = (SELECT MAX(pro_codigo) FROM Produtos WHERE pro_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
        public DataTable localizarProdutoEstoque()
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from produtos Where pro_quantidade <= 0 or pro_quantidade <= pro_estoqueMin";
                    //cmd.Parameters.Add(new SqlParameter("@descricao",
                     //SqlDbType.VarChar)).Value = descricao;
                     tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
        public DataTable localizarProdutoJr(String descricao , String aplicacao)
        {
            try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Pesquisa_Produto"; //Procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                    cmd.Parameters.Add(new SqlParameter("@aplicacao", SqlDbType.VarChar)).Value = aplicacao;
                    DataTable tab = contexto.ExecutaConsulta(cmd);
                    return tab;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
