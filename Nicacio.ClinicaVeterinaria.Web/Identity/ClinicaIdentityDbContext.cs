using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nicacio.ClinicaVeterinaria.Web.Identity
{
	public class ClinicaIdentityDbContext : IdentityDbContext<IdentityUser>
	{
		public ClinicaIdentityDbContext() : base("DbContextHome")
		{

		}
	}
}