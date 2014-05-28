using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using LoopLeader.Models;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;
using LoopLeader.Domain.Abstract;

namespace LoopLeader.Controllers
{
    public class Admin2Controller : Controller
    {
        private IProduct productRepository;
        private IContent contentRepository;
        private IUser userRepository;

        public Admin2Controller()
        {
            userRepository = new ApplicationUser();
            productRepository = new ProductRepository();
            contentRepository = new ContentRepository();
        }

        public Admin2Controller(UserManager<ApplicationUser> userManager, IProduct productRepository, IContent contentRepository)
        {
            UserManager = userManager;
            ProductRepository prodRepo = new ProductRepository();
            ContentRepository contentRepo = new ContentRepository();
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
	}
}