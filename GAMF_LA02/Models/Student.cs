using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GAMF_LA02.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Vezeték név")]
        [Required(ErrorMessage ="Vezeték név kitöltése kötelező")]
        public string LastName { get; set; }

        [DisplayName("Kereszt név")]
        [Required(ErrorMessage = "Kereszt név kitöltése kötelező")]
        public string FirstMidName { get; set; }

        [DisplayName("Vizsga dátuma")]
        [Required(ErrorMessage = "Vizsga dátuma mező kitöltése kötelező")]
        public DateTimeOffset EnrollmentDate { get; set; }
        
        [DisplayName("Vizsgák")]
        public virtual ICollection<Enrollment>  Enrollments { get; set; }

    }
}
