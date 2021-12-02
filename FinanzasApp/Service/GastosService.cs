using FinanzasApp.Interface;
using FinanzasApp.Models;
using FinanzasApp.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinanzasApp.Service
{
    public class GastosService : IGasto
    {
        private readonly FinanzasContext _context;

        public GastosService(FinanzasContext _context)
        {
            this._context = _context;
        }

        public void createGastos(Gastos gastos)
        {
            
            gastos.Fecha = DateTime.Now;
            _context.Gastos.Add(gastos);
            _context.SaveChanges();
            var id = gastos.CuentaId;
                
            var cuenta = _context.Cuenta.Where(a => a.Id == gastos.CuentaId).FirstOrDefault();
            cuenta.Monto -= gastos.Monto;

            _context.Update(cuenta);
            _context.SaveChanges();
        }

        public IEnumerable<Gastos> getLista()
        {
            return _context.Gastos.Include(gastos => gastos.Cuenta).ToList();

        }
    }
}
