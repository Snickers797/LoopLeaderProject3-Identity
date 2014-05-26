using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LoopLeader.Models
{
    public class EmailResponse
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your comment or question.")]
        public string Comment { get; set; }
    }
}