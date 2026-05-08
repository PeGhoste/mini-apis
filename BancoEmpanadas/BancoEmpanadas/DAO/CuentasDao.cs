using BancoEmpanadas.Data;
using BancoEmpanadas.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEmpanadas.DAO
{
    public class CuentasDao
    {

        private readonly AppDbContext _context;

        public CuentasDao(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CuentasViewModel>> ObtenerCuentas()
        {
            return await _context.cuentas.ToListAsync();
        }

        public async Task<CuentasViewModel> ObtenerCuentaPorId(int idCuenta)
        {
            var res = await _context.cuentas.FirstOrDefaultAsync(c => c.idCuenta == idCuenta);

            if(res != null)
            {
                return res;
            }
            else
            {
                return null;
            }

        }

        public async Task<CuentasViewModel> CrearCuenta(CuentasViewModel cuenta)
        {
            _context.cuentas.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }

        public async Task<CuentasViewModel> ActualizarCuenta(int idCuenta, CuentasViewModel cuenta)
        {
            var res = await _context.cuentas.FindAsync(idCuenta);

            try
            {
                if (res != null)
                {
                    res.tipoCuenta = cuenta.tipoCuenta;
                    res.saldo = cuenta.saldo;
                    res.estado = cuenta.estado;

                    await _context.SaveChangesAsync();
                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public async Task<bool> EliminarCuenta (int IdCuenta)
        {
            var res = await _context.cuentas.FindAsync(IdCuenta);

            if(res != null)
            {
                var cuentaBanco = await _context.cuentas.FirstOrDefaultAsync(c => c.idCuenta ==1);
                
                if(cuentaBanco != null){
                    cuentaBanco.saldo += res.saldo;
                };

                _context.Remove(res);
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }




    }
}
