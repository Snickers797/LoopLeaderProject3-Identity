using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Concrete;
using LoopLeader.Models;

namespace LoopLeader.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ContentRepository repo = new ContentRepository();
            Content homeContent = (from hc in repo.Content
                                   where hc.ContentID == "Home"
                                   select hc).FirstOrDefault<Content>();
            return View(homeContent);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Contact1()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Contact(EmailResponse emailResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thankyou", emailResponse);//Thank you, we will respond asap.
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
        
        public ViewResult Thankyou(EmailResponse emailResponse)
        {
            return View();
        }

    }
}