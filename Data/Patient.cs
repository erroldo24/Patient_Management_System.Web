using System.ComponentModel.DataAnnotations.Schema;

namespace Patient_Management_System.Web.Data
{
    public class Patient : BaseEntity
    {
        public string name { get; set; }
        public string age { get; set; }
        public string contactNumber { get; set; }
        public string disease { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        public string status { get; set; }
        public string remarks { get; set; }
    }
}
