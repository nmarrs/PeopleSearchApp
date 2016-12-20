/*
 * Application Name: People Search
 * Version: 1.0
 * 
 * Application Description:
 * 
 * Business Requirements
 * The application accepts search input in a text box and then displays in a pleasing style a list of people
 * whose first name matches what was typed in the search box (displaying at least name, address, age, interests, and a picture). 
 * Solution seeds data and provides a way to enter new users
 * 
 * Technical Requirements
 * ASP.NET MVC Application
 * Uses Ajax to respond to search request (no full page refresh) using JSON for both the request and the response
 * Uses Entity Framework Code First to talk to the database
 * Unit Tests are found in the Person.cs model
 *
 * Creator:
 * Nathan Marrs
 * 12/19/2016
 * 
 * Possible applciation additions:
 * -Google maps API to display address
 * -Misc improvements (some found in commenting around project)
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //GET Home View
    }
}