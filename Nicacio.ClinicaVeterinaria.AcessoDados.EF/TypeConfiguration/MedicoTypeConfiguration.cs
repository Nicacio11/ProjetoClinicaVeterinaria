using Nicacio.ClinicaVeterinaria.AcessoDados.Comum.EF;
using Nicacio.ClinicaVeterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.TypeConfiguration
{
	class MedicoTypeConfiguration : EntityAbstractConfiguration<Medico>
	{
		public override void ConfigurarCamposTabela()
		{
			Property(x => x.Id)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
				.HasColumnName("IdMedico");
			Property(x => x.Nome)
				.IsRequired()
				.HasColumnName("Nome");
			Property(x => x.Especialidade)
				.IsRequired()
				.HasColumnName("Especialidade");
			Property(x => x.NumeroConselhoRegionalVeterinaria)
				.IsRequired()
				.HasColumnName("NCRV");
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
			ToTable("Medico");
		}
	}
}
