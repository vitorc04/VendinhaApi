using Microsoft.EntityFrameworkCore;
using VendinhaApi.Data;
using VendinhaApi.Models;
using VendinhaApi.Repositorios.Interfaces;

namespace VendinhaApi.Repositorios
{
	public class DividaRepositorio : IDividaRepositorio
	{
		private readonly VendinhaDbContex _dbContext;
		public DividaRepositorio(VendinhaDbContex vendinhaDbContext)
		{
			_dbContext = vendinhaDbContext;
		}
		public async Task<Divida> BuscarPorId(int Id)
		{
			return await _dbContext.Dividas.FirstOrDefaultAsync(options => options.Id == Id);
		}

		public async Task<List<Divida>> BuscarTodasDividasCliente(int ClienteId)
		{
			return await _dbContext.Dividas.Where(options => options.ClienteId == ClienteId).ToListAsync();
		}

		public async Task<List<Divida>> BuscarTodasDividas()
		{
			return await _dbContext.Dividas.ToListAsync();
		}

		public async Task<Divida> Adicionar(Divida divida)
		{
			var DividaAberta = await _dbContext.Dividas.FirstOrDefaultAsync(options => options.ClienteId == divida.ClienteId && options.Paid == false);

			if (DividaAberta != null)
			{
				throw new NotImplementedException("Cliente já possui divida aberta no sistema.");
			}

			await _dbContext.Dividas.AddAsync(divida);
			await _dbContext.SaveChangesAsync();

			return divida;
		}

		public async Task<Divida> Atualizar(Divida divida, int Id)
		{
			Divida dividaPorId = await BuscarPorId(Id);

			if (dividaPorId == null)
			{
				throw new NotImplementedException($"Divida com o ID: {Id} não foi encontrado no banco de dados.");
			}

			dividaPorId.Value = divida.Value;
			dividaPorId.Paid = divida.Paid;
			dividaPorId.CreationDate = divida.CreationDate;
			dividaPorId.PaymentDate = divida.PaymentDate;
			dividaPorId.ClienteId = divida.ClienteId;

			_dbContext.Dividas.Update(dividaPorId);
			await _dbContext.SaveChangesAsync();

			return dividaPorId;
		}

		public async Task<bool> Apagar(int Id)
		{
			Divida dividaPorId = await BuscarPorId(Id);

			if (dividaPorId == null)
			{
				throw new NotImplementedException($"Divida com o ID: {Id} não foi encontrado no banco de dados.");
			}

			_dbContext.Dividas.Remove(dividaPorId);
			await _dbContext.SaveChangesAsync();
			return true;

		}
	}
}
