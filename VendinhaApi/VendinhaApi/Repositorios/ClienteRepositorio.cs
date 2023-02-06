using Microsoft.EntityFrameworkCore;
using VendinhaApi.Data;
using VendinhaApi.Models;
using VendinhaApi.Repositorios.Interfaces;

namespace VendinhaApi.Repositorios
{
	public class ClienteRepositorio : IClienteRepositorio
	{
		private readonly VendinhaDbContex _dbContext;
		public ClienteRepositorio(VendinhaDbContex vendinhaDbContext)
		{
			_dbContext = vendinhaDbContext;
		}
		public async Task<Cliente> BuscarPorId(int Id)
		{
			return await _dbContext.Clientes.FirstOrDefaultAsync(options => options.Id == Id);
		}

		public async Task<List<Cliente>> BuscarTodosClientes()
		{
			return await _dbContext.Clientes.ToListAsync();
		}

		public async Task<Cliente> Adicionar(Cliente cliente)
		{
			await _dbContext.Clientes.AddAsync(cliente);
			await _dbContext.SaveChangesAsync();

			return cliente;
		}

		public async Task<Cliente> Atualizar(Cliente cliente, int Id)
		{
			Cliente clientePorId = await BuscarPorId(Id);

			if (clientePorId == null)
			{
				throw new NotImplementedException($"Cliente para o ID: {Id} não foi encontrado no banco de dados.");
			}

			clientePorId.Nome = cliente.Nome;
			clientePorId.CPF = cliente.CPF;
			clientePorId.DataNascimento = cliente.DataNascimento;
			clientePorId.Email = cliente.Email;

			_dbContext.Clientes.Update(clientePorId);
			await _dbContext.SaveChangesAsync();

			return clientePorId;
		}

		public async Task<bool> Apagar(int Id)
		{
			Cliente clientePorId = await BuscarPorId(Id);

			if (clientePorId == null)
			{
				throw new NotImplementedException($"Cliente para o ID: {Id} não foi encontrado no banco de dados.");
			}

			_dbContext.Clientes.Remove(clientePorId);
			await _dbContext.SaveChangesAsync();
			return true;

		}
	}
}
