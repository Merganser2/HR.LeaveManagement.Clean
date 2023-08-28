using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }

    public LeaveType? leaveType { get; set; }  // Why nullable? Can we have an allocation without a Leave Type? maybe...
    public int LeaveTypeId { get; set; }
    
    public int Period { get; set; }
}