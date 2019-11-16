using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.ViewModels.Medico
{
	public class MedicoViewModel
	{
		public int Id { get; set; }
		
		[Required(ErrorMessage = "O nome é obrigatório")]
		[Display(Name = "Nome")]
		public string Nome { get; set; }
		[Required(ErrorMessage ="A especialidade é obrigatória")]
		[Display(Name = "Especialidade")]
		public string Especialidade { get; set; }

		[Required(ErrorMessage = "A Numero de Conselho Regional de Veterinaria é obrigatório")]
		[Display(Name = "NCRV")]
		public string NumeroConselhoRegionalVeterinaria { get; set; }
	}
}