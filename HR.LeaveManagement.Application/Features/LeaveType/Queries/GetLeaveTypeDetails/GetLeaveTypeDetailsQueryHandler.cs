using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query 
        var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // verify that record exists
        if (leaveTypeDetails == null)
        {
            return new LeaveTypeDetailsDto() { Id=0, DefaultDays=0, Name = "Invalid Leave Type" }; // whatever
            // Later will implement custom Exceptions
            //    throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        var leaveTypeDetailsDto = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);
        return leaveTypeDetailsDto;
    }
}
