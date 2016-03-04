using Ninject;
using Superheroes.Domain;
using Superheroes.Logic;
using Superheroes.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Web.Controllers
{
    [Authorize]
    public class SuperheroesController : Controller
    {
        [Inject]
        public SuperheroesBusinessLogic Superheroes { get; set; }

        [HttpGet]
        public ActionResult List()
        {
            return View(new SuperheroesListViewModel(Superheroes.GetSuperheroes(), this.Request.RequestContext));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Superhero model = Superheroes.GetSuperhero(id);
            if (model != null)
            {
                SuperheroViewModel viewModel = new SuperheroViewModel(model, this.Request.RequestContext);
                viewModel.Talents = Superheroes.GetSuperheroTalents(id).
                    Select(m => new TalentViewModel(m, this.Request.RequestContext)).
                    ToList<TalentViewModel>();
                return View(viewModel);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewDialog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(NewSuperheroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Superhero model = Superheroes.AddSuperhero(
                    new Superhero()
                    {
                        Name = viewModel.Name,
                        Details = viewModel.Details,
                        HeroLevel = viewModel.HeroLevel,
                        Image = ImageController.CreateDbFileFromHttpFile(viewModel.PictureFile)
                    }
                );
                return RedirectToAction("Details", new { id = model.SuperheroId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Superhero model = Superheroes.GetSuperhero(id);
            if (model != null)
            {
                ViewBag.SuperheroId = id;
                return View(new EditSuperheroViewModel(model));
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, EditSuperheroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Superhero model = Superheroes.GetSuperhero(id);
                model.Name = viewModel.Name;
                model.Details = viewModel.Details;
                model.HeroLevel = viewModel.HeroLevel;
                if (viewModel.PictureFile != null)
                {
                    model.Image = ImageController.CreateDbFileFromHttpFile(viewModel.PictureFile);
                }
                Superheroes.UpdateSuperhero(model);
                return RedirectToAction("Details", new { id = model.SuperheroId });
            }
            else
            {
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            Superheroes.DeleteSuperhero(id);
            return RedirectToAction("Index", "Home");
        }
    }
}