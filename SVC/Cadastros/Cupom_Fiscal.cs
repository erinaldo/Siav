using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class Cupom_Fiscal : Form
    {


        public Cupom_Fiscal()
        {
            InitializeComponent();

            if (File.Exists("C:/Rede_Sistema/msg_cupom.txt"))            
                txt_msg_fiscal.Text = System.IO.File.ReadAllText("C:/Rede_Sistema/msg_cupom.txt");
            


            



            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:/Rede_Sistema/msg_cupom.txt"))
                File.Delete("C:/Rede_Sistema/msg_cupom.txt");

            File.WriteAllText("C:/Rede_Sistema/msg_cupom.txt", txt_msg_fiscal.Text);
            MessageBox.Show("Mensagem salva com sucesso !");
        }
    }
}
