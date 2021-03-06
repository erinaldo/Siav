IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME = 'OneERP')
    CREATE DATABASE [OneERP]
GO
USE [OneERP]
GO
/****** Object:  StoredProcedure [dbo].[CaixaInicial]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CaixaInicial]
AS
BEGIN
    SET NOCOUNT ON
    SELECT TOP 1 fin.fin_valorInicial FROM fin_abertura_caixa fin ORDER BY fin.fin_codigo DESC --where CONVERT(CHAR(11),fin_data,103)	 = CONVERT(CHAR(11),GETDATE()-1,103)	
END
GO
/****** Object:  StoredProcedure [dbo].[ClientesAtendidos]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClientesAtendidos] @dataInicial DATETIME , @dataFinal DateTIME 
AS
BEGIN	
    SET NOCOUNT ON;
    SET LANGUAGE Brazilian;
    SELECT c.cli_nome 'Cliente', LEFT(CONVERT(VARCHAR(50),v.ven_dataVenda,113),11) 'Data da Compra', v.ven_valorFinal 'Valor da Venda'
    FROM Cliente c 
    INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente
    WHERE v.ven_dataVenda between @dataInicial and @dataFinal
END


GO
/****** Object:  StoredProcedure [dbo].[ContasAPagarAberto]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ContasAPagarAberto] @dataInicial DATETIME, @dataFinal DATETIME
AS BEGIN
SET NOCOUNT ON	
    SELECT cp_codigo 'Código', 
    CASE WHEN f.for_tipo_fornecedor like 'Pessoa Física' THEN f.for_nome else f.for_razaoSocial END 'Fornecedor',
    CASE WHEN p.pro_nome is null THEN 'Serviço' ELSE p.pro_nome END 'Item', 
    cp.cp_valor 'Valor', CONVERT(CHAR(11),cp.cp_vencimento,113) 'Data de Vencimento'
    FROM Produtos p 
    RIGHT JOIN comprasProduto comp on p.pro_codigo = comp.cp_produtos
    RIGHT JOIN Compras c on comp.cp_compras = c.com_codigo
    RIGHT JOIN ContasAPagar cp on p.pro_codigo = cp.cp_compras
    RIGHT JOIN Fornecedores f on cp.cp_fornecedor = f.for_codigo
    WHERE cp_status like 'Aberto' and 
    cp.cp_vencimento between @dataInicial and @dataFinal
END


GO
/****** Object:  StoredProcedure [dbo].[ContasAPagarPago]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ContasAPagarPago] @dataInicial DATETIME, @dataFinal DATETIME
AS BEGIN
SET NOCOUNT ON	
    SELECT cp_codigo 'Código', 
    CASE WHEN f.for_tipo_fornecedor like 'Pessoa Física' THEN f.for_nome else f.for_razaoSocial END 'Fornecedor',
    CASE WHEN p.pro_nome is null THEN 'Serviço' ELSE p.pro_nome END 'Item', 
    cp.cp_valor 'Valor', CONVERT(CHAR(11),cp.cp_vencimento,113) 'Data de Vencimento'
    FROM Produtos p 
    RIGHT JOIN comprasProduto comp on p.pro_codigo = comp.cp_produtos
    RIGHT JOIN Compras c on comp.cp_compras = c.com_codigo
    RIGHT JOIN ContasAPagar cp on p.pro_codigo = cp.cp_compras
    RIGHT JOIN Fornecedores f on cp.cp_fornecedor = f.for_codigo
    WHERE cp_status like 'Pago' and 
    cp.cp_vencimento between @dataInicial and @dataFinal	
END


GO
/****** Object:  StoredProcedure [dbo].[EntradaMercadoria]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EntradaMercadoria] @dataInicial DATETIME , @dataFinal DateTIME 
AS
BEGIN	
    SET NOCOUNT ON;

    SELECT p.pro_nome 'Produto', c.cat_descricao 'Categoria', p.pro_precoCusto 'Preço de Custo', cp_quantidade 'Quantidade',
    p.pro_precoCusto* cp.cp_quantidade 'Total'
    FROM Compras com 
    INNER JOIN comprasProduto cp on com.com_codigo= cp.cp_compras
    INNER JOIN Produtos p on cp.cp_produtos = p.pro_codigo
    INNER JOIN Categoria c on p.pro_categoria = c.cat_codigo
    WHERE com.com_dataCompra between @dataInicial and @dataFinal
END


GO
/****** Object:  StoredProcedure [dbo].[etiquetasCodigoBarra]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[etiquetasCodigoBarra] @codigoBarra VARCHAR(MAX)
AS
BEGIN
    SELECT pro_nome, pro_precoVenda,pro_codigoBarra 
    FROM Produtos
    --WHERE pro_codigoBarra = @codigoBarra
END

GO
/****** Object:  StoredProcedure [dbo].[Fechamento]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fechamento]
AS
BEGIN
SET NOCOUNT ON
    SELECT fp.fp_descricao 'Forma de Pagamento',v.ven_valorFinal 'Valor',
            'Vendas Realizadas'as [Tipo] 
    FROM  Vendas v 
          INNER JOIN FormaPagamento fp on v.ven_formaPagamento = fp.fp_codigo
    WHERE v.ven_tipo like 'Venda' and CONVERT(CHAR(11),v.ven_dataVenda ,103) = CONVERT(CHAR(11),getdate(),103)
    UNION ALL
    SELECT fp.fp_descricao 'Forma de Pagamento',pd.pd_valor 'Valor',
           'Contas Recebidas'as [Tipo] 
    FROM PagamentoDia pd 
         INNER JOIN	ContasAReceber cr on pd.cr_codigo = cr.cr_codigo
         INNER JOIN  Vendas v on cr.cr_vendas = v.ven_codigo 
         INNER JOIN FormaPagamento fp on v.ven_formaPagamento = fp.fp_codigo 
    WHERE  CONVERT(CHAR(11),pd.pd_data,103) = CONVERT(CHAR(11),getdate(),103)	
    UNION ALL
    SELECT 'Dinheiro' 'Forma de Pagamento', cp.cp_valor *-1 'Valor', 'Contas Pagas' as [Tipo]
    FROM ContasAPagar cp
    WHERE CONVERT(CHAR(11),cp.cp_dataPagamento ,103) = CONVERT(CHAR(11),getdate(),103)	
END
GO
/****** Object:  StoredProcedure [dbo].[Fechamento2]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fechamento2]
AS
BEGIN
SET NOCOUNT ON
    SELECT '' as [Forma de Pagamento], f.fin_valorInicial 'Valor','Fundo de Caixa' as [Tipo] FROM fin_abertura_caixa f
    WHERE  CONVERT(CHAR(11),f.fin_dataAbertura,103) = CONVERT(CHAR(11),getdate(),103)	
    UNION ALL
    SELECT fp.fp_descricao 'Forma de Pagamento',pd.pd_valor 'Valor',
           'Contas Recebidas'as [Tipo] 
    FROM PagamentoDia pd 
         INNER JOIN	ContasAReceber cr on pd.cr_codigo = cr.cr_codigo
         INNER JOIN  Vendas v on cr.cr_vendas = v.ven_codigo 
         INNER JOIN FormaPagamento fp on v.ven_formaPagamento = fp.fp_codigo 
    WHERE  CONVERT(CHAR(11),pd.pd_data,103) = CONVERT(CHAR(11),getdate(),103)	
    UNION ALL
    SELECT 'Dinheiro' 'Forma de Pagamento', cp.cp_valor *-1 'Valor', 'Contas Pagas' as [Tipo]
    FROM ContasAPagar cp
    WHERE CONVERT(CHAR(11),cp.cp_dataPagamento ,103) = CONVERT(CHAR(11),getdate(),103)	
END
GO
/****** Object:  StoredProcedure [dbo].[FechamentoTotalDia]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FechamentoTotalDia]	
AS
BEGIN
    SET NOCOUNT ON	
    SELECT 'Contas Recebidas' as Tipo, SUM(pd.pd_valor) 'Valor Pago(R$)' 
    FROM   PagamentoDia pd 
    WHERE  CONVERT(CHAR(11),pd_data,103) =  CONVERT(CHAR(11),getdate(),103)
    UNION ALL
    SELECT 'Vendas Realizadas' as Tipo, SUM(v.ven_valorFinal) 'Valor Pago(R$)' 
    FROM Vendas v
    WHERE v.ven_tipo like 'Venda' and v.ven_status like 'Ativo' and CONVERT(CHAR(11),v.ven_dataVenda ,103) =  CONVERT(CHAR(11),getdate(),103)
    UNION ALL
    SELECT 'Contas Pagas' as Tipo, SUM(cp.cp_valor) 
    FROM ContasAPagar cp
    WHERE CONVERT(CHAR(11),cp.cp_dataPagamento ,103) =  CONVERT(CHAR(11),getdate(),103)
END


GO
/****** Object:  StoredProcedure [dbo].[FisicoFinanceiroCompras]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Separar físico financeiro em compras e vendas
CREATE PROCEDURE [dbo].[FisicoFinanceiroCompras] 
AS BEGIN
SET NOCOUNT ON	
    SELECT  g.gru_descricao 'Grupo', p.pro_nome 'Produto',
            cp.cp_quantidade 'Quantidade Comprado',cp.cp_subtotal 'Valor Comprado'
    FROM Produtos p
         INNER JOIN Grupo g on p.pro_grupo = g.gru_codigo
         INNER JOIN comprasProduto cp on p.pro_codigo = cp.cp_produtos
         INNER JOIN Compras c on cp.cp_compras = c.com_codigo
    WHERE LEFT(c.com_dataCompra,10) = LEFT(GETDATE(),10)
    ORDER BY c.com_dataCompra DESC
END



GO
/****** Object:  StoredProcedure [dbo].[FisicoFinanceiroVendas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FisicoFinanceiroVendas]
AS BEGIN
SET NOCOUNT ON	
    SELECT  g.gru_descricao 'Grupo', p.pro_nome 'Produto',
            vi.vi_quantidade 'Quantidade Vendido' ,vi.vi_subtotal 'Valor Vendido'
    FROM Vendas v 
         INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
         INNER JOIN Produtos p on vi.pro_codigo = p.pro_codigo
         INNER JOIN Grupo g on p.pro_grupo = g.gru_codigo
    WHERE LEFT(v.ven_dataVenda,10) =  LEFT(GETDATE(),10)
    ORDER BY v.ven_dataVenda
END

GO
/****** Object:  StoredProcedure [dbo].[gerarEtiquetasCodigoBarra]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gerarEtiquetasCodigoBarra]
AS 
BEGIN	
    SELECT pro_nome, pro_codigoBarra, pro_precoVenda FROM codigoBarra	
    --SELECT CASE WHEN Len(pro_nome) <= 25 THEN LEFT(pro_nome,25) ELSE LEFT(pro_nome,12)+'...'+ substring(pro_nome,len(pro_nome)-10,len(pro_nome)) END 'pro_nome', pro_codigoBarra, pro_precoVenda FROM codigoBarra
    DELETE FROM codigoBarra
END

GO
/****** Object:  StoredProcedure [dbo].[LocalizaCliente]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocalizaCliente] @descricao VARCHAR(150), @tipo VARCHAR(50) 
AS BEGIN 
    IF(@tipo = 'Pessoa Física')
        SELECT TOP 100 c.cli_codigo 'Código do Cliente', c.cli_nome 'Nome', c.cli_idade 'Idade', CONVERT(VARCHAR(50),c.cli_data_nascimento,113) 'Data de Nascimento',c.cli_rg 'RG', c.cli_cpf 'CPF',
        ci.cid_nome 'Cidade',c.cli_logradouro 'Logradouro',c.cli_numero 'Número', c.cli_complemento 'Complemento', c.cli_bairro 'Bairro', c.cli_telefone 'Telefone',c.cli_celular 'Celular',c.cli_tipo_pessoa 'Tipo da Pessoa',
        c.cli_calJuros 'Calcular Juros', c.cli_limiteCredito 'Limite de Crédito', c.cli_limiteMensal 'Limite de Crédito Mensal'
        FROM Cliente c inner join Cidade ci on c.cid_codigo = ci.cid_codigo
        WHERE cli_codigo like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_nome like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_idade like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_data_nascimento like @descricao  and c.cli_tipo_pessoa = 'Pessoa Física' 
                     or cli_rg like @descricao and c.cli_tipo_pessoa = 'Pessoa Física' 
                     or cli_cpf like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_logradouro like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_numero like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_complemento like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_bairro like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_telefone like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_celular like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or ci.cid_nome like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_calJuros like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or cli_limiteCredito like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'
                     or c.cli_limiteMensal like @descricao and c.cli_tipo_pessoa = 'Pessoa Física'


    ELSE
        SELECT TOP 100 c.cli_codigo 'Código do Cliente', c.cli_razao_social 'Razão Social', c.cli_cnpj 'CNPJ', c.cli_ie 'Inscr. Estadual',CONVERT(VARCHAR(50),c.cli_data_fundacao,113) 'Dt. Fundação',
        ci.cid_nome 'Cidade',c.cli_logradouro 'Logradouro',c.cli_numero 'Número', c.cli_complemento 'Complemento', c.cli_bairro 'Bairro', c.cli_telefone 'Telefone',c.cli_celular 'Celular',c.cli_tipo_pessoa 'Tipo de Pessoa',
        c.cli_calJuros 'Calcular Juros', c.cli_limiteCredito 'Limite de Crédito', c.cli_limiteMensal 'Limite de Crédito Mensal'
        FROM Cliente c inner join Cidade ci on c.cid_codigo = ci.cid_codigo
        WHERE cli_codigo like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_razao_social like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_cnpj like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_ie like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_data_fundacao like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_logradouro like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_numero like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_complemento like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_bairro like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_razao_social like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_cnpj like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_ie like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_data_fundacao like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_telefone like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_celular like @descricao  and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or ci.cid_nome like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                      or cli_calJuros like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                     or cli_limiteCredito like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
                     or c.cli_limiteMensal like @descricao and c.cli_tipo_pessoa = 'Pessoa Jurídica'
    END


GO
/****** Object:  StoredProcedure [dbo].[LocalizaFornecedor]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LocalizaFornecedor] @descricao VARCHAR(150), @tipo VARCHAR(50) 
AS BEGIN 
    IF(@tipo = 'Pessoa Física')
        SELECT TOP 100 f.for_codigo 'Código do Fornecedor', f.for_nome 'Nome', f.for_rg 'RG', f.for_cpf 'CPF', 
                ci.cid_nome 'Cidade',f.for_logradouro 'Logradouro',f.for_numero 'Número', f.for_complemento 'Complemento', f.for_bairro 'Bairro', f.for_telefone 'Telefone',f.for_tipo_fornecedor 'Tipo do Fornecedor', f.for_tipo 'Prestador de Serviço'
        FROM Fornecedores f inner join Cidade ci on f.for_cidade = ci.cid_codigo
        WHERE for_codigo like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_nome like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_rg like @descricao and f.for_tipo_fornecedor = 'Pessoa Física' 
             or for_cpf like @descricao and f.for_tipo_fornecedor= 'Pessoa Física'
             or for_logradouro like @descricao and f.for_tipo_fornecedor= 'Pessoa Física'
             or for_numero like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_complemento like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_bairro like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_telefone like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or ci.cid_nome like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'
             or for_tipo like @descricao and f.for_tipo_fornecedor = 'Pessoa Física'

    ELSE

        SELECT TOP 100 f.for_codigo 'Código do Cliente', f.for_razaoSocial 'Razão Social', f.for_cnpj 'CNPJ', f.for_ie 'Inscr. Estadual',
        ci.cid_nome 'Cidade',f.for_logradouro 'Logradouro',f.for_numero 'Número', f.for_complemento 'Complemento', f.for_bairro 'Bairro',f.for_telefone 'Telefone',f.for_tipo_fornecedor 'Tipo de Pessoa', for_tipo 'Prestador de Serviço'
        FROM Fornecedores f inner join Cidade ci on f.for_cidade = ci.cid_codigo
        WHERE for_codigo like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_razaoSocial like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_cnpj like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_ie like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_logradouro like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_numero like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_complemento like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_bairro like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_razaoSocial like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_cnpj like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_ie like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_telefone like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or ci.cid_nome like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
                      or for_tipo like @descricao and f.for_tipo_fornecedor = 'Pessoa Jurídica'
    END


GO
/****** Object:  StoredProcedure [dbo].[PosicaoEstoque]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PosicaoEstoque]
AS BEGIN
SET NOCOUNT ON	
    SELECT  p.pro_nome 'Produto', p.pro_precoCusto 'Preço de Custo',p.pro_precoVenda 'Preço de Venda',
            CASE WHEN(p.pro_comissao is null) THEN 0 ELSE p.pro_comissao END 'Comissão(%)',
            c.cat_descricao 'Categoria',g.gru_descricao 'Grupo',
            CASE WHEN(sg.sg_descricao is null) THEN '' ELSE sg.sg_descricao END 'Subgrupo',
            u.uni_descricao 'Unidade'
        FROM Produtos p
         LEFT JOIN Grupo g on p.pro_grupo = g.gru_codigo
         LEFT JOIN Categoria c on p.pro_categoria = c.cat_codigo
         LEFT JOIN SubGrupo sg on p.pro_subGrupo = sg.sg_codigo
         LEFT JOIN Marcas m on p.pro_marca = m.mar_codigo
         LEFT JOIN Unidades u on p.pro_unidade = u.uni_codigo		 
    WHERE p.pro_quantidade >0
    ORDER BY p.pro_nome
END

GO
/****** Object:  StoredProcedure [dbo].[ProdutosPorMarca]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProdutosPorMarca] @marca VARCHAR(max)
AS
BEGIN

    IF(@marca='')
        BEGIN
            SELECT m.mar_descricao 'Marca',p.pro_nome 'Produto'
            FROM Produtos p inner join Marcas m on p.pro_marca =  m.mar_codigo
            /*GROUP BY m.mar_codigo,m.mar_descricao*/
        END
    ELSE
        BEGIN
            SELECT m.mar_descricao 'Marca',p.pro_nome 'Produto'
            FROM Produtos p inner join Marcas m on p.pro_marca =  m.mar_codigo
            WHERE m.mar_descricao like @marca
            /*GROUP BY m.mar_codigo,m.mar_descricao*/
        END
