using HR.LeaveManagement.BlazorWebAssyUI.Contracts;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;

namespace HR.LeaveManagement.BlazorWebAssyUI.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }
    }

}
