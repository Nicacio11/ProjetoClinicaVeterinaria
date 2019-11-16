using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Nicacio.ClinicaVeterinaria.AcessoDados.EF.Contexto;
using Nicacio.ClinicaVeterinaria.Dominio;
using Nicacio.ClinicaVeterinaria.Repositorio.Comum;
using Nicacio.ClinicaVeterinaria.Repositorio.EF;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Animal;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Medico;
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Prontuario;

namespace Nicacio.ClinicaVeterinaria.Web.Controllers
{
	public class ProntuarioController : Controller
	{
		private IRepository<Prontuario, int> repositoryProntuario = new RepositoryProntuario(new DbContexto());
		private IRepository<Medico, int> repositoryMedico = new RepositoryMedico(new DbContexto());
		private IRepository<Animal, int> repositoryAnimal = new RepositoryAnimal(new DbContexto());


		// GET: Prontuario
		public ActionResult Index()
		{
			return View(Mapper.Map<List<Prontuario>, List<ProntuarioExibicaoViewModel>>(repositoryProntuario.GetAll().ToList()));
		}

		// GET: Prontuario/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ProntuarioExibicaoViewModel prontuarioViewModel = Mapper.Map<Prontuario, ProntuarioExibicaoViewModel>(repositoryProntuario.GetById(id.Value));
			if (prontuarioViewModel == null)
			{
				return HttpNotFound();
			}
			return View(prontuarioViewModel);
		}

		// GET: Prontuario/Create
		public ActionResult Create()
		{
			var Medicos = Mapper.Map<List<Medico>, List<MedicoViewModel>>(repositoryMedico.GetAll().ToList());
			var Animais = Mapper.Map<List<Animal>, List<AnimalViewModel>>(repositoryAnimal.GetAll().ToList());
			SelectList dropDownMedico = new SelectList(Medicos, "Id", "Nome");
			SelectList dropDownAnimal = new SelectList(Animais, "Id", "Nome");
			ViewBag.DropDownMedico = dropDownMedico;
			ViewBag.DropDownAnimal = dropDownAnimal;

			return View();
		}

		// POST: Prontuario/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,MedicoId,AnimalId,DataAtendimento,Observacao")] ProntuarioViewModel prontuarioViewModel)
		{
			if (ModelState.IsValid)
			{
				var prontuario = Mapper.Map<ProntuarioViewModel, Prontuario>(prontuarioViewModel);
				var medico = repositoryMedico.GetById(prontuarioViewModel.MedicoId);
				var animal = repositoryAnimal.GetById(prontuarioViewModel.AnimalId);
				prontuario.Medico = medico;
				prontuario.Animal = animal;
				repositoryProntuario.Insert(prontuario);
				return RedirectToAction("Index");
			}

			return View(prontuarioViewModel);
		}
		public ActionResult FiltrarProntuario(DateTime? pesquisa)
		{
			IEnumerable<Prontuario> prontuario = pesquisa.HasValue ? repositoryProntuario
				.GetAll(x => x.DataAtendimento == pesquisa)
				: repositoryProntuario
				.GetAll();
			return Json(prontuario
				.Select(x =>
				new
				{
					x.Id,
					NomeMedico = x.Medico.Nome,
					NomeAnimal = x.Animal.Nome,
					DataAtendimento = x.DataAtendimento.ToString(),
					x.Observacao
				}), JsonRequestBehavior.AllowGet);
		}
		// GET: Prontuario/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ProntuarioViewModel prontuarioViewModel = Mapper
				.Map<Prontuario, ProntuarioViewModel>(repositoryProntuario.GetById(id.Value));

			if (prontuarioViewModel == null)
			{
				return HttpNotFound();
			}
			var Medicos = Mapper.Map<List<Medico>, List<MedicoViewModel>>(repositoryMedico.GetAll().ToList());
			var Animais = Mapper.Map<List<Animal>, List<AnimalViewModel>>(repositoryAnimal.GetAll().ToList());
			SelectList dropDownMedico = new SelectList(Medicos, "Id", "Nome");
			SelectList dropDownAnimal = new SelectList(Animais, "Id", "Nome");
			ViewBag.DropDownMedico = dropDownMedico;
			ViewBag.DropDownAnimal = dropDownAnimal;
			return View(prontuarioViewModel);
		}

		// POST: Prontuario/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,MedicoId,AnimalId,DataAtendimento,Observacao")] ProntuarioViewModel prontuarioViewModel)
		{
			if (ModelState.IsValid)
			{
				var prontuario = Mapper.Map<ProntuarioViewModel, Prontuario>(prontuarioViewModel);
				var medico = repositoryMedico.GetById(prontuarioViewModel.MedicoId);
				var animal = repositoryAnimal.GetById(prontuarioViewModel.AnimalId);
				prontuario.Medico = medico;
				prontuario.Animal = animal;
				repositoryProntuario.Update(prontuario);
				return RedirectToAction("Index");
			}
			var Medicos = Mapper.Map<List<Medico>, List<MedicoViewModel>>(repositoryMedico.GetAll().ToList());
			var Animais = Mapper.Map<List<Animal>, List<AnimalViewModel>>(repositoryAnimal.GetAll().ToList());
			SelectList dropDownMedico = new SelectList(Medicos, "Id", "Nome");
			SelectList dropDownAnimal = new SelectList(Animais, "Id", "Nome");
			ViewBag.DropDownMedico = dropDownMedico;
			ViewBag.DropDownAnimal = dropDownAnimal;
			return View(prontuarioViewModel);
		}

		// GET: Prontuario/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ProntuarioExibicaoViewModel prontuarioViewModel = Mapper
				.Map<Prontuario, ProntuarioExibicaoViewModel>(repositoryProntuario.GetById(id.Value));
			if (prontuarioViewModel == null)
			{
				return HttpNotFound();
			}
			return View(prontuarioViewModel);
		}

		// POST: Prontuario/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			repositoryProntuario.DeleteById(id);
			return RedirectToAction("Index");
		}
	}
}
