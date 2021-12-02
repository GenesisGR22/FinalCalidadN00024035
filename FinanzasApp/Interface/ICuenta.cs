using FinanzasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Interface
{
    public interface ICuenta
    {
        IEnumerable<Cuenta> getLista();
        void createCuenta(Cuenta cuenta);

        Cuenta Cuenta(int id);
       
    }
}
