using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Repositorio.Comum
{
	public interface IRepository<TEntidade, TChave>
		where TEntidade : class
	{
		void Insert(TEntidade pObjeto);
		IEnumerable<TEntidade> GetAll();
		IEnumerable<TEntidade> GetAll(Expression<Func<TEntidade, bool>> expression);
		Task<List<TEntidade>> GetAllAsync();
		TEntidade GetById(TChave pId);
		void Delete(TEntidade pObjeto);
		void DeleteById(TChave pId);
		void Update(TEntidade pObjeto);
	}
}
