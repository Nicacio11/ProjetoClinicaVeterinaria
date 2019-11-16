using Nicacio.ClinicaVeterinaria.AcessoDados.EF.TypeConfiguration;
using Nicacio.ClinicaVeterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto
{
	public class DbContexto : DbContext
	{
		public DbSet<Animal> Animais { get; set; }
		public DbSet<Medico> Medicos { get; set; }
		public DbSet<Prontuario> Prontuarios { get; set; }
		public DbContexto() :base("DbContextHome")
		{

		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new AnimalTypeConfiguration());
			modelBuilder.Configurations.Add(new MedicoTypeConfiguration());
			modelBuilder.Configurations.Add(new ProntuarioTypeConfiguration());
		}


	}
}
