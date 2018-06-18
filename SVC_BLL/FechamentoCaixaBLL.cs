using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class FechamentoCaixaBLL
    {
        public int codigo { get; set; }
        public int usuario { get; set; }
        public DateTime data { get; set; }
        public TimeSpan hora { get; set; }
        public Decimal valor { get; set; }
        public string caixa { get; set; }
        public int IDAber { get; set; }

        FechamentoCaixaDAL objDAL = null;

        public FechamentoCaixaBLL()
        {}

        public void limpar()
        {
            this.codigo = 0;
            this.usuario = 0;
            this.data = DateTime.Now;
            this.hora = TimeSpan.FromHours(DateTime.Now.Hour);
            this.valor = 0;
            this.caixa = "";
            this.IDAber = 0;
        }

        public void inserir()
        {
            objDAL = new FechamentoCaixaDAL();
            objDAL.inserir(this.usuario, this.data, this.hora, this.valor,this.caixa,this.IDAber);
            objDAL = null;
        }

        public bool JaFechou(int Usuario, int IDAber)
        {
            try
            {
                DataTable tab;
                objDAL = new FechamentoCaixaDAL();
                tab = objDAL.jaFechou(Usuario,IDAber);
                objDAL = null;
              if (tab.Rows[0][0].ToString() != "0")
                  return true;
                
                else
                
                    return false;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public DataTable CaixaInicial()
        {
            try
            {
                DataTable tab;
                objDAL = new FechamentoCaixaDAL();
                tab = objDAL.CaixaInicial();
                objDAL = null;
                if (tab.Rows.Count>0)
                    this.valor = Decimal.Parse(tab.Rows[0][0].ToString());
                else
                    this.valor = 0;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable FechamentoTotalDia()
        {
            try
            {
                DataTable tab;
                objDAL = new FechamentoCaixaDAL();
                tab = objDAL.FechamentoTotalDia();
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
