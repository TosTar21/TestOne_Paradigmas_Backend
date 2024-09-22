using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        // Definición de DbSets para las entidades restantes
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir las llaves primarias explícitamente
            modelBuilder.Entity<AppointmentStatus>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Service>()
                .HasKey(s => s.Id);

            // Definir las relaciones entre entidades restantes
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StatusId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
