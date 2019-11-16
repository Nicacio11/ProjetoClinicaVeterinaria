using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.Annotations
{
	public class NicacioEmailAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			return value.ToString().Contains("@nicacio.com.br");
		}
	}
}