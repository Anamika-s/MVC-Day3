using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day3.Models
{
    public class User
    {
        [Required(ErrorMessage ="Please provide Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Name")]
        [MinLength(10, ErrorMessage ="Min 10 alphabets needed")]
        [StringLength(30, ErrorMessage ="MAx 30 chracters are allowed")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage ="Only alphabets allowed")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Remote("checkdate", "employee", ErrorMessage ="Doj shud be less than current date")]
        public DateTime Doj { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ReTypePassword { get; set; }
        [Range(20,50, ErrorMessage ="Age shud be between 20 and 50")]
        public int? Age { get; set; }
        [JoingYearVaildator]
        public int? JoinigYear { get; set; }
    }
}
