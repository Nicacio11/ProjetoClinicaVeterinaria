using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.ViewModels.Animal
{
	public class AnimalViewModel
	{
		public int Id { get; set; }
		
		[Required(ErrorMessage = "Informe o nome")]
		[Display(Name = "Nome do animal")]
		[MaxLength(50, ErrorMessage = "Não é possível ter nome com mais de 50 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Informe a raça do animal")]
		[Display(Name = "Raça do animal")]
		[MaxLength(50, ErrorMessage = "Não é possível ter a raça com mais de 50 caracteres")]
		public string Raca { get; set; }

		[Required(ErrorMessage = "Informe o nome do dono")]
		[Display(Name = "Nome do dono")]
		[MaxLength(50, ErrorMessage = "Não é possível ter nome com mais de 50 caracteres")]
		public string NomeDono { get; set; }
	}
}