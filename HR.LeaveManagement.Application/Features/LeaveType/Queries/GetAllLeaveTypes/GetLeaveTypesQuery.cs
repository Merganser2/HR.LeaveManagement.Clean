using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    /*    public class GetLeaveTypesQuery : IRequest<LeaveTypeDto> // from MediatR
        { };
    */
    // Can be a record as it will not change
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;

}
