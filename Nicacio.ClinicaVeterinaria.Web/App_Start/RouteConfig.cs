using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nicacio.ClinicaVeterinaria.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
					name: "Filtro",
					url: "Animal/FiltrarAnimal/{pesquisa}",
					defaults: new { controller = "Animal", action = "FiltrarAnimal", pesquisa = UrlParameter.Optional }
				);
			routes.MapRoute(
					name: "FiltroMedico",
					url: "Medico/FiltrarMedico/{pesquisa}",
					defaults: new { controller = "Medico", action = "FiltrarMedico", pesquisa = UrlParameter.Optional }
				);
			routes.MapRoute(
					name: "FiltroProntuario",
					url: "Prontuario/FiltrarProntuario/{pesquisa}",
					defaults: new { controller = "Prontuario", action = "FiltrarProntuario", pesquisa = UrlParameter.Optional }
				);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
