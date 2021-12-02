using FinanzasApp.Interface;
using FinanzasApp.Models;
using FinanzasApp.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Service
{
    public class CuentaService : ICuenta
    {
        private readonly FinanzasContext _context;

        public CuentaService(FinanzasContext _context)
        {
            this._context = _context;
        }

        public void createCuenta(Cuenta cuenta)
        {
            _context.Cuenta.Add(cuenta);
            _context.SaveChanges();
        }

        public Cuenta Cuenta(int id)
        {
            return _context.Cuenta.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<Cuenta> getLista()
        {
            return _context.Cuenta;
        }
    }
}
