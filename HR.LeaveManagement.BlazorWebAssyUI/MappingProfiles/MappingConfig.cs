using AutoMapper;
using HR.LeaveManagement.BlazorWebAssyUI.Models;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;

namespace HR.LeaveManagement.BlazorWebAssyUI.MappingProfiles
{
    /// <summary>
    /// AutoMapper configurations WITHIN this UI project; note that
    ///  LeaveTypeDto and other DTOs are defined within the Base client (ServiceClient),
    ///  NOT from the corresponding objects in the Core Application !!!
    ///  Same is true for the Feature Commands and Queries...
    /// </summary>
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestVM>().ReverseMap();
        }
    }
}
