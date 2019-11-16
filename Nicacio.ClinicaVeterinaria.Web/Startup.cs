using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Nicacio.ClinicaVeterinaria.Web.Startup))]

namespace Nicacio.ClinicaVeterinaria.Web
{
	/// <summary>
	/// classe responsavel pela autenticação e autorização
	/// </summary>
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions()
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Usuarios/Login")
			});
		}
	}
}