END
GO
/****** Object:  StoredProcedure [dbo].[ProdutosVendidosPorCliente]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProdutosVendidosPorCliente] @produtoInicial INT, @produtoFinal INT,@dataInicial DATETIME , @dataFinal DateTIME 
AS
BEGIN	
    SET NOCOUNT ON;
    SET LANGUAGE Brazilian;
    IF @produtoInicial =0 and @produtoFinal =0
    BEGIN
        SELECT c.cli_nome 'Cliente',p.pro_nome 'Produto', LEFT(CONVERT(VARCHAR(50),v.ven_dataVenda,113),11) 'Data da Compra'
        FROM Cliente c 
            INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente
            INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
            INNER JOIN Produtos p on p.pro_codigo = vi.pro_codigo
        WHERE v.ven_dataVenda between @dataInicial and @dataFinal--'01/01/2013' and '31/12/2014'--
        END
    ELSE
    BEGIN
        SELECT c.cli_nome 'Cliente',p.pro_nome 'Produto', LEFT(CONVERT(VARCHAR(50),v.ven_dataVenda,113),11) 'Data da Compra'
        FROM Cliente c 
            INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente
            INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
            INNER JOIN Produtos p on p.pro_codigo = vi.pro_codigo
        WHERE p.pro_codigo >= @produtoInicial and p.pro_codigo <= @produtoFinal 
            and v.ven_dataVenda between @dataInicial and @dataFinal
        END
END


GO
/****** Object:  StoredProcedure [dbo].[relClienteMaisCompra]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[relClienteMaisCompra] @dataInicial datetime, @dataFinal datetime
AS 
BEGIN
    SELECT TOP 100 c.cli_nome 'Cliente', (SELECT COUNT(v.ven_cliente) FROM Vendas v where v.ven_cliente = c.cli_codigo) 'Total de Vendas do Cliente' , SUM(v.ven_valorTotal)'Valor Total da Venda (R$)',SUM(v.ven_valorFinal) 'Valor Com Descontos (R$)'--, SUM(v.ven_valorTotal)'Valor Total da Venda (R$)',SUM(v.ven_valorFinal) 'Valor Com Descontos (R$)', (SUM(v.ven_valorTotal) - SUM(v.ven_valorFinal)) 'Total de Desconto (R$)' 
    FROM Cliente c INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente
    WHERE v.ven_dataVenda between '2013-01-01' and '2015-01-01'
    GROUP BY c.cli_nome,c.cli_codigo
END


GO
/****** Object:  StoredProcedure [dbo].[relContasAReceber]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[relContasAReceber] @codigoCliente INT, @dataInicial DATETIME, @dataFinal DATETIME
AS 
BEGIN 
SET NOCOUNT ON
    IF(@codigoCliente =0)
    BEGIN
        SELECT cr.cr_codigo 'Código da Conta a Receber',c.cli_codigo 'Código do Cliente', 
        CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente',
        p.pro_nome 'Produto',cr.cr_parcela 'Parcela',CASE WHEN cr.cr_valorAlterado =0 THEN cr.cr_valorOriginal else cr.cr_valorAlterado end 'Valor',cr_status 'Status'
        FROM ContasAReceber cr
             INNER JOIN Vendas v on cr.cr_vendas = v.ven_codigo
             INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
             INNER JOIN Produtos p on vi.pro_codigo = p.pro_codigo
             INNER JOIN Cliente c on v.ven_cliente = c.cli_codigo
        WHERE cr.cr_dataVencimento between @dataInicial and @dataFinal
    END
    ELSE
    BEGIN
    SELECT cr.cr_codigo 'Código da Conta a Receber',c.cli_codigo 'Código do Cliente', 
        CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente',
        p.pro_nome 'Produto',cr.cr_parcela 'Parcela',CASE WHEN cr.cr_valorAlterado =0 THEN cr.cr_valorOriginal else cr.cr_valorAlterado end 'Valor',cr_status 'Status'
        FROM ContasAReceber cr
             INNER JOIN Vendas v on cr.cr_vendas = v.ven_codigo
             INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
             INNER JOIN Produtos p on vi.pro_codigo = p.pro_codigo
             INNER JOIN Cliente c on v.ven_cliente = c.cli_codigo
        WHERE c.cli_codigo = @codigoCliente and cr.cr_dataVencimento between @dataInicial and @dataFinal
    END
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_Abertura]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rpt_Abertura]
AS
BEGIN
    SET NOCOUNT ON;
    SET LANGUAGE brazilian;
   select
           f.fin_usuario 'Código do Usuário',
           (select u.usu_nome from Usuario u where u.usu_codigo = f.fin_usuario) as Usuário,
           CONVERT(CHAR(9),f.fin_dataAbertura,113) 'Data da Abertura',
           LEFT(f.fin_horaAbertura,8) 'Hora da Abertura',
           f.fin_valorInicial 'Valor Inicial',DATENAME(MONTH,((CONVERT(VARCHAR(50),f.fin_dataAbertura,113)))) 'Mês'
      from fin_abertura_caixa f
     ORDER BY f.fin_dataAbertura DESC
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_categoria]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_categoria]
AS
BEGIN
    SET NOCOUNT ON;

   select cat_codigo'Código',
           cat_descricao 'Descrição'
      from Categoria
     order by cat_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_Clientes]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Clientes]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.cli_tipo_pessoa 'Tipo',CASE WHEN c.cli_tipo_pessoa = 'Pessoa Física' THEN c.cli_nome ELSE c.cli_razao_social END
     'Cliente', c.cli_idade 'Idade', c.cli_logradouro 'Logradouro',c.cli_numero'Nº',cid.cid_nome 'Cidade',e.est_nome 'Estado'
    FROM Cliente c 
        INNER JOIN Cidade cid on c.cid_codigo = cid.cid_codigo
        INNER JOIN Estado e on cid.cid_estado = e.est_codigo
        ORDER BY CASE WHEN c.cli_tipo_pessoa = 'Pessoa Física' THEN c.cli_nome ELSE c.cli_razao_social END
END
GO
/****** Object:  StoredProcedure [dbo].[rpt_Fechamento]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Fechamento]
AS
BEGIN
    SET NOCOUNT ON;

   select f.fin_usuario 'Código do Usuário',
          (select u.usu_nome from Usuario u where u.usu_codigo = f.fin_usuario) as Usuário,
          CONVERT(CHAR(9),f.fin_data,113) 'Data do Fechamento',
          left(f.fin_hora,8) 'Hora do Fechamento', 
          f.fin_valor		   
      from fin_fechamento_caixa f
     order by f.fin_data
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_FormaPagamento]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_FormaPagamento]
AS
BEGIN
    SET NOCOUNT ON;

  select fp_codigo 'Código',
           fp_descricao 'Descrição'
      from FormaPagamento
     order by fp_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_Fornecedor]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Fornecedor]
AS
BEGIN
    SET NOCOUNT ON;

  select 
         CASE WHEN f.for_tipo_fornecedor like 'Pessoa Jurídica' THEN f.for_razaoSocial ELSE f.for_nome END 'Fornecedor',
         f.for_email 'Email', f.for_logradouro 'Logradouro',f.for_numero 'Número',f.for_bairro 'Bairro',f.for_cep 'CEP',
         c.cid_nome 'Cidade' ,e.est_sigla 'Estado', f.for_telefone 'Telefone', f.for_fax 'Fax', f.for_tipo_fornecedor 'Tipo Fornecedor'
      from Fornecedores f INNER JOIN Cidade c on f.for_cidade = c.cid_codigo
      INNER JOIN Estado e on c.cid_estado = e.est_codigo
     order by CASE WHEN f.for_tipo_fornecedor like 'Pessoa Jurídica' THEN f.for_razaoSocial ELSE f.for_nome END
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_grupo]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_grupo]
AS
BEGIN
    SET NOCOUNT ON;

   select gru_codigo'Código',
           gru_descricao 'Descrição'
      from Grupo
     order by gru_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_Marcas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Marcas]
AS
BEGIN
    SET NOCOUNT ON;

  select mar_codigo'Código',
           mar_descricao 'Descrição'
      from Marcas
     order by mar_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_subgrupo]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_subgrupo]
AS
BEGIN
    SET NOCOUNT ON;

  select s.sg_codigo 'Código',
           s.sg_descricao 'Descrição',
           (select g.gru_descricao from Grupo g where g.gru_codigo = s.sg_grupo) as Grupo
      from SubGrupo s
     order by grupo, s.sg_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[rpt_Unidades]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rpt_Unidades]
AS
BEGIN
    SET NOCOUNT ON;

    select uni_codigo 'Código',
           uni_descricao 'Descrição'
      from Unidades
     order by uni_descricao
END

GO
/****** Object:  StoredProcedure [dbo].[sp_CaixaPorLucratividade]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CaixaPorLucratividade] @dataInicial DATETIME,@dataFinal DATETIME
AS
BEGIN
SELECT  p.pro_nome 'Produto',p.pro_precoCusto 'Preço de Custo(R$)' ,vi.vi_valorUnitario 'Valor de Venda (R$)', 
        vi.vi_valorUnitario-p.pro_precoCusto 'Lucro (R$)', (vi.vi_valorUnitario*100)/p.pro_precoCusto-100 'Lucro(%)'
From Produtos p 
RIGHT JOIN vendaItens vi on p.pro_codigo= vi.ven_codigo
         LEFT JOIN Vendas v on p.pro_codigo = p.pro_codigo
where v.ven_dataVenda between @dataInicial and @dataFinal
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CompraPorPeriodo]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_CompraPorPeriodo] @dataInicial DATETIME, @dataFinal DATETIME, @marca Varchar(100), @grupo Varchar(100)
AS 
BEGIN	

IF(@marca = '' and @grupo ='')
BEGIN
    SELECT p.pro_nome 'Produto', m.mar_descricao 'Marca', g.gru_descricao 'Grupo', cp.cp_quantidade 'Quantidade',
    cp.cp_valorUnitario 'Custo Unitário',cp.cp_subtotal 'Total', Convert(Varchar(10),c.com_dataCompra,103) 'Data da Compra'
    FROM Marcas m 
         INNER JOIN Produtos p on m.mar_codigo = p.pro_marca
         inner join Grupo g on p.pro_grupo = g.gru_codigo
         inner join comprasProduto cp on cp.cp_produtos = p.pro_codigo
         inner join Compras c on cp.cp_compras=c.com_codigo
         WHERE c.com_dataCompra between @dataInicial and @dataFinal
END

ELSE IF (@marca <> '' and @grupo ='')
BEGIN
SELECT p.pro_nome 'Produto', m.mar_descricao 'Marca', g.gru_descricao 'Grupo', cp.cp_quantidade 'Quantidade',
    cp.cp_valorUnitario 'Custo Unitário',cp.cp_subtotal 'Total', Convert(Varchar(10),c.com_dataCompra,103) 'Data da Compra'
    FROM Marcas m 
         INNER JOIN Produtos p on m.mar_codigo = p.pro_marca
         inner join Grupo g on p.pro_grupo = g.gru_codigo
         inner join comprasProduto cp on cp.cp_produtos = p.pro_codigo
         inner join Compras c on cp.cp_compras=c.com_codigo
         WHERE c.com_dataCompra between @dataInicial and @dataFinal and m.mar_descricao like @marca
END
ELSE IF (@marca = '' and @grupo <> '')
BEGIN
SELECT p.pro_nome 'Produto', m.mar_descricao 'Marca', g.gru_descricao 'Grupo', cp.cp_quantidade 'Quantidade',
    cp.cp_valorUnitario 'Custo Unitário',cp.cp_subtotal 'Total', Convert(Varchar(10),c.com_dataCompra,103) 'Data da Compra'
    FROM Marcas m 
         INNER JOIN Produtos p on m.mar_codigo = p.pro_marca
         inner join Grupo g on p.pro_grupo = g.gru_codigo
         inner join comprasProduto cp on cp.cp_produtos = p.pro_codigo
         inner join Compras c on cp.cp_compras=c.com_codigo
         WHERE c.com_dataCompra between @dataInicial and @dataFinal and g.gru_descricao like @grupo
END
ELSE
SELECT p.pro_nome 'Produto', m.mar_descricao 'Marca', g.gru_descricao 'Grupo', cp.cp_quantidade 'Quantidade',
    cp.cp_valorUnitario 'Custo Unitário',cp.cp_subtotal 'Total', Convert(Varchar(10),c.com_dataCompra,103) 'Data da Compra'
    FROM Marcas m 
         INNER JOIN Produtos p on m.mar_codigo = p.pro_marca
         inner join Grupo g on p.pro_grupo = g.gru_codigo
         inner join comprasProduto cp on cp.cp_produtos = p.pro_codigo
         inner join Compras c on cp.cp_compras=c.com_codigo
         WHERE c.com_dataCompra between @dataInicial and @dataFinal and m.mar_descricao like @marca and g.gru_descricao like @grupo
END
     
GO
/****** Object:  StoredProcedure [dbo].[sp_cupom]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_cupom] @venda int
AS
BEGIN
    SET NOCOUNT ON;
    select e.emp_razaoSocial,e.emp_logradouro,e.emp_numero,e.emp_bairro,e.emp_cep, c.cid_nome,
           e.emp_cnpj,e.emp_telefone,
           cli.cli_nome, cli_cpf, LEFT(CONVERT(VARCHAR(50),v.ven_dataVenda,113),12) 'Data da Venda',
           v.ven_valorTotal 'Total',
           v.ven_valorFinal 'Valor Final', v.ven_desconto 'Desconto',
           p.pro_nome 'Produto', vi.vi_valorUnitario 'Preço Produto', vi.vi_quantidade 'Quantidade', 
           (vi.vi_valorUnitario * vi.vi_quantidade) 'Valor Total', 
           vi.vi_desconto 'Desconto do Produto',
           (vi.vi_valorUnitario * vi.vi_quantidade - vi.vi_desconto) 'Valor Final do Produto'
      from Empresa e inner join Cidade c on e.emp_cidade = c.cid_codigo
      right join Cliente cli on c.cid_codigo = cli.cid_codigo
      INNER JOIN Vendas v on cli.cli_codigo = v.ven_cliente
      INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
      inner join Produtos p on vi.pro_codigo = p.pro_codigo
      where v.ven_codigo = @venda
END


GO
/****** Object:  StoredProcedure [dbo].[sp_ParcelasEmAtraso]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ParcelasEmAtraso]
AS
BEGIN
SELECT c.cli_nome 'Cliente',v.ven_codigo 'Venda',cr.cr_codigo 'Cod Parc',CONVERT(VARCHAR(10),cr.cr_dataVencimento,103) 'Data de Vencimento',cr.cr_parcela 'Parcela',CASE WHEN cr.cr_valorRestante is null then cr.cr_valorOriginal else cr.cr_valorRestante end 'Valor'
FROM ContasAReceber cr 
     INNER JOIN Vendas v on cr.cr_vendas = v.ven_codigo
     INNER JOIN Cliente c on v.ven_cliente = c.cli_codigo
WHERE cr.cr_status like 'Aberto' and cr.cr_dataVencimento < GETDATE()
END
GO
/****** Object:  StoredProcedure [dbo].[VendasCanceladas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VendasCanceladas]
AS BEGIN
SET NOCOUNT ON	
    SELECT v.ven_codigo 'Código da Venda', 
    CASE WHEN c.cli_tipo_pessoa = 'Pessoa Física' THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente',
    CONVERT(CHAR(11),v.ven_dataVenda,113) 'Data da Venda', u.usu_nome 'Funcionário',fp.fp_descricao 'Forma de Pagamento',
    v.ven_qtdParcelas 'Parcelas', v.ven_valorTotal 'Valor Total da Venda',
    v.ven_desconto 'Desconto (R$)', v.ven_percentualDesconto 'Desconto(%)', 
    v.ven_valorFinal 'Valor Final da Venda'--,
    --CASE WHEN v.ven_observacao is null THEN '' ELSE v.ven_observacao END 'Observação'
    FROM VENDAS v
        INNER JOIN Usuario u on v.ven_usuario = u.usu_codigo
        INNER JOIN FormaPagamento fp on v.ven_formaPagamento = fp.fp_codigo
        INNER JOIN Cliente c on c.cli_codigo =v.ven_cliente
    WHERE v.ven_status like 'Cancelado'
END

GO
/****** Object:  StoredProcedure [dbo].[VendasPorBalconista]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VendasPorBalconista] @codigoVendedor INT, @dataInicial DATETIME, @dataFinal DATETIME
AS BEGIN
SET NOCOUNT ON	
IF(@codigoVendedor <> 0)
    BEGIN
        SELECT u.usu_nome 'Vendedor', CONVERT(CHAR(11),v.ven_dataVenda,113) 'Data da Venda',p.pro_nome 'Produto', p.pro_precoVenda 'Valor da Venda', case when (p.pro_precoVenda*p.pro_comissao/100) is null then 0 else (p.pro_precoVenda*p.pro_comissao/100)  end 'Comissão(R$)'
        FROM Usuario u
            INNER JOIN Vendas v on u.usu_codigo = v.ven_usuario
            INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
            INNER JOIN Produtos p on vi.pro_codigo = p.pro_codigo
        WHERE u.usu_codigo = @codigoVendedor and v.ven_dataVenda between @dataInicial and @dataFinal
    END
ELSE 
    BEGIN 
        SELECT u.usu_nome 'Vendedor', v.ven_dataVenda 'Data da Venda',p.pro_nome 'Produto', p.pro_precoVenda 'Valor da Venda', case when (p.pro_precoVenda*p.pro_comissao/100) is null then 0 else (p.pro_precoVenda*p.pro_comissao/100)  end 'Comissão(R$)'
        FROM Usuario u
            INNER JOIN Vendas v on u.usu_codigo = v.ven_usuario
            INNER JOIN vendaItens vi on v.ven_codigo = vi.ven_codigo
            INNER JOIN Produtos p on vi.pro_codigo = p.pro_codigo
        WHERE v.ven_dataVenda between @dataInicial and @dataFinal
    END
END


GO
/****** Object:  StoredProcedure [dbo].[vendasRealizadas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[vendasRealizadas]
AS
BEGIN
SELECT fp.fp_descricao 'Forma de Pagamento',v.ven_valorFinal 'Valor',
            'Vendas Realizadas'as [Tipo] 
    FROM  Vendas v 
          INNER JOIN FormaPagamento fp on v.ven_formaPagamento = fp.fp_codigo
    WHERE v.ven_tipo like 'Venda' and CONVERT(CHAR(11),v.ven_dataVenda ,103) = CONVERT(CHAR(11),getdate(),103)
END
GO
/****** Object:  Table [dbo].[cadastroTelas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cadastroTelas](
    [ct_nome] [varchar](50) NOT NULL,
    [per_codigo] [int] NOT NULL,
    [ct_status] [varchar](5) NOT NULL,
    [ct_name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
    [cat_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cat_descricao] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
    [cat_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cidade]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cidade](
    [cid_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cid_nome] [varchar](50) NOT NULL,
    [cid_estado] [int] NOT NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
    [cid_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
    [cli_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cli_nome] [varchar](150) NULL,
    [cli_idade] [int] NULL,
    [cli_data_nascimento] [date] NULL,
    [cli_rg] [varchar](15) NULL,
    [cli_cpf] [varchar](14) NULL,
    [cli_logradouro] [varchar](150) NULL,
    [cli_numero] [varchar](10) NULL,
    [cli_complemento] [varchar](150) NULL,
    [cli_bairro] [varchar](150) NULL,
    [cid_codigo] [int] NULL,
    [cli_razao_social] [varchar](150) NULL,
    [cli_cnpj] [varchar](25) NULL,
    [cli_ie] [varchar](30) NULL,
    [cli_data_fundacao] [date] NULL,
    [cli_tipo_pessoa] [varchar](20) NOT NULL,
    [cli_telefone] [varchar](14) NULL,
    [cli_celular] [varchar](14) NULL,
    [cli_calJuros] [varchar](3) NULL,
    [cli_limiteCredito] [float] NULL,
    [cli_limiteMensal] [float] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
    [cli_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[codigoBarra]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[codigoBarra](
    [pro_codigoBarra] [varchar](50) NULL,
    [pro_precoVenda] [float] NULL,
    [pro_nome] [varchar](150) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compras](
    [com_codigo] [int] IDENTITY(1,1) NOT NULL,
    [com_dataCompra] [datetime] NOT NULL,
    [com_usuario] [int] NOT NULL,
    [com_fornecedor] [int] NOT NULL,
    [com_quantidade] [int] NOT NULL,
    [com_valorTotal] [float] NOT NULL,
    [com_observacao] [varchar](200) NULL,
    [com_status] [varchar](10) NULL,
    [com_numPedido] [int] NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
    [com_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[comprasProduto]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comprasProduto](
    [cp_compras] [int] NOT NULL,
    [cp_produtos] [int] NOT NULL,
    [cp_valorUnitario] [float] NOT NULL,
    [cp_quantidade] [int] NOT NULL,
    [cp_subtotal] [float] NOT NULL,
    [cp_chegou] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasAPagar]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasAPagar](
    [cp_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cp_compras] [int] NULL,
    [cp_titulo] [varchar](50) NOT NULL,
    [cp_serie] [varchar](50) NOT NULL,
    [cp_emissao] [datetime] NOT NULL,
    [cp_vencimento] [datetime] NOT NULL,
    [cp_valor] [float] NOT NULL,
    [cp_status] [varchar](50) NOT NULL,
    [cp_observacao] [varchar](250) NULL,
    [cp_fornecedor] [int] NULL,
    [cp_dataPagamento] [date] NULL,
 CONSTRAINT [PK_ContasAPagar] PRIMARY KEY CLUSTERED 
(
    [cp_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContasAReceber]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContasAReceber](
    [cr_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cr_vendas] [int] NOT NULL,
    [cr_dataVencimento] [date] NOT NULL,
    [cr_valorOriginal] [float] NOT NULL,
    [cr_valorAlterado] [float] NULL,
    [cr_valorPago] [float] NULL,
    [cr_status] [varchar](50) NULL,
    [cr_dataPagamento] [datetime] NULL,
    [cr_juros] [float] NULL,
    [cr_desconto] [float] NULL,
    [cr_observacao] [varchar](250) NULL,
    [cr_parcela] [varchar](50) NOT NULL,
    [cr_valorRestante] [float] NULL,
    [cr_multa] [float] NULL,
 CONSTRAINT [PK_ContasAReceber] PRIMARY KEY CLUSTERED 
(
    [cr_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
    [emp_codigo] [int] IDENTITY(1,1) NOT NULL,
    [emp_razaoSocial] [varchar](150) NOT NULL,
    [emp_nomeFantasia] [varchar](150) NOT NULL,
    [emp_logradouro] [varchar](150) NOT NULL,
    [emp_numero] [varchar](50) NOT NULL,
    [emp_bairro] [varchar](50) NOT NULL,
    [emp_cep] [varchar](9) NOT NULL,
    [emp_cidade] [int] NOT NULL,
    [emp_inscricaoEstadual] [varchar](50) NULL,
    [emp_cnpj] [varchar](50) NOT NULL,
    [emp_telefone] [varchar](13) NULL,
    [emp_fax] [varchar](13) NULL,
    [emp_valorJuros] [float] NULL,
    [emp_multa] [float] NULL,
    [emp_qtdDias] [int] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
    [emp_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
    [est_codigo] [int] IDENTITY(1,1) NOT NULL,
    [est_sigla] [char](2) NOT NULL,
    [est_nome] [varchar](150) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
    [est_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fin_abertura_caixa]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fin_abertura_caixa](
    [fin_codigo] [int] IDENTITY(1,1) NOT NULL,
    [fin_usuario] [int] NOT NULL,
    [fin_dataAbertura] [datetime] NOT NULL,
    [fin_horaAbertura] [time](7) NOT NULL,
    [fin_valorInicial] [float] NOT NULL,
 CONSTRAINT [PK_fin_abertura_caixa] PRIMARY KEY CLUSTERED 
(
    [fin_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fin_fechamento_caixa]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fin_fechamento_caixa](
    [fin_codigo] [int] IDENTITY(1,1) NOT NULL,
    [fin_usuario] [int] NOT NULL,
    [fin_data] [date] NOT NULL,
    [fin_hora] [time](7) NOT NULL,
    [fin_valor] [float] NOT NULL,
 CONSTRAINT [PK_fin_fechamento_caixa] PRIMARY KEY CLUSTERED 
(
    [fin_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormaPagamento]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormaPagamento](
    [fp_codigo] [int] IDENTITY(1,1) NOT NULL,
    [fp_descricao] [varchar](150) NOT NULL,
 CONSTRAINT [PK_FormaPagamento] PRIMARY KEY CLUSTERED 
(
    [fp_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fornecedores]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fornecedores](
    [for_codigo] [int] IDENTITY(1,1) NOT NULL,
    [for_razaoSocial] [varchar](150) NULL,
    [for_cnpj] [varchar](50) NULL,
    [for_ie] [varchar](50) NULL,
    [for_email] [varchar](150) NULL,
    [for_cep] [varchar](9) NULL,
    [for_logradouro] [varchar](150) NULL,
    [for_numero] [varchar](50) NULL,
    [for_complemento] [varchar](150) NULL,
    [for_bairro] [varchar](150) NULL,
    [for_cidade] [int] NULL,
    [for_telefone] [varchar](14) NULL,
    [for_fax] [varchar](14) NULL,
    [for_status] [char](1) NULL,
    [for_cpf] [varchar](14) NULL,
    [for_rg] [varchar](15) NULL,
    [for_tipo_fornecedor] [varchar](20) NOT NULL,
    [for_nome] [varchar](150) NULL,
    [for_tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Fornecedores] PRIMARY KEY CLUSTERED 
(
    [for_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grupo](
    [gru_codigo] [int] IDENTITY(1,1) NOT NULL,
    [gru_descricao] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
    [gru_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[licenca]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[licenca](
    [lic_codigo] [int] IDENTITY(1,1) NOT NULL,
    [lic_chave] [varchar](50) NOT NULL,
    [lic_data] [date] NOT NULL,
 CONSTRAINT [PK_licensa] PRIMARY KEY CLUSTERED 
(
    [lic_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marcas](
    [mar_codigo] [int] IDENTITY(1,1) NOT NULL,
    [mar_descricao] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
    [mar_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PagamentoDia]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagamentoDia](
    [pd_codigo] [int] IDENTITY(1,1) NOT NULL,
    [cr_codigo] [int] NOT NULL,
    [pd_valor] [float] NOT NULL,
    [pd_data] [date] NOT NULL,
 CONSTRAINT [PK_PagamentoDia] PRIMARY KEY CLUSTERED 
(
    [pd_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissao]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permissao](
    [per_codigo] [int] IDENTITY(1,1) NOT NULL,
    [per_nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
    [per_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Produtos]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produtos](
    [pro_codigo] [int] IDENTITY(1,1) NOT NULL,
    [pro_nome] [varchar](250) NOT NULL,
    [pro_quantidade] [int] NOT NULL,
    [pro_precoCusto] [decimal](18, 2) NOT NULL,
    [pro_precoVenda] [decimal](18, 2) NOT NULL,
    [pro_categoria] [int] NOT NULL,
    [pro_grupo] [int] NULL,
    [pro_subGrupo] [int] NULL,
    [pro_unidade] [int] NULL,
    [pro_estoqueMin] [int] NOT NULL,
    [pro_estoqueMax] [int] NOT NULL,
    [pro_dataCadastro] [datetime] NOT NULL,
    [pro_codigoBarra] [varchar](50) NULL,
    [pro_marca] [int] NOT NULL,
    [pro_fornecedor] [int] NULL,
    [pro_tamanho] [int] NULL,
    [pro_margem] [float] NULL,
    [pro_comissao] [float] NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
    [pro_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SubGrupo]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubGrupo](
    [sg_codigo] [int] IDENTITY(1,1) NOT NULL,
    [sg_descricao] [varchar](50) NOT NULL,
    [sg_grupo] [int] NOT NULL,
 CONSTRAINT [PK_SubGrupo] PRIMARY KEY CLUSTERED 
(
    [sg_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unidades]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unidades](
    [uni_codigo] [int] IDENTITY(1,1) NOT NULL,
    [uni_descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Unidades] PRIMARY KEY CLUSTERED 
(
    [uni_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
    [usu_codigo] [int] IDENTITY(1,1) NOT NULL,
    [usu_nome] [varchar](150) NOT NULL,
    [usu_login] [varchar](20) NOT NULL,
    [usu_senha] [varchar](20) NOT NULL,
    [usu_status] [varchar](7) NOT NULL,
    [per_codigo] [int] NOT NULL,
    [emp_codigo] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
    [usu_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vendaItens]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendaItens](
    [ven_codigo] [int] NOT NULL,
    [pro_codigo] [int] NOT NULL,
    [vi_quantidade] [int] NOT NULL,
    [vi_valorUnitario] [float] NOT NULL,
    [vi_subtotal] [float] NOT NULL,
    [vi_desconto] [float] NULL,
    [vi_percentual] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendas]    Script Date: 17/08/2014 18:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendas](
    [ven_codigo] [int] IDENTITY(1,1) NOT NULL,
    [ven_cliente] [int] NOT NULL,
    [ven_dataVenda] [datetime] NOT NULL,
    [ven_usuario] [int] NOT NULL,
    [ven_formaPagamento] [int] NULL,
    [ven_qtdParcelas] [int] NULL,
    [ven_valorTotal] [float] NOT NULL,
    [ven_observacao] [varchar](200) NULL,
    [ven_desconto] [float] NULL,
    [ven_percentualDesconto] [float] NULL,
    [ven_valorFinal] [float] NULL,
    [ven_status] [varchar](50) NULL,
    [ven_tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Vendas] PRIMARY KEY CLUSTERED 
(
    [ven_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[cadastroTelas]  WITH CHECK ADD  CONSTRAINT [FK_cadastroTelas_Permissao] FOREIGN KEY([per_codigo])
REFERENCES [dbo].[Permissao] ([per_codigo])
GO
ALTER TABLE [dbo].[cadastroTelas] CHECK CONSTRAINT [FK_cadastroTelas_Permissao]
GO
ALTER TABLE [dbo].[Cidade]  WITH CHECK ADD  CONSTRAINT [FK_Cidade_Estado] FOREIGN KEY([cid_estado])
REFERENCES [dbo].[Estado] ([est_codigo])
GO
ALTER TABLE [dbo].[Cidade] CHECK CONSTRAINT [FK_Cidade_Estado]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cidade] FOREIGN KEY([cid_codigo])
REFERENCES [dbo].[Cidade] ([cid_codigo])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cidade]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Fornecedores] FOREIGN KEY([com_fornecedor])
REFERENCES [dbo].[Fornecedores] ([for_codigo])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Fornecedores]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuario] FOREIGN KEY([com_usuario])
REFERENCES [dbo].[Usuario] ([usu_codigo])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuario]
GO
ALTER TABLE [dbo].[comprasProduto]  WITH CHECK ADD  CONSTRAINT [FK_comprasProduto_Compras] FOREIGN KEY([cp_compras])
REFERENCES [dbo].[Compras] ([com_codigo])
GO
ALTER TABLE [dbo].[comprasProduto] CHECK CONSTRAINT [FK_comprasProduto_Compras]
GO
ALTER TABLE [dbo].[comprasProduto]  WITH CHECK ADD  CONSTRAINT [FK_comprasProduto_Produtos] FOREIGN KEY([cp_produtos])
REFERENCES [dbo].[Produtos] ([pro_codigo])
GO
ALTER TABLE [dbo].[comprasProduto] CHECK CONSTRAINT [FK_comprasProduto_Produtos]
GO
ALTER TABLE [dbo].[ContasAPagar]  WITH CHECK ADD  CONSTRAINT [FK_ContasAPagar_Compras] FOREIGN KEY([cp_compras])
REFERENCES [dbo].[Compras] ([com_codigo])
GO
ALTER TABLE [dbo].[ContasAPagar] CHECK CONSTRAINT [FK_ContasAPagar_Compras]
GO
ALTER TABLE [dbo].[ContasAPagar]  WITH CHECK ADD  CONSTRAINT [FK_ContasAPagar_Fornecedores] FOREIGN KEY([cp_fornecedor])
REFERENCES [dbo].[Fornecedores] ([for_codigo])
GO
ALTER TABLE [dbo].[ContasAPagar] CHECK CONSTRAINT [FK_ContasAPagar_Fornecedores]
GO
ALTER TABLE [dbo].[ContasAReceber]  WITH CHECK ADD  CONSTRAINT [FK_ContasAReceber_Vendas] FOREIGN KEY([cr_vendas])
REFERENCES [dbo].[Vendas] ([ven_codigo])
GO
ALTER TABLE [dbo].[ContasAReceber] CHECK CONSTRAINT [FK_ContasAReceber_Vendas]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Cidade] FOREIGN KEY([emp_cidade])
REFERENCES [dbo].[Cidade] ([cid_codigo])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Cidade]
GO
ALTER TABLE [dbo].[fin_abertura_caixa]  WITH CHECK ADD  CONSTRAINT [FK_fin_abertura_caixa_Usuario] FOREIGN KEY([fin_usuario])
REFERENCES [dbo].[Usuario] ([usu_codigo])
GO
ALTER TABLE [dbo].[fin_abertura_caixa] CHECK CONSTRAINT [FK_fin_abertura_caixa_Usuario]
GO
ALTER TABLE [dbo].[fin_fechamento_caixa]  WITH CHECK ADD  CONSTRAINT [FK_fin_fechamento_caixa_Usuario] FOREIGN KEY([fin_usuario])
REFERENCES [dbo].[Usuario] ([usu_codigo])
GO
ALTER TABLE [dbo].[fin_fechamento_caixa] CHECK CONSTRAINT [FK_fin_fechamento_caixa_Usuario]
GO
ALTER TABLE [dbo].[Fornecedores]  WITH CHECK ADD  CONSTRAINT [FK_Fornecedores_Cidade] FOREIGN KEY([for_cidade])
REFERENCES [dbo].[Cidade] ([cid_codigo])
GO
ALTER TABLE [dbo].[Fornecedores] CHECK CONSTRAINT [FK_Fornecedores_Cidade]
GO
ALTER TABLE [dbo].[PagamentoDia]  WITH CHECK ADD  CONSTRAINT [FK_PagamentoDia_ContasAReceber] FOREIGN KEY([cr_codigo])
REFERENCES [dbo].[ContasAReceber] ([cr_codigo])
GO
ALTER TABLE [dbo].[PagamentoDia] CHECK CONSTRAINT [FK_PagamentoDia_ContasAReceber]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Categoria] FOREIGN KEY([pro_categoria])
REFERENCES [dbo].[Categoria] ([cat_codigo])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Categoria]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Grupo] FOREIGN KEY([pro_grupo])
REFERENCES [dbo].[Grupo] ([gru_codigo])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Grupo]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Marcas] FOREIGN KEY([pro_marca])
REFERENCES [dbo].[Marcas] ([mar_codigo])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Marcas]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_SubGrupo] FOREIGN KEY([pro_subGrupo])
REFERENCES [dbo].[SubGrupo] ([sg_codigo])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_SubGrupo]
GO
ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Unidades] FOREIGN KEY([pro_unidade])
REFERENCES [dbo].[Unidades] ([uni_codigo])
GO
ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos_Unidades]
GO
ALTER TABLE [dbo].[SubGrupo]  WITH CHECK ADD  CONSTRAINT [FK_SubGrupo_Grupo] FOREIGN KEY([sg_grupo])
REFERENCES [dbo].[Grupo] ([gru_codigo])
GO
ALTER TABLE [dbo].[SubGrupo] CHECK CONSTRAINT [FK_SubGrupo_Grupo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Empresa] FOREIGN KEY([emp_codigo])
REFERENCES [dbo].[Empresa] ([emp_codigo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Empresa]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Permissao] FOREIGN KEY([per_codigo])
REFERENCES [dbo].[Permissao] ([per_codigo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Permissao]
GO
ALTER TABLE [dbo].[vendaItens]  WITH CHECK ADD  CONSTRAINT [FK_vendaItens_Produtos] FOREIGN KEY([pro_codigo])
REFERENCES [dbo].[Produtos] ([pro_codigo])
GO
ALTER TABLE [dbo].[vendaItens] CHECK CONSTRAINT [FK_vendaItens_Produtos]
GO
ALTER TABLE [dbo].[vendaItens]  WITH CHECK ADD  CONSTRAINT [FK_vendaItens_Vendas] FOREIGN KEY([ven_codigo])
REFERENCES [dbo].[Vendas] ([ven_codigo])
GO
ALTER TABLE [dbo].[vendaItens] CHECK CONSTRAINT [FK_vendaItens_Vendas]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Cliente] FOREIGN KEY([ven_cliente])
REFERENCES [dbo].[Cliente] ([cli_codigo])
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Cliente]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_FormaPagamento] FOREIGN KEY([ven_formaPagamento])
REFERENCES [dbo].[FormaPagamento] ([fp_codigo])
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_FormaPagamento]
GO
ALTER TABLE [dbo].[Vendas]  WITH CHECK ADD  CONSTRAINT [FK_Vendas_Usuario] FOREIGN KEY([ven_usuario])
REFERENCES [dbo].[Usuario] ([usu_codigo])
GO
ALTER TABLE [dbo].[Vendas] CHECK CONSTRAINT [FK_Vendas_Usuario]
GO