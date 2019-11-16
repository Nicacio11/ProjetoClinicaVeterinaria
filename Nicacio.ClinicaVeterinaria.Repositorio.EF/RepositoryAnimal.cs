using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Repositorio.EF
{
	public class RepositoryAnimal : Repository<Animal, int>
	{
		public RepositoryAnimal(DbContexto contexto) : base(contexto)
		{

		}
	}
}
