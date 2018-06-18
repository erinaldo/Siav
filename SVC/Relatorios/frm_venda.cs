using One.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using View;

namespace One.Relatorios
{
    public partial class frm_venda : Form
    {
        VendasBLL objVen = new VendasBLL();
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        public frm_venda()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tab = null;
            tab = objVen.LocalizarRelatorioVenda(periodo_inicial.Text,periodo_final.Text);

           // for (int i = 0; i < tab.Rows.Count ; i++)
           // {
           //     String x = tab.Rows[i]["N° SAT"].ToString();
           //    // XmlReadMode x  
           //
           //     tab.Rows[i]["N° SAT"] = x;
           //     
           // }
            
            dataGridView1.DataSource = tab;
            //stiloGrid();
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

               if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                    String filePath = folderBrowserDialog1.SelectedPath;
                    XcelApp.ActiveWorkbook.SaveAs(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

          
        
    }
}
