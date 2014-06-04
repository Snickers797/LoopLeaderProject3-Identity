using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;
using LoopLeader.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace LoopLeader.Controllers
{
    [Authorize]//(Roles = "Admin")]
    public class AdminController : Controller
    {
        public AdminController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public ActionResult Index()
        {
            return View();
        }
        //CONTENT ADMIN PAGES

        public ActionResult ContentIndex()
        {
            //Get a list of content to populate a drop down list.
            ApplicationDbContext memberContext = new ApplicationDbContext();
            LLDbContext context = new LLDbContext();
            ContentRepository repo = new ContentRepository();
            ContentViewModel contentList = new ContentViewModel() { ContentList = repo.Content.ToList<Content>() };
            return View(contentList);
        }

        [HttpPost]
        public ActionResult ContentIndex(ContentViewModel content)
        {
            //After user selects an item from the drop down list, grab its info from the database.
            ContentRepository repo = new ContentRepository();
            Content selectedContent = (from c in repo.Content
                                       where content.ContentID == c.ContentID
                                       select c).FirstOrDefault<Content>();
            selectedContent.ContentID = content.ContentID;
            //Then pass it to the form to be edited.
            return View("ContentEditForm", selectedContent);
        }

        public ViewResult ContentEditForm(Content formContent)
        {
            return View(formContent);
        }

        [HttpPost]
        public ViewResult ContentInfo(Content formContent)
        {
            ContentRepository repo = new ContentRepository();
            //After we get the information back from the form...
            if (ModelState.IsValid)
            {
                //formContent.NewText = formContent.CurrentText;
                //...update the database with it.
                formContent.UpdateSection();
            }
            //And then in this case, display a page showing the new changes.  This
            //returns the object from the database that was passed in as a parameter.
            return View((from c in repo.Content
                         where c.ContentID == formContent.ContentID
                         select c).FirstOrDefault<Content>());
        }

        //END CONTENT PAGES

        //START MEMBER PAGES

        public ActionResult MemberIndex()
        {
            var db = new ApplicationDbContext();
            var members = db.Users;
            var model = new List<EditUserViewModel>();
            foreach (var member in members)
            {
                var u = new EditUserViewModel(member);
                model.Add(u);
            }
            return View(model);
        }

        public ActionResult CreateMember()
        {
            return View("MemberEdit", new EditUserViewModel());
        }

        public ActionResult MemberEdit(string id, ManageMessageId? Message = null)
        {
            var db = new ApplicationDbContext();
            var member = db.Users.First(u => u.UserName == id);
            var model = new EditUserViewModel(member);
            ViewBag.MessageId = Message;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MemberEdit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new ApplicationDbContext();
                var member = db.Users.First(u => u.UserName == model.UserName);

                // Update the user data:
                member.UserName = model.UserName;
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.EmailAddress = model.EmailAddress;
                member.StreetAddress = model.StreetAddress;
                member.City = model.City;
                member.State = model.State;
                member.ZipCode = model.ZipCode;
                member.Country = model.Country;
                db.Entry(member).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Members");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult MemberDelete(string id = null)
        {
            var db = new ApplicationDbContext();
            var member = db.Users.First(u => u.UserName == id);
            var model = new EditUserViewModel(member);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [HttpPost, ActionName("MemberDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var db = new ApplicationDbContext();
            var member = db.Users.First(u => u.UserName == id);
            db.Users.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Members");
        }

        public ActionResult MemberRoles(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.UserName == id);
            var model = new SelectUserRolesViewModel(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberRoles(SelectUserRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var idManager = new LoopLeader.Models.ApplicationDbContext.IdentityManager();
                var Db = new ApplicationDbContext();
                var user = Db.Users.First(u => u.UserName == model.UserName);
                idManager.ClearUserRoles(user.Id);
                foreach (var role in model.Roles)
                {
                    if (role.Selected)
                    {
                        idManager.AddUserToRole(user.Id, role.RoleName);
                    }
                }
                return RedirectToAction("Members");
            }
            return View();
        }
     
        //END MEMBER PAGES

        //START PRODUCT PAGES

        public ActionResult ProductIndex()
        {
            //Get a list of content to populate a drop down list.
            ProductRepository repo = new ProductRepository();
            ProductViewModel productList = new ProductViewModel() { ProductList = repo.GetProducts.ToList<Product>() };
            return View(productList);
        }

        [HttpPost]
        public ActionResult ProductIndex(ProductViewModel product)
        {
            //After user selects an item from the drop down list, grab its info from the database.
            ProductRepository repo = new ProductRepository();
            Product selectedProduct = (from p in repo.GetProducts
                                       where product.ProductID == p.ProductID
                                       select p).FirstOrDefault<Product>();
            selectedProduct.ProductID = product.ProductID;
            //Then pass it to the form to be edited.
            return View("ProductEditForm", selectedProduct);
        }

        public ViewResult CreateProduct()
        {
            return View("ProductEditForm", new Product());
        }

        public ViewResult ProductEditForm(Product formProduct)
        {
            return View(formProduct);
        }

        [HttpPost]
        public ViewResult ProductInfo(Product formProduct)
        {
            ProductRepository repo = new ProductRepository();
            //After we get the information back from the form...
            if (ModelState.IsValid)
            {
                //...update the database with it.
                LLDbContext productDB = new LLDbContext();
                Product productToUpdate = productDB.Products.Find(formProduct.ProductID);
                if (productToUpdate != null)
                {
                    productToUpdate.Description = formProduct.Description;
                    productToUpdate.Category = formProduct.Category;
                    productToUpdate.InStock = formProduct.InStock;
                    productToUpdate.Price = formProduct.Price;
                    productToUpdate.ProductName = formProduct.ProductName;
                    //productToUpdate.Shipping = formProduct.Shipping;
                }
                productDB.SaveChanges();
            }
            //And then in this case, display a page showing the new changes.  This
            //returns the object from the database that was passed in as a parameter.
            return View((from p in repo.Products
                         where p.ProductID == formProduct.ProductID
                         select p).FirstOrDefault<Product>());
        }

        //END PRODUCT PAGES
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
