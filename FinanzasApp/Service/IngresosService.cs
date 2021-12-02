using FinanzasApp.DB;
using FinanzasApp.Interface;
using FinanzasApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasApp.Service
{
    public class IngresosService : IIngresos
    {
        private readonly FinanzasContext _context;

        public IngresosService(FinanzasContext _context)
        {
            this._context = _context;
        }

        public void createIngresos(Ingresos ingresos)
        {

            ingresos.Fecha = DateTime.Now;
            _context.Ingresos.Add(ingresos);
            _context.SaveChanges();
            var id = ingresos.CuentaId;

            var cuenta = _context.Cuenta.Where(a => a.Id == ingresos.CuentaId).FirstOrDefault();
            cuenta.Monto += ingresos.Monto;

            _context.Update(cuenta);
            _context.SaveChanges();
        }

        public IEnumerable<Ingresos> getLista()
        {
            return _context.Ingresos.Include(ingresos => ingresos.Cuenta).ToList();

        }

     
    }
}
