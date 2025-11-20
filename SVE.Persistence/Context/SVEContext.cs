using Microsoft.EntityFrameworkCore;
using SVE.Domain.Entities.Configuration;
using SVE.Domain.Entities.Network;


namespace SVE.Persistence.Context
{

    public class SVEContext : DbContext
    {

        public SVEContext(DbContextOptions<SVEContext> options) : base(options)
        {

        }

             public DbSet<Usuario> Usuarios { get; set; }
             public DbSet<Promocion> Promociones { get; set; }
             public DbSet<Producto> Productos { get; set; }
            public DbSet<Pedido> Pedidos { get; set; }
            public DbSet<DetallePedido> DetallePedidos { get; set; }
            public DbSet<NetworkType> NetworkTypes { get; set; }
            public DbSet<NetworkProvider> NetworkProvider { get; set; }
    }
}