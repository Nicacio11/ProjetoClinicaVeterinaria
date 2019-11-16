using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Nicacio.ClinicaVeterinaria.Repositorio.EF
{
	public class RepositoryMedico : Repository<Medico, int>
	{
		public RepositoryMedico(DbContexto contexto) : base(contexto)
		{
		}
	}
}
