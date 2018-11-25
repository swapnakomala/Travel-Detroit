﻿using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using TravelDetroit.Models;
using System.Linq;

namespace TravelDetroit.Controllers
{
    public class UserProfilesController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        public UserProfilesController()
        {
        }

        // GET: UserProfiles
        public ActionResult Index()
        {
            var user = new UserProfile();
            return View(user);
        }

        public ActionResult AddLocationToUser(int id)
        {
            return View("AddLocationToUser", id);
        }

        [HttpGet()]
        public async System.Threading.Tasks.Task<ContentResult> PlaceSearch(string searchText)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(
                    "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?" +
                    "input=" + searchText +
                    "&inputtype=textquery" +
                    "&fields=formatted_address,geometry,icon,id,name,permanently_closed,photo,place_id,type" +
                    "&key=AIzaSyDZh7Jb0tW0K4CJ5bO9ozvaFAFxabdT-T4" +
                    "&locationbias=circle:20000@42.3330,-83.0465");
                return Content(response);

            }
        }

        [HttpPost]
        public void SaveLocationToUser()
        {
        }
    }
}