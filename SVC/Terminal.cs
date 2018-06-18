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
    public partial class Terminal : Form
    {
        public Terminal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            Contexto objD;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = textBox1.Text;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                cmd = null;
                objD = null;
                throw ex;
            }
            finally
            {
                cmd = null;
                objD = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            Contexto objD;
            try{
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = textBox1.Text;
                tab = objD.ExecutaConsulta(cmd);
            }catch (Exception ex){
                cmd = null;
                objD = null;
                throw ex;
            }
            finally{
                cmd = null;
                objD = null;
            }

            dataGridView1.DataSource = tab;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "BACKUP DATABASE [Siav] TO DISK='C:/bd/AdventureWorks2.bak'";
        }
    }
}




