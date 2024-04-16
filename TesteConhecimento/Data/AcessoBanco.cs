using Microsoft.EntityFrameworkCore;
using TesteConhecimento.Models;
namespace TesteConhecimento.Data

{
    public class AcessoBanco : DbContext
    {
        public AcessoBanco(DbContextOptions<AcessoBanco> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venda>().ToTable("Vendas");
            modelBuilder.Entity<Venda>().HasKey(e => e.IdVenda);
            modelBuilder.Entity<Venda>().Property(e => e.Quantidade).IsRequired();
            modelBuilder.Entity<Venda>().Property(e => e.DataVenda).IsRequired();
            modelBuilder.Entity<Venda>().Property(e => e.ValorUnitario).IsRequired();
            modelBuilder.Entity<Venda>().Property(e => e.ValorTotal).IsRequired();

            modelBuilder.Entity<Venda>().HasOne(e => e.Produto).WithMany().HasForeignKey(e => e.IdProduto);
            modelBuilder.Entity<Venda>().HasOne(e => e.Cliente).WithMany().HasForeignKey(e => e.IdCliente);

        }

    }

}
