﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentProfileP1.ViewModel
{
    public class StudentIndexModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression("([A-Z*a-z]+)", ErrorMessage = "Please enter valid Name")]
        [StringLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [Required]
        public DateTime AdmitionDate { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        public Boolean IsGender { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("CGPA")]
        public double Cgpa { get; set; }
        [Required]
        [DisplayName("Department")]
        public string Department { get; set; }

        [Required]
        public string Password { get; set; }

        public string Gender
        {
            get
            {
                if (IsGender)
                    return "Male";
                else
                    return "Female";
            }
            set
            {

            }
        }
    }
}
