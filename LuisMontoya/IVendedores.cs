using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisMontoya
{
    public class IVendedores
    {
        public interface IVendedor1
        {
            void VentasContado(); // Método para ventas al contado
        }

        public interface IVendedor2
        {
            string VentasCredito(); // Método para ventas a crédito
        }
    }
}
