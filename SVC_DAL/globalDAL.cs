using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace One.Dal
{
    public static class GlobalDAL
    {
        private static String Conexao = null;

        public static String Con
        {
            get { return Conexao; }
            set { Conexao = value; }
        }
    }
}
