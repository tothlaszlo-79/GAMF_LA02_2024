using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAMF_LA02.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [DisplayName("Tantárgy")]
        public string Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
