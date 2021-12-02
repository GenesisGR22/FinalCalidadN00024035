using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Models
{
    public class Gastos
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public String Descripcion { get; set; }
        public decimal Monto { get; set; }
        public Cuenta Cuenta { get; set; }
        public int CuentaId { get; set; }
    }
}
