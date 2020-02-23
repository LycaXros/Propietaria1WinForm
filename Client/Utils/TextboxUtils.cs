using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Utils
{
    public static class TextboxUtils
    {
        public static bool ValidateMaskedTextbox(this MaskedTextBox mtb)
        {
            //if (mtb.Text.ToString() = '00-000000-00') OR  
            if (mtb.Text.Trim(' ', '-').Length  < 13)
            {
                return false;
            }
            return true;
        }

    }
    public static class MessageUtils
    {
        public static bool BoxEliminar()
        {
            return MessageBox.Show("Estas seguro de eliminar el Item", "Eliminando", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
