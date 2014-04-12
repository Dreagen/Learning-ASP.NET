using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTodo.Models;

namespace MyTodo.Controllers
{
    public class TodosController : Controller
    {
        private TodoDbContext db = new TodoDbContext();

        // GET: /Todos/
        public ActionResult Index()
        {
            return View(db.Todos.ToList());
        }

        // GET: /Todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: /Todos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Completed,Message")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Todos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: /Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: /Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string message)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo1 = db.Todos.Find(id);
            todo1.Message = message;
            System.Diagnostics.Debug.Write(message);
            db.Entry(todo1).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST /Todos/Completed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Completed(int id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo.Completed == true)
                todo.Completed = false;
            else
                todo.Completed = true;
            db.Entry(todo).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST /Todos/New/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(string message) {
            if (message == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = new Todo();
            todo.Message = message;
            db.Todos.Add(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST /Todos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            db.Todos.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Todos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Todo todo = db.Todos.Find(id);
        //    db.Todos.Remove(todo);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
