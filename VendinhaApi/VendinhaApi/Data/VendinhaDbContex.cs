using Microsoft.EntityFrameworkCore;
using VendinhaApi.Data.Map;
using VendinhaApi.Models;

namespace VendinhaApi.Data
{
	public class VendinhaDbContex : DbContext
	{
		public VendinhaDbContex(DbContextOptions<VendinhaDbContex> options) 
			: base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Divida> Dividas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClienteMap());
			modelBuilder.ApplyConfiguration(new DividaMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
