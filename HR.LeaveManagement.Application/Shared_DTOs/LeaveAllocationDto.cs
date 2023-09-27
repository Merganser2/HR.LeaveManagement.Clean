﻿using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.LeaveManagement.Application.Shared_DTOs
{
    public class LeaveAllocationDto
    {
        public int Id { get; set; }

        public int NumberOfDays { get; set; }

        public LeaveTypeDto LeaveType { get; set; }  
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
