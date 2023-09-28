using HR.LeaveManagement.BlazorWebAssyUI.Contracts;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;

namespace HR.LeaveManagement.BlazorWebAssyUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        public LeaveTypeService(IClient client) : base(client)
        {
        }
    }

}
