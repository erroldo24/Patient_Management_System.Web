using System.ComponentModel.DataAnnotations;

namespace Patient_Management_System.Web.Data
{
    public class Doctor : BaseEntity
    {
        [Display(Name = "Doctor")]
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}
