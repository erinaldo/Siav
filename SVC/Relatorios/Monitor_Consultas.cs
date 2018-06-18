using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One
{
    public partial class Monitor_Consultas : Form
    {
        
        //Dados con = new Dados();
        public string DBConn = GlobalDAL.Con = "server = 201.57.38.2;" +
                    " initial catalog= OneERP;" +
                   "user=One;password=Khaddmuswest01";
        private SqlConnection Connection
        {
            get
            {
                SqlConnection ConnectionToFetch = new SqlConnection(DBConn);
                ConnectionToFetch.Open();
                return ConnectionToFetch;
            }
        }
        public Monitor_Consultas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
       }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbxPeriodo.Visible = false;
            gbxCupomVenda.Visible = false;
            dataGridView1.DataSource = null;

            dynamic SelectQry = "Exec rpt_Clientes";
            DataSet dt = new DataSet();
            DataView Table = null;

            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(dt);
                Table = dt.Tables[0].DefaultView;
                dataGridView1.DataSource = Table;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // return Table;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gbxCupomVenda.Visible = false;
            gbxPeriodo.Visible = false;
            dataGridView1.DataSource = null;

            dynamic SelectQry = "Exec rpt_Fornecedor";
            DataSet dt = new DataSet();
            DataView Table = null;

            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(dt);
                Table = dt.Tables[0].DefaultView;
                dataGridView1.DataSource = Table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // return Table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDtInicial.Focus();
            gbxPeriodo.Visible = true;
            btnPesquisarPeriodo.Visible = true;
            dataGridView1.DataSource = null;
            gbxCupomVenda.Visible = false;
           
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gbxCupomVenda.Visible = false;
            btnPesquisarPeriodo.Visible = true;
            txtDtInicial.Focus();
            dynamic SelectQry = "Exec ContasAPagarAberto  '" + txtDtInicial.Text + "'," + "'" + txtDtFinal.Text + "'";
            DataSet dt = new DataSet();
            DataView Table = null;
                        try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(dt);
                Table = dt.Tables[0].DefaultView;
                dataGridView1.DataSource = Table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // return Table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gbxCupomVenda.Visible = false;
            dynamic SelectQry = "Exec PosicaoEstoque";
            DataSet dt = new DataSet();
            DataView Table = null;
            try
            {
                SqlCommand SampleCommand = new SqlCommand();
                dynamic SampleDataAdapter = new SqlDataAdapter();
                SampleCommand.CommandText = SelectQry;
                SampleCommand.Connection = Connection;
                SampleDataAdapter.SelectCommand = SampleCommand;
                SampleDataAdapter.Fill(dt);
                Table = dt.Tables[0].DefaultView;
                dataGridView1.DataSource = Table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // return Table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gbxCupomVenda.Visible = true;
            txtNumeroVenda.Focus();
            dataGridView1.DataSource = null;

           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ctarec.Text == "true")
            {
                dynamic SelectQry = "relContasAReceber   " + txtNumeroVenda.Text + ",'" + txtDtInicial.Text + "'," + "'" + txtDtFinal.Text + "'";
                DataSet dt = new DataSet();
                DataView Table = null;
                try
                {
                    SqlCommand SampleCommand = new SqlCommand();
                    dynamic SampleDataAdapter = new SqlDataAdapter();
                    SampleCommand.CommandText = SelectQry;
                    SampleCommand.Connection = Connection;
                    SampleDataAdapter.SelectCommand = SampleCommand;
                    SampleDataAdapter.Fill(dt);
                    Table = dt.Tables[0].DefaultView;
                    dataGridView1.DataSource = Table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                dynamic SelectQry = "Exec sp_cupom   " + txtNumeroVenda.Text;
                DataSet dt = new DataSet();
                DataView Table = null;
                try
                {
                    SqlCommand SampleCommand = new SqlCommand();
                    dynamic SampleDataAdapter = new SqlDataAdapter();
                    SampleCommand.CommandText = SelectQry;
                    SampleCommand.Connection = Connection;
                    SampleDataAdapter.SelectCommand = SampleCommand;
                    SampleDataAdapter.Fill(dt);
                    Table = dt.Tables[0].DefaultView;
                    dataGridView1.DataSource = Table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnContasaReceber_Click(object sender, EventArgs e)
        {
            gbxPeriodo.Visible = true;
            btnPesquisarPeriodo.Visible = false;
            dataGridView1.DataSource = null;
            txtDtInicial.Focus();
            gbxCupomVenda.Visible = true;
            gbxCupomVenda.Text = "Código Cliente";
            ctarec.Text = "true";
            

        }
            
        }

        

      
      
    }
