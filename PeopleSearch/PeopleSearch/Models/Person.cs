//Person model class that is basically the skeleton of the Person table in the database
//This class includes Regex + validations that are checked when the admin adds a new person

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeopleSearch.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [Required]
        [DisplayName("Address Line 1")]
        public String AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public String AddressLine2 { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        [RegularExpression(@"^(?:(A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]))$", ErrorMessage = "Please Enter Valid 2 Digit US State Code")]
        public String State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}([\-]\d{4})?$", ErrorMessage = "Please Enter Valid US ZIP Code")]
        public String ZIP { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public String Email { get; set; }

        [Required]
        [DisplayName("Primary Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?\(?\d+\)?(\s|\-|\.)?\d{1,3}(\s|\-|\.)?\d{4}[\s]*[\d]*$", ErrorMessage = "Please Enter Phone Number In (xxx) xxx-xxxx Format")]
        public String PrimaryPhone { get; set; }
        //Still need to fix this to only accept desired formatting

        [DataType(DataType.Text)]
        [Required]
        public String Interests { get; set; }

        [DataType(DataType.ImageUrl)]
        public String Picture { get; set; }
    }
}