using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.AcessoDados.Comum.EF
{
	public abstract class EntityAbstractConfiguration<TEntidade> : EntityTypeConfiguration<TEntidade>
		where TEntidade : class
	{
		public EntityAbstractConfiguration()
		{
			ConfigurarNomeTabela();
			ConfigurarCamposTabela();
			ConfigurarChavePrimaria();
			ConfigurarChaveEstrangeira();
		}

		public abstract void ConfigurarNomeTabela();
		public abstract void ConfigurarCamposTabela();
		public abstract void ConfigurarChavePrimaria();
		public abstract void ConfigurarChaveEstrangeira();
	}
}
