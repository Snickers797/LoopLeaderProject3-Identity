using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLeader.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        List<RegisterViewModel> members = new List<RegisterViewModel>();
        public List<RegisterViewModel> Members { get { return members; } }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //Supplemental Fields exting the Application User Class
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                    ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [StringLength(100, ErrorMessage = "Less than 100 characters")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Must be less than 20 characters")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode must be 5 or 9 digits in length")]
        [RegularExpression(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z]\d[a-zA-Z]\d)$")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(65, ErrorMessage = "Must be less than 65 characters")]
        public string Country { get; set; }

        //Returns a pre-populated instance of ApplicationUser
        public ApplicationUser GetUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                FirstName = this.FirstName,
                LastName = this.LastName,
                EmailAddress = this.EmailAddress,
                StreetAddress = this.StreetAddress,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Country = this.Country,
            };
            return user;
        }

        public class EditUserViewModel
        {
            public EditUserViewModel() { }

            // Allow Initialization with an instance of ApplicationUser:
            public EditUserViewModel(ApplicationUser user)
            {
                this.UserName = user.UserName;
                this.FirstName = user.FirstName;
                this.LastName = user.LastName;
                this.EmailAddress = user.EmailAddress;
                this.StreetAddress = user.StreetAddress;
                this.City = user.City;
                this.State = user.State;
                this.ZipCode = user.ZipCode;
                this.Country = user.Country;
            }

            [Required]
            [Display(Name = "User name")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Please enter an Email Address")]
            [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                        ErrorMessage = "Email Format is wrong")]
            [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
            [Display(Name = "Email Address")]
            public string EmailAddress { get; set; }

            [StringLength(100, ErrorMessage = "Less than 100 characters")]
            [Display(Name = "Street Address")]
            public string StreetAddress { get; set; }

            [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
            [Display(Name = "City")]
            public string City { get; set; }

            [StringLength(20, ErrorMessage = "Must be less than 20 characters")]
            [Display(Name = "State")]
            public string State { get; set; }

            [Required(ErrorMessage = "Zipcode must be 5 or 9 digits in length")]
            [RegularExpression(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z]\d[a-zA-Z]\d)$")]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Required]
            [Display(Name = "Country")]
            [StringLength(65, ErrorMessage = "Must be less than 65 characters")]
            public string Country { get; set; }

        }
    }

}
