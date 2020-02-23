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
    public static class StringUtils
    {
        public static bool validaCedula(this string pCedula)

        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
    }
}
