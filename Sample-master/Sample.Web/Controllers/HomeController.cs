using Sample.Entity;
using Sample.Repository;
using Sample.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Sample.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IPeopleRepository _repository;

        public HomeController(IPeopleRepository r)
        {
            this._repository = r;
        }

        public HomeController()
        {
            this._repository = new PeopleRepository(); ;
        }

        // GET
        //See the data and get the list of peoples
        public ActionResult Index()
        {
            var model = _repository.GetPeoples();
            return View(model);
        }

        public ActionResult GetPeoples()
        {
            return PartialView("_SearchPeople", _repository.GetPeoples());

        }

        //Get the search result bansed on search query and return partial view.
        [HttpGet]
        public PartialViewResult GetPeopleSearch(string q)
        {
            var model = _repository.GetSearchPeoples(q);
            return PartialView("_SearchPeople", model);
        }

        // GET
        // Add new people
        public ActionResult AddPeople()
        {
            return View();

        }

        

        // Called after page post back
        // Get the field values, people image and save this in database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPeople(PeopleViewModel model, HttpPostedFileBase Image)
        {
            List<PeopleInterests> pi = new List<PeopleInterests>();
            int j = 0;

            // If user has selected any interest.
            if (model.PeopleInterest != null)
            {
                foreach (var i in model.PeopleInterest)
                {
                    pi.Add(new PeopleInterests { InterestID = j++, PeopleID = 0, Interest = i });
                }
            }

            // if user has interests store it in People Interest.  
            if (pi != null && pi.Count > 0)
                model.People.Interests = pi;

            
            // if user has uploaded an image, convert it to binary and store in People Image.
            if (Image!=null && Image.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(Image.InputStream))
                {
                    imageData = binaryReader.ReadBytes(Image.ContentLength);
                }
                var peopleImage = new PeopleImage
                {
                    Image = imageData,
                    ImageID = 1,
                    PeopleID = 0
                };
                model.People.PeopleImage = peopleImage;
            }


            var peopleModel = _repository.AddPeople(model.People);
            return View("Index", peopleModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}