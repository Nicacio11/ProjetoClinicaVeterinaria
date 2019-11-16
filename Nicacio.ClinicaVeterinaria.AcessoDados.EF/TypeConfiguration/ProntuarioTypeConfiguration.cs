using Nicacio.ClinicaVeterinaria.AcessoDados.Comum.EF;
using Nicacio.ClinicaVeterinaria.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.AcessoDados.EF.TypeConfiguration
{
	class ProntuarioTypeConfiguration : EntityAbstractConfiguration<Prontuario>
	{
		public override void ConfigurarCamposTabela()
		{
			Property(x => x.Id)
				.HasColumnName("IdProntuario")
				.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
				.IsRequired();
			Property(x => x.DataAtendimento)
				.IsRequired();
			Property(x => x.Observacao);
		}

		public override void ConfigurarChaveEstrangeira()
		{
			HasRequired(x => x.Animal);
			HasRequired(x => x.Medico);
		}

		public override void ConfigurarChavePrimaria()
		{
			HasKey(x => x.Id);
		}

		public override void ConfigurarNomeTabela()
		{
			ToTable("Prontuario");
		}
	}
}
