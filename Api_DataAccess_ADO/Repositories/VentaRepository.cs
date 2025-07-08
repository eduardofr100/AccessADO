using Api_DataAccess_ADO.Data;
using Api_DataAccess_ADO.Models.Entities;
using Api_DataAccess_ADO.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api_DataAccess_ADO.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        public readonly AdoDbContext _context;

        public VentaRepository(AdoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateVenta(Venta venta)
        {
            var parameters = new[]
            {
                new SqlParameter("@producto", venta.Producto),
                new SqlParameter("@cantidad", venta.Cantidad),
                new SqlParameter("@precio", venta.Precio),
                new SqlParameter("@totalGanancia", venta.TotalGanancia),
                new SqlParameter("@creadoPor", venta.CreadoPor),
                new SqlParameter("@creadoEn", venta.CreadoEn),
                new SqlParameter("@actualizadoPor", venta.ActualizadoPor),
                new SqlParameter("@actualizadoEn", venta.ActualizadoEn)
            };

            var result = await _context.EjecutarAsync("sp_Create_Venta", parameters);

            return result;
        }

        public async Task<bool> UpdateVenta(Venta venta)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", venta.Id),
                new SqlParameter("@producto", venta.Producto),
                new SqlParameter("@cantidad", venta.Cantidad),
                new SqlParameter("@precio", venta.Precio),
                new SqlParameter("@totalGanancia", venta.TotalGanancia),
                new SqlParameter("@creadoPor", venta.CreadoPor),
                new SqlParameter("@creadoEn", venta.CreadoEn),
                new SqlParameter("@actualizadoPor", venta.ActualizadoPor),
                new SqlParameter("@actualizadoEn", venta.ActualizadoEn)
            };

            var result = await _context.EjecutarAsync("sp_Update_Venta", parameters);

            return result;
        }

        public async Task<bool> DeleteVenta(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", id)
            };

            var result = await _context.EjecutarAsync("sp_Delete_Venta", parameters);

            return result;
        }

        public async Task<Venta> GetByIdVenta(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", id)
            };

            var result = await _context.BuscarPorIdAsync("sp_GetById_Venta", parameters);

            if (result == null)
                return null;

            return new Venta
            {
                Id = Convert.ToInt32(result["id"]),
                Producto = result["producto"].ToString(),
                Cantidad = Convert.ToInt32(result["cantidad"]),
                Precio = Convert.ToDecimal(result["precio"]),
                TotalGanancia = Convert.ToDecimal(result["totalGanancia"]),
                CreadoPor = result["creadoPor"].ToString(),
                CreadoEn = Convert.ToDateTime(result["creadoEn"]),
                ActualizadoPor = result["actualizadoPor"].ToString(),
                ActualizadoEn = Convert.ToDateTime(result["actualizadoEn"])
            };
        }

        public async Task<IEnumerable<Venta>> GetAllVenta()
        {
            var result = await _context.ListarAsync("sp_GetAll_Venta");

            var lista = new List<Venta>();

            foreach (DataRow row in result.Rows)
            {
                lista.Add(new Venta
                {
                    Id = Convert.ToInt32(row["id"]),
                    Producto = row["producto"].ToString(),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Precio = Convert.ToDecimal(row["precio"]),
                    TotalGanancia = Convert.ToDecimal(row["totalGanancia"]),
                    CreadoPor = row["creadoPor"].ToString(),
                    CreadoEn = Convert.ToDateTime(row["creadoEn"]),
                    ActualizadoPor = row["actualizadoPor"].ToString(),
                    ActualizadoEn = Convert.ToDateTime(row["actualizadoEn"])
                });
            }

            return lista;
        }
    }
}
