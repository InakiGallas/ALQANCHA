using Microsoft.EntityFrameworkCore;
using ALQANCHA.Models;

namespace ALQCANCHA.Context
{
    public class AlqanchaDatabaseContext : DbContext
    {
        public AlqanchaDatabaseContext(DbContextOptions<AlqanchaDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<ReservaJugador> ReservaJugadores { get; set; }
        public DbSet<Sancion> Sanciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ReservaJugador>()
                .HasKey(rj => new { rj.ReservaId, rj.JugadorId });

            modelBuilder.Entity<ReservaJugador>()
                .HasOne(rj => rj.Reserva)
                .WithMany(r => r.ReservaJugadores)
                .HasForeignKey(rj => rj.ReservaId);

            modelBuilder.Entity<ReservaJugador>()
                .HasOne(rj => rj.Jugador)
                .WithMany(j => j.ReservaJugadores)
                .HasForeignKey(rj => rj.JugadorId);


            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Administrador)
                .WithMany(a => a.Reservas)
                .HasForeignKey(r => r.AdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cancha)
                .WithMany()
                .HasForeignKey(r => r.CanchaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}