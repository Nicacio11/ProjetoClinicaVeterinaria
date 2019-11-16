using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Nicacio.ClinicaVeterinaria.Repositorio.EF
{
	public class RepositoryProntuario : Repository<Prontuario, int>
	{

		public RepositoryProntuario(DbContexto contexto) : base(contexto)
		{

		}
		public override void Insert(Prontuario pObjeto)
		{
			_contexto.Set<Animal>().Attach(pObjeto.Animal);
			_contexto.Set<Medico>().Attach(pObjeto.Medico);
			base.Insert(pObjeto);
		}
		public override IEnumerable<Prontuario> GetAll()
		{
			return _contexto.Set<Prontuario>().Include(x => x.Medico).Include(x => x.Animal).ToList();
		}
		public override IEnumerable<Prontuario> GetAll(Expression<Func<Prontuario, bool>> expression)
		{
			return _contexto.Set<Prontuario>().Include(x => x.Medico).Include(x => x.Animal).Where(expression).ToList();
		}
		public override Prontuario GetById(int pId)
		{
			return _contexto.Set<Prontuario>()
				.Include(x => x.Medico)
				.Include(x => x.Animal)
				.SingleOrDefault(x => x.Id == pId);
		}  
	}
}
