using Ninject;
using Superheroes.Domain;
using Superheroes.Logic;
using Superheroes.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Web.Controllers
{
    [Authorize]
    public class TalentsController : Controller
    {
        [Inject]
        public SuperheroesBusinessLogic Superheroes { get; set; }

        public ActionResult Details(int id)
        {
            SuperheroTalent talent = Superheroes.GetSuperheroTalent(id);
            if (talent != null)
            {
                return View(new TalentViewModel(talent, this.Request.RequestContext));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SuperheroTalent model = Superheroes.GetSuperheroTalent(id);
            if (model != null)
            {
                ViewBag.TalentId = id;
                return View(new EditTalentViewModel(model));
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, EditTalentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SuperheroTalent model = Superheroes.GetSuperheroTalent(id);
                model.Name = viewModel.Name;
                model.Details = viewModel.Details;
                if (viewModel.PictureFile != null)
                {
                    model.Image = ImageController.CreateDbFileFromHttpFile(viewModel.PictureFile);
                }
                Superheroes.UpdateTalent(model);
                return RedirectToAction("Details", new { id = model.TalentId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult New(int id)
        {
            return View(new NewTalentViewModel() { SuperheroId = id });
        }

        [HttpPost]
        public ActionResult New(NewTalentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SuperheroTalent model = Superheroes.AddSuperheroTalent(
                    new SuperheroTalent()
                    {
                        OwnerId = viewModel.SuperheroId,
                        Name = viewModel.Name,
                        Details = viewModel.Details,
                        Image = ImageController.CreateDbFileFromHttpFile(viewModel.PictureFile)
                    }
                );
                return RedirectToAction("Details", new { id = model.TalentId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            SuperheroTalent model = Superheroes.GetSuperheroTalent(id);
            if (model != null)
            {
                Superheroes.DeleteSuperheroTalent(model);
                return RedirectToAction("Details", "Superheroes", new { id = model.OwnerId });
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}