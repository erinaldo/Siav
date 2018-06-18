using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class AberturaCaixaBLL
    {
        public int codigo { get; set; }
        public int usuario { get; set; }
        public DateTime data { get; set; }
        public TimeSpan hora { get; set; }
        public Decimal valor { get; set; }
        public string caixa { get; set; }
        public string fechou { get; set; }

        AberturaCaixaDAL objDAL = null;

        public AberturaCaixaBLL()
        { }

        public void limpar()
        {
            this.codigo = 0;
            this.usuario = 0;
            this.data = DateTime.Now;
            this.hora = TimeSpan.FromHours(DateTime.Now.Hour);
            this.valor = 0;
            this.caixa = "";
        }

        public void inserir()
        {
            objDAL = new AberturaCaixaDAL();
            objDAL.inserir(this.usuario, this.data, this.hora, this.valor, this.caixa);
            objDAL = null;
        }

        public void inserirDia()
        {
            objDAL = new AberturaCaixaDAL();
            //VendasDAL objVen = new VendasDAL();
            //DataTable tab = new DataTable();
            //tab = objVen.vendasDia();
            //if (tab.Rows.Count > 0)
            //{
                //this.valor = double.Parse(tab.Rows[0][0].ToString()); ;
            //}
            objDAL.inserir(this.usuario, this.data, this.hora, this.valor,this.caixa);
            objDAL = null;
        }

        //verifica se é a primeira vez que loga no sistema
        public void isPrimeiraVez(int usuario)
        {
            try
            {
                DataTable tab;
                objDAL = new AberturaCaixaDAL();
                tab = objDAL.isPrimeiraVez(usuario);
                objDAL = null;
                if (tab.Rows.Count > 0)
                {
                    if(tab.Rows[0][0].ToString()!= "")
                    this.codigo = int.Parse(tab.Rows[0][0].ToString()); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //verifica se é a primeira vez que loga no sistema no dia
        public void isPrimeiraVezDia(int usuario)
        {
            try
            {
                DataTable tab;
                objDAL = new AberturaCaixaDAL();
                tab = objDAL.isPrimeiraVezDia(usuario);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0][0].ToString());
                  
                }
                else
                    this.codigo = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public void PrimeiroDia()
        {
            try
            {
                DataTable tab;
                objDAL = new AberturaCaixaDAL();
                tab = objDAL.PrimeiroDia();
                if (tab.Rows.Count > 0)
                    this.valor = Decimal.Parse(tab.Rows[0][0].ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void isPrimeiraVezFechou(int usuario)
        {
            try
            {
                DataTable tab;
                objDAL = new AberturaCaixaDAL();
                tab = objDAL.isPrimeiraVezFechou(usuario);
                if (tab.Rows.Count > 0)
                {
                    if (tab.Rows[0][0].ToString() == "1")
                        this.fechou = tab.Rows[0][0].ToString();
                }
                else
                    this.fechou = "0";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
