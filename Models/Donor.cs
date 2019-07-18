using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodReal.Models
{
    public class Donor
    {
        [Key]
        [Required(ErrorMessage ="Must Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [DisplayName("First And Last Name")]
        public string  name { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [EmailAddress]
        [DisplayName("Enter Your E-Mail")]

        public string email { get; set; }
        [Required(ErrorMessage = "Must Required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Must Required")]
        public string  Province { get; set; }
        [Required(ErrorMessage = "Must Required")]
        [Phone]
        [DisplayName("Enter Phone Number")]
        public string  Phone { get; set; }
        [Required(ErrorMessage = "Must Required")]
        public string  CNIC { get; set; }
        [Required(ErrorMessage ="Must Required")]
        [DisplayName("Blood Group")]
        public string blood_group { get; set; }

        [Required(ErrorMessage = "Must Required")]
        [StringLength(150,MinimumLength =5)]
        public string address { get; set; }
        //[Required(ErrorMessage = "Must Required")]
        //[DataType(DataType.Password)]
        [DisplayName("Enter Your Password")]
        public string password { get; set; }
       // [Required(ErrorMessage = "Must Required")]
        //[DataType(DataType.Password)]
        //[Compare("Password" , ErrorMessage ="Password Must Match")]
       // [DisplayName("Confirm Password")]
        public string cnfrmpassword { get; set; }

    }
}