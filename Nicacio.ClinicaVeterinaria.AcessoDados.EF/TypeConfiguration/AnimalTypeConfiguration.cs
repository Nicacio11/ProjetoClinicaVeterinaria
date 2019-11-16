using Nicacio.ClinicaVeterinaria.AcessoDados.Comum.EF;
using Nicacio.ClinicaVeterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.TypeConfiguration
{
	class AnimalTypeConfiguration : EntityAbstractConfiguration<Animal>
	{
		public override void ConfigurarCamposTabela()
		{
			Property(x => x.Id)
				.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
				.IsRequired()
				.HasColumnName("IdAnimal");
			Property(x => x.Nome).IsRequired();
			Property(x => x.NomeDono).IsRequired();
			Property(x => x.Raca).IsRequired();
		}

		public override void ConfigurarChaveEstrangeira()
		{
		}

		public override void ConfigurarChavePrimaria()
		{
			HasKey(x => x.Id);
		}

		public override void ConfigurarNomeTabela()
		{
			ToTable("Animal");
		}
	}
}
