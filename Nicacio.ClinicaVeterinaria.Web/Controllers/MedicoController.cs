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
using Nicacio.ClinicaVeterinaria.Web.ViewModels.Medico;

namespace Nicacio.ClinicaVeterinaria.Web.Controllers
{
	[Authorize(Roles = "Membro")]
    public class MedicoController : Controller
    {
        private IRepository<Medico, int> db = new RepositoryMedico(new DbContexto());

        // GET: MedicoViewModels
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Medico>, List<MedicoViewModel>>(db.GetAll().ToList()));
        }
		public ActionResult FiltrarMedico(string pesquisa)
		{
			return Json(Mapper.Map<List<Medico>, List<MedicoViewModel>>(db.GetAll(x => x.Nome.Contains(pesquisa)).ToList()), JsonRequestBehavior.AllowGet);
		}
		// GET: MedicoViewModels/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoViewModel medicoViewModel = Mapper.Map<Medico, MedicoViewModel>(db.GetById(id.Value));
            if (medicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicoViewModel);
        }

        // GET: MedicoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicoViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Especialidade,NumeroConselhoRegionalVeterinaria")] MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
				db.Insert(Mapper.Map<MedicoViewModel, Medico>(medicoViewModel));
                return RedirectToAction("Index");
            }

            return View(medicoViewModel);
        }

        // GET: MedicoViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			MedicoViewModel medicoViewModel = Mapper.Map<Medico, MedicoViewModel>(db.GetById(id.Value));
            if (medicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicoViewModel);
        }

        // POST: MedicoViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Especialidade,NumeroConselhoRegionalVeterinaria")] MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
				db.Update(Mapper.Map<MedicoViewModel, Medico>(medicoViewModel));
                return RedirectToAction("Index");
            }
            return View(medicoViewModel);
        }

        // GET: MedicoViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoViewModel medicoViewModel = Mapper.Map<Medico, MedicoViewModel>(db.GetById(id.Value));
			if (medicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicoViewModel);
        }

        // POST: MedicoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			db.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
