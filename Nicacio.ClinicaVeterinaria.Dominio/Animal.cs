using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Dominio
{
	public class Animal
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Raca { get; set; }
		public string NomeDono { get; set; }
	}
}
