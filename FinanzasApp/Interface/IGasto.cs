using FinanzasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Interface
{
    public interface IGasto
    {
        IEnumerable<Gastos> getLista();
        void createGastos(Gastos gastos);
    }
}
