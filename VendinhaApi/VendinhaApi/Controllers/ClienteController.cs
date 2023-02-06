using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendinhaApi.Models;
using VendinhaApi.Repositorios.Interfaces;

namespace VendinhaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{

		private readonly IClienteRepositorio _clienteRepositorio;

		public ClienteController(IClienteRepositorio clienteRepositorio)
		{
			_clienteRepositorio = clienteRepositorio;
		}

		[HttpGet]
		public async Task<ActionResult<List<Cliente>>> BuscarTodosClientes()
		{
			List<Cliente> clientes = await _clienteRepositorio.BuscarTodosClientes();
			return Ok(clientes);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Cliente>> BuscarPorId(int id)
		{
			Cliente cliente = await _clienteRepositorio.BuscarPorId(id);
			return Ok(cliente);
		}

		[HttpPost]
		public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente clienteModel)
		{
			Cliente cliente = await _clienteRepositorio.Adicionar(clienteModel);
			return Ok(cliente);
		}

		[HttpPut]
		public async Task<ActionResult<Cliente>> Atualizar([FromBody] Cliente clienteModel, int id)
		{
			clienteModel.Id = id;
			Cliente cliente = await _clienteRepositorio.Atualizar(clienteModel, id);
			return Ok(cliente);
		}

		[HttpDelete]
		public async Task<ActionResult<Cliente>> Apagar(int id)
		{
			Boolean apagado = await _clienteRepositorio.Apagar(id);
			return Ok(apagado);
		}
	}
}
