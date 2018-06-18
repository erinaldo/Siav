using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class ConexaoDAL
    {
        Contexto objD = null;


        public ConexaoDAL()
        {
        }

        public void inserir(String Nome, String Servidor, String Banco, String Usuario, String  Senha)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Conexao" +
                    "(Nome, Servidor, Banco, Usuario, Senha)" +
                    " VALUES (@Nome, @Servidor, @Banco, @Usuario, @Senha)";
                cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = Nome;
                cmd.Parameters.Add(new SqlParameter("@Servidor", SqlDbType.VarChar)).Value = Servidor;
                cmd.Parameters.Add(new SqlParameter("@Banco", SqlDbType.VarChar)).Value = Banco;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = Usuario;
                cmd.Parameters.Add(new SqlParameter("@Senha", SqlDbType.Int)).Value = Senha;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //alterar
        public void alterar(int id, String Nome, String Servidor, String Banco, String Usuario, String Senha)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Conexao" +
                    " SET Nome=@Nome,Servidor = @Servidor, Banco = @Banco, Usuario = @Usuario," +
                    " Senha = @Senha" +
                    " WHERE" +
                    " Id =@Id";
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = id;
                cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = Nome;
                cmd.Parameters.Add(new SqlParameter("@Servidor", SqlDbType.VarChar)).Value = Servidor;
                cmd.Parameters.Add(new SqlParameter("@Banco", SqlDbType.VarChar)).Value = Banco;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = Usuario;
                cmd.Parameters.Add(new SqlParameter("@Senha", SqlDbType.Int)).Value = Senha;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }
        //Excluir
        public void excluir(int id)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Conexao" +
                    " WHERE" +
                    " Id=@Id";
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }


    }

}