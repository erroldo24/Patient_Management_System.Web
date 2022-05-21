using Patient_Management_System.Web.Contracts;
using Patient_Management_System.Web.Data;

namespace Patient_Management_System.Web.Repositoriesy
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
