using HR.LeaveManagement.BlazorWebAssyUI.Models;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;

namespace HR.LeaveManagement.BlazorWebAssyUI.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetails(int id);

        // The below are to handle custom View Model return types
        Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
        Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
        Task<Response<Guid>> DeleteLeaveType(int id);
    }
}
