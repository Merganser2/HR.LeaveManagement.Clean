using HR.LeaveManagement.BlazorWebAssyUI.Contracts;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;

namespace HR.LeaveManagement.BlazorWebAssyUI.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAllocationService(IClient client) : base(client)
        {
        }
    }

}
