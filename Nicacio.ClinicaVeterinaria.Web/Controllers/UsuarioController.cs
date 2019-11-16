using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nicacio.ClinicaVeterinaria.Web.Identity;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nicacio.ClinicaVeterinaria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login([Bind(Include = "Email,Senha")]UsuarioViewModel usuarioViewModel)
		{
			if (ModelState.IsValid)
			{
				var userStore = new UserStore<IdentityUser>(new ClinicaIdentityDbContext());
				var userManager = new UserManager<IdentityUser>(userStore);

				var usuario = userManager.Find(usuarioViewModel.Email, usuarioViewModel.Senha);
				if(usuario == null)
				{
					ModelState.AddModelError("erro_identity", "Usuario e/ou senha incorretos");
					return View(usuarioViewModel);
				}

				//registrando que de fato está autenticado
				var authManager = HttpContext.GetOwinContext().Authentication;
				var identity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
				authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties()
				{
					//lembrar usuario?
					IsPersistent = false
				}, identity);


				//necessário inserir as roles no bd para isso funcionar
				//membro é alguem que trabalha na clinica e não membro todos os outros
				///inserindo a regra e definindo com uid da regra e uid do usuario a relação
				///insert into AspNetRoles VALUES(NEWID(),'Membro')
				///insert into AspNetUserRoles VALUES('4260c7bf-a88b-40a1-95cd-023188c34b7f', '449733AE-79E8-485B-9ED9-FD8B1A3BE15C')

				///
				if (authManager.User.IsInRole("Membro"))
					return RedirectToAction("Index", "Prontuario");
				else
					return RedirectToAction("Index", "Consulta");
			}
			return View(usuarioViewModel);
		}

		public ActionResult CriarUsuario()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CriarUsuario([Bind(Include = "Email,Senha")]UsuarioViewModel usuarioViewModel)
		{
			if (ModelState.IsValid)
			{

				//user store classe responsavel por fazer o armazenamento
				var userStore = new UserStore<IdentityUser>(new ClinicaIdentityDbContext());
				var userManager = new UserManager<IdentityUser>(userStore);
				var identityUser = new IdentityUser()
				{
					Email = usuarioViewModel.Email,
					UserName = usuarioViewModel.Email
				};
				IdentityResult resultado = userManager.Create(identityUser, usuarioViewModel.Senha);
				if (resultado.Succeeded)
					return RedirectToAction("Index", "Home");
				else
				{
					ModelState.AddModelError("erro_identity", resultado.Errors.FirstOrDefault());
					return View(usuarioViewModel);
				}
			}
			return View(usuarioViewModel);
		}

		[Authorize]
		public ActionResult Logout()
		{
			var authMananger = HttpContext.GetOwinContext().Authentication;
			authMananger.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}