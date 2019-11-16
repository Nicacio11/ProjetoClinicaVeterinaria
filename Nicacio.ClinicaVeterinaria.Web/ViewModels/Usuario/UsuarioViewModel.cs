using Nicacio.ClinicaVeterinaria.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.ViewModels.Usuario
{
	public class UsuarioViewModel
	{
		[Required(ErrorMessage = "O Email é obrigatório")]
		[DataType(DataType.EmailAddress)]
		[MaxLength(30, ErrorMessage = "O email não pode ter mais que 30 caracteres")]
		[NicacioEmail(ErrorMessage = "É necessário ter Nicácio no email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "A senha é obrigatória")]
		[DataType(DataType.Password)]
		public string Senha { get; set; }
	}
}