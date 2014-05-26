using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLeader.Domain.Entities
{
    public class Member
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Login Name")]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Must be less than 20 characters")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                    ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Less than 100 characters")]
        public string StreetAddress1 { get; set; }

        [StringLength(100, ErrorMessage = "Less than 100 characters")]
        public string StreetAddress2 { get; set; }

        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        public string City { get; set; }

        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]

        public string State { get; set; }

        [StringLength(20, ErrorMessage = "Must be less than 20 characters")]
        public string Zip { get; set; }

        public bool IsAdmin { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
    }
}
