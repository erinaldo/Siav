using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class bd_pg
    {
        private NpgsqlConnection Conexao;
        private NpgsqlTransaction Trans { get; set; }
        public NpgsqlCommand Comando { get; set; }
        public string ConnectionString { get; set; }

        public bd_pg()
        {
            this.ConnectionString = "DATABASE=sat;Pooling=False;SERVER=177.125.27.78;PORT=5433;UID=sistema;Password=q2aw3@se4;";
        }

        public bd_pg(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }


        public void AbrirConexao()
        {
            if (string.IsNullOrEmpty(this.ConnectionString)) throw new Exception("Não foi informado a ConnectionString.");
            try
            {
                Conexao = new NpgsqlConnection();
                Conexao.ConnectionString = this.ConnectionString;
                Conexao.Open();
            }
            catch (NpgsqlException e)
            {
                throw new Exception("Status atual do banco :" + Conexao.FullState.ToString() + " </ br> Descrição do erro: " + e.Message);
            }
        }
        public void FechaConexao()
        {
            if (Conexao != null && Conexao.State == ConnectionState.Open)
            {
                Conexao.Close();
            }
        }

        #region Transation
        public void Transation_Begin()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            try
            {
                this.Trans = Conexao.BeginTransaction();
            }
            catch (Exception e)
            {
                throw new Exception("Status atual do banco :" + Conexao.FullState.ToString() + " </ br> Descrição do erro: " + e.Message);
            }
        }
        public void Transation_Commit()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Trans == null) throw new Exception("Trasação não iniciada. Execute o comando 'Transation_Begin' e não se esqueça de FecharConexao no final.");

            try
            {
                this.Trans.Commit();
            }
            catch (Exception e)
            {
                throw new Exception("Status atual do banco :" + Conexao.FullState.ToString() + " </ br> Descrição do erro: " + e.Message);
            }
        }
        public void Transation_Rollback()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Trans == null) throw new Exception("Trasação não iniciada. Execute o comando 'Transation_Begin' e não se esqueça de FecharConexao no final.");

            try
            {
                this.Trans.Rollback();
            }
            catch (Exception e)
            {
                throw new Exception("Status atual do banco :" + Conexao.FullState.ToString() + " </ br> Descrição do erro: " + e.Message);
            }
        }
        #endregion


        public IDataReader RetornaDados(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            IDataReader reader = command.ExecuteReader();
            return reader;
        }

        public IDataReader RetornaDados_v2()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed)
                throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Comando == null || Comando.CommandText.Length < 5)
                throw new Exception("Não ha instrução a ser executada.");

            this.Comando.Connection = this.Conexao;
            IDataReader reader = this.Comando.ExecuteReader();
            return reader;
        }
        public IDataReader RetornaDados_Procedure(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            NpgsqlCommand command = new NpgsqlCommand(sql, this.Conexao);
            command.CommandType = CommandType.StoredProcedure;
            IDataReader reader = command.ExecuteReader();

            return reader;
        }
        public IDataReader RetornaDados_Procedure()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed)
                throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Comando == null || Comando.CommandText.Length < 5)
                throw new Exception("Não ha instrução a ser executada.");

            this.Comando.Connection = this.Conexao;
            this.Comando.CommandType = CommandType.StoredProcedure;
            IDataReader reader = this.Comando.ExecuteReader();

            return reader;
        }

        public int ExecutaComando(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            int result = 0;
            result = command.ExecuteNonQuery();

            return result;
        }
        public int ExecutaComando_v2()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed)
                throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Comando == null || Comando.CommandText.Length < 5)
                throw new Exception("Não ha instrução a ser executada.");

            this.Comando.Connection = this.Conexao;
            int result = 0;
            result = this.Comando.ExecuteNonQuery();
            return result;
        }

        public int RetornaID(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            return Convert.ToInt32(command.ExecuteScalar());
        }
        public int RetornaID_v2()
        {
            if (Conexao == null || Conexao.State == ConnectionState.Closed)
                throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");
            if (Comando == null || Comando.CommandText.Length < 5)
                throw new Exception("Não ha instrução a ser executada.");

            this.Comando.Connection = this.Conexao;
            return Convert.ToInt32(this.Comando.ExecuteScalar());
        }

        public int ExecutaCount(string sql)
        {
            if (string.IsNullOrEmpty(sql)) throw new Exception("Não foi informado a query SQL.");
            if (Conexao == null || Conexao.State == ConnectionState.Closed) throw new Exception("A conexão fechada. Execute o comando AbrirConexao e não se esqueça de FecharConexao no final.");

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.Conexao;
            command.CommandText = sql;
            int result = Convert.ToInt32(command.ExecuteScalar());

            return result;

        }

    }
}
