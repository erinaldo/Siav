
using One.MENUS;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace One.Loja
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmFechamentoDetalhe());

            Application.Run(new frmLoadCaixa());
            //Application.Run(new frmPDV(""));
            
            //Application.Run(new ());
            

            //Application.Run(new frmPDV());    

            //Application.Run(new franelProdutos());
            //Application.Run(new frmPDVManager());  
        }

    }
}
