using VendinhaApi.Models;

namespace VendinhaApi.Repositorios.Interfaces
{
	public interface IDividaRepositorio
	{
		Task<List<Divida>> BuscarTodasDividasCliente(int ClienteId);
		Task<List<Divida>> BuscarTodasDividas();
		Task<Divida> BuscarPorId(int Id);
		Task<Divida> Adicionar(Divida divida);
		Task<Divida> Atualizar(Divida divida, int Id);
		Task<bool> Apagar(int Id);

	}
}
