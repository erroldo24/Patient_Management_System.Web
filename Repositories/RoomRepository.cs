using Patient_Management_System.Web.Contracts;
using Patient_Management_System.Web.Data;

namespace Patient_Management_System.Web.Repositoriesy
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
