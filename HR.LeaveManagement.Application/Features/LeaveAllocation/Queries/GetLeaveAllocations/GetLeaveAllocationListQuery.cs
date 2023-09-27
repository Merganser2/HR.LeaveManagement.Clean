using HR.LeaveManagement.Application.Shared_DTOs;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    // "Id" is a field in the record; had this been a class, it would have been a Property
    public record GetLeaveAllocationListQuery(int Id) : IRequest<List<LeaveAllocationDto>>;
}