using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class VendedorBll
    {
        #region Propriedades

        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
 
	    #endregion

        #region Métodos

        public int IncluirVendedor(VendedorBll novoVendedor)
        {
            VendedorDal vendedorDal = new VendedorDal();

            int idVendedorNovo = vendedorDal.IncluirVendedor(novoVendedor.NomeVendedor);

            return idVendedorNovo;
        }

        public void AlterarVendedor(VendedorBll novoVendedor)
        {
            VendedorDal vendedorDal = new VendedorDal();

            vendedorDal.AlterarVendedor(novoVendedor.IdVendedor, novoVendedor.NomeVendedor);
        }

        public void ExcluirVendedor(int idVendedor)
        {
            VendedorDal vendedorDal = new VendedorDal();

            vendedorDal.ExcluirVendedor(idVendedor);
        }

        public DataTable ConsultarTodosVendedor()
        {
            VendedorDal vendedorDal = new VendedorDal();

            DataTable dtVendedor = vendedorDal.ConsultarTodosVendedor();

            return dtVendedor;
        }

        public DataTable ConsultarVendedorComFiltro(VendedorBll vendedor)
        {
            VendedorDal vendedorDal = new VendedorDal();

            DataTable dtVendedor = vendedorDal.ConsultarVendedorComFiltro(vendedor.IdVendedor, vendedor.NomeVendedor);

            return dtVendedor;
        }

        public VendedorBll ConsultarVendedorPorPosicao(PosicaoVendedor posicaoVendedor, int idVendedorAtual)
        {
            VendedorBll vendedorEncontrato = new VendedorBll();;

            VendedorDal vendedorDal = new VendedorDal();
                
            DataTable dtVendedor = vendedorDal.ConsultarVendedorPorPosicao((One.Dal.Posicao)posicaoVendedor, idVendedorAtual);

            if (dtVendedor.Rows.Count > 0 && dtVendedor.Rows[0][0] != DBNull.Value)
            {
                vendedorEncontrato.IdVendedor = Convert.ToInt32(dtVendedor.Rows[0]["id"]);
                vendedorEncontrato.NomeVendedor = dtVendedor.Rows[0]["nome"].ToString();
            }                

            return vendedorEncontrato;
        }

        public DataTable ConsultarVendedorPorTodosFiltros(string textoPesquisa)
        {
            VendedorDal vendedorDal = new VendedorDal();

            DataTable dtVendedor = vendedorDal.ConsultarVendedorPorTodosFiltro(textoPesquisa);

            return dtVendedor;
        }

        #endregion
    }

    public enum PosicaoVendedor 
    {
        Primeiro = 0,
        Proximo = 1,
        Anterior = 2,
        Ultimo = 3
    }
}
