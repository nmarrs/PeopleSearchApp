using PeopleSearch.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class SearchController : Controller
    {
        private PeopleSearchContext db = new PeopleSearchContext();

        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        public JsonResult GetAllPeople()
        {
            var data = db.Persons.ToList();
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //Get method that returns all people records in the form of datatype JSON
        //JSON is javascript object that is basically an array of objects which store misc. data

        public JsonResult SearchPeopleJson(string keyword)
        {
            var data = db.Persons.Where(f =>
            f.FirstName.Contains(keyword)).ToList();
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; ; 
        }
        //Get method that returns people records who's first name contains the parameter keyword
        //The records are converted to json data type so that javascript can easily use it (seen in Search.cshtml view)
        //Possibly add functionality to handle null and non matching keyword values

        public ActionResult SearchInfo()
        {
            return View();
        }
        //GET search info view



    }
}