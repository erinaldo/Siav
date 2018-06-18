using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmPDV_Mesa : Form
    {

        public Boolean fecha_mesa = false;
        public Int32 numero_mesa = 0;

        public frmPDV_Mesa()
        {
            InitializeComponent();
            atualiza_status_das_mesas();
            
            //  button1.Visible = false;
            //  button2.Visible = false;  
            //  button3.Visible = false;
            //  button4.Visible = false;
            //  button5.Visible = false;
            //  button6.Visible = false;
            //  button7.Visible = false;
            //  button8.Visible = false;
            //  button9.Visible = false;
            //  button10.Visible = false;
        }

        public void atualiza_status_das_mesas()
        {
            MesaBLL cmd = new MesaBLL();
            
            cmd.id = 1;
            if (cmd.verifica_se_mesa_esta_aberta())
            {
                button1.ForeColor = Color.Red;
                button1.Text = "1 Indisponível";
            }
            else
            {
                button1.ForeColor = Color.Green;
                button1.Text = "1 Disponível";
            }
          // cmd.id = 2;
          // if (cmd.verifica_se_mesa_esta_aberta())
          //     btn_mesa_2.ForeColor = Color.Green;
          // else
          //     btn_mesa_2.ForeColor = Color.Red;
          //
          // cmd.id = 3;
          // if (cmd.verifica_se_mesa_esta_aberta())
          //     btn_mesa_3.ForeColor = Color.Green;
          // else
          //     btn_mesa_3.ForeColor = Color.Red;
        }

        public void Abrir_gerencia_mesa(Int32 mesa){

           // Mesa
            //MesaBll cmd = new MesaBll();
            MesaBLL cmd = new MesaBLL();
            cmd.id = mesa;

            frmPDV_Mesa_Gerencia frm = new frmPDV_Mesa_Gerencia();

            if (cmd.verifica_se_mesa_esta_aberta())
            {                

                frm.id_mesa = mesa;                
                frm.carrega_dados_mesa();
                atualiza_status_das_mesas();
                frm.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Esta mesa não esta aberta, deseja abrir a mesa ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes){
                    cmd.id = mesa;
                    cmd.abrir_mesa();

                    frm.id_mesa = mesa;                    
                    frm.carrega_dados_mesa();
                    atualiza_status_das_mesas();
                    frm.ShowDialog();
                }
            }

            if (frm.fecha_mesa)
            {
                this.fecha_mesa = true;
                this.numero_mesa = frm.id_mesa;
                this.Close();
            }           

            
        }
        
        private void button1_Click(object sender, EventArgs e){
            Abrir_gerencia_mesa(1);    
        }

        private void button2_Click(object sender, EventArgs e){
            Abrir_gerencia_mesa(2);    
        }

        private void button3_Click(object sender, EventArgs e){
            Abrir_gerencia_mesa(3);    
        }

        private void button4_Click(object sender, EventArgs e){
            Abrir_gerencia_mesa(4);  
        }

    }
}
