using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateQualifications.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name cannot be empty")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Name contains only alphabets")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Name contains only alphabets")]
        [MaxLength(30, ErrorMessage = "Name should contain only 30 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address cannot be empty")]
        [RegularExpression("^([A-Za-z0-9, ]{3,})$", ErrorMessage = "Address contains alphabets, numbers and (,) ")]
        [MaxLength(300, ErrorMessage = "Address should contain only 300 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Contact cannot be empty")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter 10 digit number only")]      
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Select Nationality")]
        public Nationalities Nationality { get; set; }

        [Required(ErrorMessage = "Date field cannot be empty")]
        [DataType(DataType.Date)]
        [ValidateDateRange]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]       
        public System.DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please accept the terms")]
        public bool AcceptTerm { get; set; }

        [Required(ErrorMessage = "Please select Qualification")]
        public int QualificationId { get; set; }
        [ForeignKey("QualificationId")]
        public virtual Qualification Qualification { get; set; }
    }
    public enum Nationalities
    {
       Indian = 1,
       American = 2,
       African = 3,
       Korean = 4
    }

}
