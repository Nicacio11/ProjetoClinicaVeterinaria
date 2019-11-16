using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicacio.ClinicaVeterinaria.Dominio
{
	public class Prontuario
	{
		public int Id { get; set; }
		public Medico Medico { get; set; }
		public Animal Animal { get; set; }
		public DateTime DataAtendimento { get; set; }
		public string Observacao { get; set; }

	}
}
