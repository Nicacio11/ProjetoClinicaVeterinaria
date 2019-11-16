using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.ViewModels.Prontuario
{
	public class ProntuarioViewModel
	{
		public int Id { get; set; }
		
		[Required(ErrorMessage = "Informe o médico")]
		public int MedicoId { get; set; }

		[Required(ErrorMessage = "Informe o animal")]
		public int AnimalId { get; set; }

		[Required(ErrorMessage = "Informe a data de atendimento")]
		[Display(Name = "Data de atendimento")]
		public DateTime DataAtendimento { get; set; }

		[Display(Name = "Observação")]
		public string Observacao { get; set; }
	}
}