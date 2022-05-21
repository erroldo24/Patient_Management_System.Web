using AutoMapper;
using Patient_Management_System.Web.Data;
using Patient_Management_System.Web.Models;

namespace Patient_Management_System.Web.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<Patient, PatientVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
