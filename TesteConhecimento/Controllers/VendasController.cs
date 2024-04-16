using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteConhecimento.Data;
using TesteConhecimento.Models;

namespace TesteConhecimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly AcessoBanco _context;

        public VendasController(AcessoBanco context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaResponseDto>>> GetVendas()
        {
            var vendas = await _context.Vendas.ToListAsync();
            var vendasResponses = new List<VendaResponseDto>();
            foreach (var venda in vendas)
            {
                var vendaResponse = new VendaResponseDto
                {
                    IdVenda = venda.IdVenda,
                    IdCliente = venda.IdCliente,
                    IdProduto = venda.IdProduto,
                    Quantidade = venda.Quantidade,
                    ValorUnitario = venda.ValorUnitario,
                    DataVenda = venda.DataVenda,
                    ValorTotal = venda.Quantidade * venda.ValorUnitario,
                };
                vendasResponses.Add(vendaResponse);
            }
            if (vendasResponses.Count == 0)
            {
                return NotFound();
            }
            return Ok(vendasResponses);
        }

        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(VendaRequestDto vendaRequestDto)
        {
            var venda = new Venda(vendaRequestDto.IdCliente, vendaRequestDto.IdProduto, vendaRequestDto.Quantidade, vendaRequestDto.ValorUnitario, vendaRequestDto.DataVenda);


            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            var vendaResponse = new VendaResponseDto
            {
                IdVenda = venda.IdVenda,
                IdCliente = venda.IdCliente,
                IdProduto = venda.IdProduto,
                Quantidade = venda.Quantidade,
                ValorUnitario = venda.ValorUnitario,
                DataVenda = venda.DataVenda,
                ValorTotal = venda.Quantidade * venda.ValorUnitario,
            };

            return CreatedAtAction("GetVenda", new { id = venda.IdVenda }, vendaResponse);
        }

        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVenda == id);
        }
    }
}

