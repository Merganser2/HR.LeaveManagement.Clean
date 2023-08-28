using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class LeaveTypeDetailsDto : LeaveTypeDto // Might be a SOC objections about this; but seems to me a shared DTO folder could be created below Queries
    {
/* TODO: Decide if this inheritance is a good idea or not, and resolve
 * public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; } */

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}