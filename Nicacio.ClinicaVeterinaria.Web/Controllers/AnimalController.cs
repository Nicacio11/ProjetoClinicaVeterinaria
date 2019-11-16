using AutoMapper;
using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum;
using Nicacio.ClinicaVeterinaria.Repositorio.EF;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nicacio.ClinicaVeterinaria.Web.Controllers
{
	[Authorize(Roles = "Membro")]
	public class AnimalController : Controller
	{
		private IRepository<Animal, int> repository = new RepositoryAnimal(new DbContexto());
		// GET: Animal
		public ActionResult Index()
		{
			return View(Mapper.Map<List<Animal>, List<AnimalViewModel>>(repository.GetAll().ToList()));
		}
		public ActionResult FiltrarAnimal(string pesquisa)
		{
			return Json(Mapper.Map<List<Animal>, List<AnimalViewModel>>(repository.GetAll(x => x.Nome.Contains(pesquisa)).ToList()), JsonRequestBehavior.AllowGet);
		}
		[Authorize(Roles = "Membro")]
		public ActionResult CadastrarAnimal()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CadastrarAnimal(AnimalViewModel animalViewModel)
		{
			if (ModelState.IsValid)
			{
				repository.Insert(Mapper.Map<AnimalViewModel, Animal>(animalViewModel));
				return RedirectToAction("Index");
			}
			return View(animalViewModel);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
			var animal = repository.GetById(id.Value);
			if (animal == null)
				return HttpNotFound();
			return View(Mapper.Map<Animal, AnimalViewModel>(animal));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,Raca,NomeDono")] AnimalViewModel animal)
		{
			if (ModelState.IsValid)
			{
				repository.Update(Mapper.Map<AnimalViewModel, Animal>(animal));
				RedirectToAction("Index");
			}
			return View(animal);
		}
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Animal animal = repository.GetById(id.Value);
			if (animal == null)
			{
				return HttpNotFound();
			}
			return View(Mapper.Map<Animal, AnimalViewModel>(animal));
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			try
			{
				repository.DeleteById(id);
				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ModelState.AddModelError("erro_fk", "Não foi possivel apagar esse registro");
				return View();
			}
		}
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Animal animal = repository.GetById(id.Value);
			if (animal == null)
			{
				return HttpNotFound();
			}
			return View(Mapper.Map<Animal, AnimalViewModel>(animal));
		}
	}
}