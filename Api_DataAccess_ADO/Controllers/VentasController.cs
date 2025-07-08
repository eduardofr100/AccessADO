using Api_DataAccess_ADO.Data;
using Api_DataAccess_ADO.Models;
using Api_DataAccess_ADO.Models.Dtos;
using Api_DataAccess_ADO.Models.Entities;
using Api_DataAccess_ADO.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_DataAccess_ADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly VentaService _ventaService;

        public VentasController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetByIdVenta(int id)
        {
            var escuela = await _ventaService.GetByIdVenta(id);
            if (escuela == null)
            {
                return NotFound();
            }
            return Ok(escuela);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetAllVenta()
        {
            var ventas = await _ventaService.GetAllVenta();
            return Ok(ventas);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateVenta([FromBody] VentaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venta = new Venta
            {
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
                TotalGanancia = dto.Cantidad * dto.Precio,
                //CreadoPor = User.Identity.Name,
                CreadoPor = dto.CreadoPor,
                CreadoEn = DateTime.Now,
                ActualizadoPor = string.Empty,
                ActualizadoEn = DateTime.Now
            };
            var id = await _ventaService.CreateVenta(venta);
            return CreatedAtAction(nameof(GetAllVenta), new { id });
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateVenta([FromBody] VentaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venta = new Venta
            {
                Id = dto.Id,
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
                TotalGanancia = dto.Cantidad * dto.Precio,
                //CreadoPor = User.Identity.Name,
                CreadoPor = dto.CreadoPor,
                CreadoEn = DateTime.Now,
                ActualizadoPor = dto.ActualizadoPor,
                ActualizadoEn = DateTime.Now
            };
            var id = await _ventaService.UpdateVenta(venta);
            return id ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var result = await _ventaService.DeleteVenta(id);
            return result ? NoContent() : NotFound();
        }
    }
}
