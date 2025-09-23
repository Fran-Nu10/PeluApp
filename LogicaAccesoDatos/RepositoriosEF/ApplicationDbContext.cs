using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEF
{
    public class ApplicationDbContext:DbContext
    {
        // DbSets para las entidades de tu proyecto
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<ControlDeCambios> ControlDeCambios { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var diasConverter = new ValueConverter<List<string>, string>(
       // Guardar siempre como JSON
       v => JsonSerializer.Serialize(v ?? new(), (JsonSerializerOptions?)null),
       // Leer tolerando JSON o CSV/puntos
       v => ParseDiasFlex(v)
   );

            modelBuilder.Entity<Empleado>()
                .Property(e => e.DiasDisponibles)
                .HasConversion(diasConverter)
                .HasColumnType("nvarchar(max)");

            base.OnModelCreating(modelBuilder);
        }

        // Método auxiliar
        private static List<string> ParseDiasFlex(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return new();

            raw = raw.Trim();
            if (raw.StartsWith("[")) // Parece JSON
            {
                try
                {
                    return JsonSerializer.Deserialize<List<string>>(raw) ?? new();
                }
                catch
                {
                    // Si falla, seguimos abajo como CSV
                }
            }

            // CSV o con puntos -> normalizamos
            raw = raw.Replace('.', ',');
            return raw.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => s.Trim())
                      .Distinct(StringComparer.OrdinalIgnoreCase)
                      .ToList();
        }
    }
    }

