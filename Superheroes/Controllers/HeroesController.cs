using Microsoft.AspNet.Identity;
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
        ApplicationDbContext db;
        public HeroesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Heroes
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            return View(db.Heroes.ToList());
        }


        // GET: Heroes/Details/5
        public ActionResult Details(int ID)
        {
            var hero = db.Heroes.Where(h => h.ID == ID).First();
            return View(hero);
        }
    

        // GET: Heroes/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Heroes/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, Name, AlterEgo, PrimaryAbility, SecondaryAbility, CatchPhrase")] Hero hero) 
        {
            try
            {
                // TODO: Add insert logic here
                db.Heroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int ID)
        {
            var hero = db.Heroes.Where(h => h.ID == ID).First();
            return View(hero);
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
        public ActionResult Delete(Hero hero )
        {

            if (ModelState.IsValid)
            {
                var deleteHero = db.Heroes.Where(h => hero.ID.Equals(hero.ID)).First();
                db.Heroes.Remove(deleteHero);
               db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hero);
        }

        // POST: Heroes/Delete/5

        [HttpPost]
        public ActionResult Delete(int ID, FormCollection collection)
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

        [HttpPost]
        public ActionResult Details([Bind(Include = "")]Hero hero)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, Name, AlterEgo, PrimaryAbility, SecondaryAbility, CatchPhrase")] Hero hero)
        {
            var updatedHero = db.Heroes.Where(h => h.ID == hero.ID).FirstOrDefault();
            updatedHero.Name = hero.Name;
            updatedHero.AlterEgo = hero.AlterEgo;
            updatedHero.PrimaryAbility = hero.PrimaryAbility;
            updatedHero.SecondaryAbility = hero.SecondaryAbility;
            updatedHero.CatchPhrase = hero.CatchPhrase;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
