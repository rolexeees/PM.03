using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TeleconNevaCommunication
{
    internal class Manager
    {
        public static Frame MainFrame { get; set; }
        public static int codVhoda = 11111111;
        public static int CodVhoda
        {
            get { return codVhoda; }
            set { codVhoda = value; }
        }
    }
}
