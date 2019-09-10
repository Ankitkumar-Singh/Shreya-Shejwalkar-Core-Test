using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace CandidateQualifications.Models
{
    public class Qualification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [RegularExpression("^([a-zA-Z '-]+)(?<!\\s)$", ErrorMessage = "Please enter valid Title (Alphabets only)")]
        [MaxLength(40, ErrorMessage = "Title should contain only 40 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please select passing year")]        
        public virtual int? PassingYear { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        [RegularExpression("^([A-Za-z0-9, ]{3,})$", ErrorMessage = "Description contains alphabets, numbers and (,) ")]
        [MaxLength(400, ErrorMessage = "Description should contain only 400 characters")]
        public string Description { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}
