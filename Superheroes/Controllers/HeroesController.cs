using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class HeroesController : Controller
    {
        ApplicationDbContext context;
        public HeroesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Heroes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Heroes/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Heroes.Add(hero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Heroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(Hero hero)
        {

            if (ModelState.IsValid)
            {
                var deleteHero = context.Heroes.Where(h => hero.ID.Equals(hero.ID)).First();
                context.Heroes.Remove(deleteHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hero);
        }
    }

        // POST: Heroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
