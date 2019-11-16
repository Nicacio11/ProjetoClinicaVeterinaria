using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.ViewModels.Prontuario
{
	public class ProntuarioExibicaoViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O médico é obrigatório")]
		[Display(Name = "Nome do médico")]
		public string MedicoNome { get; set; }
		[Required(ErrorMessage = "O animal é obrigatório")]
		[Display(Name = "Nome do animal")]
		public string AnimalNome { get; set; }

		[Display(Name = "Data do atendimento")]
		public DateTime DataAtendimento { get; set; }
		public string Observacao { get; set; }
	}
}