using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class Contexto : IdentityDbContext
{
    public DbSet<Ganancias> Ganancias { get; set; }
    public DbSet<Jugadas> Jugadas { get; set; }

    public DbSet<Loterias> Loterias { get; set; }

    public DbSet<TipoJugada> tipoJugada { get; set; }
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

        protected override void OnModelCreating(ModelBuilder model)
    {
          base.OnModelCreating(model);


        model.Entity<Loterias>().HasData
        (
            new Loterias
            {
                LoteriaId = 1,
                Nombre = "Leidsa"
            },
            new Loterias
            {
                LoteriaId = 2,
                Nombre = "Loteria Real"
            },
            new Loterias
            {
                LoteriaId = 3,
                Nombre = "Loteka"
            },
            new Loterias
            {
                LoteriaId = 4,
                Nombre = "Americana"
            },
            new Loterias
            {
                LoteriaId = 5,
                Nombre = "La Suerte"
            },

            new Loterias
            {
                LoteriaId = 6,
                Nombre = "Primera"
            },

            new Loterias
            {
                LoteriaId = 7,
                Nombre = "Loteria Nacional",

            }

        );

        model.Entity<TipoJugada>().HasData
        (
            new TipoJugada
            {
                TipoJugadaId = 1,
                NombreJugada = "Loto"
            },
             new TipoJugada
            {
                TipoJugadaId = 2,
                NombreJugada = "Loto Pool"
            },
             new TipoJugada
            {
                TipoJugadaId = 3,
                NombreJugada = "Quiniela Pale"
            },
             new TipoJugada
            {
                TipoJugadaId = 4,
                NombreJugada = "Super Kino"
            },
             new TipoJugada
            {
                TipoJugadaId = 5,
                NombreJugada = "Tripleta"
            },
             new TipoJugada
            {
                TipoJugadaId = 6,
                NombreJugada = "Pega Mas"
            },
             new TipoJugada
            {
                TipoJugadaId = 7,
                NombreJugada = "Quiniela"
            },
             new TipoJugada
            {
                TipoJugadaId = 8,
                NombreJugada = "Pale"
            },
             new TipoJugada
            {
                TipoJugadaId = 9,
                NombreJugada = "Pega 3 Mas"
            }

        );

    }

}
