using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodReal.Models
{
    public class Request
    {
        [Key]
        [Required(ErrorMessage = "Must Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [DisplayName("First And Last Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [EmailAddress]
        [DisplayName("Enter Your E-Mail")]

        public string email { get; set; }
        [Required(ErrorMessage = "Must Required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Must Required")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [Phone]
        [DisplayName("Enter Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [DisplayName("Enter Your CNIC")]
        
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Must Required")]
        [StringLength(150, MinimumLength = 5)]
        [DisplayName("Addess")]
        public string address { get; set; }

        [StringLength(200,MinimumLength =5)]
        [DisplayName("Why You need Blood?")]
        public string  message { get; set; }


    }
}