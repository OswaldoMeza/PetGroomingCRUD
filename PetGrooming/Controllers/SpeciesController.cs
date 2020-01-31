using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //what data do we need?
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }

        // Show

        public ActionResult Show(int id)
        {
            string query = "select * from species where SpeciesID = @id";
            SqlParameter parameter = new SqlParameter("@id", id);

            Species selectedspecies = db.Species.SqlQuery(query, parameter).First();

            return View(selectedspecies);
        }
        // Add

        public ActionResult Add()
        {
            return View();
        }
        // [HttpPost] Add

        [HttpPost]
        public ActionResult Add(string SpeciesName )
        {
            string query = "insert into species (Name) values (@SpeciesName)";

            SqlParameter parameter = new SqlParameter("@SpeciesName", SpeciesName);

            db.Database.ExecuteSqlCommand(query, parameter);

            return RedirectToAction("List");

            //return View();
        }
        // Update

        public ActionResult Update(int id)
        {
            //we need the species name
            string query = "select * from species where SpeciesID = @id";
            SqlParameter parameter = new SqlParameter("@id", id);

            Species selectedspecies = db.Species.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedspecies);
        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            Debug.WriteLine(SpeciesName + id.ToString());
            string query = "update species set Name = @SpeciesName where SpeciesID=@id";
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@id", id);
            parameters[1] = new SqlParameter("@SpeciesName", SpeciesName);

            db.Database.ExecuteSqlCommand(query, parameters);

            return RedirectToAction("List");
        }
        // (optional) delete

        public ActionResult Delete(int id)
        {
            string query = "delete from species where SpeciesID=@id";
            SqlParameter parameter = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);

            return RedirectToAction("List");
        }
        // [HttpPost] Delete
    }
}