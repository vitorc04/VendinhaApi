using VendinhaApi.Models;

namespace VendinhaApi.Repositorios.Interfaces
{
	public interface IClienteRepositorio
	{
		Task<List<Cliente>> BuscarTodosClientes();
		Task<Cliente> BuscarPorId(int id);
		Task<Cliente> Adicionar(Cliente cliente);
		Task<Cliente> Atualizar(Cliente cliente, int id);
		Task<bool> Apagar(int id);

	}
}
