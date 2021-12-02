using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public decimal Monto { get; set; }
 
    }
}
