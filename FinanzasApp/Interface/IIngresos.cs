using FinanzasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Interface
{
    public interface IIngresos
    {
        IEnumerable<Ingresos> getLista();
        void createIngresos(Ingresos ingresos);
    }
}
