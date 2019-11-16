using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Dominio
{
	public class Medico
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Especialidade { get; set; }
		public string NumeroConselhoRegionalVeterinaria { get; set; }
	}
}
