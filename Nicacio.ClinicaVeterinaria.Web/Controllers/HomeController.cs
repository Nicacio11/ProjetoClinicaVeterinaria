using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nicacio.ClinicaVeterinaria.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "A melhor Clinica Veterinária de todos os tempos.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Ligue e marque uma consulta.";

			return View();
		}
	}
}