using HR.LeaveManagement.Application.Shared_DTOs;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public record GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationDto>>;
}