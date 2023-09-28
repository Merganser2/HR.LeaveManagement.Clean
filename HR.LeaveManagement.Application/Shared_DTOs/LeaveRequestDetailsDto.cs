namespace HR.LeaveManagement.Application.Shared_DTOs
{
    public class LeaveRequestDetailsDto : LeaveRequestListDto
    {
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
//        public bool Cancelled { get; set; }  Is there a reason this needs to not be nullable for Details?
    }
}