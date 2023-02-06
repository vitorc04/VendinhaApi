using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendinhaApi.Models;
using VendinhaApi.Repositorios;
using VendinhaApi.Repositorios.Interfaces;

namespace VendinhaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DividaController : ControllerBase
	{

		private readonly IDividaRepositorio _dividaRepositorio;

		public DividaController(IDividaRepositorio dividaRepositorio)
		{
			_dividaRepositorio = dividaRepositorio;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Divida>> BuscarPorId(int id)
		{
			Divida divida = await _dividaRepositorio.BuscarPorId(id);
			return Ok(divida);
		}

		[HttpGet("{clienteId}")]
		public async Task<ActionResult<List<Divida>>> BuscarTodasDividasCliente(int ClienteId)
		{
			List<Divida> dividas = await _dividaRepositorio.BuscarTodasDividasCliente(ClienteId);
			return Ok(dividas);
		}

		[HttpGet]
		public async Task<ActionResult<List<Divida>>> BuscarTodasDividas()
		{
			List<Divida> dividas = await _dividaRepositorio.BuscarTodasDividas();
			return Ok(dividas);
		}
	
		[HttpPost]
		public async Task<ActionResult<Divida>> Cadastrar([FromBody] Divida dividaModel)
		{
			Divida divida = await _dividaRepositorio.Adicionar(dividaModel);
			return Ok(divida);
		}

		[HttpPut]
		public async Task<ActionResult<Divida>> Atualizar([FromBody] Divida dividaModel, int id)
		{
			dividaModel.Id = id;
			Divida divida = await _dividaRepositorio.Atualizar(dividaModel, id);
			return Ok(divida);
		}

		[HttpDelete]
		public async Task<ActionResult<Divida>> Apagar(int id)
		{
			Boolean apagado = await _dividaRepositorio.Apagar(id);
			return Ok(apagado);
		}
	}
}
