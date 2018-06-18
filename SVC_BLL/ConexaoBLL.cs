using One.Dal;
using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class ConexaoBLL
    {
        #region Propriedades
        
        public int id               { get; set; }
        public String Nome          { get; set; }
        public String Servidor      { get; set; }
        public String Banco         { get; set; }
        public String Usuario       { get; set; }
        public string Senha         { get; set; }
        
        #endregion

        public ConexaoDAL objDAL = new ConexaoDAL();


          public ConexaoBLL()
          {
          }

        //

          public Boolean testa_conexao()
          {
              Contexto objD = new Contexto();
              return objD.testa_conexao();
          }

          public void Limpar()
          {
              this.id = 0;
              this.Nome = null;
              this.Servidor = null;
              this.Banco = null;
              this.Usuario = null;
              this.Senha = null;
             
          }

          public void Inserir()
          {
              try
              {
                  objDAL = new ConexaoDAL();
                  objDAL.inserir(this.Nome, this.Servidor, this.Banco, this.Usuario, this.Senha);
                  objDAL = null;
              }
              catch (Exception)
              {
                  throw;
              }
          }

          public void Alterar()
          {
              try
              {
                  objDAL = new ConexaoDAL();
                  objDAL.alterar(this.id,this.Nome, this.Servidor, this.Banco, this.Usuario, this.Senha);
                  objDAL = null;
              }
              catch (Exception)
              {
                  throw;
              }
          }

          public void Excluir()
          {
              try
              {
                  objDAL = new ConexaoDAL();
                  objDAL.excluir(this.id);
                  objDAL = null;
              }
              catch (Exception)
              {

                  throw;
              }
          }

       
    }
}
