using Nicacio.ClinicaVeterinaria.Repositorio.Comum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Repositorio.Comum.EF
{
	public class Repository<TEntidade, TChave> : IRepository<TEntidade, TChave>
		where TEntidade : class
	{
		protected DbContext _contexto;
		public Repository(DbContext contexto)
		{
			_contexto = contexto;
		}
		public void Delete(TEntidade pObjeto)
		{
			_contexto.Set<TEntidade>().Attach(pObjeto);
			_contexto.Entry(pObjeto).State = EntityState.Deleted;
			_contexto.SaveChanges();
		}

		public void DeleteById(TChave pId)
		{
			TEntidade entidade = GetById(pId);
			Delete(entidade);
		}

		public virtual IEnumerable<TEntidade> GetAll()
		{
			return _contexto.Set<TEntidade>().ToList();
		}

		public virtual IEnumerable<TEntidade> GetAll(Expression<Func<TEntidade, bool>> expression)
		{
			return _contexto.Set<TEntidade>().Where(expression).ToList();
		}

		public virtual Task<List<TEntidade>> GetAllAsync()
		{
			return Task.Run(() =>
			{
				return _contexto.Set<TEntidade>().ToList();
			});
		}

		public virtual TEntidade GetById(TChave pId)
		{
			return _contexto.Set<TEntidade>().Find(pId);

		}

		public virtual void Insert(TEntidade pObjeto)
		{
			_contexto.Set<TEntidade>().Add(pObjeto);
			_contexto.SaveChanges();
		}

		public void Update(TEntidade pObjeto)
		{
			_contexto.Set<TEntidade>().Attach(pObjeto);
			_contexto.Entry(pObjeto).State = EntityState.Modified;
			_contexto.SaveChanges();

		}
	}
}
