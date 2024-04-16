using Microsoft.EntityFrameworkCore;
using TesteConhecimento.Data;

namespace TesteConhecimento.Extension
{
    public static class DependencyInjection
    {
        public static void RegistraServico(this IServiceCollection services,IConfiguration configuration)
        {
          services.AddDbContext<AcessoBanco>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
