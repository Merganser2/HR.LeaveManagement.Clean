﻿using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorWebAssyUI.Models
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
