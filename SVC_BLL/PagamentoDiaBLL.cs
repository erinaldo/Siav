using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class PagamentoDiaBLL
    {
        public int pd_codigo { get; set; }
        public int cr_codigo { get; set; }
        public Decimal pd_valor { get; set; }
        public DateTime pd_data { get; set; }

        public void inserir()
        {
            try
            {
                PagamentoDiaDAL objPD = new PagamentoDiaDAL();
                objPD.inserir(this.cr_codigo,this.pd_valor,this.pd_data);
                objPD = null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
